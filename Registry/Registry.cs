using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using Registry;
using System.Windows.Forms;

namespace Registry
{
    public class RegistryService : IDisposable
    {
        private const uint KEY_NOTIFY = 0x0010;
        private const uint STANDARD_RIGHTS_READ = 0x00020000;
        private const uint SYNCHRONIZE = 0x00100000;
        private const int REG_NOTIFY_CHANGE_NAME = 0x00000001;
        private const int REG_NOTIFY_CHANGE_ATTRIBUTES = 0x00000002;
        private const int REG_NOTIFY_CHANGE_LAST_SET = 0x00000004;
        private const int REG_NOTIFY_CHANGE_SECURITY = 0x00000008;

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern int RegNotifyChangeKeyValue(
            IntPtr hKey,
            bool bWatchSubtree,
            int dwNotifyFilter,
            IntPtr hEvent,
            bool fAsynchronous);

        private readonly string _logPath;
        private FileStream _logStream;
        private readonly object _logLock = new object();
        private CancellationTokenSource _monitorCts;

        public event EventHandler<RegistryChangedEventArgs> RegistryChanged;

        public RegistryService(string logFilePath)
        {
            _logPath = logFilePath;
            Directory.CreateDirectory(Path.GetDirectoryName(_logPath));
            _logStream = new FileStream(_logPath, FileMode.Append, FileAccess.Write, FileShare.Read);
        }

        public void LoadRootNodes(TreeView tree)
        {
            tree.Nodes.Clear();
            foreach (var hive in new[] { Registry.LocalMachine, Registry.CurrentUser, Registry.ClassesRoot, Registry.Users, Registry.CurrentConfig })
            {
                var rootNode = new TreeNode(hive.Name) { Tag = hive.Name };
                rootNode.Nodes.Add(new TreeNode()); // dummy node
                tree.Nodes.Add(rootNode);
            }
        }

        public void LoadSubKeys(TreeNode node)
        {
            node.Nodes.Clear();
            string hiveName = node.Tag.ToString();
            using (var baseKey = GetBaseKey(hiveName))
            using (var key = baseKey.OpenSubKey(GetSubPath(node)))
            {
                if (key == null) return;
                foreach (var name in key.GetSubKeyNames())
                {
                    var child = new TreeNode(name) { Tag = node.Tag };
                    child.Nodes.Add(new TreeNode());
                    node.Nodes.Add(child);
                }
            }
        }

        public RegistryValueInfo[] GetValues(string fullPath)
        {
            using (var key = OpenWritableKey(fullPath))
            {
                if (key == null) return Array.Empty<RegistryValueInfo>();
                var names = key.GetValueNames();
                var list = new List<RegistryValueInfo>();
                foreach (var name in names)
                {
                    list.Add(new RegistryValueInfo
                    {
                        Name = name,
                        Value = key.GetValue(name),
                        Kind = key.GetValueKind(name)
                    });
                }
                return list.ToArray();
            }
        }

        public void CreateKey(string fullPath)
        {
            using (var key = OpenWritableKey(GetParentPath(fullPath)))
            {
                key.CreateSubKey(GetKeyName(fullPath));
                LogChange(fullPath, ChangeType.KeyCreated, null);
            }
        }

        public void DeleteKey(string fullPath)
        {
            using (var key = OpenWritableKey(GetParentPath(fullPath)))
            {
                key.DeleteSubKeyTree(GetKeyName(fullPath), false);
                LogChange(fullPath, ChangeType.KeyDeleted, null);
            }
        }

        public void SetValue(string fullPath, string name, object value, RegistryValueKind kind)
        {
            using (var key = OpenWritableKey(fullPath))
            {
                key.SetValue(name, value, kind);
                LogChange(fullPath, ChangeType.ValueChanged, $"{name}={value}");
            }
        }

        public void DeleteValue(string fullPath, string name)
        {
            using (var key = OpenWritableKey(fullPath))
            {
                key.DeleteValue(name, false);
                LogChange(fullPath, ChangeType.ValueDeleted, name);
            }
        }

        public void StartMonitoring(string hiveName)
        {
            StopMonitoring();
            _monitorCts = new CancellationTokenSource();
            Task.Run(() => MonitorLoop(hiveName, _monitorCts.Token));
        }

