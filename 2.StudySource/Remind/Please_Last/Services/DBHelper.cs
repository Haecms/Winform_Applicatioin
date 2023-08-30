using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DBHelper
    {
        SqlConnection sCon = new SqlConnection(Commons.strCon);

        public SqlDataAdapter Adapter;

        public DBHelper()
        {
            sCon.Open();
        }

        public void Close()
        {
            sCon.Close();
        }
    }
}
