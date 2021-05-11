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
                    sch.set_ONLSchedule_Delete(schedule_id, "Modified Data", env.UserID);
            }

            if (order_id == 0)
                order_id = set_ONLOrder_Insert(dtOrd, dtTemp, env);
            else
                set_ONLOrder_Update(order_id, dtOrd, dtTemp, env);

            return order_id;
        }
        public int set_ONLOrder_Insert(DataTable dtOrd,DataTable dtTemp,GBLEnvVariable env)
        {
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

                ProcessAddXrayreq addxreq = new ProcessAddXrayreq();
                addxreq.XRAYREQ = _xrayreq;
                addxreq.Invoke();
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
                    addxreqdtl.XRAYREQ.IS_PORTABLE = drDetail["IS_PORTABLE"].ToString();
                    addxreqdtl.XRAYREQ.QTY = string.IsNullOrEmpty(drDetail["QTY"].ToString()) ? 1 : Convert.ToInt32(drDetail["QTY"]);
                    addxreqdtl.XRAYREQ.ORG_ID = env.OrgID;
                    addxreqdtl.XRAYREQ.CREATED_BY = env.UserID;
                    addxreqdtl.XRAYREQ.CLINIC_TYPE = Convert.ToInt32(drDetail["CLINIC_TYPE"]);//_xrayreq.CLINIC_TYPE;
                    addxreqdtl.XRAYREQ.COMMENTS = drDetail["COMMENTS"].ToString();
                    addxreqdtl.Invoke();
                }
            return order_id;
        }
        public int set_ONLOrder_Update(int order_id, DataTable dtOrd, DataTable dtTemp,GBLEnvVariable env)
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
            upxreq.Invoke();

            foreach (DataRow drDetail in dtOrd.Rows)
            {
                if (Convert.ToInt32(drDetail["ORDER_ID"].ToString()) != 0)
                {
                    #region Update Order
                    ProcessUpdateXRAYREQDTL upxreqdtl = new ProcessUpdateXRAYREQDTL();
                    upxreqdtl.XRAYREQ.ORDER_ID = order_id;
                    upxreqdtl.XRAYREQ.EXAM_ID = Convert.ToInt32(drDetail["EXAM_ID"]);
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
                    upxreqdtl.XRAYREQ.IS_PORTABLE = drDetail["IS_PORTABLE"].ToString();
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
                    addxreqdtl.XRAYREQ.IS_PORTABLE = drDetail["IS_PORTABLE"].ToString();
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

        
        public bool set_RIS_ORDERCLINICALINDICATION(List<string> listFullpath, int order_id,bool is_delete,GBLEnvVariable env)
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
        public bool set_RIS_ORDERCLINICALINDICATIONTYPE(List<string> listFullpath, int order_id, bool is_delete,GBLEnvVariable env)
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
        public bool set_RIS_ORDERICD(DataTable dt, int order_id,bool is_update,GBLEnvVariable env)
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
    }
}
