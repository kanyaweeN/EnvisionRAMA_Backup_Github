using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Base;
using NHapi.Model.V23;
using NHapi.Model.V23.Message;
using NHapi.Model.V23.Segment;
using NHapi.Model.V23.Datatype;

public class CreateMessageORU
{
    public DataTable HL7Message(Patient patdemo, ResultItems items, string CreateName)
    {
        DataTable dtMSG = new DataTable();
        dtMSG.Columns.Add("ACCESSION_NO");
        dtMSG.Columns.Add("HL7_TXT");

        ORU_R01 oru = new ORU_R01();
        oru.MSH.MessageType.MessageType.Value = "ORU";
        oru.MSH.MessageType.TriggerEvent.Value = "R01";
        oru.MSH.EncodingCharacters.Value = @"^~\&";
        oru.MSH.VersionID.Value = "2.3";

        oru.GetRESPONSE().PATIENT.PID.GetPatientIDInternalID(0).ID.Value = patdemo.HN;
        oru.GetRESPONSE().PATIENT.PID.PatientName.FamilyName.Value = patdemo.FirstNameEng;
        oru.GetRESPONSE().PATIENT.PID.PatientName.MiddleInitialOrName.Value = patdemo.MiddleNameEng;
        oru.GetRESPONSE().PATIENT.PID.PatientName.GivenName.Value = patdemo.LastNameEng;

        string[] arryPatientName = patdemo.FirstName.Trim().Split(' ');
        string fnameTH = "";
        string lnameTH = "";
        if (arryPatientName.Length > 1)
        {
            if (!string.IsNullOrEmpty(arryPatientName[0].Trim()))
                fnameTH = arryPatientName[0].Trim();
            if (!string.IsNullOrEmpty(arryPatientName[1].Trim()))
                lnameTH = arryPatientName[1].Trim();
        }
        oru.GetRESPONSE().PATIENT.PID.GetPatientAlias(0).FamilyName.Value = string.IsNullOrEmpty(fnameTH) ? patdemo.FirstName : fnameTH;
        oru.GetRESPONSE().PATIENT.PID.GetPatientAlias(0).GivenName.Value = string.IsNullOrEmpty(lnameTH) ? patdemo.LastName : lnameTH;

        string pdate = patdemo.DOB.ToString();
        if (pdate == "")
        {
        }
        else
        {
            DateTime birthDate2 = Convert.ToDateTime(Convert.ToDateTime(pdate).ToShortDateString());
            oru.GetRESPONSE().PATIENT.PID.DateOfBirth.TimeOfAnEvent.SetShortDate(birthDate2);
        }
        oru.GetRESPONSE().PATIENT.PID.Sex.Value = patdemo.Gender;
        oru.GetRESPONSE().PATIENT.PID.GetPhoneNumberHome(0).Value = patdemo.Phone;
        oru.GetRESPONSE().PATIENT.PID.GetPatientAddress(0).StateOrProvince.Value = patdemo.Address;


        oru.GetRESPONSE(0).GetORDER_OBSERVATION().ORC.OrderControl.Value = "SC";
        oru.GetRESPONSE(0).GetORDER_OBSERVATION().ORC.GetPlacerOrderNumber(0).EntityIdentifier.Value = items.Order_ID.ToString();

        oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.ResultStatus.Value = items.Status;
        oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.UniversalServiceIdentifier.Identifier.Value = items.ExamCode;
        oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.UniversalServiceIdentifier.Text.Value = items.ExamName;
        oru.GetRESPONSE(0).GetORDER_OBSERVATION().OBR.GetPlacerOrderNumber(0).EntityIdentifier.Value = items.ACCESSION_NO;

        oru.GetRESPONSE(0).GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.SetIDOBX.Value = "1";
        oru.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ValueType.Value = "TX";
        oru.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.ObservResultStatus.Value = items.Status;

        NHapi.Base.Model.Varies v2 = oru.GetRESPONSE().GetORDER_OBSERVATION().GetOBSERVATION(0).OBX.GetObservationValue(0);
        ST text = new ST(oru);
        text.Value = items.HL7Text.Replace("&", "#and#;");
        v2.Data = text;

        PipeParser parser = new PipeParser();
        string hl7 = parser.Encode(oru);
        hl7 = hl7.Replace("#and#;", "&");
        dtMSG.Rows.Add(items.ACCESSION_NO, hl7);
        return dtMSG;
    }
}
