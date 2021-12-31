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
    public partial class musteri_satıcı_login : Form
    {
        Objeler.Müşteri m1 = new Objeler.Müşteri();
        Objeler.Satıcı s1 = new Objeler.Satıcı();
        Form someForm;
        public musteri_satıcı_login(Form ParentForm, Objeler.Müşteri m2, Objeler.Satıcı s2)
        {
            InitializeComponent();
            m1 = m2;
            s1 = s2;
            someForm = ParentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Satıcı_Login_Click(object sender, EventArgs e)
        {
            m1 = null;
            Formlar.Anasayfa form = new Formlar.Anasayfa(m1, s1);
            form.Show();
            this.Close();
            someForm.Hide();
        }

        private void Musteri_Login_Click(object sender, EventArgs e)
        {
            s1 = null;
            Formlar.Anasayfa form = new Formlar.Anasayfa(m1, s1);
            form.Show();
            this.Hide();
            someForm.Hide();
        }
    }
}
