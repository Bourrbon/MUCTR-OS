using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inp = textBox1.Text;
            double num = 0.0;

            if (Double.TryParse(inp, out num))
            {
                num = Math.Round(Math.Log(num), 3);

                textBox2.Text = num.ToString();
            }
            else
            {
                textBox1.Clear();
                textBox2.Text = "Ошибка";
            }
        }

        string leave = "Ушёл";
        string enter = "Пришёл";



        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Text = enter;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Text = leave;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Text = enter;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Text = leave;
        }
    }
}
