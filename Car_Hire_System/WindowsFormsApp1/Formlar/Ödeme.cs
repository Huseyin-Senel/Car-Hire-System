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
    public partial class Ödeme : Form
    {
        Objeler.Kiralama k1 = new Objeler.Kiralama();
        Objeler.Müşteri m1 = new Objeler.Müşteri();
        Objeler.Admin ad1 = new Objeler.Admin();
        public Ödeme(Objeler.Kiralama k2, Objeler.Müşteri m2, Objeler.Admin ad2 = null)
        {
            InitializeComponent();
            k1 = k2;
            m1 = m2;
            ad1 = ad2;
            
            dtpBaslangic.MinDate = DateTime.Parse(k1.TeklifBaslangicTarihi);
            dtpBaslangic.MaxDate = DateTime.Parse(k1.TeklifBitisTarihi).AddDays(-1);
            dtpBitis.MinDate = DateTime.Parse(k1.TeklifBaslangicTarihi).AddDays(1);
            dtpBitis.MaxDate = DateTime.Parse(k1.TeklifBitisTarihi);
            lblFiyat.Text = (k1.GunlukTeklifFiyati * (dtpBitis.Value.Date - dtpBaslangic.Value.Date).Days).ToString();
            tbYasSınırı.Text = k1.YasSınırı.ToString();
            tbSasiID.Text = k1.SasiID.ToString();
        }


        private void kiralaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpBaslangic.Value > dtpBitis.Value)
                {
                    labelMessage.Text = "Teklif bitiş tarihi başlangıç tarihinden önce olamaz.*";
                    labelMessage.Visible = true;
                    dtpBitis.Focus();
                }
                else if(m1.Yası < k1.YasSınırı)
                {
                    labelMessage.Text = "Aracı kiralamak için yaşınız uygun değil.*";
                    labelMessage.Visible = true;
                    dtpBitis.Focus();
                }
                else
                {
                    Objeler.Ödeme o1 = new Objeler.Ödeme();
                    o1.BaslangicTarihi = dtpBaslangic.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    o1.BitisTarihi = dtpBitis.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    o1.MusteriID = m1.MusteriID;
                    o1.KiralamaID = k1.KiralamaID;
                    o1.KiralamaDurumu = "Devam Ediyor";


                    if(ad1 != null)
                    {
                        if(ad1.AdminOdemeEkle(o1, ad1))
                        {
                            MessageBox.Show("Kiralama başarıyla yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Kiralama yapılamadı.");
                        }
                        
                    }
                    else
                    {
                        if(o1.OdemeEkle(o1)>0)
                        {
                            MessageBox.Show("Kiralama başarıyla yapıldı.", "Sistem Mesajı", MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Kiralama yapılamadı.");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
                labelMessage.Visible = true;
            }
        }
        private void iptalBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpBaslangic_ValueChanged(object sender, EventArgs e)
        {
            dtpBitis.MinDate = dtpBaslangic.Value.Date.AddDays(1);       
            lblFiyat.Text = (k1.GunlukTeklifFiyati * (dtpBitis.Value.Date - dtpBaslangic.Value.Date).Days).ToString();
        }
        private void dtpBitis_ValueChanged(object sender, EventArgs e)
        {
            lblFiyat.Text = (k1.GunlukTeklifFiyati * (dtpBitis.Value.Date - dtpBaslangic.Value.Date).Days).ToString();
        }

    }
}
