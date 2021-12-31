using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public class Araç
    {
        private string sasiID;
        private string model;
        private string marka;
        private int mevcutKilometresi;
        private float motorGucu;
        private string yakitTuru;
        private string vitesTuru;
        private float bagajHacmi;
        private string rengi;
        private int koltukSayisi;
        private string kaskoDurumu;
        private string havaYastigiDurumu;
        private byte[] resim1;
        private string tCkimlik;
        private int kategoriID;
        private int adminID;

        public Araç()
        { }
        public Araç(string sasiID, string model, string marka, int mevcutKilometresi, float motorGucu,
            string yakitTuru, string vitesTuru, float bagajHacmi, string rengi,
            int koltukSayisi, string kaskoDurumu, string havaYastigiDurumu, string tCkimlik,
            int kategoriID,  int adminID, byte[] resim1)
        {
            this.SasiID = sasiID;
            this.Model = model;
            this.Marka = marka;
            this.MevcutKilometresi = mevcutKilometresi;
            this.MotorGucu = motorGucu;
            this.YakitTuru = yakitTuru;
            this.VitesTuru = vitesTuru;
            this.BagajHacmi = bagajHacmi;
            this.Rengi = rengi;
            this.KoltukSayisi = koltukSayisi;
            this.KaskoDurumu = kaskoDurumu;
            this.HavaYastigiDurumu = havaYastigiDurumu;
            this.Resim1 = resim1;
            this.TCkimlik = tCkimlik;
            this.KategoriID = kategoriID;
            this.AdminID = adminID;
        }

        public string SasiID 
        { 
            get => sasiID;
            set 
            {
                if (value.Trim().Length < 17 || value.Trim().Length > 17)
                {
                    throw new Exception("Şasi numarası 17 karakter olmalı");
                }
                sasiID = value; 
            } 
        }
        public string Model 
        { 
            get => model; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Model adı boş olamaz");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("model adı en fazla 30 karakter olabilir");
                }
                model = value; 
            } 
        }
        public string Marka 
        { 
            get => marka; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Marka adı boş olamaz");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("Marka adı en fazla 30 karakter olabilir");
                }
                marka = value; 
            } 
        }
        public int MevcutKilometresi 
        { 
            get => mevcutKilometresi; 
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Mevcut kilometre 0 dan daha az olamaz");
                }
                mevcutKilometresi = value; 
            }
        }
        public float MotorGucu 
        { 
            get => motorGucu; 
            set 
            {
                if (value<=0)
                {
                    throw new Exception("Motor gücü 0 ya da daha az olamaz");
                }
                motorGucu = value;
            }
        }
        public string YakitTuru 
        { 
            get => yakitTuru; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Yakıt türü boş olamaz");
                }
                else if (value.Trim().Length > 20)
                {
                    throw new Exception("Yakıt türü en fazla 20 karakter olabilir");
                }
                yakitTuru = value; 
            } 
        }
        public string VitesTuru { get => vitesTuru; set => vitesTuru = value; }
        public float BagajHacmi 
        { 
            get => bagajHacmi; 
            set 
            {
                if (value < 0)
                {
                    throw new Exception("Bagaj hacmi 0 dan daha az olamaz");
                }
                bagajHacmi = value; 
            } 
        }
        public string Rengi 
        { 
            get => rengi; 
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Renk adı boş olamaz");
                }
                else if (value.Trim().Length > 30)
                {
                    throw new Exception("Renk adı en fazla 30 karakter olabilir");
                }
                rengi = value; 
            } 
        }
        public int KoltukSayisi { get => koltukSayisi; set => koltukSayisi = value; }
        public string KaskoDurumu { get => kaskoDurumu; set => kaskoDurumu = value; }
        public string HavaYastigiDurumu { get => havaYastigiDurumu; set => havaYastigiDurumu = value; }
        public byte[] Resim1
        {
            get => resim1;
            set
            {
                if (value == null || value.ToString().Length <= 0)
                {
                    throw new Exception("Resim1 boş olamaz.");
                }
                resim1 = value;
            }
        }
        public string TCkimlik { get => tCkimlik; set => tCkimlik = value; }
        public int KategoriID { get => kategoriID; set => kategoriID = value; }
        public int AdminID { get => adminID; set => adminID = value; }



        public DataTable ButunAraçlarıCagir()
        {
            try
            {
                string sorgu = "select * from Araç";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araçları çağırma hatası. \n" + ex.Message);
            }
        }
        public Araç AracıŞasiIDyeGoreCagir(string SasiID)
        {
            Objeler.Araç a1 = new Objeler.Araç();
            try
            {
                DataTable dt = new DataTable();
                string sorgu = $"select * from Araç where ŞasiID='{SasiID}'";
                dt = DBController.Sorgula(sorgu);

                if (dt.Rows.Count > 0)
                {
                    a1.SasiID = dt.Rows[0]["ŞasiID"].ToString();
                    a1.Marka = dt.Rows[0]["Marka"].ToString();
                    a1.Model = dt.Rows[0]["Model"].ToString();
                    a1.MevcutKilometresi = int.Parse(dt.Rows[0]["MevcutKilometre"].ToString());
                    a1.MotorGucu = float.Parse(dt.Rows[0]["MotorGücü"].ToString());
                    a1.YakitTuru = dt.Rows[0]["YakıtTürü"].ToString();
                    a1.VitesTuru = dt.Rows[0]["VitesTürü"].ToString();
                    a1.BagajHacmi = float.Parse(dt.Rows[0]["BagajHacmi"].ToString());
                    a1.Rengi = dt.Rows[0]["Rengi"].ToString();
                    a1.KoltukSayisi = int.Parse(dt.Rows[0]["KoltukSayısı"].ToString());
                    a1.KaskoDurumu = dt.Rows[0]["KaskoDurumu"].ToString();
                    a1.HavaYastigiDurumu = dt.Rows[0]["HavaYastığıDurumu"].ToString();
                    a1.TCkimlik = dt.Rows[0]["TCkimlik"].ToString();

                    if ((dt.Rows[0]["Resim1"]) != null && (dt.Rows[0]["Resim1"]).ToString().Length > 0)
                    {
                        if ((Byte[])(dt.Rows[0]["Resim1"]) != null && ((Byte[])dt.Rows[0]["Resim1"]).ToString().Length > 0)
                        {
                            a1.Resim1 = (Byte[])(dt.Rows[0]["Resim1"]);
                        }
                        else
                        {
                            MemoryStream stream = new MemoryStream();
                            Properties.Resources.user_120px.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                            a1.Resim1 = stream.ToArray();
                        }
                    }
                    else
                    {
                        MemoryStream stream = new MemoryStream();
                        Properties.Resources.Car.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        a1.Resim1 = stream.ToArray();
                    }


                    if (dt.Rows[0]["KategoriID"].ToString() == "" || dt.Rows[0]["KategoriID"].ToString() == "0") { a1.KategoriID = 0; }
                    else { a1.KategoriID = int.Parse(dt.Rows[0]["KategoriID"].ToString()); }
                    if (dt.Rows[0]["AdminID"].ToString() == "") { a1.AdminID = 0; }
                    else { a1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString()); }
                    return a1;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Araç ŞasiID'si çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable AraclarıModelMarkayaGoreCagir(string ModelMarka)
        {
            try
            {
                string sorgu = $"select * from Araç where Model LIKE '%{ModelMarka}%' OR Marka LIKE '%{ModelMarka}%' ";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Model arama hatası. \n" + ex.Message);
            }
        }
        public DataTable AraclarıFiltrele(string Model,string Marka, 
            string YakıtTürü, string VitesTürü, float BagajHacmi, float BagajHacmiMax, string Rengi, 
            int KoltukSayısı, int KoltukSayısıMax, string KaskoDurumu, string HavaYastığıDurumu)
        {
            try
            {

                string sorgu = $"select * from Araç where Model LIKE '%{Model}%' " +
                    $"AND Marka LIKE '%{Marka}%' AND YakıtTürü LIKE '%{YakıtTürü}%' " +
                    $"AND VitesTürü LIKE '%{VitesTürü}' AND BagajHacmi between {BagajHacmi} and {BagajHacmiMax} " +
                    $"AND Rengi LIKE '%{Rengi}%' AND KoltukSayısı between {KoltukSayısı} and {KoltukSayısıMax} " +
                    $"AND KaskoDurumu LIKE '%{KaskoDurumu}%' AND HavaYastığıDurumu LIKE '%{HavaYastığıDurumu}%'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araçları filtreleme hatası. \n" + ex.Message);
            }
        }
        public DataTable AraçlarıAdminIDyeGoreCagir(int AdminID)
        {
            try
            {
                string sorgu = $"select * from Araç where AdminID = {AdminID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araçları adminID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable AraçlarıKategoriIDyeGoreCagir(int KategoriID)
        {
            try
            {
                string sorgu = $"select * from Araç where KategoriID = {KategoriID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araçları kategoriID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable AraçlarıTCyeGoreCagir(string TCkimlik)
        {
            try
            {
                string sorgu = $"select * from Araç where TCkimlik = '{TCkimlik}'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araçları TC'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public int AraçEkle(Araç a1)
        {
            try
            {
                string sorgu;
                if (AracıŞasiIDyeGoreCagir(a1.SasiID) != null)
                {
                    throw new Exception("Bu araç zaten eklenmiş.");
                }

                if (a1.AdminID == 0)
                {
                    string resim1 = "0x" + String.Join("", a1.Resim1.Select(n => n.ToString("X2")));

                    sorgu = $"INSERT INTO Araç(ŞasiID, Model, Marka, MevcutKilometre, MotorGücü, " +
                    $"YakıtTürü, VitesTürü, BagajHacmi, Rengi, KoltukSayısı, KaskoDurumu, HavaYastığıDurumu, " +
                    $"TCkimlik, KategoriID, Resim1)" +
                        $"VALUES('{a1.SasiID}','{a1.Model}','{a1.Marka}',{a1.MevcutKilometresi},{a1.MotorGucu.ToString(new CultureInfo("en-US"))}," +
                        $"'{a1.YakitTuru}','{a1.VitesTuru}',{a1.BagajHacmi.ToString(new CultureInfo("en-US"))},'{a1.Rengi}',{a1.KoltukSayisi}," +
                        $"'{a1.KaskoDurumu}','{a1.HavaYastigiDurumu}','{a1.TCkimlik}',{a1.KategoriID},{resim1})";
                }
                else
                {
                    string resim1 = "0x" + String.Join("", a1.Resim1.Select(n => n.ToString("X2")));

                    sorgu = $"INSERT INTO Araç(ŞasiID, Model, Marka, MevcutKilometre, MotorGücü, " +
                    $"YakıtTürü, VitesTürü, BagajHacmi, Rengi, KoltukSayısı, KaskoDurumu, HavaYastığıDurumu, " +
                    $"TCkimlik, KategoriID, Resim1, AdminID)" +
                        $"VALUES('{a1.SasiID}','{a1.Model}','{a1.Marka}',{a1.MevcutKilometresi},{a1.MotorGucu}," +
                        $"'{a1.YakitTuru}','{a1.VitesTuru}',{a1.BagajHacmi},'{a1.Rengi}',{a1.KoltukSayisi}," +
                        $"'{a1.KaskoDurumu}','{a1.HavaYastigiDurumu}','{a1.TCkimlik}',{a1.KategoriID}, {resim1},{a1.AdminID})";
                }
                
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araç ekleme hatası. \n" + ex.Message);
            }
        }
        public int AraçGüncelleme(Araç a1)
        {
            try
            {
                string sorgu;
                if (a1.AdminID == 0)
                {
                    string resim1 = "0x" + String.Join("", a1.Resim1.Select(n => n.ToString("X2")));

                    sorgu = $"UPDATE Araç SET Model = '{a1.Model}', " +
                    $"Marka = '{a1.Marka}', MevcutKilometre = {a1.MevcutKilometresi}, " +
                    $"MotorGücü = {a1.MotorGucu.ToString(new CultureInfo("en-US"))}, YakıtTürü = '{a1.YakitTuru}', VitesTürü = '{a1.VitesTuru}', " +
                    $"BagajHacmi = {a1.BagajHacmi.ToString(new CultureInfo("en-US"))}, Rengi = '{a1.Rengi}', KoltukSayısı = {a1.KoltukSayisi}, " +
                    $"KaskoDurumu = '{a1.KaskoDurumu}', HavaYastığıDurumu = '{a1.HavaYastigiDurumu}', " +
                    $"TCkimlik = '{a1.TCkimlik}', KategoriID = {a1.KategoriID}, Resim1 = {resim1} " +
                    $"WHERE ŞasiID = {a1.SasiID}";
                }
                else
                {
                    string resim1 = "0x" + String.Join("", a1.Resim1.Select(n => n.ToString("X2")));

                    sorgu = $"UPDATE Araç SET Model = '{a1.Model}', " +
                    $"Marka = '{a1.Marka}', MevcutKilometre = {a1.MevcutKilometresi}, " +
                    $"MotorGücü = {a1.MotorGucu.ToString(new CultureInfo("en-US"))}, YakıtTürü = '{a1.YakitTuru}', VitesTürü = '{a1.VitesTuru}', " +
                    $"BagajHacmi = {a1.BagajHacmi.ToString(new CultureInfo("en-US"))}, Rengi = '{a1.Rengi}', KoltukSayısı = {a1.KoltukSayisi}, " +
                    $"KaskoDurumu = '{a1.KaskoDurumu}', HavaYastığıDurumu = '{a1.HavaYastigiDurumu}', " +
                    $"TCkimlik = '{a1.TCkimlik}', KategoriID = {a1.KategoriID}, Resim1 = {resim1}, AdminID = {a1.AdminID}" +
                    $"WHERE ŞasiID = {a1.SasiID}";
                }
                
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araç güncelleme hatası. \n" + ex.Message);
            }
        }
        public int AraçSil(string SasiID)
        {
            try
            {
                string sorgu = $"DELETE Araç WHERE ŞasiID = {SasiID}";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Araç silme hatası. \n" + ex.Message);
            }
        }

    }
}
