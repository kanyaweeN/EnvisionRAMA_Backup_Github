using System;
using System.Data;
using System.Globalization;
using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Common.Miracle;
using NHapi.Base.Parser;
using NHapi.Model.V23.Message;

namespace EnvisionInterfaceEngine.Operational.HL7
{
    public class GenerateORM
    {
        private const string title_log = "EnvisionInterfaceEngine.Operational.HL7.GenerateORM";

        public static string GenerateHL7(HL7ORM data)
        {
            ORM_O01 orm = new ORM_O01();

            orm.MSH.SendingApplication.NamespaceID.Value = data.MSH.SENDING_APPLICATION;
            orm.MSH.SendingFacility.NamespaceID.Value = data.ORG.ORG_ALIAS;
            orm.MSH.ReceivingApplication.NamespaceID.Value = data.MSH.RECEIVING_APPLICATION;
            orm.MSH.DateTimeOfMessage.TimeOfAnEvent.Value = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            orm.MSH.MessageControlID.Value = data.MSH.MESSAGE_CONTROL_ID;
            orm.MSH.ProcessingID.ProcessingID.Value = data.MSH.PROCESSING_ID;
            orm.MSH.VersionID.Value = data.MSH.VERSION_ID;

            #region PATIENT
            orm.PATIENT.PID.PatientIDExternalID.ID.Value = data.PATIENT.EXT_HN;
            orm.PATIENT.PID.GetPatientIDInternalID(0).ID.Value = data.PATIENT.HN;
            orm.PATIENT.PID.AlternatePatientID.ID.Value = data.PATIENT.HIS_HN;

            orm.PATIENT.PID.PatientName.PrefixEgDR.Value = data.PATIENT.TITLE_ENG;
            orm.PATIENT.PID.PatientName.FamilyName.Value = data.PATIENT.FNAME_ENG;
            orm.PATIENT.PID.PatientName.GivenName.Value = data.PATIENT.LNAME_ENG;

            orm.PATIENT.PID.GetPatientAlias(0).PrefixEgDR.Value = data.PATIENT.TITLE;
            orm.PATIENT.PID.GetPatientAlias(0).FamilyName.Value = data.PATIENT.FNAME;
            orm.PATIENT.PID.GetPatientAlias(0).GivenName.Value = data.PATIENT.LNAME;

            if (data.PATIENT.GENDER != char.MinValue)
                orm.PATIENT.PID.Sex.Value = data.PATIENT.GENDER.ToString();

            if (data.PATIENT.DOB != null && data.PATIENT.DOB != DateTime.MinValue)
                orm.PATIENT.PID.DateOfBirth.TimeOfAnEvent.Value = data.PATIENT.DOB.ToString("yyyyMMdd", CultureInfo.GetCultureInfo("en-US"));
            orm.PATIENT.PID.SSNNumberPatient.Value = data.PATIENT.SSN;
            orm.PATIENT.PID.GetPatientAddress(0).StreetAddress.Value = data.PATIENT.ADDR1 + data.PATIENT.ADDR2 + data.PATIENT.ADDR3 + data.PATIENT.ADDR4 + data.PATIENT.ADDR5;
            orm.PATIENT.PID.GetPhoneNumberHome(0).Value = data.PATIENT.PHONE1;
            orm.PATIENT.PID.GetPhoneNumberBusiness(0).Value = data.PATIENT.PHONE2;
            #endregion
            #region PATIENT VISIT
            orm.PATIENT.PATIENT_VISIT.PV1.VisitNumber.ID.Value = data.ORDER_DETAIL.ACCESSION_NO; //If send VISIT_NO have some problem with Synapse.
            orm.PATIENT.PATIENT_VISIT.PV1.PreadmitNumber.ID.Value = data.ORDER.ADMISSION_NO;

            orm.PATIENT.PATIENT_VISIT.PV1.GetConsultingDoctor(0).IDNumber.Value = data.ASSIGNED_TO.EMP_UID;
            orm.PATIENT.PATIENT_VISIT.PV1.GetConsultingDoctor(0).FamilyName.Value = data.ASSIGNED_TO.TITLE_ENG;
            orm.PATIENT.PATIENT_VISIT.PV1.GetConsultingDoctor(0).GivenName.Value = data.ASSIGNED_TO.FNAME_ENG + " " + data.ASSIGNED_TO.LNAME_ENG;

            orm.PATIENT.PATIENT_VISIT.PV1.GetConsultingDoctor(1).IDNumber.Value = data.ASSIGNED_TO.EMP_UID;
            orm.PATIENT.PATIENT_VISIT.PV1.GetConsultingDoctor(1).FamilyName.Value = data.ASSIGNED_TO.SALUTATION;
            orm.PATIENT.PATIENT_VISIT.PV1.GetConsultingDoctor(1).GivenName.Value = data.ASSIGNED_TO.FNAME + " " + data.ASSIGNED_TO.LNAME;

            //Prim. Loc
            orm.PATIENT.PATIENT_VISIT.PV1.AssignedPatientLocation.PointOfCare.Value = data.REFERENCE_UNIT.UNIT_NAME;
            orm.PATIENT.PATIENT_VISIT.PV1.AssignedPatientLocation.Room.Value = data.REFERENCE_UNIT.UNIT_NAME;

            //Current Loc
            orm.PATIENT.PATIENT_VISIT.PV1.TemporaryLocation.PointOfCare.Value = data.REFERENCE_UNIT.UNIT_UID;
            orm.PATIENT.PATIENT_VISIT.PV1.TemporaryLocation.Room.Value = data.REFERENCE_UNIT.UNIT_NAME;
            #endregion
            #region ORDER
            orm.GetORDER().ORC.OrderControl.Value = data.ORDER_CONTROL;
            orm.GetORDER().ORC.GetPlacerOrderNumber(0).EntityIdentifier.Value = data.ORDER.REQUESTNO;
            orm.GetORDER().ORC.OrderStatus.Value = data.ORDER_STATUS;
            orm.GetORDER().ORDER_DETAIL.OBR.ResultStatus.Value = data.RESULT_STATUS;
            orm.GetORDER().ORDER_DETAIL.OBR.RelevantClinicalInformation.Value = data.ORDER.CLINICAL_INSTRUCTION;

            orm.GetORDER().ORDER_DETAIL.OBR.GetPlacerOrderNumber(0).EntityIdentifier.Value = data.ORDER_DETAIL.ACCESSION_NO;

            orm.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Identifier.Value = data.EXAM.EXAM_UID;
            orm.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Text.Value = data.EXAM.EXAM_NAME;

            orm.GetORDER().ORDER_DETAIL.OBR.TransportationMode.Value = data.PATIENT_STATUS.STATUS_UID;

            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).IDNumber.Value = data.REFERRING_DOCTOR.EMP_UID;
            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).FamilyName.Value = data.REFERRING_DOCTOR.TITLE_ENG;
            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(0).GivenName.Value = data.REFERRING_DOCTOR.FNAME_ENG + " " + data.REFERRING_DOCTOR.LNAME_ENG;

            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(1).IDNumber.Value = data.REFERRING_DOCTOR.EMP_UID;
            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(1).FamilyName.Value = data.REFERRING_DOCTOR.SALUTATION;
            orm.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider(1).GivenName.Value = data.REFERRING_DOCTOR.FNAME + " " + data.REFERRING_DOCTOR.LNAME;

