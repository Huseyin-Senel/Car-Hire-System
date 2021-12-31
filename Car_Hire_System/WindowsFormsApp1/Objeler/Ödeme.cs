using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Objeler
{
    public class Ödeme
    {
        private int odemeID;
        private string baslangicTarihi;
        private string bitisTarihi;
        private string kiralamaDurumu;
        private int musteriID;
        private int kiralamaID;
        private int adminID;

        public Ödeme()
        { }
        public Ödeme(int odemeID, string baslangicTarihi, string bitisTarihi, string kiralamaDurumu, 
             int musteriID, int kiralamaID, int adminID)
        {
            this.OdemeID = odemeID;
            this.BaslangicTarihi = baslangicTarihi;
            this.BitisTarihi = bitisTarihi;
            this.KiralamaDurumu = kiralamaDurumu;
            this.MusteriID = musteriID;
            this.KiralamaID = kiralamaID;
            this.AdminID = adminID;
        }

        public int OdemeID { get => odemeID; set => odemeID = value; }
        public string BaslangicTarihi { get => baslangicTarihi; set => baslangicTarihi = value; }
        public string BitisTarihi { get => bitisTarihi; set => bitisTarihi = value; }
        public string KiralamaDurumu { get => kiralamaDurumu; set => kiralamaDurumu = value; }
        public int MusteriID { get => musteriID; set => musteriID = value; }
        public int KiralamaID { get => kiralamaID; set => kiralamaID = value; }
        public int AdminID { get => adminID; set => adminID = value; }


        private Ödeme OdemeObjeOluştur(Ödeme o1, string sorgu)
        {
            DataTable dt = new DataTable();
            dt = DBController.Sorgula(sorgu);

            if (dt.Rows.Count > 0)
            {
                o1 = new Objeler.Ödeme();

                o1.OdemeID = int.Parse(dt.Rows[0]["ÖdemeID"].ToString());
                o1.BaslangicTarihi = dt.Rows[0]["BaşlangıçTarihi"].ToString();
                o1.BitisTarihi = dt.Rows[0]["BitişTarihi"].ToString();
                o1.KiralamaDurumu = dt.Rows[0]["KiralamaDurumu"].ToString();
                o1.MusteriID = int.Parse(dt.Rows[0]["MüşteriID"].ToString());
                o1.KiralamaID = int.Parse(dt.Rows[0]["KiralamaID"].ToString());

                if (dt.Rows[0]["AdminID"].ToString() == "") { o1.AdminID = 0; }
                else { o1.AdminID = int.Parse(dt.Rows[0]["AdminID"].ToString()); }
                return o1;
            }
            else
            {
                return o1;
            }
        }

        public DataTable ButunOdemeleriCagir()
        {
            try
            {
                string sorgu = "select * from Ödeme";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri çağırma hatası. \n" + ex.Message);
            }
        }
        public Ödeme OdemeyiIDyeGoreCagir(int ID)
        {
            Ödeme o1 = null;
            try
            {
                string sorgu = $"select * from Ödeme where ÖdemeID={ID}";
                return OdemeObjeOluştur(o1,sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödeme ID'si çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable OdemeleriMusteriIDyeGoreCagir(int ID)
        {
            try
            {
                string sorgu = $"select * from Ödeme where MüşteriID = {ID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri müşteriID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable OdemesiTamamlananlarıCagir(int ID)
        {
            try
            {
                string sorgu = $"select * from Ödeme where MüşteriID = {ID} AND KiralamaDurumu = 'Tamamlandı'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri müşteriID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable OdemesiTamamlanmayanlarıCagir(int ID)
        {
            try
            {
                string sorgu = $"select * from Ödeme where MüşteriID = {ID} AND KiralamaDurumu = 'Devam Ediyor'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri müşteriID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable OdemeleriAdminIDyeGoreCagir(int AdminID)
        {
            try
            {
                string sorgu = $"select * from Ödeme where AdminID = {AdminID}";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri adminID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public Ödeme OdemeyiKiralamaIDyeGoreCagir(int ID)
        {
            Objeler.Ödeme o1 = null;
            try
            {
                string sorgu = $"select * from Ödeme where KiralamaID = {ID}";
                return OdemeObjeOluştur(o1, sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri kiralamaID'ye göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable OdemeleriBaslangicTarihineGoreCagir(string time)
        {
            try
            {
                string sorgu = $"select * from Ödeme where BaşlangıçTarihi = '{time}'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri başlangıç tarihine göre çağırma hatası. \n" + ex.Message);
            }
        }
        public DataTable OdemeleriBitisTarihineGoreCagir(string time)
        {
            try
            {
                string sorgu = $"select * from Ödeme where BitişTarihi = '{time}'";
                return DBController.Sorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödemeleri bitiş tarihine göre çağırma hatası. \n" + ex.Message);
            }
        }
        public int OdemeEkle(Ödeme o1)
        {
            try
            {
                string sorgu;
                if (OdemeyiKiralamaIDyeGoreCagir(o1.KiralamaID) != null)
                {
                    throw new Exception("Bu araç kiralanmış");
                }

                if (o1.AdminID == 0)
                {
                    sorgu = $"INSERT INTO Ödeme(BaşlangıçTarihi, BitişTarihi, KiralamaDurumu, MüşteriID, KiralamaID)" +
                        $"VALUES('{o1.BaslangicTarihi}','{o1.BitisTarihi}','{o1.KiralamaDurumu}',{o1.MusteriID},{o1.KiralamaID})";
                }
                else
                {
                    sorgu = $"INSERT INTO Ödeme(BaşlangıçTarihi, BitişTarihi, KiralamaDurumu, MüşteriID, KiralamaID, AdminID)" +
                        $"VALUES('{o1.BaslangicTarihi}','{o1.BitisTarihi}','{o1.KiralamaDurumu}',{o1.MusteriID},{o1.KiralamaID},{o1.AdminID})";
                }
                
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödeme ekleme hatası. \n" + ex.Message);
            }
        }
        public int OdemeGüncelleme(Ödeme o1)
        {
            try
            {
                string sorgu;
                if (DateTime.Parse(OdemeyiIDyeGoreCagir(o1.OdemeID).BitisTarihi) > DateTime.Parse(o1.BitisTarihi)) 
                {
                    throw new Exception("Kiralamayı sadece uzatabilirsiniz.");
                }

                if (o1.AdminID == 0)
                {
                    sorgu = $"UPDATE Ödeme SET BitişTarihi = '{o1.BitisTarihi}' WHERE ÖdemeID = {o1.OdemeID}";
                }
                else
                {
                    sorgu = $"UPDATE Ödeme SET BitişTarihi = '{o1.BitisTarihi}', AdminID = {o1.AdminID} WHERE ÖdemeID = {o1.OdemeID}";
                }
                
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödeme güncelleme hatası. \n" + ex.Message);
            }
        }
        public int OdemeTamamla(Ödeme o1)
        {
            try
            {
                string sorgu;
                if (o1.AdminID == 0)
                {
                    sorgu = $"UPDATE Ödeme SET KiralamaDurumu = 'Tamamlandı', BitişTarihi = '{DateTime.Now.Date.ToString("yyyy-MM-dd HH:mm:ss")}' WHERE ÖdemeID = {o1.OdemeID}";
                }
                else
                {
                    sorgu = $"UPDATE Ödeme SET KiralamaDurumu = 'Tamamlandı', AdminID = {o1.AdminID} WHERE ÖdemeID = {o1.OdemeID}";
                }
                
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödeme tamamlama hatası. \n" + ex.Message);
            }
        }
        public int OdemeSil(int odemID)
        {
            try
            {
                string sorgu = $"Delete Ödeme WHERE ÖdemeID = {odemID}";
                return DBController.intSorgula(sorgu);
            }
            catch (Exception ex)
            {
                throw new Exception("Ödeme silme hatası. \n" + ex.Message);
            }
        }
    }
}
