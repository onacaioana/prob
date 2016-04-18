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
        string connStr = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
    
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
        public int Insert(string Nume, string Prenume, int NrDosar, string StartDate, string StopDate, string Observatii, string AngajatName,string PrenumeAng)
        {
            DateTime start = Convert.ToDateTime(StartDate);
            DateTime stop = Convert.ToDateTime(StopDate); 

            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql =  "INSERT INTO Angajati(Nume,Prenume,Nr.Dosar,naam,voornaam) VALUES(@param1,@param2,@param3)";
        
     /*   cmd.Parameters.Add("@param1", SqlDbType.Int).value = klantId  
        cmd.Parameters.Add("@param2", SqlDbType.Varchar, 50).value = klantNaam;
        cmd.Parameters.Add("@param3", SqlDbType.Varchar, 50).value = klantVoornaam;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
         */   SqlCommand dCmd = new SqlCommand(sql, conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
                dCmd.Parameters.AddWithValue("@NrDosar", NrDosar);
                dCmd.Parameters.AddWithValue("@StartDate", start);
                dCmd.Parameters.AddWithValue("@StopDate", stop);
                dCmd.Parameters.AddWithValue("@Angajat", AngajatName);
                dCmd.Parameters.AddWithValue("@AngajatPre", PrenumeAng);
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
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCazz,c.Nume,c.Prenume+' ' +c.Prenume2 as Prenume,c.NrDosar,c.Start,c.TheEnd,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from Cazuri as c inner join Angajati as a on a.IdAngajat = c.IDAngajat order by c.Nume,c.Prenume;", conn))
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
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCazz,c.Nume,c.Prenume+' '+c.Prenume2 as Prenume,c.NrDosar,c.Start,c.TheEnd,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from Cazuri as c inner join Angajati as a on a.IdAngajat = c.IDAngajat where c.Nume like '" + text + "%' OR c.Prenume like '" + text + "%' order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public int Update(int CazID,string Nume,string Prenume, int nrDosar, string Start, string TheEnd,string Observatii)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE Cazuri SET Nume=@Nume, Prenume=@Prenume, NrDosar = @NrDosar, Start=@Start, TheEnd=@TheEnd, Observatii=@Observatii WHERE IDCazz=@IDCaz;", conn);

            try
            {

                dCmd.Parameters.AddWithValue("@IDCaz", CazID);
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
                dCmd.Parameters.AddWithValue("@NrDosar", nrDosar);
                dCmd.Parameters.AddWithValue("@Start", Start);
                dCmd.Parameters.AddWithValue("@TheEnd",TheEnd);
                dCmd.Parameters.AddWithValue("@Observatii", Observatii);
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

    }


}