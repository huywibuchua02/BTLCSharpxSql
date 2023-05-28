using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BTLCSharpxSql.MatHang;

namespace BTLCSharpxSql
{
    internal class Modify
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // Truy vấn cập nhật tới CSDL

        public Modify()
        {
        }

        // Lấy tất cả mặt hàng
        public DataTable GetAllMatHang()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM mathang";
            using (SqlConnection sqlConnection = connect.GetConnection())
            {
                sqlConnection.Open(); // Mở kết nối

                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                // Truy xuất
                dataAdapter.Fill(dataTable);

                sqlConnection.Close();
            }
            return dataTable;
        }

        // Cập nhật thông tin mặt hàng
        public bool Update(QLmatHang qLmatHang)
        {
            using (SqlConnection sqlConnection = connect.GetConnection())
            {
                string query = "UPDATE mathang SET tenhang = @tenhang, macongty = @macongty, maloaihang = @maloaihang, soluong = @soluong, " +
                               "donvitinh = @donvitinh, giahang = @giahang WHERE mahang = @mahang;";

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = qLmatHang.MaHang;
                    sqlCommand.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = qLmatHang.TenHang;
                    sqlCommand.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = qLmatHang.MaCongTy;
                    sqlCommand.Parameters.Add("@maloaihang", SqlDbType.NVarChar).Value = qLmatHang.Maloaihang;
                    sqlCommand.Parameters.Add("@soluong", SqlDbType.Int).Value = qLmatHang.Soluong;
                    sqlCommand.Parameters.Add("@donvitinh", SqlDbType.NVarChar).Value = qLmatHang.DonviTinh;
                    sqlCommand.Parameters.Add("@giahang", SqlDbType.Money).Value = qLmatHang.GiaHang;
                    sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        // Xóa mặt hàng
        public bool Delete(string mahang)
        {
            using (SqlConnection sqlConnection = connect.GetConnection())
            {
                string query = "DELETE FROM mathang WHERE mahang=@mahang";

                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = mahang;

                    sqlCommand.ExecuteNonQuery(); // Thực thi lệnh truy vấn
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
