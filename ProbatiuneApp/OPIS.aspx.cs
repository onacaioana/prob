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
    public partial class OPIS : System.Web.UI.Page
    {
        private BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
       
            if (!IsPostBack)
            {

                if (Request.Cookies["UserName"] != null && !Request.Cookies["UserName"].Value.Contains("admin"))
                {
                    this.GridView1.Columns[8].Visible = false;
                    TextBox4.Text = pBAL.returneazaUltimulDosar() + "/" + DateTime.Now.Year.ToString();
                }
              
                BindGrid();
            }
        }
        /// <summary>
        /// Bind the gridview
        /// </summary>
        private void BindGrid()
        {

            DataTable dt = new DataTable();
            dt = pBAL.LoadAngajatiListBox();
            DropDownList1.DataTextField = "Num";
            DropDownList1.DataValueField = "Num";
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.Items.Add("Alegeti Consilier");
            DropDownList1.SelectedValue = "Alegeti Consilier";
            GridView1.DataSource = GridDataSource();
            GridView1.DataBind();
        }

        /// <summary>
        /// Get GridView DataSource
        /// </summary>
        public DataSet GridDataSource()
        {
            DataSet dset = new DataSet();
            dset = pBAL.LoadOpis();
            return dset;
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Value.ToString() == "")
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
            dset = pBAL.SearchOpis(text.ToString());
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
            int id = Int32.Parse(tb.Text.ToString());
            pBAL.DeleteOpis(id, Request.Cookies["UserName"].Value);
            BindGrid();
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
            TextBox CNP = GridView1.Rows[e.RowIndex].FindControl("txt_CNP") as TextBox;
            TextBox Caz_Referat = GridView1.Rows[e.RowIndex].FindControl("txt_cazReferat") as TextBox;
            TextBox Caz_Supraveghere = GridView1.Rows[e.RowIndex].FindControl("txt_cazSuprav") as TextBox;
            TextBox Caz_Asistenta = GridView1.Rows[e.RowIndex].FindControl("txt_cazAsis") as TextBox;
            TextBox Consilier = GridView1.Rows[e.RowIndex].FindControl("txt_Consilier") as TextBox;

            //updating the record  
            pBAL.UpdateOpis(Int32.Parse(id.Text.ToString()), Nume.Text, CNP.Text, Caz_Referat.Text, Caz_Supraveghere.Text, Caz_Asistenta.Text, Consilier.Text, Request.Cookies["UserName"].Value);

            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  */
            if (SearchTextBox.Value.ToString() != "")
            {
                GridView1.DataSource = GridDataSource_Search(SearchTextBox.Value.ToString());
                GridView1.DataBind();
                //SearchTextBox.Value = "";
            }
            else BindGrid();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            if (SearchTextBox.Value.ToString() != "")
            {
                GridView1.DataSource = GridDataSource_Search(SearchTextBox.Value.ToString());
                GridView1.DataBind();
            }
            else BindGrid();
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            if (SearchTextBox.Value.ToString() != "")
            {
                GridView1.DataSource = GridDataSource_Search(SearchTextBox.Value.ToString());
                GridView1.DataBind();
            }
            else BindGrid();
        }
        protected void AddButon_Click(object sender, ImageClickEventArgs e)
        {
            DateTime date = DateTime.Now;
            if (TextBox3.Text == "" && TextBox4.Text == "")
            {
                LabelText.Text = "Trebuie completat campul CazReferat SAU CazSupraveghere!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "func", "myfcn();", true);
            }
            else if (DropDownList1.SelectedValue.Equals("Alegeti Consilier"))
            {
                LabelText.Text = "Va rog sa selectati un consilier!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "functie", "myfcn();", true);
            }
            else
                pBAL.InsertOpis(TextBox1.Text.ToString(), TextBox2.Text.ToString(), TextBox3.Text.ToString(), TextBox4.Text.ToString(), TextBox5.Text.ToString(), DropDownList1.SelectedValue.ToString(), Request.Cookies["UserName"].Value);
            
            //daca CazSuprav completat => inreg in Caz Suprav
            if (TextBox4.Text != null)
                pBAL.InsertCase(TextBox1.Text, TextBox4.Text, DropDownList1.SelectedValue, Request.Cookies["UserName"].Value,date);

            TextBox2.Text = "";
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            BindGrid();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}