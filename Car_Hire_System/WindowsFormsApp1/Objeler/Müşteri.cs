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
    public class Müşteri : Insan
    {
        private int musteriID;
        private int adminID;

        public Müşteri(int musteriID, int adminID, string adı, string soyadı, string cinsiyeti,
            int yası, string eMailAdresi, string telefonNumarası, Adres adres, string sifresi, byte[] resim)
            : base(adı, soyadı, cinsiyeti, yası, eMailAdresi, telefonNumarası, adres, sifresi, resim)                      
        {
            this.MusteriID = musteriID;
            this.AdminID = adminID;
        }
        public Müşteri() {}

        public int MusteriID { get => musteriID; set => musteriID = value; }
        public int AdminID { get => adminID; set => adminID = value; }


        private Müşteri MusteriObjeOlustur(Müşteri m1,String sorgu)
        {
            DataTable dt = new DataTable();
            dt = DBController.Sorgula(sorgu);

            if (dt.Rows.Count > 0)
            {
                Objeler.Adres a1 = new Objeler.Adres();
                m1 = new Objeler.Müşteri();

                a1.EvAdresi = dt.Rows[0]["EvAdresi"].ToString();
                a1.Ili = dt.Rows[0]["İli"].ToString();
                a1.Ilçesi = dt.Rows[0]["İlçesi"].ToString();
                a1.Ülkesi = dt.Rows[0]["Ülkesi"].ToString();
                m1.Adres = a1;

                m1.MusteriID = int.Parse(dt.Rows[0]["MüşteriID"].ToString());
                m1.Adı = dt.Rows[0]["Adı"].ToString();
                m1.Soyadı = dt.Rows[0]["Soyadı"].ToString();
                m1.Cinsiyeti = dt.Rows[0]["Cinsiyeti"].ToString();
                m1.Yası = int.Parse(dt.Rows[0]["Yaşı"].ToString());
                m1.EMailAdresi = dt.Rows[0]["EmailAdresi"].ToString();
                m1.TelefonNumarası = dt.Rows[0]["TelefonNumarası"].ToString();
                m1.Sifresi = dt.Rows[0]["Şifresi"].ToString(); 
                if((dt.Rows[0]["Resim"]) != null && (dt.Rows[0]["Resim"]).ToString().Length > 0)
                {
                    if((Byte[])(dt.Rows[0]["Resim"]) != null && ((Byte[])dt.Rows[0]["Resim"]).ToString().Length > 0)
                    {
                        m1.Resim = (Byte[])(dt.Rows[0]["Resim"]);
                    }
                    else
                    {
                        MemoryStream stream = new MemoryStream();
                        Properties.Resources.user_120px.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        m1.Resim = stream.ToArray();
                    }
                }
                else
                {
                    MemoryStream stream = new MemoryStream();
                    Properties.Resources.user_120px.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    m1.Resim = stream.ToArray();
                }
                if (dt.Rows[0]["AdminID"].ToString() == "") { m1.AdminID = 0; }
                else { m1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString()); }
                return m1;
            }
            else
            {
                return m1;
            }
        }


        public DataTable ButunMusterileriCagir()
        {
            try
            {
                string sorgu = "select * from Müşteri";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşterileri çağırma hatası. \n" + ex.Message);
            }
        }
        public Müşteri MusteriyiIDyeGoreCagir(int ID)
        {
            Müşteri m1 = null;
            try
            {
                string sorgu = $"select * from Müşteri where MüşteriID={ID}";
                return MusteriObjeOlustur(m1, sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşteriyi ID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public Müşteri MusteriyiTelefonaGoreCagir(string telefon)
        {
            Müşteri m1 = null;
            try
            {
                string sorgu = $"select * from Müşteri where TelefonNumarası = '{telefon}'";
                return MusteriObjeOlustur(m1, sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşteri telefonunu çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable MusterileriAdminIDyeGoreCagir(int AdminID)
        {
            try
            {
                string sorgu = $"select * from Müşteri where AdminID={AdminID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşteriyi adminID'ye Göre çağırma hatası . \n" + ex.Message);
            }
        }
        public DataTable MusterileriIsmeGoreCagir(string name)
        {
            try
            {
                string sorgu = $"select * from Müşteri where Adı LIKE '%{name}%'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşterileri isme göre çağırma hatası. \n" + ex.Message);
            }
        }
        public Müşteri MusteriyiMaileGoreCagir(string mail)
        {
            Müşteri m1 = null;
            try
            {
                string sorgu = $"select * from Müşteri where EmailAdresi = '{mail}'";
                return MusteriObjeOlustur(m1, sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşterileri maile göre çağırma hatası . \n" + ex.Message);
            }
        }      
        public Müşteri MusteriLogin(string email, string sifre) 
        {
            Müşteri m1 = null;
            try
            {
                string sorgu = $"select * from Müşteri where EmailAdresi = '{email}' AND şifresi =  '{sifre}'";
                return MusteriObjeOlustur(m1, sorgu);
            }
            catch (Exception ex )
            {
                throw new Exception("Müşteri giriş hatası . \n" + ex.Message);
            }
        }
        public int Müşteri_Ekle(Müşteri m1) 
        {
            try
            {
                Objeler.Admin a1 = new Objeler.Admin();
                string sorgu;
                if(MusteriyiMaileGoreCagir(m1.EMailAdresi) !=null || a1.AdminMailCagir(m1.EMailAdresi) != null)
                {
                    throw new Exception("Bu mail zaten kullanılıyor.");
                }
                else if (MusteriyiTelefonaGoreCagir(m1.TelefonNumarası) != null)
                {
                    throw new Exception("Bu telefon numarası zaten kullanılıyor.");
                }

                SqlParameter[] parameters = new SqlParameter[13];
                if (m1.AdminID == 0) 
                {

                    sorgu = $"INSERT INTO Müşteri(Adı, Soyadı, Cinsiyeti, Yaşı, EmailAdresi, TelefonNumarası, EvAdresi, İli, İlçesi, Ülkesi, Şifresi, Resim)" +
                       $"VALUES(@Adı, @Soyadı, @Cinsiyeti, @Yaşı, @EmailAdresi, @TelefonNumarası, @EvAdresi, @İli, @İlçesi, @Ülkesi, @Şifresi, @Resim)";

                    parameters[0] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[0].Value = m1.Adı;
                    parameters[1] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[1].Value = m1.Soyadı;
                    parameters[2] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[2].Value = m1.Cinsiyeti;
                    parameters[3] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[3].Value = m1.Yası;
                    parameters[4] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[4].Value = m1.EMailAdresi;
                    parameters[5] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[5].Value = m1.TelefonNumarası;
                    parameters[6] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[6].Value = m1.Adres.EvAdresi;
                    parameters[7] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[7].Value = m1.Adres.Ili;
                    parameters[8] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[8].Value = m1.Adres.Ilçesi;
                    parameters[9] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = m1.Adres.Ülkesi;
                    parameters[10] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[10].Value = m1.Sifresi;
                    parameters[11] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[11].Value = m1.Resim;
                    parameters[12] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[12].Value = DBNull.Value;
                }
                else
                {
                    sorgu = $"INSERT INTO Müşteri(Adı, Soyadı, Cinsiyeti, Yaşı, EmailAdresi, TelefonNumarası, EvAdresi, İli, İlçesi, Ülkesi, Şifresi, Resim, AdminID)" +
                       $"VALUES(@Adı, @Soyadı, @Cinsiyeti, @Yaşı, @EmailAdresi, @TelefonNumarası, @EvAdresi, @İli, @İlçesi, @Ülkesi, @Şifresi, @AdminID, @Resim)";

                    parameters[0] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[0].Value = m1.Adı;
                    parameters[1] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[1].Value = m1.Soyadı;
                    parameters[2] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[2].Value = m1.Cinsiyeti;
                    parameters[3] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[3].Value = m1.Yası;
                    parameters[4] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[4].Value = m1.EMailAdresi;
                    parameters[5] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[5].Value = m1.TelefonNumarası;
                    parameters[6] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[6].Value = m1.Adres.EvAdresi;
                    parameters[7] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[7].Value = m1.Adres.Ili;
                    parameters[8] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[8].Value = m1.Adres.Ilçesi;
                    parameters[9] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = m1.Adres.Ülkesi;
                    parameters[10] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[10].Value = m1.Sifresi;
                    parameters[11] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[11].Value = m1.AdminID;                   
                    parameters[12] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[12].Value = m1.Resim;                            
                }
               
                return DBController.intSorgula(sorgu,parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşteri ekleme hatası . \n" + ex.Message);
            }
        }
        public int müşteri_güncelleme(Müşteri m1)
        {            
            try
            {
                Objeler.Admin a1 = new Objeler.Admin();
                string sorgu;
                if (MusteriyiMaileGoreCagir(m1.EMailAdresi) != null || a1.AdminMailCagir(m1.EMailAdresi) != null) 
                {
                    if(MusteriyiMaileGoreCagir(m1.EMailAdresi).MusteriID != m1.MusteriID)
                    {
                        throw new Exception("Bu mail başkası tarafından kullanılıyor.");
                    }                   
                }
                else if (MusteriyiTelefonaGoreCagir(m1.TelefonNumarası) != null)
                {
                    if(MusteriyiTelefonaGoreCagir(m1.TelefonNumarası).MusteriID != m1.MusteriID)
                    {
                        throw new Exception("Bu telefon numarası başkası tarafından kullanılıyor.");
                    }                    
                }

                SqlParameter[] parameters = new SqlParameter[14]; ;
                if (m1.AdminID == 0) 
                {
                    sorgu = $"UPDATE Müşteri SET Adı = @Adı ,Soyadı = @Soyadı ,Cinsiyeti = @Cinsiyeti ,Yaşı = @Yaşı ," +
                       $"EmailAdresi = @EmailAdresi ,TelefonNumarası = @TelefonNumarası ,EvAdresi = @EvAdresi, İli = @İli ," +
                       $"İlçesi = @İlçesi ,Ülkesi = @Ülkesi ,Şifresi = @Şifresi ,Resim = @Resim WHERE MüşteriID = @MüşteriID";

                    parameters[0] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[0].Value = m1.Adı;
                    parameters[1] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[1].Value = m1.Soyadı;
                    parameters[2] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[2].Value = m1.Cinsiyeti;
                    parameters[3] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[3].Value = m1.Yası;
                    parameters[4] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[4].Value = m1.EMailAdresi;
                    parameters[5] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[5].Value = m1.TelefonNumarası;
                    parameters[6] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[6].Value = m1.Adres.EvAdresi;
                    parameters[7] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[7].Value = m1.Adres.Ili;
                    parameters[8] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[8].Value = m1.Adres.Ilçesi;
                    parameters[9] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = m1.Adres.Ülkesi;
                    parameters[10] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[10].Value = m1.Sifresi;
                    parameters[11] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[11].Value = m1.Resim;
                    parameters[12] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[12].Value = m1.AdminID;
                    parameters[13] = new SqlParameter("@MüşteriID", SqlDbType.Int);
                    parameters[13].Value = m1.MusteriID;
                }
                else
                {
                    sorgu = $"UPDATE Müşteri SET Adı = @Adı ,Soyadı = @Soyadı ,Cinsiyeti = @Cinsiyeti ,Yaşı = @Yaşı ," +
                       $"EmailAdresi = @EmailAdresi ,TelefonNumarası = @TelefonNumarası ,EvAdresi = @EvAdresi, İli = @İli ," +
                       $"İlçesi = @İlçesi ,Ülkesi = @Ülkesi ,Şifresi = @Şifresi ,AdminID = @AdminID ,Resim = @Resim WHERE MüşteriID = @MüşteriID";

                    parameters[0] = new SqlParameter("@Adı", SqlDbType.VarChar, 30);
                    parameters[0].Value = m1.Adı;
                    parameters[1] = new SqlParameter("@Soyadı", SqlDbType.VarChar, 30);
                    parameters[1].Value = m1.Soyadı;
                    parameters[2] = new SqlParameter("@Cinsiyeti", SqlDbType.VarChar, 6);
                    parameters[2].Value = m1.Cinsiyeti;
                    parameters[3] = new SqlParameter("@Yaşı", SqlDbType.Int);
                    parameters[3].Value = m1.Yası;
                    parameters[4] = new SqlParameter("@EmailAdresi", SqlDbType.VarChar, 50);
                    parameters[4].Value = m1.EMailAdresi;
                    parameters[5] = new SqlParameter("@TelefonNumarası", SqlDbType.VarChar, 20);
                    parameters[5].Value = m1.TelefonNumarası;
                    parameters[6] = new SqlParameter("@EvAdresi", SqlDbType.VarChar, 500);
                    parameters[6].Value = m1.Adres.EvAdresi;
                    parameters[7] = new SqlParameter("@İli", SqlDbType.VarChar, 30);
                    parameters[7].Value = m1.Adres.Ili;
                    parameters[8] = new SqlParameter("@İlçesi", SqlDbType.VarChar, 30);
                    parameters[8].Value = m1.Adres.Ilçesi;
                    parameters[9] = new SqlParameter("@Ülkesi", SqlDbType.VarChar, 30);
                    parameters[9].Value = m1.Adres.Ülkesi;
                    parameters[10] = new SqlParameter("@Şifresi", SqlDbType.VarChar, 50);
                    parameters[10].Value = m1.Sifresi;
                    parameters[11] = new SqlParameter("@AdminID", SqlDbType.Int);
                    parameters[11].Value = m1.AdminID;
                    parameters[12] = new SqlParameter("@Resim", SqlDbType.Image);
                    parameters[12].Value = m1.Resim;
                    parameters[13] = new SqlParameter("@MüşteriID", SqlDbType.Int);
                    parameters[13].Value = m1.MusteriID;
                }
                return DBController.intSorgula(sorgu, parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşteri güncelleme hatası . \n" + ex.Message);
            }          
        }
        public int MusteriSil(int MusteriID)
        {         
            try
            {
                string sorgu = $"DELETE Müşteri WHERE MüşteriID={MusteriID}";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Müşteri silme hatası. \n" + ex.Message);
            }
        }
    }   
}