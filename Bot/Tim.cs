using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Bot
{
    public class Tim
    {
        static string cnStr = "Server=HUYBU;Database=BTLQuanLyBanHang;Trusted_Connection=True;TrustServerCertificate=True;";

/*        public string TimKH(string t)
        {
            string query = "[sp_khachhang_Search]";
            string kq = "";
            using (SqlConnection con = new SqlConnection(cnStr))
            {

                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@TenKhachHang", System.Data.SqlDbType.NVarChar, 50).Value = t;
                        cmd.CommandType = CommandType.StoredProcedure;
                        object kqTrave = cmd.ExecuteScalar();

                        kq = (string)kqTrave;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("lỗi tìm kiếm" + e.Message);
                }
                return kq;
            }
        }*/

        public string TimHD(string t)
        {
            string query = "[sp_dondathang_Search]";
            string kq = "";
            using (SqlConnection con = new SqlConnection(cnStr))
            {

                con.Open();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add("@makhachhang ", System.Data.SqlDbType.NVarChar, 50).Value = t;
                        cmd.CommandType = CommandType.StoredProcedure;
                        object kqTrave = cmd.ExecuteScalar();

                        kq = (string)kqTrave;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("lỗi tìm kiếm" + e.Message);
                }
                return kq;
            }
        }
    }
}
