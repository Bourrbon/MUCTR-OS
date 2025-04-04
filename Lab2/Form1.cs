using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public class DirInfo
    {
        // Объект с информацией о папке
        public string name, ext, crtime, latime, lwtime, attrs, path;
        public DirInfo(DirectoryInfo di)
        {
            this.name = di.Name;
            this.ext = di.Extension;
            this.crtime = Convert.ToString(di.CreationTime);
            this.latime = Convert.ToString(di.LastAccessTime);
            this.lwtime = Convert.ToString(di.LastWriteTime);
            this.attrs = Convert.ToString(di.Attributes);
            this.path = Convert.ToString(di.FullName);
        }
    }

    public class FileInform
    {
        // Объект с информацией о файле
        public string name, ext, size, crtime, latime, lwtime, attrs, ro, path;

        public FileInform(FileInfo fi)
        {
            this.name = fi.Name;
            this.ext = fi.Extension;
            this.size = GetOptSize(fi.Length);
            this.crtime = Convert.ToString(fi.CreationTime);
            this.latime = Convert.ToString(fi.LastAccessTime);
            this.lwtime = Convert.ToString(fi.LastWriteTime);
            this.attrs = Convert.ToString(fi.Attributes);
            this.ro = Convert.ToString(fi.IsReadOnly);
            this.path = Convert.ToString(fi.FullName);
        }

        private string GetOptSize(long size)
        {
            double sz = Convert.ToDouble(size);

            string[] prefix = { "bytes", "KB", "MB", "GB", "TB" };

            int index = 0;

            while ((sz > 0) && (index < prefix.Length - 1))
            {
                ++index;
                sz /= 1024;
            }

            return Math.Round(sz * 1024, 2) + " " + prefix[index - 1];
        }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetOptSize(long size)
        {
            double sz = Convert.ToDouble(size);

            string[] prefix = { "bytes", "KB", "MB", "GB", "TB" };

            int index = 0;

            while ((sz > 0) && (index < prefix.Length - 1))
            {
                ++index;
                sz /= 1024;
            }

            return Math.Round(sz * 1024, 2) + " " + prefix[index - 1];
        }

        private void PopulateFileTree(object sender, string path)
        {
            try
            {
                // Создать дерево папок и файлов
                foreach (string folder in Directory.GetDirectories(path))
                {
                    TreeNode newparent = new TreeNode(Path.GetDirectoryName(folder));
                    FileTree.Nodes.Add(newparent);

                    // Записать все свойства папки в объект и передать в тег текущего узла
                    DirectoryInfo di = new DirectoryInfo(folder);
                    newparent.Tag = new DirInfo(di);

                    foreach (string file in Directory.GetFiles(folder))
                    {
                        TreeNode newchild = new TreeNode(Path.GetFileName(file));
                        newparent.Nodes.Add(newchild);

                        // Записать все свойства папки в объект и передать в тег текущего узла
                        FileInfo fi = new FileInfo(file);
                        newchild.Tag = fi;
                    }
                }
            }

            catch
            {
                ErrorLabel.Text = "Ошибка: не вышло получить список файлов и папок";
            }
        }

        private void PopulateFileInfo(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.GetType() == typeof(DirInfo))
            {
                // Выбрана папка
                try
                {
                    foreach (PropertyInfo pi in e.GetType().GetRuntimeProperties())
                    {
                        FileInfoBox.AppendText(pi.Name + " : " + Convert.ToString(pi) + Environment.NewLine);
                    }
                }

                catch
                {
                    ErrorLabel.Text = "Ошибка: не вышло получить информацию о папке";
                }
            }
            else
            {
                // Выбран файл
                try
                {
                    foreach (PropertyInfo pi in e.GetType().GetRuntimeProperties())
                    {
                        FileInfoBox.AppendText(pi.Name + " : " + Convert.ToString(pi) + Environment.NewLine);
                    }
                }

                catch
                {
                    ErrorLabel.Text = "Ошибка: не вышло получить информацию о файле";
                }
            }
        }

        private void FileTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FileInfoBox.Clear();
            PopulateFileInfo(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.ParentFolderButton, "Родительский каталог");
            string path = System.IO.Directory.GetCurrentDirectory();
            PopulateFileTree(sender, path);

            // Развернуть по умолчанию список файлов и папок
            FileTree.ExpandAll();
        }
    }
}