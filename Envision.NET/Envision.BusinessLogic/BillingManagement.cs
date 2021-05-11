using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.BusinessLogic.ProcessRead;
using Envision.Common;

namespace Envision.BusinessLogic
{
    public class BillingManagement
    {
        /// <summary>
        /// MESSAGE ACKNOWLEGE FROM HIS_WEBSERVICE
        /// </summary>
        /// 
        // Send Billing Message
        public const string SUCCESS_SEND_BILLING = "Success in Set_Billing";
        public const string FAIL_SEND_BILLING = "Failed !!! in Set_Billing, Please connected to Programmers";
        // Cancel Billing Message
        public const string SUCCESS_CANCEL_BILLING = "Success in Cancel_Billing";
        public const string FAIL_CANCEL_BILLING = "Failed !!! in Cancel_Billing, Please connected to Programmers";
        // Connection fail Message
        private const string CONNECTION_FAIL = "Can't connect to HIS Webservice";

        private static ProcessGetRISBillingMessage processGetRISBillingMessage = null;
        private static HIS_Patient hisPatient = null;
        static BillingManagement()
        {
            processGetRISBillingMessage = new ProcessGetRISBillingMessage();
            hisPatient = new HIS_Patient();
        }
        /// <summary>
        /// This method use to genarate billing message
        /// </summary>
        /// <returns>billing message</returns>
        public static string GenarateBillingMessage(string accession_no, string user_name)
        {
            processGetRISBillingMessage.ACCESSION_NO = accession_no;
            processGetRISBillingMessage.CREATED_BY = user_name;
            processGetRISBillingMessage.Invoke();

            if (Miracle.Util.Utilities.IsHaveData(processGetRISBillingMessage.Result))
                return processGetRISBillingMessage.Result.Tables[0].Rows[0][0].ToString();
            return string.Empty;
        }

        /// <summary>
        /// This method use to send billing to HIS Webservice
        /// </summary>
        /// <param name="billingMessage">Billing Message</param>
        /// <param name="isSaveBillingLog">is Save Billing Log</param>
        /// <returns>is send ? (bool)</returns>
        public static bool SendBilling(string billingMessage, bool isSaveBillingLog)
        {
            bool isSend = true;
            //try
            //{
                string ackMsg = hisPatient.Set_Billing(billingMessage);
                if (ackMsg != SUCCESS_SEND_BILLING)
                {
                    if(isSaveBillingLog)
                        InsertBillingLog(billingMessage, FAIL_SEND_BILLING, "Set_Billing");
                    isSend = false;
                }
                else
                    if (isSaveBillingLog)
                        InsertBillingLog(billingMessage, SUCCESS_SEND_BILLING, "Set_Billing");
            //}
            //catch 
            //{
            //    isSend = false;
            //    if (isSaveBillingLog)
            //        InsertBillingLog(billingMessage, CONNECTION_FAIL);
            //}
            return isSend;
        }
        /// <summary>
        /// This method use to send billing to HIS Webservice
        /// </summary>
        /// <param name="accession_no">accession no</param>
        /// <param name="user_id">user id</param>
        /// <param name="isSaveBillingLog">is Save Billing Log</param>
        /// <returns>is send ? (bool)</returns>
        public static bool SendBilling(string accession_no, string user_name, bool isSaveBillingLog)
        {
            return SendBilling(GenarateBillingMessage(accession_no, user_name), isSaveBillingLog);
        }
        /// <summary>
        /// This method use to cancel send billing to HIS Webservice
        /// </summary>
        /// <param name="HN">Hosiptal Number</param>
        /// <param name="accession_no">Accession No</param>
        /// <param name="AN">Admission No</param>
        /// <param name="iseq">ISEQ</param>
        /// <returns>Is Canceled ? (bool)</returns>
        public static bool CancelSendBilling(string HN, string accession_no, string AN, string iseq, bool isSaveBillingLog)
        {
            bool isSend = true;
            try
            {
                if (hisPatient.Cancel_Billing(HN, accession_no, AN, iseq) != SUCCESS_CANCEL_BILLING)
                {
                    if (isSaveBillingLog)
                        InsertCancelBillingLog(HN, accession_no, AN, iseq, FAIL_CANCEL_BILLING);
                    isSend = false;
                }
                else
                    if (isSaveBillingLog)
                        InsertCancelBillingLog(HN, accession_no, AN, iseq, SUCCESS_CANCEL_BILLING);
            }
            catch
            {
                isSend = false;
                if (isSaveBillingLog)
                    InsertCancelBillingLog(HN, accession_no, AN, iseq, CONNECTION_FAIL);
            }
            return isSend;
        }
        /// <summary>
        /// This method use to insert billing log
        /// </summary>
        /// <param name="billingMessage">billing message</param>
        /// <param name="ackMessage">ack message</param>
        /// <returns></returns>
        private static bool InsertBillingLog(string billingMessage, string ackMessage, string billingType)
        {

            #region Set Parameters
            string[] msgs = billingMessage.Substring(billingMessage.IndexOf("#") + 1).Split(new string[] { "#" }, StringSplitOptions.None);

            string hn = msgs[1];
            string Acc = msgs[2];
            string AN = msgs[3];
            string ISEQ = msgs[4];
            string UNIT_UID = msgs[5];
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
            #endregion

            try
            {
                ProcessAddRISBillingtransactionlog insertMaster = new ProcessAddRISBillingtransactionlog();
                insertMaster.RISBillingtransactionlog.ACCESSION_NO = Acc;
                insertMaster.Invoke();

                ProcessAddRISBillingtransactionlogdtl insertDetail = new ProcessAddRISBillingtransactionlogdtl();
                insertDetail.RISBillingtransactionlogdtl.ACCESSION_NO = Acc;
                insertDetail.RISBillingtransactionlogdtl.BILLING_MSG = billingMessage;
                insertDetail.RISBillingtransactionlogdtl.BILLING_ACK_MSG = ackMessage;
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

                insertDetail.Invoke();
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// This method use to insert cancel billing log
        /// </summary>
        /// <param name="HN">Hosiptal Number</param>
        /// <param name="accession_no">Accession No</param>
        /// <param name="AN">Admission No</param>
        /// <param name="iseq">ISEQ</param>
        /// <param name="ack_msg">Ack Message</param>
        /// <returns></returns>
        private static bool InsertCancelBillingLog(string hn, string accession_No, string an, string iseq, string ack_msg)
        {
            try
            {
                ProcessAddRISBillingtransactionlog insertMaster = new ProcessAddRISBillingtransactionlog();
                insertMaster.RISBillingtransactionlog.ACCESSION_NO = accession_No;
                insertMaster.Invoke();

                ProcessAddRISBillingtransactionlogdtl insertDetail = new ProcessAddRISBillingtransactionlogdtl();
                insertDetail.RISBillingtransactionlogdtl.ACCESSION_NO = accession_No;
                insertDetail.RISBillingtransactionlogdtl.HN = hn;
                insertDetail.RISBillingtransactionlogdtl.AN = an;
                insertDetail.RISBillingtransactionlogdtl.BILLING_MSG = "";
                insertDetail.RISBillingtransactionlogdtl.BILLING_ACK_MSG = ack_msg;
                insertDetail.RISBillingtransactionlogdtl.BILLING_TYPE = "Cancel_Billing";
                insertDetail.RISBillingtransactionlogdtl.ORDER_DT = DateTime.Now;
                insertDetail.Invoke();
            }
            catch { return false; }
            return true;
        }
    }
}
