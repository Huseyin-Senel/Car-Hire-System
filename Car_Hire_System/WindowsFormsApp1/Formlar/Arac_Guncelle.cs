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
    public partial class Arac_Guncelle : Form
    {
        Objeler.Araç_Kategorisi k1 = new Objeler.Araç_Kategorisi();
        Objeler.Satıcı s1 = new Objeler.Satıcı();
        Objeler.Admin ad1 = new Objeler.Admin();
        Objeler.Araç a1 = new Objeler.Araç();
        byte[] resimByte = null;
        public Arac_Guncelle(Objeler.Satıcı s2,Objeler.Araç a2, Objeler.Admin ad2 = null)
        {
            InitializeComponent();

            s1 = s2;
            ad1 = ad2;
            a1 = a2;

            comboBoxKategori.DataSource = ConvertDataTable(k1.KategoriAdlarınıCagir());
            comboBoxHavaYastıgı.SelectedItem = a1.HavaYastigiDurumu;
            comboBoxKasko.SelectedItem = a1.KaskoDurumu;
            comboBoxVitesTürü.SelectedItem = a1.VitesTuru;
            nUpDKoltukSayısı.Value = a1.KoltukSayisi;
            tbSasi.Text = a1.SasiID;
            tbSasi.Enabled = false;
            tbMarka.Text = a1.Marka;
            tbModel.Text = a1.Model;
            tbMevcutKilometre.Text = a1.MevcutKilometresi.ToString();
            tbMotorGücü.Text = a1.MotorGucu.ToString();
            tbYakıtTürü.Text = a1.YakitTuru;
            tbBagajHacmi.Text = a1.BagajHacmi.ToString();
            tbRenk.Text = a1.Rengi;
            MemoryStream mem = new MemoryStream(a1.Resim1);
            pictureBox2.Image = Image.FromStream(mem);
        }

        private List<string> ConvertDataTable(DataTable dt)
        {
            List<string> data = new List<string>();
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                data.Add(dt.Rows[i]["KategoriAdı"].ToString());
            }
            return data;
        }
        private Objeler.Araç TbKontrolEt()
        {
            try
            {

                ImageConverter converter = new ImageConverter();
                resimByte = (byte[])converter.ConvertTo(pictureBox2.Image, typeof(byte[]));

                labelMessage.Visible = false;
                if (String.IsNullOrEmpty(tbSasi.Text.Trim()))
                {
                    labelMessage.Text = "Şasi numarası boş olamaz.*";
                    labelMessage.Visible = true;
                    tbSasi.Focus();
                }
                else if (tbSasi.Text.Trim().Length < 17)
                {
                    labelMessage.Text = "Şasi numarası 17 karakter olmalı.*";
                    labelMessage.Visible = true;
                    tbSasi.Focus();
                }
                else if (String.IsNullOrEmpty(tbMarka.Text.Trim()))
                {
                    labelMessage.Text = "Marka ismi boş olamaz.*";
                    labelMessage.Visible = true;
                    tbMarka.Focus();
                }
                else if (String.IsNullOrEmpty(tbModel.Text.Trim()))
                {
                    labelMessage.Text = "Model ismi boş olamaz.*";
                    labelMessage.Visible = true;
                    tbModel.Focus();
                }
                else if(int.Parse(tbMevcutKilometre.Text)<0)
                {
                    labelMessage.Text = "Aracın mevcut kilometresi 0 dan az olamaz.*";
                    labelMessage.Visible = true;
                    tbMevcutKilometre.Focus();
                }
                else if (float.Parse(tbMotorGücü.Text) <= 0)
                {
                    labelMessage.Text = "Aracın motor gücü 0 ya da daha az olamaz.*";
                    labelMessage.Visible = true;
                    tbMevcutKilometre.Focus();
                }
                else if (String.IsNullOrEmpty(tbYakıtTürü.Text.Trim()))
                {
                    labelMessage.Text = "Yakıt türü boş olamaz.*";
                    labelMessage.Visible = true;
                    tbYakıtTürü.Focus();
                }
                else if (comboBoxVitesTürü.SelectedIndex == -1)
                {
                    labelMessage.Text = "Vites türü seçiniz.*";
                    labelMessage.Visible = true;
                    comboBoxVitesTürü.Focus();
                }
                else if (float.Parse(tbBagajHacmi.Text) < 0)
                {
                    labelMessage.Text = "Aracın bagaj hacmi 0 dan az olamaz.*";
                    labelMessage.Visible = true;
                    tbBagajHacmi.Focus();
                }
                else if (String.IsNullOrEmpty(tbRenk.Text.Trim()))
                {
                    labelMessage.Text = "Aracın engi boş olamaz.*";
                    labelMessage.Visible = true;
                    tbRenk.Focus();
                }                   
                //---nUpDkoltukSayısı--//
                else if (comboBoxKasko.SelectedIndex == -1)
                {
                    labelMessage.Text = "Kasko durumunu seçiniz.*";
                    labelMessage.Visible = true;
                    comboBoxKasko.Focus();
                }
                else if (comboBoxHavaYastıgı.SelectedIndex == -1)
                {
                    labelMessage.Text = "Hava yastığı durumunu seçiniz.*";
                    labelMessage.Visible = true;
                    comboBoxHavaYastıgı.Focus();
                }
                else if (comboBoxKategori.SelectedIndex == -1)
                {
                    labelMessage.Text = "Kategori seçiniz.*";
                    labelMessage.Visible = true;
                    comboBoxKategori.Focus();
                }
                else if (resimByte == null)
                {
                    labelMessage.Text = "Resim boş olamaz.*";
                    labelMessage.Visible = true;
                    pictureBox2.Focus();
                }
                else
                {
                    //Objeler.Araç a1 = new Objeler.Araç();
                    a1.SasiID = tbSasi.Text.Trim();
                    a1.Marka = tbMarka.Text.Trim();
                    a1.Model = tbModel.Text.Trim();
                    a1.MevcutKilometresi = int.Parse(tbMevcutKilometre.Text.Trim());
                    a1.MotorGucu = float.Parse(tbMotorGücü.Text.Trim());
                    a1.YakitTuru = tbYakıtTürü.Text.Trim();
                    a1.VitesTuru = comboBoxVitesTürü.Text.Trim();
                    a1.BagajHacmi = float.Parse(tbBagajHacmi.Text.Trim());
                    a1.Rengi = tbRenk.Text.Trim();
                    a1.KoltukSayisi = (int)nUpDKoltukSayısı.Value;
                    a1.KaskoDurumu = comboBoxKasko.Text.Trim();
                    a1.HavaYastigiDurumu = comboBoxHavaYastıgı.Text.Trim();
                    a1.KategoriID = int.Parse(k1.KategorileriIsmeGoreCagir(comboBoxKategori.SelectedItem.ToString()).Rows[0]["KategoriID"].ToString());
                    a1.TCkimlik = s1.TCkimlik;
                    a1.Resim1 = resimByte;
                    return a1;
                }
                return null;
            }
            catch (Exception ex)
            {
                labelMessage.Text = ex.Message;
                labelMessage.Visible = true;
                return null;
            }
        }


        private void kaydetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (TbKontrolEt() != null)
                {
                    Objeler.Araç a1 = TbKontrolEt();
                    if (ad1 != null)
                    {
                        if (ad1.AdminAracGuncelle(a1, ad1))
                        {
                            MessageBox.Show("Araç başarıyla güncellendi.", "Sistem Mesajı", MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("Hata araç güncellenemedi");
                        }
                    }
                    else if (a1.AraçGüncelleme(a1) > 0) 
                    {
                        MessageBox.Show("Araç başarıyla güncellendi.", "Sistem Mesajı", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Hata araç güncellenemedi");
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
       



        private void tbMevcutKilometre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.RakamDegerYaz(sender, e,tbMevcutKilometre);
        }
        private void tbMotorGücü_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.FloatYaz(sender, e, tbMotorGücü);
        }
        private void tbBagajHacmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.FloatYaz(sender, e, tbBagajHacmi);
        }
        private void tbRenk_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender, e);
        }
        private void tbYakıtTürü_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender, e);
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
        private void Arac_Kayit_DragOver(object sender, DragEventArgs e)
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
        private void Arac_Kayit_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var files = e.Data.GetData(DataFormats.FileDrop) as string[];

                if (files != null)
                {
                   /* foreach(string file in files)
                    {

                    }*/

                    if (files[0].ToLower().EndsWith(".jpg") || files[0].ToLower().EndsWith(".jpeg") || files[0].ToLower().EndsWith(".bmp"))
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
