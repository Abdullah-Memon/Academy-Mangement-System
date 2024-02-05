using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIDXACADEMY
{
    public class DataBase
    {
        public static SqlConnection con;

        public void con_connection() 
        {
            con = new SqlConnection("server=coder;database=fidxacademy;integrated security = true;");
        }
    }
}
