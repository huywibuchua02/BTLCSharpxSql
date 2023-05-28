using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BTLCSharpxSql
{
    public partial class frmMatHang : Form
    {
        Modify modify;
        QLmatHang qLmatHang;
 //       libDB lib;
        connect cn = new connect(); //Khai báo biến cn kiểu Connect
        string chuoiketnoi = @"Data Source=HUYBU;Initial Catalog=QuanLyBanHang;Integrated Security=True";

        public frmMatHang()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            {
                modify = new Modify();

                //đổ dữu liệu
                try
                {
                    dataGridView1.DataSource = modify.getAllMatHang();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_sl_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_them_Click(object sender, EventArgs e)
        {
            // lấy tất cả dữ liệu đã nhập xuống:
            // Nên check lỗi người dùng nhập! => nếu mà lỗi thì return;
            string mahang = this.textBox_maH.Text;
            string tenhang = this.textBox_tenH.Text;
            string maCongTy = this.textBox_MaCTY.Text;
            string maLoaiHang = this.textBox_maLH.Text;
            int soLuong = Convert.ToInt32(this.textBox_soLuong.Text);
            string donViTinh = this.textBox_DVT.Text;
            SqlMoney giaHang = SqlMoney.Parse(this.textBox_gia.Text);
            qLmatHang = new QLmatHang(mahang, tenhang, maCongTy, maLoaiHang, soLuong, donViTinh, giaHang);



            // tao demo thực hiện proceduce - chuỗi k phải sql nữa mà là tên proceduce
            // chuẩn bị tên proceduce:
            string query = "sp_mathang_Insert";
            // new đối tượng thư viên để gọi các hàm trong thư viện:
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query); // lấy về đối tượng sqlcomman

            // Cần phải truyền dũ liệu cho cmd 
            truyenParameterMatHang(ref cmd, qLmatHang);


            // thực hiện proceduce bằng cách là gọi  thư viên
            try
            {
                // đây là câu lệnh thêm nên 
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("thêm thành công!");
                    frmMatHang_Load(sender, e);
                    xoaThongTin();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

        }

        private void xoaThongTin()
        {

        }

        private void truyenParameterMatHang(ref SqlCommand cmd, QLmatHang qLmatHang)
        {

            cmd.Parameters.Add("@mahang", SqlDbType.NVarChar).Value = qLmatHang.MaHang;
            cmd.Parameters.Add("@tenhang", SqlDbType.NVarChar).Value = qLmatHang.TenHang;
            cmd.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = qLmatHang.MaCongTy;
            cmd.Parameters.Add("@maloaihang", SqlDbType.NVarChar).Value = qLmatHang.Maloaihang;
            cmd.Parameters.Add("@soluong", SqlDbType.Int).Value = qLmatHang.Soluong;
            cmd.Parameters.Add("@donvitinh", SqlDbType.NVarChar).Value = qLmatHang.DonviTinh;
            cmd.Parameters.Add("@giahang", SqlDbType.Money).Value = qLmatHang.GiaHang;
        }
    }
}
