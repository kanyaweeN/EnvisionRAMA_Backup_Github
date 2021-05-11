using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;

using RIS.Common;
using RIS.Common.Common;

using RIS.DataAccess.Delete;
using RIS.DataAccess.Insert;
using RIS.DataAccess.Select;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ResultEntry
    {
        private GBLRadexperience gblradexperience;
        private RISExamresult examResult;
        private RISExamresultlegacy examResultlegacy;
        private RISExamresultseverity examResultserverity;
        private RISExamresultSelectData examSelect;
        private RISExamresultlegacySelectData examLegacySelect;
        private RISExamresultseveritySelectData examResultSeveritySelect;
        private RISExamresultInsertData examReport;
        private RISExamresulttemplate examTemplate;
        private List<RISExamtemplateshare> examSharedList;
       
        private bool _shared;

        public ResultEntry() 
        {
            examResult = new RISExamresult();
            examResultlegacy = new RISExamresultlegacy();
            examResultserverity = new RISExamresultseverity();
            examTemplate = new RISExamresulttemplate();
            examSharedList = new List<RISExamtemplateshare>();
            examSelect = new RISExamresultSelectData();
            examLegacySelect = new RISExamresultlegacySelectData();
            examReport = new RISExamresultInsertData();
            _shared = false;
        }
        public GBLRadexperience GetRadiologistConfig(int RadiologistID)
        {
            GBLRadexperience gblradexperience = new GBLRadexperience();
            LookUpSelect ls = new LookUpSelect();
            DataSet dsRad = ls.SelectRadiologistConfig(RadiologistID);
            if (dsRad.Tables[0].Rows.Count > 0)
            {
                gblradexperience.AUTO_REFRESH_WL_SEC = Convert.ToInt16(dsRad.Tables[0].Rows[0]["AUTO_REFRESH_WL_SEC"].ToString());
                gblradexperience.DASHBOARD_DEF_SEARCH = dsRad.Tables[0].Rows[0]["DASHBOARD_DEF_SEARCH"].ToString();
                gblradexperience.LOAD_FINALIZED_EXAMS = (bool)dsRad.Tables[0].Rows[0]["LOAD_FINALIZED_EXAMS"];
                gblradexperience.ALL_EXAM_VISIBLE = (bool)dsRad.Tables[0].Rows[0]["ALL_EXAM_VISIBLE"];
                gblradexperience.LOAD_ALL_EXAM = (bool)dsRad.Tables[0].Rows[0]["LOAD_ALL_EXAM"];
                gblradexperience.AUTO_START_ORDER_IMG = (bool)dsRad.Tables[0].Rows[0]["AUTO_START_ORDER_IMG"];
                gblradexperience.AUTO_START_PACS_IMG = (bool)dsRad.Tables[0].Rows[0]["AUTO_START_PACS_IMG"];
                gblradexperience.DEF_DATE_RANGE = dsRad.Tables[0].Rows[0]["DEF_DATE_RANGE"].ToString();
                gblradexperience.REMEMBER_GRID_ORDER = (bool)dsRad.Tables[0].Rows[0]["REMEMBER_GRID_ORDER"];
                gblradexperience.GRID_DBL_CLICK_TO = dsRad.Tables[0].Rows[0]["GRID_DBL_CLICK_TO"].ToString();
                gblradexperience.FINISH_WRITING_REFER_TO = dsRad.Tables[0].Rows[0]["FINISH_WRITING_REFER_TO"].ToString();
                gblradexperience.ALLOW_OTHERSTO_FINALIZE = (bool)dsRad.Tables[0].Rows[0]["ALLOW_OTHERSTO_FINALIZE"];
                gblradexperience.FONT_FACE = dsRad.Tables[0].Rows[0]["FONT_FACE"].ToString();
                try { gblradexperience.FONT_SIZE = (byte)dsRad.Tables[0].Rows[0]["FONT_SIZE"]; }
                catch { }
                gblradexperience.SIGNATURE_TEXT = dsRad.Tables[0].Rows[0]["SIGNATURE_TEXT"].ToString();
                gblradexperience.SIGNATURE_RTF = dsRad.Tables[0].Rows[0]["SIGNATURE_RTF"].ToString();
                gblradexperience.SIGNATURE_HTML = dsRad.Tables[0].Rows[0]["SIGNATURE_HTML"].ToString();
                try { gblradexperience.SIGNATURE_SCAN = (byte[])dsRad.Tables[0].Rows[0]["SIGNATURE_SCAN"]; }
                catch { }
                gblradexperience.USED_SIGNATURE = dsRad.Tables[0].Rows[0]["USED_SIGNATURE"].ToString();
                gblradexperience.WHEN_GROUP_SIGN_USE = dsRad.Tables[0].Rows[0]["WHEN_GROUP_SIGN_USE"].ToString();
                gblradexperience.MINIMIZE_CHARACTER = Convert.ToInt32(dsRad.Tables[0].Rows[0]["MINIMIZE_CHARACTER"].ToString());
                gblradexperience.WORKLIST_GRID_ORDER = dsRad.Tables[0].Rows[0]["WORKLIST_GRID_ORDER"].ToString();
                gblradexperience.HISTORY_GRID_ORDER = dsRad.Tables[0].Rows[0]["HISTORY_GRID_ORDER"].ToString();
            }
            else
            { 
                gblradexperience.AUTO_REFRESH_WL_SEC = 120;
                gblradexperience.DASHBOARD_DEF_SEARCH = "H";
                gblradexperience.LOAD_FINALIZED_EXAMS = false;
                gblradexperience.ALL_EXAM_VISIBLE = false;
                gblradexperience.LOAD_ALL_EXAM = false;
                gblradexperience.AUTO_START_ORDER_IMG = false;
                gblradexperience.AUTO_START_PACS_IMG = false;
                gblradexperience.DEF_DATE_RANGE = "1";
                gblradexperience.REMEMBER_GRID_ORDER = false;
                gblradexperience.GRID_DBL_CLICK_TO = "W";
                gblradexperience.FINISH_WRITING_REFER_TO = "N";
                gblradexperience.ALLOW_OTHERSTO_FINALIZE = true;
                gblradexperience.FONT_FACE = "Microsoft Sans Serif";
                try { gblradexperience.FONT_SIZE = 10; }
                catch { }
                gblradexperience.SIGNATURE_TEXT = "";
                gblradexperience.SIGNATURE_RTF = @"{\rtf1\ansi\ansicpg874\deff0\deflang1054{\fonttbl{\f0\fnil\fcharset0 Tahoma;}}
\viewkind4\uc1\pard\f0\fs17\par
}
";
                gblradexperience.SIGNATURE_HTML = "Error";
                try { gblradexperience.SIGNATURE_SCAN = new byte[] {}; }
                catch { }
                gblradexperience.USED_SIGNATURE = "T";
                gblradexperience.WHEN_GROUP_SIGN_USE = "1";
                gblradexperience.MINIMIZE_CHARACTER = 8;
                gblradexperience.WORKLIST_GRID_ORDER = "";
                gblradexperience.HISTORY_GRID_ORDER = "";

                gblradexperience.CREATED_BY = new RIS.Common.Common.GBLEnvVariable().UserID;
                gblradexperience.RADIOLOGIST_ID = new RIS.Common.Common.GBLEnvVariable().UserID;
                gblradexperience.ORG_ID = new RIS.Common.Common.GBLEnvVariable().OrgID;

                ProcessAddGBLRadexperience radAdd = new ProcessAddGBLRadexperience();
                radAdd.GBLRadexperience = gblradexperience;
                try
                {
                    radAdd.Invoke();
                }
                catch (Exception ex)
                { 
                    
                }
            }
            return gblradexperience;
        }
        public RISExamresult RISExamresult 
        {
            get { return examResult; }
            set { examResult = value; }
        }
        public RISExamresultlegacy RISExamresultlegacy
        {
            get { return examResultlegacy; }
            set { examResultlegacy = value; }
        }
        public RISExamresultseverity RISExamresultseverity
        {
            get { return examResultserverity; }
            set { examResultserverity = value; }
        }
        public RISExamresulttemplate  RISExamresulttemplate
        {
            get { return examTemplate; }
            set { examTemplate = value; }
        }
        public void AddTemplateShare(RISExamtemplateshare item)
        {
            examSharedList.Add(item);
        }
        public bool Shared {
            get { return _shared; }
            set { _shared=value; }
        }
        public DataTable GetWorkList() {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetWorkList();
        }
        public DataSet GetCaseAmount() {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetCaseAmount();
        }
        public DataSet GetHistory() {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetHistory();
        }
        public DataTable GetRadiologist() {
            ProcessGetRISOrderdtl processRadiologist = new ProcessGetRISOrderdtl();
            DataTable dtRadiologist = processRadiologist.GetRadioLogist().Copy();
            return dtRadiologist;
        }
        public DataTable GetRadioFinalize() {
            ProcessGetRISOrderdtl processRadiologist = new ProcessGetRISOrderdtl();
            DataTable dtRadiologist = processRadiologist.GetRadioLogist().Copy();
            DataRow[] drs = dtRadiologist.Select(@"AUTH_LEVEL_ID=3 AND ALLOW_OTHERS_TO_FINALIZE = 'Y'");
            DataTable dtt = dtRadiologist.Clone();
            foreach (DataRow dr in drs)
            {
                DataRow r = dtt.NewRow();
                for (int i = 0; i < dtt.Columns.Count; i++)
                {
                    r[i] = dr[i];
                }
                dtt.Rows.Add(r);
            }
            dtt.AcceptChanges();
            return dtt;
        }
        public DataSet GetTemplate() {
            RISExamresulttemplateSelectData proc = new RISExamresulttemplateSelectData();
            proc.RISExamresult = RISExamresult;
            return proc.GetData();
        }
        public DataTable GetBrowseArchive()
        {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetArchive();
        }
        public DataTable GetBrowseArchiveLegacy()
        {
            examLegacySelect.RISExamresultlegacy = RISExamresultlegacy;
            return examLegacySelect.GetArchive();
        }
        public DataTable GetExamresultSeverity()
        {
            examResultSeveritySelect = new RISExamresultseveritySelectData();
            examResultSeveritySelect.RISExamresultseverity = examResultserverity;
            return examResultSeveritySelect.GetData().Tables[0];
        }
        public DataTable GetTemplateShare() {
            RISExamresulttemplateSelectData proc = new RISExamresulttemplateSelectData();
            proc.RISExamresult = RISExamresult;
            return proc.GetTemplateShare();
        }
        public DataTable GetTransfer()
        {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetTransfer();
        }
        public DataTable GetICD(int OrderID) {
            DataTable dtPatICD=new DataTable();
            ProcessGetRISPaticd processRISPatICD = new ProcessGetRISPaticd(OrderID);
            processRISPatICD.Invoke();
            dtPatICD = processRISPatICD.Result.Tables[0];
            return dtPatICD;
        }
        public DataTable GetMergeData() {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetMergeData();
        }
        public DataTable GetExamResult() {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetExamResult();
        }
        public DataSet GetExamNote() {
            examSelect.RISExamresult = RISExamresult;
            return examSelect.GetExamNote();
        }
        public DataTable GetNextCase(string ACCESSION_NO)
        {
            return examSelect.GetNextData(ACCESSION_NO);
        }
        public DataTable GetPreviousCase(string ACCESSION_NO)
        {
            return examSelect.GetPreviousData(ACCESSION_NO);
        }
        public void UpdateTransfer()
        {
            examSelect.RISExamresult = RISExamresult;
            examSelect.UpdateTransfer();
        }
        public void SaveTemplate() {
            RISExamresulttemplateInsertData proc = new RISExamresulttemplateInsertData();
            proc.RISExamresulttemplate = examTemplate;
            examTemplate.TEMPLATE_ID=proc.Add();
            if (_shared)
            {
                if (examTemplate.TEMPLATE_ID > 0)
                {
                    
                    foreach (RISExamtemplateshare item in examSharedList) { 
                        
                        RISExamtemplateshareInsertData process = new RISExamtemplateshareInsertData();
                        process.RISExamtemplateshare = item;
                        process.RISExamtemplateshare.TEMPLATE_ID = examTemplate.TEMPLATE_ID;
                        process.Add();
                    }
                }
            }
        }
        public void DeleteTemplate(int ID) {
            RISExamresulttemplateDeleteData proc = new RISExamresulttemplateDeleteData();
            proc.RISExamresulttemplate.TEMPLATE_ID = ID;
            proc.Delete();
        }
        public void MergeSplit() {
            examSelect.RISExamresult = RISExamresult;
            examSelect.Merge();
        }
        public void Reporting() {
            examReport.RISExamresult = RISExamresult;
            examReport.Add();
        }
    }
}
