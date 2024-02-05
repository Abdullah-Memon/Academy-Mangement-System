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
    public partial class AddExpense : UserControl
    {
        public AddExpense()
        {
            InitializeComponent();
            Login.con.con_connection();
        }

        DataTable dt;

        DataTable dtet;

        public void getData()
        {
            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dt = new DataTable();
            SqlCommand comp = new SqlCommand("GetExpense", DataBase.con) { CommandType = CommandType.StoredProcedure };
            dt.Load(comp.ExecuteReader());
            DataBase.con.Close();

            dataGridView1.DataSource = dt;

            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dtet = new DataTable();
            SqlCommand comp2 = new SqlCommand("GetExpenseType", DataBase.con) { CommandType = CommandType.StoredProcedure };
            dtet.Load(comp2.ExecuteReader());
            DataBase.con.Close();
            if (dtet.Rows.Count > 0)
            {
                for (int i = 0; i < dtet.Rows.Count; i++)
                {
                    comboBox1.Items.Add(dtet.Rows[i][1].ToString());
                }
            }
        }

        private void AddExpense_Load(object sender, EventArgs e)
        {
            getData();
            dateTimePicker1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
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

                SqlCommand cmd2 = new SqlCommand("InsertExpense", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@EID", dtet.Rows[comboBox1.SelectedIndex]["EID"]));
                cmd2.Parameters.Add(new SqlParameter("@Rate", textBox1.Text));
                cmd2.Parameters.Add(new SqlParameter("@D", dateTimePicker1.Value));
                int chk = cmd2.ExecuteNonQuery();
                DataBase.con.Close();

                if (chk > 0)
                {
                    getData();
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = string.Empty;
                    dateTimePicker1.Text = System.DateTime.Now.ToString("MM/dd/yyyy");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand cmd2 = new SqlCommand("UpdateExpense", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@ERID", dataGridView1.Rows[e.RowIndex].Cells["ERID"].Value));
                cmd2.Parameters.Add(new SqlParameter("@Rate", dataGridView1.Rows[e.RowIndex].Cells["Rate"].Value));
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

                SqlCommand cmd2 = new SqlCommand("DeleteExpense", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@ERID", dataGridView1.Rows[e.RowIndex].Cells["ERID"].Value));
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
