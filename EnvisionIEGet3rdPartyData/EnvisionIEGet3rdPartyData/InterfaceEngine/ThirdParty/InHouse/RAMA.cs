using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using EnvisionInterfaceEngine.Connection;
using EnvisionInterfaceEngine.Operational;
using System.Net;
using System.IO;
using EnvisionIEGet3rdPartyData.Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace EnvisionIEGet3rdPartyData.InterfaceEngine.ThirdParty.InHouse
{
    public class RAMA : IBilling, IDemographic, IResult, ICheckSync
    {
        private readonly string title;

        public RAMA() { title = ToString(); }

        public string Check_Sync() {
            RISConnection ris = new RISConnection();
            ris.chekSync();
            return ""; 
        }
        public DataSet Get_Billing(DataSet data)
        {
            DataSet ds = new DataSet("EnvisionIE");
            return ds.Copy();
        }
        public DataSet Set_Billing(DataSet data)
        {
            DataSet ds = new DataSet("EnvisionIE");
            return ds.Copy();
        }
        public DataSet Set_PreBilling(DataSet data) { return new None().defaultValue(); }

        public DataSet Get_Demographic_Short(DataSet data) { return new None().defaultValue(); }
        public DataSet Get_Demographic(DataSet data)
        {
            DataSet ds = new DataSet("EnvisionIE");
            return ds.Copy();
        }
        public DataSet Get_PatientAllergy(DataSet data) { return new None().defaultValue(); }
        public DataSet Get_PatientLabData(DataSet data) { return new None().defaultValue(); }

        public DataSet Set_Demographic(DataSet data) { return new None().defaultValue(); }

        public DataSet Get_Result_Legacy(DataSet data) { return new None().defaultValue(); }

        public DataSet Set_Result(DataSet data)
        {
            DataSet ds = new DataSet("EnvisionIE");
            return ds.Copy();
        }
        public DataSet Set_ResultHasImage(DataSet data) { return new None().defaultValue(); }
        public bool Get_TeleMedByEncIdAndType(DataSet data)
        {
            bool flag = false;

            if (Utilities.HasData(data))
            {
                JObject obTele = new JObject();
                obTele.Add("encId", data.Tables[0].Rows[0]["encId"].ToString());
                obTele.Add("encType", data.Tables[0].Rows[0]["encType"].ToString());
                string _result = POSTTeleMed(obTele.ToString());
                //string _result = "{\"success\":true}";
                JObject jsonResult = (JObject)JsonConvert.DeserializeObject(_result);
                flag = Convert.ToBoolean(((JValue)jsonResult["success"]).Value.ToString());
            }

            return flag;
        }

        private string POSTTeleMed(string message)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://prod-nodeserv1:8080/TeleMedService/services/teleservice/searchTeleByEncIdAndType");
            request.Method = "POST";
            request.ContentType = @"application/json";

            using (Stream sw = request.GetRequestStream())
            {
                byte[] buffer = ConfigService.ThirdPartyEncoding.GetBytes(message);

                sw.Write(buffer, 0, buffer.Length);
            }

            using (Stream ms = request.GetResponse().GetResponseStream())
            {
                return new StreamReader(ms, ConfigService.ThirdPartyEncoding).ReadToEnd();
            }
        }
    }
}