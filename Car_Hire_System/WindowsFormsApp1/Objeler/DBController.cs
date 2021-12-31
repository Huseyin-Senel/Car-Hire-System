using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace WindowsFormsApp1.Objeler
{
    public static class DBController
    {
        public static DataTable Sorgula(string sorgu, SqlParameter[] parameters = null)
        {
            SqlConnection connection = null;
            try
            {
                string conString = ConfigurationManager.AppSettings["dbconnectstring"].ToString(); //"Server = DESKTOP-ST2EOV8; Database = Car_Hire_System; Trusted_Connection = True;";
                connection = new SqlConnection(conString);
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand command = new SqlCommand(sorgu, connection);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception("Bağlantı Hatası \n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public static int intSorgula(string sorgu, SqlParameter[] parameters = null)
        {
            SqlConnection connection = null;
            try
            {
                string conString = ConfigurationManager.AppSettings["dbconnectstring"].ToString(); //"Server = DESKTOP-ST2EOV8; Database = Car_Hire_System; Trusted_Connection = True;";
                connection = new SqlConnection(conString);
                connection.Open();

                if (connection.State == System.Data.ConnectionState.Open)
                {
                    SqlCommand command = new SqlCommand(sorgu, connection);
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("int Bağlantı Hatası");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Sorgu Hatası \n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
      
    }
}
