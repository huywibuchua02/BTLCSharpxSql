namespace BTLCSharpxSql
{
    partial class frmLoaiHang
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_maloaihang = new System.Windows.Forms.TextBox();
            this.txt_tenloaihang = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_xuatExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã loại hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên loại hàng:";
            // 
            // txt_maloaihang
            // 
            this.txt_maloaihang.Location = new System.Drawing.Point(149, 43);
            this.txt_maloaihang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_maloaihang.Name = "txt_maloaihang";
            this.txt_maloaihang.Size = new System.Drawing.Size(139, 22);
            this.txt_maloaihang.TabIndex = 2;
            // 
            // txt_tenloaihang
            // 
            this.txt_tenloaihang.Location = new System.Drawing.Point(149, 103);
            this.txt_tenloaihang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_tenloaihang.Name = "txt_tenloaihang";
            this.txt_tenloaihang.Size = new System.Drawing.Size(139, 22);
            this.txt_tenloaihang.TabIndex = 3;
            // 
            // button_them
            // 
            this.button_them.Location = new System.Drawing.Point(430, 57);
            this.button_them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(133, 62);
            this.button_them.TabIndex = 4;
            this.button_them.Text = "Thêm";
            this.button_them.UseVisualStyleBackColor = true;
            this.button_them.Click += new System.EventHandler(this.button_them_Click);
            // 
            // button_sua
            // 
            this.button_sua.Location = new System.Drawing.Point(591, 57);
            this.button_sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(133, 62);
            this.button_sua.TabIndex = 5;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = true;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Location = new System.Drawing.Point(756, 57);
            this.button_xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(133, 62);
            this.button_xoa.TabIndex = 6;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 183);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 321);
            this.dataGridView1.TabIndex = 7;
            // 
            // button_xuatExcel
            // 
            this.button_xuatExcel.Location = new System.Drawing.Point(913, 57);
            this.button_xuatExcel.Name = "button_xuatExcel";
            this.button_xuatExcel.Size = new System.Drawing.Size(127, 62);
            this.button_xuatExcel.TabIndex = 8;
            this.button_xuatExcel.Text = "Xuất Excel";
            this.button_xuatExcel.UseVisualStyleBackColor = true;
            this.button_xuatExcel.Click += new System.EventHandler(this.button_xuatExcel_Click_1);
            // 
            // frmLoaiHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 519);
            this.Controls.Add(this.button_xuatExcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_sua);
            this.Controls.Add(this.button_them);
            this.Controls.Add(this.txt_tenloaihang);
            this.Controls.Add(this.txt_maloaihang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLoaiHang";
            this.Text = "Loại Hàng";
            this.Load += new System.EventHandler(this.frmLoaiHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_maloaihang;
        private System.Windows.Forms.TextBox txt_tenloaihang;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_xuatExcel;
    }
}