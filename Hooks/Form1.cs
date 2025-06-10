using System.Reflection;
using System;
using System.Diagnostics;

namespace Hooks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _pollTimer = new System.Windows.Forms.Timer(this.Components)
            {
                Interval = 5  // мс
            };
            _pollTimer.Tick += PollTimer_Tick;
        }

        private System.ComponentModel.IContainer Components = new System.ComponentModel.Container();
        private Assembly? _hookAssembly;
        private Type? _hookType;
        private MethodInfo? _setHookMethod;
        private MethodInfo? _unsetHookMethod;
        private PropertyInfo? _log;

        private System.Windows.Forms.Timer? _pollTimer;
        private int _lastLogLength = 0;


        private void LinkButton_Click(object sender, EventArgs e)
        {
            string dllPath = DLLPathBox.Text; // Путь из текстового поля
            try
            {

                _hookAssembly = Assembly.LoadFrom(dllPath);

                _hookType = _hookAssembly.GetType("Hooks_DLL.KeyboardHook");
                if (_hookType == null)
                {
                    throw new Exception("Hooks_DLL.KeyboardHook не найдено");
                }


                // Подключить методы из DLL
                _setHookMethod = _hookType.GetMethod("SetHook", BindingFlags.Public | BindingFlags.Static);
                _unsetHookMethod = _hookType.GetMethod("UnsetHook", BindingFlags.Public | BindingFlags.Static);
                _log = _hookType.GetProperty("Log", BindingFlags.Public | BindingFlags.Static);

                if (_setHookMethod == null || _unsetHookMethod == null || _log == null)
                {
                    throw new Exception("Методы не найдены");
                }

                ErrorLabel.Text = "DLL успешно загружена";
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }

        private void HookButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_setHookMethod == null)
                {
                    throw new Exception("Методы из DLL не подключены");
                }

                _setHookMethod.Invoke(null, null);
                _pollTimer.Start();
                ErrorLabel.Text = "Ловушка привязана";
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }

        private void UnhookButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_setHookMethod == null)
                {
                    throw new Exception("Методы из DLL не подключены");
                }

                _unsetHookMethod.Invoke(null, null);
                _pollTimer.Stop();
                ErrorLabel.Text = "Ловушка отвязана";
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }

        private void PollTimer_Tick(object sender, EventArgs e)
        {
            if (_log == null)
            {
                return;
            }

            string fullLog = (string)_log.GetValue(null);
            if (fullLog.Length > _lastLogLength)
            {
                string newPart = fullLog.Substring(_lastLogLength);
                _lastLogLength = fullLog.Length;

                // Вывести новые нажатые клавиши из лога в текстовое поле
                OutputBox.AppendText(newPart);
                OutputBox.ScrollToCaret();
            }
        }

        private void ExplorerButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.ShowDialog();
            string result = openFileDialog1.FileName;
            DLLPathBox.Text = result;
        }

        private void ClearTextButton_Click(object sender, EventArgs e)
        {
            OutputBox.Clear();
        }
    }
}



