using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



using Envision.BusinessLogic;
using Envision.Common;
using Envision.BusinessLogic.ProcessRead;
using System.Windows.Forms;

namespace Envision.Plugin.ReportManager
{
    public class ReportMangager
    {
        //create dbconnection class instance
        //ProcessGetGBLLookup lkp; 

        string _whereclose;
        string _mrNumber;
        string _firstName;
        string _lastName;
        string _toDate;
        string _fromDate;
        string _toDate2;
        string _fromDate2;
        string _groupBy;
        string _room;
        string _examType;
        string _jobDesc;
        string _formulaFromDate;
        string _formulaToDate;
        string _formulaFromDate2;
        string _formulaToDate2;
        string _formulaGroup;
        string _formulaClinic;
        //string OrganizationName = "JF ADVANCED MED. CO. LTD.";

        /// <summary>
        /// set or get Properties all Report where close parameter
        /// </summary>
        public string WhereClose
        {
            get { return _whereclose; }
            set { _whereclose = value; }
        }

        public string JobDesc
        {
            get { return _jobDesc; }
            set { _jobDesc = value; }
        }

        public string formulaFromDate
        {
            get { return _formulaFromDate; }
            set { _formulaFromDate = value; }
        }

        public string formulaToDate
        {
            get { return _formulaToDate; }
            set { _formulaToDate = value; }
        }

        public string formulaFromDate2
        {
            get { return _formulaFromDate2; }
            set { _formulaFromDate2 = value; }
        }

        public string formulaToDate2
        {
            get { return _formulaToDate2; }
            set { _formulaToDate2 = value; }
        }

        public string formulaGroup
        {
            get { return _formulaGroup; }
            set { _formulaGroup = value; }
        }

        public string formulaClinic
        {
            get { return _formulaClinic; }
            set { _formulaClinic = value; }
        }

        public string mrNumber
        {
            get { return _mrNumber; }
            set { _mrNumber = value; }
        }

        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string fromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        public string toDate
        {
            get { return _toDate; }
            set { _toDate = value; }
        }

        public string fromDate2
        {
            get { return _fromDate2; }
            set { _fromDate2 = value; }
        }

        public string toDate2
        {
            get { return _toDate2; }
            set { _toDate2 = value; }
        }

        public string groupBy
        {
            get { return _groupBy; }
            set { _groupBy = value; }
        }

        public string Room
        {
            get { return _room; }
            set { _room = value; }
        }

        public string examType
        {
            get { return _examType; }
            set { _examType = value; }
        }

