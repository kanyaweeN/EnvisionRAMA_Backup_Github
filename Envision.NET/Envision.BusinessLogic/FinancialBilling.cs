using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

using Envision.Common;
using Envision.Common.Linq;
using Envision.DataAccess.Select;
using Envision.WebService.HISWebService;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;
using Envision.BusinessLogic.ProcessDelete;
using Miracle.HL7;
using Miracle.Translator;

namespace Envision.BusinessLogic
{
    public class FinancialBilling
    {
        public FinancialBilling()
        {

        }

        public DataSet GetBillingMessage(string ACCESSION_NO)
        {
            LookUpSelect lk = new LookUpSelect();
            return lk.GetBillingMessage(ACCESSION_NO);
        }

        public string Set_Billing(string billing_message)
        {
            HIS_Patient bill_ws = new HIS_Patient();
            string str_ack = bill_ws.Set_Billing(billing_message);
            InsertLog_SetBilling(billing_message, str_ack, "Set_Billing");
            return str_ack;
        }
        public string Resend_Billing(string billing_message)
        {
            HIS_Patient bill_ws = new HIS_Patient();
            string str_ack = bill_ws.Set_Billing(billing_message);
            InsertLog_SetBilling(billing_message, str_ack, "Resend_Billing");
            return str_ack;
        }
        public string Cancel_Billing(string HN, string ACCESSION_NO, string AN, string ISEQ)
        {
            HIS_Patient bill_ws = new HIS_Patient();
            string str_ack = bill_ws.Cancel_Billing(HN, ACCESSION_NO, AN, ISEQ);
            InsertLog_CancelBilling(HN, ACCESSION_NO, AN, ISEQ, str_ack);
            return str_ack;
        }

