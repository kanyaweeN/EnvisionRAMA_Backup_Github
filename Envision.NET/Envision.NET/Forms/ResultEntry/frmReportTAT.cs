using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using Envision.NET.Forms.Dialog;
using Envision.BusinessLogic;
using Envision.NET.Forms.Main;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.NET.Forms.ResultEntry
{
    public partial class frmReportTAT : Envision.NET.Forms.Main.MasterForm// Form
    {
        private ProcessGetRISExamresulttime _prctime;
        private int Rad_ID = 0;
        private bool FilterByAcc = false;
        private DataSet _chartdata = new DataSet();
        private DataSet _chartdataCompare1 = new DataSet();
        private DataSet _chartdataCompare2 = new DataSet();
        
        DevExpress.XtraCharts.ViewType _viewtype = DevExpress.XtraCharts.ViewType.Bar;
        DevExpress.XtraCharts.ViewType _viewtypeCompare = DevExpress.XtraCharts.ViewType.Bar;
        public frmReportTAT()
        {
            InitializeComponent();
        }

        private void frmReportTAT_Load(object sender, EventArgs e)
        {
            dtFromdate.DateTime = DateTime.Now;
            dtTodate.DateTime = DateTime.Now;
            dtStartCompare.DateTime = DateTime.Now;
            dtEndCompare.DateTime = DateTime.Now;
            dtStartCompare2.DateTime = DateTime.Now;
            dtEndCompare2.DateTime = DateTime.Now;

            InitializeCheckBox();
            chkExamTypeSelect();
            InitializeData(true, false);
            InitializeGrid();
            base.CloseWaitDialog();
        }
        private void InitializeCheckBox()
        {
             ProcessGetRISExamType prc = new ProcessGetRISExamType();
            prc.Invoke();
            DataSet dsExamType = prc.Result.Copy();
            foreach (DataRow dr in dsExamType.Tables[0].Rows)
            {
                chklExamType.Items.Add(dr["EXAM_TYPE_UID"].ToString(), true);
            }
        }
        private void InitializeGrid()
        {
            
				for (int i = 0; i < gvResulttime.Columns.Count; i++)
					gvResulttime.Columns[i].Visible = false;

                gvResulttime.Columns["ACCESSION_NO"].Caption = "Accession No.";
                gvResulttime.Columns["SL_NO"].Caption = "Serial No.";
                gvResulttime.Columns["EXAM_NAME"].Caption = "Exam name";
                gvResulttime.Columns["Radiologist"].Caption = "Radiologist/Resident";//"Priority";
                gvResulttime.Columns["START_STATUS_TEXT"].Caption = "Start from status";
                gvResulttime.Columns["START_ON"].Caption = "Start on";
                gvResulttime.Columns["LAST_SAVED_STATUS_TEXT"].Caption = "Last save status";
                gvResulttime.Columns["LAST_SAVED_ON"].Caption = "Last save";
                gvResulttime.Columns["TAT"].Caption = "TAT";

                gvResulttime.Columns["START_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:MM:ss";
                gvResulttime.Columns["LAST_SAVED_ON"].DisplayFormat.FormatString = "dd/MM/yyyy HH:MM:ss";

                gvResulttime.Columns["ACCESSION_NO"].VisibleIndex = 0;
                gvResulttime.Columns["SL_NO"].VisibleIndex = 1;
                gvResulttime.Columns["EXAM_NAME"].VisibleIndex = 2;
                gvResulttime.Columns["Radiologist"].VisibleIndex = 3;
                gvResulttime.Columns["START_STATUS_TEXT"].VisibleIndex = 4;
                gvResulttime.Columns["START_ON"].VisibleIndex = 5;
                gvResulttime.Columns["LAST_SAVED_STATUS_TEXT"].VisibleIndex = 6;
                gvResulttime.Columns["LAST_SAVED_ON"].VisibleIndex = 7;
                gvResulttime.Columns["TAT"].VisibleIndex = 8;

                gvResulttime.Columns["ACCESSION_NO"].Visible = true;
                gvResulttime.Columns["SL_NO"].Visible = true;
				gvResulttime.Columns["EXAM_NAME"].Visible = true;
                gvResulttime.Columns["Radiologist"].Visible = true;
                gvResulttime.Columns["START_STATUS_TEXT"].Visible = true;
                gvResulttime.Columns["START_ON"].Visible = true;
                gvResulttime.Columns["LAST_SAVED_STATUS_TEXT"].Visible = true;
                gvResulttime.Columns["LAST_SAVED_ON"].Visible = true;
                gvResulttime.Columns["TAT"].Visible = true;

                gvResulttime.Columns["ACCESSION_NO"].MinWidth = 100;
                gvResulttime.Columns["SL_NO"].MinWidth = 25;
                gvResulttime.Columns["SL_NO"].Width = 25;
                gvResulttime.Columns["EXAM_NAME"].MinWidth = 120;
                gvResulttime.Columns["Radiologist"].MinWidth = 100;
                gvResulttime.Columns["START_STATUS_TEXT"].MinWidth = 40;
                gvResulttime.Columns["START_ON"].MinWidth = 100;
                gvResulttime.Columns["LAST_SAVED_STATUS_TEXT"].MinWidth = 40;
                gvResulttime.Columns["LAST_SAVED_ON"].MinWidth = 100;
                gvResulttime.Columns["TAT"].MinWidth = 100;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            InitializeData(false,false);
        }

        private void chkShowall_CheckedChanged(object sender, EventArgs e)
        {
            InitializeData(false,false);
        }

        private void btnRadSelect_Click(object sender, EventArgs e)
        {
            LookUpSelect lvS = new LookUpSelect();

            Envision.NET.Forms.Dialog.LookupData lv = new Envision.NET.Forms.Dialog.LookupData();
            lv.ValueUpdated += new Envision.NET.Forms.Dialog.ValueUpdatedEventHandler(RadSelect_ValueUpdated);

            lv.AddColumn("EMP_ID", "Status Name", false, true);
            lv.AddColumn("EMP_UID", "Rad. Code", true, false);
            lv.AddColumn("RadioName", "Rad. Name", true, true);
            lv.AddColumn("AUTH_LEVEL_ID", "Status Name", false, false);
            lv.AddColumn("ALLOW_OTHER_TO_FINALIZE", "Status ID", false, false);
            lv.AddColumn("UIDAndRadioName", "Description", false, false);
            lv.AddColumn("RadioNameEng", "Description", false, false);

            lv.Text = "Search Radiologist";

            lv.Data = RISBaseData.Ris_Radiologist().Copy();
            lv.Size = new Size(600, 400);
            lv.ShowBox();
        }
        private void RadSelect_ValueUpdated(object sender, Envision.NET.Forms.Dialog.ValueUpdatedEventArgs e)
        {
            string[] retValue = e.NewValue.Split(new Char[] { '^' });
            Rad_ID = Convert.ToInt32(retValue[0].ToString());
            txtRad.Text = retValue[2];
        }
        public void InitializeData(bool _byAcc,bool _isCompare)
        {
            bool check = false;
            for (int i = 0; i < chklExamType.Items.Count; i++)
			{
                if (chklExamType.Items[i].CheckState == CheckState.Checked)
                    check = true;
			}
            if (check)
            {
                layoutControlItem5.AppearanceItemCaption.ForeColor = Color.FromArgb(0,0,0);
                chklExamType.Appearance.ForeColor = Color.FromArgb(0, 0, 0);
                if (!_isCompare)
                {
                    if (_byAcc)
                    {
                        if (Rad_ID == 0)
                        {
                            _prctime = new ProcessGetRISExamresulttime();
                            _prctime.execExamType = GenerateexecExamType();
                            _prctime.SelectByAccessionNo(txtAccession.Text);
                            gcMain.DataSource = _prctime.ResultSet.Tables[0].Copy();

                            InitializeDataSummary(2);
                            InitializeDataSummaryChart(2);
                        }
                        else
                        {
                            _prctime = new ProcessGetRISExamresulttime();
                            _prctime.execExamType = GenerateexecExamType();
                            _prctime.SelectByAccessionNoRad(txtAccession.Text, Rad_ID);
                            gcMain.DataSource = _prctime.ResultSet.Tables[0].Copy();

                            InitializeDataSummary(3);
                            InitializeDataSummaryChart(3);
                        }
                    }
                    else
                    {
                        if (chkShowall.Checked)
                        {
                            _prctime = new ProcessGetRISExamresulttime();
                            _prctime.execExamType = GenerateexecExamType();
                            _prctime.Invoke(Rad_ID);
                            gcMain.DataSource = _prctime.ResultSet.Tables[0].Copy();

                            InitializeDataSummary(1);
                            InitializeDataSummaryChart(1);

                            dtFromdate.Enabled = false;
                            dtTodate.Enabled = false;
                            timeStart.Enabled = false;
                            timeEnd.Enabled = false;
                        }
                        else
                        {
                            DateTime start = new DateTime(dtFromdate.DateTime.Year, dtFromdate.DateTime.Month,
                                dtFromdate.DateTime.Day, timeStart.Time.Hour, timeStart.Time.Minute, timeStart.Time.Second);
                            DateTime End = new DateTime(dtTodate.DateTime.Year, dtTodate.DateTime.Month,
                                dtTodate.DateTime.Day, timeEnd.Time.Hour, timeEnd.Time.Minute, timeEnd.Time.Second);
                            _prctime = new ProcessGetRISExamresulttime();
                            _prctime.execExamType = GenerateexecExamType();
                            _prctime.SelectByDate(Rad_ID, start, End);
                            gcMain.DataSource = _prctime.ResultSet.Tables[0].Copy();

                            InitializeDataSummary(4);
                            InitializeDataSummaryChart(4);

                            dtFromdate.Enabled = true;
                            dtTodate.Enabled = true;
                            timeStart.Enabled = true;
                            timeEnd.Enabled = true;
                        }
                    }
                    FilterByAcc = _byAcc;
                    if (gvResulttime.RowCount >= 0)
                    {
                        DataRow _dr = gvResulttime.GetDataRow(0);
                        fillData(_dr);
                    }
                }
                else
                {
                    if (Rad_ID > 0)
                    {
                        InitializeDataSummaryChartCompare(4);
                        InitializeDataSummaryChartCompare2(4);
                        InitializeCompare();
                        dtStartCompare.Enabled = true;
                        dtEndCompare.Enabled = true;
                        timeStartCompare.Enabled = true;
                        timeEndCompare.Enabled = true;

                    }
                }
            }
            else
            {
                layoutControlItem5.AppearanceItemCaption.ForeColor = Color.Red;
                chklExamType.Appearance.ForeColor = Color.Red;
            }
        }

        private string GenerateexecExamType()
        {
            bool firstChar = true;
            string reStr = " select EXAM_TYPE_UID from RIS_EXAMTYPE where EXAM_TYPE_UID in (";
            for (int i = 0; i < chklExamType.Items.Count; i++)
            {
                if (firstChar)
                {
                    if (chklExamType.Items[i].CheckState == CheckState.Checked)
                    {
                        reStr += "'" + chklExamType.Items[i].Value.ToString() + "'";
                        firstChar = false;
                    }
                }
                else
                {
                    if (chklExamType.Items[i].CheckState == CheckState.Checked)
                        reStr += ",'" + chklExamType.Items[i].Value.ToString() + "'";
                }
            }
            reStr += ")";
            return reStr;
        }
        private void InitializeDataSummary(int _Condition)
        {
            string Query = "";
            string SelectionQuery = @"select  pv.REPORT_ON ";
            string ConditionQuery = "";
            string PrivotQuery = @") as src	pivot (avg(REPORT_TIME) for EXAM_TYPE_UID in (";
            string SubSelectionQuery = @"	SELECT     CONVERT(date, MIN(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_ON, 
			   DATEDIFF(second, MIN(RIS_EXAMRESULTTIME.START_ON), MAX(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_TIME, 
			   RIS_EXAMTYPE.EXAM_TYPE_UID
FROM         RIS_EXAMRESULTTIME INNER JOIN
                      RIS_ORDERDTL ON RIS_EXAMRESULTTIME.ACCESSION_NO = RIS_ORDERDTL.ACCESSION_NO INNER JOIN
                      RIS_EXAM ON RIS_ORDERDTL.EXAM_ID = RIS_EXAM.EXAM_ID INNER JOIN
                      RIS_EXAMTYPE ON RIS_EXAM.EXAM_TYPE = RIS_EXAMTYPE.EXAM_TYPE_ID ";
            for (int i = 0; i < chklExamType.Items.Count; i++)
            {
                if (chklExamType.Items[i].CheckState == CheckState.Checked)
                {
                    SelectionQuery += @",dbo.fnConvertMin_fulldigit_HourMinuteSecond(" + chklExamType.Items[i].Value.ToString() + @",N'EN') as " + chklExamType.Items[i].Value.ToString();

                    if (PrivotQuery.Length == 55)
                        PrivotQuery += chklExamType.Items[i].Value.ToString();
                    else
                        PrivotQuery += @"," + chklExamType.Items[i].Value.ToString();
                }
            }
            PrivotQuery += @")) as pv order by    pv.REPORT_ON";
            SelectionQuery += @" from (";
            ConditionQuery += @" WHERE RIS_EXAMRESULTTIME.LAST_SAVED_ON IS NOT NULL ";
            switch (_Condition)
            {
                //1 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID   
                //2 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO
                //3 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO and RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID  
                //4 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID and RIS_EXAMRESULTTIME.START_ON between dbo.fnc_GetDateOnly(@FROM) and dbo.fnc_GetDateEndDay(@TO)
                case 1:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.RAD_ID = {0} ", Rad_ID.ToString());
                    break;
                case 2:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} ", "'" + txtAccession.Text + "'");
                    break;
                case 3:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} and RIS_EXAMRESULTTIME.RAD_ID = {1} ", "'" + txtAccession.Text + "'", Rad_ID.ToString());
                    break;
                case 4:
                    string fromdate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtFromdate.DateTime.Year.ToString(), dtFromdate.DateTime.Month.ToString(), dtFromdate.DateTime.Day.ToString());
                    string todate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtTodate.DateTime.Year.ToString(), dtTodate.DateTime.Month.ToString(), dtTodate.DateTime.Day.ToString());
                    ConditionQuery += string.Format(@" and RIS_EXAMRESULTTIME.RAD_ID = {0} and RIS_EXAMRESULTTIME.START_ON between 
                    dbo.fnc_GetDateOnly({1}) and dbo.fnc_GetDateEndDay({2}) and 
                    CONVERT(time,RIS_EXAMRESULTTIME.START_ON) between CONVERT(time,'{3}:00') and CONVERT(time,'{4}:59.999')", Rad_ID.ToString(), fromdate, todate, timeStart.Text, timeEnd.Text);
                    break;
                default:
                    break;
            }
            ConditionQuery += @" GROUP BY RIS_EXAMRESULTTIME.ACCESSION_NO, RIS_EXAMTYPE.EXAM_TYPE_UID";
          
            Query = SelectionQuery + SubSelectionQuery + ConditionQuery + PrivotQuery;

            _prctime = new ProcessGetRISExamresulttime();
            _prctime.SelectExecSummary(Query);
            gvSummary.Columns.Clear();
            int k = 1;
            foreach (DataColumn dc in _prctime.ResultSet.Tables[0].Columns)
            {
                DevExpress.XtraGrid.Columns.GridColumn clm = new DevExpress.XtraGrid.Columns.GridColumn();
                clm.Caption = dc.ColumnName;
                clm.FieldName = dc.ColumnName;
                clm.VisibleIndex = k;
                gvSummary.Columns.Add(clm);
                k++;
            }
           
            gcSummary.DataSource = _prctime.ResultSet.Tables[0].Copy(); 
        }
        private void InitializeDataCompare(int _Condition)
        {
            string Query = "";
            string SelectionQuery = @"select  pv.REPORT_ON ";
            string ConditionQuery = "";
            string PrivotQuery = @") as src	pivot (avg(REPORT_TIME) for EXAM_TYPE_UID in (";
            string SubSelectionQuery = @"	SELECT     CONVERT(date, MIN(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_ON, 
			   DATEDIFF(second, MIN(RIS_EXAMRESULTTIME.START_ON), MAX(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_TIME, 
			   RIS_EXAMTYPE.EXAM_TYPE_UID
FROM         RIS_EXAMRESULTTIME INNER JOIN
                      RIS_ORDERDTL ON RIS_EXAMRESULTTIME.ACCESSION_NO = RIS_ORDERDTL.ACCESSION_NO INNER JOIN
                      RIS_EXAM ON RIS_ORDERDTL.EXAM_ID = RIS_EXAM.EXAM_ID INNER JOIN
                      RIS_EXAMTYPE ON RIS_EXAM.EXAM_TYPE = RIS_EXAMTYPE.EXAM_TYPE_ID ";
            for (int i = 0; i < chklExamType.Items.Count; i++)
            {
                if (chklExamType.Items[i].CheckState == CheckState.Checked)
                {
                    SelectionQuery += @",dbo.fnConvertMin_fulldigit_HourMinuteSecond(" + chklExamType.Items[i].Value.ToString() + @",N'EN') as " + chklExamType.Items[i].Value.ToString();

                    if (PrivotQuery.Length == 55)
                        PrivotQuery += chklExamType.Items[i].Value.ToString();
                    else
                        PrivotQuery += @"," + chklExamType.Items[i].Value.ToString();
                }
            }
            PrivotQuery += @")) as pv order by    pv.REPORT_ON";
            SelectionQuery += @" from (";
            ConditionQuery += @" WHERE RIS_EXAMRESULTTIME.LAST_SAVED_ON IS NOT NULL ";
            switch (_Condition)
            {
                //1 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID   
                //2 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO
                //3 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO and RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID  
                //4 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID and RIS_EXAMRESULTTIME.START_ON between dbo.fnc_GetDateOnly(@FROM) and dbo.fnc_GetDateEndDay(@TO)
                case 1:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.RAD_ID = {0} ", Rad_ID.ToString());
                    break;
                case 2:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} ", "'" + txtAccession.Text + "'");
                    break;
                case 3:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} and RIS_EXAMRESULTTIME.RAD_ID = {1} ", "'" + txtAccession.Text + "'", Rad_ID.ToString());
                    break;
                case 4:
                    string fromdate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtStartCompare.DateTime.Year.ToString(), dtStartCompare.DateTime.Month.ToString(), dtStartCompare.DateTime.Day.ToString());
                    string todate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtEndCompare.DateTime.Year.ToString(), dtEndCompare.DateTime.Month.ToString(), dtEndCompare.DateTime.Day.ToString());
                    ConditionQuery += string.Format(@" and RIS_EXAMRESULTTIME.RAD_ID = {0} and RIS_EXAMRESULTTIME.START_ON between 
                    dbo.fnc_GetDateOnly({1}) and dbo.fnc_GetDateEndDay({2}) and 
                    CONVERT(time,RIS_EXAMRESULTTIME.START_ON) between CONVERT(time,'{3}:00') and CONVERT(time,'{4}:59.999')", Rad_ID.ToString(), fromdate, todate, timeStartCompare.Text, timeEndCompare.Text);
                    break;
                default:
                    break;
            }
            ConditionQuery += @" GROUP BY RIS_EXAMRESULTTIME.ACCESSION_NO, RIS_EXAMTYPE.EXAM_TYPE_UID";

            Query = SelectionQuery + SubSelectionQuery + ConditionQuery + PrivotQuery;

            _prctime = new ProcessGetRISExamresulttime();
            _prctime.SelectExecSummary(Query);
            gvSummary.Columns.Clear();
            int k = 1;
            foreach (DataColumn dc in _prctime.ResultSet.Tables[0].Columns)
            {
                DevExpress.XtraGrid.Columns.GridColumn clm = new DevExpress.XtraGrid.Columns.GridColumn();
                clm.Caption = dc.ColumnName;
                clm.FieldName = dc.ColumnName;
                clm.VisibleIndex = k;
                gvSummary.Columns.Add(clm);
                k++;
            }

            gcSummary.DataSource = _prctime.ResultSet.Tables[0].Copy();
        }
        private void InitializeDataSummaryChart(int _Condition)
        {
            switch (rdoChartSelect.SelectedIndex)
            {
                case 0:
                    _viewtype = DevExpress.XtraCharts.ViewType.Bar;
                    break;
                case 1:
                    _viewtype = DevExpress.XtraCharts.ViewType.StackedBar;
                    break;
                case 2:
                    _viewtype = DevExpress.XtraCharts.ViewType.Area;
                    break;
                case 3:
                    _viewtype = DevExpress.XtraCharts.ViewType.Line;
                    break;
                default:
                    break;
            }

            string Query = "";
            string SelectionQuery = @"select  pv.REPORT_ON ";
            string ConditionQuery = "";
            string PrivotQuery = @") as src	pivot (avg(REPORT_TIME) for EXAM_TYPE_UID in (";
            string SubSelectionQuery = @"	SELECT     CONVERT(date, MIN(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_ON, 
			   DATEDIFF(minute, MIN(RIS_EXAMRESULTTIME.START_ON), MAX(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_TIME, 
			   RIS_EXAMTYPE.EXAM_TYPE_UID
FROM         RIS_EXAMRESULTTIME INNER JOIN
                      RIS_ORDERDTL ON RIS_EXAMRESULTTIME.ACCESSION_NO = RIS_ORDERDTL.ACCESSION_NO INNER JOIN
                      RIS_EXAM ON RIS_ORDERDTL.EXAM_ID = RIS_EXAM.EXAM_ID INNER JOIN
                      RIS_EXAMTYPE ON RIS_EXAM.EXAM_TYPE = RIS_EXAMTYPE.EXAM_TYPE_ID ";
            for (int i = 0; i < chklExamType.Items.Count; i++)
            {
                if (chklExamType.Items[i].CheckState == CheckState.Checked)
                {
                    SelectionQuery += @", isnull(" + chklExamType.Items[i].Value.ToString() + ",0) as " + chklExamType.Items[i].Value.ToString();

                    if (PrivotQuery.Length == 55)
                        PrivotQuery += chklExamType.Items[i].Value.ToString();
                    else
                        PrivotQuery += @"," + chklExamType.Items[i].Value.ToString();
                }
            }
            PrivotQuery += @")) as pv order by    pv.REPORT_ON";
            SelectionQuery += @" from (";
            ConditionQuery += @" WHERE RIS_EXAMRESULTTIME.LAST_SAVED_ON IS NOT NULL ";
            switch (_Condition)
            {
                //1 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID   
                //2 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO
                //3 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO and RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID  
                //4 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID and RIS_EXAMRESULTTIME.START_ON between dbo.fnc_GetDateOnly(@FROM) and dbo.fnc_GetDateEndDay(@TO)
                case 1:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.RAD_ID = {0} ", Rad_ID.ToString());
                    break;
                case 2:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} ", "'" + txtAccession.Text + "'");
                    break;
                case 3:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} and RIS_EXAMRESULTTIME.RAD_ID = {1} ", "'" + txtAccession.Text + "'", Rad_ID.ToString());
                    break;
                case 4:
                    string fromdate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtFromdate.DateTime.Year.ToString(), dtFromdate.DateTime.Month.ToString(), dtFromdate.DateTime.Day.ToString());
                    string todate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtTodate.DateTime.Year.ToString(), dtTodate.DateTime.Month.ToString(), dtTodate.DateTime.Day.ToString());
                    ConditionQuery += string.Format(@" and RIS_EXAMRESULTTIME.RAD_ID = {0} and RIS_EXAMRESULTTIME.START_ON between 
                    dbo.fnc_GetDateOnly({1}) and dbo.fnc_GetDateEndDay({2}) and 
                    CONVERT(time,RIS_EXAMRESULTTIME.START_ON) between CONVERT(time,'{3}:00') and CONVERT(time,'{4}:59.999')", Rad_ID.ToString(), fromdate, todate,timeStart.Text,timeEnd.Text);
                    break;
                default:
                    break;
            }
            ConditionQuery += @" GROUP BY RIS_EXAMRESULTTIME.ACCESSION_NO, RIS_EXAMTYPE.EXAM_TYPE_UID";

            Query = SelectionQuery + SubSelectionQuery + ConditionQuery + PrivotQuery;

            _prctime = new ProcessGetRISExamresulttime();
            _prctime.SelectExecSummary(Query);

            _chartdata = _prctime.ResultSet.Copy();
            chartControl1.DataSource = _chartdata.Tables[0].Copy();
            chartControl1.Series.Clear();
          
            foreach (DataColumn dc in _prctime.ResultSet.Tables[0].Columns)
            {
                //chartControl1.Series.Clear();
                if (dc.ColumnName != "REPORT_ON")
                {
                    double[] d = new double[1];
                    chartControl1.Series.Add(dc.ColumnName, _viewtype);
                    foreach (DataRow dr in _prctime.ResultSet.Tables[0].Rows)
                    {
                        d = new double[1];
                        d[0] = Convert.ToDouble(dr[dc.ColumnName].ToString());
                        string str = dr["REPORT_ON"].ToString();
                        chartControl1.Series[dc.ColumnName].Points.Add(new DevExpress.XtraCharts.SeriesPoint(Convert.ToDateTime(dr["REPORT_ON"].ToString()).ToString("dd/MM/yyyy"), d));
                    }
                }
              
            }
        }
        private void InitializeDataSummaryChartCompare(int _Condition)
        {
            switch (radioGroup1.SelectedIndex)
            {
                    
                case 0:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Bar;
                    break;
                case 1:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.StackedBar;
                    break;
                case 2:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Area;
                    break;
                case 3:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Line;
                    break;
                default:
                    break;
            }

            string Query = "";
            string SelectionQuery = @"select 'Date : " + dtStartCompare.DateTime.ToString("dd/MM/yyyy") + " to " + dtEndCompare.DateTime.ToString("dd/MM/yyyy") + " and Time : " + timeStartCompare.Text +" to "+ timeEndCompare.Text + "' as REPORT_ON ";
            string ConditionQuery = "";
            string PrivotQuery = @") as src	pivot (avg(REPORT_TIME) for EXAM_TYPE_UID in (";
            string SubSelectionQuery = @"	SELECT     --CONVERT(date, MIN(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_ON, 
			   DATEDIFF(minute, MIN(RIS_EXAMRESULTTIME.START_ON), MAX(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_TIME, 
			   RIS_EXAMTYPE.EXAM_TYPE_UID
FROM         RIS_EXAMRESULTTIME INNER JOIN
                      RIS_ORDERDTL ON RIS_EXAMRESULTTIME.ACCESSION_NO = RIS_ORDERDTL.ACCESSION_NO INNER JOIN
                      RIS_EXAM ON RIS_ORDERDTL.EXAM_ID = RIS_EXAM.EXAM_ID INNER JOIN
                      RIS_EXAMTYPE ON RIS_EXAM.EXAM_TYPE = RIS_EXAMTYPE.EXAM_TYPE_ID ";
            for (int i = 0; i < chklExamType.Items.Count; i++)
            {
                if (chklExamType.Items[i].CheckState == CheckState.Checked)
                {
                    SelectionQuery += @", isnull(" + chklExamType.Items[i].Value.ToString() + ",0) as " + chklExamType.Items[i].Value.ToString();

                    if (PrivotQuery.Length == 55)
                        PrivotQuery += chklExamType.Items[i].Value.ToString();
                    else
                        PrivotQuery += @"," + chklExamType.Items[i].Value.ToString();
                }
            }
            PrivotQuery += @")) as pv-- order by    pv.REPORT_ON";
            SelectionQuery += @" from (";
            ConditionQuery += @" WHERE RIS_EXAMRESULTTIME.LAST_SAVED_ON IS NOT NULL ";
            switch (_Condition)
            {
                //1 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID   
                //2 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO
                //3 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO and RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID  
                //4 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID and RIS_EXAMRESULTTIME.START_ON between dbo.fnc_GetDateOnly(@FROM) and dbo.fnc_GetDateEndDay(@TO)
                case 1:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.RAD_ID = {0} ", Rad_ID.ToString());
                    break;
                case 2:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} ", "'" + txtAccession.Text + "'");
                    break;
                case 3:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} and RIS_EXAMRESULTTIME.RAD_ID = {1} ", "'" + txtAccession.Text + "'", Rad_ID.ToString());
                    break;
                case 4:
                    string fromdate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtStartCompare.DateTime.Year.ToString(), dtStartCompare.DateTime.Month.ToString(), dtStartCompare.DateTime.Day.ToString());
                    string todate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtEndCompare.DateTime.Year.ToString(), dtEndCompare.DateTime.Month.ToString(), dtEndCompare.DateTime.Day.ToString());
                    ConditionQuery += string.Format(@" and RIS_EXAMRESULTTIME.RAD_ID = {0} and RIS_EXAMRESULTTIME.START_ON between 
                    dbo.fnc_GetDateOnly({1}) and dbo.fnc_GetDateEndDay({2}) and 
                    CONVERT(time,RIS_EXAMRESULTTIME.START_ON) between CONVERT(time,'{3}:00') and CONVERT(time,'{4}:59.999')", Rad_ID.ToString(), fromdate, todate, timeStartCompare.Text, timeEndCompare.Text);
                    break;
                default:
                    break;
            }
            ConditionQuery += @" GROUP BY RIS_EXAMRESULTTIME.ACCESSION_NO, RIS_EXAMTYPE.EXAM_TYPE_UID";

            Query = SelectionQuery + SubSelectionQuery + ConditionQuery + PrivotQuery;

            _prctime = new ProcessGetRISExamresulttime();
            _prctime.SelectExecSummary(Query);

            _chartdataCompare1 = _prctime.ResultSet.Copy();
        }
        private void InitializeDataSummaryChartCompare2(int _Condition)
        {
            switch (radioGroup1.SelectedIndex)
            {

                case 0:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Bar;
                    break;
                case 1:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.StackedBar;
                    break;
                case 2:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Area;
                    break;
                case 3:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Line;
                    break;
                default:
                    break;
            }

            string Query = "";
            string SelectionQuery = @"select 'Date : " + dtStartCompare2.DateTime.ToString("dd/MM/yyyy") + " to " + dtEndCompare2.DateTime.ToString("dd/MM/yyyy") + " and Time : " + timeStartCompare2.Text + " to " + timeEndCompare2.Text + "' as REPORT_ON ";
            string ConditionQuery = "";
            string PrivotQuery = @") as src	pivot (avg(REPORT_TIME) for EXAM_TYPE_UID in (";
            string SubSelectionQuery = @"	SELECT     --CONVERT(date, MIN(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_ON, 
			   DATEDIFF(minute, MIN(RIS_EXAMRESULTTIME.START_ON), MAX(RIS_EXAMRESULTTIME.LAST_SAVED_ON)) AS REPORT_TIME, 
			   RIS_EXAMTYPE.EXAM_TYPE_UID
FROM         RIS_EXAMRESULTTIME INNER JOIN
                      RIS_ORDERDTL ON RIS_EXAMRESULTTIME.ACCESSION_NO = RIS_ORDERDTL.ACCESSION_NO INNER JOIN
                      RIS_EXAM ON RIS_ORDERDTL.EXAM_ID = RIS_EXAM.EXAM_ID INNER JOIN
                      RIS_EXAMTYPE ON RIS_EXAM.EXAM_TYPE = RIS_EXAMTYPE.EXAM_TYPE_ID ";
            for (int i = 0; i < chklExamType.Items.Count; i++)
            {
                if (chklExamType.Items[i].CheckState == CheckState.Checked)
                {
                    SelectionQuery += @", isnull(" + chklExamType.Items[i].Value.ToString() + ",0) as " + chklExamType.Items[i].Value.ToString();

                    if (PrivotQuery.Length == 55)
                        PrivotQuery += chklExamType.Items[i].Value.ToString();
                    else
                        PrivotQuery += @"," + chklExamType.Items[i].Value.ToString();
                }
            }
            PrivotQuery += @")) as pv --order by    pv.REPORT_ON";
            SelectionQuery += @" from (";
            ConditionQuery += @" WHERE RIS_EXAMRESULTTIME.LAST_SAVED_ON IS NOT NULL ";
            switch (_Condition)
            {
                //1 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID   
                //2 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO
                //3 where	RIS_EXAMRESULTTIME.ACCESSION_NO = @ACCESSION_NO and RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID  
                //4 where	RIS_EXAMRESULTTIME.RAD_ID = @RAD_ID and RIS_EXAMRESULTTIME.START_ON between dbo.fnc_GetDateOnly(@FROM) and dbo.fnc_GetDateEndDay(@TO)
                case 1:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.RAD_ID = {0} ", Rad_ID.ToString());
                    break;
                case 2:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} ", "'" + txtAccession.Text + "'");
                    break;
                case 3:
                    ConditionQuery += string.Format(" and RIS_EXAMRESULTTIME.ACCESSION_NO = {0} and RIS_EXAMRESULTTIME.RAD_ID = {1} ", "'" + txtAccession.Text + "'", Rad_ID.ToString());
                    break;
                case 4:
                    string fromdate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtStartCompare2.DateTime.Year.ToString(), dtStartCompare2.DateTime.Month.ToString(), dtStartCompare2.DateTime.Day.ToString());
                    string todate = string.Format("convert(datetime,'{0}-{1}-{2}')", dtEndCompare2.DateTime.Year.ToString(), dtEndCompare2.DateTime.Month.ToString(), dtEndCompare2.DateTime.Day.ToString());
                    ConditionQuery += string.Format(@" and RIS_EXAMRESULTTIME.RAD_ID = {0} and RIS_EXAMRESULTTIME.START_ON between 
                    dbo.fnc_GetDateOnly({1}) and dbo.fnc_GetDateEndDay({2}) and 
                    CONVERT(time,RIS_EXAMRESULTTIME.START_ON) between CONVERT(time,'{3}:00') and CONVERT(time,'{4}:59.999')", Rad_ID.ToString(), fromdate, todate, timeStartCompare2.Text, timeEndCompare2.Text);
                    break;
                default:
                    break;
            }
            ConditionQuery += @" GROUP BY RIS_EXAMRESULTTIME.ACCESSION_NO, RIS_EXAMTYPE.EXAM_TYPE_UID";

            Query = SelectionQuery + SubSelectionQuery + ConditionQuery + PrivotQuery;

            _prctime = new ProcessGetRISExamresulttime();
            _prctime.SelectExecSummary(Query);

            _chartdataCompare2 = _prctime.ResultSet.Copy();
          
        }
        private void InitializeCompare()
        {
            //ccChart1.DataSource = _chartdataCompare1.Tables[0].Copy();
            ccChart1.Series.Clear();
            if (_chartdataCompare1.Tables[0].Rows.Count <= 0 || _chartdataCompare2.Tables[0].Rows.Count <= 0)
            {
                return;
            }

            if (_chartdataCompare1.Tables[0].Rows.Count > 0)
            {
                foreach (DataColumn dc in _chartdataCompare1.Tables[0].Columns)
                {
                    if (dc.ColumnName == "REPORT_ON")
                    {
                        ccChart1.Series.Add(_chartdataCompare1.Tables[0].Rows[0][dc.ColumnName].ToString(), _viewtypeCompare);
                    }
                    else
                    {
                        double[] d = new double[1];
                        foreach (DataRow dr in _chartdataCompare1.Tables[0].Rows)
                        {
                            d = new double[1];
                            d[0] = Convert.ToDouble(dr[dc.ColumnName].ToString());
                            ccChart1.Series[0].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dc.ColumnName, d));
                        }
                    }

                }
            }
            if (_chartdataCompare2.Tables[0].Rows.Count > 0)
            {
                foreach (DataColumn dc in _chartdataCompare2.Tables[0].Columns)
                {
                    if (dc.ColumnName == "REPORT_ON")
                    {
                        ccChart1.Series.Add(_chartdataCompare2.Tables[0].Rows[0][dc.ColumnName].ToString(), _viewtypeCompare);
                    }
                    else
                    {
                        double[] d = new double[1];
                        foreach (DataRow dr in _chartdataCompare2.Tables[0].Rows)
                        {
                            d = new double[1];
                            d[0] = Convert.ToDouble(dr[dc.ColumnName].ToString());
                            ccChart1.Series[1].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dc.ColumnName, d));
                        }
                    }

                }
            }
        }
        private void txtAccession_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                InitializeData(true,false);
            }
        }

        private void gvResulttime_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                DataRow _dr = gvResulttime.GetDataRow(e.RowHandle);
                fillData(_dr);
            }
        }
        private void fillData(DataRow dr)
        {
            if (dr != null)
            {
                if (FilterByAcc)
                {
                    if (Rad_ID == 0)
                    {
                        Rad_ID = 0;
                        txtRad.Text = "";
                        txtTAT.Text = dr["TAT_BYACCESSION"].ToString();
                    }
                    else
                    {
                        Rad_ID = Convert.ToInt32(dr["RAD_ID"].ToString());
                        txtRad.Text = dr["Radiologist"].ToString();
                        txtTAT.Text = dr["TAT_BYACCESSION_RAD"].ToString();
                    }
                    txtAccession.Text = dr["ACCESSION_NO"].ToString();
                    txtExam.Text = dr["EXAM_NAME"].ToString();
                    if (dr["START_ON"].ToString() != "")
                        txtStarted.Text = Convert.ToDateTime(dr["START_ON"].ToString()).ToString("dd/MM/yyyy HH:MM:ss");
                    if (dr["LAST_SAVED_ON"].ToString() != "")
                        txtLastsaved.Text = Convert.ToDateTime(dr["LAST_SAVED_ON"].ToString()).ToString("dd/MM/yyyy HH:MM:ss");
                   
                }
                else
                {
                    Rad_ID = Convert.ToInt32(dr["RAD_ID"].ToString());
                    txtRad.Text = dr["Radiologist"].ToString();
                    txtAccession.Text = dr["ACCESSION_NO"].ToString();
                    txtExam.Text = dr["EXAM_NAME"].ToString();
                    if (dr["START_ON"].ToString() != "")
                        txtStarted.Text = Convert.ToDateTime(dr["START_ON"].ToString()).ToString("dd/MM/yyyy HH:MM:ss");
                    if (dr["LAST_SAVED_ON"].ToString() != "")
                        txtLastsaved.Text = Convert.ToDateTime(dr["LAST_SAVED_ON"].ToString()).ToString("dd/MM/yyyy HH:MM:ss");
                    txtTAT.Text = dr["TAT_BYACCESSION_RAD"].ToString();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Rad_ID = 0;
            txtRad.Text = "";
        }

        private void chkAllType_CheckedChanged(object sender, EventArgs e)
        {
            chkExamTypeSelect();
        }
        private void chkExamTypeSelect()
        {
            if (chkAllType.Checked)
            {
                for (int i = 0; i < chklExamType.Items.Count; i++)
                {
                    chklExamType.Items[i].CheckState = CheckState.Checked;
                }
                chklExamType.Enabled = false;
            }
            else
            {
                chklExamType.Enabled = true;
            }
        }

        private void rdoChartSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (rdoChartSelect.SelectedIndex)
            {
                case 0:
                    _viewtype = DevExpress.XtraCharts.ViewType.Bar;
                    break;
                case 1:
                    _viewtype = DevExpress.XtraCharts.ViewType.StackedBar;
                    break;
                case 2:
                    _viewtype = DevExpress.XtraCharts.ViewType.Area;
                    break;
                case 3:
                    _viewtype = DevExpress.XtraCharts.ViewType.Line;
                    break;
                default:
                    break;
            }

            chartControl1.DataSource = _chartdata.Tables[0].Copy();
            chartControl1.Series.Clear();

            foreach (DataColumn dc in _chartdata.Tables[0].Columns)
            {
                //chartControl1.Series.Clear();
                if (dc.ColumnName != "REPORT_ON")
                {
                    double[] d = new double[1];
                    chartControl1.Series.Add(dc.ColumnName, _viewtype);
                    foreach (DataRow dr in _prctime.ResultSet.Tables[0].Rows)
                    {
                        d = new double[1];
                        d[0] = Convert.ToDouble(dr[dc.ColumnName].ToString());
                        string str = dr["REPORT_ON"].ToString();
                        chartControl1.Series[dc.ColumnName].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr["REPORT_ON"].ToString(), d));
                    }
                }

            }
        }

        private void btnSearchCompare_Click(object sender, EventArgs e)
        {
            long difftime = timeEndCompare.Time.Ticks - timeStartCompare.Time.Ticks;
            long difftime2 = timeEndCompare2.Time.Ticks - timeStartCompare2.Time.Ticks;

            lbDate1.Visible = false;
            lbDate2.Visible = false;
            lbTime1.Visible = false;
            lbTime2.Visible = false;
            label1.Text = "";

            if (dtEndCompare.DateTime.Ticks < dtStartCompare.DateTime.Ticks)
            {
                label1.Text = "Date 1 incorrect";
                lbDate1.Visible = true;
                return;
            }
            if (dtEndCompare2.DateTime.Ticks < dtStartCompare2.DateTime.Ticks)
            {
                label1.Text = "Date 2 incorrect";
                lbDate2.Visible = true;
                return;
            }
            if (difftime != difftime2)
            {
                label1.Text = "Time incorrect";
                lbTime1.Visible = true;
                lbTime2.Visible = true;
                return;
            }
            InitializeData(false, true);
        }

        private void chkAllCompare_CheckedChanged(object sender, EventArgs e)
        {
            InitializeData(false, true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            chartControl1.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
        }

        private void btnPrintCompare_Click(object sender, EventArgs e)
        {
            ccChart1.ShowPrintPreview(DevExpress.XtraCharts.Printing.PrintSizeMode.Stretch);
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (radioGroup1.SelectedIndex)
            {
                case 0:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Bar;
                    break;
                case 1:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.StackedBar;
                    break;
                case 2:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Area;
                    break;
                case 3:
                    _viewtypeCompare = DevExpress.XtraCharts.ViewType.Line;
                    break;
                default:
                    break;
            }

            InitializeCompare();
        }

        private void xtraTabControl3_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl3.SelectedTabPageIndex == 0)
            {
                xtraTabControl1.SelectedTabPageIndex = 1;
            }
            else
            {
                xtraTabControl1.SelectedTabPageIndex = 2;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (xtraTabControl1.SelectedTabPageIndex)
            {
                case 0:
                    layoutControlItem14.ContentVisible = true;
                    break;
                case 1:
                    xtraTabControl3.SelectedTabPageIndex = 0;
                    layoutControlItem14.ContentVisible = false;
                    break;
                case 2:
                    xtraTabControl3.SelectedTabPageIndex = 1;
                    layoutControlItem14.ContentVisible = false;
                    break;
                default:
                    break;
            }
        }
    }
}
