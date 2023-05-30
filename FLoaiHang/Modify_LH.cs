using BTLCSharpxSql.FLoaiHang;
using System.Data;
using System.Data.SqlClient;

namespace BTLCSharpxSql.FNhanVien
{
    internal class Modify_LH
    {
        private readonly SqlConnection connection;

        public Modify_LH()
        {
            connection = connect.GetConnection();
        }

        public DataTable GetAllLoaiHang()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM loaihang";
            using (SqlConnection sqlConnection = connect.GetConnection())
            {
                sqlConnection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
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

        public bool ExecuteStoredProc(string storedProcedure, QLloaiHang qlLoaiHang)
        {
            try
            {
                SqlCommand command = new SqlCommand(storedProcedure, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@maloaihang", SqlDbType.Int).Value = qlLoaiHang.Maloaihang;
                command.Parameters.Add("@tenloaihang", SqlDbType.NVarChar).Value = qlLoaiHang.Tenloaihang;

                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }

        public bool ThemLoaiHang(QLloaiHang qlLoaiHang)
        {
            return ExecuteStoredProc("sp_loaihang_them", qlLoaiHang);
        }

        public bool SuaThongTinLoaiHang(QLloaiHang qlLoaiHang)
        {
            return ExecuteStoredProc("sp_loaihang_sua", qlLoaiHang);
        }

        public bool XoaLoaiHang(int maloaihang)
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_loaihang_xoa", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@maloaihang", SqlDbType.Int).Value = maloaihang;

                return ExecuteNonQuery(command);
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
    }
}
