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
        public int Insert(string Nume, string Prenume, int NrDosar, string startDate, string stopDate, string Observatii, string Angajat, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            bool Activ;
            int IdAng;

            //check date
            DateTime dt = Convert.ToDateTime(stopDate);
            if (dt < DateTime.Now)
                Activ = false;
            else Activ = true;
           
            if (stopDate.Split('-')[2].Equals("1900"))
                  Activ = true;
            

            //get IdAngajat
            IdAng = pDAL.getIdAngajat(Angajat);

            //DateTime.Now - este data curenta si va reprezenta in tabel ultima actualizare a cazului (last_modif) 
            return pDAL.Insert(Nume, Prenume, NrDosar, startDate, stopDate, Observatii, IdAng, Activ, user,DateTime.Now);

        }

        public int InsertCase(string Nume, string NrDosar, string consilier,string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            int nrDosar,idAng;
            if (Int32.TryParse(NrDosar.Split('/')[0], out nrDosar))
            {
                idAng = pDAL.getIdAngajat(consilier);

                return pDAL.InsertCase(Nume.Split(' ')[0], Nume.Substring(Nume.IndexOf(' ') + 1), nrDosar, idAng, user,DateTime.Now); ;
            }
            return 0;
        }

        public bool CheckAngajat(string Nume, string Prenume) {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.CheckAngajat(Nume, Prenume);
        }

        public int InsertOpis(string Nume, string CNP, string cazR, string cazS, string cazA, string consilier, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.InsertOpis(Nume, CNP, cazR, cazS, cazA, consilier, user);
     

        }
        /// <summary>
        /// insert records into database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        public int InsertAngajat(string Nume, string Prenume, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.InsertAngajat(Nume, Prenume, user);
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

        public DataTable LoadAngajatiListBox()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LoadAngajatiListBox();
        }
        public DataSet Load(int activ)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
           return pDAL.Load(activ);

        }
        public DataSet LoadOpis()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LoadOpis();
        }

        public DataSet LoadPerAngajatActiv(string Nume, string Prenume)
        {
              DAL.DataLayer pDAL = new DAL.DataLayer();
              int idAngajat = pDAL.getIdAngajat(Nume+' '+Prenume);

              return pDAL.LoadPerAngajat(idAngajat,1);
        }

        public DataSet LoadPerAngajatInactiv(string Nume, string Prenume)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            int idAngajat = pDAL.getIdAngajat(Nume + ' ' + Prenume);

            return pDAL.LoadPerAngajat(idAngajat,0);
        }

        public DataSet LoadAngajati()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LoadAngajati();
        }

        /// Delete record from database
        public int DeleteActiv(int IDCaz, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.DeleteActiv(IDCaz, user);
        }


        /// Delete record from database
        public int DeleteInactiv(int IDCaz, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.DeleteInactiv(IDCaz, user);
        }
        public int DeleteAngajat(int IdAngajat, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.DeleteAngajat(IdAngajat,user);
        }

        public int DeleteOpis(int ID, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.DeleteOpis(ID,user);
        }

        public int UpdateOpis(int IdOpis, string Nume, string CNP, string CazReferat, string CazSuprav, string CazAsist, string Consilier, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.UpdateOpis(IdOpis,Nume,CNP,CazReferat,CazSuprav,CazAsist,Consilier,user);
        }
        public int Update(int IDCaz, string nume, string prenume, int nrDosar, string start, string stop, string obs,string consilier, string user)
        {
            bool Activ;
            DAL.DataLayer pDAL = new DAL.DataLayer();

            //convertim string-ul primit "stop" in DateTime
            DateTime dt = Convert.ToDateTime(stop);
            //Incercam sa setem campul Activ in functie de valoarea datei de final, daca e mai mare sau nu decat data curenta
            if (dt < DateTime.Now)
                Activ = false;
            else Activ = true;
            //cazul in care data decimal final este 1900 (considerat caz activ) 
            if (stop.Split('/')[2].Split(' ')[0].Equals("1900"))
                Activ = true;
            

            //in cazul update consilier folosim campul "consilier" pentru a gasi id angajat din CazuriP
            int id = pDAL.getIdAngajat(consilier);

            //modifica CazuriP cu noile valori
            return pDAL.Update(IDCaz, nume, prenume, nrDosar, start, stop, obs,id,Activ,user);
        }

        public int UpdateAngajat(int AngID, string nume, string prenume, string user)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.UpdateAngajat(AngID, nume, prenume,user);


        }
        /*public int LogOut(string username)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.LogOut(username);

        }*/
        /*public int UpdateIP(string username)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.UpdateIP(username);
          
        }*/
        public DataSet SearchCaz(string text,int activ)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchCaz(text,activ);
        }

        public DataSet SearchCazperAngajat(string text, string nume, string prenume,int activ) {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.SearchCazperAngajat(text,nume,prenume,activ);
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

        public DataSet Search_NrDosar(string text,int activ)
        {
            int value;
            
            if (int.TryParse(text, out value))
            {
                DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchDosar(value,activ);
            }
            else return null;
        }

        public DataSet Search_NrDosarperAngajat(string text, string nume, string prenume,int activ)
        {
            int value;
            if (int.TryParse(text, out value))
            {
                DAL.DataLayer pDAL = new DAL.DataLayer();
                return pDAL.SearchDosarperAngajat(value, nume, prenume, activ);
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

        public int returneazaUltimulDosar()
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            return pDAL.returneazaUltimulDosar();
        }

    }
}