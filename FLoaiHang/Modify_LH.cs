using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTLCSharpxSql.FLoaiHang
{
    internal class Modify_LH
    {
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        public DataTable getAllLoaiHang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from loaihang";
            using (SqlConnection sqlConnection = connect.GetConnection())
            {
                sqlConnection.Open();

                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }

    }
}
