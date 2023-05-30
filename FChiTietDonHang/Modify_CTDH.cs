using BTLCSharpxSql.FChiTietDonHang;
using System.Data;
using System.Data.SqlClient;

namespace BTLCSharpxSql
{
    internal class Modify_CTDH
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng

        public DataTable GetAllChiTietDonHang()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM chitietdathang";
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

        public bool ExecuteStoredProc(string storedProcedure, QLchiTietDonHang qLchiTietDonHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                SqlCommand command = new SqlCommand(storedProcedure, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@soHoaDon", SqlDbType.Int).Value = qLchiTietDonHang.SoHoaDon;
                command.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = qLchiTietDonHang.Mahang;
                command.Parameters.Add("@giaban", SqlDbType.Money).Value = qLchiTietDonHang.Giaban;
                command.Parameters.Add("@soLuong", SqlDbType.Int).Value = qLchiTietDonHang.SoLuong;
                command.Parameters.Add("@mucgiamgia", SqlDbType.Float).Value = qLchiTietDonHang.Mucgiamgia;

                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }

        public bool ThemChiTietDonHang(QLchiTietDonHang qLchiTietDonHang)
        {
            return ExecuteStoredProc("sp_chitietdonhang_them", qLchiTietDonHang);
        }

        public bool SuaThongTinChiTietDonHang(QLchiTietDonHang qLchiTietDonHang)
        {
            return ExecuteStoredProc("sp_chitietdonhang_sua", qLchiTietDonHang);
        }

        public bool XoaChiTietDonHang(int soHoaDon)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                SqlCommand command = new SqlCommand("sp_chitietdonhang_xoa", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@soHoaDon", SqlDbType.Int).Value = soHoaDon;

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
