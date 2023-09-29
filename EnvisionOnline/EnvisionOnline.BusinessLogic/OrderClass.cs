using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.BusinessLogic.ProcessDelete;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic.ProcessUpdate;
using EnvisionOnline.Common.Common;
using System.Data.Common;
using EnvisionOnline.WebService;

namespace EnvisionOnline.BusinessLogic
{
    public class OrderClass
    {
        public EnvisionOnline.Common.ONL_WORKLIST ONL_WORKLIST { get; set; }
        public EnvisionOnline.Common.XRAYREQ XRAYREQ { get; set; }
        public EnvisionOnline.Common.RIS_CONFLICTEXAMGROUP RIS_CONFLICTEXAMGROUP { get; set; }

        public OrderClass()
        {
            ONL_WORKLIST = new EnvisionOnline.Common.ONL_WORKLIST();
            XRAYREQ = new EnvisionOnline.Common.XRAYREQ();
            RIS_CONFLICTEXAMGROUP = new EnvisionOnline.Common.RIS_CONFLICTEXAMGROUP();
        }

        public DataSet get_OnlineWorklist()
        {
            DataSet ds = new DataSet();
            ProcessGetONLWorklist worklist = new ProcessGetONLWorklist();
            worklist.ONL_WORKLIST.MODE = this.ONL_WORKLIST.MODE;//ONL_WORKLIST.MODE;
            worklist.ONL_WORKLIST.HN = this.ONL_WORKLIST.HN;
            worklist.ONL_WORKLIST.FromDate = this.ONL_WORKLIST.FromDate;
            worklist.ONL_WORKLIST.ToDate = this.ONL_WORKLIST.ToDate;
            worklist.ONL_WORKLIST.UNIT_ID = this.ONL_WORKLIST.UNIT_ID;
            worklist.ONL_WORKLIST.UNIT_ALIAS = this.ONL_WORKLIST.UNIT_ALIAS;
            worklist.Invoke();
            ds = worklist.Result;
            return ds;
        }
        public DataSet get_OnlineNurseWorklist()
        {
            DataSet ds = new DataSet();
            ProcessGetONLWorklist worklist = new ProcessGetONLWorklist();
            worklist.ONL_WORKLIST.MODE = this.ONL_WORKLIST.MODE;//ONL_WORKLIST.MODE;
            worklist.ONL_WORKLIST.HN = this.ONL_WORKLIST.HN;
            worklist.ONL_WORKLIST.FromDate = this.ONL_WORKLIST.FromDate;
            worklist.ONL_WORKLIST.ToDate = this.ONL_WORKLIST.ToDate;
            worklist.ONL_WORKLIST.UNIT_ID = this.ONL_WORKLIST.UNIT_ID;
            worklist.ONL_WORKLIST.UNIT_ALIAS = this.ONL_WORKLIST.UNIT_ALIAS;
            worklist.Invoke();
            ds = worklist.Result;
            return ds;
        }
        public bool set_ONLXrayreq_Delete()
        {
            ProcessDeleteXrayreq del = new ProcessDeleteXrayreq();
            del.XRAYREQ.ORDER_ID = this.XRAYREQ.ORDER_ID;
            del.XRAYREQ.LAST_MODIFIED_BY = this.XRAYREQ.LAST_MODIFIED_BY;
            del.XRAYREQ.REASON = this.XRAYREQ.REASON;
            del.Invoke();
            return true;
        }
        public bool set_ONLXrayreqDtl_Delete()
        {
            ProcessDeleteXrayreqdtl del = new ProcessDeleteXrayreqdtl();
            del.XRAYREQ.ORDER_ID = this.XRAYREQ.ORDER_ID;
            del.XRAYREQ.EXAM_ID = this.XRAYREQ.EXAM_ID;
            del.XRAYREQ.LAST_MODIFIED_BY = this.XRAYREQ.LAST_MODIFIED_BY;
            del.Invoke();
            return true;
        }
        public bool set_ONLOrderDirectly_Delete()
        {
            ProcessDeleteRISOrder del = new ProcessDeleteRISOrder();
            del.RIS_ORDER.ORDER_ID = this.XRAYREQ.ORDER_ID;
            del.RIS_ORDER.LAST_MODIFIED_BY = this.XRAYREQ.LAST_MODIFIED_BY;
            del.Invoke();
            return true;
        }
        public int check_ONLOrder(DataTable dtOrd, DataTable dtTemp, DataTable dtDelete, GBLEnvVariable env)
        {
            ScheduleClass sch = new ScheduleClass();
            int order_id = 0;
            int schedule_id = 0;

            #region Check Delete Order
            foreach (DataRow drDel in dtDelete.Rows)
            {
                if (!string.IsNullOrEmpty(drDel["ORDER_ID"].ToString()))
                    order_id = Convert.ToInt32(drDel["ORDER_ID"]) > 0 ? Convert.ToInt32(drDel["ORDER_ID"]) : order_id; //กรณี delete case เก่า
                if (Convert.ToInt32(drDel["SCHEDULE_ID"]) == 0)
                {
                    ProcessDeleteXrayreqdtl del = new ProcessDeleteXrayreqdtl();
                    del.XRAYREQ.ORDER_ID = order_id;
                    del.XRAYREQ.EXAM_ID = Convert.ToInt32(drDel["EXAM_ID"]);
                    del.XRAYREQ.LAST_MODIFIED_BY = env.UserID;
                    del.Invoke();
                }
                else
                {
                    ProcessDeleteRISSchedule del = new ProcessDeleteRISSchedule();
                    del.RIS_SCHEDULE.SCHEDULE_ID = Convert.ToInt32(drDel["SCHEDULE_ID"]);
                    del.RIS_SCHEDULE.REASON = "Modified Data";
                    del.RIS_SCHEDULE.LAST_MODIFIED_BY = env.UserID;
                    del.Invoke();
                }
            }
            #endregion

            foreach (DataRow drChkOrderID in dtOrd.Rows)
            {
                if (!string.IsNullOrEmpty(drChkOrderID["ORDER_ID"].ToString()))
                    order_id = Convert.ToInt32(drChkOrderID["ORDER_ID"]) > 0 ? Convert.ToInt32(drChkOrderID["ORDER_ID"]) : order_id;

                schedule_id = string.IsNullOrEmpty(drChkOrderID["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(drChkOrderID["SCHEDULE_ID"]);
                if (schedule_id != 0)
                {
                    try
                    {
                        sch.set_ONLSchedule_Delete(schedule_id, "Modified Data", env.UserID, drChkOrderID["HN"].ToString());
                    }
                    catch
                    {
                        sch.set_ONLSchedule_Delete(schedule_id, "Modified Data", env.UserID, "");
                    }
                }
            }

            if (order_id == 0)
                order_id = set_ONLOrder_Insert(dtOrd, dtTemp, env);
            else
                set_ONLOrder_Update(order_id, dtOrd, dtTemp, env);

            return order_id;
        }
        public void set_ONLDirectlyOrder_Insert(DataTable dtOrd, DataTable dtTemp, GBLEnvVariable env)
        {
            int orderId = 0;
            DbConnection connection = null;
            DbTransaction transaction = null;
            try
            {
            #region Insert to RIS_ORDER

            // #### INSERT DATA TO TABLE RIS_ORDER AND RIS_ORDERDTL ####
            connection = BusinessLogic.RISBaseClass.ConnectionDataBase();
            connection.Open();
            transaction = connection.BeginTransaction();

            // Insert to RIS_ORDER
            ProcessAddRISOrderV2 processAddRISOrder = new ProcessAddRISOrderV2();
            processAddRISOrder.Transaction = transaction;
            processAddRISOrder.RIS_ORDER.REG_ID = Convert.ToInt32(dtOrd.Rows[0]["REG_ID"]);
            processAddRISOrder.RIS_ORDER.HN = dtOrd.Rows[0]["HN"].ToString();
            processAddRISOrder.RIS_ORDER.ORG_ID = env.OrgID;
            processAddRISOrder.RIS_ORDER.ARRIVAL_BY = env.UserID;
            processAddRISOrder.RIS_ORDER.ARRIVAL_ON = DateTime.Now;
            processAddRISOrder.RIS_ORDER.CREATED_BY = env.UserID;
            //processAddRISOrder.RIS_ORDER.ADMISSION_NO = aadmissionNo;
            processAddRISOrder.RIS_ORDER.IS_REQONLINE = "Y";
            processAddRISOrder.RIS_ORDER.ORDER_DT = Convert.ToDateTime(dtOrd.Rows[0]["ORDER_DT"]);
            processAddRISOrder.RIS_ORDER.ORDER_START_TIME = Convert.ToDateTime(dtOrd.Rows[0]["ORDER_DT"]);
            processAddRISOrder.RIS_ORDER.REF_DOC = Convert.ToInt32(dtTemp.Rows[0]["REF_DOC_ID"].ToString());
            processAddRISOrder.RIS_ORDER.REF_UNIT = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"].ToString());
            processAddRISOrder.RIS_ORDER.INSURANCE_TYPE_ID = Convert.ToInt32(dtTemp.Rows[0]["INSURANCE_TYPE_ID"].ToString());
            processAddRISOrder.RIS_ORDER.PAT_STATUS = dtTemp.Rows[0]["PAT_STATUS"].ToString();
            processAddRISOrder.RIS_ORDER.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
            processAddRISOrder.RIS_ORDER.REF_DOC_INSTRUCTION = dtOrd.Rows[0]["REF_DOC_INSTRUCTION"].ToString();
            processAddRISOrder.RIS_ORDER.ENC_ID = string.IsNullOrEmpty(dtTemp.Rows[0]["ENC_ID"].ToString()) ? "0" : dtTemp.Rows[0]["ENC_ID"].ToString();
            processAddRISOrder.RIS_ORDER.ENC_TYPE = dtTemp.Rows[0]["ENC_TYPE"].ToString();
            processAddRISOrder.RIS_ORDER.ENC_CLINIC = dtTemp.Rows[0]["ENC_CLINIC"].ToString();
            processAddRISOrder.RIS_ORDER.IS_TELEMED = dtTemp.Rows[0]["IS_TELEMED"].ToString();
            processAddRISOrder.RIS_ORDER.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
            processAddRISOrder.RIS_ORDER.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
            processAddRISOrder.Invoke();
            // set order id 
            orderId = processAddRISOrder.RIS_ORDER.ORDER_ID;

            // Insert to RIS_ORDERDTL
            ProcessAddRISOrderDtlV2 processAddRISOrderDtl = new ProcessAddRISOrderDtlV2();
            processAddRISOrderDtl.UseTransaction = transaction;
            ProcessGetRISOrderGenAccessionNo processGetRISOrderGenAccessionNo = new ProcessGetRISOrderGenAccessionNo();
            processGetRISOrderGenAccessionNo.Transaction = transaction;

            foreach (DataRow drDetail in dtOrd.Rows)
            {
                processAddRISOrderDtl.RIS_ORDERDTL.ORDER_ID = processAddRISOrder.RIS_ORDER.ORDER_ID;
                processAddRISOrderDtl.RIS_ORDERDTL.EXAM_DT = Convert.ToDateTime(drDetail["EXAM_DT"]);
                processAddRISOrderDtl.RIS_ORDERDTL.ORG_ID = env.OrgID;
                processAddRISOrderDtl.RIS_ORDERDTL.CREATED_BY = env.UserID;

                processAddRISOrderDtl.RIS_ORDERDTL.EST_START_TIME = Convert.ToDateTime(dtOrd.Rows[0]["ORDER_DT"]);
                processAddRISOrderDtl.RIS_ORDERDTL.QTY = string.IsNullOrEmpty(drDetail["QTY"].ToString()) ? Convert.ToByte(1) : Convert.ToByte(drDetail["QTY"]);
                processAddRISOrderDtl.RIS_ORDERDTL.ASSIGNED_TO = string.IsNullOrEmpty(drDetail["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drDetail["ASSIGNED_TO"].ToString());
                processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID = Convert.ToInt32(drDetail["MODALITY_ID"]);
                processAddRISOrderDtl.RIS_ORDERDTL.PRIORITY = Convert.ToChar(drDetail["PRIORITY"].ToString());
                processAddRISOrderDtl.RIS_ORDERDTL.EXAM_ID = Convert.ToInt32(drDetail["EXAM_ID"]);
                processAddRISOrderDtl.RIS_ORDERDTL.RATE = Convert.ToDecimal(drDetail["RATE"]);
                processAddRISOrderDtl.RIS_ORDERDTL.CLINIC_TYPE = Convert.ToInt32(drDetail["CLINIC_TYPE"]);//_xrayreq.CLINIC_TYPE;
                #region Insert to RIS_ORDERDTL

                //Get acession no
                processGetRISOrderGenAccessionNo.MODALITY_ID = processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID;
                processGetRISOrderGenAccessionNo.REF_UNIT_ID = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"].ToString());
                processGetRISOrderGenAccessionNo.Invoke();
                processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO = processGetRISOrderGenAccessionNo.ACCESSION_ON;

                int strBP_ID = string.IsNullOrEmpty(drDetail["BPVIEW_ID"].ToString()) ? 0 : Convert.ToInt32(drDetail["BPVIEW_ID"].ToString());
                processAddRISOrderDtl.RIS_ORDERDTL.BPVIEW_ID = strBP_ID;
                processAddRISOrderDtl.RIS_ORDERDTL.COMMENTS_ONLINE = drDetail["COMMENTS"].ToString();
                processAddRISOrderDtl.RIS_ORDERDTL.PAT_DEST_ID = Convert.ToInt32(drDetail["PAT_DEST_ID"]);
                processAddRISOrderDtl.Invoke();
            }
                #endregion

            transaction.Commit();
            #endregion
            }
            catch
            {
                transaction.Rollback();
                connection.Close();
            }
            finally
            {
                connection.Close();
            }

            #region Sent To PACS
            new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORMByOrderIdQueue(0, orderId);
            #endregion
        }
        public void set_ONLDirectlyOrder_Update(int order_id, DataTable dtOrd, DataTable dtTemp, GBLEnvVariable env)
        {
            DbConnection connection = null;
            DbTransaction transaction = null;

            connection = BusinessLogic.RISBaseClass.ConnectionDataBase();
            connection.Open();
            transaction = connection.BeginTransaction();

            ProcessAddRISOrderDtlV2 processAddRISOrderDtl = new ProcessAddRISOrderDtlV2();
            //processAddRISOrderDtl.UseTransaction = transaction;
            ProcessGetRISOrderGenAccessionNo processGetRISOrderGenAccessionNo = new ProcessGetRISOrderGenAccessionNo();
            //processGetRISOrderGenAccessionNo.Transaction = transaction;

            ProcessUpdateRISOrder processUpd = new ProcessUpdateRISOrder(true);
            //processUpd.Transaction = transaction;
            ProcessUpdateRISOrderdtl processUpdate = new ProcessUpdateRISOrderdtl();
            //processUpdate.Transaction = transaction;

            #region Update Master
            processUpd.RIS_ORDER.ORDER_ID = order_id;
            processUpd.RIS_ORDER.REF_UNIT = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"].ToString());
            processUpd.RIS_ORDER.REF_DOC = Convert.ToInt32(dtTemp.Rows[0]["REF_DOC_ID"].ToString());
            processUpd.RIS_ORDER.REF_DOC_INSTRUCTION = dtOrd.Rows[0]["REF_DOC_INSTRUCTION"].ToString();
            processUpd.RIS_ORDER.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
            processUpd.RIS_ORDER.LAST_MODIFIED_BY = env.UserID;
            processUpd.RIS_ORDER.INSURANCE_TYPE_ID = Convert.ToInt32(dtTemp.Rows[0]["INSURANCE_TYPE_ID"].ToString());
            processUpd.RIS_ORDER.PAT_STATUS = dtTemp.Rows[0]["PAT_STATUS"].ToString();
            processUpd.RIS_ORDER.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
            processUpd.RIS_ORDER.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
            processUpd.Invoke();
            #endregion

            #region Update Details
            foreach (DataRow drDetail in dtOrd.Rows)
            {
                if (Convert.ToInt32(drDetail["ORDER_ID"].ToString()) != 0)
                {
                    #region ปรังปรุง Record
                    processUpdate.RIS_ORDERDTL.ORDER_ID = order_id;
                    int strBP_ID = string.IsNullOrEmpty(drDetail["BPVIEW_ID"].ToString()) ? 0 : Convert.ToInt32(drDetail["BPVIEW_ID"].ToString());
                    processUpdate.RIS_ORDERDTL.BPVIEW_ID = strBP_ID;

                    if (drDetail["COMMENTS"].ToString() == string.Empty)
                        processUpdate.RIS_ORDERDTL.COMMENTS = string.Empty;
                    else
                        processUpdate.RIS_ORDERDTL.COMMENTS = drDetail["COMMENTS"].ToString();

                    processUpdate.RIS_ORDERDTL.CLINIC_TYPE = Convert.ToInt32(drDetail["CLINIC_TYPE"]);


                    processUpdate.RIS_ORDERDTL.ASSIGNED_TO = string.IsNullOrEmpty(drDetail["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drDetail["ASSIGNED_TO"].ToString());
                    processUpdate.RIS_ORDERDTL.MODALITY_ID = Convert.ToInt32(drDetail["MODALITY_ID"]);
                    processUpdate.RIS_ORDERDTL.PRIORITY = Convert.ToChar(drDetail["PRIORITY"].ToString());
                    processUpdate.RIS_ORDERDTL.RATE = Convert.ToDecimal(drDetail["RATE"]);
                    processUpdate.RIS_ORDERDTL.ORG_ID = env.OrgID;
                    processUpdate.RIS_ORDERDTL.LAST_MODIFIED_BY = env.UserID;
                    processUpdate.Invoke();
                    #endregion
                }
                else
                {
                    #region กรณีแก้ไขแล้วเพิ่ม Record
                    // Insert to RIS_ORDERDTL
                    processAddRISOrderDtl.RIS_ORDERDTL.ORDER_ID = order_id;
                    processAddRISOrderDtl.RIS_ORDERDTL.EXAM_DT = Convert.ToDateTime(drDetail["EXAM_DT"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.ORG_ID = env.OrgID;
                    processAddRISOrderDtl.RIS_ORDERDTL.CREATED_BY = env.UserID;

                    processAddRISOrderDtl.RIS_ORDERDTL.EST_START_TIME = Convert.ToDateTime(dtOrd.Rows[0]["ORDER_DT"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.QTY = string.IsNullOrEmpty(drDetail["QTY"].ToString()) ? Convert.ToByte(1) : Convert.ToByte(drDetail["QTY"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.ASSIGNED_TO = string.IsNullOrEmpty(drDetail["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drDetail["ASSIGNED_TO"].ToString());
                    processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID = Convert.ToInt32(drDetail["MODALITY_ID"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.PRIORITY = Convert.ToChar(drDetail["PRIORITY"].ToString());
                    processAddRISOrderDtl.RIS_ORDERDTL.EXAM_ID = Convert.ToInt32(drDetail["EXAM_ID"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.RATE = Convert.ToDecimal(drDetail["RATE"]);
                    processAddRISOrderDtl.RIS_ORDERDTL.CLINIC_TYPE = Convert.ToInt32(drDetail["CLINIC_TYPE"]);//_xrayreq.CLINIC_TYPE;

                    //Get acession no
                    processGetRISOrderGenAccessionNo.MODALITY_ID = processAddRISOrderDtl.RIS_ORDERDTL.MODALITY_ID;
                    processGetRISOrderGenAccessionNo.REF_UNIT_ID = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"].ToString());
                    processGetRISOrderGenAccessionNo.Invoke();
                    processAddRISOrderDtl.RIS_ORDERDTL.ACCESSION_NO = processGetRISOrderGenAccessionNo.ACCESSION_ON;

                    int strBP_ID = string.IsNullOrEmpty(drDetail["BPVIEW_ID"].ToString()) ? 0 : Convert.ToInt32(drDetail["BPVIEW_ID"].ToString());
                    processAddRISOrderDtl.RIS_ORDERDTL.BPVIEW_ID = strBP_ID;
                    processAddRISOrderDtl.RIS_ORDERDTL.COMMENTS_ONLINE = drDetail["COMMENTS"].ToString();
                    processAddRISOrderDtl.RIS_ORDERDTL.PAT_DEST_ID = Convert.ToInt32(drDetail["PAT_DEST_ID"]);
                    processAddRISOrderDtl.Invoke();
                    #endregion
                }
            }
            #endregion
            #region Sent To PACS
            new EnvisionIEPreSyncParams(env.WebServiceIP).Set_ORMByOrderIdQueue(0, order_id);
            #endregion
        }
        public int set_ONLOrder_Insert(DataTable dtOrd, DataTable dtTemp, GBLEnvVariable env)
        {
            #region Insert Order
            int order_id = 0;
            EnvisionOnline.Common.XRAYREQ _xrayreq = new EnvisionOnline.Common.XRAYREQ();
            _xrayreq.HN = dtOrd.Rows[0]["HN"].ToString();
            _xrayreq.STATUS = "R";
            _xrayreq.REG_ID = Convert.ToInt32(dtOrd.Rows[0]["REG_ID"]);
            _xrayreq.REF_DOC_INSTRUCTION = dtOrd.Rows[0]["REF_DOC_INSTRUCTION"].ToString();
            _xrayreq.COMMENTS = dtOrd.Rows[0]["COMMENTS"].ToString();
            _xrayreq.CREATED_BY = env.UserID;
            _xrayreq.LAST_MODIFIED_BY = env.UserID;
            _xrayreq.ORG_ID = env.OrgID;
            _xrayreq.ORDER_DT = Convert.ToDateTime(dtOrd.Rows[0]["ORDER_DT"]);
            _xrayreq.REQUEST_DATE = Convert.ToDateTime(dtOrd.Rows[0]["ORDER_DT"]);
            _xrayreq.ORDER_START_TIME = Convert.ToDateTime(dtOrd.Rows[0]["ORDER_DT"]);
            _xrayreq.REQUESTNO = dtOrd.Rows[0]["REQUESTNO"].ToString();

            _xrayreq.REG_ID = Convert.ToInt32(dtTemp.Rows[0]["REG_ID"]);
            _xrayreq.FULLNAME = dtTemp.Rows[0]["FULLNAME"].ToString();
            _xrayreq.REF_UNIT = dtTemp.Rows[0]["REF_UNIT_ID"].ToString();
            _xrayreq.REF_DOC_ID = dtTemp.Rows[0]["REF_DOC_ID"].ToString();
            _xrayreq.CLINIC_TYPE = Convert.ToInt32(dtTemp.Rows[0]["CLINIC_TYPE_ID"]);
            _xrayreq.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
            _xrayreq.INSURANCE_TYPE_ID = dtTemp.Rows[0]["INSURANCE_TYPE_ID"].ToString();
            _xrayreq.EMP_UID = dtTemp.Rows[0]["REF_DOC_UID"].ToString();
            _xrayreq.DOCNAME = dtTemp.Rows[0]["REF_DOCNAME"].ToString();
            _xrayreq.REF_DOC_FNAME = dtTemp.Rows[0]["REF_DOC_FNAME"].ToString();
            _xrayreq.REF_DOC_LNAME = dtTemp.Rows[0]["REF_DOC_LNAME"].ToString();
            _xrayreq.PAT_STATUS = dtTemp.Rows[0]["PAT_STATUS"].ToString();
            _xrayreq.ENC_CLINIC = dtTemp.Rows[0]["ENC_CLINIC"].ToString();
            _xrayreq.ENC_TYPE = dtTemp.Rows[0]["ENC_TYPE"].ToString();
            _xrayreq.ENC_ID = string.IsNullOrEmpty(dtTemp.Rows[0]["ENC_ID"].ToString()) ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ENC_ID"].ToString());
            _xrayreq.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
            _xrayreq.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
            _xrayreq.IS_TELEMED = dtTemp.Rows[0]["IS_TELEMED"].ToString();

            ProcessAddXrayreq addxreq = new ProcessAddXrayreq();
            addxreq.XRAYREQ = _xrayreq;
            addxreq.Invoke(); 
            #endregion
            foreach (DataRow drDetail in dtOrd.Rows)
            {
                ProcessAddXrayreqdtl addxreqdtl = new ProcessAddXrayreqdtl();
                addxreqdtl.XRAYREQ.ORDER_ID = addxreq.order_id;
                order_id = addxreq.order_id;
                addxreqdtl.XRAYREQ.STATUS = drDetail["STATUS"].ToString() == "W" ? "R" : drDetail["STATUS"].ToString();
                addxreqdtl.XRAYREQ.PRIORITY = drDetail["PRIORITY"].ToString();
                addxreqdtl.XRAYREQ.EXAM_DT = Convert.ToDateTime(drDetail["EXAM_DT"]);
                addxreqdtl.XRAYREQ.EXAM_ID = Convert.ToInt32(drDetail["EXAM_ID"]);
                addxreqdtl.XRAYREQ.EXAM_UID = drDetail["EXAM_UID"].ToString();
                string strBP_ID = string.IsNullOrEmpty(drDetail["BPVIEW_ID"].ToString()) ? "0" : drDetail["BPVIEW_ID"].ToString();
                addxreqdtl.XRAYREQ.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                addxreqdtl.XRAYREQ.BP_VIEW = drDetail["BPVIEW_NAME"].ToString();
                addxreqdtl.XRAYREQ.ASSIGN_TO = string.IsNullOrEmpty(drDetail["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drDetail["ASSIGNED_TO"].ToString());
                addxreqdtl.XRAYREQ.RATE = Convert.ToDecimal(drDetail["RATE"]);
                addxreqdtl.XRAYREQ.PAT_DEST_ID = Convert.ToInt32(drDetail["PAT_DEST_ID"]);
                addxreqdtl.XRAYREQ.MODALITY_ID = Convert.ToInt32(drDetail["MODALITY_ID"]);
                addxreqdtl.XRAYREQ.IS_PORTABLE = drDetail["IS_PORTABLE_VALUE"].ToString();
                addxreqdtl.XRAYREQ.QTY = string.IsNullOrEmpty(drDetail["QTY"].ToString()) ? 1 : Convert.ToInt32(drDetail["QTY"]);
                addxreqdtl.XRAYREQ.ORG_ID = env.OrgID;
                addxreqdtl.XRAYREQ.CREATED_BY = env.UserID;
                addxreqdtl.XRAYREQ.CLINIC_TYPE = Convert.ToInt32(drDetail["CLINIC_TYPE"]);//_xrayreq.CLINIC_TYPE;
                addxreqdtl.XRAYREQ.COMMENTS = drDetail["COMMENTS"].ToString();
                addxreqdtl.Invoke();
            }
            return order_id;
        }
        public int set_ONLOrder_Update(int order_id, DataTable dtOrd, DataTable dtTemp, GBLEnvVariable env)
        {
            ProcessUpdateXRAYREQ upxreq = new ProcessUpdateXRAYREQ();
            upxreq.XRAYREQ.ORDER_ID = order_id;
            upxreq.XRAYREQ.INSURANCE_TYPE_ID = dtTemp.Rows[0]["INSURANCE_TYPE_ID"].ToString();
            upxreq.XRAYREQ.EMP_UID = dtTemp.Rows[0]["REF_DOC_UID"].ToString();
            upxreq.XRAYREQ.DOCNAME = dtTemp.Rows[0]["REF_DOCNAME"].ToString();
            upxreq.XRAYREQ.PAT_STATUS = dtTemp.Rows[0]["PAT_STATUS"].ToString();
            upxreq.XRAYREQ.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
            upxreq.XRAYREQ.REF_DOC_FNAME = dtTemp.Rows[0]["REF_DOC_FNAME"].ToString();
            upxreq.XRAYREQ.REF_DOC_LNAME = dtTemp.Rows[0]["REF_DOC_LNAME"].ToString();
            upxreq.XRAYREQ.REF_DOC_ID = dtTemp.Rows[0]["REF_DOC_ID"].ToString();
            upxreq.XRAYREQ.REF_UNIT = dtTemp.Rows[0]["REF_UNIT_ID"].ToString();
            upxreq.XRAYREQ.LAST_MODIFIED_BY = env.UserID;
            upxreq.XRAYREQ.ORG_ID = env.OrgID;
            upxreq.XRAYREQ.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
            upxreq.XRAYREQ.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
            upxreq.Invoke();

            foreach (DataRow drDetail in dtOrd.Rows)
            {
                if (Convert.ToInt32(drDetail["ORDER_ID"].ToString()) != 0)
                {
                    #region Update Order
                    ProcessUpdateXRAYREQDTL upxreqdtl = new ProcessUpdateXRAYREQDTL();
                    upxreqdtl.XRAYREQ.ORDER_ID = order_id;
                    upxreqdtl.XRAYREQ.EXAM_ID = Convert.ToInt32(drDetail["EXAM_ID"]);
                    upxreqdtl.XRAYREQ.MODALITY_ID = Convert.ToInt32(drDetail["MODALITY_ID"]);
                    upxreqdtl.XRAYREQ.PRIORITY = drDetail["PRIORITY"].ToString();
                    upxreqdtl.XRAYREQ.QTY = string.IsNullOrEmpty(drDetail["QTY"].ToString()) ? 1 : Convert.ToInt32(drDetail["QTY"]);
                    upxreqdtl.XRAYREQ.RATE = Convert.ToDecimal(drDetail["RATE"]);
                    upxreqdtl.XRAYREQ.BP_VIEW = drDetail["BPVIEW_NAME"].ToString();
                    string strBP_ID = string.IsNullOrEmpty(drDetail["BPVIEW_ID"].ToString()) ? "0" : drDetail["BPVIEW_ID"].ToString();
                    upxreqdtl.XRAYREQ.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                    upxreqdtl.XRAYREQ.COMMENTS = drDetail["COMMENTS"].ToString();
                    upxreqdtl.XRAYREQ.LAST_MODIFIED_BY = env.UserID;
                    upxreqdtl.XRAYREQ.ORG_ID = env.OrgID;
                    upxreqdtl.XRAYREQ.CLINIC_TYPE = Convert.ToInt32(drDetail["CLINIC_TYPE"]);
                    upxreqdtl.XRAYREQ.EXAM_DT = Convert.ToDateTime(drDetail["EXAM_DT"]);
                    upxreqdtl.XRAYREQ.PAT_DEST_ID = Convert.ToInt32(drDetail["PAT_DEST_ID"]);
                    upxreqdtl.XRAYREQ.IS_PORTABLE = drDetail["IS_PORTABLE_VALUE"].ToString();
                    upxreqdtl.Invoke();

                    #endregion
                }
                else
                {
                    #region Add Order
                    ProcessAddXrayreqdtl addxreqdtl = new ProcessAddXrayreqdtl();
                    addxreqdtl.XRAYREQ.ORDER_ID = order_id;

                    addxreqdtl.XRAYREQ.STATUS = drDetail["STATUS"].ToString();
                    addxreqdtl.XRAYREQ.PRIORITY = drDetail["PRIORITY"].ToString();
                    addxreqdtl.XRAYREQ.EXAM_DT = Convert.ToDateTime(drDetail["EXAM_DT"]);
                    addxreqdtl.XRAYREQ.EXAM_ID = Convert.ToInt32(drDetail["EXAM_ID"]);
                    addxreqdtl.XRAYREQ.EXAM_UID = drDetail["EXAM_UID"].ToString();
                    string strBP_ID = string.IsNullOrEmpty(drDetail["BPVIEW_ID"].ToString()) ? "0" : drDetail["BPVIEW_ID"].ToString();
                    addxreqdtl.XRAYREQ.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                    addxreqdtl.XRAYREQ.COMMENTS = drDetail["COMMENTS"].ToString();
                    addxreqdtl.XRAYREQ.BP_VIEW = drDetail["BPVIEW_NAME"].ToString();
                    addxreqdtl.XRAYREQ.ASSIGN_TO = string.IsNullOrEmpty(drDetail["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drDetail["ASSIGNED_TO"].ToString());
                    addxreqdtl.XRAYREQ.RATE = Convert.ToDecimal(drDetail["RATE"]);
                    addxreqdtl.XRAYREQ.PAT_DEST_ID = Convert.ToInt32(drDetail["PAT_DEST_ID"]);
                    addxreqdtl.XRAYREQ.MODALITY_ID = Convert.ToInt32(drDetail["MODALITY_ID"]);
                    addxreqdtl.XRAYREQ.IS_PORTABLE = drDetail["IS_PORTABLE_VALUE"].ToString();
                    addxreqdtl.XRAYREQ.QTY = string.IsNullOrEmpty(drDetail["QTY"].ToString()) ? 1 : Convert.ToInt32(drDetail["QTY"]);
                    addxreqdtl.XRAYREQ.ORG_ID = env.OrgID;
                    addxreqdtl.XRAYREQ.CREATED_BY = env.UserID;
                    addxreqdtl.XRAYREQ.CLINIC_TYPE = Convert.ToInt32(drDetail["CLINIC_TYPE"]);
                    addxreqdtl.Invoke();
                    #endregion
                }
            }
            return order_id;
        }
        public DataTable get_CancelTemplate()// เพิ่มเติ่มครับ
        {
            ProcessGetRISOrder ord = new ProcessGetRISOrder();
            return ord.GetCancelTemplate();
        }
        public DataSet check_conflictExam()
        {
            ProcessGetONLConflictExam conflict = new ProcessGetONLConflictExam();
            conflict.RIS_CONFLICTEXAMGROUP = this.RIS_CONFLICTEXAMGROUP;
            conflict.Invoke();
            return conflict.Result;
        }


        public bool set_RIS_ORDERCLINICALINDICATION(List<string> listFullpath, int order_id, bool is_delete, GBLEnvVariable env)
        {
            RISBaseClass risbase = new RISBaseClass();
            if (is_delete)
            {
                ProcessDeleteRISOrderClinicalIndication del = new ProcessDeleteRISOrderClinicalIndication();
                del.RIS_ORDERCLINICALINDICATION.ORDER_ID = order_id;
                del.RIS_ORDERCLINICALINDICATION.SCHEDULE_ID = 0;
                del.Invoke();
            }
            else
            {
                foreach (string strFullPath in listFullpath)
                {
                    int ciid = risbase.get_CIID_ClinicalIndication(strFullPath);

                    ProcessAddRISOrderClinicalindication addOrdIndication = new ProcessAddRISOrderClinicalindication();
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.ORDER_ID = order_id;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.IS_REQONLINE = "Y";
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CI_ID = ciid;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.ORG_ID = env.OrgID;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CREATED_BY = env.UserID;
                    addOrdIndication.Invoke();
                }
            }

            return true;
        }
        public bool set_RIS_ORDERCLINICALINDICATIONTYPE(List<string> listFullpath, int order_id, bool is_delete, GBLEnvVariable env)
        {
            RISBaseClass risbase = new RISBaseClass();
            if (is_delete)
            {
                ProcessDeleteRISOrderClinicalIndicationType del = new ProcessDeleteRISOrderClinicalIndicationType();
                del.RIS_ORDERCLINICALINDICATIONTYPE.ORDER_ID = order_id;
                del.RIS_ORDERCLINICALINDICATIONTYPE.SCHEDULE_ID = 0;
                del.Invoke();
            }
            else
            {
                foreach (string strFullPath in listFullpath)
                {
                    int ciid = risbase.get_CITypeID_ClinicalIndicationType(strFullPath);
                    ProcessAddRISOrderClinicalindicationType addOrdIndication = new ProcessAddRISOrderClinicalindicationType();
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.ORDER_ID = order_id;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.IS_REQONLINE = "Y";
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CI_ID = ciid;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.ORG_ID = env.OrgID;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CREATED_BY = env.UserID;
                    addOrdIndication.Invoke();
                }
            }
            return true;
        }
        public bool set_RIS_ORDERICD(DataTable dt, int order_id, bool is_update, GBLEnvVariable env)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ProcessAddRISOrderICD addICD = new ProcessAddRISOrderICD();
                addICD.RIS_ORDERICD.ORDER_ID = order_id;
                addICD.RIS_ORDERICD.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                addICD.RIS_ORDERICD.ORG_ID = env.OrgID;
                addICD.RIS_ORDERICD.CREATED_BY = env.UserID;
                addICD.RIS_ORDERICD.IS_REQONLINE = "Y";
                addICD.Invoke();
            }
            return true;
        }
        public bool set_RiskManagement(int xrayreq_id,DataTable dataRisk)
        {
            ProcessDeleteRisRiskIncidents processDeleteRiskIncident = new ProcessDeleteRisRiskIncidents();
            processDeleteRiskIncident.RIS_RISKINCIDENTS.XRAYREQ_ID = xrayreq_id;
            processDeleteRiskIncident.DeleteXrayreqID();

            foreach (DataRow dr in dataRisk.Rows)
            {
                ProcessAddRisRiskIncidents processAddRiskIncident = new ProcessAddRisRiskIncidents();
                processAddRiskIncident.RIS_RISKINCIDENTS.RISK_CAT_ID = Convert.ToInt32(dr["RISK_CAT_ID"]);
                processAddRiskIncident.RIS_RISKINCIDENTS.ORG_ID = Convert.ToInt32(dr["ORG_ID"]);//env.OrgID;
                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_UID = dr["INCIDENT_UID"].ToString();
                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_SUBJ = dr["INCIDENT_SUBJ"].ToString();
                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_DT = Convert.ToDateTime(dr["INCIDENT_DT"]);
                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_DESC = dr["INCIDENT_DESC"].ToString();
                processAddRiskIncident.RIS_RISKINCIDENTS.CREATED_BY = Convert.ToInt32(dr["CREATED_BY"]);//env.UserID;
                processAddRiskIncident.RIS_RISKINCIDENTS.COMMENT_ID = Convert.ToInt32(dr["COMMENT_ID"]);
                processAddRiskIncident.RIS_RISKINCIDENTS.REG_ID = Convert.ToInt32(dr["REG_ID"]);
                processAddRiskIncident.RIS_RISKINCIDENTS.XRAYREQ_ID = xrayreq_id;
                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_CHOOSED = dr["INCIDENT_CHOOSED"].ToString(); 
                processAddRiskIncident.Invoke();
            }
            return true;
        }
    }
}
