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
    public partial class musteri_satıcı : Form
    {
        Form someForm;
        public musteri_satıcı(Form ParentForm)
        {
            InitializeComponent();
            someForm = ParentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Satıcı_Kayit_Click(object sender, EventArgs e)
        {
            Objeler.Admin a1 = new Objeler.Admin();
            Formlar.Satici_Kayit form = new Formlar.Satici_Kayit();
            form.Show();
            this.Close();
            someForm.Hide();
        }

        private void Musteri_Kayit_Click(object sender, EventArgs e)
        {
            Objeler.Admin a1 = new Objeler.Admin();
            Formlar.Musteri_Kayit form = new Formlar.Musteri_Kayit();
            form.Show();
            this.Close();
            someForm.Hide();
        }
    }
}
