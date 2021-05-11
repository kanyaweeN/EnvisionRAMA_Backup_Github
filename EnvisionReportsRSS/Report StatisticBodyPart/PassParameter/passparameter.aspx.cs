using Envision.BusinessLogic;
using Envision.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using Microsoft.Reporting.WebForms;

namespace PassParameter
{
    public partial class passparameter : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection("Data Source=USER-PC;Initial Catalog=RIS_BCH;Integrated Security=True");
        public string ModalityID = "";
        public List<String> ModalityID_list = new List<string>();
        public List<String> ModalityName_list = new List<string>();
        public static string[] src;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }
        protected void BindData()
        {
            OrderDtl orderdtl = new OrderDtl();
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
            foreach (System.Web.UI.WebControls.ListItem selItem in ddchkModality.Items)
            {

                if (selItem.Selected)
                {
                    ModalityID_list.Add(selItem.Value);
                    ModalityName_list.Add(selItem.Text);

                }
                ddchkModality.Texts.SelectBoxCaption = String.Join(",", ModalityName_list.ToArray());
                src = ModalityID_list.ToArray();

            }
        }
        public string startDate
        {
            get
            {
                return txtStartDate.Text;
            }
        }
        public string endDate
        {
            get
            {
                return txtEndDate.Text;
            }
        }
        public string[] modalityselect
        {
            get
            {
                return src;
            }
        }

    }
}