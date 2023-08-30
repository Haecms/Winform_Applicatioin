using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public class MyGrid : DataGridView
    {
        public MyGrid() : base()
        {
            AllowUserToAddRows = false;
        }
        public void InsertRow()
        {
            DataRow dr = ((DataTable)DataSource).NewRow();
            ((DataTable)DataSource).Rows.Add(dr);
        }
        public void DeleteRow()
        {
            int iIndex = CurrentRow.Index;
            Rows.Remove(Rows[iIndex]);
        }
    }
}
