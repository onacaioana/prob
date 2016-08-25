using System;
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
               
                if (Request.Cookies["UserName"] != null)
                {
                    txtusername.Value = Request.Cookies["UserName"].Value;
                    Response.Redirect("Default.aspx");
                }
            }
           
        }
  
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (pBAL.LogIn(txtusername.Value, txtpassword.Value) )
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["UserName"].Value = txtusername.Value.Trim();
                Response.Redirect("Default.aspx");
            }
            else
            {
                LabelText.Text = "Username-ul sau parola sunt incorecte!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "func", "myfcn();", true);
            }
            
        }

    }



}
