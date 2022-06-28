using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using DevExpress.XtraBars;

namespace Envision.NET.Mammogram.StructureReport
{
    public partial class BiradGenerateTextViewer : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string accession_no = string.Empty;
        private string exam_code = string.Empty;
        private string exam_name = string.Empty;
        private GBLEnvVariable env = null;
        public BiradGenerateTextViewer(string accession, string exam_code, string exam_name, GBLEnvVariable env)
        {
            InitializeComponent();
            this.accession_no = accession;
            this.exam_code = exam_code;
            this.exam_name = exam_name;
            this.env = env;
            this.btnClose1.ItemClick += new ItemClickEventHandler(btnClose_ItemClick);
            this.btnPrint.ItemClick += new ItemClickEventHandler(btnPrint_ItemClick);
        }

        private void btnPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DialogResult result = MessageBox.Show("text", "test", MessageBoxButtons.OKCancel);
            //if (result == DialogResult.Cancel)
            //    return;
        }

        private void btnClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Show dialog with text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public DialogResult ShowDialog(string text, bool isRTFtext)
        {
            //DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            string examName;
            string bpView = "";
            DataTable dttMerge = new DataTable();

            ReportParameters para = new ReportParameters();
            para.SpType = 1;
            para.AccessionNo = accession_no;
            ProcessResultEntryReport lkp = new ProcessResultEntryReport();
            lkp.ReportParameters = para;
            lkp.Invoke();
            DataTable dt = lkp.ResultSet.Tables[0];

            #region group
            //ProcessGetHREmp geHr = new ProcessGetHREmp();
            //geHr.HR_EMP.MODE = "select_All_Active";
            //geHr.Invoke();
            //DataTable dtHr = new DataTable();
            //dtHr = geHr.Result.Tables[0];

            //ProcessGetRISExamresultrads getRe = new ProcessGetRISExamresultrads();
            //getRe.RIS_EXAMRESULTRADS.ACCESSION_NO = dr["ACCESSION NO"].ToString();
            //getRe.Invoke();
            //DataTable dtRe = getRe.Result.Tables[0];
            //DataTable dtRe2 = getRe.Result.Tables[1];
            //string finalName = "";
            //for (int i = 0; i < dtRe.Rows.Count; i++)
            //{
            //    DataRow[] drHr = dtHr.Select("EMP_ID=" + dtRe.Rows[i]["RAD_ID"].ToString());

            //    if (drHr != null)
            //    {
            //        if (drHr.Length > 0)
            //        {
            //            if (drHr[0]["AUTH_LEVEL_ID"].ToString() == "3")
            //            {
            //                DataTable dtAuthen = selectCheckAuthen(Convert.ToInt32(dtRe.Rows[i]["RAD_ID"]));
            //                finalName = string.IsNullOrEmpty(drHr[0]["FNAME_ENG"].ToString()) ? drHr[0]["FNAME"].ToString() : drHr[0]["FNAME_ENG"].ToString();
            //                finalName += " ";
            //                finalName += string.IsNullOrEmpty(drHr[0]["LNAME_ENG"].ToString()) ? drHr[0]["LNAME"].ToString() : drHr[0]["LNAME_ENG"].ToString();
            //                if (dtAuthen.Rows.Count > 0)
            //                {
            //                    if (dtAuthen.Rows[0]["JOB_TITLE_UID"].ToString() == "DEN003")
            //                        finalName += ",M.D.(" + drHr[0]["EMP_UID"].ToString() + ")";
            //                    else
            //                        finalName += ",M.D.(" + drHr[0]["EMP_UID"].ToString() + ") Radiologist";
            //                }
            //            }
            //            else
            //            {
            //                finalName = string.IsNullOrEmpty(drHr[0]["FNAME_ENG"].ToString()) ? drHr[0]["FNAME"].ToString() : drHr[0]["FNAME_ENG"].ToString();
            //                finalName += " ";
            //                finalName += string.IsNullOrEmpty(drHr[0]["LNAME_ENG"].ToString()) ? drHr[0]["LNAME"].ToString() : drHr[0]["LNAME_ENG"].ToString();
            //                finalName += ",M.D.(" + drHr[0]["EMP_UID"].ToString() + ")";
            //            }
            //        }

            //    }
            //    if (i == 0)
            //        dt.Rows[0]["ResultDoctor"] = finalName;
            //    else
            //        dt.Rows[0]["ResultDoctor"] += "\r\n" + finalName;
            //}
            //if (dtRe.Rows.Count > 0)
            //{
            //    if (!string.IsNullOrEmpty(dtRe2.Rows[0]["ASSIGNED_TO"].ToString()))
            //    {
            //        bool checkInGroup = false;
            //        foreach (DataRow drCheck in dtRe.Rows)
            //        {
            //            if (Convert.ToInt32(dtRe2.Rows[0]["ASSIGNED_TO"]) == Convert.ToInt32(drCheck["RAD_ID"]))
            //            {
            //                checkInGroup = true;
            //                break;
            //            }
            //        }
            //        if (!checkInGroup)
            //        {
            //            DataRow[] drAssign = dtHr.Select("EMP_ID=" + dtRe2.Rows[0]["ASSIGNED_TO"].ToString());
            //            finalName = string.IsNullOrEmpty(drAssign[0]["FNAME_ENG"].ToString()) ? drAssign[0]["FNAME"].ToString() : drAssign[0]["FNAME_ENG"].ToString();
            //            finalName += " ";
            //            finalName += string.IsNullOrEmpty(drAssign[0]["LNAME_ENG"].ToString()) ? drAssign[0]["LNAME"].ToString() : drAssign[0]["LNAME_ENG"].ToString();
            //            finalName += ",M.D.(" + drAssign[0]["EMP_UID"].ToString() + ") Radiologist";
            //            dt.Rows[0]["ResultDoctor"] = dt.Rows[0]["ResultDoctor"] + "\r\n" + finalName;

            //        }
            //    }
            //}
            //else
            //{
            //    DataRow[] drAssign = dtHr.Select("EMP_ID=" + dtRe2.Rows[0]["ASSIGNED_TO"].ToString());
            //    if (drAssign[0]["AUTH_LEVEL_ID"].ToString() == "3")
            //    {
            //        string resultDoc = dt.Rows[0]["ResultDoctor"].ToString().Trim();
            //        dt.Rows[0]["ResultDoctor"] = resultDoc + " Radiologist";
            //    }
            //}
            //string assingName = "";
            //if (!string.IsNullOrEmpty(dt.Rows[0]["ASSIGNED_TO"].ToString()))
            //{
            //    DataRow[] drAss = dtHr.Select("EMP_ID=" + dt.Rows[0]["ASSIGNED_TO"].ToString());
            //    if (drAss.Length > 0)
            //    {
            //        assingName = string.IsNullOrEmpty(drAss[0]["FNAME_ENG"].ToString()) ? drAss[0]["FNAME"].ToString() : drAss[0]["FNAME_ENG"].ToString();
            //        assingName += " ";
            //        assingName += string.IsNullOrEmpty(drAss[0]["LNAME_ENG"].ToString()) ? drAss[0]["LNAME"].ToString() : drAss[0]["LNAME_ENG"].ToString();
            //        assingName += ",M.D.(" + drAss[0]["EMP_UID"].ToString() + ") Radiologist";
            //    }
            //}
            //if (!string.IsNullOrEmpty(assingName))
            //    dt.Rows[0]["ResultDoctor"] = assingName + "\r\n" + dt.Rows[0]["ResultDoctor"].ToString(); 
            #endregion

            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["ResultDoctor"] = arrangeGroup(accession_no);
                if (!string.IsNullOrEmpty(dt.Rows[0]["BPVIEW_DESC"].ToString()))
                    bpView = " [ " + dt.Rows[0]["BPVIEW_DESC"].ToString() + " ] ";

                Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
                result.RISExamresult.ACCESSION_NO = dt.Rows[0]["ACCESSION_NO"].ToString();
                result.RISExamresult.MERGE = dt.Rows[0]["MERGE"].ToString();
                result.RISExamresult.MERGE_WITH = dt.Rows[0]["MERGE_WITH"].ToString();
                dttMerge = result.GetMergeData();
            }
            examName = exam_name + bpView + "  :   " + exam_code;
            //if (dttMerge.Rows.Count > 0)
            //{
            //    foreach (DataRow drMerge in dttMerge.Rows)
            //    {
            //        if (drMerge["ACCESSION_NO"].ToString() != accession_no)
            //        {
            //            if (!string.IsNullOrEmpty(drMerge["BPVIEW_DESC"].ToString()))
            //                bpView = " [ " + drMerge["BPVIEW_DESC"].ToString() + " ] ";
            //            else
            //                bpView = "";
            //            examName = examName + " \r\n" + drMerge["EXAM_NAME"].ToString() + bpView + "  :   " + drMerge["EXAM_UID"].ToString();
            //        }
            //    }
            //}

            string nameUser = env.FirstName + " " + env.LastName;

            ProcessGetRISExam geExam = new ProcessGetRISExam();
            geExam.Invoke();
            //DataTable dtExam = 
            DataRow[] drChechUnit = geExam.Result.Tables[0].Select("EXAM_UID='" + exam_code + "'");
            if (drChechUnit.Length <= 0)
            {
                return this.ShowDialog();
            }

            if (drChechUnit[0]["UNIT_ID"].ToString() == "2")
            {
                Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionAIMC xrpt = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionAIMC(dt, nameUser, examName);
                xrpt.DataSource = dt;
                xrpt.ShowPreviewMarginLines = false;
                xrpt.ShowPreview();
            }
            else
            {
                Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision biradReport = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision(dt, nameUser, examName, text);

                biradReport.DataSource = dt;
                biradReport.ShowPreviewMarginLines = false;
                biradReport.PrintingSystem = this.printingSystem1;
                biradReport.CreateDocument(true);
            }

            return this.ShowDialog();
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

                            if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "RAD001")
                                ResultDoctor += finalName + " Radiologist\r\n";
                            else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL001")
                                ResultDoctor += finalName + " Radiologist\r\n";
                            else if (dtAuthe.Rows[0]["JOB_TITLE_UID"].ToString() == "FEL002")
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