using System;
using System.Data;
using System.Data.SqlClient;


namespace TMDAL
{
    public class Connection
    {
       
    }

    public class PersonDAL
    {
        public string ConString = "Data Source=TTS-177;Initial Catalog=TestDb;User ID=sa;Password=admin@123";
        SqlConnection con = new SqlConnection();
        DataTable dt = new DataTable();
        public DataTable Bind(string sql)
        {
            con.ConnectionString = ConString;
            if (ConnectionState.Closed == con.State)
                con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {

                SqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                return dt;
            }
            catch
            {
                throw;
            }
        }
        public DataTable Read(string EmpId, string EmpName, string IsActive, string TableName, string FilterValue, string SortColumnName, string SortOrder, int pagenumber, int Pagesize)
        {
            con.ConnectionString = ConString;
            if (ConnectionState.Closed == con.State)
                con.Open();
            using (SqlCommand cmd = new SqlCommand("[SP_TMComboBind]", con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ValueColumn", EmpId);
                    cmd.Parameters.AddWithValue("@DisplayColumn", EmpName);
                    cmd.Parameters.AddWithValue("@ToolTipColumn", IsActive);
                    cmd.Parameters.AddWithValue("@TableName", TableName);
                    cmd.Parameters.AddWithValue("@FilterValue", FilterValue);
                    cmd.Parameters.AddWithValue("@SortColumn", SortColumnName);
                    cmd.Parameters.AddWithValue("@SortOrder", SortOrder);
                    cmd.Parameters.AddWithValue("@pagenumber", pagenumber);
                    cmd.Parameters.AddWithValue("@Pagesize", Pagesize);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                    return dt;

                }
                catch
                {
                    throw;
                }
            }

        }
        //DatagridRead
        public DataTable DatagridRead(string sqlQuery, string tableName, string sortColumn, string sortOrder, int pageNumber, int pageSize, string filterColumn, string filterValue)
        {
            con.ConnectionString = ConString;
            if (ConnectionState.Closed == con.State)
                con.Open();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    cmd.Parameters.AddWithValue("@SortColumn", sortColumn);
                    cmd.Parameters.AddWithValue("@SortOrder", sortOrder);
                    cmd.Parameters.AddWithValue("@FilterColumn", filterColumn);
                    cmd.Parameters.AddWithValue("@FilterValue", filterValue);
                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    con.Close();
                    return dt;

                }
                catch
                {
                    throw;
                }
            }

        }

      
    }   
}
