using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ReportingPassParameter
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=USER-PC;Initial Catalog=RIS_BCH;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
            //if (!IsPostBack)
            //{
            //    var years = new int[20];
            //    var currentYear = DateTime.Now.Year;

            //    for (int i = 0; i < years.Length; i++)
            //        years[i] = currentYear--;

            //    //yearsDropDownCheckBoxes.DataSource = years;
            //    //yearsDropDownCheckBoxes.DataBind();
            //}
        }

        protected void ImageBtnStart_Click(object sender, ImageClickEventArgs e)
        {
            CalendarStart.Visible = true;
        }

        protected void CalendarStart_SelectionChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = CalendarStart.SelectedDate.ToString();
            CalendarStart.Visible = false;
        }

        protected void ImageBtnEnd_Click(object sender, ImageClickEventArgs e)
        {
            CalendarEndDate.Visible = true;
        }

        protected void CalendarEndDate_SelectionChanged(object sender, EventArgs e)
        {
            txtEndDate.Text = CalendarEndDate.SelectedDate.ToString();
            CalendarEndDate.Visible = false;
        }

        protected void BindData()
        { 
            DataSet ds = new DataSet();
            string cmdstr = "select distinct RIS_MODALITY.MODALITY_NAME, RIS_ORDERDTL.MODALITY_ID from RIS_ORDERDTL inner join RIS_MODALITY on RIS_ORDERDTL.MODALITY_ID = RIS_MODALITY.MODALITY_ID";
            SqlDataAdapter adp = new SqlDataAdapter(cmdstr, conn);
            adp.Fill(ds);
       
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddchkModality.DataSource = ds.Tables[0];
                ddchkModality.DataTextField = "MODALITY_NAME";
                ddchkModality.DataValueField = "MODALITY_ID";
                ddchkModality.DataBind();
            } 

        }

        protected void ddchkModality_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> ModalityID_list = new List<string>();
            List<String> ModalityName_list = new List<string>();


            foreach (System.Web.UI.WebControls.ListItem item in ddchkModality.Items)
            {
                if (item.Selected)
                {
                    //ModalityID_list.Add(item.Value);
                    ModalityName_list.Add(item.Text);
                    
                }
                lblModalityName.Text = "Choose Data: " + String.Join(",", ModalityName_list.ToArray());
            } 
        } 
    }
}