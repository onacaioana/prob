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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Security.Permissions;
using System.IO;
using System.Xml.Xsl;
using System.Xml;


namespace ProbatiuneApp
{
    public partial class _Default : Page
    {
        private BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBox4.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.TextBox5.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (!IsPostBack)
            {
              
                if (Request.Cookies["UserName"]!=null && !Request.Cookies["UserName"].Value.Contains("admin"))
                {
                   this.GridView1.Columns[10].Visible = false;
                }
                BindGrid();
            }
           
        }
        protected void Panel_Load(object sender, EventArgs e)
        {
           
        }
        protected void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        protected void GridView1_Delete(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
        {
            //
            string s="2";
            if (true)
                s.CompareTo("1");
        }
        public void GridView1_Deleting(object sender, GridViewDeleteEventArgs e) {
            Label tb = GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            int id = Int32.Parse(tb.Text.ToString());
            pBAL.DeleteActiv(id, Request.Cookies["UserName"].Value);
            BindGrid();
        }
        protected void SearchNrDosar_Click(object sender, EventArgs e)
        {
         
        }
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //To get value:
            if (searchtext1.Value.ToString() == "")
                BindGrid();
            else
            {
                string myname = searchtext1.Value;
                DataSet ds = new DataSet();
                int tmp;
                if (int.TryParse(myname, out tmp))
                {
                    ds.Tables.Add(pBAL.Search_NrDosarActiv(myname).Tables[0].Copy());
                    searchtext1.Value = "";
                }
                else
                {
                    ds.Tables.Add(pBAL.SearchQueryActiv(myname).Tables[0].Copy());
                    searchtext1.Value = "";
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

        /// <summary>
        /// Search refresh the gridview
        /// </summary>
        private DataSet GridDataSource_Search(string text)
        { 
            DataSet dset = new DataSet();
            dset = pBAL.SearchQueryActiv(text.ToString());
            return dset;
        }

        private DataSet GDSSearch_NrDosar(string text)
        {
            DataSet dset = new DataSet();
            dset = pBAL.Search_NrDosarActiv(text.ToString());
            return dset;
        }

        /// <summary>
        /// Bind the gridview
        /// </summary>
        private void BindGrid()
        {
            //setari initiale
            string[] n;
            TextBox4.Text = DateTime.Now.ToString("yyyy-MM-dd");
            if (Request.Cookies["UserName"] != null && !Request.Cookies["UserName"].Value.Contains("admin"))
            {
                n = Request.Cookies["UserName"].Value.Split('.');
                TextBox7.Text = n[0].ToUpper();
                TextBox8.Text = n[1].ToUpper();
                TextBox7.Enabled = false;
                TextBox8.Enabled = false;
            }
            else if (Request.Cookies["UserName"] != null && Request.Cookies["UserName"].Value.Contains("admin"))
            {
                panel.Enabled = false;
            }
            
            //format date columns
   
            //insert data in gridView
            GridView1.DataSource = GridDataSource();
            GridView1.DataBind();
       

        }

        /// <summary>
        /// Get GridView DataSource
        /// </summary>
        public DataSet GridDataSource()
        {
            DataSet dset = new DataSet();
                dset = pBAL.LoadActiv();
            return dset;
        }
 
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

          protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)  
    {  
        //NewEditIndex property used to determine the index of the row being edited.  
        GridView1.EditIndex = e.NewEditIndex;

        if (searchtext1.Value.ToString() != "")
        {
            GridView1.DataSource = GridDataSource_Search(searchtext1.Value.ToString());
            GridView1.DataBind();
        }
        else BindGrid();
    }  
    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)  
    {  
        //Finding the controls from Gridview for the row which is going to update  
        Label id=GridView1.Rows[e.RowIndex].FindControl("lbl_ID") as Label;  
        TextBox Nume = GridView1.Rows[e.RowIndex].FindControl("txt_Nume") as TextBox;  
        TextBox Prenume = GridView1.Rows[e.RowIndex].FindControl("txt_Prenume") as TextBox;
        TextBox NrDosar = GridView1.Rows[e.RowIndex].FindControl("txt_NrDosar") as TextBox;
        TextBox StartDate = GridView1.Rows[e.RowIndex].FindControl("txt_Start") as TextBox;
        TextBox TheEnd = GridView1.Rows[e.RowIndex].FindControl("txt_TheEnd") as TextBox;
        TextBox Observatii = GridView1.Rows[e.RowIndex].FindControl("txt_Observatii") as TextBox;
      
        //updating the record  
        pBAL.UpdateActiv(Int32.Parse(id.Text), Nume.Text, Prenume.Text, Int32.Parse(NrDosar.Text), StartDate.Text, TheEnd.Text, Observatii.Text, Request.Cookies["UserName"].Value);

        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;  
        //Call ShowData method for displaying updated data  */
        BindGrid();
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

        //actualizare
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Data.DataRow row = ((System.Data.DataRowView)e.Row.DataItem).Row;
            if (row["DataFinal"].ToString().Contains("1/1/1900"))
                e.Row.ForeColor = System.Drawing.Color.Red;
            else if (row["NrDosar"].Equals(0))
                e.Row.ForeColor = System.Drawing.Color.Green;
        }
    }



    protected void AddButon_Click(object sender, EventArgs e)
    {
     
        int nr;
        if (TextBox11.Text == "" || TextBox2.Text == "" || TextBox3.Text=="" || TextBox4.Text==""){

                LabelText.Text = "Trebuie completate campuri Nume Caz, Prenume Caz, Nr.Dosar, Data Inceperii!";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "mycaca", "myfcn();", true);
        }
        else
        if (!Int32.TryParse(TextBox3.Text.ToString(), out nr)){
            LabelText.Text = "Numarul dosarului nu poate contine litere!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "mycaca", "myfcn();", true);
        }
        else if (!pBAL.CheckAngajat(TextBox8.Text.ToString(), TextBox7.Text.ToString()))
        {
            LabelText.Text = "Numele angajatului nu se regaseste in baza de date!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "func", "myfcn();", true);
        }
        else
        {
            pBAL.Insert(TextBox11.Text.ToString(), TextBox2.Text.ToString(), Int32.Parse(TextBox3.Text.ToString()), TextBox4.Text.ToString(), TextBox5.Text.ToString(), TextBox6.Text.ToString(), TextBox7.Text.ToString(), TextBox8.Text.ToString(), Request.Cookies["UserName"].Value);
            TextBox8.Text = "";
            TextBox7.Text = "";
            TextBox6.Text = "";
            TextBox5.Text = "";
            TextBox4.Text = "";
            TextBox3.Text = "";
            TextBox2.Text = "";
            TextBox11.Text = "";

            BindGrid();
        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }


    }
}