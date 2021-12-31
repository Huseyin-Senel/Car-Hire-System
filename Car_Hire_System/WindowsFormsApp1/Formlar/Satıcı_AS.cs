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
using ClosedXML.Excel;

namespace WindowsFormsApp1.Formlar
{
    public partial class Satıcı_AS : Form
    {
        Objeler.Satıcı s1 = new Objeler.Satıcı();
        int dgvID = -1;
        string sdgvID = "-1";
        public Satıcı_AS(Objeler.Satıcı s2)
        {
            InitializeComponent();

            s1 = s2;
        }

        private void Satıcı_AS_Load(object sender, EventArgs e)
        {
            try
            {
                AraçlarıDGVyeCagır();
                AktifAraclarıDGVyeCagir();
                BekleyenKiralamalarıDGVyeCağır();

                lblAd.Text = s1.Adı + " " + s1.Soyadı;
                lblCinsiyet.Text = s1.Cinsiyeti;
                lblMail.Text = s1.EMailAdresi;
                lblTelefon.Text = s1.TelefonNumarası;
                lblYas.Text = s1.Yası.ToString();
                lblUlke.Text = s1.Adres.Ülkesi;
                lblIl.Text = s1.Adres.Ili;
                lblIlce.Text = s1.Adres.Ilçesi;
                lblEvAdresi.Text = s1.Adres.EvAdresi;
                MemoryStream mem = new MemoryStream(s1.Resim);
                pictureBox1.Image = Image.FromStream(mem);//(Bitmap)((new ImageConverter()).ConvertFrom(s1.Resim));

                if (s1.Cinsiyeti == "Erkek")
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

                throw new Exception(ex.Message);
            }        
        }


        private void AraçlarıDGVyeCagır()
        {
            try
            {
                Objeler.Araç a1 = new Objeler.Araç();
                if (a1.AraçlarıTCyeGoreCagir(s1.TCkimlik).Rows.Count > 0)
                {
                    dgvAraçlarım.DataSource = a1.AraçlarıTCyeGoreCagir(s1.TCkimlik);
                    dgvAraçlarım.Columns[12].Visible = false;
                    dgvAraçlarım.Columns[13].Visible = false;
                    dgvAraçlarım.Columns[14].Visible = false;
                }
                else
                {
                    dgvAraçlarım.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araçları çağırırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void BekleyenKiralamalarıDGVyeCağır()
        {
            try
            {
                Objeler.Araç a1 = new Objeler.Araç();
                DataTable dt = a1.AraçlarıTCyeGoreCagir(s1.TCkimlik);

                Objeler.Kiralama k1 = new Objeler.Kiralama();
                DataTable dt1 = new DataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt1.Merge(k1.KiralamaSasiIDyeGoreCagir(dt.Rows[i]["ŞasiID"].ToString()));
                }

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
                dt1.AcceptChanges();

                if (dt1.Rows.Count > 0)
                {
                    dgvBekleyenKiralamalarım.DataSource = dt1;
                    dgvBekleyenKiralamalarım.Columns[5].Visible = false;
                }
                else
                {
                    dgvBekleyenKiralamalarım.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bekleyen kiralamaları çağırırken bir hata oluştu \n" + ex.Message, "System message", MessageBoxButtons.OK);
            }
        }
        private void AktifAraclarıDGVyeCagir()
        {
            try
            {
                Objeler.Araç a1 = new Objeler.Araç();
                DataTable dt = a1.AraçlarıTCyeGoreCagir(s1.TCkimlik);

                Objeler.Kiralama k1 = new Objeler.Kiralama();
                DataTable dt1 = new DataTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt1.Merge(k1.KiralamaSasiIDyeGoreCagir(dt.Rows[i]["ŞasiID"].ToString()));
                }


                Objeler.Ödeme o1 = new Objeler.Ödeme();
                DataTable dt2 = o1.ButunOdemeleriCagir(); //sütun sayısı eşit olsun diye çağrıyoruz
                dt2.Rows.Clear();
                DataRow row;
                for (int i = 0; i < dt1.Rows.Count; i++)
                {

                    
                    if (o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt1.Rows[i]["KiralamaID"].ToString())) != null)
                    {
                        o1 = o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt1.Rows[i]["KiralamaID"].ToString()));
                        row = dt2.NewRow();
                        row[0] = o1.OdemeID;
                        row[1] = o1.BaslangicTarihi;
                        row[2] = o1.BitisTarihi;
                        row[3] = o1.KiralamaDurumu;
                        row[4] = o1.MusteriID;
                        row[5] = o1.KiralamaID;
                        row[6] = o1.AdminID;
                        dt2.Rows.Add(row);
                    }

                }

