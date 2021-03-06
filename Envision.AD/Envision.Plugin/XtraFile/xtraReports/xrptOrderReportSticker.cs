using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Xml;
using System.Data;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Miracle.Translator;
using DevExpress.XtraReports.UI;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptOrderReportSticker : DevExpress.XtraReports.UI.XtraReport
    {
        public xrptOrderReportSticker(string HN)
        {
            InitializeComponent();

            DataTable tbHN = new DataTable();

            #region Page Setting
            //this.DefaultPrinterSettingsUsing.UseMargins = true;
            #endregion

            #region Get Paient Data
            ProcessGetHISRegistration getReg = new ProcessGetHISRegistration(HN);
            getReg.Invoke();
            tbHN = getReg.Result.Tables[0];
            #endregion

            #region Bind Control Data
            DataRow drHN = tbHN.Rows[0];
            txtBarCode.Text = drHN["HN"].ToString();
            txtHN.Text = drHN["HN"].ToString();
            txtPatientName.Text = drHN["TITLE"].ToString().Trim()
                + drHN["FNAME"].ToString().Trim()
                + " " + drHN["LNAME"].ToString().Trim();
            txtAge.Text = drHN["AGE2"].ToString();
            txtGender.Text = drHN["GENDER"].ToString();
            #endregion

            this.Parameters.Clear();
        }
    }
}