            orm.GetORDER().ORDER_DETAIL.OBR.DiagnosticServiceSectionID.Value = data.MODALITYTYPE.TYPE_NAME_ALIAS;
            orm.GetORDER().ORDER_DETAIL.OBR.QuantityTiming.Priority.Value = data.ORDER_DETAIL.PRIORITY.ToString();

            //Special for ORM
            if (data.ORDER_CONTROL == "SM")
                orm.GetORDER().ORDER_DETAIL.OBR.PlacerField1.Value = data.ORDER_DETAIL.INSTANCE_UID;
            #endregion

            return HL7Manager.decodeAlphanumeric(new PipeParser().Encode(orm));
        }

        public static void ConvertToHL7(DataTable data)
        {
            if (Utilities.HasData(data))
            {
                if (data.Columns.IndexOf("HL7_TEXT") < 0)
                    data.Columns.Add("HL7_TEXT", typeof(string));
                data.AcceptChanges();

                foreach (DataRow row in data.Rows)
                    row["HL7_TEXT"] = Utilities.ClearSyntaxHL7(GenerateHL7(ConvertToObject(row)));
                data.AcceptChanges();
            }
        }
        
        public static HL7ORM ConvertToObject(DataRow data)
        {
            HL7ORM hl7_orm = new HL7ORM();

            using (HL7ADT hl7_adt = GenerateADT.ConvertToObject(data))
            {
                hl7_orm.MSH = hl7_adt.MSH;
                hl7_orm.ORG = hl7_adt.ORG;
                hl7_orm.PATIENT = hl7_adt.PATIENT;
            }

            hl7_orm.ORDER_CONTROL = data["Hl7OrderControl"].ToString();
            hl7_orm.ORDER_STATUS = data["Hl7OrderStatus"].ToString();
            hl7_orm.RESULT_STATUS = data["Hl7ResultStatus"].ToString();


            hl7_orm.ORDER.ADMISSION_NO = data["ADMISSION_NO"].ToString();
            hl7_orm.ORDER.REQUESTNO = data["REQUESTNO"].ToString();

            hl7_orm.PATIENT_STATUS.STATUS_UID = data["PATIENT_STATUS_UID"].ToString();

            hl7_orm.REFERENCE_UNIT.UNIT_UID = data["REF_UNIT_UID"].ToString();
            hl7_orm.REFERENCE_UNIT.UNIT_NAME = data["REF_UNIT_NAME"].ToString();

            hl7_orm.REFERRING_DOCTOR.EMP_UID = data["REF_DOC_UID"].ToString();
            hl7_orm.REFERRING_DOCTOR.SALUTATION = data["REF_DOC_SALUTATION"].ToString();
            hl7_orm.REFERRING_DOCTOR.FNAME = data["REF_DOC_FNAME"].ToString();
            hl7_orm.REFERRING_DOCTOR.LNAME = data["REF_DOC_LNAME"].ToString();
            hl7_orm.REFERRING_DOCTOR.TITLE_ENG = data["REF_DOC_TITLE_ENG"].ToString();
            hl7_orm.REFERRING_DOCTOR.FNAME_ENG = data["REF_DOC_FNAME_ENG"].ToString();
            hl7_orm.REFERRING_DOCTOR.LNAME_ENG = data["REF_DOC_LNAME_ENG"].ToString();

            hl7_orm.ORDER_DETAIL.ACCESSION_NO = data["ACCESSION_NO"].ToString();
            hl7_orm.ORDER_DETAIL.INSTANCE_UID = data["INSTANCE_UID"].ToString();
            hl7_orm.ORDER_DETAIL.PRIORITY = Convert.ToChar(data["PRIORITY"]);

            hl7_orm.EXAM.EXAM_UID = data["EXAM_UID"].ToString();
            hl7_orm.EXAM.EXAM_NAME = data["EXAM_NAME"].ToString();

            hl7_orm.MODALITYTYPE.TYPE_NAME_ALIAS = data["TYPE_NAME_ALIAS"].ToString();

            hl7_orm.ASSIGNED_TO.EMP_UID = data["RAD_UID"].ToString();
            hl7_orm.ASSIGNED_TO.SALUTATION = data["RAD_SALUTATION"].ToString();
            hl7_orm.ASSIGNED_TO.FNAME = data["RAD_FNAME"].ToString();
            hl7_orm.ASSIGNED_TO.LNAME = data["RAD_LNAME"].ToString();
            hl7_orm.ASSIGNED_TO.TITLE_ENG = data["RAD_TITLE_ENG"].ToString();
            hl7_orm.ASSIGNED_TO.FNAME_ENG = data["RAD_FNAME_ENG"].ToString();
            hl7_orm.ASSIGNED_TO.LNAME_ENG = data["RAD_LNAME_ENG"].ToString();

            hl7_orm.OPERATOR.EMP_UID = data["OPERATOR_UID"].ToString();
            hl7_orm.OPERATOR.SALUTATION = data["OPERATOR_SALUTATION"].ToString();
            hl7_orm.OPERATOR.FNAME = data["OPERATOR_FNAME"].ToString();
            hl7_orm.OPERATOR.LNAME = data["OPERATOR_LNAME"].ToString();
            hl7_orm.OPERATOR.TITLE_ENG = data["OPERATOR_TITLE_ENG"].ToString();
            hl7_orm.OPERATOR.FNAME_ENG = data["OPERATOR_FNAME_ENG"].ToString();
            hl7_orm.OPERATOR.LNAME_ENG = data["OPERATOR_LNAME_ENG"].ToString();

            hl7_orm.ORG.ORG_ALIAS = ConfigManager.GetFacilityName(hl7_orm.REFERENCE_UNIT.UNIT_UID) ?? hl7_orm.ORG.ORG_ALIAS;

            return hl7_orm;
        }
        public static HL7ORM ConvertToObject(ORM_O01 value)
        {
            HL7ORM hl7_orm = new HL7ORM();

            try
            {
                hl7_orm.MSH.SENDING_APPLICATION = value.MSH.SendingApplication.NamespaceID.Value;
                hl7_orm.MSH.MESSAGE_CONTROL_ID = value.MSH.MessageControlID.Value;

                hl7_orm.ORDER_CONTROL = value.GetORDER().ORC.OrderControl.Value;

                hl7_orm.ORG.ORG_ALIAS = value.MSH.SendingFacility.NamespaceID.Value;

                hl7_orm.PATIENT.EXT_HN = value.PATIENT.PID.PatientIDExternalID.ID.Value;
                hl7_orm.PATIENT.HN = value.PATIENT.PID.GetPatientIDInternalID(0).ID.Value;
                hl7_orm.PATIENT.HIS_HN = value.PATIENT.PID.AlternatePatientID.ID.Value;

                hl7_orm.PATIENT.TITLE = value.PATIENT.PID.GetPatientAlias(0).PrefixEgDR.Value;
                hl7_orm.PATIENT.FNAME = value.PATIENT.PID.GetPatientAlias(0).FamilyName.Value;
                hl7_orm.PATIENT.LNAME = string.Format("{0} {1} {2}",
                    value.PATIENT.PID.GetPatientAlias(0).GivenName.Value,
                    value.PATIENT.PID.GetPatientAlias(0).MiddleInitialOrName.Value,
                    value.PATIENT.PID.GetPatientAlias(0).SuffixEgJRorIII.Value).Trim();

                hl7_orm.PATIENT.TITLE_ENG = value.PATIENT.PID.PatientName.PrefixEgDR.Value;
                hl7_orm.PATIENT.FNAME_ENG = value.PATIENT.PID.PatientName.FamilyName.Value;
                hl7_orm.PATIENT.LNAME_ENG = string.Format("{0} {1} {2}",
                    value.PATIENT.PID.PatientName.GivenName.Value,
                    value.PATIENT.PID.PatientName.MiddleInitialOrName.Value,
                    value.PATIENT.PID.PatientName.SuffixEgJRorIII.Value).Trim();

                hl7_orm.PATIENT.GENDER = Utilities.ToChar(value.PATIENT.PID.Sex.Value, 'O');
                hl7_orm.PATIENT.DOB = value.PATIENT.PID.DateOfBirth.TimeOfAnEvent.GetAsDate();
                hl7_orm.PATIENT.SSN = value.PATIENT.PID.SSNNumberPatient.Value;
                using (MIStringArray mi_address = new MIStringArray(HL7Manager.ConvertObjectToText(value.PATIENT.PID.GetPatientAddress(0))))
                {
                    hl7_orm.PATIENT.ADDR1 = mi_address[0];
                    hl7_orm.PATIENT.ADDR2 = mi_address[1];
                    hl7_orm.PATIENT.ADDR3 = mi_address[2];
                    hl7_orm.PATIENT.ADDR4 = mi_address[3];
                    hl7_orm.PATIENT.ADDR5 = mi_address[4];
                }
                hl7_orm.PATIENT.PHONE1 = value.PATIENT.PID.GetPhoneNumberHome(0).Value;
                hl7_orm.PATIENT.PHONE2 = value.PATIENT.PID.GetPhoneNumberBusiness(0).Value;

                hl7_orm.ORDER.ADMISSION_NO = value.PATIENT.PATIENT_VISIT.PV1.PreadmitNumber.ID.Value;
                hl7_orm.ORDER.REQUESTNO = value.GetORDER().ORC.GetPlacerOrderNumber(0).EntityIdentifier.Value;
                hl7_orm.ORDER.VISIT_NO = value.PATIENT.PATIENT_VISIT.PV1.VisitNumber.ID.Value;
                hl7_orm.ORDER.CLINICAL_INSTRUCTION = HL7Manager.DecodeText(value.GetORDER().ORDER_DETAIL.OBR.RelevantClinicalInformation.Value, string.Empty);
                hl7_orm.ORDER.REASON = value.GetORDER().ORDER_DETAIL.OBR.GetReasonForStudy(0).Text.Value;

                hl7_orm.PATIENT_STATUS.STATUS_UID = value.GetORDER().ORDER_DETAIL.OBR.TransportationMode.Value;

                hl7_orm.REFERENCE_UNIT.UNIT_UID = value.PATIENT.PATIENT_VISIT.PV1.TemporaryLocation.PointOfCare.Value;
                hl7_orm.REFERENCE_UNIT.UNIT_NAME = value.PATIENT.PATIENT_VISIT.PV1.TemporaryLocation.Room.Value;

                hl7_orm.REFERRING_DOCTOR = HL7Manager.ConvertObject(value.GetORDER().ORDER_DETAIL.OBR.GetOrderingProvider());

                hl7_orm.ORDER_DETAIL.ACCESSION_NO = value.GetORDER().ORDER_DETAIL.OBR.GetPlacerOrderNumber(0).EntityIdentifier.Value;
                hl7_orm.ORDER_DETAIL.STATUS = 'A';
                if (!string.IsNullOrEmpty(value.GetORDER().ORDER_DETAIL.OBR.ResultStatus.Value))
                {
                    switch (value.GetORDER().ORDER_DETAIL.OBR.ResultStatus.Value.ToLower())
                    {
                        case "sent":
                            hl7_orm.ORDER_DETAIL.STATUS = 'S';
                            break;
                        case "complete":
                            hl7_orm.ORDER_DETAIL.STATUS = 'C';
                            break;
                    }
                }
                hl7_orm.ORDER_DETAIL.PRIORITY = Utilities.ToChar(value.GetORDER().ORDER_DETAIL.OBR.QuantityTiming.Priority.Value, 'R');
                hl7_orm.ORDER_DETAIL.IS_DELETED = hl7_orm.ORDER_CONTROL == "CA" ? 'Y' : 'N';

                hl7_orm.EXAM.EXAM_UID = value.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Identifier.Value;
                hl7_orm.EXAM.EXAM_NAME = value.GetORDER().ORDER_DETAIL.OBR.UniversalServiceIdentifier.Text.Value;

                hl7_orm.MODALITYTYPE.TYPE_NAME_ALIAS = value.GetORDER().ORDER_DETAIL.OBR.DiagnosticServiceSectionID.Value;

                hl7_orm.ASSIGNED_TO = HL7Manager.ConvertObject(value.PATIENT.PATIENT_VISIT.PV1.GetConsultingDoctor());
                hl7_orm.OPERATOR = HL7Manager.ConvertObject(value.GetORDER().ORC.EnteredBy);

                hl7_orm.ORG.ORG_ALIAS = ConfigManager.GetFacilityName(hl7_orm.REFERENCE_UNIT.UNIT_UID) ?? hl7_orm.ORG.ORG_ALIAS;
            }
            catch (Exception ex)
            {
                hl7_orm = null;

                Utilities.SaveLog(title_log, "ConvertToObject(ORM_O01 value)", ex.Message, true);
            }

            return hl7_orm;
        }
        public static HL7ORM ConvertToObjectFromBidirectional(string hl7Text)
        {
            HL7ORM hl7_orm = new HL7ORM();

            try
            {
                string[] message = HL7Manager.splitSegmentTerminator(hl7Text);

                foreach (string segment in message)
                {
                    MIStringArray msgField = new MIStringArray(HL7Manager.splitFieldSeparator(segment));

                    switch (msgField[0])
                    {
                        case "MSH":
                            hl7_orm.MSH.SENDING_APPLICATION = msgField[2];
                            hl7_orm.ORG.ORG_ALIAS = msgField[3];
                            hl7_orm.MSH.MESSAGE_CONTROL_ID = msgField[9];
                            break;
                        case "PID":
                            hl7_orm.PATIENT.EXT_HN = msgField[2];
                            hl7_orm.PATIENT.HN = msgField[3];
                            hl7_orm.PATIENT.HIS_HN = msgField[4];

                            using (MIStringArray patient_name_eng = new MIStringArray(HL7Manager.splitComponentSeparator(msgField[5])))
                            {
                                hl7_orm.PATIENT.FNAME_ENG = patient_name_eng[0];
                                hl7_orm.PATIENT.LNAME_ENG = patient_name_eng[1];
                                hl7_orm.PATIENT.TITLE_ENG = patient_name_eng[4];
                            }

                            hl7_orm.PATIENT.DOB = Utilities.ToDateTime(msgField[7], "yyyyMMdd");
                            hl7_orm.PATIENT.GENDER = Utilities.ToChar(msgField[8]);

                            using (MIStringArray patient_name = new MIStringArray(HL7Manager.splitComponentSeparator(msgField[9])))
                            {
                                hl7_orm.PATIENT.FNAME = patient_name[0];
                                hl7_orm.PATIENT.LNAME = patient_name[1];
                                hl7_orm.PATIENT.TITLE = patient_name[4];
                            }

                            hl7_orm.PATIENT.SSN = msgField[19];
                            break;
                        case "PV1": break;
                        case "ORC":
                            hl7_orm.ORDER.REQUESTNO = msgField[2];
                            break;
                        case "OBR":
                            hl7_orm.ORDER_DETAIL.ACCESSION_NO = msgField[2];

                            using (MIStringArray exam = new MIStringArray(HL7Manager.splitComponentSeparator(msgField[4])))
                            {
                                hl7_orm.EXAM.EXAM_UID = exam[0];
                                hl7_orm.EXAM.EXAM_NAME = exam[1];
                            }

                            hl7_orm.MODALITYTYPE.TYPE_NAME_ALIAS = msgField[24];
                            switch (msgField[25].ToLower())
                            {
                                case "sent":
                                    hl7_orm.ORDER_DETAIL.STATUS = 'S';
                                    break;
                                case "complete":
                                    hl7_orm.ORDER_DETAIL.STATUS = 'C';
                                    break;
                                default:
                                    hl7_orm.ORDER_DETAIL.STATUS = 'A';
                                    break;
                            }
                            hl7_orm.IMAGE_CAPTURED_BY.ALIAS_NAME = msgField[34];
                            break;
                        case "ZDS":
                            hl7_orm.ORDER_DETAIL.INSTANCE_UID = msgField[1];
                            hl7_orm.ORDER_DETAIL.IMAGE_CAPTURED_ON = Utilities.ToDateTime(msgField[3], "yyyyMMddHHmmss");
                            hl7_orm.ORDER_DETAIL.IMAGECOUNT = Utilities.ToInt(msgField[5]);

                            hl7_orm.MODALITYAETITLE.AE_TITLE_NAME = msgField[2];
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                hl7_orm = null;

                Utilities.SaveLog(title_log, "ConvertToObjectFromBidirectional(string hl7Text)", ex.Message, true);
            }

            return hl7_orm;
        }
    }
}