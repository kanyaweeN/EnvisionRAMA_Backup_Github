using System;
using System.Data;
using System.Messaging;
using System.Threading;
using EnvisionInterfaceEngine.Common;
using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Connection;
using EnvisionInterfaceEngine.Connection.Engine;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.HL7;
using EnvisionInterfaceEngine.Operational.MSMQ;
using EnvisionInterfaceEngine.WebService;

namespace EnvisionIESender
{
    public class Sender : IDisposable
    {
        private readonly string title_log;
        private bool disposed = false;

        private ManualResetEvent manual_event;

        private DataView dv_3rd_party;

        private MessageQueue ADTByHNQueue;
        private MessageQueue ADTReconcileQueue;
        private MessageQueue ORMByAccessionNoQueue;
        private MessageQueue ORMByOrderIdQueue;
        private MessageQueue ORMBidirectionalByAccessionNoQueue;
        private MessageQueue ORMMergeByAccessionNoQueue;
        private MessageQueue ORUByAccessionNoQueue;

        public Sender() { title_log = ToString(); }
        ~Sender()
        {
            if (!disposed)
                Dispose();
        }

        public void Invoke()
        {
            Utilities.SaveLog(title_log, "Invoke()", "Begin", false);

            RISConnection ris = new RISConnection();
            dv_3rd_party = ris.selectDataIntegrationConfig().DefaultView;

            manual_event = new ManualResetEvent(false);

            try
            {
                manual_event.Reset();

                if (Utilities.HasData(dv_3rd_party))
                {
                    initializeADTByHNQueue();
                    initializeADTReconcileQueue();
                    initializeORMByAccessionNoQueue();
                    initializeORMByOrderIdQueue();
                    initializeORMBidirectionalByAccessionNoQueue();
                    initializeORMMergeByAccessionNoQueue();
                    initializeORUByAccessionNoQueue();
                    //sendORUByAccessionNo(0, "220420OERCR044", 1);
                }


                manual_event.WaitOne();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "Invoke()", ex.Message, true); }
        }
        public void Dispose()
        {
            Utilities.SaveLog(title_log, "Invoke()", "End", false);

            dv_3rd_party = null;

            if (ADTByHNQueue != null)
            {
                ADTByHNQueue.Close();
                ADTByHNQueue.Dispose();
                ADTByHNQueue = null;
            }
            if (ADTReconcileQueue != null)
            {
                ADTReconcileQueue.Close();
                ADTReconcileQueue.Dispose();
                ADTReconcileQueue = null;
            }
            if (ORMByAccessionNoQueue != null)
            {
                ORMByAccessionNoQueue.Close();
                ORMByAccessionNoQueue.Dispose();
                ORMByAccessionNoQueue = null;
            }
            if (ORMBidirectionalByAccessionNoQueue != null)
            {
                ORMBidirectionalByAccessionNoQueue.Close();
                ORMBidirectionalByAccessionNoQueue.Dispose();
                ORMBidirectionalByAccessionNoQueue = null;
            }
            if (ORMMergeByAccessionNoQueue != null)
            {
                ORMMergeByAccessionNoQueue.Close();
                ORMMergeByAccessionNoQueue.Dispose();
                ORMMergeByAccessionNoQueue = null;
            }
            if (ORUByAccessionNoQueue != null)
            {
                ORUByAccessionNoQueue.Close();
                ORUByAccessionNoQueue.Dispose();
                ORUByAccessionNoQueue = null;
            }

            disposed = true;
        }

