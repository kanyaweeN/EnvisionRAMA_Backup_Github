//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Net;
//using System.Net.Sockets;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading;
//using EnvisionInterfaceEngine.Common.Miracle;
//using EnvisionInterfaceEngine.Connection;
//using EnvisionInterfaceEngine.Operational;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using EnvisionInterfaceEngine.WebService;
//using System.Data;
//using EnvisionInterfaceEngine.Common;
//using System.Xml;
//using EnvisionInterfaceEngine.Operational.HL7;
//using NHapi.Base.Parser;
//using NHapi.Base.Model;
//using EnvisionInterfaceEngine.Common.HL7;

//namespace ConsoleTestService
//{
//    static class Program
//    {
//        private static TcpListener tcpPortListner;
//        //static string url = "http://172.17.8.231/delay/rf/main.php";
//        static string url = @"http://sddn.med.cmu.ac.th/delay/rf/main.php";
//        //static string url = "http://172.17.9.8/delay/rf/main.php";

//        public static string IP
//        {
//            get { return ConfigurationManager.AppSettings["IP"]; }
//        }
//        public static int Port
//        {
//            get { return Convert.ToInt32(ConfigurationManager.AppSettings["Port"]); }
//        }

//        static List<string> hn_list;
//        static void Main()
//        {
//            RISConnection ris = new RISConnection();

//            DataTable dtt = ris.SelectData(@"
//SET NOCOUNT ON
//
//select
//	ord.ORDER_ID,
//	ord.ORDER_DT,
//	ord.VISIT_NO,
//	ord.ADMISSION_NO,
//    ord.REQUESTNO,
//    ord.CLINICAL_INSTRUCTION,
//	ords.EXAM_ID,
//	ords.Q_NO,
//    ords.ACCESSION_NO,
//    ords.INSTANCE_UID,
//	ords.[STATUS],
//	case ords.[PRIORITY]
//		when 'R' then 'R'
//		else 'S' -- Synapse not suppport urgent.
//	end [PRIORITY],
//	ords.LAST_MODIFIED_BY,
//    unit.UNIT_UID as REF_UNIT_UID,
//    unit.UNIT_NAME as REF_UNIT_NAME,
//	doc.EMP_UID as REF_DOC_UID,
//	doc.SALUTATION as REF_DOC_SALUTATION,
//	doc.FNAME as REF_DOC_FNAME,
//	doc.LNAME as REF_DOC_LNAME,
//	doc.TITLE_ENG as REF_DOC_TITLE_ENG,
//	doc.FNAME_ENG as REF_DOC_FNAME_ENG,
//	doc.LNAME_ENG as REF_DOC_LNAME_ENG,
//	rad.EMP_UID as ASSIGNED_TO_UID,
//	rad.SALUTATION as ASSIGNED_TO_SALUTATION,
//	rad.FNAME as ASSIGNED_TO_FNAME,
//	rad.LNAME as ASSIGNED_TO_LNAME,
//	rad.TITLE_ENG as ASSIGNED_TO_TITLE_ENG,
//	rad.FNAME_ENG as ASSIGNED_TO_FNAME_ENG,
//	rad.LNAME_ENG as ASSIGNED_TO_LNAME_ENG,
//    exam.EXAM_UID,
//    exam.EXAM_NAME,
//	exam.SERVICE_TYPE,
//    ISNULL(exam.DEFER_HIS_RECONCILE, 'N') as DEFER_HIS_RECONCILE,
//    modality_type.TYPE_NAME_ALIAS,
//	emp.EMP_UID as LAST_MODIFIED_UID,
//	emp.SALUTATION as LAST_MODIFIED_SALUTATION,
//	emp.FNAME as LAST_MODIFIED_FNAME,
//	emp.LNAME as LAST_MODIFIED_LNAME,
//    reg.HN,
//    reg.HIS_HN,
//    reg.TITLE as PATIENT_TITLE,
//    reg.FNAME as PATIENT_FNAME,
//    reg.LNAME as PATIENT_LNAME,
//    reg.TITLE_ENG as PATIENT_TITLE_ENG,
//    reg.FNAME_ENG as PATIENT_FNAME_ENG,
//    reg.LNAME_ENG as PATIENT_LNAME_ENG,
//    reg.SSN as PATIENT_SSN,
//    reg.GENDER as PATIENT_GENDER,
//    reg.DOB as PATIENT_DOB,
//    reg.ADDR1 as PATIENT_ADDR1,
//    reg.ADDR2 as PATIENT_ADDR2,
//    reg.ADDR3 as PATIENT_ADDR3,
//    reg.ADDR4 as PATIENT_ADDR4,
//    reg.ADDR5 as PATIENT_ADDR5,
//    reg.PHONE1 as PATIENT_PHONE1,
//    reg.PHONE2 as PATIENT_PHONE2,
//    case
//		when ord.IS_CANCELED = 'Y' then 'CA'
//        when ords.IS_DELETED = 'Y' then 'CA'
//        else 'NW'
//    end as OrderControl,
//    env.ORG_ID,
//    env.ORG_ALIAS
//from
//    RIS_ORDER ord
//    inner join RIS_ORDERDTL ords
//            on ord.ORDER_ID = ords.ORDER_ID
//            and ords.ACCESSION_NO = '5967303'
//        inner join RIS_EXAM exam
//                on ords.EXAM_ID = exam.EXAM_ID
//		left join RIS_MODALITY modality
//				on ords.MODALITY_ID = modality.MODALITY_ID
//		    left join RIS_MODALITYTYPE modality_type
//				    on modality.MODALITY_TYPE = modality_type.[TYPE_ID]
//		left join HR_EMP rad
//				on ords.ASSIGNED_TO = rad.EMP_ID
//        inner join HR_EMP emp
//                on ords.CREATED_BY = emp.EMP_ID
//    inner join HIS_REGISTRATION reg
//            on ord.REG_ID = reg.REG_ID
//    left join HR_UNIT unit
//            on ord.REF_UNIT = unit.UNIT_ID
//    left join HR_EMP doc
//            on ord.REF_DOC = doc.EMP_ID
//	inner join GBL_ENV env
//			on ord.ORG_ID = env.ORG_ID");