        public void InsertLog_SetBilling(string str_data, string ack_msg, string billingType)
        {
            string[] msgs = str_data.Substring(str_data.IndexOf("#") + 1).Split(new string[] { "#" }, StringSplitOptions.None);

            string hn = msgs[1];
            string Acc = msgs[2];
            string AN = msgs[3];
            string ISEQ = msgs[4];
            string UNIT_UID = msgs[5];

            //string str_date = msgs[6] + " " + msgs[19];
            //DateTime ORDER_DT = Convert.ToDateTime(str_date);

            string str_day = msgs[6].Split(new string[] { "/" }, StringSplitOptions.None)[0];
            string str_month = msgs[6].Split(new string[] { "/" }, StringSplitOptions.None)[1];
            string str_year = msgs[6].Split(new string[] { "/" }, StringSplitOptions.None)[2];
            string str_hour = msgs[19].Split(new string[] { ":" }, StringSplitOptions.None)[0];
            string str_minute = msgs[19].Split(new string[] { ":" }, StringSplitOptions.None)[1];

            int day = Convert.ToInt32(str_day);
            int month = Convert.ToInt32(str_month);
            int year = Convert.ToInt32(str_year);
            int hour = Convert.ToInt32(str_hour);
            int minute = Convert.ToInt32(str_minute);
            DateTime ORDER_DT = new DateTime(year, month, day, hour, minute, 0);

            string EXAM_UID = msgs[9];
            string QTY = msgs[10];
            string RATE = msgs[11];
            string AMOUNT = msgs[12];
            string HR_UNIT = msgs[13];
            string ORDER_DATE = msgs[18];
            string ORDER_TIME = msgs[19];
            string MSG_TYPE = msgs[20];
            string CLINIC_TYPE = msgs[21];
            string COL_22 = msgs[22];
            string INSURANCE_TYPE_UID = msgs[23];
            string RD = msgs[24];
            string COL_25 = msgs[25];
            string HR_EMP = msgs[26];

            string ENC_TYPE = msgs[28];
            string ENC_ID = msgs[29];


            ProcessAddRISBillingtransactionlog insertMaster
                = new ProcessAddRISBillingtransactionlog();
            insertMaster.RISBillingtransactionlog.ACCESSION_NO = Acc;
            try
            {
                insertMaster.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            ProcessAddRISBillingtransactionlogdtl insertDetail
                = new ProcessAddRISBillingtransactionlogdtl();
            insertDetail.RISBillingtransactionlogdtl.ACCESSION_NO = Acc;
            insertDetail.RISBillingtransactionlogdtl.BILLING_MSG = str_data;
            insertDetail.RISBillingtransactionlogdtl.BILLING_ACK_MSG = ack_msg;
            insertDetail.RISBillingtransactionlogdtl.HN = hn;
            insertDetail.RISBillingtransactionlogdtl.AN = AN;
            insertDetail.RISBillingtransactionlogdtl.ISEQ = ISEQ;
            insertDetail.RISBillingtransactionlogdtl.UNIT_UID = UNIT_UID;
            insertDetail.RISBillingtransactionlogdtl.ORDER_DT = ORDER_DT;
            //insertDetail.RISBillingtransactionlogdtl.ORDER_DT = DateTime.Now;
            insertDetail.RISBillingtransactionlogdtl.EXAM_UID = EXAM_UID;
            insertDetail.RISBillingtransactionlogdtl.QTY = Convert.ToInt32(QTY);
            insertDetail.RISBillingtransactionlogdtl.RATE = Convert.ToDecimal(RATE);
            insertDetail.RISBillingtransactionlogdtl.AMOUNT = Convert.ToDecimal(AMOUNT);
            insertDetail.RISBillingtransactionlogdtl.HR_UNIT = HR_UNIT;
            insertDetail.RISBillingtransactionlogdtl.MSG_TYPE = MSG_TYPE;
            insertDetail.RISBillingtransactionlogdtl.CLINIC_TYPE = CLINIC_TYPE;
            insertDetail.RISBillingtransactionlogdtl.INSURANCE_TYPE_UID = INSURANCE_TYPE_UID;
            insertDetail.RISBillingtransactionlogdtl.HR_EMP = HR_EMP;
            insertDetail.RISBillingtransactionlogdtl.CREATED_BY = new GBLEnvVariable().UserID;
            insertDetail.RISBillingtransactionlogdtl.BILLING_TYPE = billingType == "" ? "Set_Billing" : billingType;

            insertDetail.RISBillingtransactionlogdtl.ENC_TYPE = ENC_TYPE;
            insertDetail.RISBillingtransactionlogdtl.ENC_ID = ENC_ID;

            try
            {
                insertDetail.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void InsertLog_CancelBilling(string hn, string accession_No, string an, string iseq, string ack_msg)
        {
            ProcessAddRISBillingtransactionlog insertMaster
               = new ProcessAddRISBillingtransactionlog();
            insertMaster.RISBillingtransactionlog.ACCESSION_NO = accession_No;
            try
            {
                insertMaster.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ProcessAddRISBillingtransactionlogdtl insertDetail
                = new ProcessAddRISBillingtransactionlogdtl();
            insertDetail.RISBillingtransactionlogdtl.ACCESSION_NO = accession_No;
            insertDetail.RISBillingtransactionlogdtl.HN = hn;
            insertDetail.RISBillingtransactionlogdtl.AN = an;
            insertDetail.RISBillingtransactionlogdtl.BILLING_MSG = "";
            insertDetail.RISBillingtransactionlogdtl.BILLING_ACK_MSG = ack_msg;
            insertDetail.RISBillingtransactionlogdtl.BILLING_TYPE = "Cancel_Billing";
            insertDetail.RISBillingtransactionlogdtl.ORDER_DT = DateTime.Now;
            try
            {
                insertDetail.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadEncounter(string HN,string UNIT_UID, ref string ENC_ID, ref string ENC_TYPE)
        {
            try
            {

                if (HN.Trim().Length == 0) return;
                if (UNIT_UID.Trim().Length == 0) return;

                DataSet dsInsurance = new DataSet();
                DataSet dsExcount = new DataSet();


                string enc_id = " ";
                string enc_type = " ";
                DataRow[] rows_insurance;
                //string sdloc = " ";

                HIS_Patient p = new HIS_Patient();
                dsExcount = p.GetEncounterDetailByMRNForToday(HN);
                if (dsExcount.Tables[0].Rows.Count > 0)
                {
                    rows_insurance = dsExcount.Tables[0].Select
                        ("sdloc_id='" + UNIT_UID + "' AND enc_type <> 'OTH' AND statuscode = 'active'", " enc_id desc ");

                    if (rows_insurance.Length > 0)
                    {
                        enc_id = rows_insurance[0]["enc_id"].ToString();
                        enc_type = rows_insurance[0]["enc_type"].ToString();
                    }
                    else
                    {
                        dsExcount = p.GetEncounterDetailByMRNENCTYPE(HN, "ALL");
                        if (dsExcount.Tables[0].Rows.Count < 1)
                        {
                            enc_id = " ";
                            enc_type = " ";
                        }
                        else
                        {
                            rows_insurance = dsExcount.Tables[0].Select
                                ("sdloc_id='" + UNIT_UID + "' AND enc_type <> 'OTH' AND statuscode = 'active'", " enc_id desc ");

                            if (rows_insurance.Length > 0)
                            {
                                enc_id = rows_insurance[0]["enc_id"].ToString();
                                enc_type = rows_insurance[0]["enc_type"].ToString();
                            }
                            else
                            {
                                enc_id = " ";
                                enc_type = " ";
                            }
                        }
                    }
                }
                else
                {
                    dsExcount = p.GetEncounterDetailByMRNENCTYPE(HN, "ALL");
                    if (dsExcount.Tables[0].Rows.Count < 1)
                    {
                        enc_id = " ";
                        enc_type = " ";
                    }
                    else
                    {
                        rows_insurance = dsExcount.Tables[0].Select
                            ("sdloc_id='" + UNIT_UID + "' AND enc_type <> 'OTH' AND statuscode = 'active'", " enc_id desc ");

                        if (rows_insurance.Length > 0)
                        {
                            enc_id = rows_insurance[0]["enc_id"].ToString();
                            enc_type = rows_insurance[0]["enc_type"].ToString();
                        }
                        else
                        {
                            enc_id = " ";
                            enc_type = " ";
                        }
                    }
                }

                ENC_ID = enc_id == null ? " " : enc_id;
                ENC_TYPE = enc_type;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, ex.Source);
                ENC_ID = " ";
                ENC_TYPE = " ";
            }
        }
        public void LoadHRUnit(int UNIT_ID,ref string UNIT_UID,ref string UNIT_NAME)
        {
            DataTable data = RISBaseData.His_Department();
            DataRow[] drs = data.Select("UNIT_ID=" + UNIT_ID);
            if (drs.Length > 0)
            {
                UNIT_UID = drs[0]["UNIT_UID"].ToString();
                UNIT_NAME = drs[0]["UNIT_NAME"].ToString();
            }
            else
            {
                return;
            }
        }

        public void UpdateEncount(int ORDER_ID, string ENC_ID, string ENC_TYPE)
        {
            ProcessUpdateRISOrderEncounter update = new ProcessUpdateRISOrderEncounter();
            update.RIS_ORDER.ORDER_ID = ORDER_ID;
            update.RIS_ORDER.ENC_ID = ENC_ID;
            update.RIS_ORDER.ENC_TYPE = ENC_TYPE;
            update.Invoke();
        }


        public void UpdateEncount(int ORDER_ID, string ENC_ID, string ENC_TYPE, int REF_UNIT)
        {
            ProcessUpdateRISOrderEncounter update = new ProcessUpdateRISOrderEncounter();
            update.RIS_ORDER.ORDER_ID = ORDER_ID;
            update.RIS_ORDER.ENC_ID = ENC_ID;
            update.RIS_ORDER.ENC_TYPE = ENC_TYPE;
            update.RIS_ORDER.REF_UNIT = REF_UNIT;
            update.Invoke();
        }

        public string LoadGetEligibilityInsuranceDetail(string HN, string ENC_ID, string ENC_TYPE, string SDLOC, string PerfDate, string CLINIC_TYPE)
        {
            HIS_Patient p = new HIS_Patient();

            #region load get_ipd_deatil
            string AN = LoadAdmissinNo(HN);
            #endregion

            if (AN.Trim().Length == 0)
            {
                DataSet ds = p.GetEligibilityInsuranceDetail(HN, ENC_TYPE, ENC_ID, SDLOC, PerfDate, CLINIC_TYPE);
                DataTable dt = ds.Tables[0];
                return dt.Rows[0]["insurance"].ToString();
            }
            else
            {
                DataSet ds = p.GetEligibilityInsuranceDetail(HN, "IMP", AN, SDLOC, PerfDate, CLINIC_TYPE);
                DataTable dt = ds.Tables[0];
                return dt.Rows[0]["insurance"].ToString();
            }
        }

        public void LoadInsuranceType(string INSURANCE_UID, ref int INSURANCE_ID, ref string INSURANCE_NAME)
        {
            DataTable dtInsu = RISBaseData.Ris_InsuranceType();
            DataRow[] rows = dtInsu.Select("INSURANCE_TYPE_UID='" + INSURANCE_UID + "'");
            if (rows.Length > 0)
            {
                INSURANCE_ID = Convert.ToInt32(rows[0]["INSURANCE_TYPE_ID"]);
                INSURANCE_NAME = rows[0]["INSURANCE_TYPE_DESC"].ToString();
            }
            else
            {
                DataRow[] rows_UNK = dtInsu.Select("INSURANCE_TYPE_UID='UNK'");
                INSURANCE_ID = Convert.ToInt32(rows_UNK[0]["INSURANCE_TYPE_ID"]);
                INSURANCE_NAME = rows_UNK[0]["INSURANCE_TYPE_DESC"].ToString();
            }
        }

        public void LoadUNKInsuranceType(ref int INSURANCE_ID, ref string INSURANCE_UID, ref string INSURANCE_NAME)
        {
            DataTable dtInsu = RISBaseData.Ris_InsuranceType();
            DataRow[] rows_UNK = dtInsu.Select("INSURANCE_TYPE_UID='UNK'");
            INSURANCE_ID = Convert.ToInt32(rows_UNK[0]["INSURANCE_TYPE_ID"]);
            INSURANCE_UID = rows_UNK[0]["INSURANCE_TYPE_UID"].ToString();
            INSURANCE_NAME = rows_UNK[0]["INSURANCE_TYPE_DESC"].ToString();
        }

        public void UpdateHisSync(string ACCESSION_NO,string HIS_MSG)
        {
            ProcessUpdateRISOrderdtl dtl = new ProcessUpdateRISOrderdtl();

            dtl.RIS_ORDERDTL.ACCESSION_NO = ACCESSION_NO;
            if (HIS_MSG == "Success in Set_Billing")
                dtl.RIS_ORDERDTL.HIS_SYNC = 'Y';
            else
                dtl.RIS_ORDERDTL.HIS_SYNC = 'N';
            dtl.RIS_ORDERDTL.HIS_ACK = HIS_MSG;

            dtl.UpdateSend();
        }

        public string LoadAdmissinNo(string HN)
        {
            string AN = "";
            HIS_Patient p = new HIS_Patient();
            DataSet ds = p.Get_ipd_detail(HN.Trim());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                AN = ds.Tables[0].Rows[0]["an"].ToString();
            }
            else
                AN = "";

            return AN;
        }

        public void UpdateAddmissionNo(int ORDER_ID, string ADMISSION_NO)
        {
            ProcessUpdateRISOrderEncounter update = new ProcessUpdateRISOrderEncounter();
            update.RIS_ORDER.ORDER_ID = ORDER_ID;
            update.RIS_ORDER.ADMISSION_NO = ADMISSION_NO;
            update.Invoke_ADMISSION_NO();
        }

        public DataTable LoadCurrentEncounter(string ACCESSION_NO)
        {
            RISOrderSelectData dataAccess = new RISOrderSelectData();
            DataTable tb = dataAccess.GetOrderDataByAccession(ACCESSION_NO).Tables[0];
            return tb;
        }

        public bool CheckIsSendBilling(string ACCESSION_NO)
        {
            ProcessGetRISExam getDeferHISReconcile = new ProcessGetRISExam();
            DataTable table = getDeferHISReconcile.GetIsSendBilling(ACCESSION_NO);
            if (Miracle.Util.Utilities.IsHaveData(table))
            {
                string DEFER_HIS_RECONCILE = table.Rows[0]["DEFER_HIS_RECONCILE"].ToString();
                if (DEFER_HIS_RECONCILE == "Y")
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        public bool CheckIsSendBillingByHn(string hn)
        {
            bool flag = false;
            try
            {
            HIS_Patient p = new HIS_Patient();
            DataSet ds = p.Get_demographic_long(hn.Trim());
            
                if (ds != null)
                    if (ds.Tables.Count > 0)
                        flag = true;
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }
    }
}
