using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Windows.Forms;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptResultReport : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable dtData;
        private string NameUser,ExName;
        public xrptResultReport()
        {
            InitializeComponent();
        }
        public xrptResultReport(DataTable dt,string empName,string exName)
        {
            InitializeComponent();
            dtData = new DataTable();
            dtData = dt;
            NameUser = empName;
            ExName = exName;
        }
        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            int count = dtData.Rows.Count;
            string showAddendum= "";
            for (int i = dtData.Rows.Count-1; i >=0; i--)
            {
                if (string.IsNullOrEmpty(dtData.Rows[i]["Expr1"].ToString()))
                {
                    txtAddendum.Visible = false;
                    xrLine3.Visible = false;
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(dtData.Rows[i]["NOTE_ON"]);

                    showAddendum += "Addendum : " + Convert.ToString(i+1) + " , Written By : " + dtData.Rows[i]["CreateOrder"].ToString() + " Date : " + dt.ToString() + "\r\n"
                                        + dtData.Rows[i]["Expr1"].ToString() + "\r\n\r\n";//rt.Text;
                    //if (dtData.Rows.Count == count)
                    //    showAddendum += "\r\n ---------------------------------------------------------------------------";
                    //dr["Expr1"] = showAddendum;
                }
            }
            txtAddendum.Text = showAddendum;
            
        }

        private void PageFooter_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (string.IsNullOrEmpty(dtData.Rows[0]["ResultDoctor"].ToString()))
                //if (string.IsNullOrEmpty(dtData.Rows[0]["PRELIM_FOOTER1"].ToString()))
                //    lblRadiologist.Text = "";
                //else
                //    lblRadiologist.Text =  dtData.Rows[0]["PRELIM_FOOTER1"].ToString();
            //else
            lblRadiologist.Text = dtData.Rows[0]["ResultDoctor"].ToString();

            lblPrintByDate.Text = "Printed by : "+NameUser;
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void GroupFooter1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (dtData.Rows.Count > 0)
            //{
            //    switch (dtData.Rows[0]["RESULT_STATUS"].ToString())
            //    {
            //        case "D": lblShowStatus.Text = "Draft"; break;
            //        case "P": lblShowStatus.Text = "Preliminary"; break;
            //    }
            //}
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (dtData.Rows.Count > 0)
            {
                lblShowStatus.Visible = true;
                switch (dtData.Rows[0]["RESULT_STATUS"].ToString())
                {
                    case "D": lblShowStatus.Text = "Draft"; break;
                    case "P": lblShowStatus.Text = "Preliminary"; break;
                    default :lblShowStatus.Visible = false;break;
                }
            }
            lblExamName.Text = ExName;
        }
    }
}
