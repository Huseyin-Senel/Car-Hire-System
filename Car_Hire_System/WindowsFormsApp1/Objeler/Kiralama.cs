using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public class Kiralama
    {
        private int kiralamaID;
        private string teklifBaslangicTarihi;
        private string teklifBitisTarihi;
        private float gunlukTeklifFiyati;
        private int yasSınırı;
        private string sasiID;
        private int adminID;

        public Kiralama()
        { }
        public Kiralama(int kiralamaID, string teklifBaslangicTarihi,
            string teklifBitisTarihi , float gunlukTeklifFiyati, int yasSınırı, string sasiID, int adminID)
        {
            this.KiralamaID = kiralamaID;
            this.TeklifBaslangicTarihi = teklifBaslangicTarihi;
            this.TeklifBitisTarihi = teklifBitisTarihi;
            this.GunlukTeklifFiyati = gunlukTeklifFiyati;
            this.YasSınırı = yasSınırı;
            this.SasiID = sasiID;
            this.AdminID = adminID;
        }

        public int KiralamaID { get => kiralamaID; set => kiralamaID = value; }
        public string TeklifBaslangicTarihi { get => teklifBaslangicTarihi; set => teklifBaslangicTarihi = value; }
        public string TeklifBitisTarihi { get => teklifBitisTarihi; set => teklifBitisTarihi = value; }
        public float GunlukTeklifFiyati 
        { 
            get => gunlukTeklifFiyati;
            set 
            { 
                if(value<=0)
                {
                    throw new Exception("teklif fiyatı 0 veya daha az olamaz.");
                }
                gunlukTeklifFiyati = value; 
            } 
        }
        public int YasSınırı { get => yasSınırı; set => yasSınırı = value; }
        public string SasiID { get => sasiID; set => sasiID = value; }
        public int AdminID { get => adminID; set => adminID = value; }



        public DataTable ButunKiralamalarıCagir()
        {
            try
            {
                string sorgu = "select * from Kiralama";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralamalar çağırma hatası. \n" + ex.Message);
            }
        }
        public Kiralama KiralamayıIDyeGoreCagir(int ID)
        {
            Kiralama k1 = null;
            try
            {
                string sorgu = $"select * from Kiralama where KiralamaID={ID}";
                DataTable dt = new DataTable();                  
                dt = DBController.Sorgula(sorgu);
                k1 = new Kiralama();

                if (dt.Rows.Count > 0) 
                {
                    k1.KiralamaID = int.Parse(dt.Rows[0]["KiralamaID"].ToString());
                    k1.TeklifBaslangicTarihi = dt.Rows[0]["TeklifBaslangıçTarihi"].ToString();
                    k1.TeklifBitisTarihi = dt.Rows[0]["TeklifBitişTarihi"].ToString();
                    k1.GunlukTeklifFiyati = float.Parse(dt.Rows[0]["GünlükTeklifFiyatı"].ToString());
                    k1.YasSınırı = int.Parse(dt.Rows[0]["YaşSınırı"].ToString());
                    k1.SasiID = dt.Rows[0]["ŞasiID"].ToString();

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
                throw new Exception("Kiralama ID'si çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KiralamaSasiIDyeGoreCagir(string SasiID)
        {
            try
            {
                string sorgu = $"select * from Kiralama where ŞasiID = '{SasiID}'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralamayı şasiID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KiralamalarıAdminIDyeGoreCagir(int AdminID)
        {
            try
            {
                string sorgu = $"select * from Kiralama where AdminID = {AdminID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralamaları adminID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KiralamalarıBaslangicTarihineGoreCagir(string time)
        {
            try
            {
                string sorgu = $"select * from Kiralama where TeklifBaşlangıçTarihi = '{time}'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralamaları başlangıç tarihine göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable KiralamalarıBitisTarihineGoreCagir(string time)
        {
            try
            {
                string sorgu = $"select * from Kiralama where TeklifBitişTarihi = '{time}'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralamaları bitiş tarihine göre çağırma hatası " + ex.Message);
            }
        }
        public int KiralamaEkle(Kiralama k1)
        {
            try
            {
                Objeler.Ödeme o1 = new Objeler.Ödeme();
                string sorgu;
                DataTable dt = new DataTable();
                dt = k1.KiralamaSasiIDyeGoreCagir(k1.SasiID);
                for (int i=0; i< dt.Rows.Count ;i++)
                {
                    if (o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt.Rows[i]["KiralamaID"].ToString())) == null                      
                        || o1.OdemeyiKiralamaIDyeGoreCagir(int.Parse(dt.Rows[i]["KiralamaID"].ToString())).KiralamaDurumu == "Devam Ediyor")
                    {
                        throw new Exception("Bu araç için zaten kiralama yapılmış.");
                    }
                    
                }


                if(k1.AdminID == 0)
                {
                    sorgu = $"INSERT INTO Kiralama(TeklifBaslangıçTarihi, TeklifBitişTarihi, GünlükTeklifFiyatı, YaşSınırı, ŞasiID)" +
                       $"VALUES('{k1.TeklifBaslangicTarihi}','{k1.TeklifBitisTarihi}',{k1.GunlukTeklifFiyati.ToString(new CultureInfo("en-US"))},{k1.YasSınırı},'{k1.SasiID}')";
                }
                else
                {
                    sorgu = $"INSERT INTO Kiralama(TeklifBaslangıçTarihi, TeklifBitişTarihi, GünlükTeklifFiyatı, YaşSınırı, ŞasiID, AdminID)" +
                       $"VALUES('{k1.TeklifBaslangicTarihi}','{k1.TeklifBitisTarihi}',{k1.GunlukTeklifFiyati.ToString(new CultureInfo("en-US"))},{k1.YasSınırı},'{k1.SasiID}',{k1.AdminID})";
                }
               
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralama ekleme hatası. \n" + ex.Message);
            }
        }
        public int KiralamaGüncelleme(Kiralama k1)
        {
            try
            {
                string sorgu;
                if (k1.AdminID == 0)
                {
                    sorgu = $"UPDATE Kiralama SET TeklifBaslangıçTarihi = '{k1.TeklifBaslangicTarihi}', " +
                    $"TeklifBitişTarihi = '{k1.TeklifBitisTarihi}', GünlükTeklifFiyatı = {k1.GunlukTeklifFiyati.ToString(new CultureInfo("en-US"))}, " +
                    $"YaşSınırı = {k1.YasSınırı}  WHERE KiralamaID = {k1.KiralamaID}";
                }
                else
                {
                    sorgu = $"UPDATE Kiralama SET TeklifBaslangıçTarihi = '{k1.TeklifBaslangicTarihi}', " +
                    $"TeklifBitişTarihi = '{k1.TeklifBitisTarihi}', GünlükTeklifFiyatı = {k1.GunlukTeklifFiyati.ToString(new CultureInfo("en-US"))}, " +
                    $"YaşSınırı = {k1.YasSınırı}, AdminID = {k1.AdminID} WHERE KiralamaID = {k1.KiralamaID}";
                }       

                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralama güncelleme hatası. \n" + ex.Message);
            }
        }
        public int KiralamaSil(int KiralamaID)
        {
            try
            {
                string sorgu = $"DELETE Kiralama WHERE KiralamaID = {KiralamaID}";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Kiralama silme hatası. \n" + ex.Message);
            }
        }
    }
}