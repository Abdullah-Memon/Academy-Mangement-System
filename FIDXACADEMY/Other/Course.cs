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
    public partial class Course : UserControl
    {
        public Course()
        {
            InitializeComponent();
            Login.con.con_connection();
        }

        DataTable dt;

        private void getData()
        {

            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dt = new DataTable();
            SqlCommand comp = new SqlCommand("GetCourse", DataBase.con) { CommandType = CommandType.StoredProcedure };
            dt.Load(comp.ExecuteReader());
            DataBase.con.Close();

            dataGridView1.DataSource = dt;
        }

        private void Course_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 1)
            {
                comboBox1.Focus();
            }
            else if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Focus();
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

                SqlCommand cmd2 = new SqlCommand("InsertCourse", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@D", comboBox1.SelectedIndex));
                cmd2.Parameters.Add(new SqlParameter("@CN", textBox1.Text));
                cmd2.Parameters.Add(new SqlParameter("@A", textBox2.Text));
                cmd2.Parameters.Add(new SqlParameter("@M", textBox3.Text));
                cmd2.Parameters.Add(new SqlParameter("@E", textBox4.Text));
                cmd2.Parameters.Add(new SqlParameter("@C", textBox5.Text));
                cmd2.Parameters.Add(new SqlParameter("@R", textBox6.Text));
                cmd2.Parameters.Add(new SqlParameter("@P", textBox7.Text));
                int chk = cmd2.ExecuteNonQuery();
                DataBase.con.Close();

                if (chk > 0)
                {
                    getData();
                    comboBox1.SelectedIndex = 0;
                    textBox1.Text = string.Empty;
                    textBox2.Text = "0";
                    textBox3.Text = "0";
                    textBox4.Text = "0";
                    textBox5.Text = "0";
                    textBox6.Text = "0";
                    textBox7.Text = "0";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("UpdateCourse", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@DID", dataGridView1.Rows[e.RowIndex].Cells["CID"].Value));
                cmd2.Parameters.Add(new SqlParameter("@CN", dataGridView1.Rows[e.RowIndex].Cells["CName"].Value));
                cmd2.Parameters.Add(new SqlParameter("@A", dataGridView1.Rows[e.RowIndex].Cells["CAFee"].Value));
                cmd2.Parameters.Add(new SqlParameter("@M", dataGridView1.Rows[e.RowIndex].Cells["CMFee"].Value));
                cmd2.Parameters.Add(new SqlParameter("@E", dataGridView1.Rows[e.RowIndex].Cells["CEFee"].Value));
                cmd2.Parameters.Add(new SqlParameter("@C", dataGridView1.Rows[e.RowIndex].Cells["CCFee"].Value));
                cmd2.Parameters.Add(new SqlParameter("@R", dataGridView1.Rows[e.RowIndex].Cells["CRFee"].Value));
                cmd2.Parameters.Add(new SqlParameter("@P", dataGridView1.Rows[e.RowIndex].Cells["CPFee"].Value));
                int chk = cmd2.ExecuteNonQuery();
                DataBase.con.Close();

                if (chk > 0)
                {
                    getData();
                }
            }
            else if (e.ColumnIndex == 1)
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("DeleteCourse", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@DID", dataGridView1.Rows[e.RowIndex].Cells["CID"].Value));
                int chk = cmd2.ExecuteNonQuery();
                DataBase.con.Close();

                if (chk > 0)
                {
                    getData();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login.d.addUserControl(Desktop.Deshboard.od);
        }
    }
}
