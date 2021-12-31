using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Formlar
{
    public partial class Musteri_Kayit : Form
    {
        Objeler.Admin ad1;
        byte[] resimByte = null;
        public Musteri_Kayit(Objeler.Admin ad2 = null)
        {
            InitializeComponent();
            ad1 = ad2;
        }

        private bool telefonBos()
        {
            if(maskedTbTelefon.Text.Length<14)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < 13; i++)
                {
                    if (i != 0 && i != 4 && i != 5 && i !=9)
                    {
                        if (maskedTbTelefon.Text.ToString()[i] != '0' && maskedTbTelefon.Text.ToString()[i] != '1' &&
                            maskedTbTelefon.Text.ToString()[i] != '2' && maskedTbTelefon.Text.ToString()[i] != '3' &&
                            maskedTbTelefon.Text.ToString()[i] != '4' && maskedTbTelefon.Text.ToString()[i] != '5' &&
                            maskedTbTelefon.Text.ToString()[i] != '6' && maskedTbTelefon.Text.ToString()[i] != '7' &&
                            maskedTbTelefon.Text.ToString()[i] != '8' && maskedTbTelefon.Text.ToString()[i] != '9')
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void Kayıt_ol_Click(object sender, EventArgs e)
        {
            try
            {               
                labelMessage.Visible = false;
                if (String.IsNullOrEmpty(tbAd.Text.Trim()))
                {
                    labelMessage.Text = "Müşteri adı boş olamaz.*";
                    labelMessage.Visible = true;
                    tbAd.Focus();
                }
                else if (String.IsNullOrEmpty(tbSoyad.Text.Trim()))
                {
                    labelMessage.Text = "Müşteri soyadı boş olamaz.*";
                    labelMessage.Visible = true;
                    tbSoyad.Focus();
                }
                else if (comboBoxCinsiyet.SelectedIndex == -1)
                {
                    labelMessage.Text = "Cinsiyet seçiniz.*";
                    labelMessage.Visible = true;
                    comboBoxCinsiyet.Focus();
                }
                else if (telefonBos())
                {
                    labelMessage.Text = "Telefon numarası hatalı.*";
                    labelMessage.Visible = true;
                    maskedTbTelefon.Focus();
                }
                else if (String.IsNullOrEmpty(tbEmail.Text.Trim()))
                {
                    labelMessage.Text = "E-mail adresi boş olamaz.*";
                    labelMessage.Visible = true;
                    tbEmail.Focus();
                }
                else if (!tbEmail.Text.Contains('@'))
                {
                    labelMessage.Text = "Geçerli bir E-mail adresi giriniz.*";
                    labelMessage.Visible = true;
                    tbEmail.Focus();
                }
                else if (tbEmail.Text.Trim().Contains(' '))
                {
                    labelMessage.Text = "E-mail adresi boşluk içeremez.*";
                    labelMessage.Visible = true;
                    tbEmail.Focus();
                }
                else if (String.IsNullOrEmpty(tbSifre.Text.Trim()))
                {
                    labelMessage.Text = "Şifre boş olamaz.*";
                    labelMessage.Visible = true;
                    tbSifre.Focus();
                }
                else if (tbSifre.Text.Trim().Length < 8)
                {
                    labelMessage.Text = "Şifre en az 8 karakter içermeli.*";
                    labelMessage.Visible = true;
                    tbSifre.Focus();
                }
                else if (tbSifre.Text.Trim() != tbSifreOnay.Text.Trim())
                {
                    labelMessage.Text = "Şifreler uyuşmuyor*";
                    labelMessage.Visible = true;
                    tbSifreOnay.Focus();
                }
                else if (comboBoxiL.SelectedIndex == -1)
                {
                    labelMessage.Text = "İl seçiniz.*";
                    labelMessage.Visible = true;
                    comboBoxiL.Focus();
                }
                else if (String.IsNullOrEmpty(tbIlce.Text.Trim()))
                {
                    labelMessage.Text = "İlçe boş olamaz.";
                    labelMessage.Visible = true;
                    tbIlce.Focus();
                }
                else if (String.IsNullOrEmpty(tbUlke.Text.Trim()))
                {
                    labelMessage.Text = "Ülke boş olamaz.*";
                    labelMessage.Visible = true;
                    tbUlke.Focus();
                }
                else if (String.IsNullOrEmpty(tbEvAdres.Text.Trim()))
                {
                    labelMessage.Text = "Ev adresi boş olamaz.*";
                    labelMessage.Visible = true;
                    tbEvAdres.Focus();
                }
                else if (resimByte == null)
                {
                    labelMessage.Text = "Resim boş olamaz.*";
                    labelMessage.Visible = true;
                    pictureBox2.Focus();
                }
                else 
                {
                    Objeler.Adres a1 = new Objeler.Adres(tbEvAdres.Text.Trim(), comboBoxiL.SelectedItem.ToString(), tbIlce.Text.Trim(), tbUlke.Text.Trim());
                    Objeler.Müşteri m1 = new Objeler.Müşteri();

                    m1.Adı = tbAd.Text.Trim();
                    m1.Soyadı = tbSoyad.Text.Trim();
                    m1.Cinsiyeti = comboBoxCinsiyet.Text;
                    m1.Yası = (int)numericUpDownYas.Value;
                    m1.EMailAdresi = tbEmail.Text.Trim();
                    m1.TelefonNumarası = maskedTbTelefon.Text;
                    m1.Adres = a1;
                    m1.Sifresi = tbSifre.Text.Trim();
                    m1.Resim = resimByte;

                    if(ad1!=null)
                    {
                        if (ad1.AdminMüşteriEkle(m1, ad1))
                        {
                            MessageBox.Show("Müşteri başarıyla eklendi.", "System message", MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Hata müşteri eklenemedi.");
                        }
                    } 
                    else if(m1.Müşteri_Ekle(m1)>0)
                    {
                        m1 = m1.MusteriLogin(m1.EMailAdresi, m1.Sifresi);
                        Objeler.Satıcı s1 = null;
                        Formlar.Anasayfa form = new Formlar.Anasayfa(m1,s1);
                        form.Show();
                        this.Close();
                    }
                    else 
                    {
                        throw new Exception("Hata müşteri kaydedilemedi.");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message; 
                labelMessage.Visible = true;
            }
            
        }
        private void iptal_Click(object sender, EventArgs e)
        {
            if (ad1 != null)
            {
                this.Close();
            }
            else
            {
                Formlar.Login form = new Formlar.Login();
                form.Show();
                this.Close();
            }
        }


        private void tbAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender, e);          
        }
        private void tbSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender, e);
        }
        private void tbIlce_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender, e);
        }
        private void tbUlke_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender, e);
        }


        private void Musteri_Kayit_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "resim dosyası (*.jpg, *.jpeg, *.bmp, *.png)|*.jpg; *.jpeg; *.bmp; *.png;";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap img = new Bitmap(dialog.FileName);
                    pictureBox2.Image = img;

                    //ImageConverter converter = new ImageConverter();
                    //resimByte = (byte[])converter.ConvertTo(img, typeof(byte[]));
                    resimByte = File.ReadAllBytes(dialog.FileName);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Resim ekleme hatası" + ex.Message);
            }
        }
        private void Musteri_Kayit_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null)
                {
                    if (files[0].ToLower().EndsWith(".jpg") || files[0].ToLower().EndsWith(".jpeg") || files[0].ToLower().EndsWith(".bmp") || files[0].ToLower().EndsWith(".png"))
                    {
                        Bitmap img = new Bitmap(files[0]);
                        pictureBox2.Image = img;
                        resimByte = File.ReadAllBytes(files[0]);
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