//            DataRow dr = dtt.Rows[0];

//            JObject order = new JObject();
//            order.Add("HN", dr["HIS_HN"].ToString());
//            order.Add("TITLE", dr["PATIENT_TITLE"].ToString());
//            order.Add("FNAME", dr["PATIENT_FNAME"].ToString());
//            order.Add("MNAME", string.Empty);
//            order.Add("LNAME", dr["PATIENT_LNAME"].ToString());
//            order.Add("TITLE_ENG", dr["PATIENT_TITLE_ENG"].ToString());
//            order.Add("FNAME_ENG", dr["PATIENT_FNAME_ENG"].ToString());
//            order.Add("MNAME_ENG", string.Empty);
//            order.Add("LNAME_ENG", dr["PATIENT_LNAME_ENG"].ToString());
//            order.Add("GENDER", dr["PATIENT_GENDER"].ToString());
//            order.Add("DOB", dr["PATIENT_DOB"].ToString());
//            order.Add("ADDRESS", string.Join(
//                string.Empty,
//                dr["PATIENT_ADDR1"].ToString(),
//                dr["PATIENT_ADDR2"].ToString(),
//                dr["PATIENT_ADDR3"].ToString(),
//                dr["PATIENT_ADDR4"].ToString(),
//                dr["PATIENT_ADDR5"].ToString()));
//            order.Add("PHONE", dr["PATIENT_PHONE1"].ToString());
//            order.Add("REQUEST_DATETIME", dr["ORDER_DT"].ToString());
//            order.Add("CLINICAL_DATA", dr["CLINICAL_INSTRUCTION"].ToString());
//            order.Add("INSURANCE_CODE", string.Empty);
//            order.Add("INSURANCE_DESC", string.Empty);
//            order.Add("EXAM_CODE", dr["EXAM_UID"].ToString());
//            order.Add("EXAM_NAME", dr["EXAM_NAME"].ToString());
//            //order.Add("RATE", dr["RATE"].ToString());
//            order.Add("UNIT_CODE", dr["REF_UNIT_UID"].ToString());
//            order.Add("UNIT_NAME", dr["REF_UNIT_NAME"].ToString());
//            order.Add("PHYSICIAN_CODE", dr["REF_DOC_UID"].ToString());
//            order.Add("PHYSICIAN_TITLE", dr["REF_DOC_SALUTATION"].ToString());
//            order.Add("PHYSICIAN_FNAME", dr["REF_DOC_FNAME"].ToString());
//            order.Add("PHYSICIAN_LNAME", dr["REF_DOC_LNAME"].ToString());
//            order.Add("PHYSICIAN_ENG_TITLE", dr["REF_DOC_TITLE_ENG"].ToString());
//            order.Add("PHYSICIAN_ENG_FNAME", dr["REF_DOC_FNAME_ENG"].ToString());
//            order.Add("PHYSICIAN_ENG_LNAME", dr["REF_DOC_LNAME_ENG"].ToString());
//            order.Add("PHYSICIAN_TEL", string.Empty);
//            order.Add("ACCESSION_NO", dr["ACCESSION_NO"].ToString());
//            order.Add("STATUS", dr["OrderControl"].ToString() == "CA" ? "D" : "N");

