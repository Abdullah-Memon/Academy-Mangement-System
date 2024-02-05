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
    public partial class ExpenseType : UserControl
    {
        public ExpenseType()
        {
            InitializeComponent();
            Login.con.con_connection();
        }

        DataTable dt;

        public void getData()
        {
            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dt = new DataTable();
            SqlCommand comp = new SqlCommand("GetExpenseType", DataBase.con) { CommandType = CommandType.StoredProcedure };
            dt.Load(comp.ExecuteReader());
            DataBase.con.Close();

            dataGridView1.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Focus();
            }
            else
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("InsertExpenseType", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@ET", textBox1.Text));
                int chk = cmd2.ExecuteNonQuery();
                DataBase.con.Close();
                if (chk > 0)
                {
                    getData();
                    textBox1.Text = string.Empty;
                }
            }
        }

        private void ExpenseType_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("UpdateExpenseType", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@EID", dataGridView1.Rows[e.RowIndex].Cells["EID"].Value));
                cmd2.Parameters.Add(new SqlParameter("@ET", dataGridView1.Rows[e.RowIndex].Cells["ExpenseT"].Value));
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

                SqlCommand cmd2 = new SqlCommand("DeleteExpenseType", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@EID", dataGridView1.Rows[e.RowIndex].Cells["EID"].Value));
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
