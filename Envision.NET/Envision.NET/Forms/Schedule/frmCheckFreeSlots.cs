using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using DevExpress.XtraScheduler.UI;
using DevExpress.XtraScheduler;

namespace Envision.NET.Forms.Schedule
{
    public partial class frmCheckFreeSlots : DevExpress.XtraEditors.XtraForm
    {
        private GBLEnvVariable env = new GBLEnvVariable(); 
        private DataTable dttResource, dttScheduleSession;
        private ResourcesCheckedListBoxControl checkListItems;
        private int ModalityID = 0;
        private DataTable dttBlock = new DataTable();
        private DataTable dttScheduleSessionDetail = new DataTable();

        public DateTime dateNavSelected { get; set; }
        public frmCheckFreeSlots(ResourcesCheckedListBoxControl chkItemsList)
        {
            InitializeComponent();
            checkListItems = chkItemsList;
        }
        public frmCheckFreeSlots(int modality_id)
        {
            InitializeComponent();
            ModalityID = modality_id;
        }
        private void frmCheckFreeSlots_Load(object sender, EventArgs e)
        {
            dateNav.DateTime = dateNavSelected.AddMonths(6);
            dateNav.DateTime = dateNavSelected;
            
            initialModalityData();
            initDataGridSession();
            setGridSessionData();

        }
        private void initialModalityData()
        {
            #region Show All modality with all user
            ProcessGetRISSchedule process = new ProcessGetRISSchedule();
            dttResource = process.GetModality();
            if (!dttResource.Columns.Contains("CHK"))
                dttResource.Columns.Add("CHK");
            if (ModalityID == 0)
            {
                for (int y = 0; y < checkListItems.CheckedItems.Count; y++)
                {
                    DataRow[] rowCheck = dttResource.Select("MODALITY_NAME='" + checkListItems.CheckedItems[y].ToString() + "'");
                    if (rowCheck.Length > 0)
                        rowCheck[0]["CHK"] = "Y";
                }
            }
            else
            {
                DataRow[] rowCheck = dttResource.Select("MODALITY_ID=" + ModalityID.ToString());
                if (rowCheck.Length > 0)
                    rowCheck[0]["CHK"] = "Y";
            }
            for (int i = 0; i < dttResource.Rows.Count; i++)
            {
                if (dttResource.Rows[i]["CHK"].ToString() == "Y")
                    chklModality.Items.Add(Convert.ToInt32(dttResource.Rows[i]["MODALITY_ID"]), dttResource.Rows[i]["MODALITY_NAME"].ToString(), CheckState.Checked, true);
                else
                    chklModality.Items.Add(Convert.ToInt32(dttResource.Rows[i]["MODALITY_ID"]), dttResource.Rows[i]["MODALITY_NAME"].ToString(), CheckState.Unchecked, true);

            }
            #endregion
        }
        private DataTable initDataGridSession()
        {
            DataTable dttTemp = new DataTable();

            dttTemp.Columns.Add("CLINIC");
            dttTemp.Columns.Add("MORNING");
            dttTemp.Columns.Add("AFTERNOON");
            dttTemp.Columns.Add("EVENING");

            dttTemp.Columns.Add("MORNING_START", typeof(DateTime));
            dttTemp.Columns.Add("MORNING_END", typeof(DateTime));
            dttTemp.Columns.Add("AFTERNOON_START", typeof(DateTime));
            dttTemp.Columns.Add("AFTERNOON_END", typeof(DateTime));
            dttTemp.Columns.Add("EVENING_START", typeof(DateTime));
            dttTemp.Columns.Add("EVENING_END", typeof(DateTime));

            dttTemp.Columns.Add("MODALITY_NAME");

            dttTemp.AcceptChanges();
            dttTemp.Rows.Add("ในเวลา", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "None");
            dttTemp.Rows.Add("คลินิกพิเศษ", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "None");
            dttTemp.Rows.Add("คลินิกพรีเมี่ยม", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "None");
            dttTemp.Rows.Add("AIMC", "0/0 : 0", "0/0 : 0", "0/0 : 0", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, "None");
            dttTemp.AcceptChanges();

            return dttTemp;
        }
        private void setGridSession(DataTable dtt)
        {
            if (dtt == null) return;
            grdSchedule.DataSource = dtt;
            if (view1.Columns.Count == 0) return;
            for (int i = 0; i < dtt.Columns.Count; i++)
                view1.Columns[i].Visible = false;

            view1.Columns["MODALITY_NAME"].GroupIndex = 1;
            view1.Columns["MODALITY_NAME"].Visible = true;
            view1.Columns["MODALITY_NAME"].Caption = "Modality";

            view1.Columns["CLINIC"].Visible = true;
            view1.Columns["CLINIC"].Width = 100;
            view1.Columns["CLINIC"].Caption = " ";
            view1.Columns["CLINIC"].VisibleIndex = 1;

            view1.Columns["MORNING"].Visible = true;
            view1.Columns["MORNING"].Width = 50;
            view1.Columns["MORNING"].Caption = "เช้า";
            view1.Columns["MORNING"].VisibleIndex = 2;

            view1.Columns["AFTERNOON"].Visible = true;
            view1.Columns["AFTERNOON"].Width = 50;
            view1.Columns["AFTERNOON"].Caption = "บ่าย";
            view1.Columns["AFTERNOON"].VisibleIndex = 3;

            view1.Columns["EVENING"].Visible = true;
            view1.Columns["EVENING"].Width = 50;
            view1.Columns["EVENING"].Caption = "เย็น";
            view1.Columns["EVENING"].VisibleIndex = 4;
        }
        private void setGridBlock(DataTable dtt)
        {
            if (dtt == null) return;
            grdBlocks.DataSource = dtt;
            if (viewBlock.Columns.Count == 0) return;
            for (int i = 0; i < dtt.Columns.Count; i++)
            {
                viewBlock.Columns[i].Visible = false;
                viewBlock.Columns[i].OptionsColumn.AllowEdit = false;
            }

            viewBlock.Columns["START_DATETIME"].Visible = true;
            viewBlock.Columns["START_DATETIME"].Caption = "Datetime";
            viewBlock.Columns["START_DATETIME"].DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            viewBlock.Columns["BLOCK_DATA"].Visible = true;
            viewBlock.Columns["BLOCK_DATA"].Caption = "Block Data";
        }
        private void view1_GroupRowCollapsing(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            e.Allow = false;
        }
        private void view1_EndGrouping(object sender, EventArgs e)
        {
            (sender as DevExpress.XtraGrid.Views.Grid.GridView).ExpandAllGroups();
        }
        private DataTable setGridSessionSelect(int modality_id,string modality_name)
        {
            DataTable dtTemp = new DataTable();
            dtTemp = initDataGridSession();
            DayOfWeek df = dateNav.SelectionStart.DayOfWeek;
            ProcessGetRISClinicsession process = new ProcessGetRISClinicsession();
            process.RIS_CLINICSESSION.MODALITY_ID = modality_id;
            process.RIS_CLINICSESSION.ORG_ID = env.OrgID;
            process.RIS_CLINICSESSION.WEEKDAYS = Convert.ToInt32(df);
            DataTable dtt = process.GetClinicSession();


            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                
                DateTime tmp = Convert.ToDateTime(dtt.Rows[i]["START_TIME"].ToString());
                DateTime start = new DateTime(dateNav.DateTime.Year, dateNav.DateTime.Month, dateNav.DateTime.Day, tmp.Hour, tmp.Minute, tmp.Second);
                tmp = Convert.ToDateTime(dtt.Rows[i]["END_TIME"].ToString());
                DateTime end = new DateTime(dateNav.DateTime.Year, dateNav.DateTime.Month, dateNav.DateTime.Day, tmp.Hour, tmp.Minute, tmp.Second);

                ProcessGetRISSchedule proc = new ProcessGetRISSchedule();
                proc.RIS_SCHEDULE.MODALITY_ID = modality_id;
                // proc.RIS_SCHEDULE.APPOINT_DT = start;
                proc.RIS_SCHEDULE.START_DATETIME = start;
                proc.RIS_SCHEDULE.END_DATETIME = end;
                proc.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(dtt.Rows[i]["SESSION_ID"]);
                DataSet dsmp = proc.GetSessionShow();
                if (dsmp.Tables.Count > 2)
                    dttBlock.Merge(dsmp.Tables[2].Copy());
                dtt.Rows[i]["APP"] = dsmp.Tables[0].Rows[0][0].ToString() + "/" + dtt.Rows[i]["MAX_APP"].ToString() + " : " + dsmp.Tables[1].Rows[0][0].ToString();
                switch (dtt.Rows[i]["SESSION_UID"].ToString().ToUpper())
                {
                    case "RM":
                        dtTemp.Rows[0]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[0][1] = calculateSessionSelected(dtTemp.Rows[0][1].ToString(), dsmp.Tables[0].Rows[0][0].ToString(), dtt.Rows[i]["MAX_APP"].ToString(), dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[0][4] = start;
                        dtTemp.Rows[0][5] = end;
                        break;
                    case "RA":
                        dtTemp.Rows[0]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[0][2] = calculateSessionSelected(dtTemp.Rows[0][2].ToString(), dsmp.Tables[0].Rows[0][0].ToString(),dtt.Rows[i]["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[0][6] = start;
                        dtTemp.Rows[0][7] = end;
                        break;
                    case "RE":
                        dtTemp.Rows[0]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[0][3] = calculateSessionSelected(dtTemp.Rows[0][3].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dtt.Rows[i]["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[0][8] = start;
                        dtTemp.Rows[0][9] = end;
                        break;

                    case "SM":
                        dtTemp.Rows[1]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[1][1] = calculateSessionSelected(dtTemp.Rows[1][1].ToString(),dsmp.Tables[0].Rows[0][0].ToString(), dtt.Rows[i]["MAX_APP"].ToString(), dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[1][4] = start;
                        dtTemp.Rows[1][5] = end;
                        break;
                    case "SA":
                        dtTemp.Rows[1]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[1][2] = calculateSessionSelected(dtTemp.Rows[1][2].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dtt.Rows[i]["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[1][6] = start;
                        dtTemp.Rows[1][7] = end;
                        break;
                    case "SE":
                        dtTemp.Rows[1]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[1][3] = calculateSessionSelected(dtTemp.Rows[1][3].ToString(),dsmp.Tables[0].Rows[0][0].ToString(), dtt.Rows[i]["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[1][8] = start;
                        dtTemp.Rows[1][9] = end;
                        break;
                    case "PM":
                        dtTemp.Rows[2]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[2][1] = calculateSessionSelected(dtTemp.Rows[2][1].ToString(),dsmp.Tables[0].Rows[0][0].ToString(),dtt.Rows[i]["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[2][4] = start;
                        dtTemp.Rows[2][5] = end;
                        break;
                    case "PA":
                        dtTemp.Rows[2]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[2][2] = calculateSessionSelected(dtTemp.Rows[2][2].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dtt.Rows[i]["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[2][6] = start;
                        dtTemp.Rows[2][7] = end;
                        break;
                    case "PE":
                        dtTemp.Rows[2]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[2][3] = calculateSessionSelected(dtTemp.Rows[3][3].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dtt.Rows[i]["MAX_APP"].ToString() ,dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[2][8] = start;
                        dtTemp.Rows[2][9] = end;
                        break;
                    case "AA":
                        dtTemp.Rows[3]["MODALITY_NAME"] = modality_name;
                        dtTemp.Rows[3][1] = calculateSessionSelected(dtTemp.Rows[3][1].ToString(),dsmp.Tables[0].Rows[0][0].ToString() , dtt.Rows[i]["MAX_APP"].ToString() , dsmp.Tables[1].Rows[0][0].ToString());
                        dtTemp.Rows[3][4] = start;
                        dtTemp.Rows[3][5] = end;
                        break;
                }
                dtTemp.AcceptChanges();
            }
            dttScheduleSessionDetail.Merge(dtt);
            return dtTemp;
        }
        private void view1_Click(object sender, EventArgs e)
        {
            if (view1.FocusedRowHandle >= 0)
            {
                DataRow dr = view1.GetDataRow(view1.FocusedRowHandle);
                string ModalityName = dr["MODALITY_NAME"].ToString();
                if (ModalityName == "(Any)") return;
                DataRow[] rows = dttResource.Select("MODALITY_NAME='" + ModalityName.Trim() + "'");
                int ModalityId = Convert.ToInt32(rows[0]["MODALITY_ID"].ToString());

                DateTime dtSeStart = new DateTime();
                DateTime dtSeEnd = new DateTime();
                DateTime dt = dateNav.SelectionStart;
                switch (view1.FocusedColumn.ColumnHandle)
                {
                    case 1:
                        dtSeStart = Convert.ToDateTime(dr["MORNING_START"]);
                        dtSeEnd = Convert.ToDateTime(dr["MORNING_END"]);
                        break;
                    case 2:
                        dtSeStart = Convert.ToDateTime(dr["AFTERNOON_START"]);
                        dtSeEnd = Convert.ToDateTime(dr["AFTERNOON_END"]);
                        break;
                    case 3:
                        dtSeStart = Convert.ToDateTime(dr["EVENING_START"]);
                        dtSeEnd = Convert.ToDateTime(dr["EVENING_END"]);
                        break;
                }

                if (!dr.IsNull(0))
                {
                    DateTime dtFrom = new DateTime(dt.Year, dt.Month, dt.Day, dtSeStart.Hour, dtSeStart.Minute, dtSeStart.Second);
                    DateTime dtEnd = new DateTime(dt.Year, dt.Month, dt.Day, dtSeEnd.Hour, dtSeEnd.Minute, dtSeEnd.Second);
                    int session_id = 0;
                    string session_desc = dr["CLINIC"].ToString();
                    switch (dr["CLINIC"].ToString())
                    {
                        case "ในเวลา":
                            switch (view1.FocusedColumn.Caption)
                            {
                                //case "เช้า": session_id = 2; session_desc += ">เช้า"; break;
                                //case "บ่าย": session_id = 3; session_desc += ">บ่าย"; break;
                                //case "เย็น": session_id = 9; session_desc += ">เย็น"; break;
                                default: popupSessionDetail(ModalityId, "R"); break;
                            }
                            break;
                        case "คลินิกพิเศษ":
                            switch (view1.FocusedColumn.Caption)
                            {
                                //case "เช้า": session_id = 1; session_desc += ">เช้า"; break;
                                //case "บ่าย": session_id = 8; session_desc += ">บ่าย"; break;
                                //case "เย็น": session_id = 4; session_desc += ">เย็น"; break;
                                default: popupSessionDetail(ModalityId, "S"); break;
                            }
                            break;
                        case "คลินิกพรีเมี่ยม":
                            switch (view1.FocusedColumn.Caption)
                            {
                                //case "เช้า": session_id = 5; session_desc += ">เช้า"; break;
                                //case "บ่าย": session_id = 6; session_desc += ">บ่าย"; break;
                                //case "เย็น": session_id = 7; session_desc += ">เย็น"; break;
                                default: popupSessionDetail(ModalityId, "P"); break;
                            }
                            break;
                    }
                    //base.LabelWaitDialog("Create Reporting");

                    //ProcessGetRptScheduleCountAppoint getRpt = new ProcessGetRptScheduleCountAppoint();
                    //getRpt.ReportParameters.Session = session_id;
                    //getRpt.ReportParameters.ModalityId = ModalityId;
                    //getRpt.ReportParameters.FromDate = dtFrom;
                    //getRpt.ReportParameters.ToDate = dtEnd;
                    //getRpt.InvokeWithSession();
                    //DataTable dtXrpt = new DataTable();
                    //dtXrpt = getRpt.Result.Tables[0];
                    //if (dtXrpt.Rows.Count > 0)
                    //{
                    //    Envision.Plugin.XtraFile.xtraReports.xrptScheduleCountAppoint rptSCA = new Envision.Plugin.XtraFile.xtraReports.xrptScheduleCountAppoint("Modality : " + ModalityName + " > " + session_desc);
                    //    rptSCA.DataSource = dtXrpt;
                    //    rptSCA.ShowPreviewMarginLines = false;
                    //    rptSCA.ShowPreview();
                    //}
                    //base.CloseWaitDialog();

                }
            }
        }
        private void popupSessionDetail(int modalityId, string sessionUid)
        {
            DataRow[] rowsPopoup = dttScheduleSessionDetail.Select("MODALITY_ID = " + modalityId.ToString() + " and SESSION_UID like '" + sessionUid + "%'");
            DataView dv = rowsPopoup.CopyToDataTable().DefaultView;
            dv.Sort = "SL_NO";
            DataTable sortedDT = dv.ToTable();
            string popDetail = "";
            foreach (DataRow rowPopDetail in sortedDT.Rows)
                popDetail += rowPopDetail["SESSION_NAME"].ToString() + " : \t\t" + rowPopDetail["APP"].ToString() + "\r\n\r\n";

            if (!string.IsNullOrEmpty(popDetail))
                MessageBox.Show(popDetail, "Session Detail", MessageBoxButtons.OK);
        }
        private string calculateSessionSelected(string summarySession, string countApp, string countMaxApp, string countBlock)
        {
            string _temp = "";

            string _countApp = summarySession.Substring(0, summarySession.IndexOf('/')).Trim();
            string _countMaxApp = summarySession.Substring(summarySession.IndexOf('/'), summarySession.IndexOf(':') - summarySession.IndexOf('/')).Substring(1).Trim();
            string _countBlock = summarySession.Substring(summarySession.IndexOf(':')).Substring(1).Trim();

            int _totalApp = Convert.ToInt32(_countApp) + Convert.ToInt32(countApp);
            int _totalMax = Convert.ToInt32(_countMaxApp) + Convert.ToInt32(countMaxApp);
            int _totalBlock = Convert.ToInt32(_countBlock) + Convert.ToInt32(countBlock);
            _temp = _totalApp.ToString() + "/" + _totalMax.ToString() + " : " + _totalBlock.ToString();

            return _temp;
        }
        private void dateNavigator1_EditDateModified(object sender, EventArgs e)
        {
            setGridSessionData();
        }

        private void chklModality_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            setGridSessionData();
        }
        private void setGridSessionData()
        {
            DataTable dtSession = new DataTable();
            dttBlock = new DataTable();
            dttScheduleSessionDetail = new DataTable();
            for (int z = 0; z < chklModality.CheckedItems.Count; z++)
            {
                DataRow[] rows = dttResource.Select("MODALITY_ID="+chklModality.CheckedItems[z].ToString());
                dtSession.Merge(setGridSessionSelect(Convert.ToInt32(rows[0]["MODALITY_ID"]), rows[0]["MODALITY_NAME"].ToString()));
                dtSession.AcceptChanges();
            }
            if (dtSession.Rows.Count>0)
                setGridSession(dtSession);
            else
                setGridSession(initDataGridSession());

            if(dttBlock.Rows.Count>0)
            {
                setGridBlock(dttBlock);
                layoutcBlock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {
                layoutcBlock.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            dateNavSelected = dateNav.DateTime;
            this.Close();
        }

        private void btnGoToDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            dateNavSelected = dateNav.DateTime;
            this.Close();
        }

        
       
    }
}