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
using BTLCSharpxSql.FNhaCungCap;

namespace BTLCSharpxSql.FMatHang
{
    public partial class frmNhaCungCap : Form
    {
        Modify_NCC modify_NCC;
        QLNhaCungCap qLNhaCungCap;
        connect cn = new connect(); // Khai báo biến cn kiểu Connect
        string chuoiketnoi = @"Data Source=HUYBU;Initial Catalog=BTLQuanLyBanHang;Integrated Security=True";

        public frmNhaCungCap()
        {
            InitializeComponent();
            modify_NCC = new Modify_NCC();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            LoadNhaCungCapData();
        }

        private void LoadNhaCungCapData()
        {
            try
            {
                dataGridView1.DataSource = modify_NCC.GetAllNhaCungCap();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            // Lấy tất cả dữ liệu đã nhập xuống:
            // Nên check lỗi người dùng nhập! Nếu có lỗi, thì return;
            string macongty = this.textBox_macongty.Text;
            string tencongty = this.textBox_tencongty.Text;
            string tengiaodich = this.textBox_tengiaodich.Text;
            string diachi = this.textBox_diachi.Text;
            string dienthoai = this.textBox_dienthoai.Text;
            string fax = this.textBox_fax.Text;
            string email = this.textBox_email.Text;

            qLNhaCungCap = new QLNhaCungCap(macongty, tencongty, tengiaodich, diachi, dienthoai, fax, email);

            // Chuẩn bị tên procedure:
            string query = "sp_nhacungcap_them";
            // Tạo đối tượng thư viện để gọi các hàm trong thư viện:
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query); // Lấy về đối tượng SqlCommand

            // Truyền dữ liệu cho cmd 
            truyenParameterNhaCungCap(ref cmd, qLNhaCungCap);

            // Thực hiện procedure bằng cách gọi thư viện
            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    frmNhaCungCap_Load(sender, e);
                    xoaThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void truyenParameterNhaCungCap(ref SqlCommand cmd, QLNhaCungCap qLNhaCungCap)
        {
            cmd.Parameters.Add("@macongty", SqlDbType.NVarChar).Value = qLNhaCungCap.Macongty;
            cmd.Parameters.Add("@tencongty", SqlDbType.NVarChar).Value = qLNhaCungCap.Tencongty;
            cmd.Parameters.Add("@tengiaodich", SqlDbType.NVarChar).Value = qLNhaCungCap.Tengiaodich;
            cmd.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = qLNhaCungCap.Diachi;
            cmd.Parameters.Add("@dienthoai", SqlDbType.NVarChar).Value = qLNhaCungCap.Dienthoai;
            cmd.Parameters.Add("@fax", SqlDbType.NVarChar).Value = qLNhaCungCap.Fax;
            cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = qLNhaCungCap.Email;
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string macongty = row.Cells["macongty"].Value.ToString();

                // Tạo câu truy vấn SQL hoặc gọi procedure để xóa dữ liệu
                string query = "sp_nhacungcap_xoa";
                libDB lib = new libDB(chuoiketnoi);
                SqlCommand cmd = lib.GetCmd(query);

                cmd.Parameters.Add("@macongty", SqlDbType.NVarChar, 10).Value = macongty;

                try
                {
                    int kq = lib.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        frmNhaCungCap_Load(sender, e);
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

        private void button_sua_Click(object sender, EventArgs e)
        {
            // Lấy tất cả dữ liệu đã nhập xuống:
            // Nên check lỗi người dùng nhập! Nếu có lỗi, thì return;
            string macongty = this.textBox_macongty.Text;
            string tencongty = this.textBox_tencongty.Text;
            string tengiaodich = this.textBox_tengiaodich.Text;
            string diachi = this.textBox_diachi.Text;
            string dienthoai = this.textBox_dienthoai.Text;
            string fax = this.textBox_fax.Text;
            string email = this.textBox_email.Text;

            qLNhaCungCap = new QLNhaCungCap(macongty, tencongty, tengiaodich, diachi, dienthoai, fax, email);

            // Chuẩn bị tên procedure:
            string query = "sp_nhacungcap_sua";
            // Tạo đối tượng thư viện để gọi các hàm trong thư viện:
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query); // Lấy về đối tượng SqlCommand

            // Truyền dữ liệu cho cmd 
            truyenParameterNhaCungCap(ref cmd, qLNhaCungCap);

            // Thực hiện procedure bằng cách gọi thư viện
            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    frmNhaCungCap_Load(sender, e);
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
            textBox_macongty.Text = string.Empty;
            textBox_tencongty.Text = string.Empty;
            textBox_tengiaodich.Text = string.Empty;
            textBox_diachi.Text = string.Empty;
            textBox_dienthoai.Text = string.Empty;
            textBox_fax.Text = string.Empty;
            textBox_email.Text = string.Empty;
        }
    }
}
