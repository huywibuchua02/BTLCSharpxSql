using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace BTLCSharpxSql.FNhaCungCap
{
    internal class Modify_NCC
    {
        SqlDataAdapter dataAdapter; // Truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // Truy vấn cập nhật tới CSDL

        public Modify_NCC()
        {
        }

        // Lấy tất cả nhà cung cấp
        public DataTable GetAllNhaCungCap()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from nhacungcap";
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

        // Cập nhật thông tin nhà cung cấp
        public bool Update(QLNhaCungCap qLNhaCungCap)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "update nhacungcap set tencongty = @tencongty, tengiaodich = @tengiaodich, diachi = @diachi, dienthoai = @dienthoai,"
                + "fax = @fax, email = @email "
                + "WHERE macongty = @macongty;";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = qLNhaCungCap.Macongty;
                sqlCommand.Parameters.Add("@tencongty", SqlDbType.NVarChar).Value = qLNhaCungCap.Tencongty;
                sqlCommand.Parameters.Add("@tengiaodich", SqlDbType.NVarChar).Value = qLNhaCungCap.Tengiaodich;
                sqlCommand.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = qLNhaCungCap.Diachi;
                sqlCommand.Parameters.Add("@dienthoai", SqlDbType.NVarChar).Value = qLNhaCungCap.Dienthoai;
                sqlCommand.Parameters.Add("@fax", SqlDbType.NVarChar).Value = qLNhaCungCap.Fax;
                sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = qLNhaCungCap.Email;
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

        // Xóa nhà cung cấp
        public bool Delete(string macongty)
        {
            SqlConnection sqlConnection = connect.GetConnection();

            string query = "delete nhacungcap where macongty=@macongty";

            //khi thực thi dù ảnh hưởng lỗi như nào thì luôn luôn đóng(ở finally)
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = macongty;

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
