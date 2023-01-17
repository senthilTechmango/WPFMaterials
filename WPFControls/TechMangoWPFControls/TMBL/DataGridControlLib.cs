using System;
using System.Data;
using TMDAL;

namespace TMBL
{
    public class DataGridControlLib
    {



        public DataTable BindDataGridCtrls(string tablename)
        {
            string SqlQuery = "select * from " + tablename + " ";
            DataTable dt = new DataTable();
            PersonDAL objdal = new PersonDAL();
            return objdal.Bind(SqlQuery);
        
        }
        public DataTable SearchDataGrid(string tablename,string empname)
        {
            string SqlQuery = "select * from "+ tablename +" where EmpName like '"+ empname +"%'";
            DataTable dt = new DataTable();
            PersonDAL objdal = new PersonDAL();
            return objdal.Bind(SqlQuery);


        }
    }
}
