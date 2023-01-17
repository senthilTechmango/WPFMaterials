using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TMDAL;

namespace TMBL
{
    public class ComboControlLib
    {
        public DataTable BindComboControls()
        {
            string SqlQuery = "select * from Tbl_EmployeeTest";
            DataTable dt = new DataTable();
            PersonDAL objdal = new PersonDAL();
            return objdal.Bind(SqlQuery); 

        }
    }
}
