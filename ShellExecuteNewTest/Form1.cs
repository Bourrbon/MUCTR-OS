using ShellExecuteNewTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ShellExecuteNewTest.Shell;

namespace ShellExecuteNewTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            try
            {
                var execInfo = new SHELLEXECUTEINFO
                {
                    cbSize = Marshal.SizeOf(typeof(SHELLEXECUTEINFO)),
                    fMask = 0,
                    hwnd = this.Handle,
                    lpVerb = VerbBox.SelectedItem.ToString().Trim(),
                    lpFile = FilePathBox.Text.Trim(),
                    lpParameters = ParametersBox.Text.Trim(),
                    lpDirectory = Directory.GetCurrentDirectory(),
                    nShow = 1 // SW_SHOWNORMAL
                };

                if (string.IsNullOrEmpty(execInfo.lpVerb))
                {
                    throw new Exception("Verb needed");
                }

                if (!File.Exists(execInfo.lpFile))
                {
                    throw new Exception("File not found");
                }

                if (Shell.ShellExecuteEx(ref execInfo))
                {
                    ErrorLabel.Text = "OK";
                }
                else
                {
                    int err = Marshal.GetLastWin32Error();
                    throw new Exception($"Error code: {err}");
                }
                
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            FilePathBox.Text = "C:\\WINDOWS\\notepad.exe";
            ParametersBox.Text = "C:\\Users\\1\\Downloads\\test.txt";
            HandleBox.Text = Convert.ToString(this.Handle);
            VerbBox.SelectedIndex = 3;
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.Multiselect = false;
        }

        private void OpenExplorerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FilePathBox.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }

        }

        private void ParametersButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ParametersBox.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}

