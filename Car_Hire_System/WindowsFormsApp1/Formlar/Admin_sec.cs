using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formlar
{
    public partial class Admin_sec : Form
    {
        Objeler.Satıcı s1 = new Objeler.Satıcı();
        Objeler.Müşteri m1 = new Objeler.Müşteri();
        Objeler.Admin ad1 = new Objeler.Admin();

        Objeler.Araç a1 = new Objeler.Araç();
        Objeler.Ödeme o1 = new Objeler.Ödeme();
        Objeler.Kiralama k1 = new Objeler.Kiralama();

        int secenek; //araç ekle=0, ödeme ekle=1, kiralama ekle=2
        int dgvsecenek; //araç=0 ödeme=1 kiralama=2 satıcı=3 müşteri=4
        public Admin_sec(int secenek2)
        {
            InitializeComponent();

            secenek = secenek2;

            if(secenek == 0)
            {
                dgvsecenek = 3;
            }
            else if(secenek == 1)
            {
                dgvsecenek = 4;
            }
            else if(secenek == 2)
            {
                dgvsecenek = 0;
            }
            DGVyeCagır(dgvsecenek);
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSec_Click(object sender, EventArgs e)
        {
            try
            {            
                if (secenek == 0)
                {
                    if (dgvHepsi.Rows.Count > 0)
                    {
                        if(dgvHepsi.SelectedRows[0].Cells["TCkimlik"].Value != null)
                        {
                            string TCkimlik = dgvHepsi.SelectedRows[0].Cells["TCkimlik"].Value.ToString();

                            Formlar.Arac_Kayit form = new Formlar.Arac_Kayit(s1.SatıcıyıTCyeGoreCagir(TCkimlik), ad1);
                            form.ShowDialog();
                            this.Close();
                        }                       
                        else
                        {
                            MessageBox.Show("Lütfen bir satıcı seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir satıcı seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                    }
                }
                else if (secenek == 1)
                {
                    if(m1.MusteriID == 0)
                    {
                        if (dgvHepsi.Rows.Count > 0)
                        {
                            int MüşteriID = int.Parse(dgvHepsi.Rows[dgvHepsi.CurrentCell.RowIndex].Cells["MüşteriID"].Value.ToString());
                            if (MüşteriID != 0)
                            {
                                m1 = m1.MusteriyiIDyeGoreCagir(MüşteriID);
                                DGVyeCagır(2);
                            }
                            else
                            {
                                MessageBox.Show("Lütfen bir müşteri seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen bir müşteri seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                        }
                        
                    }                    
                    else if(k1.KiralamaID == 0)
                    {
                        if (dgvHepsi.Rows.Count > 0)
                        {
                            int KiralamaID = int.Parse(dgvHepsi.Rows[dgvHepsi.CurrentCell.RowIndex].Cells["KiralamaID"].Value.ToString());
                            if (KiralamaID != 0)
                            {
                                k1 = k1.KiralamayıIDyeGoreCagir(KiralamaID);
                            }
                            else
                            {
                                MessageBox.Show("Lütfen bir kiralama seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen bir kiralama seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        Formlar.Ödeme form = new Formlar.Ödeme(k1,m1,ad1);
                        form.ShowDialog();
                        this.Close();
                    }
                   
                }
                else if (secenek == 2)
                {
                    if (dgvHepsi.Rows.Count > 0)
                    {
                        if (dgvHepsi.SelectedRows[0].Cells["ŞasiID"].Value != null)
                        {
                            string sasiID = dgvHepsi.Rows[dgvHepsi.CurrentCell.RowIndex].Cells["ŞasiID"].Value.ToString();

                            Formlar.Kiralama form = new Formlar.Kiralama(a1.AracıŞasiIDyeGoreCagir(sasiID), ad1);
                            form.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Lütfen bir araç seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir araç seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show("Liste açılırken bir hata oluştu \n" + ex.Message, "Sitem Mesajı", MessageBoxButtons.OK);
            }
            
        }


        private void DGVyeCagır(int dgvsec)
        {
            try
            {
                if (dgvsec == 0)
                {
                    dgvHepsi.DataSource = a1.ButunAraçlarıCagir();
                    label2.Text = "Araç Seçin";
                }
                else if (dgvsec == 1)
                {
                    dgvHepsi.DataSource = o1.ButunOdemeleriCagir();
                    label2.Text = "Ödeme Seçin";
                }
                else if (dgvsec == 2)
                {
                    dgvHepsi.DataSource = k1.ButunKiralamalarıCagir();
                    label2.Text = "Kiralama Seçin";
                }
                else if (dgvsec == 3)
                {
                    dgvHepsi.DataSource = s1.ButunSatıcılarıCagir();
                    label2.Text = "Satıcı Seçin";
                }
                else if (dgvsec == 4)
                {
                    dgvHepsi.DataSource = m1.ButunMusterileriCagir();
                    label2.Text = "Müşteri Seçin";
                }
                //--------------------------------------------------------------------------
                if (dgvHepsi.Rows.Count < 2)
                {
                    dgvHepsi.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liste çağrılırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }     
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            DGVyeCagır(dgvsecenek);
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Liste", dgvHepsi);
        }
        private void btnExcel1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvHepsi, "Liste");
        }
    }
}
