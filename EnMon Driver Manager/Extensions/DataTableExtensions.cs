using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EnMon_Driver_Manager.Extensions
{
    public static class DataTableExtensions
    {
        public static void WriteToCSVFile(this DataTable _datatable, string filePath)
        {
            try
            {
                StringBuilder fileContent = new StringBuilder();

                foreach (var col in _datatable.Columns)
                {
                    fileContent.Append(col.ToString() + ",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

                foreach (DataRow dr in _datatable.Rows)
                {
                    foreach (var column in dr.ItemArray)
                    {
                        fileContent.Append("\"" + column.ToString() + "\",");
                    }

                    fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
                }

                System.IO.File.WriteAllText(filePath, fileContent.ToString(), Encoding.Default);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static DataTable RemoveRows(this DataTable _datatable, DataRow[] _rowsWillBeRemoved)
        {
            for (int i = 0; i < _rowsWillBeRemoved.Count(); i++)
            {
                _datatable.Rows.Remove(_rowsWillBeRemoved[i]);
            }
            return _datatable;
        }

        public static DataTable RemoveRows(this DataTable _datatable, List<DataRow> _rowsWillBeRemoved)
        {
            for (int i = 0; i < _rowsWillBeRemoved.Count(); i++)
            {
                _datatable.Rows.Remove(_rowsWillBeRemoved[i]);
            }
            return _datatable;
        }
    }
}