        private void initializeADTByHNQueue()
        {
            try
            {
                ADTByHNQueue = MSMQManager.Initialize(Config.ADTByHNQueuePath);
                ADTByHNQueue.Formatter = new BinaryMessageFormatter();
                ADTByHNQueue.ReceiveCompleted += onADTByHNReceiveCompleted;
                ADTByHNQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeADTByHNQueue()", ex.Message, true); }
        }
        private void onADTByHNReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string hn = string.Empty;
            int org_id = 0;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                string[] temp_split = message.Body.ToString().Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                if (temp_split.Length == 2)
                {
                    log_id = Convert.ToInt32(message.Label);
                    hn = temp_split[0];
                    org_id = Convert.ToInt32(temp_split[1]);
                }

                if (!string.IsNullOrEmpty(hn) && org_id > 0)
                    sendADTByHN(log_id, hn, org_id);
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onADTByHNReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }
        }
        private void sendADTByHN(int logId, string hn, int orgId)
        {
            try
            {
                RISConnection ris = new RISConnection();
                DataTable dtt_adt = ris.selectDataHL7ADTByHN(hn, orgId);

                if (!Utilities.HasData(dtt_adt))
                    Utilities.SaveLog(title_log, "sendADTByHN(int logId, string hn, int orgId)", string.Format("Hn {0} OrgId {1} not found data", hn, orgId), false);
                else
                {
                    RIS_HL7IELOG log = new RIS_HL7IELOG();
                    log.LOG_ID = logId;

                    selectRisHL7IELog(log);

                    log.MESSAGE_TYPE = "ADT";
                    log.EVENT_TYPE = "A08";
                    log.HN = dtt_adt.Rows[0]["HN"].ToString();
                    log.ORG_ID = Convert.ToInt32(dtt_adt.Rows[0]["ORG_ID"]);
                    log.LAST_MODIFIED_BY = Convert.ToInt32(dtt_adt.Rows[0]["LAST_MODIFIED_BY"]);

                    int temp_sender = log.SENDER_ID; //keep owner
                    log.SENDER_ID = 0;

                    foreach (DataRowView drv_3rd_party in dv_3rd_party)
                    {
                        int work_station_id = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]);

                        foreach (DataRow dr_adt in dtt_adt.Rows)
                            dr_adt["ReceivingApplication"] = drv_3rd_party["WORK_STATION_UID"].ToString();

                        if (!Convert.ToBoolean(drv_3rd_party["SEND_ADT"])
                            || (temp_sender == work_station_id)
                            || (log.RECEIVER_ID > -1 && log.RECEIVER_ID != work_station_id)) continue;

                        int temp_id = log.LOG_ID;
                        int temp_receiver = log.RECEIVER_ID;

                        log.RECEIVER_ID = work_station_id;

                        HL7ACK hl7_ack = new HL7ACK();
                        try
                        {
                            if (Convert.ToBoolean(drv_3rd_party["USE_SOCKET"]))
                            {
                                GenerateADT.ConvertToHL7(dtt_adt);

                                log.HL7_TEXT = dtt_adt.Rows[0]["HL7_TEXT"].ToString();

                                hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), dtt_adt.Rows[0]["HL7_TEXT"].ToString());
                            }
                            else if (drv_3rd_party["WEB_SERVICE_URL"].ToString() != string.Empty)
                            {
                                DataSet ds = new DataSet("EnvisionIE");
                                ds.Tables.Add(dtt_adt.Copy());
                                ds.Tables[0].TableName = "HL7";
                                ds.AcceptChanges();

                                using (DataSet ds_ack = new EnvisionIEGet3rdPartyData(drv_3rd_party["WEB_SERVICE_URL"].ToString()).Set_Demographic(ds.Copy()))
                                {
                                    DataRow dr_ack = ds_ack.Tables["ACK"].Rows[0];

                                    hl7_ack.MSA.ACKNOWLEDGMENT_CODE = dr_ack["ACKNOWLEDGMENT_CODE"].ToString();
                                    hl7_ack.MSA.TEXT_MESSAGE = dr_ack["TEXT_MESSAGE"].ToString();

                                    log.HL7_TEXT = (dr_ack.Table.Columns.IndexOf("HL7_TEXT") == -1) ? string.Empty : dr_ack["HL7_TEXT"].ToString();
                                }
                            }
                            else
                            {
                                log.HL7_TEXT = string.Empty;

                                hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                                hl7_ack.MSA.TEXT_MESSAGE = string.Format("{0} config invalid", drv_3rd_party["WORK_STATION_UID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
                            hl7_ack.MSA.TEXT_MESSAGE = ex.Message;
                        }

                        log.ACKNOWLEDGMENT_CODE = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                        log.TEXT_MESSAGE = hl7_ack.MSA.TEXT_MESSAGE;

                        editLog(log);

                        if (temp_receiver > -1) break;

                        log.LOG_ID = temp_id;
                        log.RECEIVER_ID = temp_receiver;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendADTByHN(int logId, string hn, int orgId)", ex.Message, true);
            }
        }

        private void initializeADTReconcileQueue()
        {
            try
            {
                ADTReconcileQueue = MSMQManager.Initialize(Config.ADTReconcileQueuePath);
                ADTReconcileQueue.Formatter = new BinaryMessageFormatter();
                ADTReconcileQueue.ReceiveCompleted += onADTReconcileReceiveCompleted;
                ADTReconcileQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeADTReconcileQueue()", ex.Message, true); }
        }
        private void onADTReconcileReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string old_hn = string.Empty;
            string new_hn = string.Empty;
            int org_id = 0;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                string[] temp_split = message.Body.ToString().Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                if (temp_split.Length == 3)
                {
                    log_id = Convert.ToInt32(message.Label);
                    old_hn = temp_split[0];
                    new_hn = temp_split[1];
                    org_id = Convert.ToInt32(temp_split[2]);
                }

                if (!string.IsNullOrEmpty(old_hn) && !string.IsNullOrEmpty(new_hn) && org_id > 0)
                    sendADTReconcile(log_id, old_hn, new_hn, org_id);
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onADTReconcileReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }
        }
        private void sendADTReconcile(int logId, string oldHn, string newHn, int orgId)
        {
            try
            {
                RISConnection ris = new RISConnection();
                DataTable dtt_adt = ris.selectDataHL7ADTByHN(newHn, orgId);

                if (!Utilities.HasData(dtt_adt))
                    Utilities.SaveLog(title_log, "sendADTReconcile(int logId, string oldHn, string newHn, int orgId)", string.Format("NewHn {0} OrgId {1} not found data", newHn, orgId), false);
                else
                {
                    RIS_HL7IELOG log = new RIS_HL7IELOG();
                    log.LOG_ID = logId;

                    selectRisHL7IELog(log);

                    log.MESSAGE_TYPE = "ADT";
                    log.EVENT_TYPE = "A18";
                    log.HN = dtt_adt.Rows[0]["HN"].ToString();
                    log.COMPARE_VALUE = oldHn;
                    log.ORG_ID = Convert.ToInt32(dtt_adt.Rows[0]["ORG_ID"]);
                    log.LAST_MODIFIED_BY = Convert.ToInt32(dtt_adt.Rows[0]["LAST_MODIFIED_BY"]);

                    int temp_sender = log.SENDER_ID; //keep owner
                    log.SENDER_ID = 0;

                    foreach (DataRowView drv_3rd_party in dv_3rd_party)
                    {
                        int work_station_id = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]);

                        foreach (DataRow dr_adt in dtt_adt.Rows)
                            dr_adt["ReceivingApplication"] = drv_3rd_party["WORK_STATION_UID"].ToString();

                        if (!Convert.ToBoolean(drv_3rd_party["SEND_ADT_RECONCILE"])
                            || (temp_sender == work_station_id)
                            || (log.RECEIVER_ID > -1 && log.RECEIVER_ID != work_station_id)
                            || !Convert.ToBoolean(drv_3rd_party["USE_SOCKET"])) continue;

                        int temp_id = log.LOG_ID;
                        int temp_receiver = log.RECEIVER_ID;

                        log.RECEIVER_ID = work_station_id;

                        HL7ACK hl7_ack = new HL7ACK();
                        try
                        {
                            GenerateADT.ConvertToHL7Reconcile(dtt_adt, oldHn);

                            log.HL7_TEXT = dtt_adt.Rows[0]["HL7_TEXT"].ToString();

                            hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), dtt_adt.Rows[0]["HL7_TEXT"].ToString());
                        }
                        catch (Exception ex)
                        {
                            hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
                            hl7_ack.MSA.TEXT_MESSAGE = ex.Message;
                        }

                        log.ACKNOWLEDGMENT_CODE = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                        log.TEXT_MESSAGE = hl7_ack.MSA.TEXT_MESSAGE;

                        editLog(log);

                        if (temp_receiver > -1) break;

                        log.LOG_ID = temp_id;
                        log.RECEIVER_ID = temp_receiver;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendADTReconcile(int logId, string oldHn, string newHn, int orgId)", ex.Message, true);
            }
        }

        private void initializeORMByAccessionNoQueue()
        {
            try
            {
                ORMByAccessionNoQueue = MSMQManager.Initialize(Config.ORMByAccessionNoQueuePath);
                ORMByAccessionNoQueue.Formatter = new BinaryMessageFormatter();
                ORMByAccessionNoQueue.ReceiveCompleted += onORMByAccessionNoReceiveCompleted;
                ORMByAccessionNoQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeORMByAccessionNoQueue()", ex.Message, true); }
        }
        private void onORMByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string accession_no = string.Empty;
            int org_id = 0;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                string[] temp_split = message.Body.ToString().Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                if (temp_split.Length == 2)
                {
                    log_id = Convert.ToInt32(message.Label);
                    accession_no = temp_split[0];
                    org_id = Convert.ToInt32(temp_split[1]);
                }

                if (!string.IsNullOrEmpty(accession_no) && org_id > 0)
                    sendORMByAccessionNo(log_id, accession_no, org_id);
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onORMByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }
        }
        private void sendORMByAccessionNo(int logId, string accessionNo, int orgId)
        {
            try
            {
                RISConnection ris = new RISConnection();
                DataTable dtt_orm = ris.selectDataHL7ORMByAccessionNo(accessionNo, orgId);

                if (!Utilities.HasData(dtt_orm))
                    Utilities.SaveLog(title_log, "sendORMByAccessionNo(int logId, string accessionNo, int orgId)", string.Format("AccNo {0} OrgId {1} not found data", accessionNo, orgId), false);
                else
                {
                    RIS_HL7IELOG log = new RIS_HL7IELOG();
                    log.LOG_ID = logId;

                    selectRisHL7IELog(log);

                    log.MESSAGE_TYPE = "ORM";
                    log.EVENT_TYPE = "O01";
                    log.HN = dtt_orm.Rows[0]["HN"].ToString();
                    log.ACCESSION_NO = dtt_orm.Rows[0]["ACCESSION_NO"].ToString();
                    log.STATUS = Convert.ToChar(dtt_orm.Rows[0]["STATUS"]);
                    log.ORG_ID = Convert.ToInt32(dtt_orm.Rows[0]["ORG_ID"]);
                    log.LAST_MODIFIED_BY = Convert.ToInt32(dtt_orm.Rows[0]["LAST_MODIFIED_BY"]);

                    int temp_sender = log.SENDER_ID; //keep owner
                    log.SENDER_ID = 0;

                    foreach (DataRowView drv_3rd_party in dv_3rd_party)
                    {
                        int work_station_id = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]);

                        foreach (DataRow dr in dtt_orm.Rows)
                            dr["ReceivingApplication"] = drv_3rd_party["WORK_STATION_UID"].ToString();

                        if (!Convert.ToBoolean(drv_3rd_party["SEND_ORM"])
                            || (temp_sender == work_station_id)
                            || Utilities.ToInt(dtt_orm.Rows[0]["WORK_STATION_ID"].ToString()) == work_station_id
                            || (log.RECEIVER_ID > -1 && log.RECEIVER_ID != work_station_id)
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'P' && Utilities.ToInt(dtt_orm.Rows[0]["SERVICE_TYPE"].ToString()) != ConfigService.InvestigationServiceTypeId)
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'H' && dtt_orm.Rows[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")) continue;

                        int temp_id = log.LOG_ID;
                        int temp_receiver = log.RECEIVER_ID;

                        log.RECEIVER_ID = work_station_id;

                        HL7ACK hl7_ack = new HL7ACK();
                        try
                        {
                            if (Convert.ToBoolean(drv_3rd_party["USE_SOCKET"]))
                            {
                                GenerateORM.ConvertToHL7(dtt_orm);

                                log.HL7_TEXT = dtt_orm.Rows[0]["HL7_TEXT"].ToString();

                                hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), dtt_orm.Rows[0]["HL7_TEXT"].ToString());

                                if (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'P')
                                    ris.updateDataSentHL7ORM(log.ACCESSION_NO, log.ORG_ID, dtt_orm.Rows[0]["HL7_TEXT"].ToString(), hl7_ack.MSA.ACKNOWLEDGMENT_CODE == "AA" ? "Y" : "N");
                            }
                            else if (!string.IsNullOrEmpty(drv_3rd_party["WEB_SERVICE_URL"].ToString()))
                            {
                                DataSet ds = new DataSet("EnvisionIE");
                                ds.Tables.Add(dtt_orm.Copy());
                                ds.Tables[0].TableName = "HL7";
                                ds.AcceptChanges();

                                using (DataSet ds_ack = new EnvisionIEGet3rdPartyData(drv_3rd_party["WEB_SERVICE_URL"].ToString()).Set_Billing(ds.Copy()))
                                {
                                    DataRow dr_ack = ds_ack.Tables["ACK"].Rows[0];

                                    hl7_ack.MSA.ACKNOWLEDGMENT_CODE = dr_ack["ACKNOWLEDGMENT_CODE"].ToString();
                                    hl7_ack.MSA.TEXT_MESSAGE = dr_ack["TEXT_MESSAGE"].ToString();

                                    log.HL7_TEXT = (dr_ack.Table.Columns.IndexOf("HL7_TEXT") == -1) ? string.Empty : dr_ack["HL7_TEXT"].ToString();
                                }
                            }
                            else
                            {
                                log.HL7_TEXT = string.Empty;

                                hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                                hl7_ack.MSA.TEXT_MESSAGE = string.Format("{0} config invalid", drv_3rd_party["WORK_STATION_UID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
                            hl7_ack.MSA.TEXT_MESSAGE = ex.Message;
                        }

                        log.ACKNOWLEDGMENT_CODE = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                        log.TEXT_MESSAGE = hl7_ack.MSA.TEXT_MESSAGE;

                        editLog(log);

                        if (temp_receiver > -1) break;

                        log.LOG_ID = temp_id;
                        log.RECEIVER_ID = temp_receiver;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendORMByAccessionNo(int logId, string accessionNo, int orgId)", ex.Message, true);
            }
        }

        private void initializeORMByOrderIdQueue()
        {
            try
            {
                ORMByOrderIdQueue = MSMQManager.Initialize(Config.ORMByOrderIdQueuePath);
                ORMByOrderIdQueue.Formatter = new BinaryMessageFormatter();
                ORMByOrderIdQueue.ReceiveCompleted += onORMByOrderIdReceiveCompleted;
                ORMByOrderIdQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeORMByOrderIdQueue()", ex.Message, true); }
        }
        private void onORMByOrderIdReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            int order_id = 0;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                log_id = Convert.ToInt32(message.Label);
                order_id = Convert.ToInt32(message.Body);

                if (order_id > 0)
                    sendORMByOrderId(log_id, order_id);
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onORMByOrderIdReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }
        }
        private void sendORMByOrderId(int logId, int orderId)
        {
            try
            {
                RISConnection ris = new RISConnection();
                DataTable dtt = ris.selectDataHL7ORMByOrderId(orderId);

                if (!Utilities.HasData(dtt))
                    Utilities.SaveLog(title_log, "sendORMByOrderId(int logId, int orderId)", string.Format("OrderId {0} not found data", orderId), false);
                else
                {
                    foreach (DataRow dr_orm in dtt.Rows)
                        sendORMByAccessionNo(0, dr_orm["ACCESSION_NO"].ToString(), Utilities.ToInt(dr_orm["ORG_ID"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendORMByOrderId(int logId, int orderId)", ex.Message, true);
            }
        }
        /*private void sendORMByOrderId(int logId, int orderId)
        {
            try
            {
                RISConnection ris = new RISConnection();
                DataTable dtt = ris.selectDataHL7ORMByOrderId(orderId);

                if (!Utilities.HasData(dtt))
                    Utilities.SaveLog(title_log, "sendORMByOrderId(int logId, int orderId)", string.Format("OrderId {0} not found data", orderId), false);
                else
                {
                    GenerateORM.ConvertToHL7(dtt);

                    RIS_HL7IELOG log = new RIS_HL7IELOG();
                    log.LOG_ID = 0;
                    log.SENDER_ID = 0;
                    log.MESSAGE_TYPE = "ORM";
                    log.EVENT_TYPE = "O01";

                    foreach (DataRowView drv_3rd_party in dv_3rd_party)
                    {
                        if (!Convert.ToBoolean(drv_3rd_party["SEND_ORM"])) continue;

                        int work_station_id = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]);

                        log.RECEIVER_ID = work_station_id;

                        foreach (DataRow dr in dtt.Rows)
                        {
                            if (Utilities.ToInt(dr["WORK_STATION_ID"].ToString()) == work_station_id
                                || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'P' && Utilities.ToInt(dr["SERVICE_TYPE"].ToString()) == ConfigService.InvestigationServiceTypeId)
                                || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'H' && dr["DEFER_HIS_RECONCILE"].ToString() == "N"))
                            {
                                log.HN = dr["HN"].ToString();
                                log.ACCESSION_NO = dr["ACCESSION_NO"].ToString();
                                log.STATUS = Convert.ToChar(dr["STATUS"]);
                                log.HL7_TEXT = dr["HL7_TEXT"].ToString();
                                log.ORG_ID = Convert.ToInt32(dr["ORG_ID"]);
                                log.LAST_MODIFIED_BY = Convert.ToInt32(dr["LAST_MODIFIED_BY"]);

                                HL7ACK hl7_ack = new HL7ACK();
                                try
                                {
                                    if (Convert.ToBoolean(drv_3rd_party["USE_SOCKET"]))
                                    {
                                        hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), dr["HL7_TEXT"].ToString());

                                        if (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'P')
                                            ris.updateDataSentHL7ORM(log.ACCESSION_NO, log.ORG_ID, dr["HL7_TEXT"].ToString(), hl7_ack.MSA.ACKNOWLEDGMENT_CODE == "AA" ? "Y" : "N");
                                    }
                                    else if (!string.IsNullOrEmpty(drv_3rd_party["WEB_SERVICE_URL"].ToString()))
                                    {
                                        DataSet ds = new DataSet("EnvisionIE");
                                        ds.Tables.Add(dtt.Copy());
                                        ds.Tables[0].TableName = "HL7";
                                        ds.AcceptChanges();

                                        using (DataSet ds_ack = new EnvisionIEGet3rdPartyData(drv_3rd_party["WEB_SERVICE_URL"].ToString()).Set_Billing(ds.Copy()))
                                        {
                                            hl7_ack.MSA.ACKNOWLEDGMENT_CODE = ds_ack.Tables["ACK"].Rows[0]["ACKNOWLEDGMENT_CODE"].ToString();
                                            hl7_ack.MSA.TEXT_MESSAGE = ds_ack.Tables["ACK"].Rows[0]["TEXT_MESSAGE"].ToString();
                                        }
                                    }
                                    else
                                    {
                                        hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                                        hl7_ack.MSA.TEXT_MESSAGE = string.Format("{0} config invalid", drv_3rd_party["WORK_STATION_UID"].ToString());
                                    }
                                }
                                catch (Exception ex)
                                {
                                    hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
                                    hl7_ack.MSA.TEXT_MESSAGE = ex.Message;
                                }

                                log.ACKNOWLEDGMENT_CODE = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                                log.TEXT_MESSAGE = hl7_ack.MSA.TEXT_MESSAGE;

                                editLog(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendORMByOrderId(int logId, int orderId)", ex.Message, true);
            }
        }*/

        private void initializeORMBidirectionalByAccessionNoQueue()
        {
            try
            {
                ORMBidirectionalByAccessionNoQueue = MSMQManager.Initialize(Config.ORMBidirectionalByAccessionNoQueuePath);
                ORMBidirectionalByAccessionNoQueue.Formatter = new BinaryMessageFormatter();
                ORMBidirectionalByAccessionNoQueue.ReceiveCompleted += onORMBidirectionalByAccessionNoReceiveCompleted;
                ORMBidirectionalByAccessionNoQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeORMBidirectionalByAccessionNoQueue()", ex.Message, true); }
        }
        private void onORMBidirectionalByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string accession_no = string.Empty;
            int org_id = 0;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                string[] temp_split = message.Body.ToString().Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                if (temp_split.Length == 2)
                {
                    log_id = Convert.ToInt32(message.Label);
                    accession_no = temp_split[0];
                    org_id = Convert.ToInt32(temp_split[1]);
                }

                if (!string.IsNullOrEmpty(accession_no) && org_id > 0)
                    sendORMBidirectionalByAccessionNo(log_id, accession_no, org_id);
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onORMBidirectionalByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }
        }
        private void sendORMBidirectionalByAccessionNo(int logId, string accessionNo, int orgId)
        {
            try
            {
                RISConnection ris = new RISConnection();
                DataTable dtt_orm = ris.selectDataHL7ORMByAccessionNo(accessionNo, orgId);

                if (!Utilities.HasData(dtt_orm))
                    Utilities.SaveLog(title_log, "sendORMBidirectionalByAccessionNo(int logId, string accessionNo, int orgId)", string.Format("AccNo {0} OrgId {1} not found data", accessionNo, orgId), false);
                else
                {
                    RIS_HL7IELOG log = new RIS_HL7IELOG();
                    log.LOG_ID = logId;

                    selectRisHL7IELog(log);

                    log.MESSAGE_TYPE = "ORM";
                    log.EVENT_TYPE = "BDR";
                    log.HN = dtt_orm.Rows[0]["HN"].ToString();
                    log.ACCESSION_NO = dtt_orm.Rows[0]["ACCESSION_NO"].ToString();
                    log.STATUS = Convert.ToChar(dtt_orm.Rows[0]["STATUS"]);
                    log.ORG_ID = Convert.ToInt32(dtt_orm.Rows[0]["ORG_ID"]);
                    log.LAST_MODIFIED_BY = Convert.ToInt32(dtt_orm.Rows[0]["LAST_MODIFIED_BY"]);

                    int temp_sender = log.SENDER_ID; //keep owner
                    log.SENDER_ID = 0;

                    foreach (DataRowView drv_3rd_party in dv_3rd_party)
                    {
                        int work_station_id = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]);

                        foreach (DataRow dr_orm in dtt_orm.Rows)
                            dr_orm["ReceivingApplication"] = drv_3rd_party["WORK_STATION_UID"].ToString();

                        if (!Convert.ToBoolean(drv_3rd_party["SEND_ORM_BIDIRECTIONAL"])
                            || (temp_sender == work_station_id)
                            || (log.RECEIVER_ID > -1 && log.RECEIVER_ID != work_station_id)
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'P' && Utilities.ToInt(dtt_orm.Rows[0]["SERVICE_TYPE"].ToString()) != ConfigService.InvestigationServiceTypeId)
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'H' && dtt_orm.Rows[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'H' && Utilities.ToInt(dtt_orm.Rows[0]["WORK_STATION_ID"].ToString()) != work_station_id)) continue;

                        int temp_id = log.LOG_ID;
                        int temp_receiver = log.RECEIVER_ID;

                        log.RECEIVER_ID = work_station_id;

                        HL7ACK hl7_ack = new HL7ACK();
                        try
                        {
                            if (Convert.ToBoolean(drv_3rd_party["USE_SOCKET"]))
                            {
                                GenerateORM.ConvertToHL7(dtt_orm);

                                log.HL7_TEXT = dtt_orm.Rows[0]["HL7_TEXT"].ToString();

                                hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), dtt_orm.Rows[0]["HL7_TEXT"].ToString());
                            }
                            else if (drv_3rd_party["WEB_SERVICE_URL"].ToString() != string.Empty)
                            {
                                DataSet ds = new DataSet("EnvisionIE");
                                ds.Tables.Add(dtt_orm.Copy());
                                ds.Tables[0].TableName = "HL7";
                                ds.AcceptChanges();

                                using (DataSet ds_ack = new EnvisionIEGet3rdPartyData(drv_3rd_party["WEB_SERVICE_URL"].ToString()).Set_ResultHasImage(ds.Copy()))
                                {
                                    DataRow dr_ack = ds_ack.Tables["ACK"].Rows[0];

                                    hl7_ack.MSA.ACKNOWLEDGMENT_CODE = dr_ack["ACKNOWLEDGMENT_CODE"].ToString();
                                    hl7_ack.MSA.TEXT_MESSAGE = dr_ack["TEXT_MESSAGE"].ToString();

                                    log.HL7_TEXT = (dr_ack.Table.Columns.IndexOf("HL7_TEXT") == -1) ? string.Empty : dr_ack["HL7_TEXT"].ToString();
                                }
                            }
                            else
                            {
                                log.HL7_TEXT = string.Empty;

                                hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                                hl7_ack.MSA.TEXT_MESSAGE = string.Format("{0} config invalid", drv_3rd_party["WORK_STATION_UID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
                            hl7_ack.MSA.TEXT_MESSAGE = ex.Message;
                        }

                        log.ACKNOWLEDGMENT_CODE = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                        log.TEXT_MESSAGE = hl7_ack.MSA.TEXT_MESSAGE;

                        editLog(log);

                        if (temp_receiver > -1) break;

                        log.LOG_ID = temp_id;
                        log.RECEIVER_ID = temp_receiver;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendORMBidirectionalByAccessionNo(int logId, string accessionNo, int orgId)", ex.Message, true);
            }
        }

        private void initializeORMMergeByAccessionNoQueue()
        {
            try
            {
                ORMBidirectionalByAccessionNoQueue = MSMQManager.Initialize(Config.ORMMergeByAccessionNoQueuePath);
                ORMBidirectionalByAccessionNoQueue.Formatter = new BinaryMessageFormatter();
                ORMBidirectionalByAccessionNoQueue.ReceiveCompleted += onORMMergeByAccessionNoReceiveCompleted;
                ORMBidirectionalByAccessionNoQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeORMMergeByAccessionNoQueue()", ex.Message, true); }
        }
        private void onORMMergeByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string accession_no = string.Empty;
            int org_id = 0;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                string[] temp_split = message.Body.ToString().Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                if (temp_split.Length == 2)
                {
                    log_id = Convert.ToInt32(message.Label);
                    accession_no = temp_split[0];
                    org_id = Convert.ToInt32(temp_split[1]);
                }

                if (!string.IsNullOrEmpty(accession_no) && org_id > 0)
                    sendORMMergeByAccessionNo(log_id, accession_no, org_id);
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onORMMergeByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }
        }
        private void sendORMMergeByAccessionNo(int logId, string accessionNo, int orgId)
        {
            try
            {
                RISConnection ris = new RISConnection();
                DataTable dtt_orm = ris.selectDataHL7ORMByAccessionNo(accessionNo, orgId);

                if (!Utilities.HasData(dtt_orm))
                    Utilities.SaveLog(title_log, "sendORMMergeByAccessionNo(int logId, string accessionNo, int orgId)", string.Format("AccNo {0} OrgId {1} not found data", accessionNo, orgId), false);
                else
                {
                    RIS_HL7IELOG log = new RIS_HL7IELOG();
                    log.LOG_ID = logId;

                    selectRisHL7IELog(log);

                    log.MESSAGE_TYPE = "ORM";
                    log.EVENT_TYPE = "MGR";
                    log.HN = dtt_orm.Rows[0]["HN"].ToString();
                    log.ACCESSION_NO = dtt_orm.Rows[0]["ACCESSION_NO"].ToString();
                    log.STATUS = Convert.ToChar(dtt_orm.Rows[0]["STATUS"]);
                    log.ORG_ID = Convert.ToInt32(dtt_orm.Rows[0]["ORG_ID"]);
                    log.LAST_MODIFIED_BY = Convert.ToInt32(dtt_orm.Rows[0]["LAST_MODIFIED_BY"]);

                    int temp_sender = log.SENDER_ID; //keep owner
                    log.SENDER_ID = 0;

                    foreach (DataRowView drv_3rd_party in dv_3rd_party)
                    {
                        int work_station_id = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]);

                        foreach (DataRow dr_orm in dtt_orm.Rows)
                            dr_orm["ReceivingApplication"] = drv_3rd_party["WORK_STATION_UID"].ToString();

                        if (!Convert.ToBoolean(drv_3rd_party["SEND_ORM_MERGE"])
                            || (temp_sender == work_station_id)
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'P' && Utilities.ToInt(dtt_orm.Rows[0]["SERVICE_TYPE"].ToString()) != ConfigService.InvestigationServiceTypeId)
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'H' && dtt_orm.Rows[0]["DEFER_HIS_RECONCILE"].ToString() == "Y")
                            || !Convert.ToBoolean(drv_3rd_party["USE_SOCKET"])) continue;

                        int temp_id = log.LOG_ID;
                        int temp_receiver = log.RECEIVER_ID;

                        log.RECEIVER_ID = work_station_id;

                        HL7ACK hl7_ack = new HL7ACK();
                        try
                        {
                            dtt_orm.Rows[0]["Hl7OrderControl"] = "SM";
                            GenerateORM.ConvertToHL7(dtt_orm);
                            dtt_orm.Columns["HL7_TEXT"].ColumnName = "HL7_TEXT_MERGE";
                            dtt_orm.AcceptChanges();
                            dtt_orm.Rows[0]["Hl7OrderControl"] = "NW";
                            GenerateORM.ConvertToHL7(dtt_orm);
                            dtt_orm.AcceptChanges();

                            log.HL7_TEXT = dtt_orm.Rows[0]["HL7_TEXT_MERGE"].ToString();

                            hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), dtt_orm.Rows[0]["HL7_TEXT"].ToString());

                            if (hl7_ack.MSA.ACKNOWLEDGMENT_CODE == "AA")
                                hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), dtt_orm.Rows[0]["HL7_TEXT_MERGE"].ToString());
                        }
                        catch (Exception ex)
                        {
                            hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
                            hl7_ack.MSA.TEXT_MESSAGE = ex.Message;
                        }

                        log.ACKNOWLEDGMENT_CODE = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                        log.TEXT_MESSAGE = hl7_ack.MSA.TEXT_MESSAGE;

                        editLog(log);

                        if (temp_receiver > -1) break;

                        log.LOG_ID = temp_id;
                        log.RECEIVER_ID = temp_receiver;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendORMMergeByAccessionNo(int logId, string accessionNo, int orgId)", ex.Message, true);
            }
        }

        private void initializeORUByAccessionNoQueue()
        {
            try
            {
                ORUByAccessionNoQueue = MSMQManager.Initialize(Config.ORUByAccessionNoQueuePath);
                ORUByAccessionNoQueue.Formatter = new BinaryMessageFormatter();
                ORUByAccessionNoQueue.ReceiveCompleted += onORUByAccessionNoReceiveCompleted;
                ORUByAccessionNoQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeORUByAccessionNoQueue()", ex.Message, true); }
        }
        private void onORUByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string accession_no = string.Empty;
            int org_id = 0;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                string[] temp_split = message.Body.ToString().Split(new string[] { "^" }, StringSplitOptions.RemoveEmptyEntries);

                if (temp_split.Length == 2)
                {
                    log_id = Convert.ToInt32(message.Label);
                    accession_no = temp_split[0];
                    org_id = Convert.ToInt32(temp_split[1]);
                }

                if (!string.IsNullOrEmpty(accession_no) && org_id > 0)
                    sendORUByAccessionNo(log_id, accession_no, org_id);
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onORUByAccessionNoReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }
        }
        private void sendORUByAccessionNo(int logId, string accessionNo, int orgId)
        {
            try
            {
                bool isStatReport = false;
                RISConnection ris = new RISConnection();
                DataSet ds_oru = ris.selectDataHL7ORUByAccessionNo(accessionNo, orgId);

                if (!Utilities.HasData(ds_oru))
                {
                    ds_oru = ris.selectDataHL7ORUStatByAccessionNo(accessionNo, orgId);
                    isStatReport = true;
                }
                if (!Utilities.HasData(ds_oru))
                    Utilities.SaveLog(title_log, "sendORUByAccessionNo(int logId, string accessionNo, int orgId)", string.Format("AccNo {0} OrgId {1} not found data", accessionNo, orgId), false);
                else
                {
                    RIS_HL7IELOG log = new RIS_HL7IELOG();
                    log.LOG_ID = logId;

                    selectRisHL7IELog(log);

                    log.MESSAGE_TYPE = "ORU";
                    log.EVENT_TYPE = "R01";
                    log.HN = ds_oru.Tables[0].Rows[0]["HN"].ToString();
                    log.ACCESSION_NO = ds_oru.Tables[0].Rows[0]["ACCESSION_NO"].ToString();
                    log.STATUS = Convert.ToChar(ds_oru.Tables[0].Rows[0]["RESULT_STATUS"]);
                    log.ORG_ID = Convert.ToInt32(ds_oru.Tables[0].Rows[0]["ORG_ID"]);
                    log.LAST_MODIFIED_BY = Convert.ToInt32(ds_oru.Tables[0].Rows[0]["LAST_MODIFIED_BY"]);

                    int temp_sender = log.SENDER_ID; //keep owner
                    log.SENDER_ID = 0;

                    foreach (DataRowView drv_3rd_party in dv_3rd_party)
                    {
                        int work_station_id = Convert.ToInt32(drv_3rd_party["WORK_STATION_ID"]);

                        foreach (DataRow dr_oru in ds_oru.Tables[0].Rows)
                            dr_oru["ReceivingApplication"] = drv_3rd_party["WORK_STATION_UID"].ToString();

                        if (!Convert.ToBoolean(drv_3rd_party["SEND_ORU"])
                            || (temp_sender == work_station_id)
                            || (log.RECEIVER_ID > -1 && log.RECEIVER_ID != work_station_id)
                            || (Convert.ToBoolean(drv_3rd_party["SEND_ORU_WHEN_OWNER"]) && Utilities.ToInt(ds_oru.Tables[0].Rows[0]["WORK_STATION_ID"].ToString()) != work_station_id)
                            || (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'H' && 
                                ds_oru.Tables[0].Rows[0]["DEFER_HIS_RECONCILE"].ToString() == "Y" && 
                                Utilities.ToInt(ds_oru.Tables[0].Rows[0]["SERVICE_TYPE"].ToString()) != ConfigService.InvestigationServiceTypeId)
                            || (!Convert.ToBoolean(drv_3rd_party["SEND_PRELIM"]) && Convert.ToChar(ds_oru.Tables[0].Rows[0]["RESULT_STATUS"]) == 'P')) continue;

                        //if (Convert.ToBoolean(drv_3rd_party["SEND_ORU_WHEN_OWNER"]))
                        //{
                        //    RIS_HL7IELOG log_sender = new RIS_HL7IELOG();
                        //    log_sender.MESSAGE_TYPE = "ORM";
                        //    log_sender.EVENT_TYPE = "O01";
                        //    log_sender.ACCESSION_NO = ds.Tables[0].Rows[0]["ACCESSION_NO"].ToString();
                        //    log_sender.ORG_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ORG_ID"]);

                        //    DataTable dtt_sender = ris.selectRisHL7IELogSender(log_sender);

                        //    if (!Utilities.HasData(dtt_sender) || work_station_id != Convert.ToInt32(dtt_sender.Rows[0]["SENDER_ID"])) continue;
                        //}

                        int temp_id = log.LOG_ID;
                        int temp_receiver = log.RECEIVER_ID;

                        log.RECEIVER_ID = work_station_id;

                        HL7ACK hl7_ack = new HL7ACK();
                        try
                        {
                            if (Convert.ToBoolean(drv_3rd_party["USE_SOCKET"]))
                            {
                                DataTable dtResultStat = ris.selectDataResultStat(accessionNo);
                                DataTable dtResultDatetime = ris.selectDataResultDatetime(accessionNo);
                                DataTable dtRadiologistGroup = ris.selectDataRadiologistGroup(accessionNo);
                                DataTable dtSeverityLog = ris.selectDataSeverityLog(accessionNo);
                                DataTable dtSeverity = ris.selectDataSeverity(accessionNo);

                                GenerateORU.ConvertToHL7(ds_oru, drv_3rd_party["RESULT_TYPE"].ToString(),dtResultStat,dtResultDatetime,dtRadiologistGroup,dtSeverityLog,dtSeverity);
                               
                                log.HL7_TEXT = ds_oru.Tables[0].Rows[0]["HL7_TEXT"].ToString();

                                hl7_ack = HL7SocketEngine.Send(drv_3rd_party["RECEIVER_IP"].ToString(), Convert.ToInt32(drv_3rd_party["RECEIVER_PORT"]), ds_oru.Tables[0].Rows[0]["HL7_TEXT"].ToString());

                                if (Convert.ToChar(drv_3rd_party["SERVER_TYPE"]) == 'P')
                                    ris.updateDataSentHL7ORU(log.ACCESSION_NO, log.ORG_ID, ds_oru.Tables[0].Rows[0]["HL7_TEXT"].ToString(), hl7_ack.MSA.ACKNOWLEDGMENT_CODE == "AA" ? "Y" : "N");
                                if (isStatReport)
                                    ris.updateHTMLExamresultstat(Convert.ToInt32(ds_oru.Tables[0].Rows[0]["NOTE_NO"]), log.ORG_ID, ds_oru.Tables[0].Rows[0]["RESULT_TEXT_HTML"].ToString());
                                else
                                    ris.updateHTMLExamresult(ds_oru.Tables[0].Rows[0]["ACCESSION_NO"].ToString(), log.ORG_ID, ds_oru.Tables[0].Rows[0]["RESULT_TEXT_HTML"].ToString());
                            }
                            else if (drv_3rd_party["WEB_SERVICE_URL"].ToString() != string.Empty)
                            {
                                ds_oru.DataSetName = "EnvisionIE";
                                ds_oru.Tables[0].TableName = "HL7";
                                ds_oru.AcceptChanges();

                                using (DataSet ds_ack = new EnvisionIEGet3rdPartyData(drv_3rd_party["WEB_SERVICE_URL"].ToString()).Set_Result(ds_oru.Copy()))
                                {
                                    DataRow dr_ack = ds_ack.Tables["ACK"].Rows[0];

                                    hl7_ack.MSA.ACKNOWLEDGMENT_CODE = dr_ack["ACKNOWLEDGMENT_CODE"].ToString();
                                    hl7_ack.MSA.TEXT_MESSAGE = dr_ack["TEXT_MESSAGE"].ToString();

                                    log.HL7_TEXT = (dr_ack.Table.Columns.IndexOf("HL7_TEXT") == -1) ? string.Empty : dr_ack["HL7_TEXT"].ToString();
                                }
                            }
                            else
                            {
                                log.HL7_TEXT = string.Empty;

                                hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AR";
                                hl7_ack.MSA.TEXT_MESSAGE = string.Format("{0} config invalid", drv_3rd_party["WORK_STATION_UID"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            hl7_ack.MSA.ACKNOWLEDGMENT_CODE = "AE";
                            hl7_ack.MSA.TEXT_MESSAGE = ex.Message;
                        }

                        log.ACKNOWLEDGMENT_CODE = hl7_ack.MSA.ACKNOWLEDGMENT_CODE;
                        log.TEXT_MESSAGE = hl7_ack.MSA.TEXT_MESSAGE;

                        editLog(log);

                        if (temp_receiver > -1) break;

                        log.LOG_ID = temp_id;
                        log.RECEIVER_ID = temp_receiver;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "sendORUByAccessionNo(int logId, string accessionNo, int orgId)", ex.Message, true);
            }
        }

        private void selectRisHL7IELog(RIS_HL7IELOG log)
        {
            log.SENDER_ID = 0;
            log.RECEIVER_ID = -1;

            //If log id value is 0 then RIS sent all.
            if (log.LOG_ID > 0)
            {
                RISConnection ris = new RISConnection();
                DataView dv_log = ris.selectRisHL7IELogByLogId(log.LOG_ID).DefaultView;

                if (Utilities.HasData(dv_log))
                {
                    log.HN = dv_log[0]["HN"].ToString();
                    log.ACCESSION_NO = dv_log[0]["ACCESSION_NO"].ToString();
                    log.COMPARE_VALUE = dv_log[0]["COMPARE_VALUE"].ToString();
                    log.STATUS = Utilities.ToChar(dv_log[0]["STATUS"].ToString(), 'A');
                    log.ORG_ID = Utilities.ToInt(dv_log[0]["ORG_ID"].ToString());

                    if (Convert.ToInt32(dv_log[0]["RECEIVER_ID"]) == 0)
                    {
                        log.LOG_ID = 0;
                        log.SENDER_ID = Convert.ToInt32(dv_log[0]["SENDER_ID"].ToString());
                    }
                    else
                        log.RECEIVER_ID = Convert.ToInt32(dv_log[0]["RECEIVER_ID"].ToString());
                }
                else
                    log.LOG_ID = 0;
            }
        }
        private bool editLog(RIS_HL7IELOG log)
        {
            RISConnection ris = new RISConnection();

            return (log.LOG_ID > 0) ? ris.updateRisHL7IELog(log) : (ris.addRisHL7IELog(log) > 0);
        }

    }
}