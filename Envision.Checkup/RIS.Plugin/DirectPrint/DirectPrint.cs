using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Printing;
using RIS.BusinessLogic;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using RIS.Common.Common;
using RIS.Common;
using RIS.Plugin.CRFile;
using RIS.Plugin.XtraFile.xtraReports;

namespace RIS.Plugin.DirectPrint
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

        public void ResultEntryDirectPrint(string _accno,int _authlevel)
        {

            try
            {
                rptResultEntry vReport = new rptResultEntry();
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
                //PaperSize = getPaperSize("A5_Rotated");
                PaperSize = getPaperSize("A5 Rotated");

                if (PaperSize >= 0)
                {
                    vReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)PaperSize;
                }
                else
                {
                    //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                    vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    vReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
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
                rptResultEntry vReport = new rptResultEntry();
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
                //PaperSize = getPaperSize("A5_Rotated");
                PaperSize = getPaperSize("A4");

                if (PaperSize >= 0)
                {
                    vReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)PaperSize;
                }
                else
                {
                    //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                    vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    vReport.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                }
                //vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                vReport.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }

        }
        public int getPaperSize(string sizeName)
        {

            //int i;
            //int raw = -1;
            //System.Drawing.Printing.PaperSize PSize = new System.Drawing.Printing.PaperSize();

            //System.Drawing.Printing.PrintDocument PrintDoc = new System.Drawing.Printing.PrintDocument();

            //for (i = 0; i < PrintDoc.PrinterSettings.PaperSizes.Count; i++)
            //{

            //    if (PrintDoc.PrinterSettings.PaperSizes[i].PaperName == sizeName)
            //    {

            //        PSize = PrintDoc.PrinterSettings.PaperSizes[i];
            //        raw = (int)PrintDoc.PrinterSettings.PaperSizes[i].RawKind;

            //    }

            //}

            //return raw;

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
        public void ScheduleDirectPrint(string _hn, DateTime _appdate, int _modality,int _schedule)
        {

            try
            {
                rptScheduleReport vsReport = new CRFile.rptScheduleReport();

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
                txtUser.Text = new GBLEnvVariable().FirstName +" "+ new GBLEnvVariable().LastName;
      
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
                rptBiopsyLoca vsReport = new rptBiopsyLoca();
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



        public void OrderEntryDirectPrint(int OrderID, int UserID, int numberOfCopy)
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
        public void PrintSticker(string HN, int Exam_ID,bool PrintExam,int numberOfCopy) {
            try
            {
                if (PrintExam)
                {
                    CRFile.rptStickerExam vReport = new CRFile.rptStickerExam();
                    ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                    DataTable dtt = process.GetPrintStickerData(HN, Exam_ID);
                    vReport.SetDataSource(dtt);
                    vReport.PrintOptions.PrinterName = getdefaultprinter();
                    vReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)getPaperSize("Sticker");
                    vReport.PrintToPrinter(numberOfCopy, true, 0, 0);
                }
                else {
                    CRFile.rptSticker vReport = new CRFile.rptSticker();
                    ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                    DataTable dtt = process.GetPrintStickerData(HN, 0);
                    vReport.SetDataSource(dtt);
                    vReport.PrintOptions.PrinterName = getdefaultprinter();
                    vReport.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)getPaperSize("Sticker");
                    vReport.PrintToPrinter(numberOfCopy, true, 0, 0);
                }
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
        #endregion directprint

    }
}
