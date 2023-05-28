using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTLCSharpxSql.FLoaiHang
{
    internal class Modify_LH
    {
        SqlDataAdapter dataAdapter;
        SqlCommand sqlCommand;
        public Modify_LH()
        {
        }

        // Lấy tất cả loại hàng
        public DataTable GetAllLoaiHang()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM loaihang";
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

        // Cập nhật thông tin loại hàng
        public bool Update(QLloaiHang qLloaiHang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "UPDATE loaihang SET tenloaihang = @tenloaihang WHERE maloaihang = @maloaihang;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maloaihang", SqlDbType.Int).Value = qLloaiHang.Maloaihang;
                sqlCommand.Parameters.Add("@tenloaihang", SqlDbType.NVarChar).Value = qLloaiHang.Tenloaihang;
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

        // Xóa loại hàng
        public bool Delete(int maloaihang)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "DELETE loaihang WHERE maloaihang = @maloaihang";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@maloaihang", SqlDbType.Int).Value = maloaihang;

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
