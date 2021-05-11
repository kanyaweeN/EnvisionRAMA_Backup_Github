using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;



using RIS.BusinessLogic;
using RIS.Common.Common;
using RIS.Plugin.CRFile;
using RIS.Operational.CRFile;


namespace RIS.Plugin.ReportManager
{
    public class ReportMangager
    {
        //create dbconnection class instance
        //ProcessGetGBLLookup lkp; 

        string _whereclose;
        string _mrNumber;
        string _firstName;
        string _lastName;
        DateTime _toDate;
        DateTime _fromDate;
        string _toDate2;
        string _fromDate2;
        string _groupBy;
        string _room;
        string _examType;
        string _jobDesc;
        DateTime _formulaFromDate;
        DateTime _formulaToDate;
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

        public DateTime formulaFromDate
        {
            get { return _formulaFromDate; }
            set { _formulaFromDate = value; }
        }

        public DateTime formulaToDate
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

        public DateTime fromDate
        {
            get { return _fromDate; }
            set { _fromDate = value; }
        }

        public DateTime toDate
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
        public ReportDocument rptSticker(string HN)
        {
            rptSticker vReport = new rptSticker();
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
            rptStickerExam vReport = new rptStickerExam();
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
            rptDuration vReport = new  rptDuration();
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

        public ReportDocument rptScheduleReport(string _hn, DateTime _appdate, int _modality,int _schedule)
        {
            CRFile.rptScheduleReport vsReport = new CRFile.rptScheduleReport();
            try
            {


                RIS.Common.ReportParameters spara = new RIS.Common.ReportParameters();
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
                txtUser.Text = new GBLEnvVariable().FirstName + " "+ new GBLEnvVariable().LastName;
            }
            catch (Exception rrr)
            {
            }
            return vsReport;
        }

        //yo start add
        public ReportDocument rptModalityExam(int ModalityID, int UserID)
        {
            CRFile.rptModalityExam vReport = new  rptModalityExam();
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
            CRFile.rptQAWorks vReport = new  rptQAWorks();
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
            CRFile.rptAppoint vReport = new  rptAppoint();
            try
            {

                ProcessScheduleReport process = new ProcessScheduleReport(dStart, dEnd,SessionID);
                process.ReportParameters = new RIS.Common.ReportParameters();
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
        //yo end add



        //Bird - Outsource programmer

        // Function for report
        public ReportDocument rptWorkLoad
        {
            get
            {
                try
                {
                    rptWorkLoad vReport = new rptWorkLoad();
                    //CRFile.CrystalReport1 vReport = new CRFile.CrystalReport1();
                    Section section;

                    //// Get the Section object by name.

                    //section = vReport.ReportDefinition.Sections["Section1"];
                    //// Get the ReportObject by name and cast it as a FieldObject.
                    //// The name can be found in the properties window.
                    //TextObject FromDateObject = section.ReportObjects["txtFromDate"] as TextObject;
                    //FromDateObject.Text = Convert.ToString(_fromDate);
                    //TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    //ToDateObject.Text = Convert.ToString(_toDate);
                    //TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    //HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();
                    //section = vReport.ReportDefinition.Sections["Section5"];
                    //TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    //UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

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
                    FromDateObject.Text = _fromDate.ToString("dd/MM/yyyy");
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate.ToString("dd/MM/yyyy"); ;
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
                    ProcessGetRptOrder process = new ProcessGetRptOrder(_formulaFromDate.ToString(), _formulaToDate.ToString(), _formulaClinic);
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
        public ReportDocument rptOrderReport(int OrderID, int UserID)
        {
            rptOrderReport vReport = new rptOrderReport();
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
                    FromDateObject.Text = _fromDate.ToString("dd/MM/yyyy");
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate.ToString("dd/MM/yyyy");
                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();
                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    /*
                    vReport.SetDatabaseLogon("sa", "birdcamp", "HOME-415AFBFE0C\\SQLEXPRESS", "RISN");
                    FormulaFieldDefinitions crFormula = vReport.DataDefinition.FormulaFields;
                    crFormula["v_RoomUID"].Text = _room;
                    crFormula["v_FromDate"].Text = _formulaFromDate;
                    crFormula["v_ToDate"].Text = _formulaToDate;
                    crFormula["v_ExamType"].Text = _examType;
                    */
                    ProcessGetRptService process = new ProcessGetRptService(_room, _formulaFromDate.ToString("dd/MM/yyyy"), _formulaToDate.ToString("dd/MM/yyyy"), _examType);
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
                    FromDateObject.Text = _fromDate.ToString("dd/MM/yyyy");
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate.ToString("dd/MM/yyyy");
                    TextObject FromDateObject2 = section.ReportObjects["txtFromDate2"] as TextObject;
                    FromDateObject2.Text = _fromDate2;
                    TextObject ToDateObject2 = section.ReportObjects["txtToDate2"] as TextObject;
                    ToDateObject2.Text = _toDate2;

                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();

                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    ProcessGetRptComparing1 process = new ProcessGetRptComparing1(_formulaFromDate.ToString("dd/MM/yyyy"), _formulaToDate.ToString("dd/MM/yyyy"), _formulaFromDate2, _formulaToDate2);
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
                    FromDateObject.Text = _fromDate.ToString("dd/MM/yyyy");
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate.ToString("dd/MM/yyyy");
                    TextObject FromDateObject2 = section.ReportObjects["txtFromDate2"] as TextObject;
                    FromDateObject2.Text = _fromDate2;
                    TextObject ToDateObject2 = section.ReportObjects["txtToDate2"] as TextObject;
                    ToDateObject2.Text = _toDate2;

                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();

                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();

                    ProcessGetRptComparing2 process = new ProcessGetRptComparing2(_formulaFromDate.ToString("dd/MM/yyyy"), _formulaToDate.ToString("dd/MM/yyyy"), _formulaFromDate2, _formulaToDate2, new GBLEnvVariable().UserID.ToString());
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
                    FromDateObject.Text = _fromDate.ToString("dd/MM/yyyy");
                    TextObject ToDateObject = section.ReportObjects["txtToDate"] as TextObject;
                    ToDateObject.Text = _toDate.ToString("dd/MM/yyyy");
                    TextObject HeaderObject = section.ReportObjects["Text9"] as TextObject;
                    HeaderObject.Text = new GBLEnvVariable().FormTitle.ToString();
                    section = vReport.ReportDefinition.Sections["Section5"];
                    TextObject UserNameObject = section.ReportObjects["txtUserName"] as TextObject;
                    UserNameObject.Text = new GBLEnvVariable().FirstName.ToString();


                    ProcessGetRptCancellation process = new ProcessGetRptCancellation(_formulaFromDate.ToString("dd/MM/yyyy"), _formulaToDate.ToString("dd/MM/yyyy"));
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
                        CRFile.rptSummaryOrderByRefUnit rptUnit = new  rptSummaryOrderByRefUnit();
                        vReport = rptUnit;
                        break;
                    case 2:
                        CRFile.rptSummaryOrderByExam rptByExam = new  rptSummaryOrderByExam();
                        vReport = rptByExam;
                        break;
                    case 3:
                        CRFile.rptSummaryOrderByExamType rptType = new  rptSummaryOrderByExamType();
                        vReport = rptType;
                        break;
                    case 4:
                        CRFile.rptSummarySchedule rptSchedule = new  rptSummarySchedule();
                        vReport = rptSchedule;
                        break;
                    case 5:
                        CRFile.rptSummaryResultClinic rptResult = new  rptSummaryResultClinic();
                        vReport = rptResult;
                        break;
                    case 6:
                        CRFile.rptSummaryIncome rptIncome = new  rptSummaryIncome();
                        vReport = rptIncome;
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

        public ReportDocument rptSummaryDFAimc(DataTable dtt)
        {
            rptSummaryDFAimc vReport = new rptSummaryDFAimc();
            vReport.SetDataSource(dtt);
            return vReport;
        }

    }

}
