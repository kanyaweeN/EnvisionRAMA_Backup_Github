using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using Envision.Plugin.DirectPrint;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class XtraReportChangeStatus : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportChangeStatus(DataSet data)
        {
            InitializeComponent();

            Invoke(data);
        }
        public void Invoke(DataSet data)
        {
            DataTable dtheader = new DataTable();
            dtheader = data.Tables[0];

            REPORT_HEADER.Text = string.Format(dtheader.Rows[0]["REPORT_HEADER_FORMAT"].ToString(), Convert.ToDateTime(dtheader.Rows[0]["DATE_BEGIN"]), Convert.ToDateTime(dtheader.Rows[0]["DATE_END"]));

            COLUMN_HEADER_01.Text = dtheader.Rows[0]["COLUMN_HEADER_01"].ToString();
            COLUMN_HEADER_02.Text = dtheader.Rows[0]["COLUMN_HEADER_02"].ToString();
            COLUMN_HEADER_03.Text = dtheader.Rows[0]["COLUMN_HEADER_03"].ToString();
            COLUMN_HEADER_04.Text = dtheader.Rows[0]["COLUMN_HEADER_04"].ToString();
            COLUMN_HEADER_05.Text = dtheader.Rows[0]["COLUMN_HEADER_05"].ToString();
            COLUMN_HEADER_06.Text = dtheader.Rows[0]["COLUMN_HEADER_06"].ToString();
            COLUMN_HEADER_07.Text = dtheader.Rows[0]["COLUMN_HEADER_07"].ToString();
            COLUMN_HEADER_08.Text = dtheader.Rows[0]["COLUMN_HEADER_08"].ToString();
            COLUMN_HEADER_09.Text = dtheader.Rows[0]["COLUMN_HEADER_09"].ToString();
            COLUMN_HEADER_10.Text = dtheader.Rows[0]["COLUMN_HEADER_10"].ToString();
            COLUMN_HEADER_11.Text = dtheader.Rows[0]["COLUMN_HEADER_11"].ToString();

            this.DataSource = data.Tables[1];
        }
    }
}
