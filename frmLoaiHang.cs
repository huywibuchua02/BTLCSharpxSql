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

namespace BTLCSharpxSql.FLoaiHang
{
    public partial class frmLoaiHang : Form
    {
        Modify_LH modify_LH;
        QLloaiHang qLloaiHang;
        connect cn = new connect(); // Khai báo biến cn kiểu Connect
        string chuoiketnoi = @"Data Source=HUYBU;Initial Catalog=BTLQuanLyBanHang;Integrated Security=True";

        public frmLoaiHang()
        {
            InitializeComponent();
            modify_LH = new Modify_LH();
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            LoadLoaiHangData();
        }

        private void LoadLoaiHangData()
        {
            try
            {
                dataGridView1.DataSource = modify_LH.GetAllLoaiHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // lấy tất cả dữ liệu đã nhập xuống:
            // Nên check lỗi người dùng nhập! => nếu mà lỗi thì return;
            int maloaihang = Convert.ToInt32(this.txt_maLoaiHang.Text);
            string tenloaihang = this.txt_tenLoaiHang.Text;

            qLloaiHang = new QLloaiHang(maloaihang, tenloaihang);

            // tao demo thực hiện proceduce - chuỗi k phải sql nữa mà là tên proceduce
            // chuẩn bị tên proceduce:
            string query = "sp_loaihang_them";
            // new đối tượng thư viện để gọi các hàm trong thư viện:
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query); // lấy về đối tượng sqlcomman

            // Cần phải truyền dữ liệu cho cmd 
            truyenParameterLoaiHang(ref cmd, qLloaiHang);

            // thực hiện procedure bằng cách gọi thư viện
            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    frmLoaiHang_Load(sender, e);
                    xoaThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void truyenParameterLoaiHang(ref SqlCommand cmd, QLloaiHang qLloaiHang)
        {
            cmd.Parameters.Add("@maloaihang", SqlDbType.Int).Value = qLloaiHang.Maloaihang;
            cmd.Parameters.Add("@tenloaihang", SqlDbType.NVarChar).Value = qLloaiHang.Tenloaihang;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int maloaihang = Convert.ToInt32(row.Cells["maloaihang"].Value);

                // Tạo câu truy vấn SQL hoặc gọi procedure để xóa dữ liệu
                string query = "sp_loaihang_xoa";
                libDB lib = new libDB(chuoiketnoi);
                SqlCommand cmd = lib.GetCmd(query);

                cmd.Parameters.Add("@maloaihang", SqlDbType.Int).Value = maloaihang;

                try
                {
                    int kq = lib.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        frmLoaiHang_Load(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // lấy tất cả dữ liệu đã nhập xuống:
            // Nên check lỗi người dùng nhập! => nếu mà lỗi thì return;
            int maloaihang = Convert.ToInt32(this.txt_maLoaiHang.Text);
            string tenloaihang = this.txt_tenLoaiHang.Text;

            qLloaiHang = new QLloaiHang(maloaihang, tenloaihang);

            // tao demo thực hiện proceduce - chuỗi k phải sql nữa mà là tên proceduce
            // chuẩn bị tên proceduce:
            string query = "sp_loaihang_sua";
            // new đối tượng thư viên để gọi các hàm trong thư viện:
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query); // lấy về đối tượng sqlcomman

            // Cần phải truyền dữ liệu cho cmd 
            truyenParameterLoaiHang(ref cmd, qLloaiHang);

            // thực hiện procedure bằng cách gọi thư viện
            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    frmLoaiHang_Load(sender, e);
                    xoaThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void xoaThongTin()
        {
            txt_maLoaiHang.Text = string.Empty;
            txt_tenLoaiHang.Text = string.Empty;
        }
    }
}
