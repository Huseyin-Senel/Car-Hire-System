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
    public partial class Anasayfa : Form
    {
        Objeler.Müşteri m1;
        Objeler.Satıcı s1;
        public Anasayfa(Objeler.Müşteri mus, Objeler.Satıcı sat)
        {
            InitializeComponent();
            m1 = mus;
            s1 = sat;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }


        private void Anasayfa_Load(object sender, EventArgs e)
        {
            if (m1 != null)
            {
                AnaPanel.Controls.Clear();
                Formlar.Araclar_AS form = new Formlar.Araclar_AS(m1);
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                form.AutoScroll = true;
                AnaPanel.Controls.Add(form);
                form.Show();
                form.BringToFront();
                araclarButon.BackColor = Color.FromArgb(30, 0, 40);
            }
            else
            {
                AnaPanel.Controls.Clear();
                Formlar.Satıcı_AS form = new Formlar.Satıcı_AS(s1);
                form.Dock = DockStyle.Fill;
                form.TopLevel = false;
                form.AutoScroll = true;
                AnaPanel.Controls.Add(form);
                form.Show();
                form.BringToFront();
                hesabımButon.BackColor = Color.FromArgb(30, 0, 40);
            }
        }


        private void cikisButon_Click(object sender, EventArgs e)
        {
            Formlar.Login form = new Formlar.Login();
            form.Show();
            this.Close();
        }
        private void araclarButon_Click(object sender, EventArgs e)
        {
            try
            {
                Buton_Back_Color(((Button)sender).Name);

                if(s1 == null)
                {
                    AnaPanel.Controls.Clear();
                    Formlar.Araclar_AS form = new Formlar.Araclar_AS(m1);
                    form.Dock = DockStyle.Fill;
                    form.TopLevel = false;
                    form.AutoScroll = true;
                    AnaPanel.Controls.Add(form);
                    form.Show();
                    form.BringToFront();
                }
                else 
                {
                    AnaPanel.Controls.Clear();
                    Formlar.Araclar_AS form = new Formlar.Araclar_AS();
                    form.Dock = DockStyle.Fill;
                    form.TopLevel = false;
                    form.AutoScroll = true;
                    AnaPanel.Controls.Add(form);
                    form.Show();
                    form.BringToFront();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Araçlar sayfası açılırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }
        private void hesabımButon_Click(object sender, EventArgs e)
        {
            try
            {
                Buton_Back_Color(((Button)sender).Name);

                if (m1 != null)
                {
                    AnaPanel.Controls.Clear();
                    Formlar.Müşteri_AS form = new Formlar.Müşteri_AS(m1);
                    form.Dock = DockStyle.Fill;
                    form.TopLevel = false;
                    form.AutoScroll = true;
                    AnaPanel.Controls.Add(form);
                    form.Show();
                    form.BringToFront();
                }
                else
                {
                    AnaPanel.Controls.Clear();
                    Formlar.Satıcı_AS form = new Formlar.Satıcı_AS(s1);
                    form.Dock = DockStyle.Fill;
                    form.TopLevel = false;
                    form.AutoScroll = true;
                    AnaPanel.Controls.Add(form);
                    form.Show();
                    form.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesap sayfası açılırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }


        private void Buton_Back_Color(string name)
        {
            try
            {
                foreach (var control in üstPanel.Controls)
                {
                    if (control is Button)
                    {
                        var btn = (Button)control;
                        if (btn.Name == name)
                        {
                            btn.BackColor = Color.FromArgb(30, 0, 40);
                        }
                        else
                        {
                            btn.BackColor = Color.Black;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Butona basılırken bir hata oluştu \n" + ex.Message, "Sistem Mesajı", MessageBoxButtons.OK);
            }
        }

    }
}
