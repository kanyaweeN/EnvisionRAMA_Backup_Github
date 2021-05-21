using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using RAMA.WSDLServiceBilling;
using RAMA.WSDLService;
using System.Data;
using System.Xml;
using System.IO;
using System.Net;
using System.Text;

namespace PatientServices2010
{

    public class PatientWrapper
    {
        private string patient_url = ConfigurationSettings.AppSettings["patient_url"];
        private string patient_identification = ConfigurationSettings.AppSettings["patient_identification"];
        private string bill_url = ConfigurationSettings.AppSettings["bill_url"];
        private string appcenter_url = ConfigurationSettings.AppSettings["appcenter_url"];
        private string appcenter_lab_url = ConfigurationSettings.AppSettings["appcenter_lab_url"];
        private BillingService bt;
        private patientservice pt;
        private patientservice ptAppcenter;
        private PatientIdentificationService ptIdentification;

        public PatientWrapper()
        {
            pt = new patientservice();
            pt.Url = patient_url;

            bt = new BillingService();
            bt.Url = bill_url;

            ptAppcenter = new patientservice();
            ptAppcenter.Url = appcenter_url;

            ptIdentification = new PatientIdentificationService();
            ptIdentification.Url = patient_identification;
        }

        private DataTable XMLParser(string xmlcontent, string xmlpath)
        {
            try
            {
                XmlDataDocument doc = new XmlDataDocument();
                doc.DataSet.ReadXml(new StringReader(xmlcontent));
                DataSet ds = doc.DataSet;

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable("Error");
                dt.Rows.Add(xmlcontent);
                dt.Rows.Add(ex.Message);
                return dt;
            }
        }
        private DataTable XMLParser(string xmlcontent)
        {
            try
            {
                XmlDataDocument doc = new XmlDataDocument();
                doc.DataSet.ReadXml(new StringReader(xmlcontent));
                DataSet ds = doc.DataSet;

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable("Error");
                dt.Rows.Add(xmlcontent);
                dt.Rows.Add(ex.Message);
                return dt;
            }
        }
        private DataTable XMLParserSchema(string xmlcontent)
        {
            try
            {
                XmlDataDocument doc = new XmlDataDocument();
                doc.DataSet.ReadXmlSchema(new StringReader(xmlcontent));
                DataSet ds = doc.DataSet;

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                DataTable dt = new DataTable("Error");
                dt.Rows.Add(xmlcontent);
                dt.Rows.Add(ex.Message);
                return dt;
            }
        }

