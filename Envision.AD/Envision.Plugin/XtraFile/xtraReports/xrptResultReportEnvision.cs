using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptResultReportEnvision : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable dtData;
        private string NameUser, ExName;
        private string ResultText;
        public xrptResultReportEnvision()
        {
            InitializeComponent();
        }
        public xrptResultReportEnvision(DataTable dt, string empName, string exName)
        {
            InitializeComponent();
            dtData = new DataTable();
            dtData = dt;
            NameUser = empName;
            ExName = exName;
        }
        /// <summary>
        /// This constructor use for birad preview report
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="empName"></param>
        /// <param name="exName"></param>
        public xrptResultReportEnvision(DataTable dt, string empName, string exName, string result_text)
        {
            InitializeComponent();
            dtData = new DataTable();
            dtData = dt;
            NameUser = empName;
            ExName = exName;
            this.ResultText = result_text;
            
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblAddress.Text = dtData.Rows[0]["ORG_ADDR1"].ToString() + " " + dtData.Rows[0]["ORG_ADDR2"].ToString() + " " + dtData.Rows[0]["ORG_ADDR3"].ToString() + " " + dtData.Rows[0]["ORG_ADDR4"].ToString() + "\r\n" +
                                "Tel : " + dtData.Rows[0]["ORG_TEL1"].ToString() + "\r\n" +
                                "Fax : " + dtData.Rows[0]["ORG_FAX"].ToString() + "\r\n" +
                                "Email : " + dtData.Rows[0]["ORG_EMAIL1"].ToString();

            int count = dtData.Rows.Count;
            string showAddendum = "";
            for (int i = dtData.Rows.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrEmpty(dtData.Rows[i]["Expr1"].ToString()))
                {
                    txtAddendum.Visible = false;
                    xrLine6.Visible = false;
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(dtData.Rows[i]["NOTE_ON"]);

                    showAddendum += "Addendum : " + Convert.ToString(i + 1) + " , Written By : " + dtData.Rows[i]["CreateOrder"].ToString() + " Date : " + dt.ToString() + "\r\n"
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
            lblRadiologist.Text = dtData.Rows[0]["ResultDoctor"].ToString();

            //lblPrintByDate.Text = "Printed by : " + NameUser;
        }

        private void GroupHeader1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
        /// <summary>
        /// Group Footer 2 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupFooter2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (ResultText != null)
            {
                if (ResultText.Length > 0)
                {
                    this.xrRichText1.Rtf = ResultText;
                }
                else
                {
                    this.xrRichText1.Rtf = ((DataTable)this.DataSource).Rows[0]["RESULT_TEXT_PLAIN"].ToString();
                }
            }
            else
            {
                this.xrRichText1.Rtf = ((DataTable)this.DataSource).Rows[0]["RESULT_TEXT_PLAIN"].ToString();
            }

            if (((DataTable)this.DataSource).Rows[0]["ISCOVID"].ToString() == "Y")
                rtCovidCategory.Visible = true;
        }

    }
}
