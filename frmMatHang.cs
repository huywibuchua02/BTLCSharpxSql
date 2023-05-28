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

namespace BTLCSharpxSql
{
    public partial class frmMatHang : Form
    {
        Modify modify;
        QLmatHang qLmatHang;
        connect cn = new connect(); // Khai báo biến cn kiểu Connect
        string chuoiketnoi = @"Data Source=HUYBU;Initial Catalog=BanHang;Integrated Security=True";

        public frmMatHang()
        {
            InitializeComponent();
            modify = new Modify();
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            LoadMatHangData();
        }

        private void LoadMatHangData()
        {
            try
            {
                dataGridView1.DataSource = modify.getAllMatHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            string mahang = textBox_maH.Text;
            string tenhang = textBox_tenH.Text;
            string maCongTy = textBox_MaCTY.Text;
            string maLoaiHang = textBox_maLH.Text;
            int soLuong = 0;
            int.TryParse(textBox_soLuong.Text, out soLuong);
            string donViTinh = textBox_DVT.Text;
            decimal giaHang = 0;
            decimal.TryParse(textBox_gia.Text, out giaHang);

            qLmatHang = new QLmatHang(mahang, tenhang, maCongTy, maLoaiHang, soLuong, donViTinh, giaHang);

            if (modify.Update(qLmatHang))
            {
                LoadMatHangData();
                MessageBox.Show("Thêm thành công!");
                ClearInputFields();
            }
            else
            {
                MessageBox.Show("Không thêm được!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            textBox_maH.Text = "";
            textBox_tenH.Text = "";
            textBox_MaCTY.Text = "";
            textBox_maLH.Text = "";
            textBox_soLuong.Text = "";
            textBox_DVT.Text = "";
            textBox_gia.Text = "";
        }

    }
}
