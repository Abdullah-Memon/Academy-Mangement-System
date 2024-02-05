using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FIDXACADEMY
{
    public partial class SubmiitStudentFee : UserControl
    {
        public SubmiitStudentFee()
        {
            InitializeComponent();
            Login.con.con_connection();

        }

        DataTable dtbatch;
        public void getdata2()
        {
            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dtbatch = new DataTable();
            SqlCommand comp = new SqlCommand("Select * from Batch order by BID desc", DataBase.con) { CommandType = CommandType.Text };
            dtbatch.Load(comp.ExecuteReader());
            DataBase.con.Close();
            Batchdropdown.DataSource = dtbatch;
            Batchdropdown.DisplayMember = "BatchName";
            Batchdropdown.ValueMember = "BID";
        }

        DataTable dtcourse;
        public void getdata()
        {
            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dtcourse = new DataTable();
            SqlCommand comp = new SqlCommand("GetCourse", DataBase.con) { CommandType = CommandType.StoredProcedure };
            dtcourse.Load(comp.ExecuteReader());
            DataBase.con.Close();
            comboBox2.DataSource = dtcourse;
            comboBox2.DisplayMember = "CName";
            comboBox2.ValueMember = "CID";
        }

        private void SubmiitStudentFee_Load(object sender, EventArgs e)
        {
            getdata2();
            getdata();
        }

        DataTable dtview;

        DataTable dtfee2;

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.Focus();
            }
            else if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Focus();
            }
            else if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Focus();
            }
            else if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                textBox4.Focus();
            }
            else if (string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                textBox5.Focus();
            }
            else if (string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                textBox6.Focus();
            }
            else if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrWhiteSpace(textBox7.Text))
            {
                textBox7.Focus();
            }
            else
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("InsertFee", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@D", comboBox1.SelectedIndex));
                cmd2.Parameters.Add(new SqlParameter("@A", textBox2.Text));
                cmd2.Parameters.Add(new SqlParameter("@M", textBox3.Text));
                cmd2.Parameters.Add(new SqlParameter("@E", textBox4.Text));
                cmd2.Parameters.Add(new SqlParameter("@C", textBox5.Text));
                cmd2.Parameters.Add(new SqlParameter("@R", textBox6.Text));
                cmd2.Parameters.Add(new SqlParameter("@P", textBox7.Text));
                cmd2.Parameters.Add(new SqlParameter("@Date", Convert.ToInt32(dateTimePicker1.Text)));
                int chk = cmd2.ExecuteNonQuery();
                DataBase.con.Close();

                if (chk > 0)
                {
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    textBox4.Text = "0";
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                }

                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                dtfee2 = new DataTable();
                SqlCommand comp = new SqlCommand("Select Student.SName,StudentFee.[CAFee],StudentFee.[CMFee],StudentFee.[CCFee],StudentFee.[CRFee],StudentFee.[CEFee],StudentFee.[CPFee],StudentFee.[Month] from StudentFee inner join student on Student.SID = studentFee.SID where StudentFee.SID = " + comboBox1.SelectedValue + " and StudentFee.status =0", DataBase.con) { CommandType = CommandType.Text };
                dtfee2.Load(comp.ExecuteReader());
                DataBase.con.Close();
                dataGridView1.DataSource = dtfee2;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Batchdropdown.SelectedIndex == -1)
            {
                Batchdropdown.Focus();
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                comboBox2.Focus();
            }
            else
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                dtview = new DataTable();
                SqlCommand comp = new SqlCommand("Select * from Student where batch= " + Batchdropdown.SelectedValue + " and CourseID = " + comboBox2.SelectedValue + " and status =0", DataBase.con) { CommandType = CommandType.Text };
                dtview.Load(comp.ExecuteReader());
                DataBase.con.Close();
                comboBox1.DataSource = dtview;
                comboBox1.DisplayMember = "SName";
                comboBox1.ValueMember = "SID";
            }
        }

        DataTable dtfee;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                dtfee = new DataTable();
                SqlCommand comp = new SqlCommand("Select Student.SName,StudentFee.[CAFee],StudentFee.[CMFee],StudentFee.[CCFee],StudentFee.[CRFee],StudentFee.[CEFee],StudentFee.[CPFee],StudentFee.[Month] from StudentFee inner join student on Student.SID = studentFee.SID where StudentFee.SID = " + comboBox1.SelectedValue + " and StudentFee.status =0", DataBase.con) { CommandType = CommandType.Text };
                dtfee.Load(comp.ExecuteReader());
                DataBase.con.Close();
                dataGridView1.DataSource = dtfee;
            }
        }
    }
}
