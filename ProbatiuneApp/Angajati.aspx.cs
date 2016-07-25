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
                {

                    if (!Request.Cookies["UserName"].Value.Contains("admin"))
                    {
                        this.GridView1.Columns[6].Visible = false;
                    }
                    BindGrid();
                }
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
        protected void SearchButton_Click(object sender, EventArgs e)
        {

            if (SearchTextBox.Value == "")
                BindGrid();
            else
            {
                GridView1.DataSource = GridDataSource_Search(SearchTextBox.Value.ToString());
                GridView1.DataBind();
            }
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
            int id;
             if (int.TryParse(tb.Text, out id))
             {
                 pBAL.DeleteAngajat(id);
                 BindGrid();
             }
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;

            if (SearchTextBox.Value.ToString() != "")
            {
                GridView1.DataSource = GridDataSource_Search(SearchTextBox.Value.ToString());
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
             int idd;
             if (int.TryParse(id.Text, out idd) || SearchTextBox.Value.ToString() != "")
             {
                 pBAL.UpdateAngajat(idd, Nume.Text, Prenume.Text);
                 //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
                 GridView1.EditIndex = -1;

                 GridView1.DataSource = GridDataSource_Search(SearchTextBox.Value.ToString());
                 GridView1.DataBind();
                 SearchTextBox.Value = "";
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
            if (TextBox1.Text == "" || TextBox2.Text == "")
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Trebuie completate AMBELE campuri!');");
                Response.Write("document.location.href='Angajati.aspx';");
                Response.Write("</script>");

                
            }
            else
            {
                string Nume = TextBox1.Text.ToString();
                string Prenume = TextBox2.Text.ToString();
                pBAL.InsertAngajat(Nume, Prenume);
                string pass = pBAL.getPassword(Nume, Prenume);
                string user = Nume + "." + Prenume;
                // Response.Write("<script>alert('ATENTIE! Utilizatorul pe care l-ati creat se poate loga la aplicatie cu username: !!!')</script>");
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(" + Nume.ToString() + ");", true);
                //Response.Write("<script>alert('Utilizatorul creat va folosi:                                       Username:" + Server.HtmlEncode(user) + "                                                             Password:" + Server.HtmlEncode(pass) + "')</script>");
      
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Utilizatorul creat va folosi:  USERNAME:" + Server.HtmlEncode(user) + " PASSWORD:" + Server.HtmlEncode(pass) + "');");
                Response.Write("document.location.href='Angajati.aspx';");
                Response.Write("</script>");
                TextBox2.Text = "";
                TextBox1.Text = "";

            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}