        #region Get Method.
        public DataTable Get_demographic_long(string hn)
        {
            string xmlresult = pt.Get_demographic_long(hn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_demographic_long_outsidepatient(string DeptCode, string refMrn)
        {
            string xmlresult = ptAppcenter.Get_demographic_long_outsidepatient(DeptCode, refMrn);

            if (xmlresult.Contains("<dob/>"))
            {
                //xmlcontent = xmlcontent.Replace
                //    ("<xsd:element name=\"dob\" type=\"xsd:date\"/>",
                //    "<xsd:element name=\"dob\" type=\"xsd:date\" nillable=\"true\"/>");
                //xmlcontent = xmlcontent.Replace("<dob/>", "<dob xsi:nil=\"true\"></dob>");
                xmlresult = xmlresult.Replace("<dob/>", "<dob>1753-01-01T00:00:00</dob>");
            }

            xmlresult = xmlresult.Replace("<gender>1</gender>", "<gender>M</gender>");
            xmlresult = xmlresult.Replace("<gender>2</gender>", "<gender>F</gender>");

            //if (xmlresult.Contains("<gender>1</gender>"))
            //    xmlresult = xmlresult.Replace("<gender>1</gender>", "<gender>M</gender>");
            //else
            //    xmlresult = xmlresult.Replace("<gender>0</gender>", "<gender>F</gender>");

            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_demographic_short(string hn)
        {
            string xmlresult = pt.Get_demographic_short(hn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_demographic_shortByName(string cName)
        {
            string xmlresult = pt.Get_demographic_shortByName(cName.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_ForeignDemographic(string pFHn)
        {
            string xmlresult = pt.Get_ForeignDemographic(pFHn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_Adr(string hn)
        {
            string xmlresult = pt.Get_Adr(hn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_ipd_detail(string hn)
        {
            string xmlresult = pt.Get_ipd_detail(hn.ToUpper().Trim());
            xmlresult = xmlresult.Replace("<discharge_date/>", "<discharge_date>1989-01-01</discharge_date>");
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        //public DataTable Get_appointment(string hn)
        //{
        //    string xmlresult = pt.Get_appointment(hn.ToUpper().Trim());
        //    DataTable retTable = XMLParser(xmlresult);
        //    return retTable;
        //}
        public DataTable Get_appointment_detail(string hn)
        {
            int lastTimeout = pt.Timeout;
            pt.Timeout = 1000 * 5;

            string xmlresult = pt.Get_appointment_detail(hn.ToUpper().Trim());

            pt.Timeout = lastTimeout;

            DataTable retTable;
            try
            {
                retTable = XMLParser(xmlresult);
            }
            catch
            {
                retTable = XMLParserSchema(xmlresult);
            }

            return retTable;
        }

        public DataTable Get_Claim_Amt(string hn, string accession_No)
        {
            string xmlresult = pt.Get_Claim_Amt(hn.ToUpper().Trim(), accession_No.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        //public DataTable Get_insurance_detail(string hn)
        //{
        //    string xmlresult = pt.Get_insurance_detail(hn.ToUpper().Trim());
        //    DataTable retTable = XMLParser(xmlresult);
        //    return retTable;
        //}

        public DataTable Get_ForeignXrayOrder(string pFHn)
        {
            string xmlresult = pt.Get_ForeignXrayOrder(pFHn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_Lab_order(string hn)
        {
            string xmlresult = pt.Get_Lab_order(hn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_Lab_OrderFull(string pHn)
        {

            string xmlresult = pt.Get_Lab_OrderFull(pHn).Trim();
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_Lab_OrderRegisted(string pHn)
        {
            string xmlresult = pt.Get_Lab_OrderRegisted(pHn).Trim();
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_lab_data(string hn)
        {
            string xmlresult = pt.Get_lab_data(hn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_lab_data_researchall(string pHn)
        {
            string xmlresult = pt.Get_lab_data_researchall(pHn);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_lab_data_researchbydate(string pHn, string pStartDate, string pEndDate)
        {
            string xmlresult = pt.Get_lab_data_researchbydate(pHn, pStartDate, pEndDate);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        //public DataTable Get_lab_datachem_outside(string pReqname)
        //{
        //    string xmlresult = pt.Get_lab_datachem_outside(pReqname).Trim();
        //    DataTable retTable = XMLParser(xmlresult);
        //    return retTable;
        //}
        //public DataTable Get_lab_datahemato_outside(string pReqname)
        //{
        //    string xmlresult = pt.Get_lab_datahemato_outside(pReqname).Trim();
        //    DataTable retTable = XMLParser(xmlresult);
        //    return retTable;
        //}
        //public DataTable Get_lab_dataimmuno_outside(string pReqname)
        //{
        //    string xmlresult = pt.Get_lab_dataimmuno_outside(pReqname).Trim();
        //    DataTable retTable = XMLParser(xmlresult);
        //    return retTable;
        //}
        //public DataTable Get_lab_dataua_outside(string pReqname)
        //{
        //    string xmlresult = pt.Get_lab_dataua_outside(pReqname).Trim();
        //    DataTable retTable = XMLParser(xmlresult);
        //    return retTable;
        //}
        //public DataTable Get_lab_datavirus_outside(string pReqname)
        //{
        //    string xmlresult = pt.Get_lab_datavirus_outside(pReqname).Trim();
        //    DataTable retTable = XMLParser(xmlresult);
        //    return retTable;
        //}

        public DataTable Get_MedPatient(string hn, string an)
        {
            string xmlresult = pt.Get_MedPatient(hn.ToUpper().Trim(), an.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_Payment_Status(string hn, string an, string accNo)
        {
            string xmlresult = pt.Get_Payment_Status(hn.ToUpper().Trim(), an.ToUpper().Trim(), accNo.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_payment_status_outsidepatient(string refMrn, string accession_No, string dept_Code)
        {
            //object ob = pt.Get_payment_status_outsidepatient(refMrn.ToUpper().Trim(), accession_No.ToUpper().Trim(), dept_Code.ToUpper().Trim());
            //DataTable retTable = XMLParser(ob.ToString());
            //return retTable;
            return null;
        }

        public DataTable Get_XrayOrder(string pHn)
        {
            string xmlresult = pt.Get_XrayOrder(pHn.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_all_exam(string exam_code)
        {
            string xmlresult = pt.Get_all_exam(exam_code.ToUpper().Trim());
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_Org_detail(string pOrgID)
        {
            string xmlresult = pt.Get_Org_detail(pOrgID);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_Place_detail(string pPlaceID)
        {
            string xmlresult = pt.Get_Place_detail(pPlaceID);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_sdloc_all()
        {
            string xmlresult = pt.Get_sdloc_all();
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_sdloc_detail(string pSrc)
        {
            string xmlresult = pt.Get_sdloc_detail(pSrc);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_staff_detail(string user_id, string password_id)
        {
            string xmlresult = pt.Get_staff_detail(user_id, password_id);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable Get_staff_fulldetail(string sCode)
        {
            string xmlresult = pt.Get_staff_fulldetail(sCode);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable Get_TubeID(string pHn, string pSpecimenType)
        {
            string xmlresult = pt.Get_TubeID(pHn, pSpecimenType);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public object Get_Version()
        {
            //string xmlresult = pt.Get_Version();
            //DataTable retTable = XMLParser(xmlresult);
            //return retTable;

            object obj = pt.Get_Version();
            return obj;
        }

        public DataTable GetEligibilityInsuranceDetail(string pMRN, string pEncType, string PEncID, string pSDLOC, string pPerfDate, string pClinicType)
        {
            string xmlresult = pt.GetEligibilityInsuranceDetail(pMRN, pEncType, PEncID, pSDLOC, pPerfDate, pClinicType);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }

        public DataTable GetEncounterDetailByMRNForToday(string pMRN)
        {
            string xmlresult = pt.GetEncounterDetailByMRNForToday(pMRN);
            DataTable retTable = XMLParser(xmlresult);
            retTable = ConvertDataType(retTable.Copy());
            return retTable;
        }
        public DataTable GetEncounterDetailByMRNDATE(string pMRN, string pCDate)
        {
            string xmlresult = pt.GetEncounterDetailByMRNDATE(pMRN, pCDate);
            DataTable retTable = XMLParser(xmlresult);
            return retTable;
        }
        public DataTable GetEncounterDetailByMRNENCTYPE(string pMRN, string pEncType)
        {
            string xmlresult = pt.GetEncounterDetailByMRNENCTYPE(pMRN, pEncType);
            DataTable retTable = XMLParser(xmlresult);
            retTable = ConvertDataType(retTable.Copy());
            return retTable;
        }
        public DataTable GetEncounterDetailClinicTypePriceType(string pMRN, string pStrProductCode, string pActiveDate, string pNonresident)
        {
            string xmlresult = pt.GetEncounterDetailClinicTypePriceType(pMRN, pStrProductCode, pActiveDate, pNonresident).ToString();
            DataTable retTable = XMLParser(xmlresult);
            //retTable = ConvertDataType(retTable.Copy());
            return retTable;
        }

        public DataTable ConvertDataType(DataTable oldTable)
        {
            DataTable tb = new DataTable("encounter_detail");
            foreach (DataColumn col in oldTable.Columns)
            {
                if (col.Caption != "enc_id")
                {
                    DataColumn col_enc_id = new DataColumn(col.Caption);
                    col_enc_id.DataType = col.DataType;
                    tb.Columns.Add(col_enc_id);
                }
                else
                {
                    DataColumn col_enc_id = new DataColumn("enc_id");
                    col_enc_id.DataType = System.Type.GetType("System.Int32");
                    tb.Columns.Add(col_enc_id);
                }
            }

            foreach (DataRow row in oldTable.Rows)
            {
                tb.Rows.Add(row.ItemArray);
            }

            return tb;
        }

        public DataTable searchPatientIdentificationByMRNandActiveDate(string pMRN, string ActiveDate)
        {
            string xmlresult = ptIdentification.searchPatientIdentificationByMRNandActiveDate(pMRN, ActiveDate);
            DataTable retTable = XMLParser(xmlresult);
            int maxStringLength = retTable.AsEnumerable()
.SelectMany(row => row.ItemArray.OfType<string>())
.Max(str => str.Length);
            foreach (DataColumn cols in retTable.Columns)
            {
                cols.MaxLength = maxStringLength;
            }
            retTable = ConvertDataType(retTable.Copy());
            return retTable;
        }

        public DataSet Get_Lab_Creatinine(string pBType, string pMRN, string pStartDate, string pEndDate)
        {
            DataSet ds = new DataSet();
            string _param = "pBType=" + pBType.Trim();
            _param += "&pMRN=" + pMRN.Trim();
            _param += "&pStartDate=" + pStartDate.Trim();
            _param += "&pEndDate=" + pEndDate.Trim();
            string urlString = appcenter_lab_url + "?" + _param;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlString);
            request.Method = "GET";
            using (Stream ms = request.GetResponse().GetResponseStream())
            {
                string result = new StreamReader(ms, Encoding.GetEncoding(Convert.ToInt32("65001"))).ReadToEnd();
                ds.ReadXml(new StringReader(result));
            }
            return ds;
        }
        public string Get_Lab_Creatinine_String(string pBType, string pMRN, string pStartDate, string pEndDate)
        {
            DataSet ds = new DataSet();
            string result = "";
            string _param = "pBType=" + pBType.Trim();
            _param += "&pMRN=" + pMRN.Trim();
            _param += "&pStartDate=" + pStartDate.Trim();
            _param += "&pEndDate=" + pEndDate.Trim();
            string urlString = appcenter_lab_url + "?" + _param;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlString);
            request.Method = "GET";
            using (Stream ms = request.GetResponse().GetResponseStream())
            {
                result = new StreamReader(ms, Encoding.GetEncoding(Convert.ToInt32("65001"))).ReadToEnd();
            }
            return result;
        }
        #endregion

        #region Set Method.
        public string Set_Billing_Deleted20120620(string xString)
        {
            //patientservice pt42 = new patientservice();
            ////patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_Billing(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            string xmlresult = pt.Set_Billing(xString);

            //DataTable retTable = XMLParser(xmlresult);
            return xmlresult;
        }
        public string Set_Billing(string xString)
        {
            string xmlresult = bt.Set_billing(xString);
            return xmlresult;
        }
        public DataTable Set_Billing_OutsidePatient(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_Billing_OutsidePatient(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            return null;
        }
        public DataTable Set_ConfirmTube(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_ConfirmTube(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            return null;
        }
        public DataTable Set_Demographic_Long_OutsidePatient(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //string xmlresult = pt42.Set_Demographic_Long_OutsidePatient(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(xmlresult, path);
            //return retTable;
            return null;
        }
        public DataTable Set_OR(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_OR(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            return null;
        }
        public DataTable Set_PAE(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_PAE(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            return null;
        }
        public DataTable Set_StaffPayroll(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_StaffPayroll(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            return null;
        }
        public DataTable Set_Ward2Xray(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_Ward2Xray(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            return null;
        }
        public DataTable Set_WorkStaff(string xString)
        {
            //patients_v42 pt42 = new patients_v42();
            //pt42.Url = "http://192.168.0.247/WebService/Patients_v42.WSDL";
            //object ob = pt42.Set_WorkStaff(xString);
            //string path = "/VFPDataSet/all_exam";
            //DataTable retTable = XMLParser(ob.ToString(), path);
            //return retTable;
            return null;
        }
        #endregion

        #region Cancel Method.
        public string Cancel_Billing_Deleted20120620(string hn, string accession_No, string an, string iseq)
        {
            //pt.Cancel_Billing(
            string xmlresult = pt.Cancel_Billing(hn.ToUpper().Trim(), accession_No.ToUpper().Trim(), an.ToUpper().Trim(), iseq.ToUpper().Trim());
            //DataTable retTable = XMLParser(xmlresult,);
            return xmlresult;
        }
        public string Cancel_Billing(string hn, string accession_No, string an, string iseq)
        {
            string xmlresult = bt.Cancel_billing(hn.ToUpper().Trim(), accession_No.ToUpper().Trim(), an.ToUpper().Trim(), iseq.ToUpper().Trim());
            return xmlresult;
        }
        #endregion

    }

}