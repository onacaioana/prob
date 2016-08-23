using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProbatiuneApp
{
    public partial class Audit : System.Web.UI.Page
    {
        private BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
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
            GridView1.DataSource = pBAL.Audit_Tabel();
            GridView1.DataBind();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = GridDataSource_Search(SearchTextBox.Value.ToString());
            GridView1.DataBind();
        }

        /// <summary>
        /// Search refresh the gridview
        /// </summary>
        private DataSet GridDataSource_Search(string text)
        {
            DataSet dset = new DataSet();
            dset = pBAL.SearchAudit(text.ToString());
            return dset;
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Data.DataRow row = ((System.Data.DataRowView)e.Row.DataItem).Row;
                if (row["TYPE"].ToString() == "Modificare")
                    e.Row.ForeColor = System.Drawing.Color.Green;
                else if (row["TYPE"].ToString() == "Adaugare")
                    e.Row.ForeColor = System.Drawing.Color.Black;
                else if (row["TYPE"].ToString() == "Stergere")
                    e.Row.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}