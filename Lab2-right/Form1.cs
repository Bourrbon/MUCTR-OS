using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_right
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string GetOptSize(long size)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                TreeNode newparent = new TreeNode(Convert.ToString(drive.Name));
                DiskTree.Nodes.Add(newparent);
                
                var dinfo = new Dictionary<string, string>()
                {
                    //{ "Disk Name", Convert.ToString(drive.Name) },
                    {"Disk Capacity", GetOptSize(drive.TotalSize) },
                    {"Disk Available Free Space", GetOptSize(drive.TotalFreeSpace) },
                    {"Disk Occupied Space", GetOptSize(drive.TotalSize - drive.TotalFreeSpace) },
                    {"Disk Format", Convert.ToString(drive.DriveFormat) },
                    {"Disk Type", Convert.ToString(drive.DriveType) }
                };


                foreach (KeyValuePair<string, string> item in dinfo)
                {
                    TreeNode newchild = new TreeNode(item.Key + " : " + item.Value);
                    newparent.Nodes.Add(newchild);
                }
            }

            DiskTree.ExpandAll();
        }


    }
}   
