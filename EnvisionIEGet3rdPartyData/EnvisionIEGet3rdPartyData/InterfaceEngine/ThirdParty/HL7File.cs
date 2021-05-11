using System;
using System.Data;
using EnvisionIEGet3rdPartyData.Common;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.Credentials;

namespace EnvisionIEGet3rdPartyData.InterfaceEngine.ThirdParty
{
    public class HL7File : IBilling, IDemographic, IResult
    {
        public HL7File() { }

        //IBilling
        public DataSet Get_Billing(DataSet data) { return getHL7MessageoSocket(data); }
        public DataSet Set_Billing(DataSet data) { return setHL7MessageToFile(data, "ACCESSION_NO"); }
        public DataSet Set_PreBilling(DataSet data) { return new None().defaultValue(); }

        //IDemographic
        public DataSet Get_Demographic(DataSet data) { return new None().defaultValue(); }
        public DataSet Get_Demographic_Short(DataSet data) { return new None().defaultValue(); }
        public DataSet Get_PatientAllergy(DataSet data) { return new None().defaultValue(); }
        public DataSet Get_PatientLabData(DataSet data) { return new None().defaultValue(); }

        public DataSet Set_Demographic(DataSet data) { return setHL7MessageToFile(data, "HIS_HN"); }
        public bool Get_TeleMedByEncIdAndType(DataSet data) { return false; }

        //IResult
        public DataSet Get_Result_Legacy(DataSet data) { return new None().defaultValue(); }

        public DataSet Set_Result(DataSet data) { return setHL7MessageToFile(data, "ACCESSION_NO"); }
        public DataSet Set_ResultHasImage(DataSet data) { return setHL7MessageToFile(data, "ACCESSION_NO"); }

        private DataSet getHL7MessageoSocket(DataSet data)
        {
            DataSet ds = new DataSet("EnvisionIE");

            if (Utilities.HasData(data))
            {
                ds.Tables.Add(data.Tables["TextFile"].Copy());
                data = null;
                ds.Tables[0].TableName = "ACK";

                if (ds.Tables["ACK"].Columns.IndexOf("ACKNOWLEDGMENT_CODE") == -1)
                {
                    ds.Tables["ACK"].Columns.Add("ACKNOWLEDGMENT_CODE", typeof(string));
                    ds.Tables["ACK"].Columns["ACKNOWLEDGMENT_CODE"].DefaultValue = "AE";
                }
                if (ds.Tables["ACK"].Columns.IndexOf("TEXT_MESSAGE") == -1)
                {
                    ds.Tables["ACK"].Columns.Add("TEXT_MESSAGE", typeof(string));
                    ds.Tables["ACK"].Columns["TEXT_MESSAGE"].DefaultValue = "Message Error";
                }

                foreach (DataRow row_data in ds.Tables["ACK"].Rows)
                {
                    try
                    {
                        HL7ACK hl7_ack = HL7SocketEngine.Send(ConfigService.RisIP, ConfigService.RisPort, row_data["Value"].ToString());

                        row_data["ACKNOWLEDGMENT_CODE"] = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                        row_data["TEXT_MESSAGE"] = hl7_ack.MSA.TEXT_MESSAGE;
                    }
                    catch (Exception ex)
                    {
                        row_data["ACKNOWLEDGMENT_CODE"] = "AE";
                        row_data["TEXT_MESSAGE"] = Utilities.ToCleanString(ex.Message);
                    }
                }
            }
            else
            {
                HL7ACK hl7_ack = new HL7ACK();
                hl7_ack.MSH.MESSAGE_CONTROL_ID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                hl7_ack.MSA.TEXT_MESSAGE = "Data is null";

                ds.Tables.Add(Utilities.ConvertObjectToTable(hl7_ack.MSA));
                ds.Tables[0].TableName = "ACK";
            }

            ds.AcceptChanges();

            return ds.Copy();
        }
        private DataSet setHL7MessageToFile(DataSet data, string primaryValue)
        {
            DataSet ds = new DataSet("EnvisionIE");

            if (Utilities.HasData(data))
            {
                CredentialsUncPath identity = new CredentialsUncPath();

                if (!string.IsNullOrEmpty(ConfigService.ThirdPartyUncPath))
                    identity.NetUseWithCredentials(ConfigService.ThirdPartyUncPath, ConfigService.ThirdPartyUserDomainName, ConfigService.ThirdPartyUserName, ConfigService.ThirdPartyPassword);

                if (identity.LastError == 0)
                {
                    ds.Tables.Add(data.Tables["HL7"].Copy());
                    data = null;
                    ds.Tables[0].TableName = "ACK";

                    if (ds.Tables["ACK"].Columns.IndexOf("ACKNOWLEDGMENT_CODE") == -1)
                    {
                        ds.Tables["ACK"].Columns.Add("ACKNOWLEDGMENT_CODE", typeof(string));
                        ds.Tables["ACK"].Columns["ACKNOWLEDGMENT_CODE"].DefaultValue = "AE";
                    }
                    if (ds.Tables["ACK"].Columns.IndexOf("TEXT_MESSAGE") == -1)
                    {
                        ds.Tables["ACK"].Columns.Add("TEXT_MESSAGE", typeof(string));
                        ds.Tables["ACK"].Columns["TEXT_MESSAGE"].DefaultValue = "Message Error";
                    }

                    foreach (DataRow row_data in ds.Tables["ACK"].Rows)
                    {
                        try
                        {
                            Utilities.SaveTextFile(
                                string.Format("{0}\\{1}{2}",
                                    ConfigService.ThirdPartyDirectorySent,
                                    row_data[primaryValue],
                                    ConfigService.ThirdPartyFileExtension),
                                ConfigService.ThirdPartyEncoding,
                                row_data["HL7_TEXT"].ToString(),
                                false);

                            if (!string.IsNullOrEmpty(ConfigService.ThirdPartyDirectorySentBackup))
                            {
                                Utilities.SaveTextFile(
                                    string.Format("{0}\\{1:yyyyMMdd}\\{2}{3}",
                                        ConfigService.ThirdPartyDirectorySentBackup,
                                        DateTime.Now,
                                        row_data[primaryValue],
                                        ConfigService.ThirdPartyFileExtension),
                                    ConfigService.ThirdPartyEncoding,
                                    row_data["HL7_TEXT"].ToString(),
                                    false);
                            }

                            row_data["ACKNOWLEDGMENT_CODE"] = "AA";
                            row_data["TEXT_MESSAGE"] = "Message Accept";
                        }
                        catch (Exception ex)
                        {
                            row_data["ACKNOWLEDGMENT_CODE"] = "AE";
                            row_data["TEXT_MESSAGE"] = Utilities.ToCleanString(ex.Message);
                        }
                    }
                }
                else
                {
                    HL7ACK hl7_ack = new HL7ACK();
                    hl7_ack.MSH.MESSAGE_CONTROL_ID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                    hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                    hl7_ack.MSA.TEXT_MESSAGE = "Credentials UNC path have last error is " + identity.LastError.ToString();

                    ds.Tables.Add(Utilities.ConvertObjectToTable(hl7_ack.MSA));
                    ds.Tables[0].TableName = "ACK";
                }
            }
            else
            {
                HL7ACK hl7_ack = new HL7ACK();
                hl7_ack.MSH.MESSAGE_CONTROL_ID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
                hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                hl7_ack.MSA.TEXT_MESSAGE = "Data is null";

                ds.Tables.Add(Utilities.ConvertObjectToTable(hl7_ack.MSA));
                ds.Tables[0].TableName = "ACK";
            }

            ds.AcceptChanges();

            return ds.Copy();
        }
    }
}