using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIDXACADEMY
{
    public partial class Login : Form
    {
        public static DataBase con = new DataBase();

        public Login()
        {
            InitializeComponent();
            con.con_connection();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
                textBox2.Text = string.Empty;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                object a = new object();
                EventArgs b = new EventArgs();
                button1_Click(a, b);
            }
        }

        public static Desktop.Deshboard d;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Focus();
            }
            else if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Focus();
            }
            else
            {
                if (textBox1.Text == "a" & textBox2.Text == "a")
                {
                    d = new Desktop.Deshboard();
                    d.Show();
                    Hide();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
