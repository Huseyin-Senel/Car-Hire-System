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
    public partial class Aracı_Görüntüle : Form
    {
        Objeler.Araç a1 = new Objeler.Araç();
        public Aracı_Görüntüle(Objeler.Araç a2)
        {
            InitializeComponent();
            a1 = a2;

            lblŞasiNumarası.Text = a1.SasiID;
            lblMarka.Text = a1.Marka;
            lblModel.Text = a1.Model;
            lblMevcutKilometre.Text = a1.MevcutKilometresi.ToString();
            lblMotorGucu.Text = a1.MotorGucu.ToString();
            lblYakıtTürü.Text = a1.YakitTuru;
            lblVitesTürü.Text = a1.VitesTuru;
            lblBagajHacmi.Text = a1.BagajHacmi.ToString();
            lblRengi.Text = a1.Rengi;
            lblKoltukSayısı.Text = a1.KoltukSayisi.ToString();
            lblKaskoDurumu.Text = a1.KaskoDurumu;
            lblHavaYastığıDurumu.Text = a1.HavaYastigiDurumu;
            MemoryStream mem = new MemoryStream(a1.Resim1);
            pictureBox2.Image = Image.FromStream(mem);
        }

        private void iptalBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