        public void StopMonitoring()
        {
            if (_monitorCts != null)
            {
                _monitorCts.Cancel();
                _monitorCts = null;
            }
        }

        private void MonitorLoop(string hiveName, CancellationToken token)
        {
            using (var baseKey = GetBaseKey(hiveName))
            {
                IntPtr hKey = baseKey.Handle.DangerousGetHandle();
                while (!token.IsCancellationRequested)
                {
                    int result = RegNotifyChangeKeyValue(
                        hKey,
                        true,
                        REG_NOTIFY_CHANGE_NAME | REG_NOTIFY_CHANGE_LAST_SET,
                        IntPtr.Zero,
                        false);
                    if (result == 0)
                    {
                        OnRegistryChanged(new RegistryChangedEventArgs(hiveName));
                        Thread.Sleep(100); // debounce
                    }
                }
            }
        }

        protected virtual void OnRegistryChanged(RegistryChangedEventArgs e)
        {
            RegistryChanged?.Invoke(this, e);
            LogChange(e.HivePath, ChangeType.RegistryChanged, null);
        }

        private void LogChange(string path, ChangeType type, string data)
        {
            string entry = $"{DateTime.UtcNow:O} | {type} | {path}";
            if (!string.IsNullOrEmpty(data)) entry += $" | {data}";
            lock (_logLock)
            {
                byte[] bytes = Encoding.UTF8.GetBytes(entry + Environment.NewLine);
                _logStream.Write(bytes, 0, bytes.Length);
                _logStream.Flush();
            }
        }

        private RegistryKey GetBaseKey(string hiveName)
        {
            return hiveName switch
            {
                "HKEY_LOCAL_MACHINE" => Registry.LocalMachine,
                "HKEY_CURRENT_USER" => Registry.CurrentUser,
                "HKEY_CLASSES_ROOT" => Registry.ClassesRoot,
                "HKEY_USERS" => Registry.Users,
                "HKEY_CURRENT_CONFIG" => Registry.CurrentConfig,
                _ => throw new ArgumentException("Unknown hive"),
            };
        }

        private string GetSubPath(TreeNode node)
        {
            var parts = new Stack<string>();
            var current = node;
            while (current.Parent != null)
            {
                parts.Push(current.Text);
                current = current.Parent;
            }
            return string.Join("\\", parts);
        }

        private RegistryKey OpenWritableKey(string fullPath)
        {
            var idx = fullPath.IndexOf('\\');
            string hive = fullPath;
            string sub = string.Empty;
            if (idx >= 0)
            {
                hive = fullPath.Substring(0, idx);
                sub = fullPath.Substring(idx + 1);
            }
            var baseKey = GetBaseKey(hive);
            return baseKey.OpenSubKey(sub, true) ?? baseKey.CreateSubKey(sub);
        }

        private string GetParentPath(string fullPath)
        {
            int idx = fullPath.LastIndexOf('\\');
            return idx < 0 ? fullPath : fullPath.Substring(0, idx);
        }

        private string GetKeyName(string fullPath)
        {
            int idx = fullPath.LastIndexOf('\\');
            return idx < 0 ? fullPath : fullPath.Substring(idx + 1);
        }

        public void Dispose()
        {
            StopMonitoring();
            _logStream?.Dispose();
        }
    }

    public class RegistryChangedEventArgs : EventArgs
    {
        public string HivePath { get; }
        public RegistryChangedEventArgs(string hivePath) => HivePath = hivePath;
    }

    public class RegistryValueInfo
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public RegistryValueKind Kind { get; set; }
    }

    public enum ChangeType
    {
        KeyCreated,
        KeyDeleted,
        ValueChanged,
        ValueDeleted,
        RegistryChanged
    }
}

//namespace RegistryExplorerUI
//{
//    public partial class Form1 : Form
//    {
//        private RegistryService _service;

//        public Form1()
//        {
//            InitializeComponent();
//            string logPath = System.IO.Path.Combine(
//                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
//                "RegistryExplorer", "log.txt");
//            _service = new RegistryService(logPath);
//            _service.RegistryChanged += Service_RegistryChanged;

