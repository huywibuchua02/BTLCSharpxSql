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
        public bool Update(QLNhanVien qLNhanVien)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "update nhanvien set ho = @ho, ten = @ten, ngaysinh = @ngaysinh, ngaylamviec = @ngaylamviec, diachi = @diachi, " +
                "dienthoai = @dienthoai, luongcoban = @luongcoban, phucap = @phucap, tuoi = @tuoi WHERE manhanvien = @manhanvien;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@manhanvien", SqlDbType.NVarChar).Value = qLNhanVien.Manhanvien;
                sqlCommand.Parameters.Add("@ho", SqlDbType.NVarChar).Value = qLNhanVien.Ho;
                sqlCommand.Parameters.Add("@ten", SqlDbType.NVarChar).Value = qLNhanVien.Ten;
                sqlCommand.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = qLNhanVien.Ngaysinh;
                sqlCommand.Parameters.Add("@ngaylamviec", SqlDbType.DateTime).Value = qLNhanVien.Ngaylamviec;
                sqlCommand.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = qLNhanVien.Diachi;
                sqlCommand.Parameters.Add("@dienthoai", SqlDbType.NVarChar).Value = qLNhanVien.Dienthoai;
                sqlCommand.Parameters.Add("@luongcoban", SqlDbType.Money).Value = qLNhanVien.Luongcoban;
                sqlCommand.Parameters.Add("@phucap", SqlDbType.Money).Value = qLNhanVien.Phucap;
                sqlCommand.Parameters.Add("@tuoi", SqlDbType.Int).Value = qLNhanVien.Tuoi;
                sqlCommand.ExecuteNonQuery();//thực thi lệnh truy vấn
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        // Xóa nhân viên
        public bool Delete(string manhanvien)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "delete nhanvien where manhanvien=@manhanvien";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@manhanvien", SqlDbType.NVarChar).Value = manhanvien;

                sqlCommand.ExecuteNonQuery();//thực thi lệnh truy vấn
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
    }
}
