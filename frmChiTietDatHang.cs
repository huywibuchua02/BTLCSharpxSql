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
                    Excel.Application excelApp = new Excel.Application();
                    excelApp.Application.Workbooks.Add(Type.Missing);

                    for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
                    {
                        excelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            excelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    excelApp.Columns.AutoFit();
                    excelApp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất ra Excel", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
