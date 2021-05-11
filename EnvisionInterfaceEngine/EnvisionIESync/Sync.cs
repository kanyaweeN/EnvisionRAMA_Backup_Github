using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Messaging;
using System.Threading;
using EnvisionInterfaceEngine.Common;
using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.Common.HL7;
using EnvisionInterfaceEngine.Connection;
using EnvisionInterfaceEngine.Operational;
using EnvisionInterfaceEngine.Operational.HL7;
using EnvisionInterfaceEngine.Operational.MSMQ;
using EnvisionInterfaceEngine.Operational.Translator;
using EnvisionInterfaceEngine.WebService;

namespace EnvisionIESync
{
    public class Sync : IDisposable
    {
        private readonly string title_log;
        private bool disposed = false;

        private ManualResetEvent manual_event;

        private MessageQueue HL7ADTQueue;
        private MessageQueue HL7ORMQueue;
        private MessageQueue HL7ORMBidirectionalQueue;

        public Sync() { title_log = ToString(); }
        ~Sync()
        {
            if (!disposed)
                Dispose();
        }

        public void Invoke()
        {
            Utilities.SaveLog(title_log, "Invoke()", "Begin", false);

            manual_event = new ManualResetEvent(false);

            try
            {
                manual_event.Reset();
                initializeHL7ADTQueue();
                initializeHL7ORMQueue();
                initializeHL7ORMBidirectionalQueue();
                manual_event.WaitOne();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "Invoke()", ex.Message, true); }
        }
        public void Dispose()
        {
            Utilities.SaveLog(title_log, "Invoke()", "End", false);

            if (HL7ADTQueue != null)
            {
                HL7ADTQueue.Close();
                HL7ADTQueue.Dispose();
                HL7ADTQueue = null;
            }
            if (HL7ORMQueue != null)
            {
                HL7ORMQueue.Close();
                HL7ORMQueue.Dispose();
                HL7ORMQueue = null;
            }
            if (HL7ORMBidirectionalQueue != null)
            {
                HL7ORMBidirectionalQueue.Close();
                HL7ORMBidirectionalQueue.Dispose();
                HL7ORMBidirectionalQueue = null;
            }

            disposed = true;
        }

