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
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtusername.Text = Request.Cookies["UserName"].Value;
                    txtpassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    Response.Redirect("#");
                }
            }
           
        }

  
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
           /* if (chkRememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }*/
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);

            Response.Cookies["UserName"].Value = txtusername.Text.Trim();
            Response.Cookies["Password"].Value = txtpassword.Text.Trim();


            if (pBAL.LogIn(txtusername.Text, txtpassword.Text))
            {
                pBAL.UpdateIP(txtusername.Text, txtpassword.Text);
                Response.Redirect("#");
            }
            else
            {
                Response.Write("<script>alert('Please enter valid Username and Password')</script>");
            }
            
        }
    }
}
