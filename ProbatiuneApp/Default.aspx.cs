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

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {
           
     
        }

        protected void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, ImageClickEventArgs e)
        {
            GridView1.DataSource = GridDataSource_Search(SearchTextBox.Text.ToString());
            GridView1.DataBind();
        }

        /// <summary>
        /// Search refresh the gridview
        /// </summary>
        private DataSet GridDataSource_Search(string text)
        {
            BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
            DataSet dset = new DataSet();
            try
            {
                dset = pBAL.SearchQuery(text.ToString());
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

    }
}