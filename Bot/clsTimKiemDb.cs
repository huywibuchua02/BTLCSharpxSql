using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;

namespace Bot
{
    public class clsTimKiemDB
    {
        static string cnStr = "Server=HUYBU;Database=BTLQuanLyBanHang;Trusted_Connection=True;TrustServerCertificate=True;";

        public static string TimKiem(string q)
        {
            string kq = "";
            try
            {
                using (SqlConnection cn = new SqlConnection(cnStr))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandText = "sp_search";
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.Parameters.Add("@q", SqlDbType.NVarChar, 50).Value = "%" + q.Replace(' ', '%') + "%";
                        object obj = cm.ExecuteScalar(); //lấy col1 of row1
                        if (obj != null)
                            kq = (string)obj;
                        else
                            kq = "không có dữ liệu";
                    }
                }
            }
            catch (Exception ex)
            {
                kq += $"Error: {ex.Message}";
            }
            return kq;
        }
    }
}
