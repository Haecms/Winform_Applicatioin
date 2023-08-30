using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public class GridUtil
    {
         DataTable dtTemp = new DataTable();
        public void InitColumnGridUtil(DataGridView dgv, string ColumnID, string ColumnName, int ColumnWidth, bool Editable, Type ColumnType)
        {
            dtTemp.Columns.Add(ColumnID, ColumnType);
            dgv.DataSource = dtTemp;
            dgv.Columns[ColumnID].HeaderText = ColumnName;
            dgv.Columns[ColumnID].Width= ColumnWidth;
            dgv.Columns[ColumnID].ReadOnly = Editable;
        }
    }
}
