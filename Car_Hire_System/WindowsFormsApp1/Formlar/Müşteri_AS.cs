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
    public partial class Müşteri_AS : Form
    {
        Objeler.Müşteri m1 = new Objeler.Müşteri();
        int dgvID =-1;
        public Müşteri_AS(Objeler.Müşteri m2)
        {
            InitializeComponent();
            m1 = m2;
        }

        private void Kullanıcı_AS_Load(object sender, EventArgs e)
        {
            try
            {
                OdemesiTamamlananlarıDGVyeCağır();
                OdemesiTamamlanmayanlarıDGVyeCağır();

                lblAd.Text = m1.Adı + " " + m1.Soyadı;
                lblCinsiyet.Text = m1.Cinsiyeti;
                lblMail.Text = m1.EMailAdresi;
                lblTelefon.Text = m1.TelefonNumarası;
                lblYas.Text = m1.Yası.ToString();
                lblUlke.Text = m1.Adres.Ülkesi;
                lblIl.Text = m1.Adres.Ili;
                lblIlce.Text = m1.Adres.Ilçesi;
                lblEvAdresi.Text = m1.Adres.EvAdresi;
                MemoryStream mem = new MemoryStream(m1.Resim);
                pictureBox1.Image = Image.FromStream(mem);

                if (m1.Cinsiyeti == "Erkek")
                {
                    pBCinsiyet.Image = WindowsFormsApp1.Properties.Resources.male_22px;
                }
                else
                {
                    pBCinsiyet.Image = WindowsFormsApp1.Properties.Resources.female_22px;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ana sayfa yüklenirken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
           
        }


        private void OdemesiTamamlananlarıDGVyeCağır()
        {
            Objeler.Ödeme o1 = new Objeler.Ödeme();
            if(o1.OdemesiTamamlananlarıCagir(m1.MusteriID).Rows.Count > 0)
            {
                dgvKiralamaGecmisi.DataSource = o1.OdemesiTamamlananlarıCagir(m1.MusteriID);
                dgvKiralamaGecmisi.Columns[4].Visible = false;
                dgvKiralamaGecmisi.Columns[6].Visible = false;
            }
            else
            {
                dgvKiralamaGecmisi.DataSource = null;
            }
        }
        private void OdemesiTamamlanmayanlarıDGVyeCağır()
        {
            Objeler.Ödeme o1 = new Objeler.Ödeme();
            if (o1.OdemesiTamamlanmayanlarıCagir(m1.MusteriID).Rows.Count > 0)
            {
                dgvAktifKiralama.DataSource = o1.OdemesiTamamlanmayanlarıCagir(m1.MusteriID);
                dgvAktifKiralama.Columns[4].Visible = false;
                dgvAktifKiralama.Columns[6].Visible = false;


                Objeler.Kiralama k1 = new Objeler.Kiralama();
                k1 = k1.KiralamayıIDyeGoreCagir(int.Parse(dgvAktifKiralama.Rows[dgvAktifKiralama.SelectedRows[0].Index].Cells[5].Value.ToString()));
                Objeler.Araç a1 = new Objeler.Araç();
                a1 = a1.AracıŞasiIDyeGoreCagir(k1.SasiID);
                lblSasiID.Text = a1.SasiID;
                lblMarka.Text = a1.Marka;
                lblModel.Text = a1.Model;
                lblYakıtTürü.Text = a1.YakitTuru;
                lblVitesTürü.Text = a1.VitesTuru;
                lblBagajHacmi.Text = a1.BagajHacmi.ToString();
                lblRengi.Text = a1.Rengi;
                lblKoltukSayisi.Text = a1.KoltukSayisi.ToString();
                lblKaskoDurumu.Text = a1.KaskoDurumu;
                lblHavaYastıgı.Text = a1.HavaYastigiDurumu;
                MemoryStream mem = new MemoryStream(a1.Resim1);
                pictureBox2.Image = Image.FromStream(mem);
            }
            else 
            {
                dgvAktifKiralama.DataSource = null;
            }
        }


        private void dgvAktifKiralama_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if(e.ColumnIndex != -1 && e.RowIndex !=-1 && e.Button == MouseButtons.Right && dgvAktifKiralama.Rows[e.RowIndex].Cells[0].Value != null && dgvAktifKiralama.Rows[e.RowIndex].Cells[5].Value != null
                    && e.RowIndex <= dgvAktifKiralama.Rows.Count-2)
                {
                    dgvAktifKiralama.ClearSelection();
                    dgvAktifKiralama.Rows[e.RowIndex].Selected = true;
                    dgvID = int.Parse(dgvAktifKiralama.Rows[e.RowIndex].Cells[0].Value.ToString());

                    var gerceklokasyon = dgvAktifKiralama.PointToClient(Cursor.Position);
                    contextMenuStrip1.Show(dgvAktifKiralama, gerceklokasyon);


                    Objeler.Kiralama k1 = new Objeler.Kiralama();
                    k1 = k1.KiralamayıIDyeGoreCagir(int.Parse(dgvAktifKiralama.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    Objeler.Araç a1 = new Objeler.Araç();
                    a1 = a1.AracıŞasiIDyeGoreCagir(k1.SasiID);
                    lblSasiID.Text = a1.SasiID;
                    lblMarka.Text =a1.Marka;
                    lblModel.Text =a1.Model;
                    lblYakıtTürü.Text =a1.YakitTuru;
                    lblVitesTürü.Text =a1.VitesTuru;
                    lblBagajHacmi.Text = a1.BagajHacmi.ToString();
                    lblRengi.Text =a1.Rengi;
                    lblKoltukSayisi.Text =a1.KoltukSayisi.ToString();
                    lblKaskoDurumu.Text =a1.KaskoDurumu;
                    lblHavaYastıgı.Text =a1.HavaYastigiDurumu;
                    MemoryStream mem = new MemoryStream(a1.Resim1);
                    pictureBox2.Image = Image.FromStream(mem);
                }
                else if(e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Left && dgvAktifKiralama.Rows[e.RowIndex].Cells[0].Value != null && dgvAktifKiralama.Rows[e.RowIndex].Cells[5].Value != null
                    && e.RowIndex <= dgvAktifKiralama.Rows.Count - 2)
                {
                    dgvAktifKiralama.ClearSelection();
                    dgvAktifKiralama.Rows[e.RowIndex].Selected = true;
                    dgvID = int.Parse(dgvAktifKiralama.Rows[e.RowIndex].Cells[0].Value.ToString());

                    Objeler.Kiralama k1 = new Objeler.Kiralama();
                    k1 = k1.KiralamayıIDyeGoreCagir(int.Parse(dgvAktifKiralama.Rows[e.RowIndex].Cells[5].Value.ToString()));
                    Objeler.Araç a1 = new Objeler.Araç();
                    a1 = a1.AracıŞasiIDyeGoreCagir(k1.SasiID);
                    lblSasiID.Text = a1.SasiID;
                    lblMarka.Text = a1.Marka;
                    lblModel.Text = a1.Model;
                    lblYakıtTürü.Text = a1.YakitTuru;
                    lblVitesTürü.Text = a1.VitesTuru;
                    lblBagajHacmi.Text = a1.BagajHacmi.ToString();
                    lblRengi.Text = a1.Rengi;
                    lblKoltukSayisi.Text = a1.KoltukSayisi.ToString();
                    lblKaskoDurumu.Text = a1.KaskoDurumu;
                    lblHavaYastıgı.Text = a1.HavaYastigiDurumu;
                    MemoryStream mem = new MemoryStream(a1.Resim1);
                    pictureBox2.Image = Image.FromStream(mem);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }


        private void kiralamayıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvID ==-1)
                {
                    return;
                }


                Objeler.Kiralama k1 = new Objeler.Kiralama();
                k1 = k1.KiralamayıIDyeGoreCagir(int.Parse(dgvAktifKiralama.Rows[dgvAktifKiralama.SelectedRows[0].Index].Cells[5].Value.ToString()));

                Objeler.Ödeme o1 = new Objeler.Ödeme();
                o1 = o1.OdemeyiIDyeGoreCagir(dgvID);

                Formlar.Ödeme_Guncelle form = new Formlar.Ödeme_Guncelle(k1,m1,o1);
                form.ShowDialog();

                OdemesiTamamlanmayanlarıDGVyeCağır();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncellme tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void kiralamayıİptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvID == -1)
                {
                    return;
                }
                var sonuc = MessageBox.Show("Kiralamayı iptal etmek istediğinize emin misiniz?","Sistem mesajı", MessageBoxButtons.YesNo);
                if(sonuc==DialogResult.Yes)
                {
                    Objeler.Ödeme o1 = new Objeler.Ödeme();
                    var s1 = o1.OdemeTamamla(o1.OdemeyiIDyeGoreCagir(dgvID));
                    if (s1>0)
                    {
                        MessageBox.Show("Kiralama başarıyla iptal edildi.");
                        if(o1.OdemesiTamamlanmayanlarıCagir(m1.MusteriID).Rows.Count > 0)
                        {
                            dgvAktifKiralama.DataSource = o1.OdemesiTamamlanmayanlarıCagir(m1.MusteriID);
                        }
                        else
                        {
                            dgvAktifKiralama.DataSource = null;
                        }
                        if(o1.OdemesiTamamlananlarıCagir(m1.MusteriID).Rows.Count > 0)
                        {
                            dgvKiralamaGecmisi.DataSource = o1.OdemesiTamamlananlarıCagir(m1.MusteriID);
                        }
                        else
                        {
                            dgvKiralamaGecmisi.DataSource = null;
                        }
                    }
                    else 
                    {                       
                        MessageBox.Show("Kiralama iptal edilemedi.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İptal tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }


        private void btnExcel1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvAktifKiralama, "Aktif Kiralamalarım");
        }
        private void btnExcel2_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvKiralamaGecmisi, "Kiralama Geçmişim");
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Aktif Kiralamalarım", dgvAktifKiralama);
        }
        private void btnPrint2_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Kiralama Geçmişim", dgvKiralamaGecmisi);
        }
        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            OdemesiTamamlanmayanlarıDGVyeCağır();
        }
        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            OdemesiTamamlananlarıDGVyeCağır();
        }

        private void btnProfilDüzenle_Click(object sender, EventArgs e)
        {
            try
            {
                Formlar.Musteri_Guncelle form = new Formlar.Musteri_Guncelle(m1);
                form.ShowDialog();

                Objeler.Müşteri m3 = new Objeler.Müşteri();
                m3 = m3.MusteriyiIDyeGoreCagir(m1.MusteriID);

                //Güncellenen verileri yazdırıyoruz
                if (m3 != null)
                {
                    lblAd.Text = m3.Adı + " " + m3.Soyadı;
                    lblCinsiyet.Text = m3.Cinsiyeti;
                    lblMail.Text = m3.EMailAdresi;
                    lblTelefon.Text = m3.TelefonNumarası;
                    lblYas.Text = m3.Yası.ToString();
                    lblUlke.Text = m3.Adres.Ülkesi;
                    lblIl.Text = m3.Adres.Ili;
                    lblIlce.Text = m3.Adres.Ilçesi;
                    lblEvAdresi.Text = m3.Adres.EvAdresi;
                    MemoryStream mem = new MemoryStream(m3.Resim);
                    pictureBox1.Image = Image.FromStream(mem);

                    if (m3.Cinsiyeti == "Erkek")
                    {
                        pBCinsiyet.Image = WindowsFormsApp1.Properties.Resources.male_22px;
                    }
                    else
                    {
                        pBCinsiyet.Image = WindowsFormsApp1.Properties.Resources.female_22px;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgileri güncellemede bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }

        }
    }
}
