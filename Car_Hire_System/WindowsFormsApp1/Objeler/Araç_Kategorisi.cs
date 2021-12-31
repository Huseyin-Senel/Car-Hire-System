using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public class Araç_Kategorisi
    {
        private int kategoriID;
        private string kategoriAciklamasi;
        private string kategoriAdı;
        private int adminID;

        public Araç_Kategorisi()
        { }
        public Araç_Kategorisi(int kategoriID, string kategoriAciklamasi, string kategoriAdı, int adminID)
        {
            this.KategoriID = kategoriID;
            this.KategoriAciklamasi = kategoriAciklamasi;
            this.KategoriAdı = kategoriAdı;
            this.AdminID = adminID;
        }

        public int KategoriID { get => kategoriID; set => kategoriID = value; }
        public string KategoriAciklamasi { get => kategoriAciklamasi; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Kategori açıklaması boş olamaz.");
                }
                else if (value.Trim().Length > 500)
                {
                    throw new Exception("Kategori açıklaması en fazla 500 karakter olabilir.");
                }
                kategoriAciklamasi = value;
            } 
        }
        public string KategoriAdı { get => kategoriAdı; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Kategori ismi boş olamaz.");
                }
                else if(value.Trim().Length>30)
                {
                    throw new Exception("Kategori ismi en fazla 30 karakter olabilir.");
                }
                kategoriAdı = value;
            } 
        }
        public int AdminID { get => adminID; set => adminID = value; }



        public DataTable ButunKategorileriCagir()
        {
            try
            {
                string sorgu = "select * from AraçKategorisi";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategorileri çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KategoriAdlarınıCagir()
        {
            try
            {
                string sorgu = "select KategoriAdı from AraçKategorisi";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategorileri çağırma hatası. \n" + ex.Message);
            }
        }
        public Araç_Kategorisi KategoriyiIDyeGoreCagir(int ID)
        {
            Araç_Kategorisi k1 = null;
            try
            {
                DataTable dt = new DataTable();
                string sorgu = $"select * from AraçKategorisi where KategoriID={ID}";
                dt = DBController.Sorgula(sorgu);

                if (dt.Rows.Count > 0) 
                {
                    k1.KategoriID = int.Parse(dt.Rows[0]["KategoriID"].ToString());
                    k1.kategoriAdı = dt.Rows[0]["KategoriAdı"].ToString();
                    k1.kategoriAciklamasi = dt.Rows[0]["KategoriAçıklaması"].ToString();

                    if (dt.Rows[0]["AdminID"].ToString() == "") { k1.AdminID = 0; }
                    else { k1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString()); }

                    return k1;
                }
                else
                {
                    return k1;
                }              
            }
            catch (Exception ex)
            {
                throw new Exception("Kategoriyi ID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KategoriyiAdminIDyeGoreCagir(int AdminID)
        {
            try
            {
                string sorgu = $"select * from AraçKategorisi where AdminID={AdminID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategoriyi adminID'ye Göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KategorileriIsmeGoreCagir(string name)
        {
            try
            {
                string sorgu = $"select * from AraçKategorisi where KategoriAdı LIKE '%{name}%'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategorileri isme göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KategorileriTamIsmeGoreCagir(string name)
        {
            try
            {
                string sorgu = $"select * from AraçKategorisi where KategoriAdı = '{name}'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategori ismini çağırma hatası. \n" + ex.Message);
            }
        }
        public int KategorEkle(Araç_Kategorisi k1)
        {
            try
            {
                if (KategorileriTamIsmeGoreCagir(k1.KategoriAdı).Rows.Count>0)
                {
                    throw new Exception("Bu kategori zaten var.");
                }
                string sorgu = $"INSERT INTO AraçKategorisi(KategoriAdı, KategoriAçıklaması, AdminID)" +
                        $"VALUES('{k1.KategoriAdı}','{k1.KategoriAciklamasi}',{k1.AdminID})";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategori ekleme hatası. \n" + ex.Message);
            }
        }  
        public int KategoriGüncelleme(Araç_Kategorisi k1)
        {
            try
            {
                string sorgu = $"UPDATE AraçKategorisi SET KategoriAçıklaması = '{k1.KategoriAciklamasi}', " +
                    $"AdminID = {k1.AdminID} WHERE KategoriID = {k1.KategoriID}";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategori güncelleme hatası. \n" + ex.Message);
            }
        }  
        public int KategoriSil(int KategoriID)
        {
            try
            {
                string sorgu = $"DELETE AraçKategorisi WHERE KategoriID={KategoriID}";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kategori silme hatası. \n" + ex.Message);
            }
        }  

    }
}
