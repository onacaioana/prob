using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


namespace ProbatiuneApp.DAL
{
    public class DataLayer
    {
        string connStr = ConfigurationManager.ConnectionStrings["connString"].ToString();
    
        public DataLayer()
        {
            
        }


        /// <summary>
        /// Used to insert records into database
        /// </summary>
        /// <param name="Nume"></param>
        /// <param name="Prenume"></param>
        /// <param name="NrDosar"></param>
        /// <param name="StartDate"></param>
        /// <param name="StopDate"></param>
        /// <param name="Angajat"></param>
        /// <returns></returns>
        public int Insert(string Nume, string Prenume, int NrDosar, string StartDate, string StopDate, string Observatii, string Angajat)
        {
            DateTime start = Convert.ToDateTime(StartDate);
            DateTime stop = Convert.ToDateTime(StopDate); 

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand dCmd = new SqlCommand("InsertData", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
                dCmd.Parameters.AddWithValue("@NrDosar", NrDosar);
                dCmd.Parameters.AddWithValue("@StartDate", start);
                dCmd.Parameters.AddWithValue("@StopDate", stop);
                dCmd.Parameters.AddWithValue("@Angajat", Angajat);
                return dCmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                dCmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }


        /// <summary>
        /// Load all records from database ----1----
        /// </summary>
        /// <returns></returns>
        public DataTable SelectAll()
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter dAd = new SqlDataAdapter("SelectAll", conn);
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "Cazuri");
                return dSet.Tables["Cazuri"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }


        /// <summary>
        /// Load records from CAZURI ---2----
        /// </summary>
        /// <returns></returns>
        public DataSet Load()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCazz,c.Nume,c.Prenume,c.Prenume2,c.NrDosar,c.Start,c.TheEnd,c.Observatii,a.Nume,a.Prenume from Cazuri as c inner join Angajati as a on a.IdAngajat = c.IDAngajat order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        /// <summary>

        /// Delete record from database

        /// </summary>

        /// <param name="personID"></param>

        /// <returns></returns>

        public int Delete(int CazID)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("DELETE FROM Cazuri WHERE IDCazz=@IDCaz ;", conn);

            try
            {

                dCmd.Parameters.AddWithValue("@IDCaz", CazID);

                return dCmd.ExecuteNonQuery();

            }

            catch
            {

                throw;

            }

            finally
            {

                dCmd.Dispose();

                conn.Close();

                conn.Dispose();

            }

        }


        /// <summary>
        /// Folosit pentru modulul de search dupa Nume sau Prenume
        /// </summary>
        /// <returns></returns>
        public DataSet SearchQuery(string text)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCazz,c.Nume,c.Prenume,c.Prenume2,c.NrDosar,c.Start,c.TheEnd,c.Observatii,a.Nume,a.Prenume from Cazuri as c inner join Angajati as a on a.IdAngajat = c.IDAngajat where c.Nume like '" + text + "%' OR c.Prenume like '" + text + "%' order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }


    }


}