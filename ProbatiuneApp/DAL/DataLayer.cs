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
using System.Web.Configuration;

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
        public int Insert(string Nume, string Prenume, int NrDosar, string StartDate, string StopDate, string Observatii, string AngajatName, string PrenumeAng)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Insert INTO CazuriP(Nume,Prenume,NrDosar,DataInceperii,DataFinal,Observatii,IDAngajat) VALUES(@Nume,@Prenume,@NrDosar,@StartDate,@StopDate,@Observatii,(SELECT AngajatiP.IdAngajat from AngajatiP where Nume  = @Angajat AND Prenume=@AngajatPre))";
            SqlCommand dCmd = new SqlCommand(sql, conn);

            try
            {
                dCmd.Parameters.Add("@Nume", SqlDbType.NVarChar, 255).Value = Nume;
                dCmd.Parameters.Add("@Prenume", SqlDbType.NVarChar, 255).Value = Prenume;
                dCmd.Parameters.Add("@NrDosar", SqlDbType.Int).Value = NrDosar;
                dCmd.Parameters.Add("@StartDate", SqlDbType.NVarChar, 255).Value = StartDate;
                dCmd.Parameters.Add("@StopDate", SqlDbType.NVarChar, 255).Value = StopDate;
                dCmd.Parameters.Add("@Observatii", SqlDbType.NVarChar, 255).Value = Observatii;
                dCmd.Parameters.Add("@Angajat", SqlDbType.NVarChar, 255).Value = AngajatName;
                dCmd.Parameters.Add("@AngajatPre", SqlDbType.NVarChar, 255).Value = PrenumeAng;
                dCmd.CommandType = CommandType.Text;
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

        public int InsertOpis(string Nume, string CNP,string CazRef,string CazSuprav,string CazAsis,string Consilier)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Insert INTO Opis(Nume,CNP,[Caz referat],[Caz supraveghere],CazAsistenta,Consilier) VALUES(@Nume,@CNP,@CazRef,@CazSuprav,@CazAsis,@Consilier)";
            SqlCommand dCmd = new SqlCommand(sql, conn);

            try
            {
                dCmd.Parameters.Add("@Nume", SqlDbType.NVarChar, 255).Value = Nume;
                dCmd.Parameters.Add("@CNP", SqlDbType.NVarChar, 255).Value = CNP;
                dCmd.Parameters.Add("@CazRef", SqlDbType.NVarChar, 255).Value = CazRef;
                dCmd.Parameters.Add("@CazSuprav", SqlDbType.NVarChar, 255).Value = CazSuprav;
                dCmd.Parameters.Add("@CazAsis", SqlDbType.NVarChar, 255).Value = CazAsis;
                dCmd.Parameters.Add("@Consilier", SqlDbType.NVarChar, 255).Value = Consilier;
                dCmd.CommandType = CommandType.Text;
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


        public int InsertAngajat(string Nume, string Prenume)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Insert INTO AngajatiP(Nume,Prenume) VALUES(@Nume,@Prenume)";
            SqlCommand dCmd = new SqlCommand(sql, conn);

            try
            {
                dCmd.Parameters.Add("@Nume", SqlDbType.NVarChar, 255).Value = Nume;
                dCmd.Parameters.Add("@Prenume", SqlDbType.NVarChar, 255).Value = Prenume;
                dCmd.CommandType = CommandType.Text;
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
                dAd.Fill(dSet, "CazuriP");
                return dSet.Tables["CazuriP"];
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
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        /// <summary>
        /// Load opis records 
        /// </summary>
        /// <returns></returns>
        public DataSet LoadOpis()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select IdOpis,Nume,CNP,[Caz referat],[Caz supraveghere],CazAsistenta,Consilier from Opis order by Nume ASC", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }


        /// <summary>
        /// Load records from CAZURI ---2----
        /// </summary>
        /// <returns></returns>
        public DataSet LoadAngajati()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select ID,Nume,Prenume,Numar from (select CazuriP.IdAngajat,AngajatiP.IdAngajat as ID,AngajatiP.Nume,AngajatiP.Prenume, COUNT(*) as Numar from CazuriP right join AngajatiP on AngajatiP.IdAngajat = CazuriP.IdAngajat GROUP BY CazuriP.IdAngajat,AngajatiP.Nume,AngajatiP.Prenume,AngajatiP.IdAngajat) as Tabel", conn))
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

            SqlCommand dCmd = new SqlCommand("DELETE FROM CazuriP WHERE IDCaz=@IDCaz ;", conn);

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


        public int DeleteOpis(int IdOpis)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("DELETE FROM Opis WHERE IdOpis=@ID ;", conn);

            try
            {

                dCmd.Parameters.AddWithValue("@ID", IdOpis);

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

        public int DeleteAngajat(int IdAngajat)
        {
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("DELETE FROM AngajatiP WHERE IdAngajat=@ID ;", conn);

            try
            {
                dCmd.Parameters.AddWithValue("@ID", IdAngajat);

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
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where c.Nume like '" + text + "%' OR c.Prenume like '" + text + "%' order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public bool CheckAngajat(string Nume,string Prenume)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select Nume from AngajatiP where Nume like '" + Nume + "%' AND Prenume like '" + Prenume + "%'", conn))
                {
                    DataTable dt = new DataTable();
                    dAd.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }

        public DataSet SearchAngajat(string text)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select ID,Nume,Prenume,Numar from (select CazuriP.IdAngajat,AngajatiP.IdAngajat as ID,AngajatiP.Nume,AngajatiP.Prenume, COUNT(*) as Numar from CazuriP right join AngajatiP on AngajatiP.IdAngajat = CazuriP.IdAngajat where AngajatiP.Nume like '%"+text+"%' OR AngajatiP.Prenume like '%"+text+"%' GROUP BY CazuriP.IdAngajat,AngajatiP.Nume,AngajatiP.Prenume,AngajatiP.IdAngajat) as Tabel", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }


        public DataSet SearchDosar(int nr)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where c.NrDosar = " + nr + "  order by c.IDCaz;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public DataSet SearchAudit(string text)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT * FROM Audit where UserName like '%"+text+"%' ORDER BY UpdateDate DESC", conn))  
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public int Update(int CazID, string Nume, string Prenume, int nrDosar, string Start, string TheEnd, string Observatii)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE CazuriP SET Nume=@Nume, Prenume=@Prenume, NrDosar = @NrDosar, DataInceperii=@Start, DataFinal=@TheEnd, Observatii=@Observatii WHERE IDCaz=@IDCaz;", conn);

            try
            {

                dCmd.Parameters.AddWithValue("@IDCaz", CazID);
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
                dCmd.Parameters.AddWithValue("@NrDosar", nrDosar);
                dCmd.Parameters.AddWithValue("@Start", Start);
                dCmd.Parameters.AddWithValue("@TheEnd", TheEnd);
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

        public int UpdateAngajat(int AngID, string Nume, string Prenume)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE AngajatiP SET Nume=@Nume, Prenume=@Prenume WHERE IdAngajat=@AngID", conn);

            try
            {
                dCmd.Parameters.AddWithValue("@AngID", AngID);
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
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
        public DataTable ReturnAudit()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT * FROM Audit ORDER BY UpdateDate DESC", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset.Tables[0];
                }
            }
        }

        public DataTable ReturnAudit(string dtt)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT TYPE,TableName,PK,FieldName,OldValue,NewValue,UserName FROM  Audit WHERE (UpdateDate ='" + dtt + "') ORDER BY TableName DESC", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset.Tables[0];
                }
            }
        }

        public DataTable ReturnTimeAudit()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT MAX(UpdateDate) FROM  Audit ", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset.Tables[0];
                }
            }

        }

        public bool LogIn(string txtusername,string txtpassword) 
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("Select * from Users where UserName='" + txtusername + "' and Password ='" + txtpassword + "'", conn))
                {
                    DataTable dt = new DataTable();
                    dAd.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        return false;
                    }
               
                }
                return true;
            }  
        }

        public int LogOut(string username, string pass) {
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE Users SET IP = '' WHERE UserName= @user AND Password = @pass;", conn);
            dCmd.Parameters.AddWithValue("@user", username);
            dCmd.Parameters.AddWithValue("@pass", pass);

            return dCmd.ExecuteNonQuery();
            
        }
        public int UpdateIP(string username,string pass) {
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE Users SET IP = CAST(CONNECTIONPROPERTY('client_net_address') AS NVARCHAR(15)) WHERE UserName= @user AND Password = @pass;", conn);
            dCmd.Parameters.AddWithValue("@user", username);
            dCmd.Parameters.AddWithValue("@pass", pass);
            
            return dCmd.ExecuteNonQuery();
            
        }
        public string getPassword(string Nume, string Prenume) {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("Select Password from Users where UserName='" + Prenume.ToLower()+"."+ Nume.ToLower()+"'", conn))
                {
                    DataTable dt = new DataTable();
                    dAd.Fill(dt);
                    return dt.Rows[0][0].ToString();
                }
            }
            
        }

        public DataTable getLast6Months(string numeAng)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT TYPE,TableName,PK,FieldName,OldValue,NewValue,UserName FROM  Audit WHERE (UpdateDate ='" + dtt + "') ORDER BY TableName DESC", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset.Tables[0];
                }
            }
        }


    }
}