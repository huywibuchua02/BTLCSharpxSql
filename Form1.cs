using BTLCSharpxSql.FDonDatHang;
using BTLCSharpxSql.FLoaiHang;
using BTLCSharpxSql.FMatHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace BTLCSharpxSql
{
    public partial class Form1 : Form
    {
        private Form currentFormChild;
        private Button currentButton;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, Button button)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            currentFormChild = childForm;
            currentFormChild.TopLevel = false;
            currentFormChild.FormBorderStyle = FormBorderStyle.None;
            currentFormChild.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(currentFormChild);
            panel_Body.Tag = currentFormChild;
            currentFormChild.BringToFront();
            currentFormChild.Show();

            // Đặt màu viền cho button hiện tại
            if (currentButton != null)
            {
                currentButton.FlatAppearance.BorderSize = 0;
/*                currentButton.FlatAppearance.BorderColor = Color.White;*/
            }

            currentButton = button;
            currentButton.FlatAppearance.BorderSize = 2;
            currentButton.FlatAppearance.BorderColor = Color.DarkOrange;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }

            label1.Text = "🏠 Home";
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmMatHang(), button1);
            label1.Text = button1.Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmLoaiHang(), button2);
            label1.Text = button2.Text;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmDonDatHang(), button3);
            label1.Text = button3.Text;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmChiTietDonHang(), button4);
            label1.Text = button4.Text;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang(), button5);
            label1.Text = button5.Text;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap(), button6);
            label1.Text = button6.Text;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien(), button7);
            label1.Text = button7.Text;
        }
    }
}
