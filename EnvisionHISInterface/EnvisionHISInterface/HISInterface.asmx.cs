using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using EnvisionInterface.BusinessLogic.ProcessRead;
using EnvisionInterface.Webservices.NMService;
using System.IO;
using EnvisionInterface.Common.Common;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace EnvisionHISInterface
{
    /// <summary>
    /// Summary description for HISInterface
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class HISInterface : System.Web.Services.WebService
    {
        [WebMethod]
        public string get_Version()
        {
            return "1.0.2.3";
        }
        [WebMethod]
        public DataSet SearchResultOfXrayMammogram(string HN, string Enc_ID, string Enc_Type)
        {
            DataSet ds = new DataSet();
            ProcessGetMammoICheckup prc = new ProcessGetMammoICheckup();
            prc.getData(HN, Enc_ID, Enc_Type);
            ds = prc.Result.Copy();
            ds.DataSetName = "MammoICheckup";
            return ds;
        }
        [WebMethod]
        public DataSet SearchResultOfXrayMammogramByDate(string Result_Date)
        {
            DataSet ds = new DataSet();
            ProcessGetMammoICheckup prc = new ProcessGetMammoICheckup();
            prc.getDataByDate(Result_Date);
            ds = prc.Result.Copy();
            ds.DataSetName = "MammoICheckupByDate";
            return ds;
        }
        [WebMethod]
        public string GetRISAppointmentsByMRN(string HN)
        {
            DataSet ds = new DataSet();
            ProcessGetAppointmentRama prc = new ProcessGetAppointmentRama();
            prc.getData(HN);
            ds = prc.Result.Clone();
            DataTable dt = prc.Result.Tables[0];
            if (HN == "4998308")
            {
                prc.getData(Config.HNTest);
                DataTable dtt = prc.Result.Tables[0];
                dt.Merge(dtt.Copy());
            }
            //foreach (DataRow rowX in dt.Rows)
            //    rowX["appointmentID"] = Convert.ToInt32("1" + rowX["appointmentId"].ToString());

            if (Config.IsActiveNM)
            {
                try
                {
                    //string readText = File.ReadAllText(@"D:\json.txt");
                    string readText = GET("getappointmentlistbymrn", HN, "th");
                    DataTable dtt = GetDataNM(dt.Clone(), readText);
                    DataSet dsNm = new DataSet();
                    dsNm.Tables.Add(dtt.Copy());


                    //ServiceRamaApp proxyNM = new ServiceRamaApp();
                    //proxyNM.Url = Config.NMWebserviceURL;
                    //string result = proxyNM.GetAppointmentListByMrn(HN, "th");
                    //DataSet dsNm = readXMLToDataset(result);
                    if (HN == "4998308")
                    {
                        string resultTest = GET("getappointmentlistbymrn", Config.HNTest, "th");
                        DataTable dttTest = GetDataNM(dt.Clone(), resultTest);
                        DataSet dsTest = new DataSet();
                        dsTest.Tables.Add(dttTest.Copy());
                        dsNm.Merge(dsTest.Copy());
                    }
                    if (dsNm.Tables.Count > 0)
                    {
                        DataTable dtNM = dsNm.Tables[0];
                        foreach (DataRow rowX in dtNM.Rows)
                            rowX["appointmentId"] = Convert.ToInt32("20" + rowX["appointmentId"].ToString());

                        dt.Merge(dtNM);
                        dt.AcceptChanges();
                    }
                }
                catch (Exception ex)
                {

                }
            }

            dt.Columns.Add("appointmentID");
            foreach (DataRow rowX in dt.Rows)
                rowX["appointmentID"] = rowX["appointmentId"];

            ds = dt.DataSet;
            ds.DataSetName = "AppointmentList_SCB";

            return ds.GetXml();
        }
        private DataSet readXMLToDataset(string xmlData)
        {
            StringReader theReader = new StringReader(xmlData);
            DataSet theDataSet = new DataSet();
            theDataSet.ReadXml(theReader);

            return theDataSet;
        }
        [WebMethod]
        public string GetRISAppointmentsDetailByAppID(int scheduleID)
        {
            DataSet ds = new DataSet();
            string strMode = scheduleID.ToString().Substring(0, 2);
            string strScheduleID = scheduleID.ToString().Substring(2);

            ProcessGetAppointmentRama prcTemp = new ProcessGetAppointmentRama();
            prcTemp.getDataByScheduleID(0);
            DataTable dtt = prcTemp.Result.Tables[0].Clone();

            if (strMode == "20")
            {
                string readText = GET("getappointmentdetailbyappointmentid", strScheduleID, "th");
                DataTable dttt = GetDataNM(dtt.Clone(), readText);
                DataSet dsNm = new DataSet();
                dsNm.Tables.Add(dttt.Copy());

                //ServiceRamaApp proxyNM = new ServiceRamaApp();
                //proxyNM.Url = Config.NMWebserviceURL;
                //string result = proxyNM.GetAppointmentDetailByAppointmentId(strScheduleID, "th");
                //DataSet dsNm = readXMLToDataset(result);
                DataTable dt = new DataTable();
                dt = dsNm.Tables[0];
                dt.TableName = "Table";
                ds.Tables.Add(dt.Copy());
                ds.DataSetName = "AppointmentDetail_SCB";
                return ds.GetXml();
            }
            else
            {
                if (strMode == "10")
                {
                    ProcessGetAppointmentRama prc = new ProcessGetAppointmentRama();
                    prc.getDataByScheduleID(Convert.ToInt32(strScheduleID));
                    ds = prc.Result.Copy();
                    ds.DataSetName = "AppointmentDetail_SCB";
                    return ds.GetXml();
                }
                else
                {
                    ProcessGetAppointmentRama prc = new ProcessGetAppointmentRama();
                    prc.getDataByXrayreqID(Convert.ToInt32(strScheduleID));
                    ds = prc.Result.Copy();
                    ds.DataSetName = "AppointmentDetail_SCB";
                    return ds.GetXml();
                }
            }
        }
        [WebMethod]
        public string GetRISAppointmentsByMRNByNM(string HN)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("mrn");
            dt.Columns.Add("titleName");
            dt.Columns.Add("firstName");
            dt.Columns.Add("lastName");
            dt.Columns.Add("appointmentId");
            dt.Columns.Add("appointmentDate");
            dt.Columns.Add("appointmentTime");
            dt.Columns.Add("activityCode");
            dt.Columns.Add("activityName");
            dt.Columns.Add("bookingID");
            dt.Columns.Add("bookingType");
            dt.Columns.Add("bookingDate");
            dt.Columns.Add("bookingBy");
            dt.Columns.Add("admissionDate");
            dt.Columns.Add("operationDate");
            dt.Columns.Add("patientType");
            dt.Columns.Add("sdloc");
            dt.Columns.Add("clinic");
            dt.Columns.Add("place");
            dt.Columns.Add("placeName");
            dt.Columns.Add("staffId");
            dt.Columns.Add("staffName");
            dt.Columns.Add("location");
            dt.Columns.Add("preparationInformation");
            dt.Columns.Add("eligible");
            dt.Columns.Add("moreDetail");
            dt.Columns.Add("clinicTelephoneNo");
            dt.Columns.Add("medicalCertificateStatus");
            dt.Columns.Add("appointmentStatus");
            dt.AcceptChanges();

            string readText = GET("getappointmentlistbymrn", HN, "th");
            //string readText = File.ReadAllText(@"D:\json.txt");

            DataTable dtt = GetDataNM(dt.Clone(), readText);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtt.Copy());
            return ds.GetXml();
        }
        [WebMethod]
        public string GetRISAppointmentsDetailByAppIDByNM(string scheduleID)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("mrn");
            dt.Columns.Add("titleName");
            dt.Columns.Add("firstName");
            dt.Columns.Add("lastName");
            dt.Columns.Add("appointmentId");
            dt.Columns.Add("appointmentDate");
            dt.Columns.Add("appointmentTime");
            dt.Columns.Add("activityCode");
            dt.Columns.Add("activityName");
            dt.Columns.Add("bookingID");
            dt.Columns.Add("bookingType");
            dt.Columns.Add("bookingDate");
            dt.Columns.Add("bookingBy");
            dt.Columns.Add("admissionDate");
            dt.Columns.Add("operationDate");
            dt.Columns.Add("patientType");
            dt.Columns.Add("sdloc");
            dt.Columns.Add("clinic");
            dt.Columns.Add("place");
            dt.Columns.Add("placeName");
            dt.Columns.Add("staffId");
            dt.Columns.Add("staffName");
            dt.Columns.Add("location");
            dt.Columns.Add("preparationInformation");
            dt.Columns.Add("eligible");
            dt.Columns.Add("moreDetail");
            dt.Columns.Add("clinicTelephoneNo");
            dt.Columns.Add("medicalCertificateStatus");
            dt.Columns.Add("appointmentStatus");
            dt.AcceptChanges();

            string readText = GET("getappointmentdetailbyappointmentid", scheduleID, "th");

            DataTable dtt = GetDataNM(dt.Clone(), readText);
            DataSet ds = new DataSet();
            ds.Tables.Add(dtt.Copy());
            return ds.GetXml();
        }

        private DataTable GetDataNM(DataTable dt,string json)
        {
            
            JObject jsonAll = (JObject)JsonConvert.DeserializeObject(json);
            string _message = ((JValue)jsonAll["message"]).Value.ToString();
            if (_message == "Success")
            {
                JArray array_request = (JArray)jsonAll["items"];
                for (int i = 0; i < array_request.Count; i++)
                {
                    JObject jsonItems = (JObject)JsonConvert.DeserializeObject(array_request[i].ToString());
                    DataRow addRow = dt.NewRow();
                    foreach (DataColumn col in dt.Columns)
                    {
                        addRow[col.ColumnName] = jsonItems[col.ColumnName];
                    }

                    //addRow["mrn"] = jsonItems["mrn"];
                    //addRow["titleName"] = jsonItems["titleName"];
                    //addRow["firstName"] = jsonItems["firstName"];
                    //addRow["lastName"] = jsonItems["lastName"];
                    //addRow["appointmentId"] = jsonItems["appointmentId"];
                    //addRow["appointmentDate"] = jsonItems["appointmentDate"];
                    //addRow["appointmentTime"] = jsonItems["appointmentTime"];
                    //addRow["activityCode"] = jsonItems["activityCode"];
                    //addRow["activityName"] = jsonItems["activityName"];
                    //addRow["bookingID"] = jsonItems["bookingID"];
                    //addRow["bookingType"] = jsonItems["bookingType"];
                    //addRow["bookingDate"] = jsonItems["bookingDate"];
                    //addRow["bookingBy"] = jsonItems["bookingBy"];
                    //addRow["admissionDate"] = jsonItems["admissionDate"];
                    //addRow["operationDate"] = jsonItems["operationDate"];
                    //addRow["patientType"] = jsonItems["patientType"];
                    //addRow["sdloc"] = jsonItems["sdloc"];
                    //addRow["clinic"] = jsonItems["clinic"];
                    //addRow["place"] = jsonItems["place"];
                    //addRow["placeName"] = jsonItems["placeName"];
                    //addRow["staffId"] = jsonItems["staffId"];
                    //addRow["staffName"] = jsonItems["staffName"];
                    //addRow["location"] = jsonItems["location"];
                    //addRow["preparationInformation"] = jsonItems["preparationInformation"];
                    //addRow["eligible"] = jsonItems["eligible"];
                    //addRow["moreDetail"] = jsonItems["moreDetail"];
                    //addRow["clinicTelephoneNo"] = jsonItems["clinicTelephoneNo"];
                    //addRow["medicalCertificateStatus"] = jsonItems["medicalCertificateStatus"];
                    //addRow["appointmentStatus"] = jsonItems["appointmentStatus"];
                    dt.Rows.Add(addRow);
                    dt.AcceptChanges();
                }
            }
            return dt;
        }
        private string GET(string method,string value,string lang)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Config.NMRestAPI + method + "//" + value + "//" + lang);
            //request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }

        }
    }
}
