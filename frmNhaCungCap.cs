using System;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using BTLCSharpxSql.FMatHang;
using BTLCSharpxSql.FNhaCungCap;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTLCSharpxSql
{
    public partial class frmNhaCungCap : Form
    {
        Modify_NCC modify_NCC;
        QLNhaCungCap qLNhaCungCap;

        public frmNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            modify_NCC = new Modify_NCC();
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
            string maCongTy = this.txt_maCongTy.Text;
            string tenCongTy = this.txt_tenCongTy.Text;
            string tenGiaoDich = this.txt_tenGiaoDich.Text;
            string diaChi = this.txt_diaChi.Text;
            string dienThoai = this.txt_dienThoai.Text;
            string fax = this.txt_fax.Text;
            string email = this.txt_email.Text;

            qLNhaCungCap = new QLNhaCungCap(maCongTy, tenCongTy, tenGiaoDich, diaChi, dienThoai, fax, email);

            if (modify_NCC.ThemNhaCungCap(qLNhaCungCap))
            {
                dataGridView1.DataSource = modify_NCC.GetAllNhaCungCap();
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            string maCongTy = this.txt_maCongTy.Text;
            string tenCongTy = this.txt_tenCongTy.Text;
            string tenGiaoDich = this.txt_tenGiaoDich.Text;
            string diaChi = this.txt_diaChi.Text;
            string dienThoai = this.txt_dienThoai.Text;
            string fax = this.txt_fax.Text;
            string email = this.txt_email.Text;

            qLNhaCungCap = new QLNhaCungCap(maCongTy, tenCongTy, tenGiaoDich, diaChi, dienThoai, fax, email);

            if (modify_NCC.SuaThongTinNhaCungCap(qLNhaCungCap))
            {
                dataGridView1.DataSource = modify_NCC.GetAllNhaCungCap();
                MessageBox.Show("Cập nhật nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không cập nhật được nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maCongTy = dataGridView1.SelectedRows[0].Cells["maCongTy"].Value.ToString();

                if (modify_NCC.XoaNhaCungCap(maCongTy))
                {
                    dataGridView1.DataSource = modify_NCC.GetAllNhaCungCap();
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không xóa được nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button_xuatExcel_Click(object sender, EventArgs e)
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
                    sheet.Cells[1, 1] = "Mã Công Ty";
                    sheet.Cells[1, 2] = "Tên Công Ty";
                    sheet.Cells[1, 3] = "Tên Giao Dịch";
                    sheet.Cells[1, 4] = "Địa Chỉ";
                    sheet.Cells[1, 5] = "Điện Thoại";
                    sheet.Cells[1, 6] = "Fax";
                    sheet.Cells[1, 7] = "Email";


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
                    string savePath = @"D:\Excel\NhaCungCap.xlsx";
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
