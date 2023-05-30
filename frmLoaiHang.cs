using System;
using System.Data;
using System.Data.SqlTypes;
using System.Windows.Forms;
using BTLCSharpxSql.FLoaiHang;
using BTLCSharpxSql.FNhanVien;
using Excel = Microsoft.Office.Interop.Excel;

namespace BTLCSharpxSql
{
    public partial class frmLoaiHang : Form
    {
        Modify_LH modify_LH;
        QLloaiHang qLloaiHang;

        public int maloaihang;
        private string tenloaihang;

        public frmLoaiHang()
        {
            InitializeComponent();
        }

        private void frmLoaiHang_Load(object sender, EventArgs e)
        {
            modify_LH = new Modify_LH();
            try
            {
                dataGridView1.DataSource = modify_LH.GetAllLoaiHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            maloaihang = int.Parse(this.txt_maloaihang.Text);
            tenloaihang = this.txt_tenloaihang.Text;

            qLloaiHang = new QLloaiHang(maloaihang, tenloaihang);

            if (modify_LH.ThemLoaiHang(qLloaiHang))
            {
                dataGridView1.DataSource = modify_LH.GetAllLoaiHang();
                MessageBox.Show("Thêm loại hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không thêm được loại hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            maloaihang = int.Parse(this.txt_maloaihang.Text);
            tenloaihang = this.txt_tenloaihang.Text;

            qLloaiHang = new QLloaiHang(maloaihang, tenloaihang);

            if (modify_LH.SuaThongTinLoaiHang(qLloaiHang))
            {
                dataGridView1.DataSource = modify_LH.GetAllLoaiHang();
                MessageBox.Show("Cập nhật loại hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lỗi: Không cập nhật được loại hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                maloaihang = int.Parse(dataGridView1.SelectedRows[0].Cells["maloaihang"].Value.ToString());
                if (modify_LH.XoaLoaiHang(maloaihang))
                {
                    dataGridView1.DataSource = modify_LH.GetAllLoaiHang();
                    MessageBox.Show("Xóa loại hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không xóa được loại hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        sheet.Cells[1, 1] = "Mã khách hàng";
                        sheet.Cells[1, 2] = "Tên loại hàng";


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
                        string savePath = @"D:\Excel\LoaiHang.xlsx";
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
