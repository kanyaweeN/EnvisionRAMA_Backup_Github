using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;

namespace EnvisionHL7WebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class EnvisionHL7 : System.Web.Services.WebService
    {
        private string successfull = "Send message to PACS complete";

        [WebMethod]
        public ReturnOperation SendMessageORM(Patient patient, OrderItems[] orders, string createName)
        {
            ReturnOperation op = new ReturnOperation();
            HL7TransLog log = new HL7TransLog();
            op.Type = TypeCode.Fail.ToString();
            bool flag = false;
            try
            {
                #region Require Check.
                if (patient == null)
                {
                    op.Message = "Patient object is null.";
                    return op;
                }
                if (orders == null)
                {
                    op.Message = "Order object is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(createName))
                {
                    op.Message = "Create name is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.HN))
                {
                    op.Message = "HN in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.FirstName))
                {
                    op.Message = "First name in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.LastName))
                {
                    op.Message = "Last name in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.FirstNameEng))
                {
                    op.Message = "First english name in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.LastNameEng))
                {
                    op.Message = "Last english name in patient demographic is null.";
                    return op;
                }
                //foreach (OrderItems ord in orders)
                //{
                //    if (string.IsNullOrEmpty(ord.ACCESSION_NO))
                //    {
                //        flag = true;
                //        break;
                //    }
                //}
                //if (flag)
                //{
                //    op.Message = "Some object in order data accession number is null.";
                //    return op;
                //}
                flag = false;
                foreach (OrderItems ord in orders)
                {
                    if (string.IsNullOrEmpty(ord.ExamCode))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    op.Message = "Some object in order data exam code is null.";
                    return op;
                }
                flag = false;
                foreach (OrderItems ord in orders)
                {
                    if (string.IsNullOrEmpty(ord.ExamName))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    op.Message = "Some object in order data exam name is null.";
                    return op;
                }
                #endregion

                log.REQUEST_TIMESTAMP = DateTime.Now;
                log.REQUEST_TYPE = "O";
                log.REQUESTING_IP = GetIP();
                log.REQUESTING_USER = createName;


                log.PATIENT_DEMOGRAPHIC = patient.HN + "," + patient.FirstName + " " + patient.MiddleName + " " + patient.LastName + "," +
                                          patient.FirstNameEng + " " + patient.MiddleNameEng + " " + patient.LastNameEng + " " + patient.Phone;
                log.RESULT_TEXT = string.Empty;
                log.PACS_IP = PACSInfo.IP;
                log.PACS_PORT = PACSInfo.PORTS;

                DataSet dsAccession = new DataSet();
                DataTable dtAccession = new DataTable();
                dtAccession.Columns.Add("ACCESSION");
                dtAccession.AcceptChanges();
                
                for (int y = 0; y < orders.Length; y++)
                {
                    string acc = "";
                    if (string.IsNullOrEmpty(orders[y].ACCESSION_NO))
                        acc = genAccession(createName,patient.DepartmentName);
                    else
                        acc = orders[y].ACCESSION_NO;

                    orders[y].ACCESSION_NO = acc;
                    dtAccession.NewRow();
                    dtAccession.Rows.Add(acc);
                    dtAccession.AcceptChanges();
                }
                dsAccession.Tables.Add(dtAccession);
                dsAccession.AcceptChanges();

                op.Accession = dsAccession;
                op.Type = TypeCode.Complete.ToString();
                op.Message = successfull;
                CreateMessageORM orm = new CreateMessageORM();
                DataTable dtt = orm.HL7Message(patient, orders, createName);

                SendToPacs send = new SendToPacs();
                if (send.SendMSGToPacs(dtt, "ORM") == false)
                {
                    op.Type = TypeCode.Fail.ToString();
                    op.Message = "Fail sent to PACS";
                    op.Accession = null;
                    log.IS_SUCCESSFUL = "N";
                    log.ACK_TYPE = op.Type;
                    log.ACK_TIMESTAMP = DateTime.Now;
                    log.ACK_SENDING_IP = GetIP();
                    log.ACK_MSG = op.Message;
                }
                else {
                    log.IS_SUCCESSFUL = "Y";
                    log.ACK_TYPE = op.Type;
                    log.ACK_TIMESTAMP = DateTime.Now;
                    log.ACK_SENDING_IP = GetIP();
                    log.ACK_MSG = successfull;
                }
                for(int i=0;i<orders.Length;i++)
                {
                    log.EXAM_DETAILS = orders[i].ACCESSION_NO + "," + orders[i].ExamCode + "," + orders[i].ExamName;
                    log.GENERATED_HL7 = dtt.Rows[0][1].ToString();
                    log.SENDING_TIMESTAMP = DateTime.Now;
                    saveLog(log);
                }
                
            }
            catch (Exception ex)
            {
                op.Type = TypeCode.Fail.ToString();
                op.Message = ex.Message;
            }
            return op;
        }

        [WebMethod]
        public ReturnOperation SendMessageORU(Patient patient, ResultItems result, string createName)
        {
            ReturnOperation op = new ReturnOperation();
            HL7TransLog log = new HL7TransLog();
            op.Type = TypeCode.Fail.ToString();
            try
            {
                #region Require Check.
                if (patient == null)
                {
                    op.Message = "Patient object is null.";
                    return op;
                }
                if (result == null)
                {
                    op.Message = "Result object is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(createName))
                {
                    op.Message = "Create name is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.HN))
                {
                    op.Message = "HN in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.FirstName))
                {
                    op.Message = "First name in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.LastName))
                {
                    op.Message = "Last name in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.FirstNameEng))
                {
                    op.Message = "First english name in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(patient.LastNameEng))
                {
                    op.Message = "Last english name in patient demographic is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(result.ACCESSION_NO))
                {
                    op.Message = "Accession number is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(result.ExamCode))
                {
                    op.Message = "Exam code is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(result.ExamName))
                {
                    op.Message = "Exam name is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(result.ResultText))
                {
                    op.Message = "Result text is null.";
                    return op;
                }
                if (string.IsNullOrEmpty(result.Status))
                {
                    op.Message = "Status is null.";
                    return op;
                }
                #endregion

                log.REQUEST_TIMESTAMP = DateTime.Now;
                log.REQUEST_TYPE = "R";
                log.REQUESTING_IP = GetIP();
                log.REQUESTING_USER = createName;
               
               
                log.PATIENT_DEMOGRAPHIC = patient.HN + "," + patient.FirstName + " " + patient.MiddleName + " " + patient.LastName + "," +
                                        patient.FirstNameEng + " " + patient.MiddleNameEng + " " + patient.LastNameEng + " " + patient.Phone;
                log.EXAM_DETAILS = result.ACCESSION_NO + "," + result.ExamCode + "," + result.ExamName;
                log.RESULT_TEXT = result.ResultText;
               
                log.PACS_IP = PACSInfo.IP;
                log.PACS_PORT = PACSInfo.PORTS;
                
                //log.

                op.Type = TypeCode.Complete.ToString();
                op.Message = successfull;
                CreateMessageORU oru = new CreateMessageORU();
                TransRtf tran = new TransRtf(result.ResultText);
                string html = tran.Translator();
                result.HL7Text = html;
                DataTable dtt = oru.HL7Message(patient, result, createName);
                log.GENERATED_HL7 = dtt.Rows[0][1].ToString();
                log.SENDING_TIMESTAMP = DateTime.Now;
                SendToPacs send = new SendToPacs();
                if (send.SendMSGToPacs(dtt, "ORU") == false)
                {
                    op.Type = TypeCode.Fail.ToString();
                    op.Message = "Fail sent to PACS";
                    log.IS_SUCCESSFUL = "N";
                    log.ACK_TYPE = op.Type;
                    log.ACK_TIMESTAMP = DateTime.Now;
                    log.ACK_SENDING_IP = GetIP();
                    log.ACK_MSG = op.Message;
                }
                else {
                    log.IS_SUCCESSFUL = "Y";
                    log.ACK_TYPE = op.Type;
                    log.ACK_TIMESTAMP = DateTime.Now;
                    log.ACK_SENDING_IP = GetIP();
                    log.ACK_MSG = successfull;
                }
                saveLog(log);
            }
            catch (Exception ex)
            {
                op.Type = TypeCode.Fail.ToString();
                op.Message = ex.Message;
                op.Accession = null;
            }
            return op;
        }

        private void saveLog(HL7TransLog log) {
            try
            {
                SqlConnection conn = new SqlConnection(EnvisionInfo.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                                    INSERT INTO [dbo].[RIS_EXTERNALHL7TRANSLOG]
                                               ([REQUEST_TIMESTAMP]
                                               ,[REQUESTING_IP]
                                               ,[REQUESTING_USER]
                                               ,[REQUEST_TYPE]
                                               ,[PATIENT_DEMOGRAPHIC]
                                               ,[EXAM_DETAILS]
                                               ,[RESULT_TEXT]
                                               ,[PACS_IP]
                                               ,[PACS_PORT]
                                               ,[GENERATED_HL7]
                                               ,[SENDING_TIMESTAMP]
                                               ,[IS_SUCCESSFUL]
                                               ,[ACK_TYPE]
                                               ,[ACK_MSG]
                                               ,[ACK_SENDING_IP]
                                               ,[ACK_TIMESTAMP])
                                         VALUES
                                               (@REQUEST_TIMESTAMP
                                               ,@REQUESTING_IP
                                               ,@REQUESTING_USER
                                               ,@REQUEST_TYPE
                                               ,@PATIENT_DEMOGRAPHIC
                                               ,@EXAM_DETAILS
                                               ,@RESULT_TEXT
                                               ,@PACS_IP
                                               ,@PACS_PORT
                                               ,@GENERATED_HL7
                                               ,@SENDING_TIMESTAMP
                                               ,@IS_SUCCESSFUL
                                               ,@ACK_TYPE
                                               ,@ACK_MSG
                                               ,@ACK_SENDING_IP
                                               ,@ACK_TIMESTAMP)";

                cmd.Parameters.Add("@ACK_MSG", log.ACK_MSG);
                cmd.Parameters.Add("@ACK_SENDING_IP", log.ACK_SENDING_IP);
                cmd.Parameters.Add("@ACK_TIMESTAMP", log.ACK_TIMESTAMP);
                cmd.Parameters.Add("@ACK_TYPE", log.ACK_TYPE);
                cmd.Parameters.Add("@EXAM_DETAILS", log.EXAM_DETAILS);
                cmd.Parameters.Add("@GENERATED_HL7", log.GENERATED_HL7);
                cmd.Parameters.Add("@IS_SUCCESSFUL", log.IS_SUCCESSFUL);
                cmd.Parameters.Add("@PACS_IP", log.PACS_IP);
                cmd.Parameters.Add("@PACS_PORT", log.PACS_PORT);
                cmd.Parameters.Add("@PATIENT_DEMOGRAPHIC", log.PATIENT_DEMOGRAPHIC);
                cmd.Parameters.Add("@REQUEST_TIMESTAMP", log.REQUEST_TIMESTAMP);
                cmd.Parameters.Add("@REQUEST_TYPE", log.REQUEST_TYPE);
                cmd.Parameters.Add("@REQUESTING_IP", log.REQUESTING_IP);
                cmd.Parameters.Add("@REQUESTING_USER", log.REQUESTING_USER);
                cmd.Parameters.Add("@RESULT_TEXT", log.RESULT_TEXT);
                cmd.Parameters.Add("@SENDING_TIMESTAMP", log.SENDING_TIMESTAMP);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { 
            
            }
        }
//        private string genAccession(string TYPE)
//        {
//            try
//            {
//                SqlConnection conn = new SqlConnection(EnvisionInfo.ConnectionString);
//                SqlCommand cmd = new SqlCommand();
//                cmd.Connection = conn;
//                cmd.CommandType = CommandType.Text;
//                cmd.CommandText = @"declare @ACS_NO	nvarchar(30)
//	                                set @ACS_NO=''
//                                	
//	                                if(len(@Type)=1)
//		                                set @Type= @Type + '0' 
//	                                if(ISNULL(@Type,'Y')<>'Y')
//		                                begin
//			                                declare @year	nvarchar(4)
//			                                declare @month	nvarchar(2)
//			                                declare @day	nvarchar(2)
//
//			                                select	@year=year(getdate()),@month=month(getdate()),@day=day(getdate())
//			                                if(len(@month)=1)
//				                                set @month= '0' + @month
//			                                if(len(@day)=1)
//				                                set @day= '0' + @day
//
//			                                declare @NO	nvarchar(100)
//			                                exec	@NO = [dbo].[GBL_Sequences_SelectRunNo] @Seq_Name = @Type
//
//			                                if(len(@NO)=1)
//				                                set @NO='000'+@NO
//			                                else if(len(@NO)=2)
//				                                set @NO='00'+@NO
//			                                else if(len(@NO)=3)
//				                                set @NO='0'+@NO
//
//			                                set @ACS_NO=@year+@month+@day+@Type+@NO
//                                			
//		                                end
//	                                select @ACS_NO";
//                cmd.Parameters.Add("@Type", TYPE);
//                conn.Open();
//                SqlDataAdapter da = new SqlDataAdapter(cmd);

//                DataSet dss = new DataSet();
//                da.Fill(dss);
//                conn.Close();
//                return dss.Tables[0].Rows[0][0].ToString();
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }

//        }
        private string genAccession(string TYPE)
        {
            try
            {
                SqlConnection conn = new SqlConnection(EnvisionInfo.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"Prc_RIS_ORDER_GenAccession_By_WebHL7Service";
                cmd.Parameters.Add("@Type", TYPE);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet dss = new DataSet();
                da.Fill(dss);
                conn.Close();
                return dss.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        private string genAccession(string MODALITY,string REF_UNIT)
        {
            
            try
            {
                SqlParameter[] param = { 
                                        new SqlParameter("@MODALITY_TYPE_UID", MODALITY),
                                        new SqlParameter("@UNIT_UID", REF_UNIT)
                                       };
                SqlConnection conn = new SqlConnection(EnvisionInfo.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"Prc_RIS_ORDER_GenAccession_NEW2";
                cmd.Parameters.AddRange(param);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet dss = new DataSet();
                da.Fill(dss);
                conn.Close();
                return dss.Tables[0].Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public string GetIP() {
            return Context.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }

        [WebMethod]
        public string SendMessageORUTest()
        {
            SendToPACSORM();
            //SendToPACSORU();
            return "Complete";
        }

        private void SendToPACSORU()
        {
            Patient pt = new Patient();
            //List<ResultItems> results = new List<ResultItems>();
            ResultItems results = new ResultItems();
            string createName = "RD-0101";
            //--------------------------------------------------------------------------------------
            //            //Patient Setup
            //            pt.HN = "4009812";
            //            pt.FirstName = "Moinul";
            //            pt.MiddleName = "";
            //            pt.LastName = "ABEDIN";
            //            pt.FirstNameEng = "Moinul";
            //            pt.MiddleNameEng = "";
            //            pt.LastNameEng = "ABEDIN";
            //            pt.DOB = new DateTime(1977, 12, 1, 0, 0, 0);
            //            pt.Gender = "M";
            //            pt.Phone = "";
            //            pt.Address = "";
            //            pt.DoctorName = "000075";
            //            pt.DepartmentName = "1OW";

            //            //ResultItems Setup
            //            results.ACCESSION_NO = "EMPTY3";
            //            results.Order_ID = 0;
            //            results.ExamCode = "XX41";
            //            results.ExamName = "CHEST CHEST";
            //            results.Status = "F";
            //            results.ResultText = @"{\rtf1\ansi\ansicpg874\deff0\deflang1054{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
            //{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\f0\fs22 RASDSADSAD\line DSADDSADSAD\line DSADSADSADSDSADSADSA\par
            //\tab sad];we p,k p [pdl[ pl [d dd  ds da asd saa\par
            //}
            // ";
            //--------------------------------------------------------------------------------------

            //--------------------------------------------------------------------------------------
            //Patient Setup
            pt.HN = "7431";
            pt.FirstName = "Simpson";
            pt.MiddleName = "";
            pt.LastName = "Homer";
            pt.FirstNameEng = "Simpson";
            pt.MiddleNameEng = "";
            pt.LastNameEng = "Homer";
            pt.DOB = new DateTime(1955, 10, 5, 0, 0, 0);
            pt.Gender = "M";
            pt.Phone = "";
            pt.Address = "";
            pt.DoctorName = "test";
            //pt.DepartmentName = "1OW";
            pt.DepartmentName = "OER101:ทั่วไป";

            //ResultItems Setup
            results.ACCESSION_NO = "7417";
            results.Order_ID = 0;
            results.ExamCode = "XX41";
            results.ExamName = "CHEST CHEST";
            results.Status = "F";
            results.ResultText = @"{\rtf1\ansi\ansicpg874\deff0\deflang1054{\fonttbl{\f0\fnil\fcharset0 Calibri;}}
{\*\generator Msftedit 5.41.21.2510;}\viewkind4\uc1\pard\sa200\sl276\slmult1\lang9\f0\fs22 RASDSADSAD\line DSADDSADSAD\line DSADSADSADSDSADSADSA\par
\tab sad];we p,k p [pdl[ pl [d dd  ds da asd saa\par
}
 ";
            //--------------------------------------------------------------------------------------

            EnvisionHL7 hl7 = new EnvisionHL7();
            ReturnOperation op = hl7.SendMessageORU(pt, results, createName);
            //if (op.Type == "Complete")
                //MessageBox.Show(op.Message, "Complete");
            //else
            //{
                //MessageBox.Show(op.Message, "Error");
            //}

        }

        //[WebMethod]
        //public string ReturnValues()
        //{
        //    return "Hello World";
        //}

        private void SendToPACSORM()
        {
            Patient pt = new Patient();
            List<OrderItems> orders = new List<OrderItems>();
            string createName = "RD-0101";

            //Patient Setup
            pt.HN = "4009812";
            pt.FirstName = "Moinul";
            pt.MiddleName = "";
            pt.LastName = "ABEDIN";
            pt.FirstNameEng = "Moinul";
            pt.MiddleNameEng = "";
            pt.LastNameEng = "ABEDIN";
            pt.DOB = new DateTime(1977, 12, 1, 0, 0, 0);
            pt.Gender = "M";
            pt.Phone = "";
            pt.Address = "";
            pt.DoctorName = "000075";
            pt.DepartmentName = "1OW";

            //OrderItem Setup
            orders.Add(new OrderItems());
            orders[0].ACCESSION_NO = "4719";

            orders[0].Flag = "NW";
            //orders[0].Flag = "CA";
            //orders[0].Flag = "XO";

            orders[0].Order_ID = 0;
            orders[0].ExamCode = "XX32";
            orders[0].ExamName = "Chest Abdomen";
            orders[0].Priority = "R";

            EnvisionHL7 hl7 = new EnvisionHL7();
            ReturnOperation op = hl7.SendMessageORM(pt, orders.ToArray(), createName);
            //if (op.Type == "Complete")
            //    MessageBox.Show(op.Message, "Complete");
            //else
            //{
            //    MessageBox.Show(op.Message, "Error");
            //}
        }
    }


    internal class HL7TransLog {
        public DateTime REQUEST_TIMESTAMP;
        public string REQUESTING_IP;
        public string REQUESTING_USER;
        public string REQUEST_TYPE;

        public string PATIENT_DEMOGRAPHIC;
        public string EXAM_DETAILS;
        public string RESULT_TEXT;

        public string PACS_IP;
        public string PACS_PORT;
        public string GENERATED_HL7;
        public DateTime SENDING_TIMESTAMP;
        public string IS_SUCCESSFUL;

        public string ACK_TYPE;
        public string ACK_MSG;
        public string ACK_SENDING_IP;
        public DateTime ACK_TIMESTAMP;
    }
}
