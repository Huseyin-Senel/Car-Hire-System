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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            try
            {
                OdemeleriKontrolEt();
                KiralamalarıKontrolEt();
            }
            catch (Exception ex)
            {
                bilgiLabel.Text = ex.Message;
                bilgiLabel.Visible = true;
            }
            
        }

        private void OdemeleriKontrolEt()
        {
            try
            {
                Objeler.Ödeme o1 = new Objeler.Ödeme();
                DataTable dt = o1.ButunOdemeleriCagir();
                if (dt.Rows.Count > 0)
                {                   
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (DateTime.Parse(dt.Rows[i]["BitişTarihi"].ToString()) < DateTime.Now 
                            && dt.Rows[i]["KiralamaDurumu"].ToString() == "Devam Ediyor")
                        {
                            o1 = o1.OdemeyiIDyeGoreCagir(int.Parse(dt.Rows[i][0].ToString()));
                            o1.OdemeTamamla(o1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ödeme kontrol hatası" + ex.Message);
            }
        }
        private void KiralamalarıKontrolEt()
        {
            try
            {
                Objeler.Kiralama k1 = new Objeler.Kiralama();
                DataTable dt1 = k1.ButunKiralamalarıCagir();

                Objeler.Ödeme o1 = new Objeler.Ödeme();
                DataRow row;

                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    if (o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt1.Rows[i]["KiralamaID"].ToString())) != null)
                    {
                        o1 = o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt1.Rows[i]["KiralamaID"].ToString()));
                        row = dt1.Rows[i];
                        row.Delete();
                    }
                }
                dt1.AcceptChanges();  //Ödemesi olmayan kiralamalar

                int a = dt1.Rows.Count;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    k1.KiralamaID = int.Parse(dt1.Rows[i]["KiralamaID"].ToString());
                    k1.YasSınırı = int.Parse(dt1.Rows[i]["YaşSınırı"].ToString());
                    if (dt1.Rows[0]["AdminID"].ToString() == "") { k1.AdminID = 0; }
                    else { k1.AdminID = int.Parse(dt1.Rows[0]["AdminID"].ToString()); }
                    if (DateTime.Parse(dt1.Rows[i]["TeklifBaslangıçTarihi"].ToString()) <= DateTime.Now.Date)
                    {
                        k1.TeklifBaslangicTarihi = DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        k1.TeklifBaslangicTarihi = DateTime.Parse(dt1.Rows[i]["TeklifBaslangıçTarihi"].ToString()).Date.ToString("yyyy-MM-dd HH:mm:ss");
                    }                   
                    k1.TeklifBitisTarihi = DateTime.Parse(dt1.Rows[i]["TeklifBitişTarihi"].ToString()).Date.ToString("yyyy-MM-dd HH:mm:ss");
                    k1.GunlukTeklifFiyati = float.Parse(dt1.Rows[i]["GünlükTeklifFiyatı"].ToString());
                    k1.SasiID = dt1.Rows[i]["ŞasiID"].ToString();
                    k1.KiralamaGüncelleme(k1);

                    if(DateTime.Parse(k1.TeklifBaslangicTarihi) >= DateTime.Parse(k1.TeklifBitisTarihi))
                    {
                        k1.KiralamaSil(k1.KiralamaID);
                    }                 
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Kiralama kontrol hatası" + ex.Message);
            }
        }

        private void Giris_Buton_Click(object sender, EventArgs e)
        {
            try
            {
                bilgiLabel.Visible = false;
                if (String.IsNullOrEmpty(textBox7.Text.Trim()))
                {
                    bilgiLabel.Text = "E-mail adresi boş olamaz.";
                    bilgiLabel.Visible = true;
                    textBox7.Focus();
                }
                else if (!textBox7.Text.Contains('@'))
                {
                    bilgiLabel.Text = "Geçerli bir E-mail adresi giriniz.";
                    bilgiLabel.Visible = true;
                    textBox7.Focus();
                }
                else if (String.IsNullOrEmpty(textBox6.Text.Trim()))
                {
                    bilgiLabel.Text = "Şifre boş olamaz.";
                    bilgiLabel.Visible = true;
                    textBox6.Focus();
                }
                else
                {
                    Objeler.Adres a2 = new Objeler.Adres();
                    Objeler.Müşteri m2 = new Objeler.Müşteri();
                    Objeler.Satıcı s2 = new Objeler.Satıcı();
                    Objeler.Admin ad1 = new Objeler.Admin();
                    m2 = m2.MusteriLogin(textBox7.Text.Trim(), textBox6.Text.Trim());
                    s2 = s2.SatıcıLogin(textBox7.Text.Trim(), textBox6.Text.Trim());
                    ad1 = ad1.AdminLogin(textBox7.Text.Trim(), textBox6.Text.Trim());

                    if (m2 != null && s2 != null) 
                    {
                        bilgiLabel.Visible = false;
                        Formlar.musteri_satıcı_login form = new Formlar.musteri_satıcı_login(this, m2, s2);
                        form.ShowDialog();
                    }
                    else if (m2 != null || s2 != null)
                    {
                        bilgiLabel.Visible = false;
                        Formlar.Anasayfa form = new Formlar.Anasayfa(m2,s2);
                        form.Show();
                        this.Hide();
                    }
                    else if(ad1 != null)
                    {
                        bilgiLabel.Visible = false;
                        Formlar.Admin_AS form = new Formlar.Admin_AS(ad1);
                        form.Show();
                        this.Hide();                    
                    }
                    else
                    {
                        throw new Exception("E-mail veya şifre hatalı.");
                    }
                }
            }
            catch (Exception ex)
            {
                bilgiLabel.Text = ex.Message;
                bilgiLabel.Visible = true;
            }

            /*if (Control.IsKeyLocked(Keys.CapsLock))
            {
                bilgiLabel.Visible = true;
            }
            else
            {
                bilgiLabel.Visible = false;
            }*/

        }
        private void button6_Click(object sender, EventArgs e)
        {
            bilgiLabel.Visible = false;
            Formlar.musteri_satıcı form = new Formlar.musteri_satıcı(this);
            form.ShowDialog();
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
      
    }
}
