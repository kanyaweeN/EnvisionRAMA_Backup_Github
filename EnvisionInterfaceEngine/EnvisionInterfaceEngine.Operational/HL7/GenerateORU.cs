using System;
using System.Data;
using System.Globalization;
using EnvisionInterfaceEngine.Common.HL7;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V23.Datatype;
using NHapi.Model.V23.Message;

namespace EnvisionInterfaceEngine.Operational.HL7
{
    public class GenerateORU
    {
        private static DataTable dtResultStat = new DataTable();
        private static DataTable dtResultDatetime = new DataTable();
        private static DataTable dtRadiologistGroup = new DataTable();
        private static DataTable dtSeverityLog = new DataTable();
        private static DataTable dtSeverity = new DataTable();

        public static string GenerateHL7(HL7ORU data)
        {
            ORU_R01 oru = new ORU_R01();

            oru.MSH.SendingApplication.NamespaceID.Value = data.MSH.SENDING_APPLICATION;
            oru.MSH.SendingFacility.NamespaceID.Value = data.ORG.ORG_ALIAS;
            oru.MSH.ReceivingApplication.NamespaceID.Value = data.MSH.RECEIVING_APPLICATION;
            oru.MSH.DateTimeOfMessage.TimeOfAnEvent.Value = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            oru.MSH.MessageControlID.Value = data.MSH.MESSAGE_CONTROL_ID;
            oru.MSH.ProcessingID.ProcessingID.Value = data.MSH.PROCESSING_ID;
            oru.MSH.VersionID.Value = data.MSH.VERSION_ID;

            #region PATIENT
            oru.GetRESPONSE(0).PATIENT.PID.PatientIDExternalID.ID.Value = data.PATIENT.EXT_HN;
            oru.GetRESPONSE(0).PATIENT.PID.GetPatientIDInternalID(0).ID.Value = data.PATIENT.HN;
            oru.GetRESPONSE(0).PATIENT.PID.AlternatePatientID.ID.Value = data.PATIENT.HIS_HN;

            oru.GetRESPONSE(0).PATIENT.PID.PatientName.PrefixEgDR.Value = data.PATIENT.TITLE_ENG;
            oru.GetRESPONSE(0).PATIENT.PID.PatientName.FamilyName.Value = data.PATIENT.FNAME_ENG;
            oru.GetRESPONSE(0).PATIENT.PID.PatientName.GivenName.Value = data.PATIENT.LNAME_ENG;

            oru.GetRESPONSE(0).PATIENT.PID.GetPatientAlias(0).PrefixEgDR.Value = data.PATIENT.TITLE;
            oru.GetRESPONSE(0).PATIENT.PID.GetPatientAlias(0).FamilyName.Value = data.PATIENT.FNAME;
            oru.GetRESPONSE(0).PATIENT.PID.GetPatientAlias(0).GivenName.Value = data.PATIENT.LNAME;

            if (data.PATIENT.GENDER != char.MinValue)
                oru.GetRESPONSE(0).PATIENT.PID.Sex.Value = data.PATIENT.GENDER.ToString();

            if (data.PATIENT.DOB != null && data.PATIENT.DOB != DateTime.MinValue)
                oru.GetRESPONSE(0).PATIENT.PID.DateOfBirth.TimeOfAnEvent.Value = data.PATIENT.DOB.ToString("yyyyMMdd", CultureInfo.GetCultureInfo("en-US"));

            oru.GetRESPONSE(0).PATIENT.PID.SSNNumberPatient.Value = data.PATIENT.SSN;
            oru.GetRESPONSE(0).PATIENT.PID.GetPatientAddress(0).StateOrProvince.Value = data.PATIENT.ADDR1 + data.PATIENT.ADDR2 + data.PATIENT.ADDR3 + data.PATIENT.ADDR4 + data.PATIENT.ADDR5;
            oru.GetRESPONSE(0).PATIENT.PID.GetPhoneNumberHome(0).Value = data.PATIENT.PHONE1;
            oru.GetRESPONSE(0).PATIENT.PID.GetPhoneNumberBusiness(0).Value = data.PATIENT.PHONE2;
            #endregion
            #region PATIENT VISIT
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.VisitNumber.ID.Value = data.ORDER_DETAIL.ACCESSION_NO; //If send VISIT_NO have some problem with Synapse.
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.PreadmitNumber.ID.Value = data.ORDER.ADMISSION_NO;

            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.GetConsultingDoctor(0).IDNumber.Value = data.ASSIGNED_TO.EMP_UID;
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.GetConsultingDoctor(0).FamilyName.Value = data.ASSIGNED_TO.TITLE_ENG;
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.GetConsultingDoctor(0).GivenName.Value = data.ASSIGNED_TO.FNAME_ENG + " " + data.ASSIGNED_TO.LNAME_ENG;

            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.GetConsultingDoctor(1).IDNumber.Value = data.ASSIGNED_TO.EMP_UID;
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.GetConsultingDoctor(1).FamilyName.Value = data.ASSIGNED_TO.SALUTATION;
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.GetConsultingDoctor(1).GivenName.Value = data.ASSIGNED_TO.FNAME + " " + data.ASSIGNED_TO.LNAME;

            //Prim. Loc
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.AssignedPatientLocation.PointOfCare.Value = data.REFERENCE_UNIT.UNIT_NAME;
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.AssignedPatientLocation.Room.Value = data.REFERENCE_UNIT.UNIT_NAME;

            //Current Loc
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.TemporaryLocation.PointOfCare.Value = data.REFERENCE_UNIT.UNIT_UID;
            oru.GetRESPONSE(0).PATIENT.VISIT.PV1.TemporaryLocation.Room.Value = data.REFERENCE_UNIT.UNIT_NAME;
            #endregion
            #region ORDER
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().ORC.OrderControl.Value = data.ORDER_CONTROL;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().ORC.GetPlacerOrderNumber(0).EntityIdentifier.Value = data.ORDER.REQUESTNO;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().ORC.OrderStatus.Value = data.ORDER_STATUS;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.ResultStatus.Value = data.RESULT_STATUS;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.RelevantClinicalInformation.Value = data.ORDER.CLINICAL_INSTRUCTION;

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetPlacerOrderNumber(0).EntityIdentifier.Value = data.EXAMRESULT.ACCESSION_NO;

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.UniversalServiceIdentifier.Identifier.Value = data.EXAM.EXAM_UID;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.UniversalServiceIdentifier.Text.Value = data.EXAM.EXAM_NAME;

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.TransportationMode.Value = data.PATIENT_STATUS.STATUS_UID;

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetOrderingProvider(0).IDNumber.Value = data.REFERRING_DOCTOR.EMP_UID;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetOrderingProvider(0).FamilyName.Value = data.REFERRING_DOCTOR.TITLE_ENG;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetOrderingProvider(0).GivenName.Value = data.REFERRING_DOCTOR.FNAME_ENG + " " + data.REFERRING_DOCTOR.LNAME_ENG;

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetOrderingProvider(1).IDNumber.Value = data.REFERRING_DOCTOR.EMP_UID;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetOrderingProvider(1).FamilyName.Value = data.REFERRING_DOCTOR.SALUTATION;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetOrderingProvider(1).GivenName.Value = data.REFERRING_DOCTOR.FNAME + " " + data.REFERRING_DOCTOR.LNAME;

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.DiagnosticServiceSectionID.Value = data.MODALITYTYPE.TYPE_NAME_ALIAS;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.QuantityTiming.Priority.Value = data.ORDER_DETAIL.PRIORITY.ToString();
            #endregion
            #region RESULT
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.SetIDOBX.Value = "1";
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ValueType.Value = "TX";

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ObservResultStatus.Value = data.EXAMRESULT.RESULT_STATUS.ToString();

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.DateTimeOfTheObservation.TimeOfAnEvent.SetLongDate(data.EXAMRESULT.LAST_MODIFIED_ON);

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ResponsibleObserver.IDNumber.Value = data.RADIOLOGIST.EMP_UID;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ResponsibleObserver.FamilyName.Value = data.RADIOLOGIST.TITLE_ENG;
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ResponsibleObserver.GivenName.Value = data.RADIOLOGIST.FNAME_ENG + " " + data.RADIOLOGIST.LNAME_ENG;
            #endregion

            Varies varies = oru.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.GetObservationValue(0);
            TX text = new TX(oru);
            text.Value = data.OBSERVATION_VALUE;
            varies.Data = text;

            return HL7Manager.decodeAlphanumeric(new PipeParser().Encode(oru), data.RESULT_TYPE);
        }

