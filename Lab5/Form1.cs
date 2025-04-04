using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void CreateNewThread()
        {

        }

        private void StartThreadButton_Click(object sender, EventArgs e)
        {
            //Thread myThread = new Thread(CreateNewThread);
            int num = ChildThreadView.Nodes.Count;
            TreeNode tn = new TreeNode("Thread" + Convert.ToString(num));
            ChildThreadView.Nodes.Add(tn);
        }

        private void StopThreadButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
