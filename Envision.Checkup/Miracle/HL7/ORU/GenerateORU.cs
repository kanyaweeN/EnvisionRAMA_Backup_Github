using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Model.V23;
using NHapi.Model.V23.Message;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;

namespace Miracle.HL7.ORU
{
    public class GenerateORU
    {
        public DataTable createMessage(DataTable dtoru)
        {
            DataTable dtMSG = new DataTable();
            dtMSG.Columns.Add("ACCESSION_NO");
            dtMSG.Columns.Add("HL7_TXT");

            ORU_R01 oru = new ORU_R01();
            oru.MSH.MessageType.MessageType.Value = "ORU";
            oru.MSH.MessageType.TriggerEvent.Value = "R01";
            oru.MSH.EncodingCharacters.Value = @"^~\&";
            oru.MSH.VersionID.Value = "2.3";

            oru.GetRESPONSE().PATIENT.PID.GetPatientIDInternalID(0).ID.Value = dtoru.Rows[0]["HN"].ToString();
            oru.GetRESPONSE().PATIENT.PID.PatientName.FamilyName.Value = dtoru.Rows[0]["FNAME"].ToString();
            oru.GetRESPONSE().PATIENT.PID.PatientName.MiddleInitialOrName.Value = dtoru.Rows[0]["MNAME"].ToString();
            oru.GetRESPONSE().PATIENT.PID.PatientName.GivenName.Value = dtoru.Rows[0]["LNAME"].ToString();
            //oru.GetRESPONSE().PATIENT.PID.PatientName.GivenName.Value = dtoru.Rows[0]["THFNAME"].ToString() + " " + dtoru.Rows[0]["THMNAME"].ToString();
            oru.GetRESPONSE().PATIENT.PID.GetPatientAlias(0).FamilyName.Value = dtoru.Rows[0]["THFNAME"].ToString() + " " + dtoru.Rows[0]["THMNAME"].ToString();
            string pdate = dtoru.Rows[0]["DOB"].ToString().Trim();
            if (pdate == "")
            {
            }
            else
            {
                DateTime birthDate2 = Convert.ToDateTime(Convert.ToDateTime(pdate).ToShortDateString());
                if (birthDate2 != DateTime.MinValue)
                    oru.GetRESPONSE().PATIENT.PID.DateOfBirth.TimeOfAnEvent.setDatePrecision(birthDate2.Year, birthDate2.Month, birthDate2.Day);
                //oru.GetRESPONSE().PATIENT.PID.DateOfBirth.TimeOfAnEvent.SetShortDate(birthDate2);
            }
            oru.GetRESPONSE().PATIENT.PID.Sex.Value = dtoru.Rows[0]["GENDER"].ToString();
            oru.GetRESPONSE().PATIENT.PID.GetPhoneNumberHome(0).Value = dtoru.Rows[0]["PHONE"].ToString();
            oru.GetRESPONSE().PATIENT.PID.GetPatientAddress(0).StateOrProvince.Value = dtoru.Rows[0]["ADDRESS"].ToString();


            oru.GetRESPONSE(0).GetORDER_OBSERVATION().ORC.OrderControl.Value = "SC";
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().ORC.GetPlacerOrderNumber(0).EntityIdentifier.Value = dtoru.Rows[0]["ORDNO"].ToString();

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.ResultStatus.Value = dtoru.Rows[0]["STATUS"].ToString();
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.UniversalServiceIdentifier.Identifier.Value = dtoru.Rows[0]["EXAM_ID"].ToString();
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.UniversalServiceIdentifier.Text.Value = dtoru.Rows[0]["EXAM_NAME"].ToString();
            oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetPlacerOrderNumber(0).EntityIdentifier.Value = dtoru.Rows[0]["ACCESSION_NO"].ToString();

            oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.SetIDOBX.Value = "1";
            oru.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ValueType.Value = "TX";
            oru.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ObservResultStatus.Value = dtoru.Rows[0]["STATUS"].ToString();

            NHapi.Base.Model.Varies v2 = oru.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.GetObservationValue(0);

            //ST text = new ST(oru);
            //text.Value = dtoru.Rows[0]["HL7TXT"].ToString();
            //v2.Data = text;


            ////oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            ////oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";

            //PipeParser parser = new PipeParser();
            //string hl7 = parser.Encode(oru);
            //dtMSG.Rows.Add(dtoru.Rows[0]["ACCESSION_NO"].ToString(), hl7);
            //return dtMSG;

            ST text = new ST(oru);
            text.Value = dtoru.Rows[0]["HL7TXT"].ToString().Replace("&", "#and#;");
            v2.Data = text;


            //oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).GetOBSERVATION(0).OBX.ValueType.Value = "FT";
            //oru.GetPATIENT_RESULT(0).GetORDER_OBSERVATION(0).OBR.SetIDOBR.Value = "1";

            PipeParser parser = new PipeParser();
            string hl7 = parser.Encode(oru);
            hl7 = hl7.Replace("#and#;", "&");
            dtMSG.Rows.Add(dtoru.Rows[0]["ACCESSION_NO"].ToString(), hl7);
            return dtMSG;
        }
    }
}