        public static void ConvertToHL7(DataSet data, string resultType, DataTable resultStat, DataTable resultDatetime, DataTable radiologistGroup, DataTable severityLog, DataTable severity)
        {
            if (Utilities.HasData(data))
            {
                DataTable dtt_result = data.Tables[0];
                DataTable dtt_addendum = data.Tables[1];
                dtResultStat = resultStat;
                dtResultDatetime = resultDatetime;
                dtSeverityLog = severityLog;
                dtSeverity = severity;
                dtRadiologistGroup = radiologistGroup;

                if (dtt_result.Columns.IndexOf("HL7_TEXT") < 0)
                    dtt_result.Columns.Add("HL7_TEXT", typeof(string));
                data.AcceptChanges();

                foreach (DataRow row in dtt_result.Rows)
                    row["HL7_TEXT"] = Utilities.ClearSyntaxHL7(GenerateHL7(ConvertToObject(row, dtt_addendum.Select("ACCESSION_NO = '" + row["ACCESSION_NO"].ToString() + "'", "NOTE_ON desc"), resultType))); ;
                data.AcceptChanges();
            }
        }

        public static HL7ORU ConvertToObject(DataRow dataResult, DataRow[] dateResultNote, string resultType)
        {
            HL7ORU hl7_oru = new HL7ORU();

            hl7_oru.RESULT_TYPE = resultType;

            using (HL7ORM hl7_orm = GenerateORM.ConvertToObject(dataResult))
            {
                hl7_oru.MSH = hl7_orm.MSH;
                hl7_oru.ORG = hl7_orm.ORG;
                hl7_oru.PATIENT = hl7_orm.PATIENT;

                hl7_oru.ORDER = hl7_orm.ORDER;
                hl7_oru.PATIENT_STATUS = hl7_orm.PATIENT_STATUS;
                hl7_oru.REFERENCE_UNIT = hl7_orm.REFERENCE_UNIT;
                hl7_oru.REFERRING_DOCTOR = hl7_orm.REFERRING_DOCTOR;

                hl7_oru.ORDER_DETAIL = hl7_orm.ORDER_DETAIL;
                hl7_oru.EXAM = hl7_orm.EXAM;
                hl7_oru.MODALITY = hl7_orm.MODALITY;
                hl7_oru.MODALITYAETITLE = hl7_orm.MODALITYAETITLE;
                hl7_oru.MODALITYTYPE = hl7_orm.MODALITYTYPE;
                hl7_oru.ASSIGNED_TO = hl7_orm.ASSIGNED_TO;
                hl7_oru.OPERATOR = hl7_orm.OPERATOR;
            }

            hl7_oru.ORDER_CONTROL = "SC";

            hl7_oru.EXAMRESULT.ACCESSION_NO = dataResult["ACCESSION_NO"].ToString();
            hl7_oru.EXAMRESULT.RESULT_STATUS = Convert.ToChar(dataResult["RESULT_STATUS"]);
            hl7_oru.EXAMRESULT.RESULT_TEXT_HTML = dataResult["RESULT_TEXT_HTML"].ToString(); 
            hl7_oru.EXAMRESULT.RESULT_TEXT_PLAIN = dataResult["RESULT_TEXT_PLAIN"].ToString();
            hl7_oru.EXAMRESULT.RESULT_TEXT_RTF = dataResult["RESULT_TEXT_RTF"].ToString();
            hl7_oru.EXAMRESULT.LAST_MODIFIED_ON = Convert.ToDateTime(dataResult["RESULT_ON"]);

            hl7_oru.RADIOLOGIST.EMP_UID = dataResult["RAD_UID"].ToString();
            hl7_oru.RADIOLOGIST.SALUTATION = dataResult["RAD_SALUTATION"].ToString();
            hl7_oru.RADIOLOGIST.FNAME = dataResult["RAD_FNAME"].ToString();
            hl7_oru.RADIOLOGIST.LNAME = dataResult["RAD_LNAME"].ToString();
            hl7_oru.RADIOLOGIST.TITLE_ENG = dataResult["RAD_TITLE_ENG"].ToString();
            hl7_oru.RADIOLOGIST.FNAME_ENG = dataResult["RAD_FNAME_ENG"].ToString();
            hl7_oru.RADIOLOGIST.LNAME_ENG = dataResult["RAD_LNAME_ENG"].ToString();

            switch (hl7_oru.RESULT_TYPE)
            {
                case "HTML":
                    if (string.IsNullOrEmpty(dataResult["RESULT_TEXT_RTFtoHTML"].ToString()))
                        hl7_oru.EXAMRESULT.RESULT_TEXT_HTML = generateResultHTML(dataResult);
                    else
                        hl7_oru.EXAMRESULT.RESULT_TEXT_HTML = generateResultHTML(dataResult["RESULT_TEXT_RTFtoHTML"].ToString());
                    if (string.IsNullOrEmpty(hl7_oru.EXAMRESULT.RESULT_TEXT_HTML))
                        hl7_oru.EXAMRESULT.RESULT_TEXT_HTML = hl7_oru.EXAMRESULT.RESULT_TEXT_PLAIN;

                    hl7_oru.OBSERVATION_VALUE = PrepareResultHtml(hl7_oru.EXAMRESULT.RESULT_TEXT_HTML, dateResultNote)
                        //.Replace("&nbsp;", " ")
                        //.Replace("&", " and ")
                        .Replace(Convert.ToChar(0x0b).ToString(), " <br> ")
                        .Replace(Convert.ToChar(0x1c).ToString() + Convert.ToChar(0x0d).ToString(), " <br> ")
                        .Replace(Convert.ToChar(0x0d).ToString(), " <br> ")
                        .Replace(Delimiter.StringFieldSeparate, " ")
                        .Replace(Delimiter.StringComponentSeparate, " ")
                        .Replace(Delimiter.StringSubcomponentSeparate, " ")
                        .Replace(Delimiter.StringRepetitionSeparate, " ")
                        .Replace(Delimiter.StringEscapeCharacter, " ");
                    dataResult["RESULT_TEXT_HTML"] = hl7_oru.OBSERVATION_VALUE;
                    break;
                case "RTF":
                    hl7_oru.OBSERVATION_VALUE = hl7_oru.EXAMRESULT.RESULT_TEXT_RTF;
                    break;
                case "PLAIN":
                    hl7_oru.OBSERVATION_VALUE = PrepareResultPlain(hl7_oru.EXAMRESULT.RESULT_TEXT_PLAIN, dateResultNote)
                        .Replace("&", " and ")
                        .Replace(Convert.ToChar(0x0b).ToString(), " ~ ")
                        .Replace(Convert.ToChar(0x1c).ToString() + Convert.ToChar(0x0d).ToString(), " ~ ")
                        .Replace(Convert.ToChar(0x0d).ToString(), " ~ ")
                        .Replace(Delimiter.StringFieldSeparate, " ")
                        .Replace(Delimiter.StringComponentSeparate, " ")
                        .Replace(Delimiter.StringSubcomponentSeparate, " ")
                        .Replace(Delimiter.StringRepetitionSeparate, " ")
                        .Replace(Delimiter.StringEscapeCharacter, " ");
                    break;
                default:
                    hl7_oru.OBSERVATION_VALUE = ".";
                    break;
            }

            return hl7_oru;
        }
        private static string generateSeverity()
        {
            string strSeverity = "";
            if (Utilities.HasData(dtSeverity))
            {
                strSeverity += "<font face='Microsoft Sans Serif' size='4'>";
                strSeverity += string.Format("Report Severity : {0}", dtSeverity.Rows[0]["SEVERITY_LABEL"].ToString());
                strSeverity += "</font>";
            }
            return strSeverity;
        }
        private static string generateCliticalFinding(string severitylog_id)
        {
            string strCliticalFinding = "";
            DataRow[] row = dtSeverityLog.Select("SEVERITYLOG_ID="+severitylog_id);
            if (row.Length > 0)
            {
                strCliticalFinding += "<font face='Microsoft Sans Serif' size='4'>";
                strCliticalFinding += string.Format("The finding(s) in this report was discussed with {0} at {1}, within {2} minutes of observation.", row[0]["VERBAL_NAME"].ToString(), Convert.ToDateTime(row[0]["VERBAL_DATETIME"]).ToString("dd/MM/yyyy HH:mm"), row[0]["VERBAL_TIME"].ToString());
                strCliticalFinding += "</font>";
            }
            return strCliticalFinding;
        }
        private static string generateRadiologistGroup()
        {
            string strRadiologistGroup = "";
            for (int i = 0; i < dtRadiologistGroup.Rows.Count; i++)
                strRadiologistGroup += "<font face='Microsoft Sans Serif' size='4'>"+dtRadiologistGroup.Rows[i]["RAD_FULL_NAME"].ToString()+"</font> <br> ";
            return strRadiologistGroup;
        }
        private static string generateResultDatetime(string result_status)
        {
            string strResultDatetime = "<font face='Microsoft Sans Serif' size='4'><i>";
            DateTime released_on = Convert.ToDateTime(dtResultDatetime.Rows[0]["RELEASED_ON"]);
            DateTime finalized_on = Convert.ToDateTime(dtResultDatetime.Rows[0]["FINALIZED_ON"]);
            DateTime current_dt = Convert.ToDateTime(dtResultDatetime.Rows[0]["CURRENT_DT"]);
            DateTime assigned_dt = Convert.ToDateTime(dtResultDatetime.Rows[0]["ASSIGNED_TIMESTAMP"]);
            if (assigned_dt != current_dt)
            {
                strResultDatetime += "Assigned Datetime: ";
                strResultDatetime += assigned_dt.ToString("dd/MM/yyyy HH:mm:ss");
                strResultDatetime += "<br>";
            }
            if (result_status == "F")
            {
                if (released_on == current_dt)
                {
                    strResultDatetime += "Finalized Datetime: ";
                    strResultDatetime += finalized_on.ToString("dd/MM/yyyy HH:mm:ss");
                    strResultDatetime += "<br>";
                }
                else
                {
                    strResultDatetime += "Preliminary Datetime: ";
                    strResultDatetime += released_on.ToString("dd/MM/yyyy HH:mm:ss");
                    strResultDatetime += "<br>";

                    strResultDatetime += "Finalized Datetime: ";
                    strResultDatetime += finalized_on.ToString("dd/MM/yyyy HH:mm:ss");
                    strResultDatetime += "<br>";
                }
            }
            else if (result_status == "P")
            {
                strResultDatetime += "Preliminary Datetime: ";
                strResultDatetime += released_on.ToString("dd/MM/yyyy HH:mm:ss");
                strResultDatetime += "<br>";
            }
            else
            {
                strResultDatetime += "test";
            }
            strResultDatetime += "</i></font><br>";
            return strResultDatetime;
        }
        private static string generateResultStat(string note_no)
        {
            int queue = dtResultStat.Rows.Count;
            int start_queue = 0;
            if (note_no != "0")
                start_queue = 1;
            string strResultStat = "";
            int show_queue =  note_no == "0" ? queue : queue - 1 ;
            for (int i = start_queue; i < dtResultStat.Rows.Count; i++)
            {
                strResultStat += "<font face='Microsoft Sans Serif' size='4'>Short Prelim : " + show_queue.ToString() + ", ";
                strResultStat += "Written By : ";
                strResultStat += dtResultStat.Rows[i]["RadioNameEng"].ToString();
                strResultStat += ", Date : ";
                DateTime dt = Convert.ToDateTime(dtResultStat.Rows[i]["NOTE_ON"]);
                strResultStat += dt.ToString() + "<br>";
                strResultStat += generateResultHTML(dtResultStat.Rows[i]["RTF"].ToString());
                strResultStat += "</font><br>";
                queue--;
            }
            strResultStat += "<br>-------------------------";
            return strResultStat;
        }
        private static string generateResultHTML(DataRow resultData)
        {
            string html = string.Empty;
            //Text Reporting
            html += generateResultHTML(resultData["RESULT_TEXT_RTF"].ToString());
            //Add Severity
            if (Utilities.HasData(dtSeverity))
                html += " <br>  <br> " + generateSeverity();
            //Add clitical finding.
            if (!string.IsNullOrEmpty(resultData["SEVERITYLOG_ID"].ToString()))
                html += " <br>  <br> " + generateCliticalFinding(resultData["SEVERITYLOG_ID"].ToString());
            //Add radiologist group
            html += " <br>  <br> " + generateRadiologistGroup();
            //Add result datetime
            html += " <br>  <br> " + generateResultDatetime(resultData["RESULT_STATUS"].ToString());
            //Add result stat
            html += " <br>  <br> " + generateResultStat(resultData["NOTE_NO"].ToString());
            return html;
        }
        private static string generateResultHTML(string resultRTF)
        {
            string html = string.Empty;

            EnvisionInterfaceEngine.Operational.Translator.TransRtf tran = new EnvisionInterfaceEngine.Operational.Translator.TransRtf(resultRTF);
            html = tran.Translator()
                .Replace("<img	src=\"none\" />", string.Empty)
                .Replace(@"\X000d\", "<br>");

            return html;
        }
        private static string PrepareResultHtml(string resultHTML, DataRow[] addendum)
        {
            string result = string.Empty;

            result += @"<font face='Microsoft Sans Serif' size='3'>";

            if (Utilities.HasData(addendum))
            {
                int length = addendum.Length;
                int counter = 0;

                for (int i = 0; i < length; length--)
                {
                    DataRow dr = addendum[counter++];

                    result += string.Format("Addendum {0} ", length.ToString());
                    result += string.Format("Written By {0} ", dr["Radiologist"].ToString());
                    result += string.Format("Date {0:dd/MM/yyyy HH:mm}", Convert.ToDateTime(dr["NOTE_ON"]));
                    result += @" <br> ";
                    result += dr["RESULT_TEXT"].ToString();
                    result += @" <br> ";
                    result += @" <br> ";
                }

                result += @" <br> ";
                result += @"-------------------------";
                result += @" <br> ";
                result += @" <br> ";
                result += @" <br> ";
            }

            result += resultHTML;
            result += @"</font>";

            return result.Replace("\r\n", " <br> ").Replace("\n", " <br> ").Replace("\r", " <br> "); ;
        }
        private static string PrepareResultPlain(string resultPlain, DataRow[] addendum)
        {
            string result = string.Empty;

            if (Utilities.HasData(addendum))
            {
                int length = addendum.Length;
                int counter = 0;

                result = string.Empty;

                for (int i = 0; i < length; length--)
                {
                    DataRow dr = addendum[counter++];

                    result += string.Format("Addendum {0} ", length.ToString());
                    result += string.Format("Written By {0} ", dr["Radiologist"].ToString());
                    result += string.Format("Date {0:dd/MM/yyyy HH:mm}", Convert.ToDateTime(dr["NOTE_ON"]));
                    result += " ~ ";
                    result += dr["RESULT_TEXT"].ToString();
                    result += " ~ ";
                    result += " ~ ";
                }

                result += " ~ ";
                result += "-------------------------";
                result += " ~ ";
                result += " ~ ";
                result += " ~ ";
            }

            result += resultPlain;

            return result.Replace("\r\n", " ~ ").Replace("\n", " ~ ").Replace("\r", " ~ ");
        }
    }
}