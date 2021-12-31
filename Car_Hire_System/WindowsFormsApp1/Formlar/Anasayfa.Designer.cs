namespace WindowsFormsApp1.Formlar
{
    partial class Anasayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Button cikisButon;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.araclarButon = new System.Windows.Forms.Button();
            this.AnaPanel = new System.Windows.Forms.Panel();
            this.üstPanel = new System.Windows.Forms.Panel();
            this.hesabımButon = new System.Windows.Forms.Button();
            this.anaLogo = new System.Windows.Forms.PictureBox();
            this.altPanel = new System.Windows.Forms.Panel();
            cikisButon = new System.Windows.Forms.Button();
            this.üstPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.anaLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cikisButon
            // 
            cikisButon.BackColor = System.Drawing.Color.Transparent;
            cikisButon.FlatAppearance.BorderSize = 0;
            cikisButon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            cikisButon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            cikisButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cikisButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            cikisButon.ForeColor = System.Drawing.Color.White;
            cikisButon.Location = new System.Drawing.Point(1113, 12);
            cikisButon.Name = "cikisButon";
            cikisButon.Size = new System.Drawing.Size(75, 52);
            cikisButon.TabIndex = 8;
            cikisButon.Text = "Çıkış";
            cikisButon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            cikisButon.UseVisualStyleBackColor = false;
            cikisButon.Click += new System.EventHandler(this.cikisButon_Click);
            // 
            // araclarButon
            // 
            this.araclarButon.BackColor = System.Drawing.Color.Transparent;
            this.araclarButon.FlatAppearance.BorderSize = 0;
            this.araclarButon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.araclarButon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.araclarButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.araclarButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.araclarButon.ForeColor = System.Drawing.Color.White;
            this.araclarButon.Location = new System.Drawing.Point(119, 12);
            this.araclarButon.Name = "araclarButon";
            this.araclarButon.Size = new System.Drawing.Size(92, 49);
            this.araclarButon.TabIndex = 3;
            this.araclarButon.Text = "Araçlar";
            this.araclarButon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.araclarButon.UseVisualStyleBackColor = false;
            this.araclarButon.Click += new System.EventHandler(this.araclarButon_Click);
            // 
            // AnaPanel
            // 
            this.AnaPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.AnaPanel.Location = new System.Drawing.Point(0, 60);
            this.AnaPanel.Name = "AnaPanel";
            this.AnaPanel.Size = new System.Drawing.Size(1200, 570);
            this.AnaPanel.TabIndex = 18;
            // 
            // üstPanel
            // 
            this.üstPanel.BackColor = System.Drawing.Color.Black;
            this.üstPanel.Controls.Add(this.hesabımButon);
            this.üstPanel.Controls.Add(cikisButon);
            this.üstPanel.Controls.Add(this.anaLogo);
            this.üstPanel.Controls.Add(this.araclarButon);
            this.üstPanel.Location = new System.Drawing.Point(0, 0);
            this.üstPanel.Name = "üstPanel";
            this.üstPanel.Size = new System.Drawing.Size(1200, 60);
            this.üstPanel.TabIndex = 17;
            // 
            // hesabımButon
            // 
            this.hesabımButon.BackColor = System.Drawing.Color.Transparent;
            this.hesabımButon.FlatAppearance.BorderSize = 0;
            this.hesabımButon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.hesabımButon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.hesabımButon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hesabımButon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.hesabımButon.ForeColor = System.Drawing.Color.White;
            this.hesabımButon.Location = new System.Drawing.Point(208, 12);
            this.hesabımButon.Name = "hesabımButon";
            this.hesabımButon.Size = new System.Drawing.Size(107, 49);
            this.hesabımButon.TabIndex = 10;
            this.hesabımButon.Text = "Hesabım";
            this.hesabımButon.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.hesabımButon.UseVisualStyleBackColor = false;
            this.hesabımButon.Click += new System.EventHandler(this.hesabımButon_Click);
            // 
            // anaLogo
            // 
            this.anaLogo.Image = global::WindowsFormsApp1.Properties.Resources.unnamed1;
            this.anaLogo.Location = new System.Drawing.Point(3, 6);
            this.anaLogo.Name = "anaLogo";
            this.anaLogo.Size = new System.Drawing.Size(96, 52);
            this.anaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.anaLogo.TabIndex = 9;
            this.anaLogo.TabStop = false;
            // 
            // altPanel
            // 
            this.altPanel.BackColor = System.Drawing.Color.Black;
            this.altPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.altPanel.Location = new System.Drawing.Point(0, 631);
            this.altPanel.Name = "altPanel";
            this.altPanel.Size = new System.Drawing.Size(1200, 50);
            this.altPanel.TabIndex = 19;
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1200, 681);
            this.Controls.Add(this.altPanel);
            this.Controls.Add(this.üstPanel);
            this.Controls.Add(this.AnaPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1216, 720);
            this.MinimumSize = new System.Drawing.Size(1216, 720);
            this.Name = "Anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Kiralama Sistemi";
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            this.üstPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.anaLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button araclarButon;
        private System.Windows.Forms.Panel AnaPanel;
        private System.Windows.Forms.PictureBox anaLogo;
        private System.Windows.Forms.Panel üstPanel;
        private System.Windows.Forms.Button hesabımButon;
        private System.Windows.Forms.Panel altPanel;
    }
}

