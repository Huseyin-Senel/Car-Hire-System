
namespace WindowsFormsApp1.Formlar
{
    partial class Ödeme_Guncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ödeme_Guncelle));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGunlukTeklifFiyatı = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbYasSınırı = new System.Windows.Forms.TextBox();
            this.tbSasiID = new System.Windows.Forms.TextBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.lblFiyat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.dtpBaslangic = new System.Windows.Forms.DateTimePicker();
            this.iptalBtn = new System.Windows.Forms.Button();
            this.kiralaBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.lblGunlukTeklifFiyatı);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbYasSınırı);
            this.panel1.Controls.Add(this.tbSasiID);
            this.panel1.Controls.Add(this.labelMessage);
            this.panel1.Controls.Add(this.lblFiyat);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpBitis);
            this.panel1.Controls.Add(this.dtpBaslangic);
            this.panel1.Controls.Add(this.iptalBtn);
            this.panel1.Controls.Add(this.kiralaBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 225);
            this.panel1.TabIndex = 12;
            // 
            // lblGunlukTeklifFiyatı
            // 
            this.lblGunlukTeklifFiyatı.BackColor = System.Drawing.SystemColors.Window;
            this.lblGunlukTeklifFiyatı.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGunlukTeklifFiyatı.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblGunlukTeklifFiyatı.ForeColor = System.Drawing.Color.Black;
            this.lblGunlukTeklifFiyatı.Location = new System.Drawing.Point(242, 137);
            this.lblGunlukTeklifFiyatı.Name = "lblGunlukTeklifFiyatı";
            this.lblGunlukTeklifFiyatı.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblGunlukTeklifFiyatı.Size = new System.Drawing.Size(125, 20);
            this.lblGunlukTeklifFiyatı.TabIndex = 62;
            this.lblGunlukTeklifFiyatı.Text = "0,00";
            this.lblGunlukTeklifFiyatı.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Window;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(366, 137);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.TabIndex = 61;
            this.label8.Text = "₺";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(239, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 14);
            this.label9.TabIndex = 60;
            this.label9.Text = "Günlük Teklif Fiyatı";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(239, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 14);
            this.label6.TabIndex = 59;
            this.label6.Text = "Aracı kullanma yaş sınırı";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(239, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 14);
            this.label3.TabIndex = 58;
            this.label3.Text = "Aracın şasi numarası";
            // 
            // tbYasSınırı
            // 
            this.tbYasSınırı.Location = new System.Drawing.Point(242, 100);
            this.tbYasSınırı.Name = "tbYasSınırı";
            this.tbYasSınırı.ReadOnly = true;
            this.tbYasSınırı.Size = new System.Drawing.Size(148, 20);
            this.tbYasSınırı.TabIndex = 57;
            // 
            // tbSasiID
            // 
            this.tbSasiID.Location = new System.Drawing.Point(242, 59);
            this.tbSasiID.Name = "tbSasiID";
            this.tbSasiID.ReadOnly = true;
            this.tbSasiID.Size = new System.Drawing.Size(148, 20);
            this.tbSasiID.TabIndex = 56;
            // 
            // labelMessage
            // 
            this.labelMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(0)))));
            this.labelMessage.Location = new System.Drawing.Point(31, 162);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(205, 19);
            this.labelMessage.TabIndex = 55;
            this.labelMessage.Text = "agdgdsgshhrjrjrdfsagsgsgsggdhssjdjdkkd";
            this.labelMessage.Visible = false;
            // 
            // lblFiyat
            // 
            this.lblFiyat.BackColor = System.Drawing.SystemColors.Window;
            this.lblFiyat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFiyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblFiyat.ForeColor = System.Drawing.Color.Black;
            this.lblFiyat.Location = new System.Drawing.Point(34, 131);
            this.lblFiyat.Name = "lblFiyat";
            this.lblFiyat.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblFiyat.Size = new System.Drawing.Size(125, 20);
            this.lblFiyat.TabIndex = 49;
            this.lblFiyat.Text = "0,00";
            this.lblFiyat.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(158, 131);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 44;
            this.label2.Text = "₺";
            // 
            // dtpBitis
            // 
            this.dtpBitis.Location = new System.Drawing.Point(34, 85);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(148, 20);
            this.dtpBitis.TabIndex = 43;
            this.dtpBitis.ValueChanged += new System.EventHandler(this.dtpBitis_ValueChanged);
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.Enabled = false;
            this.dtpBaslangic.Location = new System.Drawing.Point(34, 59);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(148, 20);
            this.dtpBaslangic.TabIndex = 42;
            this.dtpBaslangic.ValueChanged += new System.EventHandler(this.dtpBaslangic_ValueChanged);
            // 
            // iptalBtn
            // 
            this.iptalBtn.BackColor = System.Drawing.Color.Black;
            this.iptalBtn.FlatAppearance.BorderSize = 0;
            this.iptalBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.iptalBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.iptalBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iptalBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptalBtn.ForeColor = System.Drawing.Color.White;
            this.iptalBtn.Image = global::WindowsFormsApp1.Properties.Resources.cancel_20px;
            this.iptalBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iptalBtn.Location = new System.Drawing.Point(34, 184);
            this.iptalBtn.Name = "iptalBtn";
            this.iptalBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.iptalBtn.Size = new System.Drawing.Size(90, 30);
            this.iptalBtn.TabIndex = 40;
            this.iptalBtn.Text = "   İptal";
            this.iptalBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iptalBtn.UseVisualStyleBackColor = false;
            this.iptalBtn.Click += new System.EventHandler(this.iptalBtn_Click);
            // 
            // kiralaBtn
            // 
            this.kiralaBtn.BackColor = System.Drawing.Color.Black;
            this.kiralaBtn.FlatAppearance.BorderSize = 0;
            this.kiralaBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.kiralaBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.kiralaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kiralaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kiralaBtn.ForeColor = System.Drawing.Color.White;
            this.kiralaBtn.Image = global::WindowsFormsApp1.Properties.Resources.update_20px;
            this.kiralaBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kiralaBtn.Location = new System.Drawing.Point(242, 174);
            this.kiralaBtn.Name = "kiralaBtn";
            this.kiralaBtn.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.kiralaBtn.Size = new System.Drawing.Size(148, 40);
            this.kiralaBtn.TabIndex = 39;
            this.kiralaBtn.Text = "        Güncelle";
            this.kiralaBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kiralaBtn.UseVisualStyleBackColor = false;
            this.kiralaBtn.Click += new System.EventHandler(this.kiralaBtn_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ödenecek Ücret";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kiralama Bilgileri";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kiralama Süresi *";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.aracKayit;
            this.pictureBox1.Location = new System.Drawing.Point(428, -177);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 437);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Ödeme_Guncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 225);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(683, 264);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(683, 264);
            this.Name = "Ödeme_Guncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kirala";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpBitis;
        private System.Windows.Forms.DateTimePicker dtpBaslangic;
        private System.Windows.Forms.Button iptalBtn;
        private System.Windows.Forms.Button kiralaBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFiyat;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbYasSınırı;
        private System.Windows.Forms.TextBox tbSasiID;
        private System.Windows.Forms.Label lblGunlukTeklifFiyatı;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}