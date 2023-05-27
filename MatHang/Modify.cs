﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTLCSharpxSql.MatHang
{
    internal class Modify
    {
        SqlDataAdapter dataAdapter;//truy xuat du lieu vao bang
        SqlCommand sqlCommand;//truy vấn cập nhật tới csdl
        internal string maSp;

        public Modify()
        {

        }

        //dataset: trả về nhiều bảng
        //dataTable: trả về một bảng
        public DataTable getAllMatHang()
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

        public bool Update(QLyMathang qLymatHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "update mathang set tenhang = @tenhang,macongty = @macongty,maloaihang = @maloaihang,soluong = @soluong," +
                "donvitinh = @donvitinh,giahang = @giahang WHERE mahang = @mahang;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = qLymatHang.MaHang;
                sqlCommand.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = qLymatHang.TenHang;
                sqlCommand.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = qLymatHang.Soluong;
                sqlCommand.Parameters.Add("@maloaihang", SqlDbType.NVarChar).Value = qLymatHang.Maloaihang;
                sqlCommand.Parameters.Add("@soluong", SqlDbType.Int).Value = qLymatHang.Soluong;
                sqlCommand.Parameters.Add("@donvitinh", SqlDbType.NVarChar).Value = qLymatHang.DonviTinh;
                sqlCommand.Parameters.Add("@giahang", SqlDbType.Money).Value = qLymatHang.GiaHang;
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

        public bool insert(QLyMathang qLmatHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "insert into mathang values(@mahang,@tenhang,@macongty,@maloaihang,@soluong,@donvitinh,@giahang)";

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