        //Function for report
        public ReportDocument rptExamResult
        {
            get
            {
                try
                {
                   
                    CRFile.rptResultEntry vReport = new CRFile.rptResultEntry();
                    Section section;

                    FieldObject fieldObject;
                    FieldFormat fieldFormat;

                    // Get the Section object by name.
                    section = vReport.ReportDefinition.Sections["Section2"];
                    // Get the ReportObject by name and cast it as a FieldObject.
                    // The name can be found in the properties window.
                    fieldObject = section.ReportObjects["ACCESSIONNO1"] as FieldObject;

                    // Check if the FieldObject is null.
                    if (fieldObject != null)
                    {
                        System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();

                        privateFonts.AddFontFile("FRE3OF9X.ttf");
                        System.Drawing.Font font = new Font(privateFonts.Families[0], 14, FontStyle.Regular);
                        //this.label1.Font = font;

                        //Get the FieldFormat object.
                        fieldFormat = fieldObject.FieldFormat;

                        fieldObject.ApplyFont(font);
                        //fieldObject.Color = Color.Red;




                    }


                    //Font fnt = new Font("Courier", 10);
                    //t.Text = "surajit";

                    //dc.Open();
                    //string selQry = @"";
                    ProcessGetGBLLookup lkp = new ProcessGetGBLLookup("Select * from ris_examresult" + _whereclose);
                    lkp.Invoke();
                    DataTable dt = lkp.ResultSet.Tables[0];
                    vReport.SetDataSource(dt);
                    //dc.Close();
                    return vReport;
                }
                catch (Exception Err)
                {
                    throw new Exception(Err.Message);
                }

            }
        }
        public ReportDocument rptOrderReport(int OrderID, int UserID) {
            CRFile.rptOrderReport vReport = new Envision.Plugin.CRFile.rptOrderReport();
            try
            {

                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtt = process.GetPrintData(OrderID, UserID);
                vReport.SetDataSource(dtt);
            }
            catch (Exception ex) { 
            
            }
            return vReport;
        }
        public ReportDocument rptOrderReportAIMC(int OrderID, int UserID)
        {
            CRFile.rptOrderReportAIMC vReport = new Envision.Plugin.CRFile.rptOrderReportAIMC();
            try
            {

                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtt = process.GetPrintData(OrderID, UserID);
                process.Invoke();
                vReport.SetDataSource(dtt);
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }

        public ReportDocument rptSticker(string HN)
        {
            CRFile.rptSticker vReport = new Envision.Plugin.CRFile.rptSticker();
            try
            {

                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtt = process.GetPrintStickerData(HN, 0);
                process.Invoke();
                vReport.SetDataSource(dtt);
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }
        public ReportDocument rptStickerExam(string HN, int Exam_ID)
        {
            CRFile.rptStickerExam vReport = new Envision.Plugin.CRFile.rptStickerExam();
            try
            {

                ProcessGetRISOrder process = new ProcessGetRISOrder(0, 0);
                DataTable dtt = process.GetPrintStickerData(HN, Exam_ID);
                process.Invoke();
                vReport.SetDataSource(dtt);
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }

        public ReportDocument rptDuration(DateTime DtStart, DateTime DtEnd)
        {
            CRFile.rptDuration vReport = new Envision.Plugin.CRFile.rptDuration();
            try
            {
                DtStart = new DateTime(DtStart.Year, DtStart.Month, DtStart.Day, 0, 0, 0);
                DtEnd = new DateTime(DtEnd.Year, DtEnd.Month, DtEnd.Day, 23, 59, 59);
                ProcessGetRisvPatienDate process = new ProcessGetRisvPatienDate();
                DataTable dtt = process.GetReportDuration(DtStart, DtEnd);
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
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }

        public ReportDocument rptScheduleReport(DataTable dtSCH)
        {
            CRFile.rptScheduleReport vsReport = new CRFile.rptScheduleReport();
            try
            {
                DataTable dts = dtSCH.Copy();
                DateTime _appdate = new DateTime();
                DateTime preparedate = new DateTime();
                _appdate = Convert.ToDateTime(dts.Rows[0]["APPOINT_DT"]);
                preparedate = _appdate.AddHours(-8);
                ProcessGetRISExam getEx = new ProcessGetRISExam();
                getEx.Invoke();
                DataRow[] drEx = getEx.Result.Tables[0].Select("EXAM_UID='"+dts.Rows[0]["EXAM_UID"].ToString()+"'");

                foreach (DataRow dr in dts.Rows)
                {
                    //if (_appdate.Hour < 12)
                    //string prepare = preparedate.Day.ToString();
                    //prepare += " ";
                    //prepare += preparedate.ToString("MMMM");
                    //prepare += " ";
                    //prepare += Convert.ToString(preparedate.Year+543);
                    //prepare += " ";
                    //prepare += preparedate.ToString("HH:MM");
                    //prepare += " น.";
                    //dr["INS_TEXT"] = "วิธีการเตรียมตัวก่อนตรวจ \r\n\t\r\n\t [ ] งดน้ำและอาหาร ก่อนวันและเวลา " + prepare + "\r\n\t\r\n\t [ ] ไม่งดน้ำและอาหาร \r\n\t\r\n\t" + dr["INS_TEXT"].ToString().Trim() + "\r\n\t\r\n\t - หากท่านต้องการเลื่อนนัดกรุณาแจ้งล่วงหน้า 3 วันทำการ ได้ระหว่างเวลา 14:00-15:30 น. โทร. 022564593\r\n\t\r\n\t - หากท่านไม่สามารถมาตรวจตามนัดกรุณามาพบแพทย์ใหม่\r\n\t\r\n\t";
                    //if (drEx.Length > 0)
                    //{
                    //    double nonclaim = Convert.ToDouble(dr["NONCLAIMABLE_AMT"]);
                    //    double claim = Convert.ToDouble(dr["CLAIMABLE_AMT"]);
                    //    if (Convert.ToInt32(drEx[0]["EXAM_TYPE"]) == 1)//MR
                    //    {
                    //        double rates = Convert.ToDouble(dr["RATE"]) + 2500.00;
                    //        dr["INS_TEXT"] += "- ค่ายา 2,500 บาท ค่าตรวจ (เบิกได้ " + claim.ToString("#,##0") + " บาท เบิกไม่ได้ " + nonclaim.ToString("#,##0") + " บาท) รวม " + rates.ToString("#,##0") + " บาท";
                    //    }
                    //    else if (Convert.ToInt32(drEx[0]["EXAM_TYPE"]) == 2)//CT
                    //    {
                    //        double rates = Convert.ToDouble(dr["RATE"]) + 1500.00;
                    //        dr["INS_TEXT"] += "- ค่ายา 1,500 บาท ค่าตรวจ (เบิกได้ " + claim.ToString("#,##0") + " บาท เบิกไม่ได้ " + nonclaim.ToString("#,##0") + " บาท) รวม " + rates.ToString("#,##0") + " บาท";
                    //    }
                    //}
                }
                if (Convert.ToInt32(drEx[0]["EXAM_TYPE"]) == 1)//MR
                {
                    DataRow drAdd = dts.NewRow();
                    drAdd["ORG_NAME"] = dts.Rows[0]["ORG_NAME"];
                    drAdd["HN"] = dts.Rows[0]["HN"];
                    drAdd["TITLE"] = dts.Rows[0]["TITLE"];
                    drAdd["FNAME"] = dts.Rows[0]["FNAME"];
                    drAdd["MNAME"] = dts.Rows[0]["MNAME"];
                    drAdd["LNAME"] = dts.Rows[0]["LNAME"];
                    drAdd["TITLE_ENG"] = dts.Rows[0]["TITLE_ENG"];
                    drAdd["FNAME_ENG"] = dts.Rows[0]["FNAME_ENG"];
                    drAdd["MNAME_ENG"] = dts.Rows[0]["MNAME_ENG"];
                    drAdd["LNAME_ENG"] = dts.Rows[0]["LNAME_ENG"];
                    drAdd["DOB"] = dts.Rows[0]["DOB"];
                    drAdd["APPOINT_DT"] = dts.Rows[0]["APPOINT_DT"];
                    drAdd["CLINIC_TYPE_TEXT"] = dts.Rows[0]["CLINIC_TYPE_TEXT"];
                    drAdd["MODALITY_NAME"] = dts.Rows[0]["MODALITY_NAME"];
                    drAdd["CREATED_BY"] = dts.Rows[0]["CREATED_BY"];
                    drAdd["CREATED_ON"] = dts.Rows[0]["CREATED_ON"];
                    drAdd["ORG_IMG"] = dts.Rows[0]["ORG_IMG"];
                    drAdd["ORG_ADDR3"] = dts.Rows[0]["ORG_ADDR3"];
                    drAdd["ORG_ADDR4"] = dts.Rows[0]["ORG_ADDR4"];
                    drAdd["MODALITY_ID"] = dts.Rows[0]["MODALITY_ID"];
                    drAdd["VENDOR_H2"] = dts.Rows[0]["VENDOR_H2"];
                    drAdd["INS_TEXT"] = dts.Rows[0]["INS_TEXT"];
                    drAdd["EXAM_TYPE_INS"] = dts.Rows[0]["EXAM_TYPE_INS"];
                    drAdd["HR_UNIT_INS"] = dts.Rows[0]["HR_UNIT_INS"];
                    drAdd["UNIT_NAME"] = dts.Rows[0]["UNIT_NAME"];
                    drAdd["UNIT_TITLE"] = dts.Rows[0]["UNIT_TITLE"];
                    drAdd["AGE"] = dts.Rows[0]["AGE"];
                    drAdd["GENDER"] = dts.Rows[0]["GENDER"];
                    drAdd["ROOM_UID"] = dts.Rows[0]["ROOM_UID"];
                    drAdd["INSURANCE_TYPE_DESC"] = dts.Rows[0]["INSURANCE_TYPE_DESC"];
                    drAdd["EXAM_UID"] = "";
                    drAdd["EXAM_NAME"] = "ค่ายา";
                    int rateMr = 1500;
                    int nonrate = 0;
                    drAdd["RATE"] = rateMr.ToString("#,##0");
                    drAdd["CLAIMABLE_AMT"] = rateMr.ToString("#,##0");
                    drAdd["NONCLAIMABLE_AMT"] = nonrate.ToString("#,##0");
                    dts.Rows.Add(drAdd);
                    dts.AcceptChanges();
                }
                else if (Convert.ToInt32(drEx[0]["EXAM_TYPE"]) == 2)//CT
                {
                    DataRow drAdd = dts.NewRow();
                    drAdd["ORG_NAME"] = dts.Rows[0]["ORG_NAME"];
                    drAdd["HN"] = dts.Rows[0]["HN"];
                    drAdd["TITLE"] = dts.Rows[0]["TITLE"];
                    drAdd["FNAME"] = dts.Rows[0]["FNAME"];
                    drAdd["MNAME"] = dts.Rows[0]["MNAME"];
                    drAdd["LNAME"] = dts.Rows[0]["LNAME"];
                    drAdd["TITLE_ENG"] = dts.Rows[0]["TITLE_ENG"];
                    drAdd["FNAME_ENG"] = dts.Rows[0]["FNAME_ENG"];
                    drAdd["MNAME_ENG"] = dts.Rows[0]["MNAME_ENG"];
                    drAdd["LNAME_ENG"] = dts.Rows[0]["LNAME_ENG"];
                    drAdd["DOB"] = dts.Rows[0]["DOB"];
                    drAdd["APPOINT_DT"] = dts.Rows[0]["APPOINT_DT"];
                    drAdd["CLINIC_TYPE_TEXT"] = dts.Rows[0]["CLINIC_TYPE_TEXT"];
                    drAdd["MODALITY_NAME"] = dts.Rows[0]["MODALITY_NAME"];
                    drAdd["CREATED_BY"] = dts.Rows[0]["CREATED_BY"];
                    drAdd["CREATED_ON"] = dts.Rows[0]["CREATED_ON"];
                    drAdd["ORG_IMG"] = dts.Rows[0]["ORG_IMG"];
                    drAdd["ORG_ADDR3"] = dts.Rows[0]["ORG_ADDR3"];
                    drAdd["ORG_ADDR4"] = dts.Rows[0]["ORG_ADDR4"];
                    drAdd["MODALITY_ID"] = dts.Rows[0]["MODALITY_ID"];
                    drAdd["VENDOR_H2"] = dts.Rows[0]["VENDOR_H2"];
                    drAdd["INS_TEXT"] = dts.Rows[0]["INS_TEXT"];
                    drAdd["EXAM_TYPE_INS"] = dts.Rows[0]["EXAM_TYPE_INS"];
                    drAdd["HR_UNIT_INS"] = dts.Rows[0]["HR_UNIT_INS"];
                    drAdd["UNIT_NAME"] = dts.Rows[0]["UNIT_NAME"];
                    drAdd["UNIT_TITLE"] = dts.Rows[0]["UNIT_TITLE"];
                    drAdd["AGE"] = dts.Rows[0]["AGE"];
                    drAdd["GENDER"] = dts.Rows[0]["GENDER"];
                    drAdd["ROOM_UID"] = dts.Rows[0]["ROOM_UID"];
                    drAdd["INSURANCE_TYPE_DESC"] = dts.Rows[0]["INSURANCE_TYPE_DESC"];
                    drAdd["EXAM_UID"] = "";
                    drAdd["EXAM_NAME"] = "ค่ายา";
                    int rateCT = 1500;
                    int nonrate = 0;
                    drAdd["RATE"] = rateCT.ToString("#,##0");
                    drAdd["CLAIMABLE_AMT"] = rateCT.ToString("#,##0");
                    drAdd["NONCLAIMABLE_AMT"] = nonrate.ToString("#,##0");
                    dts.Rows.Add(drAdd);
                    dts.AcceptChanges();

                }
                vsReport.SetDataSource(dts);

                double rate = 0.00;
                double claimable = 0.00;
                double Nonclaimable = 0.00;
                for (int i = 0; i < dts.Rows.Count; i++)
                {
                    rate += Convert.ToDouble(dts.Rows[i]["RATE"].ToString());
                    claimable += Convert.ToDouble(dts.Rows[i]["CLAIMABLE_AMT"].ToString());
                    Nonclaimable += Convert.ToDouble(dts.Rows[i]["NONCLAIMABLE_AMT"].ToString());
                }


                Section sections;
                Section sections1;
                TextObject txtUser;
                TextObject txtSum;
                TextObject txtClaimable;
                TextObject txtNonClaimable;


                sections1 = vsReport.Subreports["SubExam"].ReportDefinition.Sections["ReportFooterSection2"];
                sections = vsReport.ReportDefinition.Sections["Section5"];
                // Get the ReportObject by name and cast it as a FieldObject.
                // The name can be found in the properties window.

                txtClaimable = sections1.ReportObjects["txtClaimable"] as TextObject;
                txtNonClaimable = sections1.ReportObjects["txtNonClaimable"] as TextObject;
                txtSum = sections1.ReportObjects["txtSum"] as TextObject;
                txtUser = sections.ReportObjects["txtUser"] as TextObject;
                txtUser.Text = new GBLEnvVariable().FirstName + " " + new GBLEnvVariable().LastName;
                txtSum.Text =  rate.ToString("#,##0")+" บ.";
                try
                {
                    if (dtSCH.Rows.Count == 1)
                        sections1.ReportObjects["txtSum"].ObjectFormat.EnableSuppress = true;
                }
                catch { }
                txtClaimable.Text = claimable.ToString("#,##0") + " บ.";
                txtNonClaimable.Text = Nonclaimable.ToString("#,##0") + " บ.";
            }
            catch (Exception rrr)
            {
            }
            return vsReport;
        }
        public ReportDocument rptScheduleReportAIMC(string _hn, DateTime _appdate, int _modality, int _schedule)
        {
            CRFile.rptScheduleReportAIMC vsReport = new CRFile.rptScheduleReportAIMC();
            try
            {


                ReportParameters spara = new  ReportParameters();
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
            }
            catch (Exception rrr)
            {
            }
            return vsReport;
        }
        public ReportDocument rptOrderReportAll(DateTime dStart, DateTime dEnd, int Unit, int ModalityID, bool AIMC)
        {

            if (AIMC)
            {
                CRFile.rptOrderAllAIMC vReport = new Envision.Plugin.CRFile.rptOrderAllAIMC();
                try
                {
                    ProcessGetRptOrderReport process = new ProcessGetRptOrderReport();
                    process.ReportParameters.FromDate = dStart;
                    process.ReportParameters.ToDate = dEnd;
                    process.ReportParameters.ModalityId = ModalityID;
                    process.ReportParameters.Unit_ID = Unit;
                    process.Invoke();
                    DataTable dtt = process.Result.Tables[0];


                    Section section;
                    TextObject txtUser;
                    section = vReport.ReportDefinition.Sections["Section5"];

                    txtUser = section.ReportObjects["txtUser"] as TextObject;
                    GBLEnvVariable env = new GBLEnvVariable();
                    txtUser.Text = env.UserName.ToString();

                    vReport.SetDataSource(dtt);
                    vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                }
                catch (Exception ex)
                {

                }
                return vReport;
            }
            else
            {
                CRFile.rptOrderAll vReport = new Envision.Plugin.CRFile.rptOrderAll();
                try
                {
                    ProcessGetRptOrderReport process = new ProcessGetRptOrderReport();
                    process.ReportParameters.FromDate = dStart;
                    process.ReportParameters.ToDate = dEnd;
                    process.ReportParameters.ModalityId = ModalityID;
                    process.ReportParameters.Unit_ID = Unit;
                    process.Invoke();
                    DataTable dtt = process.Result.Tables[0];


                    Section section;
                    TextObject txtUser;
                    section = vReport.ReportDefinition.Sections["Section5"];

                    txtUser = section.ReportObjects["txtUser"] as TextObject;
                    GBLEnvVariable env = new GBLEnvVariable();
                    txtUser.Text = env.UserName.ToString();

                    vReport.SetDataSource(dtt);
                    vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                }
                catch (Exception ex)
                {

                }
                return vReport;
            }




        }

        //yo start add
        public ReportDocument rptModalityExam(int ModalityID, int UserID)
        {
            CRFile.rptModalityExam vReport = new Envision.Plugin.CRFile.rptModalityExam();
            try
            {

                ProcessGetRISModalityexam process = new ProcessGetRISModalityexam(ModalityID);
                DataTable dtt = process.rptModalityexam(UserID).Tables[0];
                process.Invoke();
                vReport.SetDataSource(dtt);
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }
        public ReportDocument rptQAWorks(DateTime FromDate, DateTime ToDate, int UserID)
        {
            CRFile.rptQAWorks vReport = new Envision.Plugin.CRFile.rptQAWorks();
            try
            {

                ProcessGetRISQAWorks process = new ProcessGetRISQAWorks();
                DataTable dtt = process.rptQAWorks(FromDate, ToDate, UserID).Tables[0];
                process.Invoke();
                vReport.SetDataSource(dtt);
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }
        public ReportDocument rptAppoint(DateTime dStart, DateTime dEnd, int UserID, int ModalityID,int SessionID)
        {
            CRFile.rptAppoint vReport = new Envision.Plugin.CRFile.rptAppoint();
            try
            {

                ProcessScheduleReport process = new ProcessScheduleReport(dStart, dEnd,SessionID);
                process.ReportParameters = new ReportParameters();
                process.ReportParameters.ModalityId = ModalityID;
                process.ReportParameters.SpType = UserID;
                process.Invoke();
                DataTable dtt = process.ResultSet.Tables[0];
                if (dtt.Rows.Count == 0)
                {
                    ProcessGetGBLEnv gblenv = new ProcessGetGBLEnv();
                    gblenv.Invoke();
                    DataTable dtEnv = gblenv.ResultSet.Tables[0];
                    dtt.AcceptChanges();
                    DataRow dr = dtt.NewRow();
                    dr["ORG_UID"] = dtEnv.Rows[0]["ORG_UID"];
                    dr["ORG_NAME"] = dtEnv.Rows[0]["ORG_NAME"];
                    dr["ORG_ADDR3"] = dtEnv.Rows[0]["ORG_ADDR3"];
                    dr["ORG_ADDR4"] = dtEnv.Rows[0]["ORG_ADDR4"];
                    dr["ORG_IMG"] = dtEnv.Rows[0]["ORG_IMG"];
                    dr["VENDOR_H1"] = dtEnv.Rows[0]["VENDOR_H1"];
                    dr["VENDOR_H2"] = dtEnv.Rows[0]["VENDOR_H2"];

                    dtt.Rows.Add(dr);
                    dtt.AcceptChanges();
                    
                }
                vReport.SetDataSource(dtt);
                vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                vReport.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }
        public ReportDocument rptAppointAIMC(DateTime dStart, DateTime dEnd, int UserID, int ModalityID, int SessionID)
        {
            CRFile.rptAppointAIMC vReport = new Envision.Plugin.CRFile.rptAppointAIMC();
            try
            {

                ProcessScheduleReport process = new ProcessScheduleReport(dStart, dEnd, SessionID);
                process.ReportParameters = new Envision.Common.ReportParameters();
                process.ReportParameters.ModalityId = ModalityID;
                process.ReportParameters.SpType = UserID;
                process.Invoke();
                DataTable dtt = process.ResultSet.Tables[0];

                vReport.SetDataSource(dtt);
                vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }
        public ReportDocument rptWorkload(DateTime dStart, DateTime dEnd, int UserID, string JobType)
        {
            CRFile.rptWorkLoad vReport = new Envision.Plugin.CRFile.rptWorkLoad();
            try
            {
                LookUpSelect lvS = new LookUpSelect();
                DataTable dtt = lvS.SelectWorkloadReport(dStart, dEnd, UserID, JobType).Tables[0];
                //ProcessScheduleReport process = new ProcessScheduleReport(dStart, dEnd, SessionID);
                //process.ReportParameters = new Envision.Plugin.CRFileReportParameters();
                //process.ReportParameters.ModalityId = ModalityID;
                //process.ReportParameters.SpType = UserID;
                //process.Invoke();
                //DataTable dtt = process.ResultSet.Tables[0];

                vReport.SetDataSource(dtt);
                vReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            }
            catch (Exception ex)
            {

            }
            return vReport;
        }
        //yo end add



        //Bird - Outsource programmer

        // Function for report
        public ReportDocument rptWorkLoad
        {
            get
            {
                try
                {
                    CRFile.rptWorkLoad vReport = new CRFile.rptWorkLoad();
                    //CRFile.CrystalReport1 vReport = new CRFile.CrystalReport1();
                    Section section;

                    // Get the Section object by name.

                    section = vReport.ReportDefinition.Sections["Section1"];
                    // Get the ReportObject by name and cast it as a FieldObject.
                    // The name can be found in the properties window.
                    TextObject FromDateObject = section.ReportObjects["txtFromDate"] as TextObject;
                    FromDateObject.Text = _fromDate;
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate;
                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();
                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    ProcessGetRptWorkload process = new ProcessGetRptWorkload(new GBLEnvVariable().UserID, _formulaFromDate, _formulaToDate, _jobDesc);
                    //DataTable dtt = process..GetPrintData(OrderID, UserID);
                    process.Invoke();
                    vReport.SetDataSource(process.Result.Tables[0]);
                    /*
                    FormulaFieldDefinitions crFormula = vReport.DataDefinition.FormulaFields;
                    crFormula["v_empid"].Text = new GBLEnvVariable().UserID.ToString();
                    //crFormula["v_jobDesc"].Text = "\""+_jobDesc+"\"";
                    crFormula["v_jobDesc"].Text = _jobDesc;
                    crFormula["v_fromDate"].Text = _formulaFromDate;
                    crFormula["v_toDate"].Text = _formulaToDate;
                    */
                    //vReport.SetDataSource(dt);

                    return vReport;
                }
                catch (Exception Err)
                {
                    throw new Exception(Err.Message);
                }
            }
        }

        // Function for report
        public ReportDocument rptOrder
        {
            get
            {
                try
                {
                    CRFile.rptOrder vReport = new CRFile.rptOrder();
                    Section section;
                    // Get the Section object by name.

                    section = vReport.ReportDefinition.Sections["Section1"];
                    // Get the ReportObject by name and cast it as a FieldObject.
                    // The name can be found in the properties window.
                    TextObject FromDateObject = section.ReportObjects["txtFromDate"] as TextObject;
                    FromDateObject.Text = _fromDate;
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate;
                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();
                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    section = vReport.ReportDefinition.Sections["GroupHeaderSection1"];

                    //vReport.SetDatabaseLogon("sa", "birdcamp", "HOME-415AFBFE0C\\SQLEXPRESS", "RISN");
                    /*
                    FormulaFieldDefinitions crFormula = vReport.DataDefinition.FormulaFields;
                    crFormula["f_group"].Text = _formulaGroup;
                    crFormula["v_fromDate"].Text = _formulaFromDate;
                    crFormula["v_toDate"].Text = _formulaToDate;
                    crFormula["f_special_clinic"].Text = _formulaClinic;
                    */
                    FormulaFieldDefinitions crFormula = vReport.DataDefinition.FormulaFields;
                    crFormula["f_group"].Text = _formulaGroup;
                    ProcessGetRptOrder process = new ProcessGetRptOrder(_formulaFromDate, _formulaToDate, _formulaClinic);
                    //DataTable dtt = process..GetPrintData(OrderID, UserID);
                    process.Invoke();
                    vReport.SetDataSource(process.Result.Tables[0]);

                    //dc.Close();
                    return vReport;
                }
                catch (Exception Err)
                {
                    throw new Exception(Err.Message);
                }
            }
        }

        // Function for report
        public ReportDocument rptService
        {
            get
            {
                try
                {
                    CRFile.rptService vReport = new CRFile.rptService();
                    Section section;
                    // Get the Section object by name.

                    section = vReport.ReportDefinition.Sections["Section1"];
                    // Get the ReportObject by name and cast it as a FieldObject.
                    // The name can be found in the properties window.
                    TextObject FromDateObject = section.ReportObjects["txtFromDate"] as TextObject;
                    FromDateObject.Text = _fromDate;
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate;
                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    GBLEnvVariable env = new GBLEnvVariable();
                    HeaderObject.Text = env.FormTitle;
                    UserNameObject.Text = env.FirstName;
                    // HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();
                   // UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    /*
                    vReport.SetDatabaseLogon("sa", "birdcamp", "HOME-415AFBFE0C\\SQLEXPRESS", "RISN");
                    FormulaFieldDefinitions crFormula = vReport.DataDefinition.FormulaFields;
                    crFormula["v_RoomUID"].Text = _room;
                    crFormula["v_FromDate"].Text = _formulaFromDate;
                    crFormula["v_ToDate"].Text = _formulaToDate;
                    crFormula["v_ExamType"].Text = _examType;
                    */
                    ProcessGetRptService process = new ProcessGetRptService(_room, _formulaFromDate, _formulaToDate, _examType);
                    //DataTable dtt = process..GetPrintData(OrderID, UserID);
                    process.Invoke();
                    vReport.SetDataSource(process.Result.Tables[0]);

                    //dc.Close();
                    return vReport;
                }
                catch (Exception Err)
                {
                    throw new Exception(Err.Message);
                }
            }
        }

        // Function for report
        //public ReportDocument rptWaitingDuration
        //{
        //    get
        //    {
        //        try
        //        {
        //            CRFile.rptWaitingDuration vReport = new CRFile.rptWaitingDuration();
        //            /*
        //            Section section;
        //            // Get the Section object by name.

        //            section = vReport.ReportDefinition.Sections["Section2"];
        //            // Get the ReportObject by name and cast it as a FieldObject.
        //            // The name can be found in the properties window.
        //            fieldObject = section.ReportObjects["Text3"] as TextObject;

        //            lkp = new ProcessGetGBLLookup("Select * from ris_examresult" + _whereclose);
        //            lkp.Invoke();
        //            DataTable dt = lkp.ResultSet.Tables[0];
        //            vReport.SetDataSource(dt);
        //             * */
        //            //dc.Close();
        //            return vReport;
        //        }
        //        catch (Exception Err)
        //        {
        //            throw new Exception(Err.Message);
        //        }
        //    }
        //}


        // Function for report
        public ReportDocument rptComparing1
        {
            get
            {
                try
                {
                    CRFile.rptComparing1 vReport = new CRFile.rptComparing1();
                    Section section;

                    // Get the Section object by name.

                    section = vReport.ReportDefinition.Sections["Section1"];
                    // Get the ReportObject by name and cast it as a FieldObject.
                    // The name can be found in the properties window.
                    TextObject FromDateObject = section.ReportObjects["txtFromDate"] as TextObject;
                    FromDateObject.Text = _fromDate;
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate;
                    TextObject FromDateObject2 = section.ReportObjects["txtFromDate2"] as TextObject;
                    FromDateObject2.Text = _fromDate2;
                    TextObject ToDateObject2 = section.ReportObjects["txtToDate2"] as TextObject;
                    ToDateObject2.Text = _toDate2;

                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();

                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    ProcessGetRptComparing1 process = new ProcessGetRptComparing1(_formulaFromDate, _formulaToDate, _formulaFromDate2, _formulaToDate2);
                    //DataTable dtt = process..GetPrintData(OrderID, UserID);
                    process.Invoke();
                    vReport.SetDataSource(process.Result.Tables[0]);
                    /*
                    vReport.SetDatabaseLogon("sa", "birdcamp", "HOME-415AFBFE0C\\SQLEXPRESS", "RISN");

                    ParameterFieldDefinitions crFormula = vReport.DataDefinition.ParameterFields;
                    ParameterValues pValues = new ParameterValues();
                    ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();
                    discreteValue.Value = _formulaFromDate;
                    pValues.Add(discreteValue);
                    crFormula["fromDate1"].ApplyCurrentValues(pValues);

                    discreteValue.Value = _formulaFromDate2;
                    pValues.Add(discreteValue);
                    crFormula["fromDate2"].ApplyCurrentValues(pValues);

                    discreteValue.Value = _formulaToDate;
                    pValues.Add(discreteValue);
                    crFormula["toDate1"].ApplyCurrentValues(pValues);

                    discreteValue.Value = _formulaToDate2;
                    pValues.Add(discreteValue);
                    crFormula["toDate2"].ApplyCurrentValues(pValues);
                     */
                    /*
                    crFormula["v_RoomUID"].Text = _room;
                    crFormula["v_FromDate"].Text = _formulaFromDate;
                    crFormula["v_ToDate"].Text = _formulaToDate;
                    crFormula["v_ExamType"].Text = _examType;
                    */
                    //dc.Close();
                    return vReport;
                }
                catch (Exception Err)
                {
                    throw new Exception(Err.Message);
                }
            }
        }

        // Function for report
        public ReportDocument rptComparing2
        {
            get
            {
                try
                {
                    CRFile.rptComparing2 vReport = new CRFile.rptComparing2();
                    Section section;

                    // Get the Section object by name.

                    section = vReport.ReportDefinition.Sections["Section1"];
                    // Get the ReportObject by name and cast it as a FieldObject.
                    // The name can be found in the properties window.
                    TextObject FromDateObject = section.ReportObjects["txtFromDate"] as TextObject;
                    FromDateObject.Text = _fromDate;
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate;
                    TextObject FromDateObject2 = section.ReportObjects["txtFromDate2"] as TextObject;
                    FromDateObject2.Text = _fromDate2;
                    TextObject ToDateObject2 = section.ReportObjects["txtToDate2"] as TextObject;
                    ToDateObject2.Text = _toDate2;

                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();

                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    ProcessGetRptComparing2 process = new ProcessGetRptComparing2(_formulaFromDate, _formulaToDate, _formulaFromDate2, _formulaToDate2, new GBLEnvVariable().UserID.ToString());
                    //DataTable dtt = process..GetPrintData(OrderID, UserID);
                    process.Invoke();
                    vReport.SetDataSource(process.Result.Tables[0]);
                    /*
                    vReport.SetDatabaseLogon("sa", "birdcamp", "HOME-415AFBFE0C\\SQLEXPRESS", "RISN");

                    ParameterFieldDefinitions crFormula = vReport.DataDefinition.ParameterFields;
                    ParameterValues pValues = new ParameterValues();
                    ParameterDiscreteValue discreteValue = new ParameterDiscreteValue();
                    discreteValue.Value = _formulaFromDate;
                    pValues.Add(discreteValue);
                    crFormula["fromDate1"].ApplyCurrentValues(pValues);

                    discreteValue.Value = _formulaFromDate2;
                    pValues.Add(discreteValue);
                    crFormula["fromDate2"].ApplyCurrentValues(pValues);

                    discreteValue.Value = _formulaToDate;
                    pValues.Add(discreteValue);
                    crFormula["toDate1"].ApplyCurrentValues(pValues);

                    discreteValue.Value = _formulaToDate2;
                    pValues.Add(discreteValue);
                    crFormula["toDate2"].ApplyCurrentValues(pValues);

                    discreteValue.Value = new GBLEnvVariable().UserID.ToString();
                    pValues.Add(discreteValue);
                    crFormula["EmpID"].ApplyCurrentValues(pValues);
                    //dc.Close();
                     */
                    return vReport;
                }
                catch (Exception Err)
                {
                    throw new Exception(Err.Message);
                }
            }
        }

        // Function for report
        public ReportDocument rptCancelation
        {
            get
            {
                try
                {
                    CRFile.rptCancelation vReport = new CRFile.rptCancelation();
                    Section section;

                    section = vReport.ReportDefinition.Sections["Section1"];
                    // Get the ReportObject by name and cast it as a FieldObject.
                    // The name can be found in the properties window.
                    TextObject FromDateObject = section.ReportObjects["txtFromDate"] as TextObject;
                    FromDateObject.Text = _fromDate;
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate;
                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    
                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    GBLEnvVariable env = new GBLEnvVariable();


                    HeaderObject.Text = env.FormTitle;
                    UserNameObject.Text = env.FirstName;


                    ProcessGetRptCancellation process = new ProcessGetRptCancellation(_formulaFromDate, _formulaToDate);
                    //DataTable dtt = process..GetPrintData(OrderID, UserID);
                    process.Invoke();
                    vReport.SetDataSource(process.Result.Tables[0]);
                    //dc.Close();
                    return vReport;
                }
                catch (Exception Err)
                {
                    throw new Exception(Err.Message);
                }
            }
        }
        public ReportDocument rptSummaryReport(int id, DataTable dtt)
        {
            ReportDocument vReport = new ReportDocument();
            try
            {
                switch (id)
                {
                    case 1:
                        CRFile.rptSummaryOrderByRefUnit rptUnit = new Envision.Plugin.CRFile.rptSummaryOrderByRefUnit();
                        vReport = rptUnit;
                        break;
                    case 2:
                        CRFile.rptSummaryOrderByExam rptByExam = new Envision.Plugin.CRFile.rptSummaryOrderByExam();
                        vReport = rptByExam;
                        break;
                    case 3:
                        CRFile.rptSummaryOrderByExamType rptType = new Envision.Plugin.CRFile.rptSummaryOrderByExamType();
                        vReport = rptType;
                        break;
                    case 4:
                        CRFile.rptSummarySchedule rptSchedule = new Envision.Plugin.CRFile.rptSummarySchedule();
                        vReport = rptSchedule;
                        break;
                    case 5:
                        CRFile.rptSummaryResultClinic rptResult = new Envision.Plugin.CRFile.rptSummaryResultClinic();
                        vReport = rptResult;
                        break;
                    case 6:
                        CRFile.rptSummaryIncome rptIncome = new Envision.Plugin.CRFile.rptSummaryIncome();
                        vReport = rptIncome;
                        break;
                    case 7:
                        CRFile.rptSummaryScheduleByModality rptArrive = new Envision.Plugin.CRFile.rptSummaryScheduleByModality();
                        vReport = rptArrive;
                        break;
                    default:
                        break;
                }
                vReport.SetDataSource(dtt);
            }
            catch (Exception ex)
            {
                return vReport;
            }
            return vReport;
        }
        public ReportDocument rptSummaryDF(DataTable dtt)
        {
            CRFile.rptSummaryDF vReport = new Envision.Plugin.CRFile.rptSummaryDF();
            vReport.SetDataSource(dtt);
            return vReport;
        }
        public ReportDocument rptSummaryDFAimc(DataTable dtt)
        {
            CRFile.rptSummaryDFAimc vReport = new Envision.Plugin.CRFile.rptSummaryDFAimc();
            vReport.SetDataSource(dtt);
            return vReport;
        }
        public ReportDocument rptInvStock(DataTable dtt)
        {
            CRFile.rptInvStock vReport = new Envision.Plugin.CRFile.rptInvStock();
            vReport.SetDataSource(dtt);
            return vReport;
        }
        public ReportDocument rptPatientFlowReport(DataTable dtt)
        {
            CRFile.rptPatientFlow vReport = new Envision.Plugin.CRFile.rptPatientFlow();
            vReport.SetDataSource(dtt);
            return vReport;
        }

        public ReportDocument rptSummaryDFTech(DataTable dtt)
        {
            CRFile.rptSummaryDFTech vReport = new CRFile.rptSummaryDFTech();
            vReport.SetDataSource(dtt);
            return vReport;
        }

        public ReportDocument rptScheduleReportIntervention(DataTable dtSCH)
        {
            CRFile.rptScheduleReportIntervention vsReport = new CRFile.rptScheduleReportIntervention();
            try
            {
                DataTable dts = dtSCH.Copy();
                DateTime _appdate = new DateTime();
                DateTime preparedate = new DateTime();
                _appdate = Convert.ToDateTime(dts.Rows[0]["APPOINT_DT"]);
                preparedate = _appdate.AddHours(-8);
                ProcessGetRISExam getEx = new ProcessGetRISExam();
                getEx.Invoke();
                DataRow[] drEx = getEx.Result.Tables[0].Select("EXAM_UID='" + dts.Rows[0]["EXAM_UID"].ToString() + "'");

                vsReport.SetDataSource(dts);
            }
            catch (Exception ex)
            {
            }
            return vsReport;
        }

        public ReportDocument BiopsyLocalizeResultPreview(string Accession, int userID
                                , string RC, string R1, string R2, string R3, string R4, string R5, string R6, string R7, string R8, string R9, string R10, string R11, string R12, string RO
                                , string LC, string L1, string L2, string L3, string L4, string L5, string L6, string L7, string L8, string L9, string L10, string L11, string L12, string LO)
        {

                CRFile.rptBiopsyLoca vsReport = new CRFile.rptBiopsyLoca();
                ProcessGetRptBiopsyResult lkp = new ProcessGetRptBiopsyResult(Accession, userID, RC, R1, R2, R3, R4, R5, R6, R7, R8, R9, R10, R11, R12, RO, LC, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, LO);
                lkp.Invoke();
                DataTable dt = lkp.Result.Tables[0];
                vsReport.SetDataSource(dt);
                vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;
                return vsReport;
        }
        public ReportDocument BiopsyResultPreview(string Accession, int userID
                                        , string RC, string R1, string R2, string R3, string R4, string R5, string R6, string R7, string R8, string R9, string R10, string R11, string R12, string RO
                                        , string LC, string L1, string L2, string L3, string L4, string L5, string L6, string L7, string L8, string L9, string L10, string L11, string L12, string LO)
        {

            CRFile.rptBiospy vsReport = new Envision.Plugin.CRFile.rptBiospy();
            ProcessGetRptBiopsyResult lkp = new ProcessGetRptBiopsyResult(Accession, userID, RC, R1, R2, R3, R4, R5, R6, R7, R8, R9, R10, R11, R12, RO, LC, L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12, LO);
            lkp.Invoke();
            DataTable dt = lkp.Result.Tables[0];

            vsReport.SetDataSource(dt);
            vsReport.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA5;

            return vsReport;
        }
        //XtraReport Preview
        public void ResultEntryDirectPrintA4(string _accno)
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
                Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision xrpt = new Envision.Plugin.XtraFile.xtraReports.xrptResultReportEnvision(dt, nameUser, examName);
                xrpt.DataSource = dt;
                xrpt.ShowPreviewMarginLines = false;
                xrpt.ShowPreviewDialog();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }

        }
        public void ResultEntryDirectPrintA4AIMC(string _accno)
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
                xrpt.ShowPreviewDialog();
            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.ToString());
            }
        }
        public void ResultEntryDirectPrintA4SDMC(string _accno)
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
                xrpt.ShowPreviewDialog();
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
    }

}
