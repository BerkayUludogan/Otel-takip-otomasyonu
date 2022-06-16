namespace Otel_Takip
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.kull_adi = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.kull_adi);
            this.groupBox1.Controls.Add(this.sifre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 291);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkKhaki;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(100, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.DarkKhaki;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkBox1.Location = new System.Drawing.Point(359, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(123, 25);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Şifreyi Göster";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkKhaki;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button1.Location = new System.Drawing.Point(102, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Giriş";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkKhaki;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button2.Location = new System.Drawing.Point(195, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Şifremi Unuttum";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // kull_adi
            // 
            this.kull_adi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kull_adi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.kull_adi.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.kull_adi.Location = new System.Drawing.Point(208, 94);
            this.kull_adi.Name = "kull_adi";
            this.kull_adi.Size = new System.Drawing.Size(141, 29);
            this.kull_adi.TabIndex = 2;
            this.kull_adi.Text = "Kullanıcı Adı";
            this.kull_adi.Click += new System.EventHandler(this.sifre_Click);
            this.kull_adi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kull_adi_KeyPress);
            // 
            // sifre
            // 
            this.sifre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sifre.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.sifre.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.sifre.Location = new System.Drawing.Point(208, 132);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(141, 29);
            this.sifre.TabIndex = 4;
            this.sifre.Text = "Şifre";
            this.sifre.TextAlignChanged += new System.EventHandler(this.sifre_TextAlignChanged);
            this.sifre.Click += new System.EventHandler(this.sifre_Click);
            this.sifre.TextChanged += new System.EventHandler(this.sifre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkKhaki;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(87, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kullanıcı Şifresi :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::Otel_Takip.Properties.Resources.WhatsApp_Image_2019_05_13_at_20_35_09;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(549, 319);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(565, 358);
            this.MinimumSize = new System.Drawing.Size(565, 358);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Üye Girişi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox kull_adi;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Label label2;
    }
}

