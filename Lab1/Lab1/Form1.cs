namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string inp = "";
        double num = 0.0;

        private void button1_Click(object sender, EventArgs e)
        {
            inp = textBox1.Text;
            try
            {
                num = double.Parse(inp);
                textBox2.Text = Convert.ToString(Math.Round(Math.Log(num), 3));
            }
            catch
            {
                textBox2.Text = "Error";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Text = "Ïðèø¸ë";
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Text = "Ïðèø¸ë";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Text = "Óø¸ë";
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Text = "Óø¸ë";
        }
    }
}
