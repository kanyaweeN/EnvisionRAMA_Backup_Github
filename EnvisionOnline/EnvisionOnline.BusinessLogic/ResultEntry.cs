using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;

using EnvisionOnline.Common;

using EnvisionOnline.DataAccess.Insert;
using EnvisionOnline.DataAccess.Delete;
using EnvisionOnline.DataAccess.Select;
using EnvisionOnline.DataAccess.Update;

using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.BusinessLogic.ProcessDelete;

namespace EnvisionOnline.BusinessLogic
{
    public class ResultEntry
    {
        private RIS_EXAMRESULT examResult;
        private RISExamresultSelectData examSelect;
        public ResultEntry()
        {
            examResult = new RIS_EXAMRESULT();
            //examResultlegacy = new RIS_EXAMRESULTLEGACY();
            //examResultserverity = new RIS_EXAMRESULTSEVERITY();
            //examTemplate = new RIS_EXAMRESULTTEMPLATE();
            //examSharedList = new List<RIS_EXAMTEMPLATESHARE>();
            examSelect = new RISExamresultSelectData();
            //examLegacySelect = new RISExamresultlegacySelectData();
            //examReport = new RISExamresultInsertData();
            //_shared = false;
        }
        public RIS_EXAMRESULT RISExamresult
        {
            get { return examResult; }
            set { examResult = value; }
        }

        public DataTable GetMergeData()
        {
            examSelect.RIS_EXAMRESULT = RISExamresult;
            return examSelect.GetMergeData();
        }

        public DataSet getReportPreview(string accession_no)
        {
            DataSet ds = new DataSet();
            _LookUpSelect lv = new _LookUpSelect();
            ds = lv.selectDataResultByAccessionNo(accession_no);
            return ds;
        }
        public void getResultReportData(string accession_no,out DataTable reportData,out string ExamName)
        {
            string bpView = "";
            DataTable dttMerge = new DataTable();
            ReportParameters para = new ReportParameters();
            para.SpType = 1;
            para.AccessionNo = accession_no;
            ProcessResultEntryReport lkp = new ProcessResultEntryReport();
            lkp.ReportParameters = para;
            lkp.Invoke();
            reportData = lkp.ResultSet.Tables[0];


            if (reportData.Rows.Count > 0)
            {
                reportData.Rows[0]["ResultDoctor"] = arrangeGroup(accession_no);
                if (!string.IsNullOrEmpty(reportData.Rows[0]["BPVIEW_DESC"].ToString()))
                    bpView = " [ " + reportData.Rows[0]["BPVIEW_DESC"].ToString() + " ] ";

                RISExamresult.ACCESSION_NO = reportData.Rows[0]["ACCESSION_NO"].ToString();
                RISExamresult.MERGE = reportData.Rows[0]["MERGE"].ToString();
                RISExamresult.MERGE_WITH = reportData.Rows[0]["MERGE_WITH"].ToString();
                dttMerge = GetMergeData();
            }
            ExamName = reportData.Rows[0]["EXAM_NAME"].ToString() + bpView + "  :   " + reportData.Rows[0]["EXAM_UID"].ToString();
            if (dttMerge.Rows.Count > 0)
            {
                foreach (DataRow drMerge in dttMerge.Rows)
                {
                    if (drMerge["ACCESSION_NO"].ToString() != reportData.Rows[0]["ACCESSION_NO"].ToString())
                    {
                        if (!string.IsNullOrEmpty(drMerge["BPVIEW_DESC"].ToString()))
                            bpView = " [ " + drMerge["BPVIEW_DESC"].ToString() + " ] ";
                        else
                            bpView = "";
                        ExamName = ExamName + " \r\n" + drMerge["EXAM_NAME"].ToString() + bpView + "  :   " + drMerge["EXAM_UID"].ToString();
                    }
                }
            }

        }
        private string arrangeGroup(string accession_no)
        {
            ProcessGetHREmp geHr = new ProcessGetHREmp();
            geHr.HR_EMP.MODE = "select_All_Active";
            geHr.Invoke();
            DataTable dtHr = new DataTable();
            dtHr = geHr.Result.Tables[0];
            string finalName = "";
            string ResultDoctor = "";
            ProcessGetRISExamresultrads rad = new ProcessGetRISExamresultrads();
            rad.RIS_EXAMRESULTRADS.ACCESSION_NO = accession_no;
            rad.Invoke();
            DataTable dtSetGroup = rad.Result.Tables[0];

            if (dtSetGroup.Rows.Count > 0)
            {
                foreach (DataRow dr in dtSetGroup.Rows)
                {
                    DataTable dtAuthe = selectCheckAuthen(Convert.ToInt32(dr["RAD_ID"]));
                    if (dtAuthe.Rows.Count > 0)
                    {
                        string resultDoc = "";
                        if (dtAuthe.Rows[0]["AUTH_LEVEL_ID"].ToString() == "3")
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            finalName += " ";
                            finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";

                            if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString().StartsWith("RAD"))
                                ResultDoctor += finalName + " Radiologist\r\n";
                            else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString().StartsWith("FEL"))
                                ResultDoctor += finalName + " Radiologist\r\n";
                            else
                                ResultDoctor += finalName + "\r\n";


                        }
                        else
                        {
                            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dr["RAD_ID"].ToString());
                            finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString().Trim() : drAssign[0]["FNAME_ENG"].ToString().Trim();
                            finalName += " ";
                            finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString().Trim() : drAssign[0]["LNAME_ENG"].ToString().Trim();
                            finalName += ", M.D.(" + drAssign[0]["EMP_UID"].ToString() + ")";
                            ResultDoctor += finalName + "\r\n";
                        }

                    }
                }
            }
            return ResultDoctor;
        }
        private DataTable selectCheckAuthen(int EMP_ID)
        {
            ProcessGetHREmp hr = new ProcessGetHREmp();
            hr.HR_EMP.MODE = "check_Auther";
            hr.HR_EMP.EMP_ID = EMP_ID;
            hr.Invoke();
            DataTable dtAuth = hr.Result.Tables[0];
            dtAuth.AcceptChanges();
            return dtAuth;
        }
        
    }
}
