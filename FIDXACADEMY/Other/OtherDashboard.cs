using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIDXACADEMY
{
    public partial class OtherDashboard : UserControl
    {
        public OtherDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Domicile dm = new Domicile();
            Login.d.addUserControl(dm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Course c = new Course();
            Login.d.addUserControl(c);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExpenseType et = new ExpenseType();
            Login.d.addUserControl(et);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddExpense ae = new AddExpense();
            Login.d.addUserControl(ae);
        }
    }
}
