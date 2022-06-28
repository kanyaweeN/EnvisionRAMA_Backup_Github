using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;

using Envision.Common;

using Envision.DataAccess.Insert;
using Envision.DataAccess.Delete;
using Envision.DataAccess.Select;
using Envision.DataAccess.Update;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessDelete;

using Envision.WebService.PACSService;

namespace Envision.BusinessLogic
{
    public class ResultEntry
    {

        private GBL_RADEXPERIENCE gblradexperience;
        private RIS_EXAMRESULT examResult;
        private RIS_EXAMRESULTLEGACY examResultlegacy;
        private RIS_EXAMRESULTSEVERITY examResultserverity;
        private RISExamresultSelectData examSelect;
        private RISExamresultlegacySelectData examLegacySelect;
        private RISExamresultseveritySelectData examResultSeveritySelect;
        private RISExamresultInsertData examReport;
        private RIS_EXAMRESULTTEMPLATE examTemplate;
        private List<RIS_EXAMTEMPLATESHARE> examSharedList;
        private bool _shared;

        public ResultEntry() 
        {
            examResult = new RIS_EXAMRESULT();
            examResultlegacy = new RIS_EXAMRESULTLEGACY();
            examResultserverity = new RIS_EXAMRESULTSEVERITY();
            examTemplate = new RIS_EXAMRESULTTEMPLATE();
            examSharedList = new List<RIS_EXAMTEMPLATESHARE>();
            examSelect = new RISExamresultSelectData();
            examLegacySelect = new RISExamresultlegacySelectData();
            examReport = new RISExamresultInsertData();
            _shared = false;
            RIS_EXAMRESULT_DTL = new RIS_EXAMRESULT_DTL();
        }
        public GBL_RADEXPERIENCE GetRadiologistConfig(int RadiologistID)
        {
            GBL_RADEXPERIENCE gblradexperience = new GBL_RADEXPERIENCE();
            LookUpSelect ls = new LookUpSelect();
            DataSet dsRad = ls.SelectRadiologistConfig(RadiologistID);
            gblradexperience.AUTO_REFRESH_WL_SEC = Convert.ToInt16(dsRad.Tables[0].Rows[0]["AUTO_REFRESH_WL_SEC"].ToString());
            gblradexperience.DASHBOARD_DEF_SEARCH = Convert.ToChar(dsRad.Tables[0].Rows[0]["DASHBOARD_DEF_SEARCH"].ToString());
            gblradexperience.LOAD_FINALIZED_EXAMS = (bool)dsRad.Tables[0].Rows[0]["LOAD_FINALIZED_EXAMS"];
            gblradexperience.ALL_EXAM_VISIBLE = (bool)dsRad.Tables[0].Rows[0]["ALL_EXAM_VISIBLE"];
            gblradexperience.LOAD_ALL_EXAM = (bool)dsRad.Tables[0].Rows[0]["LOAD_ALL_EXAM"];
            gblradexperience.AUTO_START_ORDER_IMG = (bool)dsRad.Tables[0].Rows[0]["AUTO_START_ORDER_IMG"];
            gblradexperience.AUTO_START_PACS_IMG = (bool)dsRad.Tables[0].Rows[0]["AUTO_START_PACS_IMG"];
            //gblradexperience.DEF_DATE_RANGE = Convert.ToChar(dsRad.Tables[0].Rows[0]["DEF_DATE_RANGE"].ToString());
            gblradexperience.DEF_DATE_RANGE = dsRad.Tables[0].Rows[0]["DEF_DATE_RANGE"].ToString();
            gblradexperience.REMEMBER_GRID_ORDER = (bool)dsRad.Tables[0].Rows[0]["REMEMBER_GRID_ORDER"];
            gblradexperience.GRID_DBL_CLICK_TO = Convert.ToChar(dsRad.Tables[0].Rows[0]["GRID_DBL_CLICK_TO"].ToString());
            gblradexperience.FINISH_WRITING_REFER_TO = Convert.ToChar(dsRad.Tables[0].Rows[0]["FINISH_WRITING_REFER_TO"].ToString());
            gblradexperience.ALLOW_OTHERSTO_FINALIZE = (bool)dsRad.Tables[0].Rows[0]["ALLOW_OTHERSTO_FINALIZE"];
            gblradexperience.FONT_FACE = dsRad.Tables[0].Rows[0]["FONT_FACE"].ToString();
            try { gblradexperience.FONT_SIZE = (byte)dsRad.Tables[0].Rows[0]["FONT_SIZE"]; }catch { }
            gblradexperience.SIGNATURE_TEXT = dsRad.Tables[0].Rows[0]["SIGNATURE_TEXT"].ToString();
            gblradexperience.SIGNATURE_RTF = dsRad.Tables[0].Rows[0]["SIGNATURE_RTF"].ToString();
            gblradexperience.SIGNATURE_HTML = dsRad.Tables[0].Rows[0]["SIGNATURE_HTML"].ToString();
            try { gblradexperience.SIGNATURE_SCAN = (byte[])dsRad.Tables[0].Rows[0]["SIGNATURE_SCAN"]; }catch { }
            gblradexperience.USED_SIGNATURE = Convert.ToChar(dsRad.Tables[0].Rows[0]["USED_SIGNATURE"].ToString());
            gblradexperience.WHEN_GROUP_SIGN_USE = Convert.ToChar(dsRad.Tables[0].Rows[0]["WHEN_GROUP_SIGN_USE"].ToString());
            gblradexperience.MINIMIZE_CHARACTER = Convert.ToInt32(dsRad.Tables[0].Rows[0]["MINIMIZE_CHARACTER"].ToString());
            gblradexperience.WORKLIST_GRID_ORDER = dsRad.Tables[0].Rows[0]["WORKLIST_GRID_ORDER"].ToString();
            gblradexperience.HISTORY_GRID_ORDER = dsRad.Tables[0].Rows[0]["HISTORY_GRID_ORDER"].ToString();
            gblradexperience.IS_ADDENDUM = dsRad.Tables[0].Rows[0]["IS_ADDENDUM"].ToString();
            gblradexperience.ZOOM_SETTING = dsRad.Tables[0].Rows[0]["ZOOM_SETTING"].ToString() == "" ? 100 : Convert.ToInt32(dsRad.Tables[0].Rows[0]["ZOOM_SETTING"].ToString());
            gblradexperience.AUTO_CLINICALINDICATION = dsRad.Tables[0].Rows[0]["AUTO_CLINICALINDICATION"].ToString();
            gblradexperience.AUTO_EXAMNAME = dsRad.Tables[0].Rows[0]["AUTO_EXAMNAME"].ToString();
            gblradexperience.OPEN_PACS_WHEN_MERGE = dsRad.Tables[0].Rows[0]["OPEN_PACS_WHEN_MERGE"].ToString();
            gblradexperience.MAXIMUM_SHORTPRELIM_CHARECTORS = dsRad.Tables[0].Rows[0]["MAXIMUM_SHORTPRELIM_CHARECTORS"].ToString() == "" ? 0 : Convert.ToInt32(dsRad.Tables[0].Rows[0]["MAXIMUM_SHORTPRELIM_CHARECTORS"]);
            return gblradexperience;
        }
        public RIS_EXAMRESULT RISExamresult 
        {
            get { return examResult; }
            set { examResult = value; }
        }
        public RIS_EXAMRESULTLEGACY RISExamresultlegacy
        {
            get { return examResultlegacy; }
            set { examResultlegacy = value; }
        }
        public RIS_EXAMRESULTSEVERITY RISExamresultseverity
        {
            get { return examResultserverity; }
            set { examResultserverity = value; }
        }
        public RIS_EXAMRESULTTEMPLATE RISExamresulttemplate
        {
            get { return examTemplate; }
            set { examTemplate = value; }
        }
        public RIS_EXAMRESULT_DTL RIS_EXAMRESULT_DTL { get; set; }
        public void AddTemplateShare(RIS_EXAMTEMPLATESHARE item)
        {
            examSharedList.Add(item);
        }
        public bool Shared {
            get { return _shared; }
            set { _shared=value; }
        }
        public DataTable GetWorkList() {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetWorkList();
        }
        public DataTable GetWorkListSchedule()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetWorkListSchedule();
        }
        public DataTable GetWorkListCovid()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetWorkListCovid();
        }
        public DataTable GetCaseSelect(string _Acc,int _EmpID)
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetCaseSelect(_Acc,_EmpID);
        }
        public DataSet GetCaseAmount() {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetCaseAmount();
        }
        public DataSet GetCaseAmountDetail()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetCaseAmountDetail();
        }
        public DataTable GetHistory() {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetHistory();
        }
        public DataTable GetHistoryReport()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetHistoryReport();
        }
        public DataTable GetDemographic()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetDemographic();
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
            proc.RIS_EXAMRESULT = RISExamresult;
            return proc.GetData();
        }
        public DataTable GetTemplateById(int TemplateId) {
            DataTable dtt = new DataTable();
            RISExamresulttemplateSelectData proc = new RISExamresulttemplateSelectData();
            proc.RIS_EXAMRESULTTEMPLATE.TEMPLATE_ID = TemplateId;
            return proc.GetTemplateById();
        }
        public DataTable GetTemplateAuto(int exam_id) {
            DataTable dtt = new DataTable();
            RISExamresulttemplateSelectData proc = new RISExamresulttemplateSelectData();
            proc.RIS_EXAMRESULTTEMPLATE.EXAM_ID = exam_id;
            proc.RIS_EXAMRESULTTEMPLATE.CREATED_BY = new GBLEnvVariable().UserID;
            return proc.GetTemplateAuto();
        }
        public DataTable GetBrowseArchive()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetArchive();
        }
        public DataTable GetBrowseArchiveLegacy()
        {
            examLegacySelect.RIS_EXAMRESULTLEGACY = RISExamresultlegacy;
            return examLegacySelect.GetArchive();
        }
        public DataTable GetExamresultSeverity()
        {
            examResultSeveritySelect = new RISExamresultseveritySelectData();
            examResultSeveritySelect.RIS_EXAMRESULTSEVERITY = examResultserverity;
            return examResultSeveritySelect.GetData().Tables[0];
        }
        public DataTable GetTemplateShare() {
            RISExamresulttemplateSelectData proc = new RISExamresulttemplateSelectData();
            proc.RIS_EXAMRESULT = RISExamresult;
            return proc.GetTemplateShare();
        }
        public DataTable GetTransfer(string strAccession)
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetTransfer(strAccession);
        }
        public DataTable GetTransferRadiologist()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetTransferRadiologist();
        }
        public DataTable GetICD(int OrderID) {
            DataTable dtPatICD=new DataTable();
            ProcessGetRISPaticd processRISPatICD = new ProcessGetRISPaticd(OrderID);
            processRISPatICD.Invoke();
            dtPatICD = processRISPatICD.Result.Tables[0];
            return dtPatICD;
        }
        public DataTable GetMergeData() {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetMergeData();
        }
        public DataTable GetExamResult() {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetExamResult();
        }
        public DataSet GetExamNote() {
            examSelect.RIS_EXAMRESULT = RISExamresult;
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
            examSelect.RIS_EXAMRESULT = RISExamresult;
            examSelect.UpdateTransfer();
        }
        public void SaveTemplate() {
            RISExamresulttemplateInsertData proc = new RISExamresulttemplateInsertData();
            proc.RIS_EXAMRESULTTEMPLATE = examTemplate;
            examTemplate.TEMPLATE_ID=proc.Add();
            if (_shared)
            {
                if (examTemplate.TEMPLATE_ID > 0)
                {
                    
                    foreach (RIS_EXAMTEMPLATESHARE item in examSharedList) { 
                        
                        RISExamtemplateshareInsertData process = new RISExamtemplateshareInsertData();
                        process.RIS_EXAMTEMPLATESHARE = item;
                        process.RIS_EXAMTEMPLATESHARE.TEMPLATE_ID = examTemplate.TEMPLATE_ID;
                        process.Add();
                    }
                }
            }
        }
        public void DeleteTemplate(int ID) {
            RIS_EXAMRESULTTEMPLATEDeleteData proc = new RIS_EXAMRESULTTEMPLATEDeleteData();
            proc.RIS_EXAMRESULTTEMPLATE.TEMPLATE_ID = ID;
            proc.Delete();
        }
        public void MergeSplit() {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            examSelect.Merge();
        }
        public void Reporting() {
            examReport.RIS_EXAMRESULT = RISExamresult;
            examReport.Add();
        }
        public void ReportingDtl()
        {
            RISExamresultDtlInsertData resultDtl = new RISExamresultDtlInsertData();
            resultDtl.RIS_EXAMRESULT_DTL = RIS_EXAMRESULT_DTL;
            resultDtl.Add();
        }
        public void UpdateServerity()
        {
            examReport.RIS_EXAMRESULT = RISExamresult;
            examReport.UpdateServerity();
        }
        public void UpdateServerityLog(string accession_no,int severitylog_id)
        {
            examReport.UpdateServerityLog(accession_no, severitylog_id);
        }
        public void UpdateHtml()
        {
            examReport.RIS_EXAMRESULT = RISExamresult;
            examReport.UpdateHtml();
        }
        public string ReportStatus(string ACCESSION_NO)
        {
            string status = string.Empty;
            try
            {
                DataTable dtt = examSelect.GetReportStatus(ACCESSION_NO);
                if (dtt.Rows.Count == 0)
                    status = "A";
                else
                    status = dtt.Rows[0][0].ToString().Trim();
            }
            catch { }
            return status;
        }
        public DataSet GetConsultCaseData(string ACCESSION_NO)
        {
            examSelect = new RISExamresultSelectData();
            DataSet ds = examSelect.GetConsultCase(ACCESSION_NO);
            return ds;
        }
        public bool GetCanUserFinalize(int emp_id, int exam_id)
        {
            LookUpSelect lkp = new LookUpSelect();
            DataSet ds = lkp.SelectAcFinalizePrivilegeCanUserFinalize(emp_id, exam_id);
            int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            if (count == 0)
                return false;
            else
                return true;
        }
        public DataSet GetExamStatReport()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetExamStatReport();
        }
    }
}
