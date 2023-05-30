namespace Bot
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cmd1 = new Button();
            txtLog = new TextBox();
            txt1 = new TextBox();
            SuspendLayout();
            // 
            // cmd1
            // 
            cmd1.Location = new Point(662, 369);
            cmd1.Name = "cmd1";
            cmd1.Size = new Size(111, 55);
            cmd1.TabIndex = 0;
            cmd1.Text = "button1";
            cmd1.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(12, 21);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(776, 291);
            txtLog.TabIndex = 1;
            // 
            // txt1
            // 
            txt1.Location = new Point(12, 383);
            txt1.Name = "txt1";
            txt1.Size = new Size(520, 27);
            txt1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txt1);
            Controls.Add(txtLog);
            Controls.Add(cmd1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button cmd1;
        private TextBox txtLog;
        private TextBox txt1;
    }
}