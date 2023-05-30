using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCSharpxSql.FMatHang
{
    internal class Modify
    {
        private string connectionString = @"Data Source=HUYBU;Initial Catalog=BTLQuanLyBanHang;Integrated Security=True";

        public DataTable GetAllMatHang()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM mathang";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    dataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return dataTable;
        }

        public bool ThemMatHang(QLmatHang qLMatHang)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO mathang (maHang, tenHang, maCongTy, maloaihang, soluong, donviTinh) VALUES (@MaHang, @TenHang, @MaCongTy, @MaLoaiHang, @SoLuong, @DonViTinh)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHang", qLMatHang.MaHang);
                    command.Parameters.AddWithValue("@TenHang", qLMatHang.TenHang);
                    command.Parameters.AddWithValue("@MaCongTy", qLMatHang.MaCongTy);
                    command.Parameters.AddWithValue("@MaLoaiHang", qLMatHang.Maloaihang);
                    command.Parameters.AddWithValue("@SoLuong", qLMatHang.Soluong);
                    command.Parameters.AddWithValue("@DonViTinh", qLMatHang.DonviTinh);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool SuaThongTinMatHang(QLmatHang qLMatHang)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE mathang SET tenHang = @TenHang, maCongTy = @MaCongTy, maloaihang = @MaLoaiHang, soluong = @SoLuong, donviTinh = @DonViTinh WHERE maHang = @MaHang";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHang", qLMatHang.MaHang);
                    command.Parameters.AddWithValue("@TenHang", qLMatHang.TenHang);
                    command.Parameters.AddWithValue("@MaCongTy", qLMatHang.MaCongTy);
                    command.Parameters.AddWithValue("@MaLoaiHang", qLMatHang.Maloaihang);
                    command.Parameters.AddWithValue("@SoLuong", qLMatHang.Soluong);
                    command.Parameters.AddWithValue("@DonViTinh", qLMatHang.DonviTinh);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public bool XoaMatHang(string maHang)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM mathang WHERE maHang = @MaHang";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHang", maHang);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}
