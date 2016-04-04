using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ProbatiuneApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        /// <summary>
        /// Bind the gridview
        /// </summary>
        private void BindGrid()
        {
            GridView1.DataSource = GridDataSource();
            GridView1.DataBind();
        }

        /// <summary>
        /// Get GridView DataSource
        /// </summary>
        private DataSet GridDataSource()
        {
            BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
            DataSet dset = new DataSet();
            try
            {
                dset = pBAL.Load();
            }
            catch (Exception ee)
            {
                lblMessage.Text = ee.Message.ToString();
            }
            finally
            {
                pBAL = null;
            }

            return dset;
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
           
     
        }
    }
}