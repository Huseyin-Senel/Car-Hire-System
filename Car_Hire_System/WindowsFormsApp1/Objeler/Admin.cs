using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public class Admin
    {
        private int adminID;
        private string kullanıcıAdı;
        private string sifre;
        private string eMail;

        public Admin()
        { }
        public Admin(int adminID, string kullanıcıAdı, string sifre, string eMail)
        {
            this.AdminID = adminID;
            this.KullanıcıAdı = kullanıcıAdı;
            this.Sifre = sifre;
            this.EMail = eMail;
        }

        public int AdminID { get => adminID; set => adminID = value; }
        public string KullanıcıAdı { get => kullanıcıAdı; set => kullanıcıAdı = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string EMail { get => eMail; set => eMail = value; }

        public DataTable ButunAdminleriCagir()
        {
            try
            {
                string sorgu = "select * from Admin";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Adminleri çağırma hatası. \n" + ex.Message);
            }
        }
        public Admin AdminLogin(string email, string sifre)
        {
            Admin ad1 = null;
            try
            {
                DataTable dt = new DataTable();
                string sorgu = $"select * from Admin where Email = '{email}' AND Şifre =  '{sifre}'";
                dt = DBController.Sorgula(sorgu);

                if (dt.Rows.Count > 0)
                {
                    ad1 = new Objeler.Admin();

                    ad1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString());
                    ad1.KullanıcıAdı = dt.Rows[0]["KullanıcıAdı"].ToString();
                    ad1.EMail = dt.Rows[0]["Email"].ToString();
                    ad1.Sifre = dt.Rows[0]["Şifre"].ToString();

                    return ad1;
                }
                else
                {
                    return ad1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Addmin giriş hatası. \n" + ex.Message);
            }
        }
        public Admin AdminiAdminIDyeGoreCagir(int admin_ID)
        {
            Admin ad1 = null;
            try
            {
                DataTable dt = new DataTable();
                string sorgu = $"select * from Admin where AdminID = {admin_ID}";
                dt = DBController.Sorgula(sorgu);

                if (dt.Rows.Count > 0)
                {
                    ad1 = new Objeler.Admin();

                    ad1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString());
                    ad1.KullanıcıAdı = dt.Rows[0]["KullanıcıAdı"].ToString();
                    ad1.EMail = dt.Rows[0]["Email"].ToString();
                    ad1.Sifre = dt.Rows[0]["Şifre"].ToString();

                    return ad1;
                }
                else
                {
                    return ad1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Addmini ID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public Admin AdminMailCagir(string email)
        {
            Admin ad1 = null;
            try
            {
                DataTable dt = new DataTable();
                string sorgu = $"select * from Admin where Email = '{email}'";
                dt = DBController.Sorgula(sorgu);

                if (dt.Rows.Count > 0)
                {
                    ad1 = new Objeler.Admin();

                    ad1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString());
                    ad1.KullanıcıAdı = dt.Rows[0]["KullanıcıAdı"].ToString();
                    ad1.EMail = dt.Rows[0]["Email"].ToString();
                    ad1.Sifre = dt.Rows[0]["Şifre"].ToString();

                    return ad1;
                }
                else
                {
                    return ad1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Addmin mail çağırma hatası. \n" + ex.Message);
            }
        }
        public int Admin_Ekle(Admin ad1)
        {
            try
            {
                Objeler.Müşteri m1 = new Objeler.Müşteri();
                Objeler.Satıcı s1 = new Objeler.Satıcı();
                string sorgu;
                if (m1.MusteriyiMaileGoreCagir(ad1.EMail) != null || s1.SatıcıyıMaileGoreCagir(ad1.EMail) != null || ad1.AdminMailCagir(ad1.EMail) != null)
                {
                    throw new Exception("Bu mail zaten kullanılıyor.");
                }

                SqlParameter[] parameters = new SqlParameter[3];

                sorgu = $"INSERT INTO Admin(KullanıcıAdı, Şifre, Email)" +
                   $"VALUES(@KullanıcıAdı, @Şifre, @Email)";

                parameters[0] = new SqlParameter("@KullanıcıAdı", SqlDbType.VarChar, 50);
                parameters[0].Value = ad1.KullanıcıAdı;
                parameters[1] = new SqlParameter("@Şifre", SqlDbType.VarChar, 50);
                parameters[1].Value = ad1.Sifre;
                parameters[2] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                parameters[2].Value = ad1.EMail;

                return DBController.intSorgula(sorgu, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Admin ekleme hatası . \n" + ex.Message);
            }
        }
        public int Admin_güncelleme(Admin ad1)
        {
            try
            {
                Objeler.Müşteri m1 = new Objeler.Müşteri();
                Objeler.Satıcı s1 = new Objeler.Satıcı();

                string sorgu;
                if (m1.MusteriyiMaileGoreCagir(ad1.EMail) != null || s1.SatıcıyıMaileGoreCagir(ad1.EMail) != null)
                {
                    throw new Exception("Bu mail başkası tarafından kullanılıyor.");
                }
                else if(AdminMailCagir(ad1.EMail) != null)
                {
                    if (AdminMailCagir(ad1.EMail).AdminID != ad1.AdminID)
                    {
                        throw new Exception("Bu mail başkası tarafından kullanılıyor.");
                    }
                }

                SqlParameter[] parameters = new SqlParameter[4]; ;

                    sorgu = $"UPDATE Admin SET KullanıcıAdı = @KullanıcıAdı ,Şifre = @Şifre ,Email = @Email " +                      
                       $"WHERE AdminID = @AdminID";

                    parameters[0] = new SqlParameter("@KullanıcıAdı", SqlDbType.VarChar, 50);
                    parameters[0].Value = ad1.KullanıcıAdı;
                    parameters[1] = new SqlParameter("@Şifre", SqlDbType.VarChar, 50);
                    parameters[1].Value = ad1.Sifre;
                    parameters[2] = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                    parameters[2].Value = ad1.EMail;
                    parameters[3] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[3].Value = ad1.AdminID;
                   
                return DBController.intSorgula(sorgu, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex.Message);
            }
        }
        public int AdminSil(int AdminID)
        {
            try
            {
                string sorgu = $"DELETE Admin WHERE AdminID={AdminID}";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Admin silme hatası. \n" + ex.Message);
            }
        }


        public bool AdminMüşteriEkle(Müşteri m1, Admin a1) 
        {
            try
            {
                m1.AdminID = a1.AdminID;
                if (m1.Müşteri_Ekle(m1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin müşteri ekleme hatası. \n" + ex.Message);
            }

        }
        public bool AdminMüşteriGuncelle(Müşteri m1, Admin a1)
        {
            try
            {
                m1.AdminID = a1.AdminID;
                if (m1.müşteri_güncelleme(m1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin müşteri güncelleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminSatıcıGuncelle(Satıcı s1, Admin a1)
        {
            try
            {
                s1.AdminID = a1.AdminID;
                if (s1.Satıcı_güncelleme(s1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin satıcı güncelleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminSatıcıEkle(Satıcı s1, Admin a1)
        {
            try
            {
                s1.AdminID = a1.AdminID;
                if (s1.Satıcı_Ekle(s1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin satıcı ekleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminOdemeEkle(Ödeme o1, Admin a1)
        {
            try
            {
                o1.AdminID = a1.AdminID;
                if (o1.OdemeEkle(o1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin ödeme ekleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminOdemeGuncelle(Ödeme o1, Admin a1)
        {
            try
            {
                o1.AdminID = a1.AdminID;
                if (o1.OdemeGüncelleme(o1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin ödeme güncelleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminOdemeTamamla(Ödeme o1, Admin a1)
        {
            try
            {
                o1.AdminID = a1.AdminID;
                if (o1.OdemeTamamla(o1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin ödeme tamamlama hatası. \n" + ex.Message);
            }
        }
        public bool AdminKiralamaEkle(Kiralama k1, Admin a1)
        {
            try
            {
                k1.AdminID = a1.AdminID;
                if (k1.KiralamaEkle(k1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin kiralama ekleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminKiralamaGuncelle(Kiralama k1, Admin a1)
        {
            try
            {
                k1.AdminID = a1.AdminID;
                if (k1.KiralamaGüncelleme(k1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin kiralama güncelleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminKategoriEkle(Araç_Kategorisi k1, Admin a1)
        {
            try
            {
                k1.AdminID = a1.AdminID;
                if (k1.KategorEkle(k1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin kategori ekleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminKategoriGuncelle(Araç_Kategorisi k1, Admin a1)
        {
            try
            {
                k1.AdminID = a1.AdminID;
                if (k1.KategoriGüncelleme(k1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin Kategori güncelleme hatası. \n" + ex.Message);
            }
        }
        public bool AdminAracEkle(Araç a1, Admin ad1)
        {
            try
            {
                a1.AdminID = ad1.AdminID;
                if (a1.AraçEkle(a1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin araç eklenemedi hatası. \n" + ex.Message);
            }
        }
        public bool AdminAracGuncelle(Araç a1, Admin ad1)
        {
            try
            {
                a1.AdminID = ad1.AdminID;
                if (a1.AraçGüncelleme(a1) >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Admin araç güncelleme hatası. \n" + ex.Message);
            }
        }
    }
}
