using BTLCSharpxSql.FKhachHang;
using System.Data;
using System.Data.SqlClient;

namespace BTLCSharpxSql.FNhanVien
{
    internal class Modify_KH
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng

        public DataTable GetAllKhachHang()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM khachhang";
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

        public bool ExecuteStoredProc(string storedProcedure, QLkhachHang qLKhachHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                SqlCommand command = new SqlCommand(storedProcedure, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@maKhachHang", SqlDbType.NVarChar).Value = qLKhachHang.MaKhachHang;
                command.Parameters.Add("@tenCongTy", SqlDbType.NVarChar).Value = qLKhachHang.TenCongTy1;
                command.Parameters.Add("@tenGiaoDich", SqlDbType.NVarChar).Value = qLKhachHang.TenGiaoDich;
                command.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = qLKhachHang.DiaChi;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = qLKhachHang.Email;
                command.Parameters.Add("@dienThoai", SqlDbType.NVarChar).Value = qLKhachHang.DienThoai;
                command.Parameters.Add("@fax", SqlDbType.NVarChar).Value = qLKhachHang.Fax;

                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }

        public bool ThemKhachHang(QLkhachHang qLKhachHang)
        {
            return ExecuteStoredProc("sp_khachhang_them", qLKhachHang);
        }

        public bool SuaThongTinKhachHang(QLkhachHang qLKhachHang)
        {
            return ExecuteStoredProc("sp_khachhang_sua", qLKhachHang);
        }

        public bool XoaKhachHang(string maKhachHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                SqlCommand command = new SqlCommand("sp_khachhang_xoa", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@maKhachHang", SqlDbType.NVarChar).Value = maKhachHang;

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
