using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTLCSharpxSql.FNhanVien
{
    internal class Modify_NV
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // Truy vấn cập nhật tới CSDL

        public Modify_NV()
        {
        }

        // Lấy tất cả nhân viên
        public DataTable GetAllNhanVien()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from nhanvien";
            using (SqlConnection sqlConnection = connect.GetConnection())
            {
                sqlConnection.Open();//mở kết nối

                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                //truy xuất 
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }

        // Cập nhật thông tin nhân viên
        public bool ExecuteStoredProc(string storedProcedure, QLNhanVien qLNhanVien)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            try
            {
                SqlCommand command = new SqlCommand(storedProcedure, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@manhanvien", SqlDbType.NVarChar).Value = qLNhanVien.Manhanvien;
                command.Parameters.Add("@ho", SqlDbType.NVarChar).Value = qLNhanVien.Ho;
                command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = qLNhanVien.Ten;
                command.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = qLNhanVien.Ngaysinh;
                command.Parameters.Add("@ngaylamviec", SqlDbType.DateTime).Value = qLNhanVien.Ngaylamviec;
                command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = qLNhanVien.Diachi;
                command.Parameters.Add("@dienthoai", SqlDbType.NVarChar).Value = qLNhanVien.Dienthoai;
                command.Parameters.Add("@luongcoban", SqlDbType.Money).Value = qLNhanVien.Luongcoban;
                command.Parameters.Add("@phucap", SqlDbType.Money).Value = qLNhanVien.Phucap;

                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }

        // Thực thi non-query command
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

        // Thêm nhân viên
        public bool ThemNhanVien(QLNhanVien qLNhanVien)
        {
            return ExecuteStoredProc("sp_nhanvien_them", qLNhanVien);
        }

        // Sửa thông tin nhân viên
        public bool SuaThongTinNhanVien(QLNhanVien qLNhanVien)
        {
            return ExecuteStoredProc("sp_nhanvien_sua", qLNhanVien);
        }

        // Xóa nhân viên
        public bool XoaNhanVien(string manhanvien)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "sp_nhanvien_xoa";

            try
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@manhanvien", SqlDbType.NVarChar).Value = manhanvien;

                return ExecuteNonQuery(command);
            }
            catch
            {
                return false;
            }
        }
    }
}
