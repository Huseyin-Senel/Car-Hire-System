using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public class Adres
    {
        private string evAdresi;
        private string ili;
        private string ilçesi;
        private string ülkesi;

        public Adres(string evAdresi, string ili, string ilçesi, string ülkesi)
        {
            this.EvAdresi = evAdresi;
            this.Ili = ili;
            this.Ilçesi = ilçesi;
            this.Ülkesi = ülkesi;
        }
        public  Adres()
        {

        }

        public string EvAdresi { get => evAdresi; 
            set
            {
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    throw new Exception("Ev adresi boş olamaz");
                }
                else if (value.Trim().Length > 500)
                {
                    throw new Exception("Ev adresi en fazla 500 karakter olabilir");
                }
                evAdresi = value.Trim();
            }
        }
        public string Ili { get => ili; set => ili = value.Trim(); }
        public string Ilçesi { get => ilçesi; 
            set
            {
                if (string.IsNullOrEmpty(value.Trim()) || value.All(char.IsDigit))
                {
                    throw new Exception("ilçe adı boş olamaz ya da rakam içeremez");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("ilçe adı fazla 30 harf olabilir");
                }
                ilçesi = value.Trim();
            }
        }
        public string Ülkesi { get => ülkesi;
            set
            {
                if (string.IsNullOrEmpty(value.Trim()) || value.All(char.IsDigit))
                {
                    throw new Exception("Ülke adı boş olamaz ya da rakam içeremez");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("Ülke adı fazla 30 harf olabilir");
                }
                ülkesi = value.Trim();
            }
        }
    }
}
