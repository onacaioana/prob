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
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] == null)
                    HttpContext.Current.Response.Redirect("LogIn.aspx");

                if (Request.Cookies["UserName"]!=null && !Request.Cookies["UserName"].Value.Contains("admin"))
                {
                   this.GridView1.Columns[10].Visible = false;
                }
                allCheck.Checked = true;
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
                    if (allCheck.Checked == true)
                        ds.Tables.Add(pBAL.Search_NrDosarActiv(myname).Tables[0].Copy());
                    else if (mineCheck.Checked == true)
                        ds.Tables.Add(pBAL.Search_NrDosarActivperAngajat(myname, Request.Cookies["UserName"].Value.Split('.')[1], Request.Cookies["UserName"].Value.Split('.')[0]).Tables[0].Copy());
                }
                else
                {
                    if (allCheck.Checked == true)
                        ds.Tables.Add(pBAL.SearchQueryActiv(myname).Tables[0].Copy());
                    else if (mineCheck.Checked == true)
                        ds.Tables.Add(pBAL.SearchQueryActivperAngajat(myname, Request.Cookies["UserName"].Value.Split('.')[1], Request.Cookies["UserName"].Value.Split('.')[0]).Tables[0].Copy());
             
                }
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }

       //actualizare date in tabel "seach nume" - folosit la edit
        private DataSet GridDataSource_Search(string text)
        { 
            DataSet dset = new DataSet();
            if (allCheck.Checked == true)
                dset = pBAL.SearchQueryActiv(text.ToString());
            else if (mineCheck.Checked == true)
                dset = pBAL.SearchQueryActivperAngajat(text.ToString(), Request.Cookies["UserName"].Value.Split('.')[1], Request.Cookies["UserName"].Value.Split('.')[0]);
            return dset;
        }
        //actualizare date in tabel "seach dosar"
        private DataSet GDSSearch_NrDosar(string text)
        {
            DataSet dset = new DataSet();
            if (allCheck.Checked == true)
                dset = pBAL.Search_NrDosarActiv(text.ToString());
            else if (mineCheck.Checked == true)
                dset = pBAL.Search_NrDosarActivperAngajat(text.ToString(), Request.Cookies["UserName"].Value.Split('.')[1], Request.Cookies["UserName"].Value.Split('.')[0]);
            return dset;
        }
        // Bind the gridview
        private void BindGrid()
        {
            //dropDownlist initializare cu valori 
            DataTable dt = new DataTable();
            dt = pBAL.LoadAngajatiListBox();
            AngDownList.DataTextField = "Num";
            AngDownList.DataValueField = "Num";
            AngDownList.DataSource = dt;
            AngDownList.DataBind();
            AngDownList.Items.Add("Alegeti Consilier");

            //data de start va fi pusa default data de azi 
            TextBox4.Text = DateTime.Now.ToString("yyyy-MM-dd");

            //seteaza ca valoare default a listei de consilieri user-ul care este logat
            string nume,prenume;
            if (Request.Cookies["UserName"] != null && !Request.Cookies["UserName"].Value.Contains("admin"))
            {
                nume = Request.Cookies["UserName"].Value.Split('.')[1].ToUpper();
                prenume = Request.Cookies["UserName"].Value.Split('.')[0].ToUpper();
                AngDownList.SelectedValue =nume+' '+prenume;
            }
            else if (Request.Cookies["UserName"] != null && Request.Cookies["UserName"].Value.Contains("admin"))
            {
                panel.Enabled = false;
            }
   
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
            if (allCheck.Checked == true)
                dset = pBAL.LoadActiv();
            else if (mineCheck.Checked == true)
                dset = pBAL.LoadPerAngajatActiv(Request.Cookies["UserName"].Value.Split('.')[1], Request.Cookies["UserName"].Value.Split('.')[0]);
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
        if (searchtext1.Value.ToString() != "")
        {
            GridView1.DataSource = GridDataSource_Search(searchtext1.Value.ToString());
            GridView1.DataBind();
        }
        else BindGrid();
    }

    protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
        GridView1.EditIndex = -1;
        if (searchtext1.Value.ToString() != "")
        {
            GridView1.DataSource = GridDataSource_Search(searchtext1.Value.ToString());
            GridView1.DataBind();
        }
        else BindGrid();
    }

    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        if (searchtext1.Value.ToString() != "")
        {
            GridView1.DataSource = GridDataSource_Search(searchtext1.Value.ToString());
            GridView1.DataBind();
        }
        else BindGrid();
    }

        //actualizare
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            System.Data.DataRow row = ((System.Data.DataRowView)e.Row.DataItem).Row;
            if (row["DataFinal"].ToString().Contains("/1900"))
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "myfnc", "myfcn();", true);
        }
        else
        if (!Int32.TryParse(TextBox3.Text.ToString(), out nr)){
            LabelText.Text = "Numarul dosarului nu poate contine litere!";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "myfnc", "myfcn();", true);
        }
        else
        {
            pBAL.Insert(TextBox11.Text.ToString(), TextBox2.Text.ToString(), Int32.Parse(TextBox3.Text.ToString()), TextBox4.Text.ToString(), TextBox5.Text.ToString(), TextBox6.Text.ToString(), AngDownList.SelectedValue.ToString(), Request.Cookies["UserName"].Value);
            
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

    protected void mineCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (mineCheck.Checked == true)
        {
            allCheck.Checked = false;
            GridView1.DataSource = GridDataSource();
            GridView1.DataBind();
        }
        else if ((allCheck.Checked == false) && (mineCheck.Checked == false))
            allCheck.Checked = true;
    }

    protected void allCheck_CheckedChanged(object sender, EventArgs e)
    {
        if (allCheck.Checked == true)
        {
            mineCheck.Checked = false;
            GridView1.DataSource = GridDataSource();
            GridView1.DataBind();
        }
        else if ((allCheck.Checked == false) && (mineCheck.Checked == false))
            mineCheck.Checked = true;
    }


    }
}