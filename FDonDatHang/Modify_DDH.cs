using System.Data;
using System.Data.SqlClient;

namespace BTLCSharpxSql.FDonDatHang
{
    internal class Modify_DDH
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng

        public DataTable GetAllDonDatHang()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM dondathang";
            using (SqlConnection sqlConnection = connect.GetConnection())
            {
                sqlConnection.Open();// Mở kết nối

                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                // Truy xuất 
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }

        private bool ExecuteNonQuery(SqlCommand command)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                command.Connection = sqlConnection;
                sqlConnection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public bool ExecuteStoredProc(string storedProcedure, QLdonDatHang qLdonDatHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                SqlCommand command = new SqlCommand(storedProcedure, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@sohoadon", SqlDbType.Int).Value = qLdonDatHang.Sohoadon;
                command.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = qLdonDatHang.Makhachhang;
                command.Parameters.Add("@manhanvien", SqlDbType.NVarChar).Value = qLdonDatHang.Manhanvien;
                command.Parameters.Add("@ngaydathang", SqlDbType.DateTime).Value = qLdonDatHang.Ngaydathang;
                command.Parameters.Add("@ngaygiaohang", SqlDbType.DateTime).Value = qLdonDatHang.Ngaygiaohang;
                command.Parameters.Add("@ngaychuyenhang", SqlDbType.DateTime).Value = qLdonDatHang.Ngaychuyenhang;
                command.Parameters.Add("@noigiaohang", SqlDbType.NVarChar).Value = qLdonDatHang.Noigiaohang;

                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }

        public bool ThemDonDatHang(QLdonDatHang qLdonDatHang)
        {
            return ExecuteStoredProc("sp_dondathang_them", qLdonDatHang);
        }

        public bool SuaThongTinDonDatHang(QLdonDatHang qLdonDatHang)
        {
            return ExecuteStoredProc("sp_dondathang_sua", qLdonDatHang);
        }

        public bool XoaDonDatHang(int sohoadon)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                SqlCommand command = new SqlCommand("sp_dondathang_xoa", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@sohoadon", SqlDbType.Int).Value = sohoadon;

                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
