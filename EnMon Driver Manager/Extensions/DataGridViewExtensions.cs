using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnMon_Driver_Manager.Extensions
{
    public static class DataGridViewExtensions
    {
        public static void HideAllColumns(this DataGridView dgv)
        {
            foreach(DataGridViewColumn column in dgv.Columns)
            {
                column.Visible = false;
            }
        }

        public static void ShowColumn(this DataGridView dgv, string columnName)
        {
            var column = dgv.Columns[columnName];
            if (column != null) column.Visible = true;
        }
    }
}
