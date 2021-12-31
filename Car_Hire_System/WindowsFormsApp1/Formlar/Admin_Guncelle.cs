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
    public partial class Admin_Guncelle : Form
    {
        Objeler.Admin ad1 = new Objeler.Admin();
        public Admin_Guncelle(Objeler.Admin ad2)
        {
            InitializeComponent();
            ad1 = ad2;

            tbKullanıcıAdı.Text = ad1.KullanıcıAdı;
            tbMail.Text = ad1.EMail;
            tbSifre.Text = ad1.Sifre;
            tbSifreOnay.Text = ad1.Sifre;
        }

        private void iptalBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kaydetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                labelMessage.Visible = false;
                if (String.IsNullOrEmpty(tbKullanıcıAdı.Text.Trim()))
                {
                    labelMessage.Text = "Kullanıcı adı boş olamaz.*";
                    labelMessage.Visible = true;
                    tbKullanıcıAdı.Focus();
                }
                else if (String.IsNullOrEmpty(tbMail.Text.Trim()))
                {
                    labelMessage.Text = "E-mail adresi boş olamaz.*";
                    labelMessage.Visible = true;
                    tbMail.Focus();
                }
                else if (!tbMail.Text.Contains('@'))
                {
                    labelMessage.Text = "Geçerli bir E-mail adresi giriniz.*";
                    labelMessage.Visible = true;
                    tbMail.Focus();
                }
                else if (tbMail.Text.Trim().Contains(' '))
                {
                    labelMessage.Text = "E-mail adresi boşluk içeremez.*";
                    labelMessage.Visible = true;
                    tbMail.Focus();
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
                else
                {

                    ad1.KullanıcıAdı = tbKullanıcıAdı.Text.Trim();
                    ad1.EMail = tbMail.Text.Trim();
                    ad1.Sifre = tbSifre.Text.Trim();


                    if (ad1.Admin_güncelleme(ad1) > 0)
                    {
                        MessageBox.Show("Admin başarıyla güncellendi.", "Sistem Mesajı", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Hata admin güncellenemedi.");
                    }
                }
               
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
                labelMessage.Visible = true;
            }
        }
    }
}
