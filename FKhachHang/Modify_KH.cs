using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTLCSharpxSql.FKhachHang
{
    internal class Modify
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // Truy vấn cập nhật tới CSDL

        public Modify()
        {
        }

        // Lấy tất cả khách hàng
        public DataTable GetAllKhachHang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from qlkhachhang";
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

        // Cập nhật thông tin khách hàng
        public bool Update(QLkhachHang qLKhachHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "update qlkhachhang set TenCongTy = @TenCongTy, tenGiaoDich = @tenGiaoDich, diaChi = @diaChi, email = @email,"
                + "dienThoai = @dienThoai, fax = @fax, tenKhachHang = @tenKhachHang WHERE maKhachHang = @maKhachHang;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maKhachHang", SqlDbType.NVarChar).Value = qLKhachHang.MaKhachHang;
                sqlCommand.Parameters.Add("@TenCongTy", SqlDbType.NVarChar).Value = qLKhachHang.TenCongTy1;
                sqlCommand.Parameters.Add("@tenGiaoDich", SqlDbType.NVarChar).Value = qLKhachHang.TenGiaoDich;
                sqlCommand.Parameters.Add("@diaChi", SqlDbType.NVarChar).Value = qLKhachHang.DiaChi;
                sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = qLKhachHang.Email;
                sqlCommand.Parameters.Add("@dienThoai", SqlDbType.NVarChar).Value = qLKhachHang.DienThoai;
                sqlCommand.Parameters.Add("@fax", SqlDbType.NVarChar).Value = qLKhachHang.Fax;
                sqlCommand.Parameters.Add("@tenKhachHang", SqlDbType.NVarChar).Value = qLKhachHang.TenKhachHang;
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

        // Xóa khách hàng
        public bool Delete(string maKhachHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "delete qlkhachhang where maKhachHang=@maKhachHang";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maKhachHang", SqlDbType.NVarChar).Value = maKhachHang;

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
