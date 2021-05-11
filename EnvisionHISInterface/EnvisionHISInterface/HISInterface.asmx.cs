using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;
using EnvisionInterface.BusinessLogic.ProcessRead;
using EnvisionInterface.Webservices.NMService;
using System.IO;
using EnvisionInterface.Common.Common;

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
                    ServiceRamaApp proxyNM = new ServiceRamaApp();
                    proxyNM.Url = Config.NMWebserviceURL;
                    string result = proxyNM.GetAppointmentListByMrn(HN, "th");
                    DataSet dsNm = readXMLToDataset(result);
                    if (HN == "4998308")
                    {
                        string resultTest = proxyNM.GetAppointmentListByMrn(Config.HNTest, "th");
                        dsNm.Merge(readXMLToDataset(resultTest).Copy());
                    }
                    if (dsNm.Tables.Count > 0)
                    {
                        DataTable dtNM = dsNm.Tables[0];
                        foreach (DataRow rowX in dtNM.Rows)
                            rowX["appointmentID"] = Convert.ToInt32("20" + rowX["appointmentId"].ToString());

                        dt.Merge(dtNM);
                        dt.AcceptChanges();
                    }
                }
                catch (Exception ex)
                {

                }
            }
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

            if (strMode == "20")
            {
                ServiceRamaApp proxyNM = new ServiceRamaApp();
                proxyNM.Url = Config.NMWebserviceURL;
                string result = proxyNM.GetAppointmentDetailByAppointmentId(strScheduleID, "th");
                DataSet dsNm = readXMLToDataset(result);
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
            ServiceRamaApp proxyNM = new ServiceRamaApp();
            proxyNM.Url = Config.NMWebserviceURL;
            string result = proxyNM.GetAppointmentListByMrn(HN, "th");
            DataSet dsNm = readXMLToDataset(result);
            if (dsNm.Tables.Count > 0)
            {
                DataTable dtNM = dsNm.Tables[0];
                foreach (DataRow rowX in dtNM.Rows)
                    rowX["appointmentID"] = Convert.ToInt32("2" + rowX["appointmentId"].ToString());
            }
            dsNm.DataSetName = "AppointmentList_SCB";

            return dsNm.GetXml();
        }
        [WebMethod]
        public string GetRISAppointmentsDetailByAppIDByNM(string scheduleID)
        {
            ServiceRamaApp proxyNM = new ServiceRamaApp();
            proxyNM.Url = Config.NMWebserviceURL;
            string result = proxyNM.GetAppointmentDetailByAppointmentId(scheduleID, "th");
            return result;
        }
    }
}
