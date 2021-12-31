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
    public partial class Araç_Seçin : Form
    {
        Objeler.Satıcı s1 = new Objeler.Satıcı();
        public Araç_Seçin(Objeler.Satıcı s2)
        {
            InitializeComponent();

            s1 = s2;
            kiralamasıOlmayanAraclarıDGVyeCagır();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvAraçlar.Rows.Count >0)
                {
                    string sasiID = dgvAraçlar.Rows[dgvAraçlar.CurrentCell.RowIndex].Cells["ŞasiID"].Value.ToString();
                    if (sasiID != null)
                    {
                        Objeler.Araç a1 = new Objeler.Araç();
                        Formlar.Kiralama form = new Formlar.Kiralama(a1.AracıŞasiIDyeGoreCagir(sasiID));
                        form.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen bir araç seçin ", "Sistem Mesajı", MessageBoxButtons.OK);
                    }
                }
                
            }
            catch (Exception ex )
            {
                MessageBox.Show("Kiralma açılırken bir hata oluştu \n" + ex.Message, "Sitem Mesajı", MessageBoxButtons.OK);
            }
            
        }


        private void kiralamasıOlmayanAraclarıDGVyeCagır()
        {
            try
            {
                Objeler.Ödeme o1 = new Objeler.Ödeme();
                Objeler.Araç a1 = new Objeler.Araç();
                DataTable dt1 = new DataTable();
                Objeler.Kiralama k1 = new Objeler.Kiralama();
                dt1 = a1.AraçlarıTCyeGoreCagir(s1.TCkimlik); ;


                DataTable dt2 = new DataTable();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dt2.Merge(k1.KiralamaSasiIDyeGoreCagir(dt1.Rows[i]["ŞasiID"].ToString()));
                }

                DataRow row2;
                int ilkSatirSayisi = dt1.Rows.Count;

                for (int i = 0; i < ilkSatirSayisi; i++) //araç sayısı
                {
                    for (int k = 0; k < dt2.Rows.Count; k++) //kiralama sayısı
                    {
                        if (dt1.Rows[i]["ŞasiID"].ToString() == a1.AracıŞasiIDyeGoreCagir(dt2.Rows[k]["ŞasiID"].ToString()).SasiID) //Kiralama bulunduysa
                        {
                            if(o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt2.Rows[k]["KiralamaID"].ToString())) == null)
                            {
                                row2 = dt1.Rows[i];
                                row2.Delete();
                                k = dt2.Rows.Count + 1; //aracı silerse diğer araca geçmek için
                            }
                            else if(o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt2.Rows[k]["KiralamaID"].ToString())) != null
                            && o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt2.Rows[k]["KiralamaID"].ToString())).KiralamaDurumu == "Devam Ediyor")
                            {
                                row2 = dt1.Rows[i];
                                row2.Delete();
                                k = dt2.Rows.Count + 1; //aracı silerse diğer araca geçmek için
                            }
                        }
                    }
                }
                dt1.AcceptChanges();


                if (dt1.Rows.Count > 0)
                {
                    dgvAraçlar.DataSource = dt1;
                    dgvAraçlar.Columns[12].Visible = false;
                    dgvAraçlar.Columns[13].Visible = false;
                    dgvAraçlar.Columns[14].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Araçlar çağrılırken bir hata oluştu \n" + ex.Message, "System message", MessageBoxButtons.OK);
            }
        
        }

        private void btnRefresh1_Click(object sender, EventArgs e)
        {
            kiralamasıOlmayanAraclarıDGVyeCagır();
        }
        private void btnPrint1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.PrintDGV("Araçlar", dgvAraçlar);
        }
        private void btnExcel1_Click(object sender, EventArgs e)
        {
            Objeler.FormYardımcisi.ExcelYazdır(dgvAraçlar, "Araçlar");
        }
    }
}
