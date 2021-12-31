
namespace WindowsFormsApp1.Formlar
{
    partial class musteri_satıcı
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(musteri_satıcı));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Satıcı_Kayit = new System.Windows.Forms.Button();
            this.Musteri_Kayit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Satıcı_Kayit);
            this.panel1.Controls.Add(this.Musteri_Kayit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.MaximumSize = new System.Drawing.Size(325, 170);
            this.panel1.MinimumSize = new System.Drawing.Size(325, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 170);
            this.panel1.TabIndex = 45;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::WindowsFormsApp1.Properties.Resources.cancel_20px;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(12, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 41;
            this.button1.Text = "  İptal";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(40, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nasıl kayıt olmak istiyorsunuz?";
            // 
            // Satıcı_Kayit
            // 
            this.Satıcı_Kayit.BackColor = System.Drawing.Color.Black;
            this.Satıcı_Kayit.FlatAppearance.BorderSize = 0;
            this.Satıcı_Kayit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Satıcı_Kayit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Satıcı_Kayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Satıcı_Kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Satıcı_Kayit.ForeColor = System.Drawing.Color.White;
            this.Satıcı_Kayit.Image = global::WindowsFormsApp1.Properties.Resources.next_page_20px;
            this.Satıcı_Kayit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Satıcı_Kayit.Location = new System.Drawing.Point(129, 75);
            this.Satıcı_Kayit.Name = "Satıcı_Kayit";
            this.Satıcı_Kayit.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.Satıcı_Kayit.Size = new System.Drawing.Size(183, 30);
            this.Satıcı_Kayit.TabIndex = 40;
            this.Satıcı_Kayit.Text = "Satıcı olarak kayıt ol";
            this.Satıcı_Kayit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Satıcı_Kayit.UseVisualStyleBackColor = false;
            this.Satıcı_Kayit.Click += new System.EventHandler(this.Satıcı_Kayit_Click);
            // 
            // Musteri_Kayit
            // 
            this.Musteri_Kayit.BackColor = System.Drawing.Color.Black;
            this.Musteri_Kayit.FlatAppearance.BorderSize = 0;
            this.Musteri_Kayit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Musteri_Kayit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.Musteri_Kayit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Musteri_Kayit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Musteri_Kayit.ForeColor = System.Drawing.Color.White;
            this.Musteri_Kayit.Image = global::WindowsFormsApp1.Properties.Resources.next_page_20px;
            this.Musteri_Kayit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Musteri_Kayit.Location = new System.Drawing.Point(129, 119);
            this.Musteri_Kayit.Name = "Musteri_Kayit";
            this.Musteri_Kayit.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.Musteri_Kayit.Size = new System.Drawing.Size(183, 30);
            this.Musteri_Kayit.TabIndex = 40;
            this.Musteri_Kayit.Text = "Müşteri olarak kayıt ol";
            this.Musteri_Kayit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Musteri_Kayit.UseVisualStyleBackColor = false;
            this.Musteri_Kayit.Click += new System.EventHandler(this.Musteri_Kayit_Click);
            // 
            // musteri_satıcı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(324, 161);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(340, 200);
            this.MinimumSize = new System.Drawing.Size(340, 200);
            this.Name = "musteri_satıcı";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kayıt Ol";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Satıcı_Kayit;
        private System.Windows.Forms.Button Musteri_Kayit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}