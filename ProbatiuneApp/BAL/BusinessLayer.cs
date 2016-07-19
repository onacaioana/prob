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
                return pDAL.Insert(Nume, Prenume, NrDosar, startDate, stopDate, Observatii, AngajatName, PrenumeAng);

        }

        public bool CheckAngajat(string Nume, string Prenume) {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.CheckAngajat(Nume, Prenume);
        }

        public int InsertOpis(string Nume, string CNP, string cazR, string cazS, string cazA, string consilier)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.InsertOpis(Nume, CNP, cazR, cazS, cazA, consilier);
     

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
            return pDAL.InsertAngajat(Nume, Prenume);
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

        public DataSet LoadActiv()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LoadActiv();
        }


        public DataSet LoadInactiv()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
           return pDAL.LoadInactiv();

        }
        public DataSet LoadOpis()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LoadOpis();
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
        public int DeleteActiv(int IDCaz)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.DeleteActiv(IDCaz);
        }


        /// Delete record from database
        public int DeleteInactiv(int IDCaz)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.DeleteInactiv(IDCaz);
        }
        public int DeleteAngajat(int IdAngajat)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.DeleteAngajat(IdAngajat);
        }

        public int DeleteOpis(int ID)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.DeleteOpis(ID);
        }

        public int UpdateOpis(int IdOpis, string Nume, string CNP, string CazReferat, string CazSuprav, string CazAsist, string Consilier)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.UpdateOpis(IdOpis,Nume,CNP,CazReferat,CazSuprav,CazAsist,Consilier);
        }
        public int UpdateActiv(int IDCaz, string nume, string prenume, int nrDosar, string start, string stop, string obs)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.UpdateActiv(IDCaz, nume, prenume, nrDosar, start, stop, obs);
        }

        public int UpdateInactiv(int IDCaz, string nume, string prenume, int nrDosar, string start, string stop, string obs)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.UpdateInactiv(IDCaz, nume, prenume, nrDosar, start, stop, obs);
        }



        public int UpdateAngajat(int AngID, string nume, string prenume)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.UpdateAngajat(AngID, nume, prenume);


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
        public DataSet SearchQueryActiv(string text)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchQueryActiv(text);
        }

        public DataSet SearchQueryInactiv(string text)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.SearchQueryInactiv(text);
        }

        public DataSet SearchAngajat(string text)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchAngajat(text);
          
        }

        public DataSet SearchAudit(string text)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchAudit(text);
        }

        public DataSet Search_NrDosarActiv(string text)
        {
            int value;
            
            if (int.TryParse(text, out value))
            {
                DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchDosarActiv(value);
            }
            else return null;
        }

        public DataSet Search_NrDosarInactiv(string text)
        {
            int value;

            if (int.TryParse(text, out value))
            {
                DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchDosarInactiv(value);
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