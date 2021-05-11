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
namespace Miracle.HL7.ORM
{
    public class GenerateORM
    {
        public DataTable ORMMessage(PatientHL7 patdemo, DataTable dtord)
        {
            DataTable msg = new DataTable();
            msg.Columns.Add("ACCESSION_NO", typeof(string));
            msg.Columns.Add("HL7_TXT", typeof(string));
            ORM_O01 orm = new ORM_O01();

            orm.MSH.SendingApplication.UniversalID.Value = "RIS FUSION";

            orm.PATIENT.PID.GetPatientIDInternalID(0).ID.Value = patdemo.HN;// "HN";
            orm.PATIENT.PID.PatientName.FamilyName.Value = patdemo.FirstEnglishName;//"PATIENT NAME en";
            orm.PATIENT.PID.PatientName.GivenName.Value = patdemo.LastEnglishame;
            orm.PATIENT.PID.PatientName.MiddleInitialOrName.Value = patdemo.MiddleEnglishName;
            orm.PATIENT.PID.GetPatientAlias(0).FamilyName.Value = patdemo.FirstThaiName + " " + patdemo.MiddleThaiName + " " + patdemo.LastThaiName;//"PATIENT NAME th";
            //orm.PATIENT.PID.DateOfBirth.TimeOfAnEvent.SetShortDate(patdemo.DateOfBirth);//"DATE OF BIRTH";
            if(patdemo.DateOfBirth!=DateTime.MinValue)
                orm.PATIENT.PID.DateOfBirth.TimeOfAnEvent.setDatePrecision(patdemo.DateOfBirth.Year, patdemo.DateOfBirth.Month, patdemo.DateOfBirth.Day);
            orm.PATIENT.PID.Sex.Value = patdemo.Gender;//"GENDER";
            orm.PATIENT.PID.GetPhoneNumberHome(0).Value = patdemo.Phone;//"PHONE";
            orm.PATIENT.PID.GetPatientAddress(0).StateOrProvince.Value = patdemo.Address;//"BANGKOK";


            orm.PATIENT.PATIENT_VISIT.PV1.PatientClass.Value = "I";

            orm.PATIENT.PATIENT_VISIT.PV1.AssignedPatientLocation.PointOfCare.Value = patdemo.DepartmentName;
            orm.PATIENT.PATIENT_VISIT.PV1.AssignedPatientLocation.Room.Value = patdemo.DepartmentName;
            orm.PATIENT.PATIENT_VISIT.PV1.AttendingDoctor.IDNumber.Value = patdemo.DoctorName;
            orm.PATIENT.PATIENT_VISIT.PV1.AttendingDoctor.FamilyName.Value = patdemo.DoctorName;
            orm.PATIENT.PATIENT_VISIT.PV1.ReferringDoctor.IDNumber.Value = patdemo.DoctorName;// patdemo.REF_DOC_INSTRUCTION;

            //orm.PATIENT.PATIENT_VISIT.PV1.ReferringDoctor.DegreeEgMD.Value = "Dr.";
            orm.PATIENT.PATIENT_VISIT.PV1.ReferringDoctor.FamilyName.Value = patdemo.DoctorName;// patdemo.REF_DOC_INSTRUCTION;
            orm.PATIENT.PATIENT_VISIT.PV1.TemporaryLocation.PointOfCare.Value = patdemo.DepartmentName;// patdemo.REFER_FROM;
            orm.PATIENT.PATIENT_VISIT.PV1.VisitNumber.ID.Value = dtord.Rows[0]["ACCESSION_NO"].ToString().Trim();


            //orm.GetORDER().ORC.OrderControl.Value = ordflag;
            //orm.GetORDER().ORC.OrderStatus.Value = "NW";
            orm.GetORDER().ORC.EnteredBy.FamilyName.Value = patdemo.OperatorName;//"Operator Name";
            //orm.GetORDER().ORC.GetOrderingProvider(0).IDNumber.Value = patdemo.Doctor_Name;//patdemo.REF_DOC_INSTRUCTION;
            //orm.GetORDER().ORC.GetOrderingProvider(0).FamilyName.Value = patdemo.Doctor_Name;//patdemo.REF_DOC_INSTRUCTION;//"Radio";
            // orm.GetORDER().ORC.EntererSLocation.PointOfCare.Value = patdemo.Department_Name;//patdemo.REFER_FROM;//"DEPARTMNT";
            for (int i = 0; i < dtord.Rows.Count; i++)
            {
                orm.GetORDER().ORC.OrderControl.Value = dtord.Rows[i]["ordflag"].ToString();
                orm.GetORDER().ORC.GetPlacerOrderNumber(0).EntityIdentifier.Value = dtord.Rows[0]["ORDER_ID"].ToString().Trim();//dtord.Rows[i]["ACCESSION_NO"].ToString().Trim();//"434343434111125";

                orm.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Identifier.Value = dtord.Rows[i]["EXAM_UID"].ToString().Trim();//"3333";
                orm.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Text.Value = dtord.Rows[i]["EXAM_NAME"].ToString().Trim();//"abc";
                orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).IDNumber.Value = patdemo.DoctorName;//patdemo.REF_DOC_INSTRUCTION;
                orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).FamilyName.Value = patdemo.DoctorName;// patdemo.REF_DOC_INSTRUCTION;//"Adisorn";
                orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).AssigningFacilityID.NamespaceID.Value = patdemo.DepartmentName;
                orm.GetORDER().ORDER_DETAIL.OBR.GetPlacerOrderNumber(0).EntityIdentifier.Value = dtord.Rows[i]["ACCESSION_NO"].ToString().Trim();//"434343434111125";
                orm.GetORDER().ORDER_DETAIL.OBR.QuantityTiming.Priority.Value = dtord.Rows[i]["PRIORITY"].ToString().Trim();
                PipeParser parser = new PipeParser();
                string hl7 = parser.Encode(orm);
                DataRow dr = msg.NewRow();
                dr[0] = dtord.Rows[i]["ACCESSION_NO"].ToString().Trim();
                dr[1] = hl7;
                msg.Rows.Add(dr);


            }
            return msg;
        }
    }
}
