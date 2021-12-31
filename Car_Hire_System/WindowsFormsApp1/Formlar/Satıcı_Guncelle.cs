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
    public partial class Satıcı_Guncelle : Form
    {
        Objeler.Admin ad1;
        Objeler.Satıcı s1 = new Objeler.Satıcı();
        byte[] resimByte = null;
        public Satıcı_Guncelle(Objeler.Satıcı s2, Objeler.Admin ad2 = null)
        {
            InitializeComponent();
            ad1 = ad2;
            s1 = s2;

            tbTCKimlik.Text = s1.TCkimlik;
            tbAd.Text = s1.Adı;
            tbSoyad.Text = s1.Soyadı;
            comboBoxCinsiyet.SelectedItem = s1.Cinsiyeti;
            numericUpDownYas.Value = s1.Yası;
            maskedTbTelefon.Text = s1.TelefonNumarası;
            tbEmail.Text = s1.EMailAdresi;
            tbSifre.Text = s1.Sifresi;
            tbSifreOnay.Text = s1.Sifresi;
            comboBoxiL.SelectedItem = s1.Adres.Ili;
            tbIlce.Text = s1.Adres.Ilçesi;
            tbUlke.Text = s1.Adres.Ülkesi;
            tbEvAdres.Text = s1.Adres.EvAdresi;
            MemoryStream mem = new MemoryStream(s1.Resim);
            pictureBox2.Image = Image.FromStream(mem);

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

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            try
            {               
                labelMessage.Visible = false;

                ImageConverter converter = new ImageConverter();
                resimByte = (byte[])converter.ConvertTo(pictureBox2.Image, typeof(byte[]));

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

                    s1.Adı = tbAd.Text.Trim();
                    s1.Soyadı = tbSoyad.Text.Trim();
                    s1.Cinsiyeti = comboBoxCinsiyet.Text;
                    s1.Yası = (int)numericUpDownYas.Value;
                    s1.EMailAdresi = tbEmail.Text.Trim();
                    s1.TelefonNumarası = maskedTbTelefon.Text;
                    s1.Adres.EvAdresi = tbEvAdres.Text.Trim();
                    s1.Adres.Ülkesi = tbUlke.Text.Trim();
                    s1.Adres.Ili = comboBoxiL.SelectedItem.ToString();
                    s1.Adres.Ilçesi = tbIlce.Text.Trim();
                    s1.Sifresi = tbSifre.Text.Trim();
                    s1.Resim = resimByte;

                    if(ad1!=null)
                    {
                        if (ad1.AdminSatıcıGuncelle(s1, ad1))
                        {
                            MessageBox.Show("Satıcı bilgileri başarıyla güncellendi.", "System message", MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Hata satıcı bilgileri güncellenemedi.");
                        }
                    } 
                    else if(s1.Satıcı_güncelleme(s1)>0)
                    {
                        this.Close();
                        MessageBox.Show("Bilgileriniz başarıyla güncellendi." , "Sistem Mesajı", MessageBoxButtons.OK);
                    }
                    else 
                    {
                        throw new Exception("Hata bilgiler güncellenemedi.");
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


        private void Satıcı_Guncelle_DragOver(object sender, DragEventArgs e)
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
                    
                    resimByte = File.ReadAllBytes(dialog.FileName);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Resim ekleme hatası" + ex.Message);
            }
        }
        private void Satıcı_Guncelle_DragDrop(object sender, DragEventArgs e)
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
