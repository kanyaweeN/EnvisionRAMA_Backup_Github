using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using EnvisionOnline.Common.Common;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Common;

using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.Common.Common;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using EnvisionOnline.Operational;
using System.Globalization;
using EnvisionOnline.Common;
using System.IO;
using System.Drawing;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic.ProcessUpdate;
using EnvisionOnline.BusinessLogic.ProcessRead;

namespace EnvisionOnline.ReportViewer.Reports
{
    public partial class xrptScheduleReportAIMCNew : DevExpress.XtraReports.UI.XtraReport
    {
        public bool HasData { get; set; }
        public int ScheduleID { get; set; }

        private int schedule_id, org_id;
        private string printor_name;

        public xrptScheduleReportAIMCNew()
        {
            InitializeComponent();
            this.PrintingSystem.ShowMarginsWarning = false;
        }
        public xrptScheduleReportAIMCNew(int _schedule_id, int _org_id, string _printor_name)
        {
            InitializeComponent();
            this.PrintingSystem.ShowMarginsWarning = false;
            schedule_id = _schedule_id;
            org_id = _org_id;
            printor_name = _printor_name;

            initReport();
        }
        private void initReport()
        {
            DataSet ds = new DataSet();

            ProcessScheduleReport slkp = new ProcessScheduleReport();
            slkp.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(schedule_id);
            slkp.RIS_SCHEDULE.ORG_ID = org_id;
            slkp.getReportAIMC();
            ds = slkp.ResultSet;
            HasData = true;

            bindingData(ds);
        }
        private void bindingData(DataSet ds)
        {
            DataSource = ds.Tables[0];
            lblPrintBy.Text = "ผู้ออกบัตรนัด : " + printor_name;
            lblPrintBy.Text += "ออกบัตรนัดวันที่ : " + ds.Tables[1].Rows[0]["SCH_PRINT_DATETIME"].ToString();
        }
    }
}
