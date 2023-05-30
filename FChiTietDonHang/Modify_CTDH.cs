using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTLCSharpxSql.FChiTietDonHang
{
    internal class Modify_CTDH
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // Truy vấn cập nhật tới CSDL

        public Modify_CTDH()
        {
        }

        // Lấy tất cả chi tiết đơn hàng
        public DataTable GetAllChiTietDonHang()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from chitietdonhang";
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

        // Cập nhật thông tin chi tiết đơn hàng
        public bool Update(QLchiTietDonHang qLChiTietDonHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "update qlchitietdonhang set mahang = @mahang, giaban = @giaban, soluong = @soluong, mucgiamgia = @mucgiamgia "
                + "WHERE sohoadon = @sohoadon;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@sohoadon", SqlDbType.Int).Value = qLChiTietDonHang.SoHoaDon;
                sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = qLChiTietDonHang.Mahang;
                sqlCommand.Parameters.Add("@giaban", SqlDbType.Money).Value = qLChiTietDonHang.Giaban;
                sqlCommand.Parameters.Add("@soluong", SqlDbType.Int).Value = qLChiTietDonHang.SoLuong;
                sqlCommand.Parameters.Add("@mucgiamgia", SqlDbType.Float).Value = qLChiTietDonHang.Mucgiamgia;
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

        // Xóa chi tiết đơn hàng
        public bool Delete(int sohoadon)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "delete qlchitietdonhang where sohoadon=@sohoadon";

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