        private void initializeHL7ADTQueue()
        {
            try
            {
                HL7ADTQueue = MSMQManager.Initialize(Config.HL7ADTQueuePath);
                HL7ADTQueue.Formatter = new BinaryMessageFormatter();
                HL7ADTQueue.ReceiveCompleted += onHL7ADTReceiveCompleted;
                HL7ADTQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeHL7ADTQueue()", ex.Message, true); }
        }
        private void onHL7ADTReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string hl7_text = string.Empty;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                log_id = Convert.ToInt32(message.Label);
                hl7_text = HL7Manager.cleanHL7Text(message.Body.ToString());
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onHL7ADTReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.ToString(), true); }
            finally { mq.BeginReceive(); }

            if (!string.IsNullOrEmpty(hl7_text))
                processHL7ADTMessage(log_id, hl7_text);
        }
        private void processHL7ADTMessage(int logId, string hl7Text)
        {
            try
            {
                object[] result = HL7Manager.ConvertHL7ToObject(hl7Text);

                if (result[0].ToString() != "AA")
                {
                    Utilities.SaveLog(title_log, "processHL7ADTMessage(int logId, string hl7Text)", string.Format("{0} {1} {2}", result[0], result[2], hl7Text), true);

                    return;
                }

                HL7ADT adt = (HL7ADT)result[2];
                RISConnection ris = new RISConnection();

                //select org
                adt.ORG.ORG_ID = ConfigService.DefaultOrgId;

                selectOrg(adt.ORG);

                RIS_HL7IELOG log = new RIS_HL7IELOG();
                log.LOG_ID = logId;

                selectHl7IELog(log);

                log.HL7_TEXT = hl7Text;

                bool is_reconcile = false;

                if (ConfigService.BypassProcessHL7ADT)
                    log.TEXT_MESSAGE = "Bypass process";
                else
                {
                    string flag = string.Empty;

                    //insert or update patient
                    adt.PATIENT.ORG_ID = adt.ORG.ORG_ID;
                    adt.PATIENT.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                    if ((flag = editPatient(adt.PATIENT)) != string.Empty)
                    {
                        log.ACKNOWLEDGMENT_CODE = "AE";
                        log.TEXT_MESSAGE = flag;
                    }
                    else if (string.IsNullOrEmpty(adt.OLD_PATIENT.HN) && adt.PATIENT.HN != adt.OLD_PATIENT.HN)
                    {
                        log.ACKNOWLEDGMENT_CODE = "AA";
                        log.TEXT_MESSAGE = "Edited data patient";
                    }
                    else if (ris.reconcilePatient(adt.OLD_PATIENT.HN, adt.PATIENT.REG_ID, adt.PATIENT.HN, adt.PATIENT.ORG_ID, adt.PATIENT.LAST_MODIFIED_BY))
                    {
                        is_reconcile = true;

                        log.ACKNOWLEDGMENT_CODE = "AA";
                        log.TEXT_MESSAGE = "Reconciled data patient";
                    }
                    else
                    {
                        log.ACKNOWLEDGMENT_CODE = "AE";
                        log.TEXT_MESSAGE = "Reconciled data patient fail";
                    }
                }

                log.HN = adt.PATIENT.HN;
                log.COMPARE_VALUE = adt.OLD_PATIENT.HN;
                log.LAST_MODIFIED_BY = adt.PATIENT.LAST_MODIFIED_BY;

                editLog(log);

                if (log.ACKNOWLEDGMENT_CODE == "AA")
                {
                    EnvisionIEPreSyncParams ws = new EnvisionIEPreSyncParams(Config.DomainWebService);

                    if (is_reconcile)
                        ws.Set_ADTReconcileQueue(log.LOG_ID, adt.OLD_PATIENT.HN, adt.PATIENT.HN, adt.PATIENT.ORG_ID);
                    else
                        ws.Set_ADTByHNQueue(log.LOG_ID, adt.PATIENT.HN, adt.PATIENT.ORG_ID);
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "processHL7ADTMessage(int logId, string hl7Text)", ex.Message, true);
            }
        }

        private void initializeHL7ORMQueue()
        {
            try
            {
                HL7ORMQueue = MSMQManager.Initialize(Config.HL7ORMQueuePath);
                HL7ORMQueue.Formatter = new BinaryMessageFormatter();
                HL7ORMQueue.ReceiveCompleted += onHL7ORMReceiveCompleted;
                HL7ORMQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeHL7ORMQueue()", ex.ToString(), true); }
        }
        private void onHL7ORMReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string hl7_text = string.Empty;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                log_id = Convert.ToInt32(message.Label);
                hl7_text = HL7Manager.cleanHL7Text(message.Body.ToString());

            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onHL7ORMReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }

            if (!string.IsNullOrEmpty(hl7_text))
                processHL7ORMMessage(log_id, hl7_text);
        }
        private void processHL7ORMMessage(int logId, string hl7Text)
        {
            try
            {
                object[] result = HL7Manager.ConvertHL7ToObject(hl7Text);

                if (result[0].ToString() != "AA")
                {
                    Utilities.SaveLog(title_log, "processHL7ORMMessage(int logId, string hl7Text)", string.Format("{0} {1} {2}", result[0], result[2], hl7Text), true);

                    return;
                }

                HL7ORM orm = (HL7ORM)result[2];
                RISConnection ris = new RISConnection();

                //select org
                orm.ORG.ORG_ID = ConfigService.DefaultOrgId;

                selectOrg(orm.ORG);

                RIS_HL7IELOG log = new RIS_HL7IELOG();
                log.LOG_ID = logId;

                selectHl7IELog(log);

                log.HL7_TEXT = hl7Text;

                List<string> list_accession_no = new List<string>();

                if (ConfigService.BypassProcessHL7ORM)
                {
                    list_accession_no.Add(orm.ORDER_DETAIL.ACCESSION_NO);

                    log.TEXT_MESSAGE = "Bypass process";
                }
                else if (orm.ORDER_DETAIL.IS_DELETED == 'Y')
                {
                    orm.ORDER_DETAIL.ORG_ID = orm.ORG.ORG_ID;
                    orm.ORDER_DETAIL.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                    if (ris.updateRisOrderDtl_IsDelete(orm.ORDER_DETAIL))
                    {
                        list_accession_no.Add(orm.ORDER_DETAIL.ACCESSION_NO);

                        log.IS_DELETED = 'Y';
                        log.ACKNOWLEDGMENT_CODE = "AA";
                        log.TEXT_MESSAGE = "Cancel order";
                    }
                    else
                    {
                        log.IS_DELETED = 'Y';
                        log.ACKNOWLEDGMENT_CODE = "AE";
                        log.TEXT_MESSAGE = "Cancel order fail";
                    }
                }
                else
                {
                    orm.PATIENT_STATUS.ORG_ID = orm.ORG.ORG_ID;

                    selectPatientStatus(orm.PATIENT_STATUS);

                    string flag = string.Empty;

                    //insert or update patient
                    orm.PATIENT.ORG_ID = orm.ORG.ORG_ID;
                    orm.PATIENT.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                    if ((flag = editPatient(orm.PATIENT)) != string.Empty)
                    {
                        log.ACKNOWLEDGMENT_CODE = "AE";
                        log.TEXT_MESSAGE = flag;
                    }
                    else
                    {
                        //insert or update Reference unit
                        orm.REFERENCE_UNIT.ORG_ID = orm.ORG.ORG_ID;
                        orm.REFERENCE_UNIT.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                        editUnit(orm.REFERENCE_UNIT);

                        //insert or update Referring doctor
                        orm.REFERRING_DOCTOR.JOB_TYPE = 'D';
                        orm.REFERRING_DOCTOR.ORG_ID = orm.ORG.ORG_ID;
                        orm.REFERRING_DOCTOR.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                        editEmp(orm.REFERRING_DOCTOR);

                        //insert or update exam
                        orm.EXAM.EXAM_TYPE = ConfigService.DefaultExamTypeId;
                        orm.EXAM.BP_ID = ConfigService.DefaultBPId;
                        orm.EXAM.BPVIEW_ID = ConfigService.DefaultBPViewId;
                        orm.EXAM.SERVICE_TYPE = ConfigService.DefaultServiceTypeId;
                        orm.EXAM.UNIT_ID = ConfigService.DefaultUnitId;
                        orm.EXAM.ORG_ID = orm.ORG.ORG_ID;
                        orm.EXAM.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                        if ((flag = editExam(orm)) != string.Empty)
                        {
                            log.ACKNOWLEDGMENT_CODE = "AE";
                            log.TEXT_MESSAGE = flag;
                        }
                        else
                        {
                            //select assigned to radiologist
                            orm.ASSIGNED_TO.ORG_ID = orm.ORG.ORG_ID;

                            using (DataTable dtt = ris.selectDataRadiologistByEmpUId(orm.ASSIGNED_TO.EMP_UID, orm.ASSIGNED_TO.ORG_ID))
                            {
                                if (Utilities.HasData(dtt))
                                    orm.ASSIGNED_TO.EMP_ID = Convert.ToInt32(dtt.Rows[0]["EMP_ID"].ToString());
                            }

                            DataTable dtt_exam_panel = ris.selectRisExamPanel(orm.EXAM.EXAM_ID);
                            int exam_panel_count = dtt_exam_panel.Rows.Count;
                            int loop = -1;

                            orm.ORDER_DETAIL.WORK_STATION_ID = log.SENDER_ID;
                            orm.ORDER_DETAIL.HIS_SYNC = selectServerTypeFromHIS(log.SENDER_ID) ? 'Y' : 'N';

                            do
                            {
                                if (loop > -1)
                                {
                                    DataRow dr_exam_panel = dtt_exam_panel.Rows[loop];

                                    orm.EXAM.EXAM_ID = Convert.ToInt32(dr_exam_panel["AUTO_EXAM_ID"]);
                                    orm.EXAM.SERVICE_TYPE = Convert.ToInt32(dr_exam_panel["SERVICE_TYPE"]);

                                    orm.ORDER_DETAIL.ACCESSION_NO = string.Empty;
                                    orm.ORDER_DETAIL.QTY = Convert.ToInt32(dr_exam_panel["NO_OF_EXAM"]);
                                    orm.ORDER_DETAIL.RATE = decimal.Zero;
                                    orm.ORDER_DETAIL.WORK_STATION_ID = 0;

                                    //select mapping between modality and exam
                                    using (DataTable dtt = ris.selectRisModalityExamByExamId(orm.EXAM.EXAM_ID))
                                        orm.MODALITY.MODALITY_ID = Utilities.HasData(dtt) ? Convert.ToInt32(dtt.Rows[0]["MODALITY_ID"]) : ConfigService.UnknownModalityId;
                                }

                                if (string.IsNullOrEmpty(orm.ORDER_DETAIL.ACCESSION_NO))
                                {
                                    using (DataTable dtt = ris.selectDataExistsBillingByRequestNoAndExamId(orm.ORDER.REQUESTNO, orm.EXAM.EXAM_ID, orm.ORG.ORG_ID))
                                    {
                                        if (Utilities.HasData(dtt))
                                        {
                                            orm.ORDER_DETAIL.ACCESSION_NO = dtt.Rows[0]["ACCESSION_NO"].ToString();

                                            orm.MODALITY.MODALITY_ID = 0;
                                        }
                                    }
                                }
                                //insert or update order and order detail with transaction
                                orm.ORDER.REG_ID = orm.PATIENT.REG_ID;
                                orm.ORDER.HN = orm.PATIENT.HN;
                                orm.ORDER.PAT_STATUS = orm.PATIENT_STATUS.STATUS_ID;
                                orm.ORDER.REF_UNIT = orm.REFERENCE_UNIT.UNIT_ID;
                                orm.ORDER.REF_DOC = orm.REFERRING_DOCTOR.EMP_ID;
                                orm.ORDER.ORG_ID = orm.ORG.ORG_ID;
                                orm.ORDER.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                                orm.ORDER_DETAIL.EXAM_ID = orm.EXAM.EXAM_ID;
                                orm.ORDER_DETAIL.SERVICE_TYPE = orm.EXAM.SERVICE_TYPE;
                                orm.ORDER_DETAIL.MODALITY_ID = orm.MODALITY.MODALITY_ID;
                                orm.ORDER_DETAIL.ASSIGNED_TO = orm.ASSIGNED_TO.EMP_ID;
                                orm.ORDER_DETAIL.STATUS = 'A';
                                orm.ORDER_DETAIL.ORG_ID = orm.ORG.ORG_ID;
                                orm.ORDER_DETAIL.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                                if (string.IsNullOrEmpty(orm.ORDER_DETAIL.ACCESSION_NO))
                                    orm.ORDER_DETAIL.ACCESSION_NO = ris.generateAccessionNo(orm.ORDER_DETAIL.MODALITY_ID, orm.ORG.ORG_UID);

                                if (string.IsNullOrEmpty(orm.ORDER.REQUESTNO))
                                    orm.ORDER.REQUESTNO = orm.ORDER_DETAIL.ACCESSION_NO;
                                if (string.IsNullOrEmpty(orm.ORDER_DETAIL.Q_NO))
                                    orm.ORDER_DETAIL.Q_NO = orm.ORDER_DETAIL.ACCESSION_NO;

                                if ((flag = editOrder(orm.ORDER, orm.ORDER_DETAIL)) != string.Empty)
                                {
                                    log.ACKNOWLEDGMENT_CODE = "AE";
                                    log.TEXT_MESSAGE = flag;

                                    break;
                                }
                                else
                                {
                                    list_accession_no.Add(orm.ORDER_DETAIL.ACCESSION_NO);

                                    log.ACKNOWLEDGMENT_CODE = "AA";
                                    log.TEXT_MESSAGE = "Edited data order";
                                }

                                loop++;
                            }
                            while (exam_panel_count > loop && log.ACKNOWLEDGMENT_CODE == "AA");

                            if (log.ACKNOWLEDGMENT_CODE == "AA")
                            {
                                if (!ris.updateRisOrderDtlMerge(orm.PATIENT.REG_ID))
                                    log.TEXT_MESSAGE = "Merge order fail";
                            }
                        }
                    }
                }

                log.HN = orm.PATIENT.HN;
                log.ACCESSION_NO = orm.ORDER_DETAIL.ACCESSION_NO;
                log.STATUS = orm.ORDER_DETAIL.STATUS;
                log.LAST_MODIFIED_BY = orm.ORDER_DETAIL.LAST_MODIFIED_BY;

                editLog(log);

                if (log.ACKNOWLEDGMENT_CODE == "AA")
                {
                    foreach (string accession_no in list_accession_no)
                        new EnvisionIEPreSyncParams(Config.DomainWebService).Set_ORMByAccessionNoQueue((log.ACCESSION_NO == accession_no) ? log.LOG_ID : 0, accession_no, orm.ORG.ORG_ID);
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "processHL7ORMMessage(int logId, string hl7Text)", ex.Message, true);
            }
        }

        private void initializeHL7ORMBidirectionalQueue()
        {
            try
            {
                HL7ORMQueue = MSMQManager.Initialize(Config.HL7ORMBidirectionalQueuePath);
                HL7ORMQueue.Formatter = new BinaryMessageFormatter();
                HL7ORMQueue.ReceiveCompleted += onHL7ORMBidirectionalReceiveCompleted;
                HL7ORMQueue.BeginReceive();
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "initializeHL7ORMBidirectionalQueue()", ex.ToString(), true); }
        }
        private void onHL7ORMBidirectionalReceiveCompleted(object source, ReceiveCompletedEventArgs e)
        {
            MessageQueue mq = (MessageQueue)source;

            int log_id = 0;
            string hl7_text = string.Empty;

            try
            {
                Message message = mq.EndReceive(e.AsyncResult);
                message.Formatter = new XmlMessageFormatter(new string[] { "System.String, mscorlib" });

                log_id = Convert.ToInt32(message.Label);
                hl7_text = HL7Manager.cleanHL7Text(message.Body.ToString());
            }
            catch (Exception ex) { Utilities.SaveLog(title_log, "onHL7ORMBidirectionalReceiveCompleted(object source, ReceiveCompletedEventArgs e)", ex.Message, true); }
            finally { mq.BeginReceive(); }

            if (!string.IsNullOrEmpty(hl7_text))
                processHL7ORMBidirectionalMessage(log_id, hl7_text);
        }
        private void processHL7ORMBidirectionalMessage(int logId, string hl7Text)
        {
            try
            {
                HL7ORM orm = GenerateORM.ConvertToObjectFromBidirectional(hl7Text);
                RISConnection ris = new RISConnection();

                //select org
                orm.ORG.ORG_ID = ConfigService.DefaultOrgId;

                selectOrg(orm.ORG);

                orm.MODALITY.MODALITY_ID = ConfigService.UnknownModalityId;

                if (!string.IsNullOrEmpty(orm.MODALITYAETITLE.AE_TITLE_NAME))
                {
                    using (DataTable dtt = ris.selectDataExistsModalityAETitleByAETitle(orm.MODALITYAETITLE.AE_TITLE_NAME, orm.ORG.ORG_ID))
                    {
                        if (Utilities.HasData(dtt))
                        {
                            orm.MODALITYAETITLE.AE_TITLE_ID = Utilities.ToInt(dtt.Rows[0]["AE_TITLE_ID"].ToString());
                            orm.MODALITYAETITLE.MODALITY_ID = Utilities.ToInt(dtt.Rows[0]["MODALITY_ID"].ToString());
                        }
                        else
                        {
                            orm.MODALITYAETITLE.MODALITY_ID = ConfigService.UnknownModalityId;
                            orm.MODALITYAETITLE.ORG_ID = ConfigService.DefaultOrgId;
                            orm.MODALITYAETITLE.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                            orm.MODALITYAETITLE.AE_TITLE_ID = ris.addRisModalityAETitle(orm.MODALITYAETITLE);

                            if (orm.MODALITYAETITLE.AE_TITLE_ID == 0)
                                Utilities.SaveLog(title_log, "processHL7ORMBidirectionalMessage(int logId, string hl7Text) : Add AE Title", string.Format("AccNo {0} add new AE Title {1} fail", orm.ORDER_DETAIL.ACCESSION_NO, orm.MODALITYAETITLE.AE_TITLE_NAME), true);
                            else
                                Utilities.SaveLog(title_log, "processHL7ORMBidirectionalMessage(int logId, string hl7Text) : Add AE Title", string.Format("AccNo {0} add new AE Title {1}", orm.ORDER_DETAIL.ACCESSION_NO, orm.MODALITYAETITLE.AE_TITLE_NAME), false);
                        }
                    }

                    orm.MODALITY.MODALITY_ID = orm.MODALITYAETITLE.MODALITY_ID;
                }

                if (!string.IsNullOrEmpty(orm.IMAGE_CAPTURED_BY.ALIAS_NAME))
                {
                    using (DataTable dtt = ris.selectDataExistsEmpByAliasName(orm.IMAGE_CAPTURED_BY.ALIAS_NAME, orm.ORG.ORG_ID))
                    {
                        if (Utilities.HasData(dtt))
                            orm.IMAGE_CAPTURED_BY.EMP_ID = Utilities.ToInt(dtt.Rows[0]["EMP_ID"].ToString());
                    }
                }

                RIS_HL7IELOG log = new RIS_HL7IELOG();
                log.LOG_ID = logId;

                selectHl7IELog(log);

                log.HL7_TEXT = hl7Text;

                bool is_reconcile = false;
                bool qa_bypass = false;

                DataTable dtt_exists_billing = ris.selectDataExistsBillingByAccessionNo(orm.ORDER_DETAIL.ACCESSION_NO, orm.ORG.ORG_ID);

                if (!Utilities.HasData(dtt_exists_billing))
                {
                    dtt_exists_billing = ris.selectDataExistsBillingByInstanceUid(orm.ORDER_DETAIL.INSTANCE_UID, orm.ORG.ORG_ID);

                    if (Utilities.HasData(dtt_exists_billing))
                    {
                        DataRow dr_exists_billing = dtt_exists_billing.Rows[0];

                        if ((!string.IsNullOrEmpty(orm.ORDER_DETAIL.ACCESSION_NO)
                                && orm.ORDER_DETAIL.ACCESSION_NO != dr_exists_billing["ACCESSION_NO"].ToString())
                            || orm.PATIENT.HN != dr_exists_billing["HN"].ToString())
                        {
                            if (dr_exists_billing["IS_CANCELED"].ToString() == "N"
                                && dr_exists_billing["IS_DELETED"].ToString() == "N")
                            {
                                RIS_ORDERDTL ords = new RIS_ORDERDTL();
                                ords.ACCESSION_NO = dr_exists_billing["ACCESSION_NO"].ToString();
                                ords.IS_DELETED = 'Y';
                                ords.ORG_ID = Utilities.ToInt(dr_exists_billing["ORG_ID"].ToString());
                                ords.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                                if (ris.updateRisOrderDtl_IsDelete(ords))
                                    new EnvisionIEPreSyncParams(Config.DomainWebService).Set_ORMByAccessionNoQueue(0, ords.ACCESSION_NO, orm.ORG.ORG_ID);
                            }

                            dtt_exists_billing = null;
                        }
                        else
                        {
                            is_reconcile = true;

                            orm.ORDER_DETAIL.ACCESSION_NO = dr_exists_billing["ACCESSION_NO"].ToString();
                        }
                    }
                }

                if (Utilities.HasData(dtt_exists_billing))
                {
                    if (dtt_exists_billing.Rows[0]["QA_REQUIRED"].ToString() == "N" && orm.ORDER_DETAIL.STATUS == 'S')
                    {
                        orm.ORDER_DETAIL.STATUS = 'C';

                        qa_bypass = true;
                    }

                    if (!ConfigService.AutoModifyModalityId
                        || orm.MODALITY.MODALITY_ID == ConfigService.UnknownModalityId)
                        orm.MODALITY.MODALITY_ID = 0;

                    orm.ORDER_DETAIL.MODALITY_ID = orm.MODALITY.MODALITY_ID;
                    orm.ORDER_DETAIL.AE_TITLE_ID = orm.MODALITYAETITLE.AE_TITLE_ID;
                    orm.ORDER_DETAIL.IMAGE_CAPTURED_BY = orm.IMAGE_CAPTURED_BY.EMP_ID;
                    orm.ORDER_DETAIL.ORG_ID = orm.ORG.ORG_ID;
                    orm.ORDER_DETAIL.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                    if (ris.updateRisOrderDtlStatusHasImage(orm.ORDER_DETAIL))
                    {
                        log.ACKNOWLEDGMENT_CODE = "AA";
                        log.TEXT_MESSAGE = "Updated data status order";
                    }
                    else
                    {
                        log.ACKNOWLEDGMENT_CODE = "AE";
                        log.TEXT_MESSAGE = "Update data status order fail";
                    }
                }
                else if (ConfigService.AllowHL7ORMBidirectionalNewOrder)
                {
                    string flag = string.Empty;
                    bool is_allowed = true;

                    BidirectionalNewOrderElement element = ConfigManager.GetBidirectionalNewOrderElement(orm.MODALITYAETITLE.AE_TITLE_ID);

                    if (element != null)
                    {
                        if (is_allowed = element.IsAllowed)
                            orm.REFERENCE_UNIT.UNIT_ID = element.ReferenceUnitId;
                        else
                        {
                            log.ACKNOWLEDGMENT_CODE = "AR";
                            log.TEXT_MESSAGE = string.Format("AE Title {0} not allowed to new order", orm.MODALITYAETITLE.AE_TITLE_NAME);
                        }
                    }

                    if (is_allowed)
                    {
                        if (orm.REFERENCE_UNIT.UNIT_ID < 1)
                            orm.REFERENCE_UNIT.UNIT_ID = ConfigService.DefaultUnitId;

                        //insert or update patient
                        orm.PATIENT.ORG_ID = orm.ORG.ORG_ID;
                        orm.PATIENT.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                        if ((flag = editPatient(orm.PATIENT)) != string.Empty)
                        {
                            log.ACKNOWLEDGMENT_CODE = "AE";
                            log.TEXT_MESSAGE = flag;
                        }
                        else
                        {
                            //insert or update exam
                            orm.EXAM.EXAM_TYPE = ConfigService.DefaultExamTypeId;
                            orm.EXAM.BP_ID = ConfigService.DefaultBPId;
                            orm.EXAM.BPVIEW_ID = ConfigService.DefaultBPViewId;
                            orm.EXAM.SERVICE_TYPE = ConfigService.DefaultServiceTypeId;
                            orm.EXAM.QA_REQUIRED = 'Y';
                            orm.EXAM.UNIT_ID = orm.REFERENCE_UNIT.UNIT_ID;
                            orm.EXAM.ORG_ID = orm.ORG.ORG_ID;
                            orm.EXAM.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                            if ((flag = editExam(orm)) != string.Empty)
                            {
                                log.ACKNOWLEDGMENT_CODE = "AE";
                                log.TEXT_MESSAGE = flag;
                            }
                            else
                            {
                                //insert or update order and order detail with transaction
                                orm.ORDER.REG_ID = orm.PATIENT.REG_ID;
                                orm.ORDER.HN = orm.PATIENT.HN;
                                orm.ORDER.REF_UNIT = orm.REFERENCE_UNIT.UNIT_ID;
                                orm.ORDER.REF_DOC = orm.REFERRING_DOCTOR.EMP_ID;
                                orm.ORDER.ORG_ID = orm.ORG.ORG_ID;
                                orm.ORDER.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                                if (orm.EXAM.QA_REQUIRED == 'N' && orm.ORDER_DETAIL.STATUS == 'S')
                                {
                                    orm.ORDER_DETAIL.STATUS = 'C';

                                    qa_bypass = true;
                                }

                                orm.ORDER_DETAIL.EXAM_ID = orm.EXAM.EXAM_ID;
                                orm.ORDER_DETAIL.SERVICE_TYPE = orm.EXAM.SERVICE_TYPE;
                                orm.ORDER_DETAIL.MODALITY_ID = orm.MODALITY.MODALITY_ID;
                                orm.ORDER_DETAIL.AE_TITLE_ID = orm.MODALITYAETITLE.AE_TITLE_ID;
                                orm.ORDER_DETAIL.IMAGE_CAPTURED_BY = orm.IMAGE_CAPTURED_BY.EMP_ID;
                                orm.ORDER_DETAIL.WORK_STATION_ID = log.SENDER_ID;
                                orm.ORDER_DETAIL.ORG_ID = orm.ORG.ORG_ID;
                                orm.ORDER_DETAIL.LAST_MODIFIED_BY = ConfigService.DefaultLastModifiedBy;

                                if (string.IsNullOrEmpty(orm.ORDER_DETAIL.ACCESSION_NO))
                                {
                                    is_reconcile = true;

                                    orm.ORDER_DETAIL.ACCESSION_NO = ris.generateAccessionNo(orm.ORDER_DETAIL.MODALITY_ID, orm.ORG.ORG_UID);
                                }

                                if ((flag = editOrder(orm.ORDER, orm.ORDER_DETAIL)) != string.Empty)
                                {
                                    log.ACKNOWLEDGMENT_CODE = "AE";
                                    log.TEXT_MESSAGE = flag;
                                }
                                else
                                {
                                    log.ACKNOWLEDGMENT_CODE = "AA";
                                    log.TEXT_MESSAGE = "Added data order";
                                }
                            }
                        }
                    }
                }
                else
                {
                    log.ACKNOWLEDGMENT_CODE = "AR";
                    log.TEXT_MESSAGE = "Accession number not match";
                }

                log.HN = orm.PATIENT.HN;
                log.ACCESSION_NO = orm.ORDER_DETAIL.ACCESSION_NO;
                log.STATUS = orm.ORDER_DETAIL.STATUS;
                log.LAST_MODIFIED_BY = orm.ORDER_DETAIL.LAST_MODIFIED_BY;

                editLog(log);

                if (log.ACKNOWLEDGMENT_CODE == "AA")
                {
                    EnvisionIEPreSyncParams ws = new EnvisionIEPreSyncParams(Config.DomainWebService);

                    if (orm.ORDER_DETAIL.STATUS == 'C')
                        ws.Set_ORMBidirectionalByAccessionNoQueue(qa_bypass ? 0 : log.LOG_ID, orm.ORDER_DETAIL.ACCESSION_NO, orm.ORDER_DETAIL.ORG_ID);

                    if (is_reconcile)
                    {
                        if (string.IsNullOrEmpty(orm.ORDER_DETAIL.INSTANCE_UID))
                            Utilities.SaveLog(title_log, "processHL7ORMBidirectionalMessage(int logId, string hl7Text)", string.Format("{0} have not a Study Instance Uid", orm.ORDER_DETAIL.ACCESSION_NO), false);
                        else
                            ws.Set_ORMMergeByAccessionNoQueue(log.LOG_ID, orm.ORDER_DETAIL.ACCESSION_NO, orm.ORDER_DETAIL.ORG_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.SaveLog(title_log, "processHL7ORMBidirectionalMessage(int logId, string hl7Text)", ex.Message, true);
            }
        }

        private void selectOrg(GBL_ENV org)
        {
            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsOrgByOrgAlias(org.ORG_ALIAS))
            {
                if (Utilities.HasData(dtt))
                {
                    org.ORG_ID = Convert.ToInt32(dtt.Rows[0]["ORG_ID"].ToString());
                    org.ORG_UID = dtt.Rows[0]["ORG_ID"].ToString();
                }
            }
        }
        private void selectPatientStatus(RIS_PATSTATUS status)
        {
            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsPatientStatusByStatusUid(status.STATUS_UID, status.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    if (dtt.Rows[0]["IS_ACTIVE"].ToString() == "Y")
                        status.STATUS_ID = Convert.ToInt32(dtt.Rows[0]["STATUS_ID"].ToString());
                }
            }
        }
        private void selectHl7IELog(RIS_HL7IELOG log)
        {
            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectRisHL7IELogByLogId(log.LOG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    log.SENDER_ID = Utilities.ToInt(dtt.Rows[0]["SENDER_ID"].ToString());
                    log.RECEIVER_ID = Utilities.ToInt(dtt.Rows[0]["RECEIVER_ID"].ToString());
                    log.HN = dtt.Rows[0]["RECEIVER"].ToString();
                    log.ACCESSION_NO = dtt.Rows[0]["RECEIVER"].ToString();
                    log.COMPARE_VALUE = dtt.Rows[0]["RECEIVER"].ToString();
                    log.STATUS = Utilities.ToChar(dtt.Rows[0]["RECEIVER"].ToString(), 'A');
                    log.ORG_ID = Utilities.ToInt(dtt.Rows[0]["ORG_ID"].ToString());
                }
            }
        }
        private bool selectServerTypeFromHIS(int workStationId)
        {
            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataIntegrationConfigByWorkStationId(workStationId))
            {
                if (Utilities.HasData(dtt))
                    return dtt.Rows[0]["SERVER_TYPE"].ToString() == "H";
            }

            return false;
        }

        private bool editEmp(HR_EMP emp)
        {
            bool flag = false;

            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsEmpByEmpUId(emp.EMP_UID, emp.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    emp.EMP_ID = Convert.ToInt32(dtt.Rows[0]["EMP_ID"].ToString());

                    flag = true;

                    if (ConfigService.AllowUpdateReferringDoctor)
                        flag = ris.updateHrEmp(emp);
                }
                else
                    flag = (emp.EMP_ID = ris.addHrEmp(emp)) > 0;
            }

            return flag;
        }
        private string editExam(HL7ORM orm)
        {
            string flag = string.Empty;

            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsExamByExamUid(orm.EXAM.EXAM_UID, orm.EXAM.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    using (DataView dv = dtt.DefaultView)
                    {
                        dv.RowFilter = "IS_ACTIVE = 'Y'";

                        if (dv.Count == 0)
                            flag = string.Format("ExamUid {0} OrgId {1} doesn't active", orm.EXAM.EXAM_UID, orm.EXAM.ORG_ID);
                        else
                        {
                            orm.EXAM.EXAM_ID = Convert.ToInt32(dv[0]["EXAM_ID"].ToString());
                            orm.EXAM.SERVICE_TYPE = Convert.ToInt32(dv[0]["SERVICE_TYPE"].ToString());
                            orm.EXAM.QA_REQUIRED = Utilities.ToChar(dv[0]["QA_REQUIRED"].ToString(), 'Y');
                            orm.ORDER_DETAIL.QTY = Convert.ToInt32(dv[0]["NO_OF_EXAM"].ToString());

                            if (ConfigService.AllowUpdateExam)
                                flag = ris.updateRisExam(orm.EXAM) ? string.Empty : string.Format("ExamUid {0} OrgId {1} update exam fail", orm.EXAM.EXAM_UID, orm.EXAM.ORG_ID);

                            if (orm.MODALITY.MODALITY_ID > 0
                                && ConfigService.AllowAutoMappingModalityExam
                                && !Utilities.HasData(ris.selectDataExistsModalityExam(orm.MODALITY.MODALITY_ID, orm.EXAM.EXAM_ID)))
                            {
                                if (!ris.addRisModalityExam(orm.MODALITY.MODALITY_ID, orm.EXAM.EXAM_ID, orm.EXAM.ORG_ID, orm.EXAM.LAST_MODIFIED_BY))
                                    flag = string.Format("ExamUid {0} OrgId {1} mapping ModalityId {2} fail", orm.EXAM.EXAM_UID, orm.EXAM.ORG_ID, orm.MODALITY.MODALITY_ID);
                            }
                        }
                    }
                }
                else
                {
                    orm.EXAM.EXAM_ID = ris.addRisExam(orm.EXAM);

                    flag = orm.EXAM.EXAM_ID > 0 ? string.Empty : string.Format("ExamUid {0} OrgId {1} add exam fail", orm.EXAM.EXAM_UID, orm.EXAM.ORG_ID);

                    if (orm.EXAM.EXAM_ID > 0 && ConfigService.AllowAutoMappingModalityExam)
                    {
                        if (orm.MODALITY.MODALITY_ID > 0)
                        {
                            if (!ris.addRisModalityExam(orm.MODALITY.MODALITY_ID, orm.EXAM.EXAM_ID, orm.EXAM.ORG_ID, orm.EXAM.LAST_MODIFIED_BY))
                                flag = string.Format("ExamUid {0} OrgId {1} mapping ModalityId {2} fail", orm.EXAM.EXAM_UID, orm.EXAM.ORG_ID, orm.MODALITY.MODALITY_ID);
                        }
                        else
                        {
                            string type_name_alias = string.IsNullOrEmpty(orm.MODALITYTYPE.TYPE_NAME_ALIAS) ? ConfigService.DefaultModalityTypeNameAlias : orm.MODALITYTYPE.TYPE_NAME_ALIAS;

                            if (!ris.addRisModalityExamByModalityTypeAlias(type_name_alias, orm.EXAM.EXAM_ID, orm.EXAM.ORG_ID, orm.EXAM.LAST_MODIFIED_BY))
                                flag = string.Format("ExamUid {0} OrgId {1} mapping {2} fail", orm.EXAM.EXAM_UID, orm.EXAM.ORG_ID, type_name_alias);
                        }
                    }
                }
            }

            //select mapping between modality and exam
            using (DataTable dtt = ris.selectRisModalityExamByExamId(orm.EXAM.EXAM_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    DataRow[] rows = null;

                    if (!string.IsNullOrEmpty(orm.MODALITYTYPE.TYPE_NAME_ALIAS))
                        rows = dtt.Select(string.Format("TYPE_NAME_ALIAS = '{0}'", orm.MODALITYTYPE.TYPE_NAME_ALIAS));

                    DataRow row = Utilities.HasData(rows) ? rows[0] : dtt.Rows[0];

                    orm.MODALITY.MODALITY_ID = Convert.ToInt32(row["MODALITY_ID"]);
                }
            }

            if (orm.MODALITY.MODALITY_ID == 0)
                orm.MODALITY.MODALITY_ID = ConfigService.UnknownModalityId;

            return flag;
        }
        private string editOrder(RIS_ORDER ord, RIS_ORDERDTL ords)
        {
            string flag = string.Empty;

            RISConnection ris = new RISConnection();

            using (DbConnection connection = ris.DoConnect())
            {
                connection.Open();

                using (DbTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (DataTable dtt_billing = ris.selectDataExistsBillingByAccessionNo(ords.ACCESSION_NO, ords.ORG_ID))
                        {
                            if (Utilities.HasData(dtt_billing))
                            {
                                ord.ORDER_ID = Convert.ToInt32(dtt_billing.Rows[0]["ORDER_ID"].ToString());
                                ris.updateRisOrder(ord, transaction);

                                ords.ORDER_ID = ord.ORDER_ID;
                                ris.updateRisOrderDtl(ords, transaction);
                            }
                            else
                            {
                                using (DataTable dtt_ord = ris.selectRisOrderHasActived(ord.REQUESTNO, ord.ORG_ID))
                                {
                                    if (Utilities.HasData(dtt_ord))
                                    {
                                        DataView dv_ord = dtt_ord.DefaultView;
                                        dv_ord.RowFilter = string.Format("REG_ID <> {0} or EXAM_ID = {1}", ord.REG_ID, ords.EXAM_ID);

                                        if (!Utilities.HasData(dtt_ord))
                                        {
                                            dv_ord.RowFilter = string.Empty;

                                            ord.ORDER_ID = Convert.ToInt32(dv_ord[0]["ORDER_ID"]);
                                        }
                                    }
                                }

                                if (ord.ORDER_ID == 0)
                                    ord.ORDER_ID = ris.addRisOrder(ord, transaction);

                                if (ord.ORDER_ID == 0)
                                {
                                    flag = string.Format("AccNo {0} OrgId {1} add order fail", ords.ACCESSION_NO, ord.ORG_ID);

                                    transaction.Rollback();
                                }
                                else
                                {
                                    ords.ORDER_ID = ord.ORDER_ID;

                                    using (DataTable dtt_clinic = ris.selectRisClinicTypeByDateTime(DateTime.Now, ords.ORG_ID))
                                    {
                                        if (Utilities.HasData(dtt_clinic))
                                            ords.CLINIC_TYPE = Convert.ToInt32(dtt_clinic.Rows[0]["CLINIC_TYPE_ID"]);
                                    }

                                    ris.addRisOrderDtl(ords, transaction);
                                }
                            }
                        }

                        if (transaction.Connection != null)
                            transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        flag = string.Format("AccNo {0} OrgId {1} {2}", ords.ACCESSION_NO, ords.ORG_ID, Utilities.ToCleanString(ex.Message));
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }

            return flag;
        }
        private string editPatient(HIS_REGISTRATION patient)
        {
            string flag = string.Empty;

            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsPatientByHn(patient.HN, patient.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    DataRow dr = dtt.Rows[0];

                    patient.REG_ID = Convert.ToInt32(dr["REG_ID"]);

                    if (string.IsNullOrEmpty(patient.TITLE))
                        patient.TITLE = patient.TITLE_ENG;
                    else if (string.IsNullOrEmpty(patient.TITLE_ENG))
                    {
                        if (string.Equals(patient.TITLE, dr["TITLE"])
                            && !string.IsNullOrEmpty(dr["TITLE_ENG"].ToString()))
                            patient.TITLE_ENG = dr["TITLE_ENG"].ToString();
                        else
                            patient.TITLE_ENG = TransToEnglish.TransSalutation(patient.TITLE);
                    }

                    if (string.IsNullOrEmpty(patient.FNAME))
                        patient.FNAME = patient.FNAME_ENG;
                    else if (string.IsNullOrEmpty(patient.FNAME_ENG))
                    {
                        if (string.Equals(patient.FNAME, dr["FNAME"])
                            && !string.IsNullOrEmpty(dr["FNAME_ENG"].ToString()))
                            patient.FNAME_ENG = dr["FNAME_ENG"].ToString();
                        else
                            patient.FNAME_ENG = TransToEnglish.Trans(patient.FNAME);
                    }

                    if (string.IsNullOrEmpty(patient.LNAME))
                        patient.LNAME = patient.LNAME_ENG;
                    else if (string.IsNullOrEmpty(patient.LNAME_ENG))
                    {
                        if (string.Equals(patient.LNAME, dr["LNAME"])
                            && !string.IsNullOrEmpty(dr["LNAME_ENG"].ToString()))
                            patient.LNAME_ENG = dr["LNAME_ENG"].ToString();
                        else
                            patient.LNAME_ENG = TransToEnglish.Trans(patient.LNAME);
                    }

                    flag = ris.updateHisRegistration(patient) ? string.Empty : string.Format("Hn {0} OrgId {1} update patient fail", patient.HN, patient.ORG_ID);
                }
                else
                {
                    if (string.IsNullOrEmpty(patient.TITLE))
                        patient.TITLE = patient.TITLE_ENG;
                    else if (string.IsNullOrEmpty(patient.TITLE_ENG))
                        patient.TITLE_ENG = TransToEnglish.TransSalutation(patient.TITLE);

                    if (string.IsNullOrEmpty(patient.FNAME))
                        patient.FNAME = patient.FNAME_ENG;
                    else if (string.IsNullOrEmpty(patient.FNAME_ENG))
                        patient.FNAME_ENG = TransToEnglish.Trans(patient.FNAME);

                    if (string.IsNullOrEmpty(patient.LNAME))
                        patient.LNAME = patient.LNAME_ENG;
                    else if (string.IsNullOrEmpty(patient.LNAME_ENG))
                        patient.LNAME_ENG = TransToEnglish.Trans(patient.LNAME);

                    patient.REG_ID = ris.addHisRegistration(patient);

                    flag = patient.REG_ID > 0 ? string.Empty : string.Format("Hn {0} OrgId {1} add patient fail", patient.HN, patient.ORG_ID);
                }
            }

            return flag;
        }
        private bool editUnit(HR_UNIT unit)
        {
            bool flag = false;

            RISConnection ris = new RISConnection();

            using (DataTable dtt = ris.selectDataExistsUnitByUnitUid(unit.UNIT_UID, unit.ORG_ID))
            {
                if (Utilities.HasData(dtt))
                {
                    unit.UNIT_ID = Convert.ToInt32(dtt.Rows[0]["UNIT_ID"].ToString());

                    flag = true;

                    if (ConfigService.AllowUpdateReferenceUnit)
                        flag = ris.updateHrUnit(unit);
                }
                else
                    flag = (unit.UNIT_ID = ris.addHrUnit(unit)) > 0;
            }

            return flag;
        }
        private bool editLog(RIS_HL7IELOG log)
        {
            RISConnection ris = new RISConnection();

            return (log.LOG_ID > 0) ? ris.updateRisHL7IELog(log) : (log.LOG_ID = ris.addRisHL7IELog(log)) > 0;
        }
    }
}