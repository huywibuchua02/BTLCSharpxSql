namespace BTLCSharpxSql
{
    partial class frmChiTietDonHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_soHoaDon = new System.Windows.Forms.TextBox();
            this.txt_maHang = new System.Windows.Forms.TextBox();
            this.txt_giaBan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_mucGiamGia = new System.Windows.Forms.TextBox();
            this.txt_soLuong = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_xuatExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 183);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 321);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số Hóa Đơn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã Hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 113);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Giá Bán:";
            // 
            // txt_soHoaDon
            // 
            this.txt_soHoaDon.Location = new System.Drawing.Point(171, 25);
            this.txt_soHoaDon.Margin = new System.Windows.Forms.Padding(4);
            this.txt_soHoaDon.Name = "txt_soHoaDon";
            this.txt_soHoaDon.Size = new System.Drawing.Size(132, 22);
            this.txt_soHoaDon.TabIndex = 4;
            // 
            // txt_maHang
            // 
            this.txt_maHang.Location = new System.Drawing.Point(171, 64);
            this.txt_maHang.Margin = new System.Windows.Forms.Padding(4);
            this.txt_maHang.Name = "txt_maHang";
            this.txt_maHang.Size = new System.Drawing.Size(132, 22);
            this.txt_maHang.TabIndex = 5;
            // 
            // txt_giaBan
            // 
            this.txt_giaBan.Location = new System.Drawing.Point(171, 105);
            this.txt_giaBan.Margin = new System.Windows.Forms.Padding(4);
            this.txt_giaBan.Name = "txt_giaBan";
            this.txt_giaBan.Size = new System.Drawing.Size(132, 22);
            this.txt_giaBan.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(392, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mức Giảm Giá:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(392, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số Lượng";
            // 
            // txt_mucGiamGia
            // 
            this.txt_mucGiamGia.Location = new System.Drawing.Point(531, 38);
            this.txt_mucGiamGia.Margin = new System.Windows.Forms.Padding(4);
            this.txt_mucGiamGia.Name = "txt_mucGiamGia";
            this.txt_mucGiamGia.Size = new System.Drawing.Size(132, 22);
            this.txt_mucGiamGia.TabIndex = 9;
            // 
            // txt_soLuong
            // 
            this.txt_soLuong.Location = new System.Drawing.Point(531, 86);
            this.txt_soLuong.Margin = new System.Windows.Forms.Padding(4);
            this.txt_soLuong.Name = "txt_soLuong";
            this.txt_soLuong.Size = new System.Drawing.Size(132, 22);
            this.txt_soLuong.TabIndex = 10;
            // 
            // button_them
            // 
            this.button_them.Location = new System.Drawing.Point(776, 28);
            this.button_them.Margin = new System.Windows.Forms.Padding(4);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(100, 28);
            this.button_them.TabIndex = 11;
            this.button_them.Text = "Thêm";
            this.button_them.UseVisualStyleBackColor = true;
            this.button_them.Click += new System.EventHandler(this.button_them_Click);
            // 
            // button_sua
            // 
            this.button_sua.Location = new System.Drawing.Point(776, 66);
            this.button_sua.Margin = new System.Windows.Forms.Padding(4);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(100, 28);
            this.button_sua.TabIndex = 12;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = true;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Location = new System.Drawing.Point(910, 28);
            this.button_xoa.Margin = new System.Windows.Forms.Padding(4);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(100, 28);
            this.button_xoa.TabIndex = 13;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_xuatExcel
            // 
            this.button_xuatExcel.Location = new System.Drawing.Point(910, 64);
            this.button_xuatExcel.Name = "button_xuatExcel";
            this.button_xuatExcel.Size = new System.Drawing.Size(100, 30);
            this.button_xuatExcel.TabIndex = 14;
            this.button_xuatExcel.Text = "Xuất Excel";
            this.button_xuatExcel.UseVisualStyleBackColor = true;
            this.button_xuatExcel.Click += new System.EventHandler(this.button_xuatExcel_Click);
            // 
            // frmChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 519);
            this.Controls.Add(this.button_xuatExcel);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_sua);
            this.Controls.Add(this.button_them);
            this.Controls.Add(this.txt_soLuong);
            this.Controls.Add(this.txt_mucGiamGia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_giaBan);
            this.Controls.Add(this.txt_maHang);
            this.Controls.Add(this.txt_soHoaDon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmChiTietDonHang";
            this.Text = "frmChiTietDatHang";
            this.Load += new System.EventHandler(this.frmChiTietDonHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_soHoaDon;
        private System.Windows.Forms.TextBox txt_maHang;
        private System.Windows.Forms.TextBox txt_giaBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_mucGiamGia;
        private System.Windows.Forms.TextBox txt_soLuong;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_xuatExcel;
    }
}