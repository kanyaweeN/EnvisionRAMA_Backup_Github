using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Envision.BusinessLogic;
using System.Data;

namespace Envision.Plugin.XtraFile.xtraReports
{
    public partial class xrptACAcademicReport : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime FromDate;
        DateTime ToDate;
        int EmpID;
        string Mode;

        DataSet dsData;

        public xrptACAcademicReport(DateTime FromDate, DateTime ToDate, int EmpID, string Mode)
        {
            InitializeComponent();

            this.DataSource = dsData;

            this.FromDate = FromDate;
            this.ToDate = ToDate;
            this.EmpID = EmpID;
            this.Mode = Mode;

            ReloadData();
        }

        private void LoadDataGrid()
        {
            LookUpSelect lk = new LookUpSelect();
            dsData = lk.SelectACAcademicReport(FromDate, ToDate, EmpID, Mode);
        }
        private void LoadDataFilter()
        {
        }
        private void LoadDataControl()
        {
            //xrRadiologist.DataBindings.Add("Text", dsData, "RAD_NAME","");
            //xrExamType.DataBindings.Add("Text", dsData, "EXAM_TYPE_TEXT", "");
            //xrExamName.DataBindings.Add("Text", dsData, "EXAM_NAME", "");
            //xrNumberOfReport.DataBindings.Add("Text", dsData, "NumberOfReporting", "");
            gridControl1.DataSource = dsData;
           //gridView1.show
        }
        private void ReloadData()
        {
            LoadDataGrid();
            LoadDataFilter();
            LoadDataControl();
        }
    }
}
