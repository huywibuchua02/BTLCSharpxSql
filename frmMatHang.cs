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
    public partial class frmMatHang : Form
    {
        Modify modify;
        QLmatHang qLmatHang;
        connect cnn = new connect(); //Khai báo biến cnn kiểu Connect

        public frmMatHang()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            {
                modify = new Modify();

                //đổ dữu liệu
                try
                {
                    dataGridView1.DataSource = modify.getAllMatHang();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_sl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
