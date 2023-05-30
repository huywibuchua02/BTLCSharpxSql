using System;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using BTLCSharpxSql.FChiTietDonHang;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTLCSharpxSql
{
    public partial class frmChiTietDonHang : Form
    {
        Modify_CTDH modify_CTDH;
        QLchiTietDonHang qLChiTietDonHang;

        public frmChiTietDonHang()
        {
            InitializeComponent();
        }

        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {
            modify_CTDH = new Modify_CTDH();
            try
            {
                dataGridView1.DataSource = modify_CTDH.GetAllChiTietDonHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            int soHoaDon = int.Parse(this.txt_soHoaDon.Text);
            string maHang = this.txt_maHang.Text;
            SqlMoney giaBan = SqlMoney.Parse(this.txt_giaBan.Text);
            int soLuong = int.Parse(this.txt_soLuong.Text);
            double mucGiamGia = double.Parse(this.txt_mucGiamGia.Text);
            qLChiTietDonHang = new QLchiTietDonHang(soHoaDon, maHang, giaBan, soLuong, mucGiamGia);

            if (modify_CTDH.ThemChiTietDonHang(qLChiTietDonHang))
            {
                dataGridView1.DataSource = modify_CTDH.GetAllChiTietDonHang();
                MessageBox.Show("Thêm chi tiết đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được chi tiết đơn hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            int soHoaDon = int.Parse(this.txt_soHoaDon.Text);
            string maHang = this.txt_maHang.Text;
            SqlMoney giaBan = SqlMoney.Parse(this.txt_giaBan.Text);
            int soLuong = int.Parse(this.txt_soLuong.Text);
            double mucGiamGia = double.Parse(this.txt_mucGiamGia.Text);
            qLChiTietDonHang = new QLchiTietDonHang(soHoaDon, maHang, giaBan, soLuong, mucGiamGia);

            if (modify_CTDH.SuaThongTinChiTietDonHang(qLChiTietDonHang))
            {
                dataGridView1.DataSource = modify_CTDH.GetAllChiTietDonHang();
                MessageBox.Show("Cập nhật chi tiết đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không cập nhật được chi tiết đơn hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int soHoaDon = int.Parse(dataGridView1.SelectedRows[0].Cells["soHoaDon"].Value.ToString());

                if (modify_CTDH.XoaChiTietDonHang(soHoaDon))
                {
                    dataGridView1.DataSource = modify_CTDH.GetAllChiTietDonHang();
                    MessageBox.Show("Xóa chi tiết đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không xóa được chi tiết đơn hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    sheet.Cells[1, 1] = "Số hóa đơn";
                    sheet.Cells[1, 2] = "Mã hàng";
                    sheet.Cells[1, 3] = "Giá bán";
                    sheet.Cells[1, 4] = "Số lượng";
                    sheet.Cells[1, 5] = "Mức giảm giá";

                    // Đổ dữ liệu từ DataGridView vào Excel
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


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
