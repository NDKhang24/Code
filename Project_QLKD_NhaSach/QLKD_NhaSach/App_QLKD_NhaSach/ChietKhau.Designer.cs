namespace App_QLKD_NhaSach
{
    partial class ChietKhau
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
            this.textBox_phantram = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1_xnChietKhau = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phần Trăm Chiết Khấu";
            // 
            // textBox_phantram
            // 
            this.textBox_phantram.Location = new System.Drawing.Point(91, 45);
            this.textBox_phantram.Name = "textBox_phantram";
            this.textBox_phantram.Size = new System.Drawing.Size(115, 22);
            this.textBox_phantram.TabIndex = 1;
            this.textBox_phantram.TextChanged += new System.EventHandler(this.textBox_phantram_TextChanged);
            this.textBox_phantram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_phantram_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(236, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // button1_xnChietKhau
            // 
            this.button1_xnChietKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_xnChietKhau.Location = new System.Drawing.Point(91, 87);
            this.button1_xnChietKhau.Name = "button1_xnChietKhau";
            this.button1_xnChietKhau.Size = new System.Drawing.Size(115, 33);
            this.button1_xnChietKhau.TabIndex = 3;
            this.button1_xnChietKhau.Text = "Xác Nhận";
            this.button1_xnChietKhau.UseVisualStyleBackColor = true;
            this.button1_xnChietKhau.Click += new System.EventHandler(this.button1_xnChietKhau_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "0 - 100";
            // 
            // ChietKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(289, 132);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1_xnChietKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_phantram);
            this.Controls.Add(this.label1);
            this.Name = "ChietKhau";
            this.Text = "Chiết Khấu";
            this.Load += new System.EventHandler(this.ChietKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_phantram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1_xnChietKhau;
        private System.Windows.Forms.Label label3;
    }
}