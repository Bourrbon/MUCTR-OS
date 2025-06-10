using Microsoft.Win32;
using System;
using System.Management;
using System.Windows.Forms;

namespace RegistryApp
{
    public partial class Form1 : Form
    {
        private ManagementEventWatcher keyWatcherHKLM;
        private ManagementEventWatcher keyWatcherHKCU;
        private ManagementEventWatcher valueWatcher;

        public Form1()
        {
            InitializeComponent();
            //SetupUI();
            PopulateTreeView();
            //SetupRegistryWatchers();
        }

        private void SetupUI()
        {
            
            listViewValues.View = View.Details;
            listViewValues.Columns.Add("Имя", 150);
            listViewValues.Columns.Add("Тип", 100);
            listViewValues.Columns.Add("Значение", 200);

            ParametersBox.Items.AddRange(new[] { "Раздел", "Строковый параметр", "QWORD" });
            ParametersBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void PopulateTreeView()
        {
            RegistryTreeView.Nodes.Clear();
            RegistryKey[] RegistryKeyCollection = { Registry.ClassesRoot, Registry.CurrentUser, Registry.LocalMachine, Registry.Users, Registry.CurrentConfig };
            foreach (RegistryKey rootKey in RegistryKeyCollection)
            {
                TreeNode treeNode = new TreeNode(rootKey.Name);
                RegistryTreeView.Nodes.Add(treeNode);
                LoadSubKeys(rootKey, treeNode);
            }
        }

        private void LoadSubKeys(RegistryKey key, TreeNode parentNode)
        {
            string keyPath = key.Name;
            try
            {
                string[] subKeyNames = key.GetSubKeyNames();
                if (subKeyNames != null)
                {
                    foreach (string subkeyname in key.GetSubKeyNames())
                    {
                        TreeNode treeNode = new TreeNode(subkeyname);
                        parentNode.Nodes.Add(treeNode);
                        RegistryKey? subKey = key.OpenSubKey(subkeyname);
                        if (subKey != null)
                        {
                            foreach (string test in subKey.GetSubKeyNames())
                            {
                                treeNode.Nodes.Add(test);
                            }
                        }
                    }
                    //foreach (string subKeyName in subKeyNames)
                    //{
                        
                    //    RegistryKey? subKey = key.OpenSubKey(subKeyName);
                    //    using (subKey)
                    //    {
                    //        if (subKey != null)
                    //        {
                    //            TreeNode subNode = new TreeNode(subKeyName) { Tag = subKey };
                    //            parentNode.Nodes.Add(subNode);
                    //            LoadSubKeys(subKey, subNode);
                    //        }
                    //    }
                    //}
                }

            }
            catch (Exception ex)
            {
                ErrorLabel.Text = $"Ошибка загрузки подразделов для '{keyPath}': {ex.Message}";
            }
        }

        private RegistryKey OpenRegistryKey(string keyPath)
        {
            if (keyPath.StartsWith("HKEY_CLASSES_ROOT"))
                return Registry.ClassesRoot.OpenSubKey(keyPath.Substring(18));
            else if (keyPath.StartsWith("HKEY_CURRENT_USER"))
                return Registry.CurrentUser.OpenSubKey(keyPath.Substring(18));
            else if (keyPath.StartsWith("HKEY_LOCAL_MACHINE"))
                return Registry.LocalMachine.OpenSubKey(keyPath.Substring(19));
            else if (keyPath.StartsWith("HKEY_USERS"))
                return Registry.Users.OpenSubKey(keyPath.Substring(11));
            else if (keyPath.StartsWith("HKEY_CURRENT_CONFIG"))
                return Registry.CurrentConfig.OpenSubKey(keyPath.Substring(20));
            return null;
        }

        private void RegistryTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listViewValues.Items.Clear();
            RegistryKey key = (RegistryKey)e.Node.Tag;
            if (key != null)
            {
                try
                {
                    string[] valueNames = key.GetValueNames();
                    foreach (string valueName in valueNames)
                    {
                        object value = key.GetValue(valueName);
                        string valueType = key.GetValueKind(valueName).ToString();
                        ListViewItem item = new ListViewItem(valueName);
                        item.SubItems.Add(valueType);
                        item.SubItems.Add(value?.ToString() ?? "");
                        listViewValues.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки параметров: {ex.Message}");
                }
            }
            SetupValueWatcher(key);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (RegistryTreeView.SelectedNode == null)
            {
                MessageBox.Show("Выберите раздел в дереве.");
                return;
            }
            if (ParametersBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип создаваемого элемента.");
                return;
            }

            RegistryKey selectedKey = (RegistryKey)RegistryTreeView.SelectedNode.Tag;
            string selectedType = ParametersBox.SelectedItem.ToString();

            if (selectedType == "Раздел")
            {
                string newKeyName = PromptForInput("Введите имя нового раздела:");
                if (!string.IsNullOrEmpty(newKeyName))
                {
                    try
                    {
                        RegistryKey newKey = selectedKey.CreateSubKey(newKeyName);
                        TreeNode newNode = new TreeNode(newKeyName) { Tag = newKey };
                        newNode.Nodes.Add("Загрузка...");
                        RegistryTreeView.SelectedNode.Nodes.Add(newNode);
                        RegistryTreeView.SelectedNode.Expand();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка создания раздела: {ex.Message}");
                    }
                }
            }
            else if (selectedType == "Строковый параметр" || selectedType == "QWORD")
            {
                string valueName = PromptForInput("Введите имя параметра:");
                if (!string.IsNullOrEmpty(valueName))
                {
                    string valueData = PromptForInput("Введите значение:");
                    if (!string.IsNullOrEmpty(valueData))
                    {
                        try
                        {
                            if (selectedType == "Строковый параметр")
                            {
                                selectedKey.SetValue(valueName, valueData, RegistryValueKind.String);
                            }
                            else if (selectedType == "QWORD")
                            {
                                if (long.TryParse(valueData, out long qwordValue))
                                {
                                    selectedKey.SetValue(valueName, qwordValue, RegistryValueKind.QWord);
                                }
                                else
                                {
                                    MessageBox.Show("Некорректное значение QWORD.");
                                    return;
                                }
                            }
                            RegistryTreeView_AfterSelect(sender, new TreeViewEventArgs(RegistryTreeView.SelectedNode));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка создания параметра: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewValues.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewValues.SelectedItems[0];
                string valueName = selectedItem.Text;
                RegistryKey key = (RegistryKey)RegistryTreeView.SelectedNode.Tag;
                try
                {
                    key.DeleteValue(valueName);
                    listViewValues.Items.Remove(selectedItem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления параметра: {ex.Message}");
                }
            }
            else if (RegistryTreeView.SelectedNode != null)
            {
                TreeNode selectedNode = RegistryTreeView.SelectedNode;
                RegistryKey keyToDelete = (RegistryKey)selectedNode.Tag;
                string keyName = selectedNode.Text;
                TreeNode parentNode = selectedNode.Parent;
                if (parentNode != null)
                {
                    RegistryKey parentKey = (RegistryKey)parentNode.Tag;
                    try
                    {
                        parentKey.DeleteSubKeyTree(keyName);
                        parentNode.Nodes.Remove(selectedNode);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления раздела: {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Нельзя удалить корневые разделы.");
                }
            }
        }

        private void listViewValues_DoubleClick(object sender, EventArgs e)
        {
            if (listViewValues.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewValues.SelectedItems[0];
                string valueName = selectedItem.Text;
                RegistryKey key = (RegistryKey)RegistryTreeView.SelectedNode.Tag;
                string currentValue = selectedItem.SubItems[2].Text;
                string valueType = selectedItem.SubItems[1].Text;
                string newValue = PromptForInput("Измените значение:", currentValue);
                if (!string.IsNullOrEmpty(newValue))
                {
                    try
                    {
                        if (valueType == "String")
                        {
                            key.SetValue(valueName, newValue, RegistryValueKind.String);
                        }
                        else if (valueType == "QWord")
                        {
                            if (long.TryParse(newValue, out long qwordValue))
                            {
                                key.SetValue(valueName, qwordValue, RegistryValueKind.QWord);
                            }
                            else
                            {
                                MessageBox.Show("Некорректное значение QWORD.");
                                return;
                            }
                        }
                        selectedItem.SubItems[2].Text = newValue;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка изменения параметра: {ex.Message}");
                    }
                }
            }
        }

        private void SetupRegistryWatchers()
        {
            try
            {
                string queryHKLM = "SELECT * FROM RegistryTreeChangeEvent WHERE Hive = 'HKEY_LOCAL_MACHINE'";
                keyWatcherHKLM = new ManagementEventWatcher(new WqlEventQuery(queryHKLM));
                keyWatcherHKLM.EventArrived += (s, args) => listBoxChanges.Items.Add("Обнаружено изменение в HKEY_LOCAL_MACHINE");
                keyWatcherHKLM.Start();

                string queryHKCU = "SELECT * FROM RegistryTreeChangeEvent WHERE Hive = 'HKEY_CURRENT_USER'";
                keyWatcherHKCU = new ManagementEventWatcher(new WqlEventQuery(queryHKCU));
                keyWatcherHKCU.EventArrived += (s, args) => listBoxChanges.Items.Add("Обнаружено изменение в HKEY_CURRENT_USER");
                keyWatcherHKCU.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка настройки отслеживания реестра: {ex.Message}");
            }
        }

        private void SetupValueWatcher(RegistryKey key)
        {
            if (valueWatcher != null)
            {
                valueWatcher.Stop();
                valueWatcher.Dispose();
            }

            if (key != null)
            {
                string hive = GetHive(key);
                string keyPath = GetKeyPath(key);
                if (!string.IsNullOrEmpty(hive))
                {
                    string query = $"SELECT * FROM RegistryValueChangeEvent WHERE Hive = '{hive}' AND KeyPath = '{keyPath.Replace("\\", "\\\\")}'";
                    try
                    {
                        valueWatcher = new ManagementEventWatcher(new WqlEventQuery(query));
                        valueWatcher.EventArrived += (s, args) =>
                        {
                            string valueName = args.NewEvent["ValueName"].ToString();
                            listBoxChanges.Items.Add($"Параметр '{valueName}' изменён в {hive}\\{keyPath}");
                        };
                        valueWatcher.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка настройки отслеживания параметров: {ex.Message}");
                    }
                }
            }
        }

        private string GetHive(RegistryKey key)
        {
            string name = key.Name;
            int firstBackslash = name.IndexOf('\\');
            return firstBackslash > 0 ? name.Substring(0, firstBackslash) : name;
        }

        private string GetKeyPath(RegistryKey key)
        {
            string name = key.Name;
            int firstBackslash = name.IndexOf('\\');
            return firstBackslash > 0 ? name.Substring(firstBackslash + 1) : "";
        }

        private string PromptForInput(string prompt, string defaultValue = "")
        {
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, "Ввод", defaultValue);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            keyWatcherHKLM?.Stop();
            keyWatcherHKLM?.Dispose();
            keyWatcherHKCU?.Stop();
            keyWatcherHKCU?.Dispose();
            valueWatcher?.Stop();
            valueWatcher?.Dispose();
        }
    }
}