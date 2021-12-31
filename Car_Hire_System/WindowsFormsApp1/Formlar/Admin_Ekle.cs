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
    public partial class Admin_Ekle : Form
    {

        public Admin_Ekle()
        {
            InitializeComponent();
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
                    Objeler.Admin ad1 = new Objeler.Admin();

                    ad1.KullanıcıAdı = tbKullanıcıAdı.Text.Trim();
                    ad1.EMail = tbMail.Text.Trim();
                    ad1.Sifre = tbSifre.Text.Trim();


                    if (ad1.Admin_Ekle(ad1) > 0)
                    {
                        MessageBox.Show("admin başarıyla eklendi.", "Sistem Mesajı", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Hata admin eklenemedi.");
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
