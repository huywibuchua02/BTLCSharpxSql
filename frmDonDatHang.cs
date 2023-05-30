using System;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using BTLCSharpxSql.FDonDatHang;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTLCSharpxSql
{
    public partial class frmDonDatHang : Form
    {
        Modify_DDH modify_DDH;
        QLdonDatHang qLdonDatHang;

        public frmDonDatHang()
        {
            InitializeComponent();
        }

        private void frmDonDatHang_Load(object sender, EventArgs e)
        {
            modify_DDH = new Modify_DDH();
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
            int sohoadon = int.Parse(txt_sohoadon.Text);
            string makhachhang = txt_makhachhang.Text;
            string manhanvien = txt_manhanvien.Text;
            DateTime ngaydathang = dtp_ngaydathang.Value;
            DateTime ngaygiaohang = dtp_ngaygiaohang.Value;
            DateTime ngaychuyenhang = dtp_ngaychuyenhang.Value;
            string noigiaohang = txt_noigiaohang.Text;
            qLdonDatHang = new QLdonDatHang(sohoadon, makhachhang, manhanvien, ngaydathang, ngaygiaohang, ngaychuyenhang, noigiaohang);
            if (modify_DDH.ThemDonDatHang(qLdonDatHang))
            {
                dataGridView1.DataSource = modify_DDH.GetAllDonDatHang();
                MessageBox.Show("Thêm đơn đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được đơn đặt hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sohoadon = int.Parse(txt_sohoadon.Text);
            string makhachhang = txt_makhachhang.Text;
            string manhanvien = txt_manhanvien.Text;
            DateTime ngaydathang = dtp_ngaydathang.Value;
            DateTime ngaygiaohang = dtp_ngaygiaohang.Value;
            DateTime ngaychuyenhang = dtp_ngaychuyenhang.Value;
            string noigiaohang = txt_noigiaohang.Text;
            qLdonDatHang = new QLdonDatHang(sohoadon, makhachhang, manhanvien, ngaydathang, ngaygiaohang, ngaychuyenhang, noigiaohang);
            if (modify_DDH.SuaThongTinDonDatHang(qLdonDatHang))
            {
                dataGridView1.DataSource = modify_DDH.GetAllDonDatHang();
                MessageBox.Show("Cập nhật đơn đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không cập nhật được đơn đặt hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int sohoadon = int.Parse(dataGridView1.SelectedRows[0].Cells["sohoadon"].Value.ToString());
                if (modify_DDH.XoaDonDatHang(sohoadon))
                {
                    dataGridView1.DataSource = modify_DDH.GetAllDonDatHang();
                    MessageBox.Show("Xóa đơn đặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không xóa được đơn đặt hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn đặt hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

                    // Đặt tên các cột trong Excel
                    sheet.Cells[1, 1] = "Số hóa đơn";
                    sheet.Cells[1, 2] = "Mã khách hàng";
                    sheet.Cells[1, 3] = "Mã nhân viên";
                    sheet.Cells[1, 4] = "Ngày đặt hàng";
                    sheet.Cells[1, 5] = "Ngày giao hàng";
                    sheet.Cells[1, 6] = "Ngày chuyển hàng";
                    sheet.Cells[1, 7] = "Nơi giao hàng";

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[j].Value != null)
                            {
                                sheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // Lưu file Excel
                    string savePath = @"D:\Excel\ChiTietDatHang.xlsx";
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
