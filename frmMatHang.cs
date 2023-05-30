using System;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using BTLCSharpxSql.FMatHang;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTLCSharpxSql
{
    public partial class frmMatHang : Form
    {
        Modify_MH modify_MH;
        QLmatHang qlMatHang;

        public frmMatHang()
        {
            InitializeComponent();
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            modify_MH = new Modify_MH();
            try
            {
                dataGridView1.DataSource = modify_MH.GetAllMatHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            string maHang = this.txt_maHang.Text;
            string tenHang = this.txt_tenHang.Text;
            string maCongTy = this.txt_maCongTy.Text;
            string maLoaiHang = this.txt_maLoaiHang.Text;
            int soLuong = int.Parse(this.txt_soLuong.Text);
            string donViTinh = this.txt_donViTinh.Text;
            SqlMoney giaHang = SqlMoney.Parse(this.txt_giaHang.Text);

            qlMatHang = new QLmatHang(maHang, tenHang, maCongTy, maLoaiHang, soLuong, donViTinh, giaHang);

            if (modify_MH.ThemMatHang(qlMatHang))
            {
                dataGridView1.DataSource = modify_MH.GetAllMatHang();
                MessageBox.Show("Thêm mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được mặt hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            string maHang = this.txt_maHang.Text;
            string tenHang = this.txt_tenHang.Text;
            string maCongTy = this.txt_maCongTy.Text;
            string maLoaiHang = this.txt_maLoaiHang.Text;
            int soLuong = int.Parse(this.txt_soLuong.Text);
            string donViTinh = this.txt_donViTinh.Text;
            SqlMoney giaHang = SqlMoney.Parse(this.txt_giaHang.Text);

            qlMatHang = new QLmatHang(maHang, tenHang, maCongTy, maLoaiHang, soLuong, donViTinh, giaHang);

            if (modify_MH.SuaThongTinMatHang(qlMatHang))
            {
                dataGridView1.DataSource = modify_MH.GetAllMatHang();
                MessageBox.Show("Cập nhật mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không cập nhật được mặt hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                string maHang = dataGridView1.SelectedRows[0].Cells["maHang"].Value.ToString();
                if (modify_MH.XoaMatHang(maHang))
                {
                    dataGridView1.DataSource = modify_MH.GetAllMatHang();
                    MessageBox.Show("Xóa mặt hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không xóa được mặt hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_xuatExcel_Click_1(object sender, EventArgs e)
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
                    sheet.Cells[1, 1] = "Mã Hàng";
                    sheet.Cells[1, 2] = "Tên Hàng";
                    sheet.Cells[1, 3] = "Mã Công Ty";
                    sheet.Cells[1, 4] = "Mã Loại Hàng";
                    sheet.Cells[1, 5] = "Số Lượng";
                    sheet.Cells[1, 6] = "Đơn Vị Tính";
                    sheet.Cells[1, 7] = "Giá Hàng";


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
                    string savePath = @"D:\Excel\MatHang.xlsx";
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
