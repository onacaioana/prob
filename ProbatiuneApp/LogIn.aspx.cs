﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ProbatiuneApp
{
    public partial class LogIn : System.Web.UI.Page
    {
        private BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtusername.Text = Request.Cookies["UserName"].Value;
                    txtpassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    chkRememberMe.Checked = true;
                    Response.Redirect("#");
                }
            }
           
        }

  
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (chkRememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            Response.Cookies["UserName"].Value = txtusername.Text.Trim();
            Response.Cookies["Password"].Value = txtpassword.Text.Trim();

            SqlConnection con = new SqlConnection("Data Source=192.168.0.14;Initial Catalog=probatiune;Persist Security Info=True;User ID=sa; password=ioana");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Users where UserName='" + txtusername.Text + "' and Password ='" + txtpassword.Text + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {

               
                Response.Redirect("#");
            }
            else
            {
                Response.Write("<script>alert('Please enter valid Username and Password')</script>");
            }
            
        }
    }
}
