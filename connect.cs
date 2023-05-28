using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BTLCSharpxSql
{
    internal class connect
    {
        //chuỗi kết nối
        private static string stringConncect = @"Data Source=HUYBU;Initial Catalog=BanHang;Integrated Security=True";
        //kết nối mở csdl
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(stringConncect);
        }
    }

}
