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
    public partial class ViewStudents : UserControl
    {
        public ViewStudents()
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

        private void ViewStudents_Load(object sender, EventArgs e)
        {
            getdata2();
            getdata();
        }

        DataTable dtview;

        private void button3_Click(object sender, EventArgs e)
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
                SqlCommand comp = new SqlCommand("GetViewStudent", DataBase.con) { CommandType = CommandType.StoredProcedure };
                comp.Parameters.Add(new SqlParameter("@Bid", Batchdropdown.SelectedValue));
                comp.Parameters.Add(new SqlParameter("@Cid", comboBox2.SelectedValue));
                dtview.Load(comp.ExecuteReader());
                DataBase.con.Close();
                    dataGridView1.DataSource = dtview;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                SqlCommand comp2 = new SqlCommand("Update Student set Status = 1 where SID = "+dataGridView1.Rows[e.RowIndex].Cells[1].Value+"", DataBase.con) { CommandType = CommandType.Text };
                comp2.ExecuteNonQuery();

                dtview = new DataTable();
                SqlCommand comp = new SqlCommand("GetViewStudent", DataBase.con) { CommandType = CommandType.StoredProcedure };
                comp.Parameters.Add(new SqlParameter("@Bid", Batchdropdown.SelectedValue));
                comp.Parameters.Add(new SqlParameter("@Cid", comboBox2.SelectedValue));
                dtview.Load(comp.ExecuteReader());
                DataBase.con.Close();
                    dataGridView1.DataSource = dtview;
            }
        }
    }
}
