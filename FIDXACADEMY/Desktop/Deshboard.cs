using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIDXACADEMY.Desktop
{
    public partial class Deshboard : Form
    {
        public static Dashboard_Detail u1;

        public Deshboard()
        {
            InitializeComponent();
            Login.con.con_connection();
            u1 = new Dashboard_Detail();
            addUserControl(u1);
        }

        public void addUserControl(UserControl uc)
        {
            panel3.Controls.Clear();
            //uc.Dock = DockStyle.Fill;
            panel3.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
        }

        public static StudentAdmission sa;

        private void button1_Click(object sender, EventArgs e)
        {
            sa = new StudentAdmission();
            addUserControl(sa);
        }

        public static ViewStudents vs;

        private void button2_Click(object sender, EventArgs e)
        {
            vs = new ViewStudents();
            addUserControl(vs);
        }

        public static OtherDashboard od;
        private void button3_Click(object sender, EventArgs e)
        {
            od = new OtherDashboard();
            addUserControl(od);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SubmiitStudentFee ss = new SubmiitStudentFee();
            addUserControl(ss);
        }

        private void Crossbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Maximizebtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else
                WindowState = FormWindowState.Maximized;
        }

        private void Minimizebtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            Dashboard_Detail dd = new Dashboard_Detail();
            addUserControl(dd);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Login l = new Login();
            l.Show();
        }
    }
}
