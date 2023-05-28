﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTLCSharpxSql.FMatHang
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
            string query = "select * from mathang";
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

        // Cập nhật thông tin mặt hàng
        public bool Update(QLmatHang qLmatHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "update mathang set tenhang = @tenhang,macongty = @macongty,maloaihang = @maloaihang,soluong = @soluong," +
                "donvitinh = @donvitinh,giahang = @giahang WHERE mahang = @mahang;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = qLmatHang.MaHang;
                sqlCommand.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = qLmatHang.TenHang;
                sqlCommand.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = qLmatHang.Soluong;
                sqlCommand.Parameters.Add("@maloaihang", SqlDbType.NVarChar).Value = qLmatHang.Maloaihang;
                sqlCommand.Parameters.Add("@soluong", SqlDbType.Int).Value = qLmatHang.Soluong;
                sqlCommand.Parameters.Add("@donvitinh", SqlDbType.NVarChar).Value = qLmatHang.DonviTinh;
                sqlCommand.Parameters.Add("@giahang", SqlDbType.Money).Value = qLmatHang.GiaHang;
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

        // Xóa mặt hàng
        public bool Delete(string mahang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "delete mathang where mahang=@mahang";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = mahang;

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