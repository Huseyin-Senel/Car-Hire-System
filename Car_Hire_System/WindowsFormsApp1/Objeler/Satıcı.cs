using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public class Satıcı:Insan
    {
        private string tCkimlik;       
        private int adminID;

        public Satıcı() { }
        public Satıcı(string tCkimlik, int adminID, string adı, string soyadı, string cinsiyeti, 
            int yası, string eMailAdresi, string telefonNumarası, Adres adres, string sifresi, byte[] resim)
            :base(adı, soyadı, cinsiyeti, yası, eMailAdresi, telefonNumarası, adres, sifresi, resim)
           
        {
            this.TCkimlik = tCkimlik;
            this.AdminID = adminID;
        }


        public string TCkimlik { get => tCkimlik; 
            set 
            {
                if (value.All(char.IsLetter))
                {
                    throw new Exception("TC kimlik numarası harf içeremez.");
                }
                else if (string.IsNullOrEmpty(value) || value.Length < 11 || value.Length > 11)
                {
                    throw new Exception("TC kimlik numarası 11 rakam içermelidir.");
                }
                tCkimlik = value; 
            } 
        }
        public int AdminID { get => adminID; set => adminID = value; }


        private Satıcı SatıcıObjeOlustur(Satıcı s1,string sorgu)
        {
            DataTable dt = new DataTable();
            dt = DBController.Sorgula(sorgu);

            if (dt.Rows.Count > 0)
            {
                Objeler.Adres a1 = new Objeler.Adres();
                s1 = new Objeler.Satıcı();

                a1.EvAdresi = dt.Rows[0]["EvAdresi"].ToString();
                a1.Ili = dt.Rows[0]["İli"].ToString();
                a1.Ilçesi = dt.Rows[0]["İlçesi"].ToString();
                a1.Ülkesi = dt.Rows[0]["Ülkesi"].ToString();
                s1.Adres = a1;

                s1.TCkimlik = dt.Rows[0]["TCkimlik"].ToString();
                s1.Adı = dt.Rows[0]["Adı"].ToString();
                s1.Soyadı = dt.Rows[0]["Soyadı"].ToString();
                s1.Cinsiyeti = dt.Rows[0]["Cinsiyeti"].ToString();
                s1.Yası = int.Parse(dt.Rows[0]["Yaşı"].ToString());
                s1.EMailAdresi = dt.Rows[0]["EmailAdresi"].ToString();
                s1.TelefonNumarası = dt.Rows[0]["TelefonNumarası"].ToString();
                s1.Sifresi = dt.Rows[0]["Şifresi"].ToString();

                if ((dt.Rows[0]["Resim"]) != null && (dt.Rows[0]["Resim"]).ToString().Length > 0)
                {
                    if ((Byte[])(dt.Rows[0]["Resim"]) != null && ((Byte[])dt.Rows[0]["Resim"]).ToString().Length > 0)
                    {
                        s1.Resim = (Byte[])(dt.Rows[0]["Resim"]);
                    }
                    else
                    {
                        MemoryStream stream = new MemoryStream();
                        Properties.Resources.user_120px.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        s1.Resim = stream.ToArray();
                    }
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    Properties.Resources.user_120px.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    s1.Resim = stream.ToArray();
                }
                if (dt.Rows[0]["AdminID"].ToString() == "") { s1.AdminID = 0; }
                else { s1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString()); }
                return s1;
            }
            else
            {
                return s1;
            }
        }

        public DataTable ButunSatıcılarıCagir()
        {
            try
            {
                string sorgu = "select * from Satıcı";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcıları çağırma hatası. \n" + ex.Message);
            }
        }
        public Satıcı SatıcıyıTCyeGoreCagir(string TCkimlik)
        {
            Satıcı s1 = null;
            try
            {                
               string sorgu = $"select * from Satıcı where TCkimlik='{TCkimlik}'";
               return SatıcıObjeOlustur(s1, sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcı TC'sini çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable SatıcıIsmeGoreCagir(string name)
        {
            try
            {
                string sorgu = $"select * from Satıcı where Adı LIKE '%{name}%'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcıları isme göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable SatıcıAdminIDyeGoreCagir(int AdminID)
        {
            try
            {
                string sorgu = $"select * from Satıcı where AdminID = {AdminID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcıları adminID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public Satıcı SatıcıyıMaileGoreCagir(string mail)
        {
            Satıcı s1 = null;
            try
            {
                string sorgu = $"select * from Satıcı where EmailAdresi = '{mail}'";
                return SatıcıObjeOlustur(s1,sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcı mailini çağırma hatası. \n" + ex.Message);
            }
        }
        public Satıcı SatıcıyıTelefonaGoreCagir(string telefon)
        {
            Satıcı s1 = null;
            try
            {
                string sorgu = $"select * from Satıcı where TelefonNumarası = '{telefon}'";
                return SatıcıObjeOlustur(s1, sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcı telefonunu çağırma hatası. \n" + ex.Message);
            }
        }
        public Satıcı SatıcıLogin(string email, string sifre)
        {
            Satıcı s1 = null;
            try
            {
                string sorgu = $"select * from Satıcı where EmailAdresi = '{email}' AND şifresi =  '{sifre}'";
                return SatıcıObjeOlustur(s1, sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcı giriş hatası. \n" + ex.Message);
            }
        }
        public int Satıcı_Ekle(Satıcı s1)
        {
            try
            {
                Objeler.Admin a1 = new Objeler.Admin();
                string sorgu;
                if (SatıcıyıTCyeGoreCagir(s1.TCkimlik) != null)
                {
                    throw new Exception("Bu TC kimlik zaten kullanılıyor.");
                }
                else if (SatıcıyıMaileGoreCagir(s1.EMailAdresi) != null || a1.AdminMailCagir(s1.EMailAdresi) != null)
                {
                    throw new Exception("Bu mail zaten kullanılıyor.");
                }
                else if (SatıcıyıTelefonaGoreCagir(s1.TelefonNumarası) != null)
                {
                    throw new Exception("Bu telefon numarası zaten kullanılıyor.");
                }

                SqlParameter[] parameters = new SqlParameter[14];
                if (s1.AdminID == 0) 
                {
                    sorgu = $"INSERT INTO Satıcı(TCkimlik, Adı, Soyadı, Cinsiyeti, Yaşı, EmailAdresi, TelefonNumarası, EvAdresi, İli, İlçesi, Ülkesi, Şifresi, Resim)" +
                        $"VALUES(@TCkimlik, @Adı, @Soyadı, @Cinsiyeti, @Yaşı, @EmailAdresi, @TelefonNumarası, @EvAdresi, @İli, @İlçesi, @Ülkesi, @Şifresi, @Resim)";     

                    parameters[0] = new SqlParameter("@TCkimlik", SqlDbType.VarChar, 11);
                    parameters[0].Value = s1.TCkimlik;
                    parameters[1] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[1].Value = s1.Adı;
                    parameters[2] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[2].Value = s1.Soyadı;
                    parameters[3] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[3].Value = s1.Cinsiyeti;
                    parameters[4] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[4].Value = s1.Yası;
                    parameters[5] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[5].Value = s1.EMailAdresi;
                    parameters[6] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[6].Value = s1.TelefonNumarası;
                    parameters[7] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[7].Value = s1.Adres.EvAdresi;
                    parameters[8] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[8].Value = s1.Adres.Ili;
                    parameters[9] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = s1.Adres.Ilçesi;
                    parameters[10] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[10].Value = s1.Adres.Ülkesi;
                    parameters[11] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[11].Value = s1.Sifresi;
                    parameters[12] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[12].Value = s1.Resim;
                    parameters[13] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[13].Value = s1.AdminID;
                }
                else
                {
                    sorgu = $"INSERT INTO Satıcı(TCkimlik, Adı, Soyadı, Cinsiyeti, Yaşı, EmailAdresi, TelefonNumarası, EvAdresi, İli, İlçesi, Ülkesi, Şifresi, AdminID, Resim)" +
                        $"VALUES(@TCkimlik, @Adı, @Soyadı, @Cinsiyeti, @Yaşı, @EmailAdresi, @TelefonNumarası, @EvAdresi, @İli, @İlçesi, @Ülkesi, @Şifresi, @AdminID, @Resim)";

                    parameters[0] = new SqlParameter("@TCkimlik", SqlDbType.VarChar, 11);
                    parameters[0].Value = s1.TCkimlik;
                    parameters[1] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[1].Value = s1.Adı;
                    parameters[2] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[2].Value = s1.Soyadı;
                    parameters[3] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[3].Value = s1.Cinsiyeti;
                    parameters[4] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[4].Value = s1.Yası;
                    parameters[5] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[5].Value = s1.EMailAdresi;
                    parameters[6] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[6].Value = s1.TelefonNumarası;
                    parameters[7] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[7].Value = s1.Adres.EvAdresi;
                    parameters[8] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[8].Value = s1.Adres.Ili;
                    parameters[9] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = s1.Adres.Ilçesi;
                    parameters[10] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[10].Value = s1.Adres.Ülkesi;
                    parameters[11] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[11].Value = s1.Sifresi;
                    parameters[12] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[12].Value = s1.AdminID;
                    parameters[13] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[13].Value = s1.Resim;
                }
                
                return DBController.intSorgula(sorgu, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcı ekleme hatası. \n " + ex.Message);
            }
        }
        public int Satıcı_güncelleme(Satıcı s1)
        {
            try
            {
                Objeler.Admin a1 = new Objeler.Admin();
                string sorgu;
                if (SatıcıyıMaileGoreCagir(s1.EMailAdresi) != null  || a1.AdminMailCagir(s1.EMailAdresi) != null)
                {
                    if(SatıcıyıMaileGoreCagir(s1.EMailAdresi).TCkimlik != s1.TCkimlik)
                    {
                        throw new Exception("Bu mail başkası tarafından kullanılıyor.");
                    }                    
                }
                else if (SatıcıyıTelefonaGoreCagir(s1.TelefonNumarası) != null)
                {
                    if(SatıcıyıTelefonaGoreCagir(s1.TelefonNumarası).tCkimlik != s1.TCkimlik)
                    {
                        throw new Exception("Bu telefon numarası başkası tarafından kullanılıyor.");
                    }                   
                }

                SqlParameter[] parameters = new SqlParameter[14];
                if (s1.AdminID == 0)
                {
                    sorgu = $"UPDATE Satıcı SET Adı = @Adı ,Soyadı = @Soyadı ,Cinsiyeti = @Cinsiyeti ,Yaşı = @Yaşı ," +
                        $"EmailAdresi = @EmailAdresi ,TelefonNumarası = @TelefonNumarası ,EvAdresi = @EvAdresi, İli = @İli," +
                        $"İlçesi = @İlçesi ,Ülkesi = @Ülkesi ,Şifresi = @Şifresi ,Resim = @Resim WHERE TCkimlik = @TCkimlik";

                    parameters[0] = new SqlParameter("@TCkimlik", SqlDbType.VarChar, 11);
                    parameters[0].Value = s1.TCkimlik;
                    parameters[1] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[1].Value = s1.Adı;
                    parameters[2] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[2].Value = s1.Soyadı;
                    parameters[3] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[3].Value = s1.Cinsiyeti;
                    parameters[4] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[4].Value = s1.Yası;
                    parameters[5] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[5].Value = s1.EMailAdresi;
                    parameters[6] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[6].Value = s1.TelefonNumarası;
                    parameters[7] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[7].Value = s1.Adres.EvAdresi;
                    parameters[8] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[8].Value = s1.Adres.Ili;
                    parameters[9] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = s1.Adres.Ilçesi;
                    parameters[10] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[10].Value = s1.Adres.Ülkesi;
                    parameters[11] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[11].Value = s1.Sifresi;
                    parameters[12] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[12].Value = s1.Resim;
                    parameters[13] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[13].Value = s1.AdminID;
                }
                else
                {
                    sorgu = $"UPDATE Satıcı SET Adı = @Adı ,Soyadı = @Soyadı ,Cinsiyeti = @Cinsiyeti ,Yaşı = @Yaşı ," +
                        $"EmailAdresi = @EmailAdresi ,TelefonNumarası = @TelefonNumarası ,EvAdresi = @EvAdresi, İli = @İli," +
                        $"İlçesi = @İlçesi ,Ülkesi = @Ülkesi ,Şifresi = @Şifresi ,AdminID = @AdminID, Resim = @Resim WHERE TCkimlik = @TCkimlik";

                    parameters[0] = new SqlParameter("@TCkimlik", SqlDbType.VarChar, 11);
                    parameters[0].Value = s1.TCkimlik;
                    parameters[1] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[1].Value = s1.Adı;
                    parameters[2] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[2].Value = s1.Soyadı;
                    parameters[3] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[3].Value = s1.Cinsiyeti;
                    parameters[4] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[4].Value = s1.Yası;
                    parameters[5] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[5].Value = s1.EMailAdresi;
                    parameters[6] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[6].Value = s1.TelefonNumarası;
                    parameters[7] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[7].Value = s1.Adres.EvAdresi;
                    parameters[8] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[8].Value = s1.Adres.Ili;
                    parameters[9] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = s1.Adres.Ilçesi;
                    parameters[10] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[10].Value = s1.Adres.Ülkesi;
                    parameters[11] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[11].Value = s1.Sifresi;
                    parameters[12] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[12].Value = s1.AdminID;
                    parameters[13] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[13].Value = s1.Resim;
                }
                
                return DBController.intSorgula(sorgu, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcı güncelleme hatası. \n" + ex.Message);
            }
        }
        public int SatıcıSil(string TCkimlik)
        {
            try
            {
                string sorgu = $"DELETE Satıcı WHERE TCkimlik='{TCkimlik}'";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Satıcı silme hatası. \n" + ex.Message);
            }
        }
    }
}
