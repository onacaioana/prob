using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProbatiuneApp
{

    public partial class Angajati : System.Web.UI.Page
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
            GridView1.DataSource = GridDataSource();
            GridView1.DataBind();
        }

        /// <summary>
        /// Get GridView DataSource
        /// </summary>
        public DataSet GridDataSource()
        {
            DataSet dset = new DataSet();
            dset = pBAL.LoadAngajati();
            return dset;
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
            DataSet dset = new DataSet();
            dset = pBAL.SearchAngajat(text.ToString());
            return dset;
        }

        protected void AddButon_Click(object sender, EventArgs e)
        {
            pBAL.InsertAngajat(TextBox1.Text.ToString(), TextBox2.Text.ToString());
            TextBox2.Text = "";
            TextBox1.Text = "";
            BindGrid();
        }

        protected void GridView1_Delete(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
        {
            //
            string s = "2";
            if (true)
                s.CompareTo("1");
        }
        public void GridView1_Deleting(object sender, GridViewDeleteEventArgs e)
        {
            Label tb = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            int id = Int32.Parse(tb.Text.ToString());
            pBAL.DeleteAngajat(id);
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;

            if (SearchTextBox.Text.ToString() != "")
            {
                GridView1.DataSource = GridDataSource_Search(SearchTextBox.Text.ToString());
                GridView1.DataBind();
            }
            else BindGrid();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox Nume = GridView1.Rows[e.RowIndex].FindControl("txt_Nume") as TextBox;
            TextBox Prenume = GridView1.Rows[e.RowIndex].FindControl("txt_Prenume") as TextBox;

            //updating the record  
            pBAL.UpdateAngajat(Int32.Parse(id.Text), Nume.Text, Prenume.Text);

            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  */
            if (SearchTextBox.Text.ToString() != "")
            {
                GridView1.DataSource = GridDataSource_Search(SearchTextBox.Text.ToString());
                GridView1.DataBind();
                SearchTextBox.Text = "";
            }
            else BindGrid();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }
        protected void AddButon_Click(object sender, ImageClickEventArgs e)
        {
            pBAL.InsertAngajat(TextBox1.Text.ToString(), TextBox2.Text.ToString());
            TextBox2.Text = "";
            TextBox1.Text = "";

            BindGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}