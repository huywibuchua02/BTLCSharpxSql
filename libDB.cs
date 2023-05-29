using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTLCSharpxSql
{
    internal class libDB
    {
        private string ConnectionString;

        public libDB(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public SqlCommand GetCmd(string sp_name)
        {
            SqlCommand cmd = new SqlCommand(sp_name);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;

        }

        public DataTable Query(SqlCommand cm)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                cm.Connection = cn;
                SqlDataReader dr = cm.ExecuteReader();//thực thi SQL -> trả về dr
                DataTable dt = new DataTable();// tạo 1 bảng trống để lưu dữ liệu đọc được
                dt.Load(dr);    //Lấy hết dữ liệu trong dr vào dt
                dr.Close();
                return dt;  //trả về kq
            }
        }

        public DataTable Query(string sql)
        {
            //sử dụng cấu trúc điều khiển USING để giải phóng đối tượng cm sau khi kết thúc khối USING
            using (SqlCommand cm = new SqlCommand(sql))
            {
                return Query(cm);
            }
        }

        public int RunSQL(SqlCommand cm)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                cm.Connection = cn;
                return cm.ExecuteNonQuery();//thực thi SQL -> trả về số dòng bị tác động
            }
        }

        public int RunSQL(string sql)
        {
            using (SqlCommand cm = new SqlCommand(sql))
            {
                return RunSQL(cm);
            }
        }
        public object Scalar(SqlCommand cm)
        {
            using (SqlConnection cn = new SqlConnection(ConnectionString))
            {
                cn.Open();
                cm.Connection = cn;
                return cm.ExecuteScalar();
            }
        }

        public object Scalar(string sql)
        {
            using (SqlCommand cm = new SqlCommand(sql))
            {
                return Scalar(cm);
            }

        }
    }
}
