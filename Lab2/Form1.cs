using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            toolTip1.SetToolTip(this.ParentFolderButton, "Родительский каталог");

            // Развернуть по умолчанию список файлов и папок
            FileTree.ExpandAll();

            string CurrentDir = System.IO.Directory.GetCurrentDirectory();

            string[] folders = Directory.GetDirectories(CurrentDir);
            string[] filesLong = Directory.GetFiles(CurrentDir);
            string[] files = new string[filesLong.Length];



            FileInfoBox.Text = CurrentDir + "\t";

            // Получить список только из имён файлов без пути
            for (int i = 0; i < filesLong.Length; i++)
            {
                files[i] = Path.GetFileName(filesLong[i]);
            }


            // Создать дерево папок и файлов
            foreach (string folder in folders)
            {
                FileTree.Nodes.Add(folder);

                string[] curfiles = Directory.GetFiles(folder);

                foreach (string file in curfiles)
                {
                    FileTree.Nodes.Add(file);
                    //FileInfoBox.Text += file + Environment.NewLine;
                }
                
            }
        }

        private void FileTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FileInfo fi = new FileInfo(e.Node.Name);
            var properties = new Dictionary<string, string>() {
                {"Name", fi.Name },
                {"Full Name", fi.FullName },
                {"Last Write Time", Convert.ToString(fi.LastWriteTime) },
                {"Creation Time", Convert.ToString(fi.CreationTime) },
                {"Length", Convert.ToString(fi.Length) },
                {"Attributes", Convert.ToString(fi.Attributes) },
                {"Directory Name", fi.DirectoryName }
            };

            foreach (string key in properties.Keys)
            {
                FileInfoBox.AppendText(key + " : " + properties[key]);
            }
        }
    }

 
}
