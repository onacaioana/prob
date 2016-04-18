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
        public int Insert(string Nume, string Prenume, int NrDosar, string startDate,string stopDate, string Observatii, string AngajatName,string PrenumeAng)
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


        /// <summary>

        /// Delete record from database

        /// </summary>

        /// <param name="personID"></param>

        /// <returns></returns>

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

        public int Update(int IDCaz,string nume, string prenume,int nrDosar,string start,string stop,string obs)
        {
            DAL.DataLayer pDAL = new DAL.DataLayer();
            try{
                return pDAL.Update(IDCaz, nume, prenume, nrDosar, start, stop, obs);
            }
            catch
            { throw; }

            finally
            { pDAL = null; }

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



    }
}