//            JObject message = new JObject();
//            message.Add("METHOD", "");
//            message.Add("PARAMS", order);
//            string result = message.ToString();
//            //POST2(url);
//            //POST3(url);
//            EnvisionIEGet3rdPartyData ws = new EnvisionIEGet3rdPartyData("http://127.0.0.1:8001/EnvisionIEGet3rdPartyData/");

//            HIS_REGISTRATION reg = new HIS_REGISTRATION();
//            reg.HN = "JF001";
//            reg.FNAME = "ทดสอบ";
//            reg.LNAME = "ระบบ";
//            DataSet ds = new DataSet();

//            ds.Tables.Add(Utilities.ConvertObjectToTable(reg));
            
//            ws.Set_Demographic(ds);

//            //string hn = "1234";
//            //string his_hn = "1234";
//            //int length = his_hn.Length;
//            //if (Utilities.HasData(new RISConnection().selectDataExistsRisOrderDtlByQNO("", 1)))
//            //{

//            //}
//            //tcpPortListner = new TcpListener(IPAddress.Parse(IP), Port);
//            //tcpPortListner.Start();


//            //while (true)
//            //{
//            //    Socket serverSocket = tcpPortListner.AcceptSocket();
//            //    StreamReader streamReader = new StreamReader(new NetworkStream(serverSocket));
//            //    Console.WriteLine(streamReader.ReadToEnd());
//            //}
//            //DateTime dateStart = DateTime.Now;
//            //Console.WriteLine(dateStart);
//            //hn_list = new List<string>();
//            //Welcome();

//            //for (int i = 0; i < 200; i++)
//            //    new Thread(new ThreadStart(Welcome)).Start();

//            while (Console.ReadKey().Key != ConsoleKey.Escape) { }
//            //tcpPortListner.Stop();
//        }

//        public static void Welcome()
//        {
//            string how = POST(url, @"{""method"":""get_ex_hn"",""params"":{""method"":""get_ex_hn"",""output"":""json"",""hn"":""""}}");

//            string value = string.Empty;

//            if (!string.IsNullOrEmpty(how))
//            {
//                how = how.Substring(1);
//                how = how.Substring(0, how.Length - 1);

//                string[] spilt_columns = how.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

//                foreach (string item in spilt_columns)
//                {
//                    MIStringArray _columns = new MIStringArray(item.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries));

//                    switch (_columns[0].Trim())
//                    {
//                        case "\"_value\"":
//                            value = _columns[1];
//                            break;
//                    }
//                }
//            }
//            string value_delay = string.Empty;

//            JArray obj2 = null;
//            int i = 0;

//            if (!string.IsNullOrEmpty(value))
//            {
//                while (obj2 == null)
//                {
//                    i++;

