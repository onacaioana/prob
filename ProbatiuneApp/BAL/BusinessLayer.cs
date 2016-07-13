using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


namespace ProbatiuneApp.BAL
{
    public class BusinessLayer
    {

        public BusinessLayer()
        {

        }


        /// <summary>
        /// insert records into database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public int Insert(string Nume, string Prenume, int NrDosar, string startDate, string stopDate, string Observatii, string AngajatName, string PrenumeAng)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();

            try
            {
                return pDAL.Insert(Nume, Prenume, NrDosar, startDate, stopDate, Observatii, AngajatName, PrenumeAng);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }

        public bool CheckAngajat(string Nume, string Prenume) {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.CheckAngajat(Nume, Prenume);
        }

        public int InsertOpis(string Nume, string CNP, string cazR, string cazS, string cazA, string consilier)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();

            try
            {
                return pDAL.InsertOpis(Nume, CNP, cazR, cazS, cazA, consilier);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }

        }
        /// <summary>
        /// insert records into database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public int InsertAngajat(string Nume, string Prenume)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();

            try
            {
                return pDAL.InsertAngajat(Nume, Prenume);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }


        public string getPassword(string Nume, string Prenume) { 
              DAL.DataLayer pDAL = new DAL.DataLayer();
              return pDAL.getPassword(Nume, Prenume);
        }

        public int changePassword(string username, string newpass)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.changePassword(username, newpass);
        }

        public DataSet Load()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.Load();
            }
            catch
            {
                throw;
            }
            finally
           {
                pDAL = null;
            }
        }


        public DataSet LoadInactiv()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.LoadInactiv();
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }


        public DataSet LoadOpis()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.LoadOpis();
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }

        public DataSet LoadPerAngajat(string Nume, string Prenume)
        {
              DAL.DataLayer pDAL = new DAL.DataLayer();
              int idAngajat = pDAL.getAngajatiId(Nume, Prenume);

              return pDAL.LoadPerAngajat(idAngajat);
        }

        public DataSet LoadAngajati()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LoadAngajati();
        }

        /// Delete record from database
        public int Delete(int IDCaz)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {

                return pDAL.Delete(IDCaz);

            }

            catch
            {

                throw;

            }

            finally
            {

                pDAL = null;

            }

        }

        public int DeleteAngajat(int IdAngajat)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.DeleteAngajat(IdAngajat);
            }

            catch
            {
                throw;
            }

            finally
            {
                pDAL = null;
            }
        }

        public int DeleteOpis(int ID)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.DeleteOpis(ID);
            }

            catch
            {
                throw;
            }

            finally
            {
                pDAL = null;
            }
        }

        public int UpdateOpis(int IdOpis, string Nume, string CNP, string CazReferat, string CazSuprav, string CazAsist, string Consilier)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.UpdateOpis(IdOpis,Nume,CNP,CazReferat,CazSuprav,CazAsist,Consilier);
            }
            catch
            { throw; }

            finally
            { pDAL = null; }
        }
        public int Update(int IDCaz, string nume, string prenume, int nrDosar, string start, string stop, string obs)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.Update(IDCaz, nume, prenume, nrDosar, start, stop, obs);
            }
            catch
            { throw; }

            finally
            { pDAL = null; }

        }

        public int UpdateAngajat(int AngID, string nume, string prenume)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.UpdateAngajat(AngID, nume, prenume);
            }
            catch
            { throw; }

            finally
            { pDAL = null; }

        }
        public int LogOut(string username)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LogOut(username);

        }
        public int UpdateIP(string username)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.UpdateIP(username);
          
        }
        public DataSet SearchQuery(string text)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.SearchQuery(text);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }

        public DataSet SearchAngajat(string text)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.SearchAngajat(text);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }

        public DataSet SearchAudit(string text)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.SearchAudit(text);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }

        public DataSet Search_NrDosar(string text)
        {
            int value;
            
            if (int.TryParse(text, out value))
            {
                DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchDosar(value);
            }
            else return null;
        }



        public DataSet SearchOpis(string text)
        {
       
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try
            {
                return pDAL.SearchOpis(text);
            }
            catch
            {
                throw;
            }
            finally
            {
                pDAL = null;
            }
        }


        public DataTable Audit_Tabel()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.ReturnAudit();
        }

        public bool LogIn(string txtusername, string txtpassword) {
            DAL.DataLayer pDAL = new DAL.DataLayer();

            if (txtusername == "" || txtpassword == "")
                return false;
    
            return pDAL.LogIn(txtusername,txtpassword);
        }

        public DataTable GetLast6MonthsCases(string angajat) {
            DAL.DataLayer pDAL = new DAL.DataLayer();


            return pDAL.getLast6Months(angajat);
        }

    }
}