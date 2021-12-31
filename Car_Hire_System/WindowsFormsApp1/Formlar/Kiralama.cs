using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formlar
{
    public partial class Kiralama : Form
    {
        Objeler.Araç ara1 = new Objeler.Araç();
        Objeler.Admin ad1 = new Objeler.Admin();
        public Kiralama(Objeler.Araç ara2, Objeler.Admin ad2 = null)
        {
            InitializeComponent();
            ara1 = ara2;
            ad1 = ad2;

            dtpBaslangic.MinDate = DateTime.Now.Date;
            dtpBitis.MinDate = DateTime.Now.Date.AddDays(1);
            sasiID.Text = ara1.SasiID;
        }

        private void kaydetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(dtpBaslangic.Value>dtpBitis.Value)
                {
                    labelMessage.Text = "Teklif bitiş tarihi başlangıç tarihinden önce olamaz.*";
                    labelMessage.Visible = true;
                    dtpBitis.Focus();
                }
                else if(string.IsNullOrEmpty(tbFiyat.Text.Trim()))
                {
                    labelMessage.Text = "Günlük teklif fiyatı 0 ya da boş olamaz.*";
                    labelMessage.Visible = true;
                    tbFiyat.Focus();
                }
                else if(float.Parse(tbFiyat.Text) <= 0)
                {
                    labelMessage.Text = "Günlük teklif fiyatı 0 ya da boş olamaz.*";
                    labelMessage.Visible = true;
                    tbFiyat.Focus();
                }
                else 
                {
                    Objeler.Kiralama k1 = new Objeler.Kiralama();
                    k1.SasiID = ara1.SasiID;
                    k1.TeklifBaslangicTarihi = dtpBaslangic.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    k1.TeklifBitisTarihi = dtpBitis.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    k1.GunlukTeklifFiyati = float.Parse(tbFiyat.Text.Trim());
                    k1.YasSınırı = (int)nudYasSınırı.Value;



                    if (ad1 != null)
                    {
                        if (ad1.AdminKiralamaEkle(k1, ad1))
                        {                        
                            this.Close();
                            MessageBox.Show("Kiralama başarıyla eklendi.", "System message", MessageBoxButtons.OK);
                        }
                        else
                        {
                            throw new Exception("Hata kiralama eklenemedi.");
                        }
                    }
                    else if(k1.KiralamaEkle(k1) > 0)
                    {
                        MessageBox.Show("Kiralama başarıyla eklendi." , "Sistem Mesajı", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Hata kiralama eklenemedi.");
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
        }
        private void tbFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.FloatYaz(sender, e, tbFiyat);
        }
    }
}
