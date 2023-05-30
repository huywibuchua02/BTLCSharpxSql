using System;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using BTLCSharpxSql.FKhachHang;
using BTLCSharpxSql.FNhanVien;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTLCSharpxSql
{
    public partial class frmKhachHang : Form
    {
        Modify_KH modify_KH;
        QLkhachHang qLkhachHang;

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            modify_KH = new Modify_KH();
            try
            {
                dataGridView1.DataSource = modify_KH.GetAllKhachHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            string maKhachHang = this.txt_maKhachHang.Text;
            string tenCongTy = this.txt_tenCongTy.Text;
            string tenGiaoDich = this.txt_tenGiaoDich.Text;
            string diaChi = this.txt_diaChi.Text;
            string email = this.txt_email.Text;
            string dienThoai = this.txt_dienThoai.Text;
            string fax = this.txt_fax.Text;
            QLkhachHang qLkhachHang = new QLkhachHang(maKhachHang, tenCongTy, tenGiaoDich, diaChi, email, dienThoai, fax);
            if (modify_KH.ThemKhachHang(qLkhachHang))
            {
                dataGridView1.DataSource = modify_KH.GetAllKhachHang();
                MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            string maKhachHang = this.txt_maKhachHang.Text;
            string tenCongTy = this.txt_tenCongTy.Text;
            string tenGiaoDich = this.txt_tenGiaoDich.Text;
            string diaChi = this.txt_diaChi.Text;
            string email = this.txt_email.Text;
            string dienThoai = this.txt_dienThoai.Text;
            string fax = this.txt_fax.Text;
            QLkhachHang qLkhachHang = new QLkhachHang(maKhachHang, tenCongTy, tenGiaoDich, diaChi, email, dienThoai, fax);
            if (modify_KH.SuaThongTinKhachHang(qLkhachHang))
            {
                dataGridView1.DataSource = modify_KH.GetAllKhachHang();
                MessageBox.Show("Cập nhật khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không cập nhật được khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maKhachHang = dataGridView1.SelectedRows[0].Cells["maKhachHang"].Value.ToString();
                if (modify_KH.XoaKhachHang(maKhachHang))
                {
                    dataGridView1.DataSource = modify_KH.GetAllKhachHang();
                    MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không xóa được khách hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    string savePath = @"D:\Excel\KhachHang.xlsx";
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
