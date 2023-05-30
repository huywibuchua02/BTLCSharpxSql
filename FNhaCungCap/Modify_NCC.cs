using System.Data;
using System.Data.SqlClient;

namespace BTLCSharpxSql.FNhaCungCap
{
    internal class Modify_NCC
    {
        private readonly SqlConnection connection;

        public Modify_NCC()
        {
            connection = connect.GetConnection();
        }

        public DataTable GetAllNhaCungCap()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM nhacungcap";
            using (SqlConnection sqlConnection = connection)
            {
                sqlConnection.Open();

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection))
                {
                    dataAdapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        private bool ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                command.Connection = connection;
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool ExecuteStoredProc(string storedProcedure, QLNhaCungCap qLNhaCungCap)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = qLNhaCungCap.Macongty;
                    command.Parameters.Add("@tencongty", SqlDbType.NVarChar).Value = qLNhaCungCap.Tencongty;
                    command.Parameters.Add("@tengiaodich", SqlDbType.NVarChar).Value = qLNhaCungCap.Tengiaodich;
                    command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = qLNhaCungCap.Diachi;
                    command.Parameters.Add("@dienthoai", SqlDbType.NVarChar).Value = qLNhaCungCap.Dienthoai;
                    command.Parameters.Add("@fax", SqlDbType.NVarChar).Value = qLNhaCungCap.Fax;
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = qLNhaCungCap.Email;

                    return ExecuteNonQuery(command);
                }
            }
            catch
            {
                return false;
            }
        }

        public bool ThemNhaCungCap(QLNhaCungCap qLNhaCungCap)
        {
            return ExecuteStoredProc("sp_nhacungcap_them", qLNhaCungCap);
        }

        public bool SuaThongTinNhaCungCap(QLNhaCungCap qLNhaCungCap)
        {
            return ExecuteStoredProc("sp_nhacungcap_sua", qLNhaCungCap);
        }

        public bool XoaNhaCungCap(string macongty)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("sp_nhacungcap_xoa", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = macongty;

                    return ExecuteNonQuery(command);
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