//                    value_delay = POST(url, @"{""method"":""get_delay_response"",""params"":{""method"":""get_delay_response"",""output"":""json"",""delay_service_nm"":""get_ex_hn"",""delay_id"":" + value + @",""timer"":3,""delay"":true}}");
//                    //string user_status = last_obj["user_status"].ToString().Trim().TrimStart('\"').TrimEnd('\"');
//                    //{"_code":0,"_value":"{\"HN\":\"3330043\",\"TITLE\":\"u0e19u0e32u0e07\",\"FNAME\":\"u0e2au0e35u0e04u0e33\",\"MNAME\":\"\",\"LNAME\":\"u0e27u0e34u0e17u0e22u0e32u0e04u0e21\",\"TITLE_ENG\":\"\",\"FNAME_ENG\":\"\",\"MNAME_ENG\":\"\",\"LNAME_ENG\":\"\",\"SSN\":\"3570400821087\",\"DOB\":\"1960-02-26\",\"ADDR1\":\"123 u0e21. 04\",\"ADDR2\":\" u0e15.  u0e2d. u0e40u0e17u0e34u0e07\",\"ADDR3\":\" u0e08. u0e40u0e0au0e35u0e22u0e07u0e23u0e32u0e22 \",\"ADDR4\":\"\",\"ADDR5\":\"\",\"PHONE1\":\"\",\"PHONE2\":\"053178117\",\"PHONE3\":\"\",\"EMAIL\":\"3330043\",\"GENDER\":\"u0e0d\",\"INSURANCE_TYPE_UID\":\"A1$\",\"INSURANCE_TYPE_DESC\":\"\",\"REF_UNIT_UID\":\"03-S05    \",\"REF_UNIT_NAME\":\"\"}","_msg":"success","_delay":0}
//                    JObject obj = (JObject)JsonConvert.DeserializeObject(value_delay);

//                    obj2 = (JArray)JsonConvert.DeserializeObject(((JValue)obj["_value"]).Value.ToString());

//                    if (obj2 != null)
//                    {
//                        for (int j = 0; j < 1/*obj2.Count*/; j++)
//                        {
//                            hn_list.Add((((Newtonsoft.Json.Linq.JValue)(obj2[j]["hn"]))).Value.ToString());
//                            //Welcome();
//                        }

//                        for (int j = 0; j < 1/*obj2.Count*/; j++)
//                        {
//                            new Thread(new ThreadStart(Welcome2)).Start();
//                        }
//                    }
//                }
//            }

//            //{""_code"":0,""_value"":""{\""_code\"":0,\""_value\"":{\""user_status\"":\""u0e24u0e17u0e18u0e34u0e40u0e14u0e0a u0e27u0e07u0e04u0e4cu0e08u0e31u0e19u0e17u0e23u0e4cu0e04u0e33<br\/>u0e21u0e2bu0e32u0e23u0e32u0e0au0e19u0e04u0e23u0e40u0e0au0e35u0e22u0e07u0e43u0e2bu0e21u0e48\"",\""hid\"":\""13780\""},\""_msg\"":\""success\""}"",""_msg"":""success"",""_delay"":0}
//            //	how = GET("http://61.19.199.184/delay/rf/main.php");

//        }
//        public static void Welcome2()
//        {
//            string hn_temp = hn_list[0];
//            hn_list.RemoveAt(0);

//            string how = POST(url, @"{""method"":""get_pt_by_hn"",""params"":{""method"":""get_pt_by_hn"",""output"":""json"",""hn"":""" + hn_temp + @"""}}");

//            string value = string.Empty;

//            if (!string.IsNullOrEmpty(how))
//            {
//                how = how.Substring(1);
//                how = how.Substring(0, how.Length - 1);

//                string[] spilt_columns = how.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

//                foreach (string item in spilt_columns)
//                {
//                    MIStringArray _columns = new MIStringArray(item.Split(new string[] { ":" }, StringSplitOptions.RemoveEmptyEntries));

//                    switch (_columns[0].Trim())
//                    {
//                        case "\"_value\"":
//                            value = _columns[1];
//                            break;
//                    }
//                }
//            }
//            string value_delay = string.Empty;

//            JObject obj2 = null;
//            int i = 0;

//            if (!string.IsNullOrEmpty(value))
//            {
//                while (obj2 == null)
//                {
//                    i++;

