﻿using System;
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


namespace ProbatiuneApp
{
    public partial class _Default : Page
    {
        private BAL.BusinessLayer pBAL = new BAL.BusinessLayer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
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
            pBAL.Delete(id);
            BindGrid();
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

          protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)  
    {  
        //NewEditIndex property used to determine the index of the row being edited.  
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();  
    }  
    protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)  
    {  
        //Finding the controls from Gridview for the row which is going to update  
        Label id=GridView1.Rows[e.RowIndex].FindControl("lbl_IDCazz") as Label;  
        TextBox Nume = GridView1.Rows[e.RowIndex].FindControl("txt_Nume") as TextBox;  
        TextBox Prenume = GridView1.Rows[e.RowIndex].FindControl("txt_Prenume") as TextBox;
        TextBox Prenume2 = GridView1.Rows[e.RowIndex].FindControl("txt_Prenume2") as TextBox;
        TextBox NrDosar = GridView1.Rows[e.RowIndex].FindControl("txt_NrDosar") as TextBox;
        TextBox StartDate = GridView1.Rows[e.RowIndex].FindControl("txt_Start") as TextBox;
        TextBox TheEnd = GridView1.Rows[e.RowIndex].FindControl("txt_TheEnd") as TextBox;
        TextBox Observatii = GridView1.Rows[e.RowIndex].FindControl("txt_Observatii") as TextBox;
        TextBox NumeAng = GridView1.Rows[e.RowIndex].FindControl("txt_NumeAng") as TextBox;
        TextBox PrenumeAng = GridView1.Rows[e.RowIndex].FindControl("txt_PrenumeAng") as TextBox;
      
        //updating the record  
       
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

    }
}