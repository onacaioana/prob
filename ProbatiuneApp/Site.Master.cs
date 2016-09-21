﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ProbatiuneApp
{
   
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;
        private _Default def = new _Default();
        private BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
        private string clients;
        public string Clients { get { return clients; } }

        protected void Page_Init(object sender, EventArgs e)
        {
           
            // The code below helps to protect against XSRF attacks
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Use the Anti-XSRF token from the cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generate a new Anti-XSRF token and save to the cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Set Anti-XSRF token
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validate the Anti-XSRF token
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["UserName"] != null && !Request.Cookies["UserName"].Value.Contains("admin"))
            {
                clients = Request.Cookies["UserName"].Value;
                clients = clients.Replace(".", " ");
            }
            else if (Request.Cookies["UserName"] != null && Request.Cookies["UserName"].Value.Contains("admin"))
            {
                clients = Request.Cookies["UserName"].Value;
            }
            //Label1.Text = "Utilizator:  " + Request.Cookies["UserName"].Value;
            else
            {
                cssmenu.Visible = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        protected void ExportCazuriCurente(object sender, EventArgs e) {
            DataTable tbl = new DataTable();
            tbl = pBAL.Load(1).Tables[0];
            string export = "ExportCazuriCurente " + DateTime.Now.ToString("dd/MM/yyyy");
            ExportToExcel(tbl, export);
        }


        protected void ExportCazuriIesite(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = pBAL.Load(0).Tables[0];
            string export = "ExportCazuriIesite " + DateTime.Now.ToString("dd/MM/yyyy");
            ExportToExcel(tbl, export);
        }


        protected void ExportAngajati(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = pBAL.LoadAngajati().Tables[0];
            string export = "ExportAngajati " + DateTime.Now.ToString("dd/MM/yyyy");
            ExportToExcel(tbl, export);
        }

        protected void LogOut(object sender, EventArgs e) {
            if (Request.Cookies["UserName"] != null)
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);

            HttpContext.Current.Response.Redirect("LogIn.aspx");
        }

        protected void ChangePassword(object sender, EventArgs e)
        {
            if (Request.Cookies["UserName"] != null)
                 HttpContext.Current.Response.Redirect("password.aspx");
            
        }

        protected void ExportOpis(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();
            tbl = pBAL.LoadOpis().Tables[0];
            string export = "ExportOpis " + DateTime.Now.ToString("dd/MM/yyyy");
            ExportToExcel(tbl, export);
        }

        void ExportToExcel(DataTable dt, string FileName)
        {
            if (dt.Rows.Count > 0)
            {
                string filename = FileName + ".xls";
                System.IO.StringWriter tw = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
                DataGrid dgGrid = new DataGrid();
                dgGrid.DataSource = dt;
                dgGrid.DataBind();

                //Get the HTML for the control.
                dgGrid.RenderControl(hw);
                //Write the HTML back to the browser.
                //Response.ContentType = application/vnd.ms-excel;
                Response.ContentType = "application/vnd.ms-excel";
                Response.AppendHeader("Content-Disposition",
                                      "attachment; filename=" + filename + "");
                this.EnableViewState = false;
                Response.Write(tw.ToString());
                Response.End();
            }
        }


    }
}