using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Data;
using TMDAL;





namespace TMBL
{
    public class Helper
    {
        private static readonly List<string> columns = new List<string>();
        //ComboBox
        public static DataView BindCombo(string SqlQuery,string EmpId, string EmpName, string IsActive,
            string TableName, string FilterValue, string SortColumnName, string SortOrder, int pagenumber, int Pagesize)
       
        {
   
            DataTable dt = new DataTable();
            PersonDAL personDAL = new PersonDAL();
            dt= personDAL.Read(EmpId, EmpName, IsActive, TableName, FilterValue,SortColumnName, SortOrder, pagenumber, Pagesize);
            return dt.DefaultView;

        }

        //DataGrid
        public static DataView BindDataGrid(string sqlQuery, string tableName, string sortColumn, string sortOrder, int pageNumber, int pageSize, [Optional] string filterColumn, [Optional] string filterValue)
        {
            DataTable dt = new DataTable();
            PersonDAL personDAL = new PersonDAL();
            dt = personDAL.DatagridRead(sqlQuery, tableName, sortColumn, sortOrder, pageNumber, pageSize, filterColumn, filterValue);

            if (columns.Count == 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columns.Add(dt.Columns[i].ColumnName);
                }
            }

            return dt.DefaultView;
        }
        public static List<string> ComboBoxData()
        {
            return columns;
        }

        public static DataView BindDataGridCtrls(string sqlQuery, string tableName, string sortColumn, string sortOrder, int pageNumber, int pageSize, [Optional] string filterColumn, [Optional] string filterValue)
        {
            DataTable dt = new DataTable();
            PersonDAL personDAL = new PersonDAL();
            dt = personDAL.DatagridRead(sqlQuery, tableName, sortColumn, sortOrder, pageNumber, pageSize, filterColumn, filterValue);
            if (columns.Count == 0)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    columns.Add(dt.Columns[i].ColumnName);
                }
            }

            return dt.DefaultView;
        }



    }
}
