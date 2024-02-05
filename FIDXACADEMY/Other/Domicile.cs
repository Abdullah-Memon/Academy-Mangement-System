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
    public partial class Domicile : UserControl
    {
        public Domicile()
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
            SqlCommand comp = new SqlCommand("GetDomicile", DataBase.con) { CommandType = CommandType.StoredProcedure };
            dt.Load(comp.ExecuteReader());
                DataBase.con.Close();

            dataGridView1.DataSource = dt;
        }

        private void Domicile_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;

            getData();
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
            else
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("InsertDomicile", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@p", comboBox1.SelectedIndex));
                cmd2.Parameters.Add(new SqlParameter("@d", textBox1.Text));
                int chk = cmd2.ExecuteNonQuery();
                    DataBase.con.Close();    

                if (chk > 0)
                {
                    getData();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("UpdateDomicile", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@did", dataGridView1.Rows[e.RowIndex].Cells["DID"].Value));
                cmd2.Parameters.Add(new SqlParameter("@d", dataGridView1.Rows[e.RowIndex].Cells["DName"].Value));
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

                SqlCommand cmd2 = new SqlCommand("DeleteDomicile", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@did", dataGridView1.Rows[e.RowIndex].Cells["DID"].Value));
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
