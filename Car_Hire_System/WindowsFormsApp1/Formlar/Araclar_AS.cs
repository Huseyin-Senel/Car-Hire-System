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
    public partial class Araclar_AS : Form
    {
        Objeler.Müşteri m1 = new Objeler.Müşteri();
        string SasiID = null;
        public Araclar_AS(Objeler.Müşteri m2 = null)
        {
            InitializeComponent();
            cbVitesTuru.SelectedIndex = 0;
            cbKasko.SelectedIndex = 0;
            cbHavaYastigi.SelectedIndex = 0;
            AraçlarıDGVyeCagir();
            m1 = m2;
            if(m1 == null)
            {
                btnKirala.Visible = false;
                btnKirala.Enabled = false;
                lblBilgi.Visible = true;
                lblBilgi2.Visible = true;
            }
            else 
            {
                btnKirala.Visible = true;
                btnKirala.Enabled = true;
                lblBilgi.Visible = false;
                lblBilgi2.Visible = false;
            }
        }

        private void tbRenk_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender,e);
        }
        private void tbYakıtTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.HarfYaz(sender, e);
        }
        private void tbBagajHacmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.RakamDegerYaz(sender, e,tbBagajHacmi);
        }
        private void tbBagajHacmiMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            Objeler.FormYardımcisi.RakamDegerYaz(sender, e, tbBagajHacmiMax);
        }


        private void btnFiltrele_Click(object sender, EventArgs e)
        {
            AraçlarıDGVyeCagir();
        }
        private void btnExcel1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvAraçlar, "Araçlar");
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Araçlar", dgvAraçlar);
        }
        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            AraçlarıDGVyeCagir();
        }
        private void btnKirala_Click(object sender, EventArgs e)
        {
            if (SasiID == null || lblTeklifBitişTarihi.Text == "")
            {
                return;
            }
            Formlar.Ödeme form = new Formlar.Ödeme(SasiIDyeGoreBosKiralamayıCgir(SasiID), m1);
            form.ShowDialog();

            AraçlarıDGVyeCagir();
        }
        private void dgvAraçlar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SasiID == null || lblTeklifBitişTarihi.Text == "")
            {
                return;
            }
            Formlar.Ödeme form = new Formlar.Ödeme(SasiIDyeGoreBosKiralamayıCgir(SasiID), m1);
            form.ShowDialog();

            AraçlarıDGVyeCagir();
        }

        private void dgvAraçlar_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                Objeler.Kiralama k1 = new Objeler.Kiralama();
                if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == MouseButtons.Right && dgvAraçlar.Rows[e.RowIndex].Cells[0].Value != null && m1 != null)
                {
                    dgvAraçlar.ClearSelection();
                    dgvAraçlar.Rows[e.RowIndex].Selected = true;
                    SasiID = dgvAraçlar.SelectedRows[0].Cells["ŞasiID"].Value.ToString();

                    if (String.IsNullOrEmpty(SasiID))
                    {
                        SasiID = dgvAraçlar.Rows[dgvAraçlar.SelectedRows[0].Index-1].Cells["ŞasiID"].Value.ToString();
                    }

                    var gerceklokasyon = dgvAraçlar.PointToClient(Cursor.Position);
                    contextMenuStrip1.Show(dgvAraçlar, gerceklokasyon);

                    k1 = SasiIDyeGoreBosKiralamayıCgir(SasiID);
                    lblTeklifBaşlangıçTarihi.Text = k1.TeklifBaslangicTarihi;
                    lblTeklifBitişTarihi.Text = k1.TeklifBitisTarihi.ToString();
                    lblYasSınırı.Text = k1.YasSınırı.ToString();
                    lblTeklifFiyatı.Text = k1.GunlukTeklifFiyati.ToString();
                }
                else if(e.ColumnIndex != -1 && e.RowIndex != -1 && dgvAraçlar.Rows[e.RowIndex].Cells[0].Value != null && e.RowIndex + 1 <= dgvAraçlar.Rows.Count)
                {
                    dgvAraçlar.ClearSelection();
                    dgvAraçlar.Rows[e.RowIndex].Selected = true;
                    SasiID = dgvAraçlar.SelectedRows[0].Cells["ŞasiID"].Value.ToString();
                    if (String.IsNullOrEmpty(SasiID))
                    {
                        SasiID = dgvAraçlar.Rows[dgvAraçlar.SelectedRows[0].Index - 1].Cells["ŞasiID"].Value.ToString(); //SasiID = dgvAraçlar.Rows[dgvAraçlar.CurrentCell.RowIndex - 1].Cells["ŞasiID"].Value.ToString();
                    }
                    k1 = SasiIDyeGoreBosKiralamayıCgir(SasiID);
                    lblTeklifBaşlangıçTarihi.Text = k1.TeklifBaslangicTarihi;
                    lblTeklifBitişTarihi.Text = k1.TeklifBitisTarihi.ToString();
                    lblYasSınırı.Text = k1.YasSınırı.ToString();
                    lblTeklifFiyatı.Text = k1.GunlukTeklifFiyati.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hücreye tıklanırken bir hata oluştu \n" + ex.Message, "Sitem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void kiralaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Formlar.Ödeme form = new Formlar.Ödeme(SasiIDyeGoreBosKiralamayıCgir(SasiID), m1);
            form.ShowDialog();

            AraçlarıDGVyeCagir();
        }



        private DataTable Filtrele1()
        {
            try
            {
                if (tbBagajHacmi.Text.Trim() != "" || tbBagajHacmiMax.Text.Trim() != "")
                {
                    if (tbBagajHacmi.Text.Trim() != "" && tbBagajHacmiMax.Text.Trim() != "")
                    {
                        if (float.Parse(tbBagajHacmi.Text.Trim()) > float.Parse(tbBagajHacmiMax.Text.Trim()))
                        {
                            tbBagajHacmiMax.Text = tbBagajHacmi.Text;
                        }
                    }
                    else
                    {
                        if (tbBagajHacmi.Text.Trim() != "")
                        {
                            tbBagajHacmiMax.Text = tbBagajHacmi.Text;
                        }
                        else
                        {
                            tbBagajHacmi.Text = "0";
                        }
                    }
                }
                else
                {
                    tbBagajHacmi.Text = "0";
                    tbBagajHacmiMax.Text = "10000";
                }

                if (nUdKoltukSayısı.Value > nUdKoltukSayisiMax.Value)
                {
                    nUdKoltukSayisiMax.Value = nUdKoltukSayısı.Value;
                }

                string strCbHavaYastıgı;
                if (cbHavaYastigi.GetItemText(cbHavaYastigi.SelectedItem) == "Hepsi")
                {
                    strCbHavaYastıgı = "";
                }
                else
                {
                    strCbHavaYastıgı = cbHavaYastigi.GetItemText(cbHavaYastigi.SelectedItem);
                }
                string strCbVitesTürü;
                if (cbVitesTuru.GetItemText(cbVitesTuru.SelectedItem) == "Hepsi")
                {
                    strCbVitesTürü = "";
                }
                else
                {
                    strCbVitesTürü = cbVitesTuru.GetItemText(cbVitesTuru.SelectedItem);
                }
                string strCbKaso;
                if (cbKasko.GetItemText(cbKasko.SelectedItem) == "Hepsi")
                {
                    strCbKaso = "";
                }
                else
                {
                    strCbKaso = cbKasko.GetItemText(cbKasko.SelectedItem);
                }

                Objeler.Araç a1 = new Objeler.Araç();
                return a1.AraclarıFiltrele(tbModel.Text.Trim(), tbMarka.Text.Trim(),
                    tbYakıtTuru.Text.Trim(), strCbVitesTürü, float.Parse(tbBagajHacmi.Text.Trim()),      //filtreli araçlar
                    float.Parse(tbBagajHacmiMax.Text.Trim()), tbRenk.Text.Trim(),
                    (int)nUdKoltukSayısı.Value, (int)nUdKoltukSayisiMax.Value, strCbKaso, strCbHavaYastıgı);
            }
            catch (Exception ex)
            {

                throw new Exception("Araç filtreleme hatası" + ex.Message);
            }
        }
        private void AraçlarıDGVyeCagir()
        {
            try
            {
                Objeler.Kiralama k1 = new Objeler.Kiralama();
                Objeler.Ödeme o1 = new Objeler.Ödeme();
                Objeler.Araç a1 = new Objeler.Araç();
                DataTable dt1 = new DataTable();

                dt1 = Filtrele1();

                DataTable dt2 = new DataTable();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dt2.Merge(k1.KiralamaSasiIDyeGoreCagir(dt1.Rows[i]["ŞasiID"].ToString()));
                }


                DataRow row;
                for (int i = 0; i < dt2.Rows.Count; i++)
                {

                    if (o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt2.Rows[i]["KiralamaID"].ToString())) != null)
                    {
                        o1 = o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt2.Rows[i]["KiralamaID"].ToString()));
                        row = dt2.Rows[i];
                        row.Delete();
                    }
                }
                dt2.AcceptChanges();      //ödemesi olmayan filtreli araç kiralamaları


                DataRow row2;
                bool var = false;
                int firstRowCount = dt1.Rows.Count;
                for (int i = 0; i < firstRowCount; i++)
                {
                    row2 = dt1.Rows[i];
                    var = false;
                    for (int k = 0; k < dt2.Rows.Count; k++)
                    {

                        if (dt1.Rows[i]["ŞasiID"].ToString() == a1.AracıŞasiIDyeGoreCagir(dt2.Rows[k]["ŞasiID"].ToString()).SasiID)
                        {
                            var = true;
                        }
                    }
                    if (!var)
                    {
                        row2.Delete();
                    }
                }
                dt1.AcceptChanges();     //ödmesi olmayan filtreli araçlar

                if (dt1.Rows.Count > 0)
                {
                    dgvAraçlar.DataSource = dt1;
                    dgvAraçlar.Columns[12].Visible = false;
                    dgvAraçlar.Columns[13].Visible = false;
                    dgvAraçlar.Columns[14].Visible = false;

                    SasiID = dgvAraçlar.Rows[0].Cells["ŞasiID"].Value.ToString();
                    k1 = SasiIDyeGoreBosKiralamayıCgir(SasiID);
                    lblTeklifBaşlangıçTarihi.Text = k1.TeklifBaslangicTarihi;
                    lblTeklifBitişTarihi.Text = k1.TeklifBitisTarihi.ToString();
                    lblYasSınırı.Text = k1.YasSınırı.ToString();
                    lblTeklifFiyatı.Text = k1.GunlukTeklifFiyati.ToString();

                }
                else 
                {
                    dgvAraçlar.DataSource = null;
                    dgvAraçlar.Refresh();

                    lblTeklifBaşlangıçTarihi.Text = "";
                    lblTeklifBitişTarihi.Text = "";
                    lblYasSınırı.Text = "";
                    lblTeklifFiyatı.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Araçları çağırırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }

        }
        private Objeler.Kiralama SasiIDyeGoreBosKiralamayıCgir(string sasiID)
        {
            try
            {
                Objeler.Kiralama k1 = new Objeler.Kiralama();
                Objeler.Ödeme o1 = new Objeler.Ödeme();
                DataTable dt1 = new DataTable();
                dt1 = k1.KiralamaSasiIDyeGoreCagir(sasiID);

                DataRow row2;
                int firstRowCount = dt1.Rows.Count;
                for (int i = 0; i < firstRowCount; i++)
                {
                    row2 = dt1.Rows[i];

                    if (o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt1.Rows[i]["KiralamaID"].ToString())) != null)
                    {
                        row2.Delete();
                    }
                }
                dt1.AcceptChanges();

                return k1.KiralamayıIDyeGoreCagir(int.Parse(dt1.Rows[0]["KiralamaID"].ToString()));
            }
            catch (Exception ex )
            {

                throw new Exception("Boş kiralama çağrılırken bir haya oluştu." + ex.Message);
            }        
        }

        
    }
}
