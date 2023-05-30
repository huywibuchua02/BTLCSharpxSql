using System;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using BTLCSharpxSql.FNhanVien;
using Excel = Microsoft.Office.Interop.Excel;


namespace BTLCSharpxSql
{
    public partial class frmNhanVien : Form
    {
        Modify_NV modify_NV;
        QLNhanVien qLNhanVien;

        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            modify_NV = new Modify_NV();
            try
            {
                dataGridView1.DataSource = modify_NV.GetAllNhanVien();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string manhanvien = this.txt_maNV.Text;
            string ho = this.txt_ho.Text;
            string ten = this.txt_ten.Text;
            DateTime ngaysinh = this.dtp_ngaySinh.Value;
            DateTime ngaylamviec = this.dtp_ngayLamViec.Value;
            string diachi = this.txt_diaChi.Text;
            string dienthoai = this.txt_dienThoai.Text;
            SqlMoney luongcoban = SqlMoney.Parse(this.txt_luongCoBan.Text);
            SqlMoney phucap = SqlMoney.Parse(this.txt_phuCap.Text);
            qLNhanVien = new QLNhanVien(manhanvien, ho, ten, ngaysinh, ngaylamviec, diachi, dienthoai, luongcoban, phucap);
            if (modify_NV.ThemNhanVien(qLNhanVien))
            {
                dataGridView1.DataSource = modify_NV.GetAllNhanVien();
                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string manhanvien = this.txt_maNV.Text;
            string ho = this.txt_ho.Text;
            string ten = this.txt_ten.Text;
            DateTime ngaysinh = this.dtp_ngaySinh.Value;
            DateTime ngaylamviec = this.dtp_ngayLamViec.Value;
            string diachi = this.txt_diaChi.Text;
            string dienthoai = this.txt_dienThoai.Text;
            SqlMoney luongcoban = SqlMoney.Parse(this.txt_luongCoBan.Text);
            SqlMoney phucap = SqlMoney.Parse(this.txt_phuCap.Text);
            qLNhanVien = new QLNhanVien(manhanvien, ho, ten, ngaysinh, ngaylamviec, diachi, dienthoai, luongcoban, phucap);
            if (modify_NV.SuaThongTinNhanVien(qLNhanVien))
            {
                dataGridView1.DataSource = modify_NV.GetAllNhanVien();
                MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không cập nhật được nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string manhanvien = dataGridView1.SelectedRows[0].Cells["manhanvien"].Value.ToString();
                if (modify_NV.XoaNhanVien(manhanvien))
                {
                    dataGridView1.DataSource = modify_NV.GetAllNhanVien();
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không xóa được nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    string savePath = @"D:\Excel\NhanVien.xlsx";
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
