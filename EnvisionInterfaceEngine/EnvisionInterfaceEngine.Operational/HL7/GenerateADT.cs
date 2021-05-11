using System;
using System.Data;
using System.Globalization;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Common.Miracle;
using NHapi.Base.Parser;
using NHapi.Model.V23.Message;

namespace EnvisionInterfaceEngine.Operational.HL7
{
    public class GenerateADT
    {
        private const string title_log = "EnvisionInterfaceEngine.Operational.HL7.GenerateADT";

        public static string GenerateHL7(HL7ADT data)
        {
            ADT_A08 adt = new ADT_A08();

            adt.MSH.SendingApplication.NamespaceID.Value = data.MSH.SENDING_APPLICATION;
            adt.MSH.SendingFacility.NamespaceID.Value = data.ORG.ORG_ALIAS;
            adt.MSH.ReceivingApplication.NamespaceID.Value = data.MSH.RECEIVING_APPLICATION;
            adt.MSH.DateTimeOfMessage.TimeOfAnEvent.Value = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            adt.MSH.MessageControlID.Value = data.MSH.MESSAGE_CONTROL_ID;
            adt.MSH.ProcessingID.ProcessingID.Value = data.MSH.PROCESSING_ID;
            adt.MSH.VersionID.Value = data.MSH.VERSION_ID;

            adt.PID.PatientIDExternalID.ID.Value = data.PATIENT.EXT_HN;
            adt.PID.GetPatientIDInternalID(0).ID.Value = data.PATIENT.HN;
            adt.PID.AlternatePatientID.ID.Value = data.PATIENT.HIS_HN;

            adt.PID.PatientName.PrefixEgDR.Value = data.PATIENT.TITLE_ENG;
            adt.PID.PatientName.FamilyName.Value = data.PATIENT.FNAME_ENG;
            adt.PID.PatientName.GivenName.Value = data.PATIENT.LNAME_ENG;

            adt.PID.GetPatientAlias(0).PrefixEgDR.Value = data.PATIENT.TITLE;
            adt.PID.GetPatientAlias(0).FamilyName.Value = data.PATIENT.FNAME;
            adt.PID.GetPatientAlias(0).GivenName.Value = data.PATIENT.LNAME;

            if (data.PATIENT.GENDER != char.MinValue)
                adt.PID.Sex.Value = data.PATIENT.GENDER.ToString();

            if (data.PATIENT.DOB != null && data.PATIENT.DOB != DateTime.MinValue)
                adt.PID.DateOfBirth.TimeOfAnEvent.Value = data.PATIENT.DOB.ToString("yyyyMMdd", CultureInfo.GetCultureInfo("en-US"));

            adt.PID.SSNNumberPatient.Value = data.PATIENT.SSN;
            adt.PID.GetPatientAddress(0).StateOrProvince.Value = data.PATIENT.ADDR1 + data.PATIENT.ADDR2 + data.PATIENT.ADDR3 + data.PATIENT.ADDR4 + data.PATIENT.ADDR5;
            adt.PID.GetPhoneNumberHome(0).Value = data.PATIENT.PHONE1;
            adt.PID.GetPhoneNumberBusiness(0).Value = data.PATIENT.PHONE2;

            return HL7Manager.decodeAlphanumeric(new PipeParser().Encode(adt));
        }
        public static string GenerateHL7Reconcile(HL7ADT data, string oldHn)
        {
            ADT_A18 adt = new ADT_A18();

            adt.MSH.SendingApplication.NamespaceID.Value = data.MSH.SENDING_APPLICATION;
            adt.MSH.SendingFacility.NamespaceID.Value = data.ORG.ORG_ALIAS;
            adt.MSH.MessageControlID.Value = data.MSH.MESSAGE_CONTROL_ID;
            adt.MSH.ProcessingID.ProcessingID.Value = data.MSH.PROCESSING_ID;
            adt.MSH.VersionID.Value = data.MSH.VERSION_ID;

            adt.PID.PatientIDExternalID.ID.Value = data.PATIENT.EXT_HN;
            adt.PID.GetPatientIDInternalID(0).ID.Value = data.PATIENT.HN;
            adt.PID.AlternatePatientID.ID.Value = data.PATIENT.HIS_HN;

            adt.PID.PatientName.PrefixEgDR.Value = data.PATIENT.TITLE_ENG;
            adt.PID.PatientName.FamilyName.Value = data.PATIENT.FNAME_ENG;
            adt.PID.PatientName.GivenName.Value = data.PATIENT.LNAME_ENG;

            adt.PID.GetPatientAlias(0).PrefixEgDR.Value = data.PATIENT.TITLE;
            adt.PID.GetPatientAlias(0).FamilyName.Value = data.PATIENT.FNAME;
            adt.PID.GetPatientAlias(0).GivenName.Value = data.PATIENT.LNAME;

            if (data.PATIENT.GENDER != char.MinValue)
                adt.PID.Sex.Value = data.PATIENT.GENDER.ToString();

            if (data.PATIENT.DOB != null && data.PATIENT.DOB != DateTime.MinValue)
                adt.PID.DateOfBirth.TimeOfAnEvent.Value = data.PATIENT.DOB.ToString("yyyyMMdd", CultureInfo.GetCultureInfo("en-US"));

            adt.PID.SSNNumberPatient.Value = data.PATIENT.SSN;
            adt.PID.GetPatientAddress(0).StateOrProvince.Value = data.PATIENT.ADDR1 + data.PATIENT.ADDR2 + data.PATIENT.ADDR3 + data.PATIENT.ADDR4 + data.PATIENT.ADDR5;
            adt.PID.GetPhoneNumberHome(0).Value = data.PATIENT.PHONE1;
            adt.PID.GetPhoneNumberBusiness(0).Value = data.PATIENT.PHONE2;

            adt.MRG.GetPriorPatientIDInternal(0).ID.Value = oldHn;

            return HL7Manager.decodeAlphanumeric(new PipeParser().Encode(adt));
        }

