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
using static Lab_ShellExecute.Shell;

namespace Lab_ShellExecute
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
                int temp = 0;
                int.TryParse(HandleBox.Text, out temp);
                execInfo.hwnd = (IntPtr)temp;

                execInfo.lpFile = FilePathBox.Text;
                execInfo.nShow = Convert.ToInt32(NShowBox.Checked);
                execInfo.lpClass = ClassBox.Text;
                if (string.IsNullOrEmpty(ParametersBox.Text.Trim()))
                {
                    execInfo.lpParameters = null;
                }
                else
                {
                    execInfo.lpParameters = ParametersBox.Text;
                }
                
                execInfo.lpVerb = VerbBox.SelectedText;
                
                execInfo.lpDirectory = null;
                execInfo.fMask = 0x00000001;
                execInfo.dwHotKey = 0;
                execInfo.lpIDList = IntPtr.Zero;
                execInfo.hIcon = IntPtr.Zero;
                execInfo.hInstApp = IntPtr.Zero;

                Shell.execInfo.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(execInfo);
                Shell.ShellExecuteExA(ref execInfo);
                
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DirectoryBox.Text = Directory.GetCurrentDirectory();
            HandleBox.Text = Convert.ToString(this.Handle);

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
    }
}

