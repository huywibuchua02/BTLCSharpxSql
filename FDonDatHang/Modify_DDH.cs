using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTLCSharpxSql.FDonDatHang
{
    internal class Modify_DDH
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // Truy vấn cập nhật tới CSDL

        public Modify_DDH()
        {
        }

        // Lấy tất cả đơn đặt hàng
        public DataTable GetAllDonDatHang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from dondathang";
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

        // Cập nhật thông tin đơn đặt hàng
        public bool Update(QLdonDatHang qLDonDatHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "update dondathang set makhachhang = @makhachhang, manhanvien = @manhanvien, ngaydathang = @ngaydathang, ngaygiaohang = @ngaygiaohang,"
                + "noigiaohang = @noigiaohang " + "ngaychuyenhang = @ngaychuyenhang"
                + "WHERE sohoadon = @sohoadon;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@sohoadon", SqlDbType.Int).Value = qLDonDatHang.Sohoadon;
                sqlCommand.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = qLDonDatHang.Makhachhang;
                sqlCommand.Parameters.Add("@manhanvien", SqlDbType.NVarChar).Value = qLDonDatHang.Manhanvien;
                sqlCommand.Parameters.Add("@ngaydathang", SqlDbType.DateTime).Value = qLDonDatHang.Ngaydathang;
                sqlCommand.Parameters.Add("@ngaygiaohang", SqlDbType.DateTime).Value = qLDonDatHang.Ngaygiaohang;
                sqlCommand.Parameters.Add("@ngaychuyenhang", SqlDbType.DateTime).Value = qLDonDatHang.Ngaychuyenhang;
                sqlCommand.Parameters.Add("@noigiaohang", SqlDbType.NVarChar).Value = qLDonDatHang.Noigiaohang;
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

        // Xóa đơn đặt hàng
        public bool Delete(int sohoadon)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "delete qldondathang where sohoadon=@sohoadon";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@sohoadon", SqlDbType.Int).Value = sohoadon;

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
