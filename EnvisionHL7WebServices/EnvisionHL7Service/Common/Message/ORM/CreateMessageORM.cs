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
/// <summary>
/// Summary description for CreateMessageORM
/// </summary>
public class CreateMessageORM
{
    public DataTable HL7Message(Patient patdemo, OrderItems[] dtord, string CreateName)
    {
        DataTable msg = new DataTable();
        msg.Columns.Add("ACCESSION_NO", typeof(string));
        msg.Columns.Add("HL7_TXT", typeof(string));
        ORM_O01 orm = new ORM_O01();
        orm.MSH.SendingApplication.UniversalID.Value = "RIS FUSION";

        orm.PATIENT.PID.GetPatientIDInternalID(0).ID.Value = patdemo.HN;
        orm.PATIENT.PID.PatientName.FamilyName.Value = patdemo.FirstNameEng;
        orm.PATIENT.PID.PatientName.GivenName.Value = patdemo.LastNameEng;
        orm.PATIENT.PID.PatientName.MiddleInitialOrName.Value = patdemo.MiddleNameEng;

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
        orm.PATIENT.PID.GetPatientAlias(0).FamilyName.Value = string.IsNullOrEmpty(fnameTH) ? patdemo.FirstName : fnameTH;
        orm.PATIENT.PID.GetPatientAlias(0).GivenName.Value = string.IsNullOrEmpty(lnameTH) ? patdemo.LastName : lnameTH;

        orm.PATIENT.PID.DateOfBirth.TimeOfAnEvent.setDatePrecision(patdemo.DOB.Year, patdemo.DOB.Month, patdemo.DOB.Day);
        orm.PATIENT.PID.Sex.Value = patdemo.Gender;
        orm.PATIENT.PID.GetPhoneNumberHome(0).Value = patdemo.Phone;
        orm.PATIENT.PID.GetPatientAddress(0).StateOrProvince.Value = patdemo.Address;

        orm.PATIENT.PATIENT_VISIT.PV1.PatientClass.Value = "I";

        orm.PATIENT.PATIENT_VISIT.PV1.AssignedPatientLocation.PointOfCare.Value = patdemo.DepartmentName;
        orm.PATIENT.PATIENT_VISIT.PV1.AssignedPatientLocation.Room.Value = patdemo.DepartmentName;
        orm.PATIENT.PATIENT_VISIT.PV1.AttendingDoctor.IDNumber.Value = patdemo.DoctorName;
        orm.PATIENT.PATIENT_VISIT.PV1.AttendingDoctor.FamilyName.Value = patdemo.DoctorName;
        orm.PATIENT.PATIENT_VISIT.PV1.ReferringDoctor.IDNumber.Value = patdemo.DoctorName;

        orm.PATIENT.PATIENT_VISIT.PV1.ReferringDoctor.FamilyName.Value = patdemo.DoctorName;
        orm.PATIENT.PATIENT_VISIT.PV1.TemporaryLocation.PointOfCare.Value = patdemo.DepartmentName;


        orm.GetORDER().ORC.EnteredBy.FamilyName.Value = CreateName;

        for (int i = 0; i < dtord.Length; i++) {
            orm.PATIENT.PATIENT_VISIT.PV1.VisitNumber.ID.Value = dtord[i].ACCESSION_NO;//visit number in sysnape
            orm.GetORDER().ORC.OrderControl.Value = dtord[i].Flag;
            orm.GetORDER().ORC.GetPlacerOrderNumber(0).EntityIdentifier.Value = dtord[i].Order_ID.ToString();
            orm.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Identifier.Value = dtord[i].ExamCode;
            orm.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Text.Value = dtord[i].ExamName;
            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).IDNumber.Value = patdemo.DoctorName;
            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).FamilyName.Value = patdemo.DoctorName;
            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).AssigningFacilityID.NamespaceID.Value = patdemo.DepartmentName;
            orm.GetORDER().ORDER_DETAIL.OBR.GetPlacerOrderNumber(0).EntityIdentifier.Value = dtord[i].ACCESSION_NO;
            orm.GetORDER().ORDER_DETAIL.OBR.QuantityTiming.Priority.Value = dtord[i].Priority;
            PipeParser parser = new PipeParser();
            string hl7 = parser.Encode(orm);
            DataRow dr = msg.NewRow();
            dr[0] = dtord[i].ACCESSION_NO;
            dr[1] = hl7;
            msg.Rows.Add(dr);
        }
        return msg;
    }

}
