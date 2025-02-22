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

            // Развернуть по умолчанию список файлов и папок
            FileTree.ExpandAll();

            string CurrentDir = System.IO.Directory.GetCurrentDirectory();

            string[] folders = Directory.GetDirectories(CurrentDir);
            string[] filesLong = Directory.GetFiles(CurrentDir);
            string[] files = new string[filesLong.Length];



            FileInfoBox.Text = CurrentDir + "\t";

            for (int i = 0; i < filesLong.Length; i++)
            {
                files[i] = Path.GetFileName(filesLong[i]);
            }



            foreach (string file in files)
            {
                
                FileTree.Nodes.Add(file);
                FileInfoBox.Text += file + Environment.NewLine;
            }
        }
    }

 
}