                if(dt2.Rows.Count >0)
                {
                    dgvKiralanmısAraclarim.DataSource = dt2;
                    dgvKiralanmısAraclarim.Columns[6].Visible = false;
                }
                else
                {
                    dgvKiralanmısAraclarim.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Aktif araçları çağırırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }           
        }


        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Formlar.Arac_Kayit form = new Formlar.Arac_Kayit(s1);
                form.ShowDialog();
                AraçlarıDGVyeCagır();
                BekleyenKiralamalarıDGVyeCağır();
            }
            catch (Exception ex)
            {
                throw new Exception("Araç ekleme hatası" + ex.Message);
            }
        }
        private void btnKiralamaEkle_Click(object sender, EventArgs e)
        {
            Formlar.Araç_Seçin form = new Formlar.Araç_Seçin(s1);
            form.ShowDialog();
            BekleyenKiralamalarıDGVyeCağır();
        }
        private void btnProfilDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                Formlar.Satıcı_Guncelle form = new Formlar.Satıcı_Guncelle(s1);
                form.ShowDialog();


                //Güncellenen verileri yazdırıyoruz
                Objeler.Satıcı s3 = new Objeler.Satıcı();
                s3 = s3.SatıcıyıTCyeGoreCagir(s1.TCkimlik);

                if(s3 != null)
                {
                    lblAd.Text = s3.Adı + " " + s3.Soyadı;
                    lblCinsiyet.Text = s3.Cinsiyeti;
                    lblMail.Text = s3.EMailAdresi;
                    lblTelefon.Text = s3.TelefonNumarası;
                    lblYas.Text = s3.Yası.ToString();
                    lblUlke.Text = s3.Adres.Ülkesi;
                    lblIl.Text = s3.Adres.Ili;
                    lblIlce.Text = s3.Adres.Ilçesi;
                    lblEvAdresi.Text = s3.Adres.EvAdresi;
                    MemoryStream mem = new MemoryStream(s3.Resim);
                    pictureBox1.Image = Image.FromStream(mem);

                    if (s3.Cinsiyeti == "Erkek")
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


        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            AraçlarıDGVyeCagır();
        }   
        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            AktifAraclarıDGVyeCagir();
        }
        private void btnRefresh3_Click(object sender, EventArgs e)
        {
            BekleyenKiralamalarıDGVyeCağır();
        }
        private void btnExcel1_Click(object sender, EventArgs e)
        {          
            Objeler.FormYardımcisi.ExcelYazdır(dgvAraçlarım, "Araçlarım");      
        }
        private void btnExcel2_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvKiralanmısAraclarim, "Kiralanmış Araçlarım");          
        }
        private void btnExcel3_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvBekleyenKiralamalarım, "Bekleyen Kiralamalarım");
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Araçlarım",dgvAraçlarım);
        }
        private void btnPrint2_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Kiralanmış Araçlarım", dgvKiralanmısAraclarim);
        }
        private void btnPrint3_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Bekleyen Kiralamalarım", dgvBekleyenKiralamalarım);
        }


        private void dgvKiralanmısAraclarim_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvKiralanmısAraclarim.Rows[e.RowIndex].Cells[5].Value != null && e.RowIndex <= dgvKiralanmısAraclarim.Rows.Count - 2)
                {
                    dgvKiralanmısAraclarim.ClearSelection();
                    dgvKiralanmısAraclarim.Rows[e.RowIndex].Selected = true;
                    dgvID = int.Parse(dgvKiralanmısAraclarim.Rows[e.RowIndex].Cells[5].Value.ToString());

                    var gerceklokasyon = dgvKiralanmısAraclarim.PointToClient(Cursor.Position);
                    contextMenuStrip2.Show(dgvKiralanmısAraclarim, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void dgvBekleyenKiralamalarım_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvBekleyenKiralamalarım.Rows[e.RowIndex].Cells[0].Value != null && e.RowIndex <= dgvBekleyenKiralamalarım.Rows.Count - 2)
                {
                    dgvBekleyenKiralamalarım.ClearSelection();
                    dgvBekleyenKiralamalarım.Rows[e.RowIndex].Selected = true;
                    dgvID = int.Parse(dgvBekleyenKiralamalarım.Rows[e.RowIndex].Cells[0].Value.ToString());

                    var gerceklokasyon = dgvBekleyenKiralamalarım.PointToClient(Cursor.Position);
                    contextMenuStrip3.Show(dgvBekleyenKiralamalarım, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void dgvAraçlarım_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvAraçlarım.Rows[e.RowIndex].Cells[0].Value != null && e.RowIndex <= dgvAraçlarım.Rows.Count - 2)
                {
                    dgvAraçlarım.ClearSelection();
                    dgvAraçlarım.Rows[e.RowIndex].Selected = true;
                    sdgvID = dgvAraçlarım.Rows[e.RowIndex].Cells[0].Value.ToString();

                    var gerceklokasyon = dgvAraçlarım.PointToClient(Cursor.Position);
                    contextMenuStrip1.Show(dgvAraçlarım, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }


        private void aracıGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {       
            try
            {
                if (dgvID == -1)
                {
                    return;
                }

                Objeler.Kiralama k1 = new Objeler.Kiralama();
                k1 = k1.KiralamayıIDyeGoreCagir(dgvID);
                Objeler.Araç a1 = new Objeler.Araç();
                a1 = a1.AracıŞasiIDyeGoreCagir(k1.SasiID);

                Formlar.Aracı_Görüntüle form = new Aracı_Görüntüle(a1);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Aracı görüntüleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void kiralamayıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvID == -1)
                {
                    return;
                }
                var sonuc = MessageBox.Show("Kiralamayı silmek istediğinize emin misiniz?", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    Objeler.Kiralama k1 = new Objeler.Kiralama();
                    if (k1.KiralamaSil(dgvID) > 0)
                    {
                        MessageBox.Show("Kiralama başarıyla silindi.", "Sistem Mesajı", MessageBoxButtons.OK);
                        BekleyenKiralamalarıDGVyeCağır();
                    }
                    else
                    {
                        MessageBox.Show("Kiralama silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);
                        BekleyenKiralamalarıDGVyeCağır();
                    }
                }        

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiralamayı silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void KiralamaGuncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvID == -1)
                {
                    return;
                }

                Objeler.Kiralama k3 = new Objeler.Kiralama();
                k3 = k3.KiralamayıIDyeGoreCagir(dgvID);

                Formlar.Kiralama_Guncelle form = new Kiralama_Guncelle(k3);
                form.ShowDialog();

                BekleyenKiralamalarıDGVyeCağır();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiralamayı güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void aracıKaldırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sdgvID == "-1")
                {
                    return;
                }
                var sonuc = MessageBox.Show("Aracı silmek istediğinize emin misiniz? \n (Sadece ödemesi olmayan araçlar kaldırılabilir.)", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    Objeler.Kiralama k1 = new Objeler.Kiralama();

                    if(k1.KiralamaSasiIDyeGoreCagir(sdgvID).Rows.Count > 0) 
                    {
                        int kiralamaID = int.Parse(k1.KiralamaSasiIDyeGoreCagir(sdgvID).Rows[0]["KiralamaID"].ToString()); //Birden fazla kiralama varsa ödemesi olmak zorunda onun için ilk satıra bakmak yeterli
                        Objeler.Ödeme o1 = new Objeler.Ödeme();
                        if (o1.OdemeyiKiralamaIDyeGoreCagir(kiralamaID) != null)
                        {
                            MessageBox.Show("Araca ait ödeme bulundu. \n(Ödemesi olan araçlar kaldırılamaz). \nAraç kaldırılamadı", "Sistem Mesajı", MessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Araca ait kiralama bulundu. \nLütfen ilk önce aracın kiralamasını kaldırın. \nAraç kaldırılamadı.", "Sistem Mesajı", MessageBoxButtons.OK);
                            return;
                        }
                    }
                    else
                    {
                        Objeler.Araç a1 = new Objeler.Araç();
                        if (a1.AraçSil(sdgvID) > 0)
                        {
                            MessageBox.Show("Araç silidi.", "Sistem Mesajı", MessageBoxButtons.OK);
                            AraçlarıDGVyeCagır();
                        }
                        else
                        {
                            MessageBox.Show("Hata araç silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);
                            AraçlarıDGVyeCagır();
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Araç silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }

        private void aracıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sdgvID == "-1")
                {
                    return;
                }

                Objeler.Araç a3 = new Objeler.Araç();
                a3 = a3.AracıŞasiIDyeGoreCagir(sdgvID);

                Formlar.Arac_Guncelle form = new Arac_Guncelle(s1,a3);
                form.ShowDialog();

                AraçlarıDGVyeCagır();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Aracı güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
    }
}
