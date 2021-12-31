
namespace WindowsFormsApp1.Formlar
{
    partial class Araç_Seçin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Araç_Seçin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSec = new System.Windows.Forms.Button();
            this.btnİptal = new System.Windows.Forms.Button();
            this.btnRefresh1 = new System.Windows.Forms.Button();
            this.btnPrint1 = new System.Windows.Forms.Button();
            this.btnExcel1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvAraçlar = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAraçlar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSec);
            this.panel1.Controls.Add(this.btnİptal);
            this.panel1.Controls.Add(this.btnRefresh1);
            this.panel1.Controls.Add(this.btnPrint1);
            this.panel1.Controls.Add(this.btnExcel1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvAraçlar);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 561);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(507, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "(Seçiniz)";
            // 
            // btnSec
            // 
            this.btnSec.BackColor = System.Drawing.Color.Black;
            this.btnSec.FlatAppearance.BorderSize = 0;
            this.btnSec.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnSec.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnSec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSec.ForeColor = System.Drawing.Color.White;
            this.btnSec.Image = global::WindowsFormsApp1.Properties.Resources.checkmark_20px;
            this.btnSec.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSec.Location = new System.Drawing.Point(744, 522);
            this.btnSec.Name = "btnSec";
            this.btnSec.Size = new System.Drawing.Size(85, 30);
            this.btnSec.TabIndex = 21;
            this.btnSec.Text = "Seç";
            this.btnSec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSec.UseVisualStyleBackColor = false;
            this.btnSec.Click += new System.EventHandler(this.btnSec_Click);
            // 
            // btnİptal
            // 
            this.btnİptal.BackColor = System.Drawing.Color.Black;
            this.btnİptal.FlatAppearance.BorderSize = 0;
            this.btnİptal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnİptal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnİptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnİptal.ForeColor = System.Drawing.Color.White;
            this.btnİptal.Image = global::WindowsFormsApp1.Properties.Resources.cancel_20px;
            this.btnİptal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnİptal.Location = new System.Drawing.Point(10, 522);
            this.btnİptal.Name = "btnİptal";
            this.btnİptal.Size = new System.Drawing.Size(85, 30);
            this.btnİptal.TabIndex = 20;
            this.btnİptal.Text = "İptal";
            this.btnİptal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnİptal.UseVisualStyleBackColor = false;
            this.btnİptal.Click += new System.EventHandler(this.btnİptal_Click);
            // 
            // btnRefresh1
            // 
            this.btnRefresh1.BackColor = System.Drawing.Color.Black;
            this.btnRefresh1.FlatAppearance.BorderSize = 0;
            this.btnRefresh1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnRefresh1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnRefresh1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh1.ForeColor = System.Drawing.Color.White;
            this.btnRefresh1.Image = global::WindowsFormsApp1.Properties.Resources.refresh_20px;
            this.btnRefresh1.Location = new System.Drawing.Point(70, 17);
            this.btnRefresh1.Name = "btnRefresh1";
            this.btnRefresh1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnRefresh1.Size = new System.Drawing.Size(24, 24);
            this.btnRefresh1.TabIndex = 19;
            this.btnRefresh1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh1.UseVisualStyleBackColor = false;
            this.btnRefresh1.Click += new System.EventHandler(this.btnRefresh1_Click);
            // 
            // btnPrint1
            // 
            this.btnPrint1.BackColor = System.Drawing.Color.Black;
            this.btnPrint1.FlatAppearance.BorderSize = 0;
            this.btnPrint1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnPrint1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnPrint1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint1.ForeColor = System.Drawing.Color.White;
            this.btnPrint1.Image = global::WindowsFormsApp1.Properties.Resources.print_22px;
            this.btnPrint1.Location = new System.Drawing.Point(40, 17);
            this.btnPrint1.Name = "btnPrint1";
            this.btnPrint1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.btnPrint1.Size = new System.Drawing.Size(24, 24);
            this.btnPrint1.TabIndex = 18;
            this.btnPrint1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint1.UseVisualStyleBackColor = false;
            this.btnPrint1.Click += new System.EventHandler(this.btnPrint1_Click);
            // 
            // btnExcel1
            // 
            this.btnExcel1.BackColor = System.Drawing.Color.Black;
            this.btnExcel1.FlatAppearance.BorderSize = 0;
            this.btnExcel1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.btnExcel1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnExcel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel1.ForeColor = System.Drawing.Color.White;
            this.btnExcel1.Image = global::WindowsFormsApp1.Properties.Resources.microsoft_excel_2019_22px;
            this.btnExcel1.Location = new System.Drawing.Point(10, 17);
            this.btnExcel1.Name = "btnExcel1";
            this.btnExcel1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.btnExcel1.Size = new System.Drawing.Size(24, 24);
            this.btnExcel1.TabIndex = 17;
            this.btnExcel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel1.UseVisualStyleBackColor = false;
            this.btnExcel1.Click += new System.EventHandler(this.btnExcel1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(321, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kiralanabilecek Araçlar";
            // 
            // dgvAraçlar
            // 
            this.dgvAraçlar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAraçlar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAraçlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAraçlar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvAraçlar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dgvAraçlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAraçlar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAraçlar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAraçlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAraçlar.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAraçlar.EnableHeadersVisualStyles = false;
            this.dgvAraçlar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.dgvAraçlar.Location = new System.Drawing.Point(10, 46);
            this.dgvAraçlar.MultiSelect = false;
            this.dgvAraçlar.Name = "dgvAraçlar";
            this.dgvAraçlar.ReadOnly = true;
            this.dgvAraçlar.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAraçlar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAraçlar.RowHeadersWidth = 51;
            this.dgvAraçlar.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAraçlar.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAraçlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAraçlar.Size = new System.Drawing.Size(820, 470);
            this.dgvAraçlar.TabIndex = 15;
            // 
            // Araç_Seçin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(841, 561);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(857, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(857, 600);
            this.Name = "Araç_Seçin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Araç Seçin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAraçlar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefresh1;
        private System.Windows.Forms.Button btnPrint1;
        private System.Windows.Forms.Button btnExcel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvAraçlar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSec;
        private System.Windows.Forms.Button btnİptal;
    }
}