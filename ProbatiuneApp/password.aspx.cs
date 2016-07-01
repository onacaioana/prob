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
    public partial class password : System.Web.UI.Page
    {
        private BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   

            }

        }


        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserName"].Value != null && newpass.Value.Equals(newpass1.Value))
            {
                pBAL.changePassword(Request.Cookies["UserName"].Value, newpass.Value);
                Response.Redirect("Default.aspx");
            }
            else
            {
                
                Response.Write("<script>alert('Parola NU a fost schimbata. Incercati din nou!')</script>");
            }

        }
    }
}
