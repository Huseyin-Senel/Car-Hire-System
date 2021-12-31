using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public abstract class Insan
    {
        private string adı;
        private string soyadı;
        private string cinsiyeti;
        private int yası;
        private string eMailAdresi;
        private string telefonNumarası;
        private Adres adres;
        private string sifresi;
        private byte[] resim;

        public Insan(string adı, string soyadı, string cinsiyeti, int yası,
            string eMailAdresi, string telefonNumarası, Adres adres, string sifresi, byte[] resim)
        {
            this.Adı = adı;
            this.Soyadı = soyadı;
            this.Cinsiyeti = cinsiyeti;
            this.Yası = yası;
            this.EMailAdresi = eMailAdresi;
            this.TelefonNumarası = telefonNumarası;
            this.Adres = adres;
            this.Sifresi = sifresi;
            this.Resim = resim;
        }
        public Insan() { }

        public string Adı
        {
          
            get { return adı; }

            set
            {
                if (string.IsNullOrEmpty(value) || value.All(char.IsDigit))
                {
                    throw new Exception("İsim rakam içeremez veya boş olamaz");
                }
                else if (value.Trim().Length > 30) 
                {
                    throw new Exception("İsim en fazla 30 harf olabilir");
                }
                adı = value.Trim();
            }
        }
        public string Soyadı
        {
            get { return soyadı; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.All(char.IsDigit))
                {
                    throw new Exception("Soyisim rakam içeremez veya boş olamaz");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("Soyisim en fazla 30 harf olabilir");
                }
                soyadı = value.Trim();
            }
        }    
        public string Cinsiyeti { get => cinsiyeti; set => cinsiyeti = value; }
        public int Yası { get => yası; set => yası = value; }
        public string EMailAdresi { get => eMailAdresi;
            set 
            {
                if (String.IsNullOrEmpty(value.Trim()))
                {
                    throw new Exception("E-mail adresi boş olamaz.");
                }
                else if(!value.Contains('@'))
                {
                    throw new Exception("Geçerli bir E-mail adresi giriniz.");
                }
                else if (value.Trim().Length > 50)
                {
                    throw new Exception("E-mail en fazla 50 karakter olabilir");
                }
                eMailAdresi = value.Trim(); 
            } 
        }
        public string TelefonNumarası 
        { 
            get => telefonNumarası;
            set 
            {
                if (value.Trim().Length < 14 || value.Trim().Length > 14)
                {
                    throw new Exception("Telefon numarası 10 rakamdan oluşmalı.");
                }
                else if(value.All(char.IsLetter))
                {
                    throw new Exception("Telefon numarası sadece rakam içerebilir.");
                }
                telefonNumarası = value; 
            } 
        }
        public string Sifresi 
        { 
            get => sifresi; 
            set 
            {
                if (value.Trim().Length < 8)
                {
                    throw new Exception("Şifre en az 8 karakter olmalı");
                }
                else if (value.Trim().Length > 50)
                {
                    throw new Exception("şifre en fazla 50 karakter olabilir");
                }
                sifresi = value.Trim();
            } 
        }
        public Adres Adres { get => adres; set => adres = value; }
        public byte[] Resim { get => resim; 
            set 
            {
                if (value == null || value.ToString().Length <= 0)
                {
                    throw new Exception("Resim boş olamaz.");
                }
                resim = value;
            } 
        }
    }
}
