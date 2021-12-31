
namespace WindowsFormsApp1.Formlar
{
    partial class Admin_Ekle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Ekle));
            this.kaydetBtn = new System.Windows.Forms.Button();
            this.iptalBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbKullanıcıAdı = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSifre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSifreOnay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kaydetBtn
            // 
            this.kaydetBtn.BackColor = System.Drawing.Color.Black;
            this.kaydetBtn.FlatAppearance.BorderSize = 0;
            this.kaydetBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.kaydetBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.kaydetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kaydetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kaydetBtn.ForeColor = System.Drawing.Color.White;
            this.kaydetBtn.Image = global::WindowsFormsApp1.Properties.Resources.save_20px;
            this.kaydetBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kaydetBtn.Location = new System.Drawing.Point(284, 179);
            this.kaydetBtn.Name = "kaydetBtn";
            this.kaydetBtn.Size = new System.Drawing.Size(90, 30);
            this.kaydetBtn.TabIndex = 41;
            this.kaydetBtn.Text = " Ekle";
            this.kaydetBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kaydetBtn.UseVisualStyleBackColor = false;
            this.kaydetBtn.Click += new System.EventHandler(this.kaydetBtn_Click);
            // 
            // iptalBtn
            // 
            this.iptalBtn.BackColor = System.Drawing.Color.Black;
            this.iptalBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.iptalBtn.FlatAppearance.BorderSize = 0;
            this.iptalBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.iptalBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.iptalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iptalBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptalBtn.ForeColor = System.Drawing.Color.White;
            this.iptalBtn.Image = global::WindowsFormsApp1.Properties.Resources.cancel_20px;
            this.iptalBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iptalBtn.Location = new System.Drawing.Point(27, 179);
            this.iptalBtn.Name = "iptalBtn";
            this.iptalBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.iptalBtn.Size = new System.Drawing.Size(90, 30);
            this.iptalBtn.TabIndex = 42;
            this.iptalBtn.Text = "   İptal";
            this.iptalBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iptalBtn.UseVisualStyleBackColor = false;
            this.iptalBtn.Click += new System.EventHandler(this.iptalBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.aracKayit;
            this.pictureBox1.Location = new System.Drawing.Point(404, -186);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 437);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 14);
            this.label2.TabIndex = 46;
            this.label2.Text = "E-Mail *";
            // 
            // tbMail
            // 
            this.tbMail.Location = new System.Drawing.Point(27, 124);
            this.tbMail.MaxLength = 30;
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(148, 20);
            this.tbMail.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 14);
            this.label1.TabIndex = 44;
            this.label1.Text = "Kullanıcı Adı*";
            // 
            // tbKullanıcıAdı
            // 
            this.tbKullanıcıAdı.Location = new System.Drawing.Point(27, 81);
            this.tbKullanıcıAdı.MaxLength = 17;
            this.tbKullanıcıAdı.Name = "tbKullanıcıAdı";
            this.tbKullanıcıAdı.Size = new System.Drawing.Size(148, 20);
            this.tbKullanıcıAdı.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(223, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 14);
            this.label3.TabIndex = 50;
            this.label3.Text = "Şifre *";
            // 
            // tbSifre
            // 
            this.tbSifre.Location = new System.Drawing.Point(226, 80);
            this.tbSifre.MaxLength = 30;
            this.tbSifre.Name = "tbSifre";
            this.tbSifre.PasswordChar = '*';
            this.tbSifre.Size = new System.Drawing.Size(148, 20);
            this.tbSifre.TabIndex = 51;
            this.tbSifre.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(223, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 14);
            this.label4.TabIndex = 52;
            this.label4.Text = "Şifre Tekrar *";
            // 
            // tbSifreOnay
            // 
            this.tbSifreOnay.Location = new System.Drawing.Point(226, 123);
            this.tbSifreOnay.MaxLength = 30;
            this.tbSifreOnay.Name = "tbSifreOnay";
            this.tbSifreOnay.PasswordChar = '*';
            this.tbSifreOnay.Size = new System.Drawing.Size(148, 20);
            this.tbSifreOnay.TabIndex = 53;
            this.tbSifreOnay.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 54;
            this.label5.Text = "Admin Bilgileri";
            // 
            // labelMessage
            // 
            this.labelMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(0)))));
            this.labelMessage.Location = new System.Drawing.Point(131, 169);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(148, 49);
            this.labelMessage.TabIndex = 55;
            this.labelMessage.Text = "agdgdsgshhrjrjrdfsagsgsgsggdhssjdjdkkd";
            this.labelMessage.Visible = false;
            // 
            // Admin_Ekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(642, 227);
            this.ControlBox = false;
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbSifreOnay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSifre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbKullanıcıAdı);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.kaydetBtn);
            this.Controls.Add(this.iptalBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(658, 266);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(658, 266);
            this.Name = "Admin_Ekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kaydetBtn;
        private System.Windows.Forms.Button iptalBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbKullanıcıAdı;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSifre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbSifreOnay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelMessage;
    }
}