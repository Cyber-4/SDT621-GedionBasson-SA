using System;
using System.Windows.Forms;

namespace SectionB_Q1._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGreeting_Click(object sender, EventArgs e)
        {
            String userName = txtName.Text;

            if (!string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show($"Hello, {userName}!", "Greeting");

            }
            else
            {
                MessageBox.Show("Please enter your name.", "Input Required");
            }
        }
    }
}
