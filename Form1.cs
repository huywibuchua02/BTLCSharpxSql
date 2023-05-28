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

namespace BTLCSharpxSql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form currentFromChild;
        private void OpenChildForm(Form childForm)
        {
            if (currentFromChild != null)
            {
                currentFromChild.Close();
            }
            currentFromChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(childForm);
            panel_Body.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFromChild != null)
            {
                currentFromChild.Close();
            }
            label1.Text = "🏠 Home";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmMatHang());
            label1.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmLoaiHang());
            label1.Text = button2.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhaCungCap());
            label1.Text = button6.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDonDatHang());
            label1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChiTietDatHang());
            label1.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
            label1.Text = button5.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
            label1.Text = button7.Text;
        }
    }
}
