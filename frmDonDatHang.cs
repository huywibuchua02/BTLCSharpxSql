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
using Excel = Microsoft.Office.Interop.Excel;
using BTLCSharpxSql.FDonDatHang;

namespace BTLCSharpxSql.FLoaiHang
{
    public partial class frmDonDatHang : Form
    {
        Modify_DDH modify_DDH;
        QLdonDatHang qLdonDatHang;
        connect cn = new connect();
        string chuoiketnoi = @"Data Source=HUYBU;Initial Catalog=BTLQuanLyBanHang;Integrated Security=True";

        public frmDonDatHang()
        {
            InitializeComponent();
            modify_DDH = new Modify_DDH();
        }

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            LoadDonDatHangData();
        }

        private void LoadDonDatHangData()
        {
            try
            {
                dataGridView1.DataSource = modify_DDH.GetAllDonDatHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sohoadon = Convert.ToInt32(this.txt_sohoadon.Text);
            string makhachhang = this.txt_makhachhang.Text;
            string manhanvien = this.txt_manhanvien.Text;
            DateTime ngaydathang = this.dtp_ngaydathang.Value;
            DateTime ngaygiaohang = this.dtp_ngaygiaohang.Value;
            DateTime ngaychuyenhang = this.dtp_ngaychuyenhang.Value;
            string noigiaohang = this.txt_noigiaohang.Text;

            qLdonDatHang = new QLdonDatHang(sohoadon, makhachhang, manhanvien, ngaydathang, ngaygiaohang, ngaychuyenhang, noigiaohang);

            string query = "sp_dondathang_them";
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query);

            truyenParameterDonDatHang(ref cmd, qLdonDatHang);

            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Thêm thành công!");
                    frmDonDatHang_Load(sender, e);
                    xoaThongTin();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void truyenParameterDonDatHang(ref SqlCommand cmd, QLdonDatHang qLdonDatHang)
        {
            cmd.Parameters.Add("@sohoadon", SqlDbType.Int).Value = qLdonDatHang.Sohoadon;
            cmd.Parameters.Add("@makhachhang", SqlDbType.NVarChar).Value = qLdonDatHang.Makhachhang;
            cmd.Parameters.Add("@manhanvien", SqlDbType.NVarChar).Value = qLdonDatHang.Manhanvien;
            cmd.Parameters.Add("@ngaydathang", SqlDbType.DateTime).Value = qLdonDatHang.Ngaydathang;
            cmd.Parameters.Add("@ngaygiaohang", SqlDbType.DateTime).Value = qLdonDatHang.Ngaygiaohang;
            cmd.Parameters.Add("@ngaychuyenhang", SqlDbType.DateTime).Value = qLdonDatHang.Ngaychuyenhang;
            cmd.Parameters.Add("@noigiaohang", SqlDbType.NVarChar).Value = qLdonDatHang.Noigiaohang;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                int sohoadon = Convert.ToInt32(row.Cells["sohoadon"].Value);

                string query = "sp_dondathang_xoa";
                libDB lib = new libDB(chuoiketnoi);
                SqlCommand cmd = lib.GetCmd(query);

                cmd.Parameters.Add("@sohoadon", SqlDbType.Int).Value = sohoadon;

                try
                {
                    int kq = lib.RunSQL(cmd);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        frmDonDatHang_Load(sender, e);
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
            int sohoadon = Convert.ToInt32(this.txt_sohoadon.Text);
            string makhachhang = this.txt_makhachhang.Text;
            string manhanvien = this.txt_manhanvien.Text;
            DateTime ngaydathang = this.dtp_ngaydathang.Value;
            DateTime ngaygiaohang = this.dtp_ngaygiaohang.Value;
            DateTime ngaychuyenhang = this.dtp_ngaychuyenhang.Value;
            string noigiaohang = this.txt_noigiaohang.Text;

            qLdonDatHang = new QLdonDatHang(sohoadon, makhachhang, manhanvien, ngaydathang, ngaygiaohang, ngaychuyenhang, noigiaohang);

            string query = "sp_dondathang_sua";
            libDB lib = new libDB(chuoiketnoi);
            SqlCommand cmd = lib.GetCmd(query);

            truyenParameterDonDatHang(ref cmd, qLdonDatHang);

            try
            {
                int kq = lib.RunSQL(cmd);
                if (kq > 0)
                {
                    MessageBox.Show("Sửa thành công!");
                    frmDonDatHang_Load(sender, e);
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
            txt_sohoadon.Text = string.Empty;
            txt_makhachhang.Text = string.Empty;
            txt_manhanvien.Text = string.Empty;
            txt_noigiaohang.Text = string.Empty;
            dtp_ngaydathang.Value = DateTime.Now;
            dtp_ngaygiaohang.Value = DateTime.Now;
            dtp_ngaychuyenhang.Value = DateTime.Now;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    // Tạo đối tượng Excel
                    Excel.Application excel = new Excel.Application();
                    excel.Visible = true;
                    Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet sheet = (Excel.Worksheet)workbook.ActiveSheet;

                    // Đổ dữ liệu từ DataGridView vào Excel
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                sheet.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // Lưu file Excel
                    string savePath = @"D:\Excel\DonDatHang.xlsx";
                    workbook.SaveAs(savePath);
                    MessageBox.Show("Xuất file Excel thành công! Đường dẫn: " + savePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
