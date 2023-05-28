using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCSharpxSql.FLoaiHang
{
    public partial class frmLoaiHang : Form
    {
        Modify_LH modify_LH;
        QLloaiHang qLloaiHang;
        string chuoiketnoi = @"Data Source=HUYBU;Initial Catalog=QuanLyBanHang;Integrated Security=True";

        public frmLoaiHang()
        {
            InitializeComponent();
            modify_LH = new Modify_LH();
        }

        private void fmLoaiHang_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                string maloaihang = row.Cells["maloaihang"].Value.ToString();

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
                        LoadLoaiHangData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
/*            int maloaihang = Convert.ToInt32(this.txt_maLoaiHang.Text);*/
            int maloaihang;
            if (!int.TryParse(this.txt_maLoaiHang.Text, out maloaihang))
            {
                MessageBox.Show("mã loại hàng không hợp lệ. Vui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string tenloaihang = this.txt_tenLoaiHang.Text;
            QLloaiHang qLloaiHang = new QLloaiHang(maloaihang, tenloaihang);

            string query = "sp_loaihang_sua";
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query);

            cmd.Parameters.Add("@maloaihang", SqlDbType.Int).Value = maloaihang;
            cmd.Parameters.Add("@tenloaihang", SqlDbType.NVarChar, 50).Value = tenloaihang;

            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    LoadLoaiHangData();
                    xoaThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int maloaihang = Convert.ToInt32(this.txt_maLoaiHang.Text);
            string tenloaihang = this.txt_tenLoaiHang.Text;
            QLloaiHang qLloaiHang = new QLloaiHang(maloaihang, tenloaihang);

            string query = "sp_loaihang_them";
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query);

            cmd.Parameters.Add("@maloaihang", SqlDbType.Int).Value = maloaihang;
            cmd.Parameters.Add("@tenloaihang", SqlDbType.NVarChar, 50).Value = tenloaihang;

            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    LoadLoaiHangData();
                    xoaThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void xoaThongTin()
        {
            txt_maLoaiHang.Text = string.Empty;
            txt_tenLoaiHang.Text = string.Empty;
        }
    }
}
