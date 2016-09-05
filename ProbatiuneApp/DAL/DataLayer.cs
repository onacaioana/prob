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
        public int Insert(string Nume, string Prenume, int NrDosar, string StartDate, string StopDate, string Observatii, int IdAng,bool activ,string user)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Insert INTO CazuriP(Nume,Prenume,NrDosar,DataInceperii,DataFinal,Observatii,IDAngajat,Activ,user_modif) VALUES(@Nume,@Prenume,@NrDosar,@StartDate,@StopDate,@Observatii,@Angajat,@activ,@user)";
            SqlCommand dCmd = new SqlCommand(sql, conn);

            try
            {
                dCmd.Parameters.Add("@Nume", SqlDbType.NVarChar, 255).Value = Nume;
                dCmd.Parameters.Add("@Prenume", SqlDbType.NVarChar, 255).Value = Prenume;
                dCmd.Parameters.Add("@NrDosar", SqlDbType.Int).Value = NrDosar;
                dCmd.Parameters.Add("@StartDate", SqlDbType.NVarChar, 255).Value = StartDate;
                dCmd.Parameters.Add("@StopDate", SqlDbType.NVarChar, 255).Value = StopDate;
                dCmd.Parameters.Add("@Observatii", SqlDbType.NVarChar, 255).Value = Observatii;
                dCmd.Parameters.Add("@Angajat", SqlDbType.Int).Value = IdAng;
                dCmd.Parameters.Add("@activ", SqlDbType.Bit).Value = activ;
                dCmd.Parameters.Add("@user", SqlDbType.NVarChar, 255).Value = user;
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

        //Insert case if Opis record has CazSuprav 
        public int InsertCase(string Nume,string Prenume, int NrDosar,int IdAng,bool activ ,string user)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Insert INTO CazuriP(Nume,Prenume,NrDosar,DataInceperii,DataFinal,IDAngajat,Activ,user_modif) VALUES(@Nume,@Prenume,@NrDosar,@StartDate,@StopDate,@Angajat,@activ,@user)";
            SqlCommand dCmd = new SqlCommand(sql, conn);

            try
            {
                dCmd.Parameters.Add("@Nume", SqlDbType.NVarChar, 255).Value = Nume;
                dCmd.Parameters.Add("@Prenume", SqlDbType.NVarChar, 255).Value = Prenume;
                dCmd.Parameters.Add("@NrDosar", SqlDbType.Int).Value = NrDosar;
                dCmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = DateTime.Now.ToString("yyyy-MM-dd");
                dCmd.Parameters.Add("@StopDate", SqlDbType.Date).Value = "01/01/1900";
                dCmd.Parameters.Add("@Angajat", SqlDbType.Int).Value = IdAng;
                dCmd.Parameters.Add("@activ", SqlDbType.Bit).Value = activ;
                dCmd.Parameters.Add("@user", SqlDbType.NVarChar, 255).Value = user;
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

        public int InsertOpis(string Nume, string CNP,string CazRef,string CazSuprav,string CazAsis,string Consilier,string user)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Insert INTO Opis(Nume,CNP,CazReferat,CazSupraveghere,CazAsistenta,Consilier,user_modif) VALUES(@Nume,@CNP,@CazRef,@CazSuprav,@CazAsis,@Consilier,@user)";
            SqlCommand dCmd = new SqlCommand(sql, conn);

            try
            {
                dCmd.Parameters.Add("@Nume", SqlDbType.NVarChar, 255).Value = Nume;
                dCmd.Parameters.Add("@CNP", SqlDbType.NVarChar, 255).Value = CNP;
                dCmd.Parameters.Add("@CazRef", SqlDbType.NVarChar, 255).Value = CazRef;
                dCmd.Parameters.Add("@CazSuprav", SqlDbType.NVarChar, 255).Value = CazSuprav;
                dCmd.Parameters.Add("@CazAsis", SqlDbType.NVarChar, 255).Value = CazAsis;
                dCmd.Parameters.Add("@Consilier", SqlDbType.NVarChar, 255).Value = Consilier;
                dCmd.Parameters.Add("@user", SqlDbType.NVarChar, 255).Value = user;
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


        public int InsertAngajat(string Nume, string Prenume, string user)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            string sql = "Insert INTO AngajatiP(Nume,Prenume,user_modif) VALUES(@Nume,@Prenume,@user)";
            SqlCommand dCmd = new SqlCommand(sql, conn);

            try
            {
                dCmd.Parameters.Add("@Nume", SqlDbType.NVarChar, 255).Value = Nume;
                dCmd.Parameters.Add("@Prenume", SqlDbType.NVarChar, 255).Value = Prenume;
                dCmd.Parameters.Add("@user", SqlDbType.NVarChar, 255).Value = user;
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


        public DataTable LoadAngajatiListBox()
        {
            DataTable subjects = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select Nume +' '+ Prenume as Num from AngajatiP", conn))
                {
                    dAd.Fill(subjects);
                    return subjects;
                }
            }
        }

        public DataSet LoadActiv()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where Activ = 1 order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public DataSet LoadInactiv()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where Activ =0 order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public DataSet LoadPerAngajatActiv(int idAngajat)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where a.IdAngajat = "+idAngajat+" AND Activ=1 order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public DataSet LoadPerAngajatInactiv(int idAngajat)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where a.IdAngajat = " + idAngajat + " AND Activ=0 order by c.Nume,c.Prenume;", conn))
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
                using (SqlDataAdapter dAd = new SqlDataAdapter("select IdOpis,Nume,CNP,CazReferat,CazSupraveghere,CazAsistenta,Consilier from Opis order by Nume ASC", conn))
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
                using (SqlDataAdapter dAd = new SqlDataAdapter(" SELECT ang.IdAngajat as ID, Nume, Prenume, isnull(a.activ,0) as activ, isnull(i.inactiv,0) as inactiv From AngajatiP as ang left join (SELECT IdAngajat,COUNT(*) AS activ FROM CazuriP WHERE Activ=1 GROUP BY IdAngajat) as a ON a.IdAngajat = ang.IdAngajat left join (SELECT IdAngajat,COUNT(*) AS inactiv FROM CazuriP WHERE Activ=0 GROUP BY IdAngajat) as i ON i.IdAngajat = ang.IdAngajat", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        // Delete record from database
        public int DeleteActiv(int CazID, string user)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            SqlCommand userCmd = new SqlCommand("UPDATE CazuriP SET user_modif = @user WHERE IDCaz=@IDCaz AND Activ=1 ;", conn);
            SqlCommand dCmd = new SqlCommand("DELETE FROM CazuriP WHERE IDCaz=@IDCaz AND Activ=1 ;", conn);

            userCmd.Parameters.AddWithValue("@user", user);
            userCmd.Parameters.AddWithValue("@IDCaz", CazID);
            userCmd.ExecuteNonQuery();

            dCmd.Parameters.AddWithValue("@IDCaz", CazID);
            return dCmd.ExecuteNonQuery();

        }

        //Delete record from database
        public int DeleteInactiv(int CazID, string user)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            SqlCommand userCmd = new SqlCommand("UPDATE CazuriP SET user_modif = @user WHERE IDCaz=@IDCaz AND Activ=0 ;", conn);
            SqlCommand dCmd = new SqlCommand("DELETE FROM CazuriP WHERE IDCaz=@IDCaz AND Activ=0 ;", conn);

            userCmd.Parameters.AddWithValue("@user", user);
            userCmd.Parameters.AddWithValue("@IDCaz", CazID);
            userCmd.ExecuteNonQuery();

            dCmd.Parameters.AddWithValue("@IDCaz", CazID);
            return dCmd.ExecuteNonQuery();

        }

        public int DeleteOpis(int IdOpis, string user)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            SqlCommand userCmd = new SqlCommand("UPDATE Opis SET user_modif = @user WHERE IdOpis=@ID ;", conn);
            SqlCommand dCmd = new SqlCommand("DELETE FROM Opis WHERE IdOpis=@ID ;", conn);

            userCmd.Parameters.AddWithValue("@user", user);
            userCmd.Parameters.AddWithValue("@ID", IdOpis);
            userCmd.ExecuteNonQuery();

            dCmd.Parameters.AddWithValue("@ID", IdOpis);
            return dCmd.ExecuteNonQuery();

        }

        public int DeleteAngajat(int IdAngajat, string user)
        {
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();
            SqlCommand userCmd = new SqlCommand("UPDATE AngajatiP SET user_modif = @user WHERE IdAngajat=@ID ;", conn);
            SqlCommand dCmd = new SqlCommand("DELETE FROM AngajatiP WHERE IdAngajat=@ID ;", conn);

            userCmd.Parameters.AddWithValue("@user", user);
            userCmd.Parameters.AddWithValue("@ID", IdAngajat);
            userCmd.ExecuteNonQuery();

            dCmd.Parameters.AddWithValue("@ID", IdAngajat);
            return dCmd.ExecuteNonQuery();
          
        }
        /// <summary>
        /// Folosit pentru modulul de search dupa Nume sau Prenume
        /// </summary>
        /// <returns></returns>
        public DataSet SearchQueryActiv(string text)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where Activ=1 AND (c.Nume COLLATE Latin1_General_CI_AI like '" + text + "%' OR c.Prenume COLLATE Latin1_General_CI_AI like '" + text + "%')  order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }


        /// <summary>
        /// Folosit pentru modulul de search dupa Nume sau Prenume
        /// </summary>
        /// <returns></returns>
        public DataSet SearchQueryInactiv(string text)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where  Activ=0 AND (c.Nume COLLATE Latin1_General_CI_AI like '" + text + "%' OR c.Prenume COLLATE Latin1_General_CI_AI like '" + text + "%')  order by c.Nume,c.Prenume;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }
        public bool CheckAngajat(string Nume, string Prenume)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select Nume from AngajatiP where Nume IN('"+Nume+"','"+Prenume+"') AND Prenume IN ('"+Nume+"','"+Prenume+"')", conn))
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
               using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT ang.IdAngajat as ID, Nume, Prenume, isnull(a.activ,0) as activ,isnull(i.inactiv,0) as inactiv From AngajatiP as ang left join (SELECT IdAngajat,COUNT(*) AS activ FROM CazuriP WHERE Activ=1 GROUP BY IdAngajat) as a ON a.IdAngajat = ang.IdAngajat left join (SELECT IdAngajat,COUNT(*) AS inactiv FROM CazuriP WHERE Activ=0 GROUP BY IdAngajat) as i ON i.IdAngajat = ang.IdAngajat WHERE Nume COLLATE Latin1_General_CI_AI like '%" + text + "%' OR Prenume COLLATE Latin1_General_CI_AI like '%" + text + "%'", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }


        public DataSet SearchDosarActiv(int nr)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where Activ = 1 AND c.NrDosar = " + nr + " order by c.IDCaz;", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public DataSet SearchDosarInactiv(int nr)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("select c.IDCaz,c.Nume,c.Prenume,c.NrDosar,c.DataInceperii,c.DataFinal,c.Observatii,a.Nume as NumeAng,a.Prenume as PrenumeAng from CazuriP as c inner join AngajatiP as a on a.IdAngajat = c.IDAngajat where Activ=0 AND c.NrDosar = " + nr + " order by c.IDCaz;", conn))
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

        public DataSet SearchOpis(string text)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {

                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT * FROM Opis where Nume COLLATE Latin1_General_CI_AI like '%" + text + "%' ORDER BY Nume DESC", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset;
                }
            }
        }

        public int UpdateOpis(int IdOpis, string Nume, string CNP, string CazReferat, string CazSuprav, string CazAsist, string Consilier, string user)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE Opis SET Nume=@Nume, CNP=@CNP, CazReferat = @CazReferat, CazSupraveghere=@CazSuprav, CazAsistenta=@CazAsist, Consilier=@Consilier, user_modif=@user WHERE IdOpis=@Id;", conn);

            try
            {

                dCmd.Parameters.AddWithValue("@Id", IdOpis);
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@CNP", CNP);
                dCmd.Parameters.AddWithValue("@CazReferat", CazReferat);
                dCmd.Parameters.AddWithValue("@CazSuprav", CazSuprav);
                dCmd.Parameters.AddWithValue("@CazAsist", CazAsist);
                dCmd.Parameters.AddWithValue("@Consilier", Consilier);
                dCmd.Parameters.AddWithValue("@user", user);
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


        public int UpdateActiv(int CazID, string Nume, string Prenume, int nrDosar, string Start, string TheEnd, string Observatii,bool Activ, string user)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE CazuriP SET Nume=@Nume, Prenume=@Prenume, NrDosar = @NrDosar, DataInceperii=@Start, DataFinal=@TheEnd, Observatii=@Observatii,Activ=@Activ, user_modif = @user WHERE IDCaz=@IDCaz AND Activ=1;", conn);

            try
            {

                dCmd.Parameters.AddWithValue("@IDCaz", CazID);
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
                dCmd.Parameters.AddWithValue("@NrDosar", nrDosar);
                dCmd.Parameters.Add("@Start", SqlDbType.Date).Value = Start;
                dCmd.Parameters.Add("@TheEnd", SqlDbType.Date).Value = TheEnd;
                dCmd.Parameters.AddWithValue("@Observatii", Observatii);
                dCmd.Parameters.AddWithValue("@Activ", Activ);
                dCmd.Parameters.AddWithValue("@user", user);
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

        public int UpdateInactiv(int CazID, string Nume, string Prenume, int nrDosar, string Start, string TheEnd, string Observatii, bool Activ, string user)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE CazuriP SET Nume=@Nume, Prenume=@Prenume, NrDosar = @NrDosar, DataInceperii=@Start, DataFinal=@TheEnd, Observatii=@Observatii,Activ=@Activ, user_modif = @user WHERE IDCaz=@IDCaz AND Activ=0;", conn);

            try
            {

                dCmd.Parameters.AddWithValue("@IDCaz", CazID);
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
                dCmd.Parameters.AddWithValue("@NrDosar", nrDosar);
                dCmd.Parameters.Add("@Start", SqlDbType.Date).Value = Start;
                dCmd.Parameters.Add("@TheEnd", SqlDbType.Date).Value = TheEnd;
                dCmd.Parameters.AddWithValue("@Observatii", Observatii);
                dCmd.Parameters.AddWithValue("@Activ", Activ);
                dCmd.Parameters.AddWithValue("@user", user);
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

        public int UpdateAngajat(int AngID, string Nume, string Prenume, string user)
        {

            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE AngajatiP SET Nume=@Nume, Prenume=@Prenume, user_modif = user WHERE IdAngajat=@AngID", conn);

            try
            {
                dCmd.Parameters.AddWithValue("@AngID", AngID);
                dCmd.Parameters.AddWithValue("@Nume", Nume);
                dCmd.Parameters.AddWithValue("@Prenume", Prenume);
                dCmd.Parameters.AddWithValue("@user", user);
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

       /* public int LogOut(string username)
        {
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE Users SET IP = '' WHERE UserName= @user", conn);
            dCmd.Parameters.AddWithValue("@user", username);


            return dCmd.ExecuteNonQuery();

        }*/

       /* public int UpdateIP(string username) {
        
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand dCmd = new SqlCommand("UPDATE Users SET IP = CAST(CONNECTIONPROPERTY('client_net_address') AS NVARCHAR(15)) WHERE UserName= @user", conn);
            dCmd.Parameters.AddWithValue("@user", username);
            return dCmd.ExecuteNonQuery();
            
        }*/

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

        public int changePassword(string username,string newpass)
        {
            SqlConnection conn = new SqlConnection(connStr);

            conn.Open();

            SqlCommand dCmd = new SqlCommand("UPDATE Users SET password = @newpass WHERE UserName= @user", conn);
            dCmd.Parameters.AddWithValue("@user", username);
            dCmd.Parameters.AddWithValue("@newpass", newpass);

            return dCmd.ExecuteNonQuery();

        }

        public DataTable getLast6Months(string numeAng)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT * from CazuriP where DATEDIFF(month,GETDATE(),CazuriP.DataFinal) < 6 AND  DATEDIFF(month,GETDATE(),CazuriP.DataFinal) > 0", conn))
                {
                    DataSet dset = new DataSet();
                    dAd.Fill(dset);
                    return dset.Tables[0];
                }
            }
        }

        public int getIdAngajat(string Nume) {


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlDataAdapter dAd = new SqlDataAdapter("SELECT IdAngajat FROM AngajatiP WHERE '" + Nume + "' COLLATE Latin1_General_CI_AI like '%'+Nume+'%' AND '" + Nume + "' COLLATE Latin1_General_CI_AI like '%'+Prenume+'%'", conn))
                {
                    DataTable dt = new DataTable();
                    dAd.Fill(dt);
                    int value;
                    if (int.TryParse(dt.Rows[0][0].ToString(), out value))
                        return value;
                    else return 0;
                }
            }
        }

    }
}