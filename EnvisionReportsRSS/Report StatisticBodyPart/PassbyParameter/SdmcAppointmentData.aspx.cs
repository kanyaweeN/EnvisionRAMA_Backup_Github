using Envision.BusinessLogic;
using Envision.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PassbyParameter
{
    public partial class SdmcAppointmentData : System.Web.UI.Page
    {
        public string ModalityID = "";
        public List<String> roomID_list = new List<string>();
        public List<String> roomName_list = new List<string>();
        public List<String> sessionID_list = new List<string>();
        public List<String> sessionName_list = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            txtStartDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtEndDate.Text = DateTime.Today.ToString("yyyy-MM-dd");

            DataSet ds;
            HrUnit hrUnit = new HrUnit();
            ds = new DataSet();
            ds = hrUnit.Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                drpRoom.DataSource = ds.Tables[0];
                drpRoom.DataTextField = "UNIT_NAME_ALIAS";//UNIT_NAME
                drpRoom.DataValueField = "UNIT_ID";
                drpRoom.DataBind();
            }

            RisClinicSession session = new RisClinicSession();
            ds = new DataSet();
            ds = session.Select();

            if (ds.Tables[0].Rows.Count > 0)
            {
                drpSession.DataSource = ds.Tables[0];
                drpSession.DataTextField = "SESSION_NAME";
                drpSession.DataValueField = "SESSION_ID";
                drpSession.DataBind();
            }
        }

        static string[] srcRoom;
        static string[] srcSession;

        protected void drpRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (System.Web.UI.WebControls.ListItem item in drpRoom.Items)
            {
                var ss = roomID_list.Find(x => x.ToString() == item.Value);
                if (ss == null)
                {
                    if (item.Selected)
                    {
                        roomID_list.Add(item.Value);
                        roomName_list.Add(item.Text);

                    }
                    drpRoom.Texts.SelectBoxCaption = String.Join(",", roomName_list.ToArray());
                    srcRoom = roomID_list.ToArray();
                }
            }
        }

        protected void drpSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (System.Web.UI.WebControls.ListItem item in drpSession.Items)
            {
                var ss = sessionID_list.Find(x => x.ToString() == item.Value);
                if (ss == null)
                {
                    if (item.Selected)
                    {
                        sessionID_list.Add(item.Value);
                        sessionName_list.Add(item.Text);

                    }
                    drpSession.Texts.SelectBoxCaption = String.Join(",", sessionName_list.ToArray());
                    srcSession = sessionID_list.ToArray();
                }
            }
        }


        public void btnRun_Click(object sender, EventArgs e)
        {
           
            //if (txtStartDate.Text == "")
            //if (string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text) && srcRoom == null)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Enter Data " + "');", true);
            //}
            //else if (string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text) && srcRoom != null)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Enter DateStart And EndDate" + "');", true);
            //}
            //else if (string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text) && srcRoom != null)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Enter DateStart " + "');", true);
            //}
            //else if (!string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text) && srcRoom == null)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Enter EndDate And Select Modality" + "');", true);
            //}
            //else if (!string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text) && srcRoom == null)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Select Modality " + "');", true);
            //}
            //else if (string.IsNullOrEmpty(txtStartDate.Text) && !string.IsNullOrEmpty(txtEndDate.Text) && srcRoom == null)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Enter DateStart And Select Modality" + "');", true);
            //}
            //else if (!string.IsNullOrEmpty(txtStartDate.Text) && string.IsNullOrEmpty(txtEndDate.Text) && srcRoom != null)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Please Enter DateEnd" + "');", true);
            //}
            //else
            //{
                Server.Transfer("displaydata.aspx");
            //}

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
        public string[] roomSelect
        {
            get
            {
                return srcRoom;
            }
        }

        public string[] sessionSelect
        {
            get
            {
                return srcSession;
            }
        }

       





 
    }
}