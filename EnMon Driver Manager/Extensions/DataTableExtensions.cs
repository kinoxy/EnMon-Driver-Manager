using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EnMon_Driver_Manager.Extensions
{

    public static class DataTableExtensions

    {

        public static void WriteToCSVFile(this DataTable _datatable, string filePath, string seperator  = ";")

        {
            try
            {
                StringBuilder fileContent = new StringBuilder();

                foreach (var col in _datatable.Columns)
                {
                    fileContent.Append(col.ToString() + seperator);
                }

                fileContent.Replace(seperator, System.Environment.NewLine, fileContent.Length - 1, 1);

                foreach (DataRow dr in _datatable.Rows)
                {
                    foreach (var column in dr.ItemArray)
                    {
                        fileContent.Append(column.ToString() + seperator);
                    }

                    fileContent.Replace(seperator, System.Environment.NewLine, fileContent.Length - 1, 1);
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


        public static bool HasRow(this DataTable _dt)

        {
            if(_dt.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static DataTable addColumn(this DataTable _datatable, string[] columnNames)

        {
            DataTable dt = new DataTable();
            try
            {
                for (int c = 0; c < columnNames.Length; c++)
                {
                    dt.Columns.Add(columnNames[c]);
                }
            }
            catch (Exception ex)
            {
                Log.Instance.Error(ex.Message);
                throw ex;
            }
            return dt;
        }
    }
}