using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnvisionOnline.BusinessLogic;
using System.Data;

using EnvisionOnline.BusinessLogic.ProcessRead;
using System.IO;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.Forms.Dialogs
{
    public partial class OnlineAlertPatientPhone : System.Web.UI.Page
    {
        private string reg_id, strXTRAFORM, strIS_ONLINE, strORDER_ID, printor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                reg_id = Request.Params["REG_ID"];
                get_Patient_Data(reg_id.Trim());


                strXTRAFORM = Request.Params["XTRAFORM"];
                strIS_ONLINE = Request.Params["IS_ONLINE"];
                strORDER_ID = Request.Params["ORDER_ID"];
                reg_id = Request.Params["REG_ID"];

                set_Patient_Data();

                GBLEnvVariable env = Session["GBLEnvVariable"] as GBLEnvVariable;
                ProcessScheduleReport slkpDirect = new ProcessScheduleReport();
                slkpDirect.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(strORDER_ID);
                slkpDirect.RIS_SCHEDULE.ORG_ID = env.OrgID;
                slkpDirect.getReport();

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            strXTRAFORM = Request.Params["XTRAFORM"];
            strIS_ONLINE = Request.Params["IS_ONLINE"];
            strORDER_ID = Request.Params["ORDER_ID"];
            reg_id = Request.Params["REG_ID"];
            printor = Request.Params["PRINTOR"];

            //int p, p2;
            //bool phone1 = int.TryParse(txtPhone.Text.ToString(), out p);
            //bool phone2 = int.TryParse(txtPhone2.Text.ToString(), out p2);
            //if (phone1 || phone2)
            //{
            //    if ((txtPhone.Text.Length > 8) || (txtPhone2.Text.Length > 8))
            //    {
            set_Patient_Data();

            string url = @"../../ReportViewer/frmXtraReportViewer.aspx?XTRAFORM=" + strXTRAFORM + "&IS_ONLINE=" + strIS_ONLINE + "&ORDER_ID=" + strORDER_ID + "&PRINTOR=" + printor;
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "PrintAndClose('" + url + "');", true);
            //    }
            //} 
        }

        private void set_Patient_Data()
        {
            PatientClass pat = new PatientClass();
            pat.HIS_REGISTRATION.REG_ID = Convert.ToInt32(reg_id);
            pat.HIS_REGISTRATION.PHONE1 = txtPhone.Text;
            pat.HIS_REGISTRATION.PHONE2 = txtPhone2.Text;
            pat.HIS_REGISTRATION.EMAIL = "";
            pat.set_Patient_Phone();
        }
        private void get_Patient_Data(string reg_id)
        {
            PatientClass pat = new PatientClass();
            DataSet ds = pat.get_Patient_Registration_ByREG_ID(Convert.ToInt32(reg_id));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lblPatient.Text = "HN : " + dr["HN"].ToString() + "\r\n";
                lblPatient2.Text = "Name : " + dr["TITLE"].ToString() + dr["FNAME"].ToString() + " " + dr["LNAME"].ToString() + "\r\n";

                txtPhone.Text = dr["PHONE1"].ToString();
                txtPhone2.Text = dr["PHONE2"].ToString();
                //txtPhone.Text = "-";
                //txtPhone2.Text = "-";
            }
        }

        

    }
}
