using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Envision.Plugin.CRFile;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;
using Envision.Plugin.XtraFile.xtraReports;

namespace Envision.Plugin.DirectPrint
{
    public class PrinterVariable
    {
        public string PrinterName;
        public string PaperStyle;
        //public PaperSize PaperSize;
    }
    public class DirectPrint
    {
        public PrinterVariable PrinterSelected;
        public string PrinterName { get; set; }
        public DirectPrint()
        {
            PrinterSelected = new PrinterVariable();
        }

        #region DirectPrint
        public void InvoiceDirectPrint(string _txtThaiBaht, string _txtResultRate, int _id, string _status, string RefName, string RefAdr, bool Print)
        {
            try
            {
                
                CRFile.rptInvoice invoice = new rptInvoice();
                ProcessGetRptInvoice invo = new ProcessGetRptInvoice();
                invo.FIN_INVOICE.PAY_ID = _id;
                invo.FIN_INVOICE.REF_NAME = RefName;
                invo.FIN_INVOICE.REF_ADR = RefAdr;
                invo.FIN_INVOICE.STATUS = Convert.ToChar(_status);
                invo.Invoke();

                invoice.SetDataSource(invo.ResultSet.Tables[0]);
                DataTable dtt = invo.ResultSet.Tables[0];

                Section section;
                TextObject txtThaiBaht;
                TextObject txtResultRate;
                section = invoice.ReportDefinition.Sections["Section4"];

                txtThaiBaht = section.ReportObjects["txtThaiBaht"] as TextObject;
                txtResultRate = section.ReportObjects["txtResultRate"] as TextObject;
                txtThaiBaht.Text = _txtThaiBaht;
                txtResultRate.Text = _txtResultRate;

                invoice.PrintOptions.PrinterName = getdefaultprinter();
                invoice.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)getPaperSize("A5_Rotated");
                //invoice.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                if (Print == true)
                {
                    invoice.PrintToPrinter(1, true, 0, 0);
                }
            }
            catch (Exception Err)
            {

                MessageBox.Show(Err.ToString());
            }
        }
        public void ReceiptDirectPrint(string _txtThaiBaht, int _id, string _status, string RefName, string RefAdr, bool Print)
        {
            try
            {
                CRFile.rptReceipt receipt = new rptReceipt();
                ProcessGetRptInvoice invo = new ProcessGetRptInvoice();
                invo.FIN_INVOICE.PAY_ID = _id;
                invo.FIN_INVOICE.REF_NAME = RefName;
                invo.FIN_INVOICE.REF_ADR = RefAdr;
                invo.FIN_INVOICE.STATUS = Convert.ToChar(_status);
                invo.Invoke();

                receipt.SetDataSource(invo.ResultSet.Tables[0]);
                DataTable dtt = invo.ResultSet.Tables[0];

                Section section;
                TextObject txtThaiBaht;
                TextObject txtResultRate;
                section = receipt.ReportDefinition.Sections["Section4"];

                txtThaiBaht = section.ReportObjects["txtThaiBaht"] as TextObject;
                //txtResultRate = section.ReportObjects["txtResultRate"] as TextObject;
                txtThaiBaht.Text = _txtThaiBaht;
                //txtResultRate.Text = _txtResultRate;

                receipt.PrintOptions.PrinterName = getdefaultprinter();
                try
                {
                    receipt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)getPaperSize("A5_Rotated");
                }
                catch
                {
                    receipt.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    receipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                }
                //receipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                if (Print == true)
                {
                    receipt.PrintToPrinter(1, true, 0, 0);
                }
            }
            catch (Exception Err)
            {

                MessageBox.Show(Err.ToString());
            }
        }
        public void ReceiptDirectPrint2(string _txtThaiBaht, DataRow[] dr, string _status, string RefName, string RefAdr, bool Print)
        {
            try
            {
                CRFile.rptReceipt receipt = new rptReceipt();
                double Rate = 0.00;
                #region Create Table
                DataTable dtAdd = new DataTable();
                dtAdd.Columns.Add("Date");
                dtAdd.Columns.Add("EXAM_NAME");
                dtAdd.Columns.Add("SERVICE_TYPE");
                dtAdd.Columns.Add("FULLNAME");
                dtAdd.Columns.Add("ORG_NAME");
                dtAdd.Columns.Add("ORG_ADDR1");
                dtAdd.Columns.Add("ORG_EMAIL1");
                dtAdd.Columns.Add("ORG_WEBSITE");
                dtAdd.Columns.Add("ORG_TEL1");
                dtAdd.Columns.Add("ORG_IMG");
                dtAdd.Columns.Add("HOS_NAME");
                dtAdd.Columns.Add("ORG_FAX");
                dtAdd.Columns.Add("ORG_ADDR2");
                dtAdd.Columns.Add("ORG_ADDR3");
                dtAdd.Columns.Add("ORG_ADDR4");
                dtAdd.Columns.Add("ORG_TEL2");
                dtAdd.Columns.Add("ORG_TEL3");
                dtAdd.Columns.Add("phone");
                dtAdd.Columns.Add("PAID");
                dtAdd.Columns.Add("NUMBER");
                dtAdd.Columns.Add("STATUS");
                dtAdd.Columns.Add("RATE");
                dtAdd.Columns.Add("INSURANCE_TYPE_ID");
                dtAdd.AcceptChanges();
                #endregion

                int PayID = 0;
                ProcessGetRptInvoice invo = new ProcessGetRptInvoice();
                for (int i = 0; i < dr.Length; i++)
                {
                    if (PayID != Convert.ToInt32(dr[i]["PAY_ID"]))
                    {
                        invo.FIN_INVOICE.PAY_ID = Convert.ToInt32(dr[i]["PAY_ID"]);
                        invo.FIN_INVOICE.REF_NAME = RefName;
                        invo.FIN_INVOICE.REF_ADR = RefAdr;
                        invo.FIN_INVOICE.STATUS = Convert.ToChar(_status);
                        invo.Invoke();

                        DataRow drAdd;
                        if (invo.ResultSet.Tables[0].Rows.Count > 1)
                        {
                            foreach (DataRow drTest in invo.ResultSet.Tables[0].Rows)
                            {
                                drAdd = dtAdd.NewRow();
                                #region Add Multi Table
                                drAdd["Date"] = drTest["Date"];
                                drAdd["EXAM_NAME"] = drTest["EXAM_NAME"];
                                drAdd["SERVICE_TYPE"] = drTest["SERVICE_TYPE"];
                                drAdd["FULLNAME"] = drTest["FULLNAME"];
                                drAdd["ORG_NAME"] = drTest["ORG_NAME"];
                                drAdd["ORG_ADDR1"] = drTest["ORG_ADDR1"];
                                drAdd["ORG_EMAIL1"] = drTest["ORG_EMAIL1"];
                                drAdd["ORG_WEBSITE"] = drTest["ORG_WEBSITE"];
                                drAdd["ORG_TEL1"] = drTest["ORG_TEL1"];
                                drAdd["ORG_IMG"] = drTest["ORG_IMG"];
                                drAdd["HOS_NAME"] = drTest["HOS_NAME"];
                                drAdd["ORG_FAX"] = drTest["ORG_FAX"];
                                drAdd["ORG_ADDR2"] = drTest["ORG_ADDR2"];
                                drAdd["ORG_ADDR3"] = drTest["ORG_ADDR3"];
                                drAdd["ORG_ADDR4"] = drTest["ORG_ADDR4"];
                                drAdd["ORG_TEL2"] = drTest["ORG_TEL2"];
                                drAdd["ORG_TEL3"] = drTest["ORG_TEL3"];
                                drAdd["phone"] = drTest["phone"];
                                drAdd["PAID"] = Convert.ToDouble(drTest["PAID"]).ToString("#,##0.00");
                                drAdd["NUMBER"] = drTest["NUMBER"];
                                drAdd["STATUS"] = drTest["STATUS"];
                                drAdd["RATE"] = Convert.ToDouble(drTest["RATE"]).ToString("#,##0.00");
                                drAdd["INSURANCE_TYPE_ID"] = drTest["INSURANCE_TYPE_ID"];
                                dtAdd.Rows.Add(drAdd);
                                dtAdd.AcceptChanges();
                                Rate += Convert.ToDouble(drTest["RATE"]);
                                #endregion
                            }
                        }
                        else
                        {
                            drAdd = dtAdd.NewRow();
                            #region Add Table
                            drAdd["Date"] = invo.ResultSet.Tables[0].Rows[0]["Date"];
                            drAdd["EXAM_NAME"] = invo.ResultSet.Tables[0].Rows[0]["EXAM_NAME"];
                            drAdd["SERVICE_TYPE"] = invo.ResultSet.Tables[0].Rows[0]["SERVICE_TYPE"];
                            drAdd["FULLNAME"] = invo.ResultSet.Tables[0].Rows[0]["FULLNAME"];
                            drAdd["ORG_NAME"] = invo.ResultSet.Tables[0].Rows[0]["ORG_NAME"];
                            drAdd["ORG_ADDR1"] = invo.ResultSet.Tables[0].Rows[0]["ORG_ADDR1"];
                            drAdd["ORG_EMAIL1"] = invo.ResultSet.Tables[0].Rows[0]["ORG_EMAIL1"];
                            drAdd["ORG_WEBSITE"] = invo.ResultSet.Tables[0].Rows[0]["ORG_WEBSITE"];
                            drAdd["ORG_TEL1"] = invo.ResultSet.Tables[0].Rows[0]["ORG_TEL1"];
                            drAdd["ORG_IMG"] = invo.ResultSet.Tables[0].Rows[0]["ORG_IMG"];
                            drAdd["HOS_NAME"] = invo.ResultSet.Tables[0].Rows[0]["HOS_NAME"];
                            drAdd["ORG_FAX"] = invo.ResultSet.Tables[0].Rows[0]["ORG_FAX"];
                            drAdd["ORG_ADDR2"] = invo.ResultSet.Tables[0].Rows[0]["ORG_ADDR2"];
                            drAdd["ORG_ADDR3"] = invo.ResultSet.Tables[0].Rows[0]["ORG_ADDR3"];
                            drAdd["ORG_ADDR4"] = invo.ResultSet.Tables[0].Rows[0]["ORG_ADDR4"];
                            drAdd["ORG_TEL2"] = invo.ResultSet.Tables[0].Rows[0]["ORG_TEL2"];
                            drAdd["ORG_TEL3"] = invo.ResultSet.Tables[0].Rows[0]["ORG_TEL3"];
                            drAdd["phone"] = invo.ResultSet.Tables[0].Rows[0]["phone"];
                            drAdd["PAID"] = Convert.ToDouble(invo.ResultSet.Tables[0].Rows[0]["PAID"]).ToString("#,##0.00");
                            drAdd["NUMBER"] = invo.ResultSet.Tables[0].Rows[0]["NUMBER"];
                            drAdd["STATUS"] = invo.ResultSet.Tables[0].Rows[0]["STATUS"];
                            drAdd["RATE"] = Convert.ToDouble(invo.ResultSet.Tables[0].Rows[0]["RATE"]).ToString("#,##0.00");
                            drAdd["INSURANCE_TYPE_ID"] = invo.ResultSet.Tables[0].Rows[0]["INSURANCE_TYPE_ID"];
                            dtAdd.Rows.Add(drAdd);
                            dtAdd.AcceptChanges();
                            Rate += Convert.ToDouble(invo.ResultSet.Tables[0].Rows[0]["RATE"]);
                            #endregion
                        }
                        PayID = Convert.ToInt32(dr[i]["PAY_ID"]);
                    }
                }


                receipt.SetDataSource(dtAdd);

                DataTable dtt = invo.ResultSet.Tables[0];

                Section section;
                TextObject txtThaiBaht;
                TextObject txtResultRate;
                section = receipt.ReportDefinition.Sections["Section4"];

                txtThaiBaht = section.ReportObjects["txtThaiBaht"] as TextObject;
                txtResultRate = section.ReportObjects["txtRate"] as TextObject;
                txtThaiBaht.Text = _txtThaiBaht;
                txtResultRate.Text = Rate.ToString("#,##0.00");

                receipt.PrintOptions.PrinterName = getdefaultprinter();
                try
                {
                    receipt.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)getPaperSize("A5_Rotated");
                }
                catch
                {
                    receipt.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    receipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                }
                //receipt.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                if (Print == true)
                {
                    receipt.PrintToPrinter(1, true, 0, 0);
                }
            }
            catch (Exception Err)
            {

                MessageBox.Show(Err.ToString());
            }
        }
        public void ResultEntryDirectPrint(string _accno,int _authlevel)
        {

            try
            {
                CRFile.rptResultEntry vReport = new rptResultEntry();
                int PaperSize = -1;
                ReportParameters para = new ReportParameters();
                para.SpType = 1;
                para.AccessionNo = _accno;
                ProcessResultEntryReport lkp = new ProcessResultEntryReport();
                lkp.ReportParameters = para;
                lkp.Invoke();
                DataTable dt = lkp.ResultSet.Tables[0];

                vReport.SetDataSource(dt);

                vReport.PrintOptions.PrinterName = getdefaultprinter();
                PaperSize = getPaperSize("A5_Rotated");

                if (PaperSize >= 0)
                {
                    vReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)PaperSize;
                }
                else
                {
                    vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                    vReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                }
                //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                vReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }

        }
        public void ResultEntryDirectPrintA4(string _accno, int _authlevel)
        {
            try
            {
                string examName;
                string bpView = "";
                DataTable dttMerge = new DataTable();
                GBLEnvVariable env = new GBLEnvVariable();
                ReportParameters para = new ReportParameters();
                para.SpType = 1;
                para.AccessionNo = _accno;
                ProcessResultEntryReport lkp = new ProcessResultEntryReport();
                lkp.ReportParameters = para;
                lkp.Invoke();
                DataTable dt = lkp.ResultSet.Tables[0];


                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["ResultDoctor"] = arrangeGroup(_accno);
                    if (!string.IsNullOrEmpty(dt.Rows[0]["BPVIEW_DESC"].ToString()))
                        bpView = " [ " + dt.Rows[0]["BPVIEW_DESC"].ToString() + " ] ";

                    Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
                    result.RISExamresult.ACCESSION_NO = dt.Rows[0]["ACCESSION_NO"].ToString();
                    result.RISExamresult.MERGE = dt.Rows[0]["MERGE"].ToString();
                    result.RISExamresult.MERGE_WITH = dt.Rows[0]["MERGE_WITH"].ToString();
                    dttMerge = result.GetMergeData();
                }
                examName = dt.Rows[0]["EXAM_NAME"].ToString() + bpView + "  :   " + dt.Rows[0]["EXAM_UID"].ToString();
                if (dttMerge.Rows.Count > 0)
                {
                    foreach (DataRow drMerge in dttMerge.Rows)
                    {
                        if (drMerge["ACCESSION_NO"].ToString() != dt.Rows[0]["ACCESSION_NO"].ToString())
                        {
                            if (!string.IsNullOrEmpty(drMerge["BPVIEW_DESC"].ToString()))
                                bpView = " [ " + drMerge["BPVIEW_DESC"].ToString() + " ] ";
                            else
                                bpView = "";
                            examName = examName + " \r\n" + drMerge["EXAM_NAME"].ToString() + bpView + "  :   " + drMerge["EXAM_UID"].ToString();
                        }
                    }
                }
                string nameUser =  env.FirstName+" "+env.LastName;
                Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision xrpt 
                    = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision(dt, nameUser, examName);
                xrpt.DataSource = dt;
                xrpt.ShowPreviewMarginLines = false;
                xrpt.Print();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }

        }
        public void ResultEntryDirectPrintA4AIMC(string _accno, int _authlevel)
        {

            try
            {
                string examName;
                string bpView = "";
                DataTable dttMerge = new DataTable();
                GBLEnvVariable env = new GBLEnvVariable();
                ReportParameters para = new ReportParameters();
                para.SpType = 1;
                para.AccessionNo = _accno;
                ProcessResultEntryReport lkp = new ProcessResultEntryReport();
                lkp.ReportParameters = para;
                lkp.Invoke();
                DataTable dt = lkp.ResultSet.Tables[0];

                string IS_ER = "";

                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["ResultDoctor"] = arrangeGroup(_accno);
                    if (!string.IsNullOrEmpty(dt.Rows[0]["BPVIEW_DESC"].ToString()))
                        bpView = " [ " + dt.Rows[0]["BPVIEW_DESC"].ToString() + " ] ";

                    Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
                    result.RISExamresult.ACCESSION_NO = dt.Rows[0]["ACCESSION_NO"].ToString();
                    result.RISExamresult.MERGE = dt.Rows[0]["MERGE"].ToString();
                    result.RISExamresult.MERGE_WITH = dt.Rows[0]["MERGE_WITH"].ToString();
                    dttMerge = result.GetMergeData();

                    IS_ER = dt.Rows[0]["IS_ER"].ToString();
                }
                examName = dt.Rows[0]["EXAM_NAME"].ToString() + bpView + "  :   " + dt.Rows[0]["EXAM_UID"].ToString();
                if (dttMerge.Rows.Count > 0)
                {
                    foreach (DataRow drMerge in dttMerge.Rows)
                    {
                        if (drMerge["ACCESSION_NO"].ToString() != dt.Rows[0]["ACCESSION_NO"].ToString())
                        {
                            if (!string.IsNullOrEmpty(drMerge["BPVIEW_DESC"].ToString()))
                                bpView = " [ " + drMerge["BPVIEW_DESC"].ToString() + " ] ";
                            else
                                bpView = "";
                            examName = examName + " \r\n" + drMerge["EXAM_NAME"].ToString() + bpView + "  :   " + drMerge["EXAM_UID"].ToString();
                        }
                    }
                }

                string nameUser = env.FirstName + " " + env.LastName;
                Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionAIMC xrpt = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionAIMC(dt, nameUser, examName);
                xrpt.DataSource = dt;
                xrpt.ShowPreviewMarginLines = false;
                xrpt.Print();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }
        }
        public void ResultEntryDirectPrintA4SDMC(string _accno, int _authlevel)
        {
            try
            {
                string examName;
                string bpView = "";
                DataTable dttMerge = new DataTable();
                GBLEnvVariable env = new GBLEnvVariable();
                ReportParameters para = new ReportParameters();
                para.SpType = 1;
                para.AccessionNo = _accno;
                ProcessResultEntryReport lkp = new ProcessResultEntryReport();
                lkp.ReportParameters = para;
                lkp.Invoke();
                DataTable dt = lkp.ResultSet.Tables[0];


                if (dt.Rows.Count > 0)
                {
                    dt.Rows[0]["ResultDoctor"] = arrangeGroup(_accno);
                    if (!string.IsNullOrEmpty(dt.Rows[0]["BPVIEW_DESC"].ToString()))
                        bpView = " [ " + dt.Rows[0]["BPVIEW_DESC"].ToString() + " ] ";

                    Envision.BusinessLogic.ResultEntry result = new Envision.BusinessLogic.ResultEntry();
                    result.RISExamresult.ACCESSION_NO = dt.Rows[0]["ACCESSION_NO"].ToString();
                    result.RISExamresult.MERGE = dt.Rows[0]["MERGE"].ToString();
                    result.RISExamresult.MERGE_WITH = dt.Rows[0]["MERGE_WITH"].ToString();
                    dttMerge = result.GetMergeData();
                }
                examName = dt.Rows[0]["EXAM_NAME"].ToString() + bpView + "  :   " + dt.Rows[0]["EXAM_UID"].ToString();
                if (dttMerge.Rows.Count > 0)
                {
                    foreach (DataRow drMerge in dttMerge.Rows)
                    {
                        if (drMerge["ACCESSION_NO"].ToString() != dt.Rows[0]["ACCESSION_NO"].ToString())
                        {
                            if (!string.IsNullOrEmpty(drMerge["BPVIEW_DESC"].ToString()))
                                bpView = " [ " + drMerge["BPVIEW_DESC"].ToString() + " ] ";
                            else
                                bpView = "";
                            examName = examName + " \r\n" + drMerge["EXAM_NAME"].ToString() + bpView + "  :   " + drMerge["EXAM_UID"].ToString();
                        }
                    }
                }
                string nameUser = env.FirstName + " " + env.LastName;
                Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionSDMC xrpt = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvisionSDMC(dt, nameUser, examName);
                xrpt.DataSource = dt;
                xrpt.ShowPreviewMarginLines = false;
                xrpt.Print();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
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
        public int getPaperSize(string sizeName)
        {

            int i;
            int raw = -1;
            System.Drawing.Printing.PaperSize PSize = new System.Drawing.Printing.PaperSize();

            System.Drawing.Printing.PrintDocument PrintDoc = new System.Drawing.Printing.PrintDocument();

            for (i = 0; i < PrintDoc.PrinterSettings.PaperSizes.Count; i++)
            {

                if (PrintDoc.PrinterSettings.PaperSizes[i].PaperName == sizeName)
                {

                    PSize = PrintDoc.PrinterSettings.PaperSizes[i];
                    raw = (int)PrintDoc.PrinterSettings.PaperSizes[i].RawKind;

                }

            }

            return raw;


        }
        public void AppointmentDirectPrint(int scheduleId,string pat_dest) { AppointmentDirectPrint(scheduleId, pat_dest, 1); }
        public void AppointmentDirectPrint(int scheduleId, string pat_dest, int numberOfCopy)
        {
            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
            switch (pat_dest)
            {
                case "SDMC": report = new xrptScheduleReportSDMC(scheduleId); break;
                case "AIMC": report = new xrptScheduleReportAIMCNew(scheduleId); break;
                default: report = new xrptScheduleReport(scheduleId); break;
            }
            if (!string.IsNullOrEmpty(PrinterSelected.PrinterName))
                report.PrinterName = PrinterSelected.PrinterName;

            numberOfCopy = (numberOfCopy < 1) ? 1 : numberOfCopy;

            for (int _i = 0; _i < numberOfCopy; _i++)
                report.Print();
        }
        public void AppointmentDirectPrintMulti(DataSet ds, string pat_dest)
        {
            DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
            switch (pat_dest)
            {
                case "SDMC": report = new xrptScheduleReportSDMC(ds); break;
                case "AIMC": report = new xrptScheduleReportAIMC(ds); break;
                default: report = new xrptScheduleReport(ds); break;
            }
            if (!string.IsNullOrEmpty(PrinterSelected.PrinterName))
                report.PrinterName = PrinterSelected.PrinterName;
                report.Print();
        }
        public void ScheduleDirectPrint(string _hn, DateTime _appdate, int _modality,int _schedule)
        {

            try
            {
                CRFile.rptScheduleReport vsReport = new CRFile.rptScheduleReport();

                //ReportParameters spara = new ReportParameters();
                //spara.PatientId = _hn;
                //spara.AppointDate = _appdate;
                //spara.ModalityId = _modality;
                //spara.ScheduleID = _schedule;
                ProcessScheduleReport slkp = new ProcessScheduleReport();
                slkp.RIS_SCHEDULE.HN = _hn;
                slkp.RIS_SCHEDULE.START_DATETIME = _appdate;
                slkp.RIS_SCHEDULE.MODALITY_ID = _modality;
                slkp.RIS_SCHEDULE.SCHEDULE_ID = _schedule;
                slkp.Invoke();
                DataTable dts = slkp.ResultSet.Tables[0];
                DateTime preparedate = new DateTime();
                preparedate = _appdate.AddHours(-8);
                foreach (DataRow dr in dts.Rows)
                {
                    //if (_appdate.Hour < 12)

                    string prepare = preparedate.Day.ToString();
                    prepare += " ";
                    prepare += preparedate.ToString("MMMM");
                    prepare += " ";
                    prepare += Convert.ToString(preparedate.Year + 543);
                    prepare += " ";
                    prepare += preparedate.ToString("HH:MM");
                    prepare += " น.";
                    dr["INS_TEXT"] = "วิธีการเตรียมตัวก่อนตรวจ \r\n\t - งดน้ำและอาหาร ก่อนวันและเวลา " + prepare + "\r\n\t\r\n" + dr["INS_TEXT"].ToString() + "\r\n\t - หากท่านต้องการเลื่อนนัดกรุณาแจ้งล่วงหน้า 3 วันทำการ ได้ระหว่างเวลา 14:00-15:30 น. โทร. 022564593\r\n\t - หากท่านไม่สามารถมาตรวจตามนัดกรุณามาพบแพทย์ใหม่";
                    //else if (_appdate.Hour >= 12 && _appdate.Hour <= 15)
                    //    dr["INS_TEXT"] = dr["INS_TEXT"].ToString() + "\r\n - เลื่อนนัดแจ้งล่วงหน้า 3 วันทำการตั้งแต่เวลา 16:00-19:00 น. โทร. 022564593\r\n - ถ้าไม่ได้ทำนัดให้ติดต่อแพทย์";
                    //else if (_appdate.Hour > 15)
                    //    dr["INS_TEXT"] = dr["INS_TEXT"].ToString() + "\r\n - เลื่อนนัดแจ้งล่วงหน้า 3 วันทำการตั้งแต่เวลา 8:00-12:00 น. โทร. 022564593\r\n - ถ้าไม่ได้ทำนัดให้ติดต่อแพทย์";
                }
                vsReport.SetDataSource(dts);
                double rate = 0.00;
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    rate += Convert.ToDouble(dts.Rows[i]["RATE"].ToString());
                }

                Section sections;
                Section sections1;
                TextObject txtUser;
                TextObject txtSum;

                sections1 = vsReport.Subreports["SubExam"].ReportDefinition.Sections["ReportFooterSection2"];
                sections = vsReport.ReportDefinition.Sections["Section5"];
                // Get the ReportObject by name and cast it as a FieldObject.
                // The name can be found in the properties window.

                txtSum = sections1.ReportObjects["txtSum"] as TextObject;
                txtUser = sections.ReportObjects["txtUser"] as TextObject;
                txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;
                txtSum.Text = "รวมสุทธิ : " + rate.ToString("#,##0");

                try
                {
                    if (dts.Rows.Count == 1)
                        sections1.ReportObjects["txtSum"].ObjectFormat.EnableSuppress = true;
                }
                catch { }
                //Section sections;
                //TextObject txtUser;
                

                //sections = vsReport.ReportDefinition.Sections["Section5"];
                //// Get the ReportObject by name and cast it as a FieldObject.
                //// The name can be found in the properties window.

                //txtUser = sections.ReportObjects["txtUser"] as TextObject;
                //txtUser.Text = new GBLEnvVariable().FirstName +" "+ new GBLEnvVariable().LastName;
      
                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }


        }
        public void ScheduleDirectPrintAIMC(string _hn, DateTime _appdate, int _modality, int _schedule)
        {

            try
            {
                CRFile.rptScheduleReportAIMC vsReport = new CRFile.rptScheduleReportAIMC();

                ReportParameters spara = new ReportParameters();
                spara.PatientId = _hn;
                spara.AppointDate = _appdate;
                spara.ModalityId = _modality;
                spara.ScheduleID = _schedule;
                ProcessScheduleReport slkp = new ProcessScheduleReport();
                slkp.ReportParameters = spara;
                slkp.Invoke();
                DataTable dts = slkp.ResultSet.Tables[0];
                vsReport.SetDataSource(dts);

                Section sections;
                TextObject txtUser;


                sections = vsReport.ReportDefinition.Sections["Section5"];
                // Get the ReportObject by name and cast it as a FieldObject.
                // The name can be found in the properties window.

                txtUser = sections.ReportObjects["txtUser"] as TextObject;
                txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;

                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }


        }
        public void ScheduleDirectPrintMulti(DataTable dataTemp)
        {
            try
            {
                //CRFile.rptScheduleReport vsReport = new CRFile.rptScheduleReport();
                ProcessGetRISExam getEx = new ProcessGetRISExam();
                getEx.Invoke();
                DataRow[] drEx = getEx.Result.Tables[0].Select("EXAM_UID='" + dataTemp.Rows[0]["EXAM_UID"].ToString() + "'");
                foreach (DataRow dr in dataTemp.Rows)
                {
                    DateTime _appdate = new DateTime();
                    _appdate = Convert.ToDateTime(dr["APPOINT_DT"]);
                    DateTime preparedate = new DateTime();
                    preparedate = _appdate.AddHours(-8);
                }
                if (Convert.ToInt32(drEx[0]["EXAM_TYPE"]) == 1)//MR
                {
                    DataRow drAdd = dataTemp.NewRow();
                    drAdd["ORG_NAME"] = dataTemp.Rows[0]["ORG_NAME"];
                    drAdd["HN"] = dataTemp.Rows[0]["HN"];
                    drAdd["TITLE"] = dataTemp.Rows[0]["TITLE"];
                    drAdd["FNAME"] = dataTemp.Rows[0]["FNAME"];
                    drAdd["MNAME"] = dataTemp.Rows[0]["MNAME"];
                    drAdd["LNAME"] = dataTemp.Rows[0]["LNAME"];
                    drAdd["TITLE_ENG"] = dataTemp.Rows[0]["TITLE_ENG"];
                    drAdd["FNAME_ENG"] = dataTemp.Rows[0]["FNAME_ENG"];
                    drAdd["MNAME_ENG"] = dataTemp.Rows[0]["MNAME_ENG"];
                    drAdd["LNAME_ENG"] = dataTemp.Rows[0]["LNAME_ENG"];
                    drAdd["DOB"] = dataTemp.Rows[0]["DOB"];
                    drAdd["APPOINT_DT"] = dataTemp.Rows[0]["APPOINT_DT"];
                    drAdd["CLINIC_TYPE_TEXT"] = dataTemp.Rows[0]["CLINIC_TYPE_TEXT"];
                    drAdd["MODALITY_NAME"] = dataTemp.Rows[0]["MODALITY_NAME"];
                    drAdd["CREATED_BY"] = dataTemp.Rows[0]["CREATED_BY"];
                    drAdd["CREATED_ON"] = dataTemp.Rows[0]["CREATED_ON"];
                    drAdd["ORG_IMG"] = dataTemp.Rows[0]["ORG_IMG"];
                    drAdd["ORG_ADDR3"] = dataTemp.Rows[0]["ORG_ADDR3"];
                    drAdd["ORG_ADDR4"] = dataTemp.Rows[0]["ORG_ADDR4"];
                    drAdd["MODALITY_ID"] = dataTemp.Rows[0]["MODALITY_ID"];
                    drAdd["VENDOR_H2"] = dataTemp.Rows[0]["VENDOR_H2"];
                    drAdd["INS_TEXT"] = dataTemp.Rows[0]["INS_TEXT"];
                    drAdd["EXAM_TYPE_INS"] = dataTemp.Rows[0]["EXAM_TYPE_INS"];
                    drAdd["HR_UNIT_INS"] = dataTemp.Rows[0]["HR_UNIT_INS"];
                    drAdd["UNIT_NAME"] = dataTemp.Rows[0]["UNIT_NAME"];
                    drAdd["UNIT_TITLE"] = dataTemp.Rows[0]["UNIT_TITLE"];
                    drAdd["AGE"] = dataTemp.Rows[0]["AGE"];
                    drAdd["GENDER"] = dataTemp.Rows[0]["GENDER"];
                    drAdd["ROOM_UID"] = dataTemp.Rows[0]["ROOM_UID"];
                    drAdd["INSURANCE_TYPE_DESC"] = dataTemp.Rows[0]["INSURANCE_TYPE_DESC"];
                    drAdd["EXAM_UID"] = "";
                    drAdd["EXAM_NAME"] = "ค่ายา";
                    int rateMR = 2500;
                    int nonrate = 0;
                    drAdd["RATE"] = rateMR.ToString("#,##0");
                    drAdd["CLAIMABLE_AMT"] = rateMR.ToString("#,##0");
                    drAdd["NONCLAIMABLE_AMT"] = nonrate.ToString("#,##0");
                    dataTemp.Rows.Add(drAdd);
                    dataTemp.AcceptChanges();
                }
                else if (Convert.ToInt32(drEx[0]["EXAM_TYPE"]) == 2)//CT
                {
                    DataRow drAdd = dataTemp.NewRow();
                    drAdd["ORG_NAME"] = dataTemp.Rows[0]["ORG_NAME"];
                    drAdd["HN"] = dataTemp.Rows[0]["HN"];
                    drAdd["TITLE"] = dataTemp.Rows[0]["TITLE"];
                    drAdd["FNAME"] = dataTemp.Rows[0]["FNAME"];
                    drAdd["MNAME"] = dataTemp.Rows[0]["MNAME"];
                    drAdd["LNAME"] = dataTemp.Rows[0]["LNAME"];
                    drAdd["TITLE_ENG"] = dataTemp.Rows[0]["TITLE_ENG"];
                    drAdd["FNAME_ENG"] = dataTemp.Rows[0]["FNAME_ENG"];
                    drAdd["MNAME_ENG"] = dataTemp.Rows[0]["MNAME_ENG"];
                    drAdd["LNAME_ENG"] = dataTemp.Rows[0]["LNAME_ENG"];
                    drAdd["DOB"] = dataTemp.Rows[0]["DOB"];
                    drAdd["APPOINT_DT"] = dataTemp.Rows[0]["APPOINT_DT"];
                    drAdd["CLINIC_TYPE_TEXT"] = dataTemp.Rows[0]["CLINIC_TYPE_TEXT"];
                    drAdd["MODALITY_NAME"] = dataTemp.Rows[0]["MODALITY_NAME"];
                    drAdd["CREATED_BY"] = dataTemp.Rows[0]["CREATED_BY"];
                    drAdd["CREATED_ON"] = dataTemp.Rows[0]["CREATED_ON"];
                    drAdd["ORG_IMG"] = dataTemp.Rows[0]["ORG_IMG"];
                    drAdd["ORG_ADDR3"] = dataTemp.Rows[0]["ORG_ADDR3"];
                    drAdd["ORG_ADDR4"] = dataTemp.Rows[0]["ORG_ADDR4"];
                    drAdd["MODALITY_ID"] = dataTemp.Rows[0]["MODALITY_ID"];
                    drAdd["VENDOR_H2"] = dataTemp.Rows[0]["VENDOR_H2"];
                    drAdd["INS_TEXT"] = dataTemp.Rows[0]["INS_TEXT"];
                    drAdd["EXAM_TYPE_INS"] = dataTemp.Rows[0]["EXAM_TYPE_INS"];
                    drAdd["HR_UNIT_INS"] = dataTemp.Rows[0]["HR_UNIT_INS"];
                    drAdd["UNIT_NAME"] = dataTemp.Rows[0]["UNIT_NAME"];
                    drAdd["UNIT_TITLE"] = dataTemp.Rows[0]["UNIT_TITLE"];
                    drAdd["AGE"] = dataTemp.Rows[0]["AGE"];
                    drAdd["GENDER"] = dataTemp.Rows[0]["GENDER"];
                    drAdd["ROOM_UID"] = dataTemp.Rows[0]["ROOM_UID"];
                    drAdd["INSURANCE_TYPE_DESC"] = dataTemp.Rows[0]["INSURANCE_TYPE_DESC"];
                    drAdd["EXAM_UID"] = "";
                    drAdd["EXAM_NAME"] = "ค่ายา";
                    int rateCT = 1500;
                    int nonrate = 0;
                    drAdd["RATE"] = rateCT.ToString("#,##0");
                    drAdd["CLAIMABLE_AMT"] = rateCT.ToString("#,##0");
                    drAdd["NONCLAIMABLE_AMT"] = nonrate.ToString("#,##0");
                    dataTemp.Rows.Add(drAdd);
                    dataTemp.AcceptChanges();

                }
                //xrptScheduleReport scheduleReport = new xrptScheduleReport(Schedule);
                //scheduleReport.ShowPreviewDialog();

                //vsReport.SetDataSource(dataTemp);
                //double rate = 0.00;
                //double claimable = 0.00;
                //double Nonclaimable = 0.00;
                //for (int i = 0; i < dataTemp.Rows.Count ; i++)
                //{
                //    rate += Convert.ToDouble(dataTemp.Rows[i]["RATE"].ToString());
                //    claimable += Convert.ToDouble(dataTemp.Rows[i]["CLAIMABLE_AMT"].ToString());
                //    Nonclaimable += Convert.ToDouble(dataTemp.Rows[i]["NONCLAIMABLE_AMT"].ToString());
                //}

                //Section sections;
                //Section sections1;
                //TextObject txtUser;
                //TextObject txtSum;

                //sections1 = vsReport.Subreports["SubExam"].ReportDefinition.Sections["ReportFooterSection2"];
                //sections = vsReport.ReportDefinition.Sections["Section5"];
                //txtSum = sections1.ReportObjects["txtSum"] as TextObject;
                //txtUser = sections.ReportObjects["txtUser"] as TextObject;
                //txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;
                //txtSum.Text =  rate.ToString("#,##0")+" บ.";

                //if (dataTemp.Rows.Count == 1)
                //    sections1.ReportObjects["txtSum"].ObjectFormat.EnableSuppress = true;

                ////if (dataTemp.Rows[0]["HL7_FORMAT"].ToString().Trim().Length > 0)
                ////{
                ////    TextObject Text6 = sections.ReportObjects["Text6"] as TextObject;
                ////    Text6.Text += " (" + dataTemp.Rows[0]["HL7_FORMAT"].ToString().Trim() + ")";
                ////}

                //vsReport.PrintOptions.PrinterName = getdefaultprinter();
                //vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                //vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }
        }
        public void ScheduleDirectPrintMultiAIMC(DataTable dataTemp)
        {

            try
            {
                CRFile.rptScheduleReportAIMC vsReport = new CRFile.rptScheduleReportAIMC();
                vsReport.SetDataSource(dataTemp);
                double rate = 0.00;
                for (int i = 0; i < dataTemp.Rows.Count; i++)
                {
                    rate += Convert.ToDouble(dataTemp.Rows[i]["RATE"].ToString());
                }



                Section sections;
                Section sections1;
                TextObject txtUser;
                TextObject txtSum;

                sections1 = vsReport.Subreports["SubExam"].ReportDefinition.Sections["ReportFooterSection2"];
                sections = vsReport.ReportDefinition.Sections["Section5"];
                // Get the ReportObject by name and cast it as a FieldObject.
                // The name can be found in the properties window.

                txtSum = sections1.ReportObjects["txtSum"] as TextObject;
                txtUser = sections.ReportObjects["txtUser"] as TextObject;
                txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;
                txtSum.Text = "รวมสุทธิ : " + rate.ToString("#,##0");

                try
                {
                    if (dataTemp.Rows.Count == 1)
                        sections1.ReportObjects["txtSum"].ObjectFormat.EnableSuppress = true;
                }
                catch { }

                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }


        }
        public void ScheduleDirectPrintMultiER(DataTable dataTemp)
        {
            try
            {
                CRFile.rptScheduleReportER vsReport = new CRFile.rptScheduleReportER();
                ProcessGetRISExam getEx = new ProcessGetRISExam();
                getEx.Invoke();
                DataRow[] drEx = getEx.Result.Tables[0].Select("EXAM_UID='" + dataTemp.Rows[0]["EXAM_UID"].ToString() + "'");
                foreach (DataRow dr in dataTemp.Rows)
                {
                    DateTime _appdate = new DateTime();
                    _appdate = Convert.ToDateTime(dr["APPOINT_DT"]);
                    DateTime preparedate = new DateTime();
                    preparedate = _appdate.AddHours(-8);
                }
                vsReport.SetDataSource(dataTemp);
                double rate = 0.00;
                double claimable = 0.00;
                double Nonclaimable = 0.00;
                for (int i = 0; i < dataTemp.Rows.Count; i++)
                {
                    rate += Convert.ToDouble(dataTemp.Rows[i]["RATE"].ToString());
                    claimable += Convert.ToDouble(dataTemp.Rows[i]["CLAIMABLE_AMT"].ToString());
                    Nonclaimable += Convert.ToDouble(dataTemp.Rows[i]["NONCLAIMABLE_AMT"].ToString());
                }

                Section sections;
                Section sections1;
                TextObject txtUser;
                TextObject txtSum;

                sections1 = vsReport.Subreports["SubExam"].ReportDefinition.Sections["ReportFooterSection2"];
                sections = vsReport.ReportDefinition.Sections["Section5"];

                txtSum = sections1.ReportObjects["txtSum"] as TextObject;
                txtUser = sections.ReportObjects["txtUser"] as TextObject;
                txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;
                txtSum.Text = rate.ToString("#,##0") + " บ.";

                if (dataTemp.Rows.Count == 1)
                    sections1.ReportObjects["txtSum"].ObjectFormat.EnableSuppress = true;

                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }
        }
        public void BiopsyResultDirectPrint(string Accession, int userID
                                        , string RC, string R1, string R2, string R3, string R4, string R5, string R6, string R7, string R8, string R9, string R10, string R11, string R12, string RO
                                        , string LC, string L1, string L2, string L3, string L4, string L5, string L6, string L7, string L8, string L9, string L10, string L11, string L12, string LO)
        {

            try
            {
                CRFile.rptBiospy vsReport = new rptBiospy();
                ProcessGetRptBiopsyResult lkp = new ProcessGetRptBiopsyResult(Accession, userID, RC, R1, R2, R3, R4, R5, R6, R7, R8, R9, R10, R11, R12, RO, LC, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, LO);
                lkp.Invoke();
                DataTable dt = lkp.Result.Tables[0];

                vsReport.SetDataSource(dt);

                //Section sections;
                //TextObject txtUser;


                //sections = vsReport.ReportDefinition.Sections["Section5"];
                //// Get the ReportObject by name and cast it as a FieldObject.
                //// The name can be found in the properties window.

                //txtUser = sections.ReportObjects["txtUser"] as TextObject;
                //txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;

                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }


        }

        public void BiopsyLocalizeResultDirectPrint(string Accession, int userID
                                , string RC, string R1, string R2, string R3, string R4, string R5, string R6, string R7, string R8, string R9, string R10, string R11, string R12, string RO
                                , string LC, string L1, string L2, string L3, string L4, string L5, string L6, string L7, string L8, string L9, string L10, string L11, string L12, string LO)
        {

            try
            {
                CRFile.rptBiopsyLoca vsReport = new rptBiopsyLoca();
                ProcessGetRptBiopsyResult lkp = new ProcessGetRptBiopsyResult(Accession, userID, RC, R1, R2, R3, R4, R5, R6, R7, R8, R9, R10, R11, R12, RO, LC, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, LO);
                lkp.Invoke();
                DataTable dt = lkp.Result.Tables[0];

                vsReport.SetDataSource(dt);

                //Section sections;
                //TextObject txtUser;


                //sections = vsReport.ReportDefinition.Sections["Section5"];
                //// Get the ReportObject by name and cast it as a FieldObject.
                //// The name can be found in the properties window.

                //txtUser = sections.ReportObjects["txtUser"] as TextObject;
                //txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;

                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }


        }

        public void OrderEntryDirectPrint(int OrderID, int UserID) {
            OrderEntryDirectPrint(OrderID, UserID, 1);
        }
        public void OrderEntryDirectPrint(int OrderID, int UserID,int numberOfCopy)
        {
            try
            {
                xrptOrderReport orderReport = new xrptOrderReport(OrderID);
                
                if (!string.IsNullOrEmpty(PrinterSelected.PrinterName))
                    orderReport.PrinterName = PrinterSelected.PrinterName;

                numberOfCopy = (numberOfCopy < 1) ? 1 : numberOfCopy;

                for (int _i = 0; _i < numberOfCopy; _i++)
                    orderReport.Print();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void OrderEntryDirectPrintAIMC(int OrderID, int UserID)
        {
            OrderEntryDirectPrintAIMC(OrderID, UserID, getdefaultprinter());
        }
        public void OrderEntryDirectPrintAIMC(int OrderID, int UserID,string printer_name)
        {
            try
            {
                xrptOrderReportAIMC orderReport = new xrptOrderReportAIMC(OrderID);

                if (!string.IsNullOrEmpty(PrinterSelected.PrinterName))
                    orderReport.PrinterName = printer_name;
                    orderReport.Print();


                //CRFile.rptOrderReportAIMC vReport = new CRFile.rptOrderReportAIMC();
                //ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                //DataTable dtt = process.GetPrintData(OrderID, UserID);
                //vReport.SetDataSource(dtt);
                //vReport.PrintOptions.PrinterName = printer_name;
                //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                //vReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void OrderEntryDirectPrintAIMC(int OrderID, int UserID, int numberOfCopy)
        {
            try
            {
                xrptOrderReportAIMC orderReport = new xrptOrderReportAIMC(OrderID);

                if (!string.IsNullOrEmpty(PrinterSelected.PrinterName))
                    orderReport.PrinterName = PrinterSelected.PrinterName;

                numberOfCopy = (numberOfCopy < 1) ? 1 : numberOfCopy;

                for (int _i = 0; _i < numberOfCopy; _i++)
                    orderReport.Print();


                //CRFile.rptOrderReportAIMC vReport = new CRFile.rptOrderReportAIMC();
                //ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                //DataTable dtt = process.GetPrintData(OrderID, UserID);
                //vReport.SetDataSource(dtt);
                //vReport.PrintOptions.PrinterName = getdefaultprinter();
                //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                //vReport.PrintToPrinter(numberOfCopy, true, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void PrintSticker(string HN, int Exam_ID,bool PrintExam,int numberOfCopy) {
            try
            {
                xrptOrderReportSticker orderReport = new xrptOrderReportSticker(HN);
                if (!string.IsNullOrEmpty(PrinterSelected.PrinterName))
                    orderReport.PrinterName = PrinterSelected.PrinterName;

                numberOfCopy = (numberOfCopy < 1) ? 1 : numberOfCopy;

                for (int _i = 0; _i < numberOfCopy; _i++)
                    orderReport.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void PrintDuration(DateTime dtStart,DateTime dtEnd) {
            try
            {
                dtStart = new DateTime(dtStart.Year, dtStart.Month, dtStart.Day,0, 0, 0);
                dtEnd = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 23, 59, 59);

                CRFile.rptDuration vReport = new CRFile.rptDuration();
                ProcessGetRisvPatienDate process = new ProcessGetRisvPatienDate();
                DataTable dtt = process.GetReportDuration(dtStart, dtEnd);
                foreach (DataRow dr in dtt.Rows)
                {

                    if (dr["ORDER_ENTERED_ON"].ToString() != string.Empty)
                    {
                        DateTime dtOrder = Convert.ToDateTime(dr["ORDER_ENTERED_ON"]);
                        DateTime dtTemp = DateTime.MinValue;
                        TimeSpan ts = DateTime.Now.TimeOfDay;
                        string day, hour, minute;
                        dr["WaitForCapture"] = "00:00:00";
                        dr["WaitForQA"] = "00:00:00";
                        dr["WaitForPrelim"] = "00:00:00";
                        dr["WaitForFinalize"] = "00:00:00";
                        if (dr["IMAGE_CAPTURED_ON"].ToString() != string.Empty)
                        {
                            dtTemp = Convert.ToDateTime(dr["IMAGE_CAPTURED_ON"]);
                            ts = dtTemp.Subtract(dtOrder);
                            day = ts.Days == 0 ? "00" : ts.Days.ToString();
                            day = day.Length == 1 ? "0" + day + ":" : day + ":";
                            hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                            hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                            minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                            minute = minute.Length == 1 ? "0" + minute : minute;
                            dr["WaitForCapture"] = day + hour + minute;
                        }
                        if (dr["QA_ON"].ToString() != string.Empty)
                        {
                            dtTemp = Convert.ToDateTime(dr["QA_ON"]);
                            ts = dtTemp.Subtract(dtOrder);
                            day = ts.Days == 0 ? "00" : ts.Days.ToString();
                            day = day.Length == 1 ? "0" + day + ":" : day + ":";
                            hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                            hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                            minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                            minute = minute.Length == 1 ? "0" + minute : minute;
                            dr["WaitForQA"] = day + hour + minute;

                        }
                        if (dr["PRELIM_ON"].ToString() != string.Empty)
                        {
                            dtTemp = Convert.ToDateTime(dr["PRELIM_ON"]);
                            ts = dtTemp.Subtract(dtOrder);
                            day = ts.Days == 0 ? "00" : ts.Days.ToString();
                            day = day.Length == 1 ? "0" + day + ":" : day + ":";
                            hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                            hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                            minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                            minute = minute.Length == 1 ? "0" + minute : minute;
                            dr["WaitForPrelim"] = day + hour + minute;

                        }
                        if (dr["FINALIZED_ON"].ToString() != string.Empty)
                        {
                            dtTemp = Convert.ToDateTime(dr["FINALIZED_ON"]);
                            ts = dtTemp.Subtract(dtOrder);
                            day = ts.Days == 0 ? "00" : ts.Days.ToString();
                            day = day.Length == 1 ? "0" + day + ":" : day + ":";
                            hour = ts.Hours == 0 ? "00" : ts.Hours.ToString();
                            hour = hour.Length == 1 ? "0" + hour + ":" : hour + ":";
                            minute = ts.Minutes == 0 ? "00" : ts.Minutes.ToString();
                            minute = minute.Length == 1 ? "0" + minute : minute;
                            dr["WaitForFinalize"] = day + hour + minute;

                        }
                    }
                }
                vReport.SetDataSource(dtt);
                vReport.PrintOptions.PrinterName = getdefaultprinter();
                vReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        
        }
        private string getdefaultprinter()
        {
            string printername;
            PrintDocument getprintername = new PrintDocument();
            printername = getprintername.PrinterSettings.PrinterName;
            return printername;
        }
        public void PrintOpNote(DataTable dt)
        {
            try
            {
                CRFile.rptOpNoteTemplate vReport = new CRFile.rptOpNoteTemplate();
                vReport.SetDataSource(dt);
                vReport.PrintOptions.PrinterName = getdefaultprinter();
                vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                vReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Message Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void PR_Report(int PR_ID)
        {
            try
            {
                CRFile.rptPRreport enReport = new rptPRreport();

                Envision.BusinessLogic.LookUpSelect look = new Envision.BusinessLogic.LookUpSelect();
                enReport.SetDataSource(look.PR_Report(PR_ID).Tables[0]);
                enReport.PrintOptions.PrinterName = getdefaultprinter();
                enReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                enReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {

                MessageBox.Show(Err.ToString());
            }
        }
        public void PO_Report(int PO_ID)
        {
            try
            {
                CRFile.rptPOreport enReport = new rptPOreport();

                Envision.BusinessLogic.LookUpSelect look = new Envision.BusinessLogic.LookUpSelect();
                enReport.SetDataSource(look.PO_Report(PO_ID).Tables[0]);
                enReport.PrintOptions.PrinterName = getdefaultprinter();
                enReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                enReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {

                MessageBox.Show(Err.ToString());
            }
        }

        public void ScheduleDirectPrintMultiIntervention(DataTable dataTemp)
        {
            try
            {
                CRFile.rptScheduleReportIntervention vsReport = new CRFile.rptScheduleReportIntervention();
                ProcessGetRISExam getEx = new ProcessGetRISExam();
                getEx.Invoke();
                DataRow[] drEx = getEx.Result.Tables[0].Select("EXAM_UID='" + dataTemp.Rows[0]["EXAM_UID"].ToString() + "'");
                foreach (DataRow dr in dataTemp.Rows)
                {
                    DateTime _appdate = new DateTime();
                    _appdate = Convert.ToDateTime(dr["APPOINT_DT"]);
                    DateTime preparedate = new DateTime();
                    preparedate = _appdate.AddHours(-8);

                }

                vsReport.SetDataSource(dataTemp);
                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }
        }
        public void ScheduleDirectPrintMultiSDMC(DataTable dataTemp)
        {
            try
            {
                CRFile.rptScheduleReportSDMC vsReport = new CRFile.rptScheduleReportSDMC();
                vsReport.SetDataSource(dataTemp);
                double rate = 0.00;
                for (int i = 0; i < dataTemp.Rows.Count; i++)
                {
                    rate += Convert.ToDouble(dataTemp.Rows[i]["RATE"].ToString());
                }

                Section sections;
                Section sections1;
                TextObject txtUser;
                TextObject txtSum;

                sections1 = vsReport.Subreports["SubExam"].ReportDefinition.Sections["ReportFooterSection2"];
                sections = vsReport.ReportDefinition.Sections["Section5"];
                // Get the ReportObject by name and cast it as a FieldObject.
                // The name can be found in the properties window.

                txtSum = sections1.ReportObjects["txtSum"] as TextObject;
                txtUser = sections.ReportObjects["txtUser"] as TextObject;
                txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;
                txtSum.Text = "รวมสุทธิ : " + rate.ToString("#,##0");

                try
                {
                    if (dataTemp.Rows.Count == 1)
                        sections1.ReportObjects["txtSum"].ObjectFormat.EnableSuppress = true;
                }
                catch { }

                vsReport.PrintOptions.PrinterName = getdefaultprinter();
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                vsReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }
        }

        #endregion directprint

    }
}
