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

namespace Miracle.HL7.ADT
{
    public class GenerateADT
    {
        public DataTable createMessage(PatientHL7 patdemo, DataTable dtord)
        {
            if (dtord != null)
            {
                DataTable msg = new DataTable();
                msg.Columns.Add("ACCESSION_NO", typeof(string));
                msg.Columns.Add("HL7_TXT", typeof(string));
                //ADT_A34 _adt = new ADT_A34();
                ADT_A18 _adt = new ADT_A18();

                _adt.MSH.FieldSeparator.Value = "|";
                _adt.MSH.DateTimeOfMessage.TimeOfAnEvent.setDateMinutePrecision(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute);
                _adt.MSH.SendingApplication.NamespaceID.Value = "REGADT";
                _adt.MSH.SequenceNumber.Value = "123";
                _adt.MSH.MessageType.MessageType.Value = "ADT";
                _adt.MSH.MessageType.TriggerEvent.Value = "A18";
                _adt.MSH.EncodingCharacters.Value = @"^~\&";
                _adt.MSH.VersionID.Value = "2.3";
                _adt.MSH.SendingApplication.UniversalID.Value = "RIS FUSION";
                //_adt.MSH.MessageControlID.Value = "MESSAGE001";
                _adt.MSH.ProcessingID.ProcessingID.Value = "P";
                _adt.EVN.EventTypeCode.Value = "A18";
                _adt.EVN.RecordedDateTime.TimeOfAnEvent.setDateMinutePrecision(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute);// = "200901051530";//current date time


                _adt.PID.GetPatientIDInternalID(0).ID.Value = dtord.Rows[0]["HN"].ToString(); //HN

                _adt.PID.PatientName.FamilyName.Value = dtord.Rows[0]["THAI_NAME"].ToString();//"Unspecified, Pat_2010.03.12.16.05";//patdemo.FirstName_ENG + " " + patdemo.MiddleName_ENG + " " + patdemo.LastName_ENG;//"PATIENT NAME en";
                //orm.PATIENT.PID.PatientName.GivenName.Value =patdemo.FirstName + " " + patdemo.MiddleName + " " + patdemo.LastName;//"PATIENT NAME th";
                _adt.PID.GetPatientAlias(0).FamilyName.Value = dtord.Rows[0]["ENG_NAME"].ToString();//"Unspecified, Pat_2010.03.12.16.05";//patdemo.FirstName + " " + patdemo.MiddleName + " " + patdemo.LastName;//"PATIENT NAME th";
                //_adt.PID.DateOfBirth.TimeOfAnEvent.SetShortDate("1979/10/11");//"DATE OF BIRTH";
                _adt.PID.Sex.Value = dtord.Rows[0]["GENDER"].ToString();//"M";//"GENDER";
                _adt.PID.GetPhoneNumberHome(0).Value = dtord.Rows[0]["PHONE"].ToString();//"08929292";//"PHONE";
                _adt.PID.GetPatientAddress(0).StateOrProvince.Value = dtord.Rows[0]["ADDR3"].ToString();//"Bangkok";//"BANGKOK";
                _adt.PID.PatientAccountNumber.ID.Value = dtord.Rows[0]["THAI_NAME"].ToString() + "<cr>";//marge with HN 

                _adt.MRG.GetPriorPatientIDInternal(0).ID.Value = patdemo.HN;//"255708";//pat to be marge HN
                _adt.MRG.PriorPatientAccountNumber.ID.Value = patdemo.HN +"<cr>";//pat to be marge HN

                PipeParser parser = new PipeParser();
                string hl7 = parser.Encode(_adt);

                DataRow drr = msg.NewRow();
                drr[0] = "ADT_MESSAGE";// dtord.Rows[0]["ACCESSION_NO"].ToString().Trim();
                drr[1] = hl7;
                msg.Rows.Add(drr);
                msg.AcceptChanges();
                return msg;
            }
            else
            {
                return null;
            }
        }
    }
}
