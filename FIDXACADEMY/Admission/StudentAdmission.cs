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
    public partial class StudentAdmission : UserControl
    {

        public StudentAdmission()
        {
            InitializeComponent();
            Login.con.con_connection();
            getData();
        }

        DataTable dtcourse;
        DataTable dtquali;
        DataTable dtdomicile;
        DataTable dtbatch;

        private void getData()
        {
            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dtquali = new DataTable();
            SqlCommand comp2 = new SqlCommand("select * from Qualification", DataBase.con) { CommandType = CommandType.Text };
            dtquali.Load(comp2.ExecuteReader());
            comboBox4.DataSource = dtquali;
            comboBox4.DisplayMember = "QualificationFiled";
            comboBox4.ValueMember = "QID";

            dtbatch = new DataTable();
            SqlCommand comp3 = new SqlCommand("select * from Batch", DataBase.con) { CommandType = CommandType.Text };
            dtbatch.Load(comp3.ExecuteReader());
            batchdropdwn.DataSource = dtbatch;
            batchdropdwn.DisplayMember = "BatchName";
            batchdropdwn.ValueMember = "BID";

            DataBase.con.Close();

            int year = Convert.ToInt32(System.DateTime.Now.ToString("yyyy")) - 2;
            for (int i = 0; i < 4; i++)
            {
                comboBox5.Items.Add(year);
                year++;
            }

            dateTimePicker1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            dateTimePicker2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                textBox9.Text = textBox8.Text;
            }
            else
            {
                textBox9.Text = "";
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

            dtdomicile = new DataTable();
            SqlCommand comp3 = new SqlCommand("GetDomicile_2", DataBase.con) { CommandType = CommandType.StoredProcedure };
            comp3.Parameters.Add(new SqlParameter("@id", comboBox7.SelectedIndex + 1));
            dtdomicile.Load(comp3.ExecuteReader());
            comboBox3.DataSource = dtdomicile;
            comboBox3.DisplayMember = "DName";
            comboBox3.ValueMember = "DID";

            DataBase.con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
            }
            else if (comboBox1.SelectedIndex ==-1)
            {
                comboBox1.Focus();
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.Focus();
            }
            else if (comboBox2.SelectedIndex == -1)
            {
                comboBox2.Focus();
            }
            else if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                dateTimePicker1.Focus();
            }
            else
                tabControl1.SelectedTab = tabPage2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                textBox5.Focus();
            }
            else if (comboBox7.SelectedIndex == -1)
            {
                comboBox7.Focus();
            }
            else if (string.IsNullOrEmpty(textBox6.Text))
            {
                textBox6.Focus();
            }
            else if (string.IsNullOrEmpty(textBox7.Text))
            {
                textBox7.Focus();
            }
            else if (comboBox3.SelectedIndex == -1)
            {
                comboBox3.Focus();
            }
            else if (string.IsNullOrEmpty(textBox8.Text))
            {
                textBox8.Focus();
            }
            else if (string.IsNullOrEmpty(textBox9.Text))
            {
                textBox9.Focus();
            }
            else
                tabControl1.SelectedTab = tabPage3;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "image File (*.jpg;*.bmp;*.png;*.jpeg)|*.jpg;*.bmp;*.png;*.jpeg";
                    ofd.Multiselect = false;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                    }

                    if (pictureBox1.Image == null)
                    {
                        pictureBox1.Image = Properties.Resources.User;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.User;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (batchdropdwn.SelectedIndex == -1)
            {
                batchdropdwn.Focus();
            }
            else if (comboBox4.SelectedIndex == -1)
            {
                comboBox4.Focus();
            }
            else if (string.IsNullOrEmpty(textBox10.Text))
            {
                textBox10.Focus();
            }
            else if (string.IsNullOrEmpty(textBox11.Text))
            {
                textBox11.Focus();
            }
            else if (comboBox5.SelectedIndex == -1)
            {
                comboBox5.Focus();
            }
            else if (string.IsNullOrEmpty(textBox12.Text))
            {
                textBox12.Focus();
            }
            else if (comboBox6.SelectedIndex == -1)
            {
                comboBox6.Focus();
            }
            else if (string.IsNullOrEmpty(dateTimePicker2.Text))
            {
                dateTimePicker2.Focus();
            }
            else if (batchdropdwn.SelectedIndex == -1)
            {
                batchdropdwn.Focus();
            }
            else
            {
                if (DataBase.con.State == ConnectionState.Closed)
                    DataBase.con.Open();

                ImageConverter imc = new ImageConverter();
                byte[] img = (byte[])imc.ConvertTo(pictureBox1.Image, Type.GetType("System.Byte[]"));

                SqlCommand cmd2 = new SqlCommand("InsertStudent", DataBase.con) { CommandType = CommandType.StoredProcedure };
                cmd2.Parameters.Add(new SqlParameter("@n", textBox1.Text));
                cmd2.Parameters.Add(new SqlParameter("@fn", textBox2.Text));
                cmd2.Parameters.Add(new SqlParameter("@cn", textBox3.Text));
                cmd2.Parameters.Add(new SqlParameter("@c", textBox4.Text));
                cmd2.Parameters.Add(new SqlParameter("@e", textBox5.Text));
                cmd2.Parameters.Add(new SqlParameter("@c1", textBox6.Text));
                cmd2.Parameters.Add(new SqlParameter("@c2", textBox7.Text));
                cmd2.Parameters.Add(new SqlParameter("@ca", textBox8.Text));
                cmd2.Parameters.Add(new SqlParameter("@pa", textBox9.Text));
                cmd2.Parameters.Add(new SqlParameter("@q", textBox10.Text));
                cmd2.Parameters.Add(new SqlParameter("@b", textBox11.Text));
                cmd2.Parameters.Add(new SqlParameter("@re", textBox12.Text));
                cmd2.Parameters.Add(new SqlParameter("@g", comboBox1.SelectedIndex));
                cmd2.Parameters.Add(new SqlParameter("@r", comboBox2.SelectedIndex));
                cmd2.Parameters.Add(new SqlParameter("@d", comboBox3.SelectedValue));
                cmd2.Parameters.Add(new SqlParameter("@qf", comboBox4.SelectedValue));
                cmd2.Parameters.Add(new SqlParameter("@y", comboBox5.Text));
                cmd2.Parameters.Add(new SqlParameter("@co", comboBox6.SelectedValue));
                cmd2.Parameters.Add(new SqlParameter("@ad", dateTimePicker2.Value));
                cmd2.Parameters.Add(new SqlParameter("@dob", dateTimePicker1.Value));
                cmd2.Parameters.Add(new SqlParameter("@cd", System.DateTime.Now.ToString("MM-dd-yyyy")));
                cmd2.Parameters.Add(new SqlParameter("@t", System.DateTime.Now.ToString("hh:mm:ss")));
                cmd2.Parameters.Add(new SqlParameter("@Image", img));
                cmd2.Parameters.Add(new SqlParameter("@Bid", batchdropdwn.SelectedValue));
                int chk = cmd2.ExecuteNonQuery();
                DataBase.con.Close();
                if (chk > 0)
                {
                    textBox10.Text = string.Empty;
                    textBox11.Text = string.Empty;
                    textBox12.Text = string.Empty;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    comboBox6.SelectedIndex = -1;
                    dateTimePicker2.Text = System.DateTime.Now.ToString("MM-dd-yyyy");

                    textBox5.Text = string.Empty;
                    textBox6.Text = string.Empty;
                    textBox7.Text = string.Empty;
                    textBox8.Text = string.Empty;
                    textBox9.Text = string.Empty;
                    comboBox7.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;

                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;
                    textBox4.Text = string.Empty;
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    dateTimePicker1.Text = System.DateTime.Now.ToString("MM-dd-yyyy");
                    tabControl1.SelectedTab = tabPage1;
                    batchdropdwn.SelectedIndex = -1;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;
            textBox12.Text = string.Empty;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            dateTimePicker2.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            batchdropdwn.SelectedIndex = -1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            comboBox7.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            dateTimePicker1.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void batchdropdwn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (batchdropdwn.SelectedIndex != -1)
            { 
                 if (DataBase.con.State == ConnectionState.Closed)
                DataBase.con.Open();

                dtcourse = new DataTable();
                SqlCommand comp = new SqlCommand("Select CID,CName from Course where status = 0", DataBase.con) { CommandType = CommandType.Text };
                dtcourse.Load(comp.ExecuteReader());
                comboBox6.Items.Clear();
                comboBox6.DataSource = dtcourse;
                comboBox6.DisplayMember = "CName";
                comboBox6.ValueMember = "CID";

                DataBase.con.Close();
            }
        }
    }
}
