﻿namespace BTLCSharpxSql
{
    partial class frmMatHang
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_mahang = new System.Windows.Forms.TextBox();
            this.txt_tenhang = new System.Windows.Forms.TextBox();
            this.txt_sl = new System.Windows.Forms.TextBox();
            this.txt_gia = new System.Windows.Forms.TextBox();
            this.txt_mloaihang = new System.Windows.Forms.TextBox();
            this.txt_mcongty = new System.Windows.Forms.TextBox();
            this.txt_dvt = new System.Windows.Forms.TextBox();
            this.button_them = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hàng:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã loại hàng:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 58);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mã công ty:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Đơn vị tính:";
            // 
            // txt_mahang
            // 
            this.txt_mahang.Location = new System.Drawing.Point(106, 23);
            this.txt_mahang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_mahang.Name = "txt_mahang";
            this.txt_mahang.Size = new System.Drawing.Size(76, 20);
            this.txt_mahang.TabIndex = 7;
            // 
            // txt_tenhang
            // 
            this.txt_tenhang.Location = new System.Drawing.Point(106, 51);
            this.txt_tenhang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_tenhang.Name = "txt_tenhang";
            this.txt_tenhang.Size = new System.Drawing.Size(76, 20);
            this.txt_tenhang.TabIndex = 8;
            // 
            // txt_sl
            // 
            this.txt_sl.Location = new System.Drawing.Point(106, 82);
            this.txt_sl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_sl.Name = "txt_sl";
            this.txt_sl.Size = new System.Drawing.Size(76, 20);
            this.txt_sl.TabIndex = 9;
            this.txt_sl.TextChanged += new System.EventHandler(this.txt_sl_TextChanged);
            // 
            // txt_gia
            // 
            this.txt_gia.Location = new System.Drawing.Point(106, 121);
            this.txt_gia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_gia.Name = "txt_gia";
            this.txt_gia.Size = new System.Drawing.Size(76, 20);
            this.txt_gia.TabIndex = 10;
            // 
            // txt_mloaihang
            // 
            this.txt_mloaihang.Location = new System.Drawing.Point(362, 23);
            this.txt_mloaihang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_mloaihang.Name = "txt_mloaihang";
            this.txt_mloaihang.Size = new System.Drawing.Size(76, 20);
            this.txt_mloaihang.TabIndex = 11;
            // 
            // txt_mcongty
            // 
            this.txt_mcongty.Location = new System.Drawing.Point(362, 58);
            this.txt_mcongty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_mcongty.Name = "txt_mcongty";
            this.txt_mcongty.Size = new System.Drawing.Size(76, 20);
            this.txt_mcongty.TabIndex = 12;
            // 
            // txt_dvt
            // 
            this.txt_dvt.Location = new System.Drawing.Point(362, 96);
            this.txt_dvt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_dvt.Name = "txt_dvt";
            this.txt_dvt.Size = new System.Drawing.Size(76, 20);
            this.txt_dvt.TabIndex = 13;
            // 
            // button_them
            // 
            this.button_them.Location = new System.Drawing.Point(551, 23);
            this.button_them.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_them.Name = "button_them";
            this.button_them.Size = new System.Drawing.Size(56, 33);
            this.button_them.TabIndex = 14;
            this.button_them.Text = "Thêm";
            this.button_them.UseVisualStyleBackColor = true;
            // 
            // button_sua
            // 
            this.button_sua.Location = new System.Drawing.Point(551, 71);
            this.button_sua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(56, 31);
            this.button_sua.TabIndex = 15;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = true;
            // 
            // button_xoa
            // 
            this.button_xoa.Location = new System.Drawing.Point(551, 115);
            this.button_xoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(56, 31);
            this.button_xoa.TabIndex = 16;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 167);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(852, 398);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // frmMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 576);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_sua);
            this.Controls.Add(this.button_them);
            this.Controls.Add(this.txt_dvt);
            this.Controls.Add(this.txt_mcongty);
            this.Controls.Add(this.txt_mloaihang);
            this.Controls.Add(this.txt_gia);
            this.Controls.Add(this.txt_sl);
            this.Controls.Add(this.txt_tenhang);
            this.Controls.Add(this.txt_mahang);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMatHang";
            this.Text = "frmMatHang";
            this.Load += new System.EventHandler(this.frmMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_mahang;
        private System.Windows.Forms.TextBox txt_tenhang;
        private System.Windows.Forms.TextBox txt_sl;
        private System.Windows.Forms.TextBox txt_gia;
        private System.Windows.Forms.TextBox txt_mloaihang;
        private System.Windows.Forms.TextBox txt_mcongty;
        private System.Windows.Forms.TextBox txt_dvt;
        private System.Windows.Forms.Button button_them;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}