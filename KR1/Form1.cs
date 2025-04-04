using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void CreateFolderButton_Click(object sender, EventArgs e)
        {

            // 15.03.25 КР1 Вариант 13 
            string path = Directory.GetCurrentDirectory();
            string MainFolderName = InputBox.Text;

            bool FolderCreatedSuccessFully = false;

            try
            {
                Directory.SetCurrentDirectory(MainFolderName);
                FolderCreatedSuccessFully = true;
            }

            catch
            {
                OutputBox.AppendText("Папки не существует. Создание..." + Environment.NewLine + Environment.NewLine);
                try
                {
                    Directory.CreateDirectory(MainFolderName);
                    Directory.SetCurrentDirectory(MainFolderName);
                    FolderCreatedSuccessFully = true;
                }
                catch (Exception subex)
                {
                    OutputBox.AppendText("Не удалось создать папку: " + Environment.NewLine + subex.Message);
                }

            }

            if (FolderCreatedSuccessFully)
            {
                OutputBox.Clear();

                // Создание подпапки
                Random rnd_gen = new Random();
                int rnd_num = rnd_gen.Next();

                string SubFolderName = MainFolderName + "_" + Convert.ToString(rnd_num);


                Directory.CreateDirectory(SubFolderName);
          
                OutputBox.AppendText($"В папке {MainFolderName} создана папка {SubFolderName}");
            }
        }
    }
}