        public static void ConvertToHL7(DataTable data)
        {
            if (Utilities.HasData(data))
            {
                if (data.Columns.IndexOf("HL7_TEXT") < 0)
                    data.Columns.Add("HL7_TEXT", typeof(string));
                data.AcceptChanges();

                foreach (DataRow row in data.Rows)
                    row["HL7_TEXT"] = GenerateHL7(ConvertToObject(row));
                data.AcceptChanges();
            }
        }
        public static void ConvertToHL7Reconcile(DataTable data, string oldHn)
        {
            if (Utilities.HasData(data))
            {
                if (data.Columns.IndexOf("HL7_TEXT") < 0)
                    data.Columns.Add("HL7_TEXT", typeof(string));
                data.AcceptChanges();

                foreach (DataRow row in data.Rows)
                    row["HL7_TEXT"] = GenerateHL7Reconcile(ConvertToObject(row), oldHn);
                data.AcceptChanges();
            }
        }

        public static HL7ADT ConvertToObject(DataRow data)
        {
            HL7ADT hl7_adt = new HL7ADT();

            hl7_adt.MSH.SENDING_APPLICATION = data["SendingApplication"].ToString();
            hl7_adt.MSH.RECEIVING_APPLICATION = data["ReceivingApplication"].ToString();

            hl7_adt.ORG.ORG_ALIAS = data["ORG_ALIAS"].ToString();

            hl7_adt.PATIENT.EXT_HN = data["EXT_HN"].ToString();
            hl7_adt.PATIENT.HN = data["HN"].ToString();
            hl7_adt.PATIENT.HIS_HN = data["HIS_HN"].ToString();
            hl7_adt.PATIENT.TITLE = data["PATIENT_TITLE"].ToString();
            hl7_adt.PATIENT.FNAME = data["PATIENT_FNAME"].ToString();
            hl7_adt.PATIENT.LNAME = data["PATIENT_LNAME"].ToString();
            hl7_adt.PATIENT.TITLE_ENG = data["PATIENT_TITLE_ENG"].ToString();
            hl7_adt.PATIENT.FNAME_ENG = data["PATIENT_FNAME_ENG"].ToString();
            hl7_adt.PATIENT.LNAME_ENG = data["PATIENT_LNAME_ENG"].ToString();
            hl7_adt.PATIENT.GENDER = Utilities.ToChar(data["PATIENT_GENDER"].ToString(), 'O');
            hl7_adt.PATIENT.DOB = Utilities.ToDateTime(data["PATIENT_DOB"]);
            hl7_adt.PATIENT.SSN = data["PATIENT_SSN"].ToString();
            hl7_adt.PATIENT.ADDR1 = data["PATIENT_ADDR1"].ToString();
            hl7_adt.PATIENT.ADDR2 = data["PATIENT_ADDR2"].ToString();
            hl7_adt.PATIENT.ADDR3 = data["PATIENT_ADDR3"].ToString();
            hl7_adt.PATIENT.ADDR4 = data["PATIENT_ADDR4"].ToString();
            hl7_adt.PATIENT.ADDR5 = data["PATIENT_ADDR5"].ToString();
            hl7_adt.PATIENT.PHONE1 = data["PATIENT_PHONE1"].ToString();
            hl7_adt.PATIENT.PHONE2 = data["PATIENT_PHONE2"].ToString();

            return hl7_adt;
        }
        public static HL7ADT ConvertToObject(ADT_A08 value)
        {
            HL7ADT hl7_adt = new HL7ADT();

            try
            {
                hl7_adt.MSH.SENDING_APPLICATION = value.MSH.SendingApplication.NamespaceID.Value;
                hl7_adt.MSH.MESSAGE_CONTROL_ID = value.MSH.MessageControlID.Value;

                hl7_adt.ORG.ORG_ALIAS = value.MSH.SendingFacility.NamespaceID.Value;

                hl7_adt.PATIENT.EXT_HN = value.PID.PatientIDExternalID.ID.Value;
                hl7_adt.PATIENT.HN = value.PID.GetPatientIDInternalID(0).ID.Value;
                hl7_adt.PATIENT.HIS_HN = value.PID.AlternatePatientID.ID.Value;

                hl7_adt.PATIENT.TITLE = value.PID.GetPatientAlias(0).PrefixEgDR.Value;
                hl7_adt.PATIENT.FNAME = value.PID.GetPatientAlias(0).FamilyName.Value;
                hl7_adt.PATIENT.LNAME = string.Format("{0} {1} {2}",
                    value.PID.GetPatientAlias(0).GivenName.Value,
                    value.PID.GetPatientAlias(0).MiddleInitialOrName.Value,
                    value.PID.GetPatientAlias(0).SuffixEgJRorIII.Value).Trim();

                hl7_adt.PATIENT.TITLE_ENG = value.PID.PatientName.PrefixEgDR.Value;
                hl7_adt.PATIENT.FNAME_ENG = value.PID.PatientName.FamilyName.Value;
                hl7_adt.PATIENT.LNAME_ENG = string.Format("{0} {1} {2}",
                    value.PID.PatientName.GivenName.Value,
                    value.PID.PatientName.MiddleInitialOrName.Value,
                    value.PID.PatientName.SuffixEgJRorIII.Value).Trim();

                hl7_adt.PATIENT.GENDER = Utilities.ToChar(value.PID.Sex.Value, 'O');
                hl7_adt.PATIENT.DOB = value.PID.DateOfBirth.TimeOfAnEvent.GetAsDate();
                hl7_adt.PATIENT.SSN = value.PID.SSNNumberPatient.Value;
                using (MIStringArray mi_address = new MIStringArray(HL7Manager.ConvertObjectToText(value.PID.GetPatientAddress(0))))
                {
                    hl7_adt.PATIENT.ADDR1 = mi_address[0];
                    hl7_adt.PATIENT.ADDR2 = mi_address[1];
                    hl7_adt.PATIENT.ADDR3 = mi_address[2];
                    hl7_adt.PATIENT.ADDR4 = mi_address[3];
                    hl7_adt.PATIENT.ADDR5 = mi_address[4];
                }
                hl7_adt.PATIENT.PHONE1 = value.PID.GetPhoneNumberHome(0).Value;
                hl7_adt.PATIENT.PHONE2 = value.PID.GetPhoneNumberBusiness(0).Value;
            }
            catch (Exception ex)
            {
                hl7_adt = null;

                Utilities.SaveLog(title_log, "ConvertToObject(ADT_A08 data)", ex.Message, true);
            }

            return hl7_adt;
        }
        public static HL7ADT ConvertToObject(ADT_A18 value)
        {
            HL7ADT hl7_adt = new HL7ADT();

            try
            {
                hl7_adt.MSH.SENDING_APPLICATION = value.MSH.SendingApplication.NamespaceID.Value;
                hl7_adt.MSH.MESSAGE_CONTROL_ID = value.MSH.MessageControlID.Value;

                hl7_adt.ORG.ORG_ALIAS = value.MSH.SendingFacility.NamespaceID.Value;

                hl7_adt.PATIENT.EXT_HN = value.PID.PatientIDExternalID.ID.Value;
                hl7_adt.PATIENT.HN = value.PID.GetPatientIDInternalID(0).ID.Value;
                hl7_adt.PATIENT.HIS_HN = value.PID.AlternatePatientID.ID.Value;

                hl7_adt.PATIENT.TITLE = value.PID.GetPatientAlias(0).PrefixEgDR.Value;
                hl7_adt.PATIENT.FNAME = value.PID.GetPatientAlias(0).FamilyName.Value;
                hl7_adt.PATIENT.LNAME = string.Format("{0} {1} {2}",
                    value.PID.GetPatientAlias(0).GivenName.Value,
                    value.PID.GetPatientAlias(0).MiddleInitialOrName.Value,
                    value.PID.GetPatientAlias(0).SuffixEgJRorIII.Value).Trim();

                hl7_adt.PATIENT.TITLE_ENG = value.PID.PatientName.PrefixEgDR.Value;
                hl7_adt.PATIENT.FNAME_ENG = value.PID.PatientName.FamilyName.Value;
                hl7_adt.PATIENT.LNAME_ENG = string.Format("{0} {1} {2}",
                    value.PID.PatientName.GivenName.Value,
                    value.PID.PatientName.MiddleInitialOrName.Value,
                    value.PID.PatientName.SuffixEgJRorIII.Value).Trim();

                hl7_adt.PATIENT.GENDER = Utilities.ToChar(value.PID.Sex.Value, 'O');
                hl7_adt.PATIENT.DOB = value.PID.DateOfBirth.TimeOfAnEvent.GetAsDate();
                hl7_adt.PATIENT.SSN = value.PID.SSNNumberPatient.Value;
                using (MIStringArray mi_address = new MIStringArray(HL7Manager.ConvertObjectToText(value.PID.GetPatientAddress(0))))
                {
                    hl7_adt.PATIENT.ADDR1 = mi_address[0];
                    hl7_adt.PATIENT.ADDR2 = mi_address[1];
                    hl7_adt.PATIENT.ADDR3 = mi_address[2];
                    hl7_adt.PATIENT.ADDR4 = mi_address[3];
                    hl7_adt.PATIENT.ADDR5 = mi_address[4];
                }
                hl7_adt.PATIENT.PHONE1 = value.PID.GetPhoneNumberHome(0).Value;
                hl7_adt.PATIENT.PHONE2 = value.PID.GetPhoneNumberBusiness(0).Value;

                hl7_adt.OLD_PATIENT.HIS_HN = value.MRG.GetPriorAlternatePatientID(0).ID.Value;
                hl7_adt.OLD_PATIENT.HN = value.MRG.GetPriorPatientIDInternal(0).ID.Value;
                if (string.IsNullOrEmpty(hl7_adt.OLD_PATIENT.HIS_HN)) hl7_adt.OLD_PATIENT.HIS_HN = hl7_adt.OLD_PATIENT.HN;
            }
            catch (Exception ex)
            {
                hl7_adt = null;

                Utilities.SaveLog(title_log, "ConvertToObject(ADT_A18 data)", ex.Message, true);
            }

            return hl7_adt;
        }
    }
}