//            // Инициализация UI
//            _service.LoadRootNodes(treeViewRegistry);
//            chkMonitor.CheckedChanged += ChkMonitor_CheckedChanged;
//            treeViewRegistry.BeforeExpand += TreeViewRegistry_BeforeExpand;
//            treeViewRegistry.AfterSelect += TreeViewRegistry_AfterSelect;
//            btnCreateKey.Click += BtnCreateKey_Click;
//            btnDeleteKey.Click += BtnDeleteKey_Click;
//            btnSetValue.Click += BtnSetValue_Click;
//            btnDeleteValue.Click += BtnDeleteValue_Click;
//            btnOpenLog.Click += BtnOpenLog_Click;
//        }

//        private void TreeViewRegistry_BeforeExpand(object sender, TreeViewCancelEventArgs e)
//        {
//            _service.LoadSubKeys(e.Node);
//        }

//        private void TreeViewRegistry_AfterSelect(object sender, TreeViewEventArgs e)
//        {
//            string path = e.Node.FullPath;
//            var values = _service.GetValues(path);
//            listViewValues.Items.Clear();
//            foreach (var val in values)
//            {
//                var item = new ListViewItem(val.Name);
//                item.SubItems.Add(val.Kind.ToString());
//                item.SubItems.Add(val.Value?.ToString());
//                listViewValues.Items.Add(item);
//            }
//        }

//        private void BtnCreateKey_Click(object sender, EventArgs e)
//        {
//            var node = treeViewRegistry.SelectedNode;
//            if (node == null) return;
//            string newKey = txtKeyName.Text.Trim();
//            string path = node.FullPath + "\\" + newKey;
//            _service.CreateKey(path);
//            node.Nodes.Add(new TreeNode(newKey));
//        }

//        private void BtnDeleteKey_Click(object sender, EventArgs e)
//        {
//            var node = treeViewRegistry.SelectedNode;
//            if (node == null || node.Parent == null) return;
//            string path = node.FullPath;
//            if (MessageBox.Show($"Delete key {path}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
//            {
//                _service.DeleteKey(path);
//                node.Remove();
//            }
//        }

//        private void BtnSetValue_Click(object sender, EventArgs e)
//        {
//            var node = treeViewRegistry.SelectedNode;
//            if (node == null) return;
//            string path = node.FullPath;
//            string name = txtValueName.Text.Trim();
//            object value = txtValueData.Text;
//            var kind = (RegistryValueKind)Enum.Parse(typeof(RegistryValueKind), cmbValueType.SelectedItem.ToString());
//            _service.SetValue(path, name, value, kind);
//            TreeViewRegistry_AfterSelect(this, new TreeViewEventArgs(node));
//        }

//        private void BtnDeleteValue_Click(object sender, EventArgs e)
//        {
//            var node = treeViewRegistry.SelectedNode;
//            if (node == null) return;
//            if (listViewValues.SelectedItems.Count == 0) return;
//            var item = listViewValues.SelectedItems[0];
//            string name = item.Text;
//            string path = node.FullPath;
//            _service.DeleteValue(path, name);
//            TreeViewRegistry_AfterSelect(this, new TreeViewEventArgs(node));
//        }

//        private void ChkMonitor_CheckedChanged(object sender, EventArgs e)
//        {
//            if (chkMonitor.Checked)
//            {
//                _service.StartMonitoring(treeViewRegistry.Nodes[0].Tag.ToString());
//                toolStripStatusLabel.Text = "Monitoring...";
//            }
//            else
//            {
//                _service.StopMonitoring();
//                toolStripStatusLabel.Text = "Monitoring stopped.";
//            }
//        }

//        private void Service_RegistryChanged(object sender, RegistryChangedEventArgs e)
//        {
//            this.BeginInvoke((MethodInvoker)(() =>
//            {
//                toolStripStatusLabel.Text = $"Change detected in {e.HivePath} at {DateTime.Now}";
//            }));
//        }

//        private void BtnOpenLog_Click(object sender, EventArgs e)
//        {
//            System.Diagnostics.Process.Start("notepad.exe", _service.LogFilePath);
//        }

//        protected override void OnFormClosing(FormClosingEventArgs e)
//        {
//            _service.Dispose();
//            base.OnFormClosing(e);
//        }
//    }
//}
