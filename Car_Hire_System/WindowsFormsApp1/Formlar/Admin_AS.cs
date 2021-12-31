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
    public partial class Admin_AS : Form
    {
        Objeler.Admin ad1 = new Objeler.Admin();
        Objeler.Araç a1 = new Objeler.Araç();
        Objeler.Müşteri m1 = new Objeler.Müşteri();
        Objeler.Satıcı s1 = new Objeler.Satıcı();
        Objeler.Ödeme o1 = new Objeler.Ödeme();
        Objeler.Kiralama k1 = new Objeler.Kiralama();

        string sasiID = "-1";
        int kiralamaID = -1;
        int odemeID = -1;
        int musteriID = -1;
        string satıcıID = "-1";
        int adminID = -1;
        public Admin_AS(Objeler.Admin ad2)
        {
            InitializeComponent();
            ad1 = ad2;

            lblAdminID.Text = ad1.AdminID.ToString();
            lblisim.Text = ad1.KullanıcıAdı;
            lblMail.Text = ad1.EMail;
            dgvAraçlar.DataSource = a1.ButunAraçlarıCagir();
            if (a1.ButunAraçlarıCagir().Rows.Count < 1)
            {
                dgvAraçlar.DataSource = null;
            }
            dgvMüşteriler.DataSource = m1.ButunMusterileriCagir();
            if (m1.ButunMusterileriCagir().Rows.Count < 1)
            {
                dgvMüşteriler.DataSource = null;
            }
            dgvSatıcılar.DataSource = s1.ButunSatıcılarıCagir();
            if (s1.ButunSatıcılarıCagir().Rows.Count < 1)
            {
                dgvSatıcılar.DataSource = null;
            }
            dgvKiralamalar.DataSource = k1.ButunKiralamalarıCagir();
            if (k1.ButunKiralamalarıCagir().Rows.Count < 1)
            {
                dgvKiralamalar.DataSource = null;
            }
            dgvOdemeler.DataSource = o1.ButunOdemeleriCagir();
            if (o1.ButunOdemeleriCagir().Rows.Count < 1)
            {
                dgvOdemeler.DataSource = null;
            }
            dgvAdminler.DataSource = ad1.ButunAdminleriCagir();
            if (ad1.ButunAdminleriCagir().Rows.Count < 1)
            {
                dgvAdminler.DataSource = null;
            }
        }


        private void Admin_AS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Formlar.Login form = new Formlar.Login();
            form.Show();
        }



        private void btnExcel1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvAraçlar, "Araçlar");
        }
        private void btnExcel2_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvSatıcılar, "Satıcılar");
        }
        private void btnExcel3_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvMüşteriler, "Müşteriler");
        }
        private void btnExcel4_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvOdemeler, "Ödemeler");
        }
        private void btnExcel5_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvKiralamalar, "Kiralamalar");
        }
        private void btnExcel6_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvAdminler, "Adminler");
        }



        private void btnPrint1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Araçlar", dgvAraçlar);
        }
        private void btnPrint2_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Satıcılar", dgvSatıcılar);
        }
        private void btnPrint3_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Müşteriler", dgvMüşteriler);
        }
        private void btnPrint4_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Ödemeler", dgvOdemeler);
        }
        private void btnPrint5_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Kiralamalar", dgvKiralamalar);
        }
        private void btnPrint6_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Adminler", dgvAdminler);
        }



        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            dgvAraçlar.DataSource = a1.ButunAraçlarıCagir();
            if(a1.ButunAraçlarıCagir().Rows.Count < 1)
            {
                dgvAraçlar.DataSource = null;
            }
        }
        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            dgvSatıcılar.DataSource = s1.ButunSatıcılarıCagir();
            if (s1.ButunSatıcılarıCagir().Rows.Count < 1)
            {
                dgvSatıcılar.DataSource = null;
            }
        }
        private void btnRefresh3_Click(object sender, EventArgs e)
        {
            dgvMüşteriler.DataSource = m1.ButunMusterileriCagir();
            if (m1.ButunMusterileriCagir().Rows.Count < 1)
            {
                dgvMüşteriler.DataSource = null;
            }
        }
        private void btnRefresh4_Click(object sender, EventArgs e)
        {
            dgvOdemeler.DataSource = o1.ButunOdemeleriCagir();
            if (o1.ButunOdemeleriCagir().Rows.Count < 1)
            {
                dgvOdemeler.DataSource = null;
            }
        }
        private void btnRefresh5_Click(object sender, EventArgs e)
        {
            dgvKiralamalar.DataSource = k1.ButunKiralamalarıCagir();
            if (k1.ButunKiralamalarıCagir().Rows.Count < 1)
            {
                dgvKiralamalar.DataSource = null;
            }
        }
        private void btnRefresh6_Click(object sender, EventArgs e)
        {
            dgvAdminler.DataSource = ad1.ButunAdminleriCagir();
            if (ad1.ButunAdminleriCagir().Rows.Count < 1)
            {
                dgvAdminler.DataSource = null;
            }
        }



        private void btnSatıcıEkle_Click(object sender, EventArgs e)
        {
            Formlar.Satici_Kayit form = new Satici_Kayit(ad1);
            form.ShowDialog();

            dgvSatıcılar.DataSource = s1.ButunSatıcılarıCagir();
            if (s1.ButunSatıcılarıCagir().Rows.Count < 1)
            {
                dgvSatıcılar.DataSource = null;
            }
        }
        private void btnMüşteriEkle_Click(object sender, EventArgs e)
        {
            Formlar.Musteri_Kayit form = new Musteri_Kayit(ad1);
            form.ShowDialog();

            dgvMüşteriler.DataSource = m1.ButunMusterileriCagir();
            if (m1.ButunMusterileriCagir().Rows.Count < 1)
            {
                dgvMüşteriler.DataSource = null;
            }
        }
        private void btnOdemeEkle_Click(object sender, EventArgs e)
        {
            Formlar.Admin_sec form = new Admin_sec(1);
            form.ShowDialog();

            dgvOdemeler.DataSource = o1.ButunOdemeleriCagir();
            if (o1.ButunOdemeleriCagir().Rows.Count < 1)
            {
                dgvOdemeler.DataSource = null;
            }
        }
        private void btnKiralamaEkle_Click(object sender, EventArgs e)
        {
            Formlar.Admin_sec form = new Admin_sec(2);
            form.ShowDialog();

            dgvKiralamalar.DataSource = k1.ButunKiralamalarıCagir();
            if (k1.ButunKiralamalarıCagir().Rows.Count < 1)
            {
                dgvKiralamalar.DataSource = null;
            }
        }
        private void btnAracEkle_Click(object sender, EventArgs e)
        {
            Formlar.Admin_sec form = new Admin_sec(0);
            form.ShowDialog();

            dgvAraçlar.DataSource = a1.ButunAraçlarıCagir();
            if (a1.ButunAraçlarıCagir().Rows.Count < 1)
            {
                dgvAraçlar.DataSource = null;
            }
        }
        private void btnAdminEkle_Click(object sender, EventArgs e)
        {
            Formlar.Admin_Ekle form = new Admin_Ekle();
            form.ShowDialog();

            dgvAdminler.DataSource = ad1.ButunAdminleriCagir();
            if (ad1.ButunAdminleriCagir().Rows.Count < 1)
            {
                dgvAdminler.DataSource = null;
            }
        }



        private void dgvAraçlar_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvAraçlar.Rows[e.RowIndex].Cells["ŞasiID"].Value != null && e.RowIndex <= dgvAraçlar.Rows.Count - 2)
                {
                    dgvAraçlar.ClearSelection();
                    dgvAraçlar.Rows[e.RowIndex].Selected = true;
                    sasiID = dgvAraçlar.Rows[e.RowIndex].Cells["ŞasiID"].Value.ToString();

                    var gerceklokasyon = dgvAraçlar.PointToClient(Cursor.Position);
                    cMsArac.Show(dgvAraçlar, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void dgvSatıcılar_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvSatıcılar.Rows[e.RowIndex].Cells["TCkimlik"].Value != null && e.RowIndex <= dgvSatıcılar.Rows.Count - 2)
                {
                    dgvSatıcılar.ClearSelection();
                    dgvSatıcılar.Rows[e.RowIndex].Selected = true;
                    satıcıID = dgvSatıcılar.Rows[e.RowIndex].Cells["TCkimlik"].Value.ToString();

                    var gerceklokasyon = dgvSatıcılar.PointToClient(Cursor.Position);
                    cMsSatıcı.Show(dgvSatıcılar, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void dgvMüşteriler_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvMüşteriler.Rows[e.RowIndex].Cells["MüşteriID"].Value != null && e.RowIndex <= dgvMüşteriler.Rows.Count - 2)
                {
                    dgvMüşteriler.ClearSelection();
                    dgvMüşteriler.Rows[e.RowIndex].Selected = true;
                    musteriID = int.Parse(dgvMüşteriler.Rows[e.RowIndex].Cells["MüşteriID"].Value.ToString());

                    var gerceklokasyon = dgvMüşteriler.PointToClient(Cursor.Position);
                    cMsMusteri.Show(dgvMüşteriler, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void dgvAdminler_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvAdminler.Rows[e.RowIndex].Cells["AdminID"].Value != null && e.RowIndex <= dgvAdminler.Rows.Count - 2)
                {
                        dgvAdminler.ClearSelection();
                        dgvAdminler.Rows[e.RowIndex].Selected = true;
                        adminID = int.Parse(dgvAdminler.Rows[e.RowIndex].Cells["AdminID"].Value.ToString());

                        var gerceklokasyon = dgvAdminler.PointToClient(Cursor.Position);
                        cMsAdmin.Show(dgvAdminler, gerceklokasyon);                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void dgvOdemeler_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvOdemeler.Rows[e.RowIndex].Cells["ÖdemeID"].Value != null && e.RowIndex <= dgvOdemeler.Rows.Count - 2)
                {
                    dgvOdemeler.ClearSelection();
                    dgvOdemeler.Rows[e.RowIndex].Selected = true;
                    odemeID = int.Parse(dgvOdemeler.Rows[e.RowIndex].Cells["ÖdemeID"].Value.ToString());

                    var gerceklokasyon = dgvOdemeler.PointToClient(Cursor.Position);
                    cMsOdeme.Show(dgvOdemeler, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void dgvKiralamalar_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvKiralamalar.Rows[e.RowIndex].Cells["KiralamaID"].Value != null && e.RowIndex <= dgvKiralamalar.Rows.Count - 2)
                {
                    dgvKiralamalar.ClearSelection();
                    dgvKiralamalar.Rows[e.RowIndex].Selected = true;
                    kiralamaID = int.Parse(dgvKiralamalar.Rows[e.RowIndex].Cells["KiralamaID"].Value.ToString());

                    var gerceklokasyon = dgvKiralamalar.PointToClient(Cursor.Position);
                    cMsKiralama.Show(dgvKiralamalar, gerceklokasyon);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mouse tıklamasında bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }



        private void adminiGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminID == -1)
                {
                    return;
                }
                Objeler.Admin ad3 = new Objeler.Admin();
                ad3 = ad3.AdminiAdminIDyeGoreCagir(adminID);
                if(ad3 != null)
                {
                    Formlar.Admin_Guncelle form = new Admin_Guncelle(ad3);
                    form.ShowDialog();

                    dgvAdminler.DataSource = ad1.ButunAdminleriCagir();
                    if (ad1.ButunAdminleriCagir().Rows.Count < 1)
                    {
                        dgvAdminler.DataSource = null;
                    }

                    ad3 = ad3.AdminiAdminIDyeGoreCagir(ad1.AdminID);
                    lblAdminID.Text = ad3.AdminID.ToString();
                    lblisim.Text = ad3.KullanıcıAdı;
                    lblMail.Text = ad3.EMail;
                }
                else
                {
                    MessageBox.Show("Admin bulunamadı. ", "Sistem Mesajı", MessageBoxButtons.OK);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Admin güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void kiralamayıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiralamaID == -1)
                {
                    return;
                }
                Objeler.Kiralama k3 = new Objeler.Kiralama();
                k3 = k3.KiralamayıIDyeGoreCagir(kiralamaID);
                if (k3 != null)
                {
                    Formlar.Kiralama_Guncelle form = new Kiralama_Guncelle(k3,ad1);
                    form.ShowDialog();

                    dgvKiralamalar.DataSource = k1.ButunKiralamalarıCagir();
                    if (k1.ButunKiralamalarıCagir().Rows.Count < 1)
                    {
                        dgvKiralamalar.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("Kiralama bulunamadı. ", "Sistem Mesajı", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiralama güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void ödemeyiGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (odemeID == -1)
                {
                    return;
                }
                Objeler.Ödeme o3 = new Objeler.Ödeme();
                o3 = o3.OdemeyiIDyeGoreCagir(odemeID);

                Objeler.Müşteri m3 = new Objeler.Müşteri();
                m3 = m3.MusteriyiIDyeGoreCagir(o3.MusteriID);

                Objeler.Kiralama k3 = new Objeler.Kiralama();
                k3 = k3.KiralamayıIDyeGoreCagir(o3.KiralamaID);

                if (o3 != null)
                {
                    Formlar.Ödeme_Guncelle form = new Ödeme_Guncelle(k3, m3, o3, ad1);
                    form.ShowDialog();

                    dgvOdemeler.DataSource = o1.ButunOdemeleriCagir();
                    if (o1.ButunOdemeleriCagir().Rows.Count < 1)
                    {
                        dgvOdemeler.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("Ödeme bulunamadı. ", "Sistem Mesajı", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void müşteriyiGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (musteriID == -1)
                {
                    return;
                }
                Objeler.Müşteri m3 = new Objeler.Müşteri();
                m3 = m3.MusteriyiIDyeGoreCagir(musteriID);
                if (m3 != null)
                {
                    Formlar.Musteri_Guncelle form = new Musteri_Guncelle(m3, ad1);
                    form.ShowDialog();

                    dgvMüşteriler.DataSource = m1.ButunMusterileriCagir();
                    if (m1.ButunMusterileriCagir().Rows.Count < 1)
                    {
                        dgvMüşteriler.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri bulunamadı. ", "Sistem Mesajı", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void satıcıyıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (satıcıID == "-1")
                {
                    return;
                }
                Objeler.Satıcı s3 = new Objeler.Satıcı();
                s3 = s3.SatıcıyıTCyeGoreCagir(satıcıID);
                if (s3 != null)
                {
                    Formlar.Satıcı_Guncelle form = new Satıcı_Guncelle(s3, ad1);
                    form.ShowDialog();

                    dgvSatıcılar.DataSource = s1.ButunSatıcılarıCagir();
                    if (s1.ButunSatıcılarıCagir().Rows.Count < 1)
                    {
                        dgvSatıcılar.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("Satıcı bulunamadı. ", "Sistem Mesajı", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Satıcı güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void aracıGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sasiID == "-1")
                {
                    return;
                }

                Objeler.Araç a3 = new Objeler.Araç();
                a3 = a3.AracıŞasiIDyeGoreCagir(sasiID);

                Objeler.Satıcı s3 = new Objeler.Satıcı();
                s3 = s3.SatıcıyıTCyeGoreCagir(a3.TCkimlik);

                if (a3 != null && s3 != null)
                {
                    Formlar.Arac_Guncelle form = new Arac_Guncelle(s3, a3, ad1);
                    form.ShowDialog();

                    dgvAraçlar.DataSource = a1.ButunAraçlarıCagir();
                    if (a1.ButunAraçlarıCagir().Rows.Count < 1)
                    {
                        dgvAraçlar.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("Araç ya da satıcı bulunamadı. ", "Sistem Mesajı", MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Aracı güncelleme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }


        private void adminiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (adminID == -1)
                {
                    return;
                }
                var sonuc = MessageBox.Show("Admini silmek istediğinize emin misiniz?", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    if(adminID == 1)
                    {
                        MessageBox.Show("Ana admini silemezsiniz.", "Sistem Mesajı", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (ad1.AdminSil(adminID) > 0)
                        {
                            MessageBox.Show("Admin başarıyla silindi.", "Sistem Mesajı", MessageBoxButtons.OK);

                            dgvAdminler.DataSource = ad1.ButunAdminleriCagir();
                            if (ad1.ButunAdminleriCagir().Rows.Count < 1)
                            {
                                dgvAdminler.DataSource = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Admin silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);

                            dgvAdminler.DataSource = ad1.ButunAdminleriCagir();
                            if (ad1.ButunAdminleriCagir().Rows.Count < 1)
                            {
                                dgvAdminler.DataSource = null;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Admin silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void kiralamayıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (kiralamaID == -1)
                {
                    return;
                }
                var sonuc = MessageBox.Show("Kiralamayı silmek istediğinize emin misiniz?", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    Objeler.Kiralama k3 = new Objeler.Kiralama();
                    if (k3.KiralamaSil(kiralamaID) > 0)
                    {
                        MessageBox.Show("Kiralama başarıyla silindi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvKiralamalar.DataSource = k1.ButunKiralamalarıCagir();
                        if (k1.ButunKiralamalarıCagir().Rows.Count < 1)
                        {
                            dgvKiralamalar.DataSource = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kiralama silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvKiralamalar.DataSource = k1.ButunKiralamalarıCagir();
                        if (k1.ButunKiralamalarıCagir().Rows.Count < 1)
                        {
                            dgvKiralamalar.DataSource = null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Kiralama silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void ödemeyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (odemeID == -1)
                {
                    return;
                }
                var sonuc = MessageBox.Show("Ödemeyi silmek istediğinize emin misiniz?", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    Objeler.Ödeme o3 = new Objeler.Ödeme();
                    if (o3.OdemeSil(odemeID) > 0)
                    {
                        MessageBox.Show("Ödeme başarıyla silindi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvOdemeler.DataSource = o1.ButunOdemeleriCagir();
                        if (o1.ButunOdemeleriCagir().Rows.Count < 1)
                        {
                            dgvOdemeler.DataSource = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ödeme silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvOdemeler.DataSource = o1.ButunOdemeleriCagir();
                        if (o1.ButunOdemeleriCagir().Rows.Count < 1)
                        {
                            dgvOdemeler.DataSource = null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ödeme silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void müşteriyiSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (musteriID == -1)
                {
                    return;
                }
                var sonuc = MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    Objeler.Müşteri m3 = new Objeler.Müşteri();
                    if (m3.MusteriSil(musteriID) > 0)
                    {
                        MessageBox.Show("Müşteri başarıyla silindi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvMüşteriler.DataSource = m1.ButunMusterileriCagir();
                        if (m1.ButunMusterileriCagir().Rows.Count < 1)
                        {
                            dgvMüşteriler.DataSource = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Müşteri silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvMüşteriler.DataSource = m1.ButunMusterileriCagir();
                        if (m1.ButunMusterileriCagir().Rows.Count < 1)
                        {
                            dgvMüşteriler.DataSource = null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Müşteri silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void satıcıyıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (satıcıID == "-1")
                {
                    return;
                }
                var sonuc = MessageBox.Show("Satıcıyı silmek istediğinize emin misiniz?", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    Objeler.Satıcı s3 = new Objeler.Satıcı();
                    if (s3.SatıcıSil(satıcıID) > 0)
                    {
                        MessageBox.Show("Satıcı başarıyla silindi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvSatıcılar.DataSource = s1.ButunSatıcılarıCagir();
                        if (s1.ButunSatıcılarıCagir().Rows.Count < 1)
                        {
                            dgvSatıcılar.DataSource = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hata satıcı silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvSatıcılar.DataSource = s1.ButunSatıcılarıCagir();
                        if (s1.ButunSatıcılarıCagir().Rows.Count < 1)
                        {
                            dgvSatıcılar.DataSource = null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Satıcı silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void aracıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (sasiID == "-1")
                {
                    return;
                }
                var sonuc = MessageBox.Show("Aracı silmek istediğinize emin misiniz?", "Sistem mesajı", MessageBoxButtons.YesNo);
                if (sonuc == DialogResult.Yes)
                {
                    Objeler.Araç a3 = new Objeler.Araç();
                    if (a3.AraçSil(sasiID) > 0)
                    {
                        MessageBox.Show("Araç başarıyla silindi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvAraçlar.DataSource = a1.ButunAraçlarıCagir();
                        if (a1.ButunAraçlarıCagir().Rows.Count < 1)
                        {
                            dgvAraçlar.DataSource = null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hata araç silinemedi.", "Sistem Mesajı", MessageBoxButtons.OK);

                        dgvAraçlar.DataSource = a1.ButunAraçlarıCagir();
                        if (a1.ButunAraçlarıCagir().Rows.Count < 1)
                        {
                            dgvAraçlar.DataSource = null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Aracı silme seçiminde bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
    }
}