//                    value_delay = POST(url, @"{""method"":""get_delay_response"",""params"":{""method"":""get_delay_response"",""output"":""json"",""delay_service_nm"":""get_pt_by_hn"",""delay_id"":" + value + @",""timer"":3,""delay"":true}}");
//                    //string user_status = last_obj["user_status"].ToString().Trim().TrimStart('\"').TrimEnd('\"');
//                    //{"_code":0,"_value":"{\"HN\":\"3330043\",\"TITLE\":\"u0e19u0e32u0e07\",\"FNAME\":\"u0e2au0e35u0e04u0e33\",\"MNAME\":\"\",\"LNAME\":\"u0e27u0e34u0e17u0e22u0e32u0e04u0e21\",\"TITLE_ENG\":\"\",\"FNAME_ENG\":\"\",\"MNAME_ENG\":\"\",\"LNAME_ENG\":\"\",\"SSN\":\"3570400821087\",\"DOB\":\"1960-02-26\",\"ADDR1\":\"123 u0e21. 04\",\"ADDR2\":\" u0e15.  u0e2d. u0e40u0e17u0e34u0e07\",\"ADDR3\":\" u0e08. u0e40u0e0au0e35u0e22u0e07u0e23u0e32u0e22 \",\"ADDR4\":\"\",\"ADDR5\":\"\",\"PHONE1\":\"\",\"PHONE2\":\"053178117\",\"PHONE3\":\"\",\"EMAIL\":\"3330043\",\"GENDER\":\"u0e0d\",\"INSURANCE_TYPE_UID\":\"A1$\",\"INSURANCE_TYPE_DESC\":\"\",\"REF_UNIT_UID\":\"03-S05    \",\"REF_UNIT_NAME\":\"\"}","_msg":"success","_delay":0}
//                    JObject obj = (JObject)JsonConvert.DeserializeObject(value_delay);

//                    obj2 = (JObject)JsonConvert.DeserializeObject(((JValue)obj["_value"]).Value.ToString());

//                    if (obj2 != null)
//                    {
//                        string hn = ((JValue)(obj2["HN"])).Value.ToString();
//                        string title = ((JValue)(obj2["TITLE"])).Value.ToString();
//                        string fname = ((JValue)(obj2["FNAME"])).Value.ToString();
//                        string mname = ((JValue)(obj2["MNAME"])).Value.ToString();
//                        string lname = ((JValue)(obj2["LNAME"])).Value.ToString();
//                        string title_eng = ((JValue)(obj2["TITLE_ENG"])).Value.ToString();
//                        string fname_eng = ((JValue)(obj2["FNAME_ENG"])).Value.ToString();
//                        string mname_eng = ((JValue)(obj2["MNAME_ENG"])).Value.ToString();
//                        string lname_eng = ((JValue)(obj2["LNAME_ENG"])).Value.ToString();
//                        string ssn = ((JValue)(obj2["SSN"])).Value.ToString();
//                        string dob = ((JValue)(obj2["DOB"])).Value.ToString();
//                        string addr1 = ((JValue)(obj2["ADDR1"])).Value.ToString();
//                        string addr2 = ((JValue)(obj2["ADDR2"])).Value.ToString();
//                        string addr3 = ((JValue)(obj2["ADDR3"])).Value.ToString();
//                        string addr4 = ((JValue)(obj2["ADDR4"])).Value.ToString();
//                        string addr5 = ((JValue)(obj2["ADDR5"])).Value.ToString();
//                        string phone1 = ((JValue)(obj2["PHONE1"])).Value.ToString();
//                        string phone2 = ((JValue)(obj2["PHONE2"])).Value.ToString();
//                        string phone3 = ((JValue)(obj2["PHONE3"])).Value.ToString();
//                        string email = ((JValue)(obj2["EMAIL"])).Value.ToString();
//                        string gender = ((JValue)(obj2["GENDER"])).Value.ToString();
//                        string insurance_type_uid = ((JValue)(obj2["INSURANCE_TYPE_UID"])).Value.ToString();
//                        string insurance_type_desc = ((JValue)(obj2["INSURANCE_TYPE_DESC"])).Value.ToString();
//                        string ref_unit_uid = ((JValue)(obj2["REF_UNIT_UID"])).Value.ToString();
//                        string ref_unit_name = ((JValue)(obj2["REF_UNIT_NAME"])).Value.ToString();
//                        Console.WriteLine(DateTime.Now.ToString() + "     " + hn);
//                    }
//                }
//            }

//            //{""_code"":0,""_value"":""{\""_code\"":0,\""_value\"":{\""user_status\"":\""u0e24u0e17u0e18u0e34u0e40u0e14u0e0a u0e27u0e07u0e04u0e4cu0e08u0e31u0e19u0e17u0e23u0e4cu0e04u0e33<br\/>u0e21u0e2bu0e32u0e23u0e32u0e0au0e19u0e04u0e23u0e40u0e0au0e35u0e22u0e07u0e43u0e2bu0e21u0e48\"",\""hid\"":\""13780\""},\""_msg\"":\""success\""}"",""_msg"":""success"",""_delay"":0}
//            //	how = GET("http://61.19.199.184/delay/rf/main.php");

//        }
//        static string POST(string url, string content)
//        {
//            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//            request.Method = "POST";
//            request.ContentType = @"text/xml; charset=utf-8";

//            byte[] buffer = Encoding.UTF8.GetBytes(content);

//            using (Stream sw = request.GetRequestStream())
//                sw.Write(buffer, 0, buffer.Length);

//            using (Stream ms = request.GetResponse().GetResponseStream())
//                return new StreamReader(ms, Encoding.UTF8).ReadToEnd();

//            //using (Stream streamReceiver = request.GetResponse().GetResponseStream())
//            //{
//            //    BinaryReader sr = new BinaryReader(streamReceiver);
//            //    int i = 0;
//            //    int read = 0;
//            //    bool foundEsc = false;
//            //    do
//            //    {  
//            //        byte[] buffer = new byte[1];
//            //        read = sr.Read(buffer, 0, 1);
//            //        byte bb = (byte)'\\';

//            //        if (bb == buffer[0])
//            //        {
//            //            foundEsc = true;

//            //        }
//            //        else
//            //        {
//            //            if (foundEsc)
//            //            {
//            //                char cc = (char)buffer[0];
//            //                Console.WriteLine(i + " " + buffer[0] + "               " + (char)buffer[0]);
//            //            }
//            //            foundEsc = false;
//            //        }


//            //        i++;
//            //    }
//            //    while (read != 0);
//        }

//        public static byte[] EncryptTextToMemory(string Data, byte[] Key, byte[] IV)
//        {
//            try
//            {
//                // Create a MemoryStream.
//                MemoryStream mStream = new MemoryStream();

//                // Create a CryptoStream using the MemoryStream 
//                // and the passed key and initialization vector (IV).
//                CryptoStream cStream = new CryptoStream(mStream,
//                    new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV),
//                    CryptoStreamMode.Write);

//                // Convert the passed string to a byte array.
//                byte[] toEncrypt = new ASCIIEncoding().GetBytes(Data);

//                // Write the byte array to the crypto stream and flush it.
//                cStream.Write(toEncrypt, 0, toEncrypt.Length);
//                cStream.FlushFinalBlock();

//                // Get an array of bytes from the 
//                // MemoryStream that holds the 
//                // encrypted data.
//                byte[] ret = mStream.ToArray();

//                // Close the streams.
//                cStream.Close();
//                mStream.Close();

//                // Return the encrypted buffer.
//                return ret;
//            }
//            catch (CryptographicException e)
//            {
//                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
//                return null;
//            }

//        }
//        public static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV)
//        {
//            try
//            {
//                // Create a new MemoryStream using the passed 
//                // array of encrypted data.
//                MemoryStream msDecrypt = new MemoryStream(Data);

//                // Create a CryptoStream using the MemoryStream 
//                // and the passed key and initialization vector (IV).
//                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
//                    new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV),
//                    CryptoStreamMode.Read);

//                // Create buffer to hold the decrypted data.
//                byte[] fromEncrypt = new byte[Data.Length];

//                // Read the decrypted data out of the crypto stream
//                // and place it into the temporary buffer.
//                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

//                //Convert the buffer into a string and return it.
//                return new ASCIIEncoding().GetString(fromEncrypt);
//            }
//            catch (CryptographicException e)
//            {
//                Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
//                return null;
//            }
//        }
//    }
//}