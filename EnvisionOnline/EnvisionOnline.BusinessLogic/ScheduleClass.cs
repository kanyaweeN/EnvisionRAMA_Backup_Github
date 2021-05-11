using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EnvisionOnline.BusinessLogic.ProcessRead;
using EnvisionOnline.Common.Common;
using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic.ProcessCreate;
using EnvisionOnline.BusinessLogic.ProcessDelete;
using EnvisionOnline.BusinessLogic.ProcessUpdate;

namespace EnvisionOnline.BusinessLogic
{
    public class ScheduleClass
    {
        public ScheduleClass() { 
        }
        public DataSet get_SessionMaxapp(int modality_id , byte weekdays)
        {
            ProcessGetRISSessionMaxapp maxapp = new ProcessGetRISSessionMaxapp();
            maxapp.RIS_SESSIONMAXAPP.MODALITY_ID = modality_id;
            maxapp.RIS_SESSIONMAXAPP.WEEKDAY = weekdays;
            maxapp.Invoke();
            return maxapp.ResultSet;
        }
        
        public DataTable get_SessionTimeAll()
        {
            ProcessGetRISClinicsession session = new ProcessGetRISClinicsession();
            return session.getSessionTimeAll();
        }
        public int get_SessionID_ByAppointDate(DateTime appointDate,int clinic_type_id)
        {
            int id = 0;
            ProcessGetRISClinicsession session = new ProcessGetRISClinicsession();
            id = session.getSessionIDByAppintDate2(appointDate, clinic_type_id);
            if(id == 0)
                id = session.getSessionIDByAppintDate(appointDate);
            return id;
        }
        public DataSet get_ScheduleCountInSession(DateTime start_time,DateTime end_time,int modality_id)
        {
            ProcessGetRISClinicsession session = new ProcessGetRISClinicsession();
            session.RIS_CLINICSESSION.START_TIME = start_time;
            session.RIS_CLINICSESSION.END_TIME = end_time;
            session.RIS_CLINICSESSION.MODALITY_ID = modality_id;
            return session.getScheduleCountInSession();
        }
        public DataTable get_ScheduleApp(DateTime start_time, DateTime end_time, int modality_id)
        {
            ProcessGetRISSchedule sch = new ProcessGetRISSchedule();
            return sch.GetScheduleApp(start_time,end_time, modality_id);
        }
        public DataTable get_ScheduleAppCount(string query, DateTime date_start, DateTime date_end)
        {
            DataTable dt = new DataTable();
            ProcessGetRISSessionAppCount sessionApp = new ProcessGetRISSessionAppCount(query,date_start,date_end);
            sessionApp.Invoke();
            dt = sessionApp.Result.Tables[0];
            return dt;
        }
        public int get_ScheduleAppCountDisplay(int modalityId, DateTime appDate, string sessionUid)
        {
            ProcessGetRISSchedule checkDisplay = new ProcessGetRISSchedule();
            return Convert.ToInt32(checkDisplay.get_ScheduleAppCountDisplay(modalityId, appDate, sessionUid).Rows[0][0]);
        }
        public DataTable get_ScheduleConflictExam(int exam_id, int reg_id)
        {
            DataTable dt = new DataTable();
            ProcessGetRISSchedule conflictExam = new ProcessGetRISSchedule();
            dt = conflictExam.GetScheduleConflictExam(exam_id, reg_id);
            return dt;
        }
        
        public List<int> check_ONLSchedule(DataTable dtSch, DataTable dtTemp, DataTable dtDelete, GBLEnvVariable env)
        {
            OrderClass ord = new OrderClass();
            int order_id = 0;
            int schedule_id = 0;
            #region Check Delete Order
            foreach (DataRow drDel in dtDelete.Rows)
            {
                if (!string.IsNullOrEmpty(drDel["SCHEDULE_ID"].ToString()))
                    schedule_id = Convert.ToInt32(drDel["SCHEDULE_ID"]) > 0 ? Convert.ToInt32(drDel["SCHEDULE_ID"]) : schedule_id; //กรณี delete case เก่า
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

            foreach (DataRow drChkScheduleID in dtSch.Rows)
            {
                if (!string.IsNullOrEmpty(drChkScheduleID["ORDER_ID"].ToString()))
                    order_id = Convert.ToInt32(drChkScheduleID["ORDER_ID"]) > 0 ? Convert.ToInt32(drChkScheduleID["ORDER_ID"]) : order_id;

                if (order_id != 0)
                {
                    ProcessDeleteXrayreqdtl del = new ProcessDeleteXrayreqdtl();
                    del.XRAYREQ.ORDER_ID = order_id;
                    del.XRAYREQ.EXAM_ID = Convert.ToInt32(drChkScheduleID["EXAM_ID"]);
                    del.XRAYREQ.LAST_MODIFIED_BY = env.UserID;
                    del.Invoke();
                }
            }

            return set_ONLSchedule_Update(dtSch, dtTemp, env);
        }
        public List<int> check_ONLSchedule_ToCNMI(DataTable dtSch, DataTable dtTemp, DataTable dtDelete, GBLEnvVariable env, DataTable dtPatient)
        {
            return set_ONLSchedule_Update_ToCNMI(dtSch, dtTemp, env, dtPatient);
        }
        public DataSet check_ScheduleBlock(DateTime start_time,int modality_id)
        {
            ProcessGetRISSchedule sch = new ProcessGetRISSchedule();
            return sch.CheckBlockcase(start_time, modality_id);
        }
        public DataSet check_NavigationInstruction(int exam_id)
        {
            ProcessGetRISExamInstruction nav = new ProcessGetRISExamInstruction();
            return nav.getNavigation(exam_id);
        }

        public List<int> set_ONLSchedule_Update(DataTable dtSch, DataTable dtTemp, GBLEnvVariable env)
        {
            List<int> list = new List<int>();
            RISBaseClass baseMange = new RISBaseClass();
            DataSet dsSch = new DataSet();
            DataTable dtt = new DataTable();
            DataView dvSch = dtSch.DefaultView;
            int schedule_id = 0;
            dvSch.Sort = "SCHEDULE_ID DESC";
            dtt = dvSch.ToTable();
            schedule_id = schedule_id = string.IsNullOrEmpty(dtt.Rows[0]["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(dtt.Rows[0]["SCHEDULE_ID"].ToString());
            if (schedule_id == 0)
            {
                #region Separate Table
                int dtCount = 0;
                dvSch.Sort = "IS_PORTABLE_VALUE DESC";
                dtt = dvSch.ToTable();
                while (dtt.Rows.Count > 0)
                {
                    dtCount++;
                    DataTable dttTemp = new DataTable(dtCount.ToString());
                    dttTemp = dtt.Clone();

                    if (!string.IsNullOrEmpty(dtt.Rows[0]["IS_PORTABLE_VALUE"].ToString()))
                    {
                        DataTable dttClinic = baseMange.get_RIS_ClinicType();
                        DataTable dttExam = baseMange.get_Ris_ExamAll();

                        DataTable dtPanelPortable = new DataTable();
                        dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(dtt.Rows[0]["EXAM_ID"]), Convert.ToInt32(dtt.Rows[0]["CLINIC_TYPE"]));
                        if (dtPanelPortable.Rows.Count > 0)
                        {
                            DataRow[] chkPort = dtt.Select("EXAM_ID=" + dtPanelPortable.Rows[0]["AUTO_EXAM_ID"].ToString());
                            if (chkPort.Length > 0)
                            {

                                chkPort[0]["QTY"] = 1;
                                chkPort[0]["SESSION_ID"] = dtt.Rows[0]["SESSION_ID"];
                                chkPort[0]["START_DATETIME"] = dtt.Rows[0]["START_DATETIME"];
                                chkPort[0]["END_DATETIME"] = dtt.Rows[0]["END_DATETIME"];
                                DataRow[] rowsClinic = dttClinic.Select("CLINIC_TYPE_ID=" + chkPort[0]["CLINIC_TYPE"].ToString());
                                DataRow[] rowsExam = dttExam.Select("EXAM_ID=" + chkPort[0]["EXAM_ID"].ToString());
                                switch (rowsClinic[0]["CLINIC_TYPE_UID"].ToString())
                                {
                                    case "Normal": chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                    case "Special": chkPort[0]["RATE"] = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                                    case "VIP": chkPort[0]["RATE"] = rowsExam[0]["VIP_RATE"].ToString(); break;
                                    default: chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                }


                                dttTemp.ImportRow(chkPort[0]);
                                dttTemp.ImportRow(dtt.Rows[0]);
                                dttTemp.AcceptChanges();

                                dtt.Rows.Remove(chkPort[0]);
                                dtt.Rows.Remove(dtt.Rows[0]);
                                dtt.AcceptChanges();
                            }
                            else
                            {
                                foreach (DataTable dtCheck in dsSch.Tables)
                                {
                                    chkPort = dtCheck.Select("EXAM_ID=" + dtPanelPortable.Rows[0]["AUTO_EXAM_ID"].ToString());
                                    if (chkPort.Length > 0)
                                    {
                                        chkPort[0]["QTY"] = 1;
                                        chkPort[0]["SESSION_ID"] = dtt.Rows[0]["SESSION_ID"];
                                        chkPort[0]["START_DATETIME"] = dtt.Rows[0]["START_DATETIME"];
                                        chkPort[0]["END_DATETIME"] = dtt.Rows[0]["END_DATETIME"];
                                        DataRow[] rowsClinic = dttClinic.Select("CLINIC_TYPE_ID=" + chkPort[0]["CLINIC_TYPE"].ToString());
                                        DataRow[] rowsExam = dttExam.Select("EXAM_ID=" + chkPort[0]["EXAM_ID"].ToString());
                                        switch (rowsClinic[0]["CLINIC_TYPE_UID"].ToString())
                                        {
                                            case "Normal": chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                            case "Special": chkPort[0]["RATE"] = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                                            case "VIP": chkPort[0]["RATE"] = rowsExam[0]["VIP_RATE"].ToString(); break;
                                            default: chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                        }

                                        dtCheck.ImportRow(dtt.Rows[0]);
                                        dtCheck.AcceptChanges();

                                        dtt.Rows.Remove(dtt.Rows[0]);
                                        dtt.AcceptChanges();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable dtPanel = baseMange.get_Exam_Panel();
                        DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + dtt.Rows[0]["EXAM_ID"].ToString());
                        if (chkPanel.Length > 0)
                        {
                            DataRow[] rowCheck = dtt.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
                            if (rowCheck.Length > 0)
                            {
                                dttTemp.Rows.Add(dtt.Rows[0].ItemArray);
                                dttTemp.Rows.Add(rowCheck[0]);
                                dttTemp.AcceptChanges();

                                dtt.Rows.Remove(rowCheck[0]);
                                dtt.AcceptChanges();
                            }
                            else
                            {
                                foreach (DataTable dtCheck in dsSch.Tables)
                                {
                                    rowCheck = dtCheck.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
                                    if (rowCheck.Length > 0)
                                    {
                                        dtCheck.Rows.Add(dtt.Rows[0].ItemArray);
                                        dtCheck.AcceptChanges();

                                        dtt.Rows.Remove(dtt.Rows[0]);
                                        dtt.AcceptChanges();
                                    }
                                }
                                if (dsSch.Tables.Count <= 0)
                                {
                                    dttTemp.Rows.Add(dtt.Rows[0].ItemArray);
                                    dttTemp.AcceptChanges();

                                    dtt.Rows.Remove(dtt.Rows[0]);
                                    dtt.AcceptChanges();
                                }
                            }
                        }
                        else
                        {
                            dttTemp.Rows.Add(dtt.Rows[0].ItemArray);
                            dttTemp.AcceptChanges();

                            dtt.Rows.Remove(dtt.Rows[0]);
                            dtt.AcceptChanges();
                        }
                    }
                        
                    
                    dsSch.Tables.Add(dttTemp.Copy());
                    dsSch.Tables[dtCount - 1].TableName = dtCount.ToString();
                    dsSch.AcceptChanges();
                }
                #endregion
            }
            else
            {
                dsSch.Tables.Add(dtt.Copy());
                dsSch.AcceptChanges();
            }
            for (int z = 0; z < dsSch.Tables.Count; z++)
            {
                if (dsSch.Tables[z].Rows.Count > 0)
                {
                    #region Check Parameter
                    schedule_id = string.IsNullOrEmpty(dsSch.Tables[z].Rows[0]["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(dsSch.Tables[z].Rows[0]["SCHEDULE_ID"].ToString());
                    int avg_time = 5;
                    if (string.IsNullOrEmpty(dsSch.Tables[z].Rows[0]["AVG_INV_TIME"].ToString()))
                    {
                        RISBaseClass risbase = new RISBaseClass();
                        DataRow[] drModality = risbase.get_Ris_Modality().Select("MODALITY_ID=" + dsSch.Tables[z].Rows[0]["MODALITY_ID"].ToString());
                        avg_time = Convert.ToInt32(drModality[0]["AVG_INV_TIME"]);
                    }
                    else
                    {
                        avg_time = Convert.ToInt32(dsSch.Tables[z].Rows[0]["AVG_INV_TIME"]);
                    }
                    string strBP_ID = string.IsNullOrEmpty(dsSch.Tables[z].Rows[0]["BPVIEW_ID"].ToString()) ? "5" : dsSch.Tables[z].Rows[0]["BPVIEW_ID"].ToString();
                    #endregion

                    if (schedule_id == 0)
                    {
                        #region Insert Schedule
                        ProcessAddRISSchedule sch = new ProcessAddRISSchedule();
                        sch.RIS_SCHEDULE.SCHEDULE_ID = 0;
                        sch.RIS_SCHEDULE.HN = dsSch.Tables[z].Rows[0]["HN"].ToString();
                        sch.RIS_SCHEDULE.REG_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["REG_ID"]);
                        sch.RIS_SCHEDULE.SCHEDULE_DT = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["EXAM_DT"]);
                        sch.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["MODALITY_ID"]);
                        sch.RIS_SCHEDULE.SCHEDULE_DATA = get_ScheduleData(dsSch.Tables[z], dtTemp);
                        sch.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["SESSION_ID"]);
                        sch.RIS_SCHEDULE.START_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["START_DATETIME"]);
                        sch.RIS_SCHEDULE.END_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["END_DATETIME"]);
                        sch.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"]);
                        sch.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(dtTemp.Rows[0]["REF_DOC_ID"]);
                        sch.RIS_SCHEDULE.REF_DOC_INSTRUCTION = dsSch.Tables[z].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                        sch.RIS_SCHEDULE.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
                        sch.RIS_SCHEDULE.PAT_STATUS = Convert.ToInt32(dtTemp.Rows[0]["PAT_STATUS"]);
                        sch.RIS_SCHEDULE.SCHEDULE_STATUS = Convert.ToChar(dsSch.Tables[z].Rows[0]["STATUS"].ToString());//dsSch.Tables[z].Rows[0]["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'W' : 'S';
                        sch.RIS_SCHEDULE.IS_BLOCKED = 'N';//drChk["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'Y' : 'N';
                        sch.RIS_SCHEDULE.COMMENTS = dsSch.Tables[z].Rows[0]["COMMENTS"].ToString();
                        sch.RIS_SCHEDULE.ORG_ID = env.OrgID;
                        sch.RIS_SCHEDULE.CREATED_BY = env.UserID;
                        sch.RIS_SCHEDULE.INSURANCE_TYPE_ID = Convert.ToInt32(dtTemp.Rows[0]["INSURANCE_TYPE_ID"]);
                        sch.RIS_SCHEDULE.ENC_ID = string.IsNullOrEmpty(dtTemp.Rows[0]["ENC_ID"].ToString()) ? 0 : Convert.ToInt32(dtTemp.Rows[0]["ENC_ID"].ToString());
                        sch.RIS_SCHEDULE.ENC_TYPE = dtTemp.Rows[0]["ENC_TYPE"].ToString();
                        sch.RIS_SCHEDULE.ENC_CLINIC = dtTemp.Rows[0]["ENC_CLINIC"].ToString();
                        sch.RIS_SCHEDULE.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
                        sch.RIS_SCHEDULE.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
                        sch.RIS_SCHEDULE.IS_TELEMED = dtTemp.Rows[0]["IS_TELEMED"].ToString();
                        sch.Invoke();
                        schedule_id = sch.RIS_SCHEDULE.SCHEDULE_ID;
                        foreach (DataRow drChk in dsSch.Tables[z].Rows)
                        {
                            ProcessAddRISScheduleDtl schdtl = new ProcessAddRISScheduleDtl();
                            schdtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                            schdtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drChk["EXAM_ID"]);
                            schdtl.RIS_SCHEDULEDTL.QTY = string.IsNullOrEmpty(drChk["QTY"].ToString()) ? 1 : Convert.ToInt32(drChk["QTY"]);
                            schdtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(drChk["RATE"]);
                            schdtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(drChk["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drChk["ASSIGNED_TO"].ToString());
                            schdtl.RIS_SCHEDULEDTL.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                            schdtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = avg_time;
                            schdtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                            schdtl.RIS_SCHEDULEDTL.CREATED_BY = env.UserID;
                            schdtl.RIS_SCHEDULEDTL.PAT_DEST_ID = Convert.ToInt32(drChk["PAT_DEST_ID"]);
                            schdtl.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = string.IsNullOrEmpty(drChk["PRIORITY"].ToString().Trim()) ? "R" : drChk["PRIORITY"].ToString().Trim();
                            schdtl.Invoke();
                        }
                        #endregion

                        #region Keep logs
                        set_scheduleLogs(schedule_id, env.UserID, 'C', "Create Online");
                        #endregion
                    }
                    else
                    {
                        #region Update Schedule
                        ProcessUpdateRISSchedule upd = new ProcessUpdateRISSchedule();
                        upd.RIS_SCHEDULE.SCHEDULE_ID = schedule_id;
                        upd.RIS_SCHEDULE.HN = dsSch.Tables[z].Rows[0]["HN"].ToString();
                        upd.RIS_SCHEDULE.REG_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["REG_ID"]);
                        upd.RIS_SCHEDULE.SCHEDULE_DT = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["EXAM_DT"]);
                        upd.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["MODALITY_ID"]);
                        upd.RIS_SCHEDULE.SCHEDULE_DATA = get_ScheduleData(dsSch.Tables[z], dtTemp);
                        upd.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["SESSION_ID"]);
                        upd.RIS_SCHEDULE.START_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["START_DATETIME"]);
                        upd.RIS_SCHEDULE.END_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["END_DATETIME"]);
                        upd.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"]);
                        upd.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(dtTemp.Rows[0]["REF_DOC_ID"]);
                        upd.RIS_SCHEDULE.REF_DOC_INSTRUCTION = dsSch.Tables[z].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                        upd.RIS_SCHEDULE.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
                        upd.RIS_SCHEDULE.PAT_STATUS = Convert.ToInt32(dtTemp.Rows[0]["PAT_STATUS"]);
                        upd.RIS_SCHEDULE.SCHEDULE_STATUS = dsSch.Tables[z].Rows[0]["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'W' : 'S';
                        upd.RIS_SCHEDULE.IS_BLOCKED = 'N';//drChk["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'Y' : 'N';
                        upd.RIS_SCHEDULE.COMMENTS = dsSch.Tables[z].Rows[0]["COMMENTS"].ToString();
                        upd.RIS_SCHEDULE.ORG_ID = env.OrgID;
                        upd.RIS_SCHEDULE.CREATED_BY = env.UserID;
                        upd.RIS_SCHEDULE.INSURANCE_TYPE_ID = Convert.ToInt32(dtTemp.Rows[0]["INSURANCE_TYPE_ID"]);
                        upd.RIS_SCHEDULE.ENC_TYPE = dtTemp.Rows[0]["ENC_TYPE"].ToString();
                        upd.RIS_SCHEDULE.ENC_CLINIC = dtTemp.Rows[0]["ENC_CLINIC"].ToString();
                        upd.RIS_SCHEDULE.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
                        upd.RIS_SCHEDULE.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
                        upd.Invoke();
                        foreach (DataRow drChk in dsSch.Tables[z].Rows)
                        {
                            if (string.IsNullOrEmpty(drChk["SCHEDULE_ID"].ToString()))
                            {
                                ProcessAddRISScheduleDtl schdtl = new ProcessAddRISScheduleDtl();
                                schdtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                                schdtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drChk["EXAM_ID"]);
                                schdtl.RIS_SCHEDULEDTL.QTY = string.IsNullOrEmpty(drChk["QTY"].ToString()) ? 1 : Convert.ToInt32(drChk["QTY"]);
                                schdtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(drChk["RATE"]);
                                schdtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(drChk["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drChk["ASSIGNED_TO"].ToString());
                                schdtl.RIS_SCHEDULEDTL.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                                schdtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = avg_time;
                                schdtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                                schdtl.RIS_SCHEDULEDTL.CREATED_BY = env.UserID;
                                schdtl.RIS_SCHEDULEDTL.PAT_DEST_ID = Convert.ToInt32(drChk["PAT_DEST_ID"]);
                                schdtl.Invoke();
                            }
                            else
                            {
                                ProcessUpdateRISScheduledtl upddtl = new ProcessUpdateRISScheduledtl();
                                upddtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                                upddtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drChk["EXAM_ID"]);
                                upddtl.RIS_SCHEDULEDTL.QTY = string.IsNullOrEmpty(drChk["QTY"].ToString()) ? 1 : Convert.ToInt32(drChk["QTY"]);
                                upddtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(drChk["RATE"]);
                                upddtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(drChk["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drChk["ASSIGNED_TO"].ToString());
                                upddtl.RIS_SCHEDULEDTL.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                                upddtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = avg_time;
                                upddtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                                upddtl.RIS_SCHEDULEDTL.CREATED_BY = env.UserID;
                                upddtl.RIS_SCHEDULEDTL.PAT_DEST_ID = Convert.ToInt32(drChk["PAT_DEST_ID"]);
                                upddtl.Invoke();
                            }
                        }
                        #endregion

                        #region Keep logs
                        set_scheduleLogs(schedule_id, env.UserID, 'U', "Update Online");
                        #endregion
                    }
                    list.Add(schedule_id);
                }
            }
            return list;
        }
        public List<int> set_ONLSchedule_Update_ToCNMI(DataTable dtSch, DataTable dtTemp, GBLEnvVariable env, DataTable dtPatient)
        {
            List<int> list = new List<int>();
            RISBaseClass baseMange = new RISBaseClass();
            DataSet dsSch = new DataSet();
            DataTable dtt = new DataTable();
            DataView dvSch = dtSch.DefaultView;
            int schedule_id = 0;
            dvSch.Sort = "SCHEDULE_ID DESC";
            dtt = dvSch.ToTable();
            //schedule_id = schedule_id = string.IsNullOrEmpty(dtt.Rows[0]["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(dtt.Rows[0]["SCHEDULE_ID"].ToString());
            if (schedule_id == 0)
            {
                #region Separate Table
                int dtCount = 0;
                dvSch.Sort = "IS_PORTABLE_VALUE DESC";
                dtt = dvSch.ToTable();

                while (dtt.Rows.Count > 0)
                {
                    dtCount++;
                    DataTable dttTemp = new DataTable(dtCount.ToString());
                    dttTemp = dtt.Clone();

                    if (!string.IsNullOrEmpty(dtt.Rows[0]["IS_PORTABLE_VALUE"].ToString()))
                    {
                        DataTable dttClinic = baseMange.get_RIS_ClinicType();
                        DataTable dttExam = baseMange.get_Ris_ExamAll();

                        DataTable dtPanelPortable = new DataTable();
                        dtPanelPortable = baseMange.get_ExamPortable_Panel(Convert.ToInt32(dtt.Rows[0]["EXAM_ID"]), Convert.ToInt32(dtt.Rows[0]["CLINIC_TYPE"]));
                        if (dtPanelPortable.Rows.Count > 0)
                        {
                            DataRow[] chkPort = dtt.Select("EXAM_ID=" + dtPanelPortable.Rows[0]["AUTO_EXAM_ID"].ToString());
                            if (chkPort.Length > 0)
                            {
                                chkPort[0]["QTY"] = 1;
                                chkPort[0]["SESSION_ID"] = dtt.Rows[0]["SESSION_ID"];
                                chkPort[0]["START_DATETIME"] = dtt.Rows[0]["START_DATETIME"];
                                chkPort[0]["END_DATETIME"] = dtt.Rows[0]["END_DATETIME"];

                                DataRow[] rowsClinic = dttClinic.Select("CLINIC_TYPE_ID=" + chkPort[0]["CLINIC_TYPE"].ToString());
                                DataRow[] rowsExam = dttExam.Select("EXAM_ID=" + chkPort[0]["EXAM_ID"].ToString());
                                switch (rowsClinic[0]["CLINIC_TYPE_UID"].ToString())
                                {
                                    case "Normal": chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                    case "Special": chkPort[0]["RATE"] = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                                    case "VIP": chkPort[0]["RATE"] = rowsExam[0]["VIP_RATE"].ToString(); break;
                                    default: chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                }


                                dttTemp.ImportRow(chkPort[0]);
                                dttTemp.ImportRow(dtt.Rows[0]);
                                dttTemp.AcceptChanges();

                                dtt.Rows.Remove(chkPort[0]);
                                dtt.Rows.Remove(dtt.Rows[0]);
                                dtt.AcceptChanges();
                            }
                            else
                            {
                                foreach (DataTable dtCheck in dsSch.Tables)
                                {
                                    chkPort = dtCheck.Select("EXAM_ID=" + dtPanelPortable.Rows[0]["AUTO_EXAM_ID"].ToString());
                                    if (chkPort.Length > 0)
                                    {
                                        chkPort[0]["QTY"] = 1;
                                        chkPort[0]["SESSION_ID"] = dtt.Rows[0]["SESSION_ID"];
                                        chkPort[0]["START_DATETIME"] = dtt.Rows[0]["START_DATETIME"];
                                        chkPort[0]["END_DATETIME"] = dtt.Rows[0]["END_DATETIME"];

                                        DataRow[] rowsClinic = dttClinic.Select("CLINIC_TYPE_ID=" + chkPort[0]["CLINIC_TYPE"].ToString());
                                        DataRow[] rowsExam = dttExam.Select("EXAM_ID=" + chkPort[0]["EXAM_ID"].ToString());
                                        switch (rowsClinic[0]["CLINIC_TYPE_UID"].ToString())
                                        {
                                            case "Normal": chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                            case "Special": chkPort[0]["RATE"] = rowsExam[0]["SPECIAL_RATE"].ToString(); break;
                                            case "VIP": chkPort[0]["RATE"] = rowsExam[0]["VIP_RATE"].ToString(); break;
                                            default: chkPort[0]["RATE"] = rowsExam[0]["RATE"].ToString(); break;
                                        }

                                        dtCheck.ImportRow(dtt.Rows[0]);
                                        dtCheck.AcceptChanges();

                                        dtt.Rows.Remove(dtt.Rows[0]);
                                        dtt.AcceptChanges();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DataTable dtPanel = baseMange.get_Exam_Panel();
                        DataRow[] chkPanel = dtPanel.Select("EXAM_ID=" + dtt.Rows[0]["EXAM_ID"].ToString());
                        if (chkPanel.Length > 0)
                        {
                            DataRow[] rowCheck = dtt.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
                            if (rowCheck.Length > 0)
                            {
                                dttTemp.Rows.Add(dtt.Rows[0].ItemArray);
                                dttTemp.Rows.Add(rowCheck[0]);
                                dttTemp.AcceptChanges();

                                dtt.Rows.Remove(rowCheck[0]);
                                dtt.AcceptChanges();
                            }
                            else
                            {
                                foreach (DataTable dtCheck in dsSch.Tables)
                                {
                                    rowCheck = dtCheck.Select("EXAM_ID=" + chkPanel[0]["AUTO_EXAM_ID"].ToString());
                                    if (rowCheck.Length > 0)
                                    {
                                        dtCheck.Rows.Add(dtt.Rows[0].ItemArray);
                                        dtCheck.AcceptChanges();

                                        dtt.Rows.Remove(dtt.Rows[0]);
                                        dtt.AcceptChanges();
                                    }
                                }
                                if (dsSch.Tables.Count <= 0)
                                {
                                    dttTemp.Rows.Add(dtt.Rows[0].ItemArray);
                                    dttTemp.AcceptChanges();

                                    dtt.Rows.Remove(dtt.Rows[0]);
                                    dtt.AcceptChanges();
                                }
                            }
                        }
                        else
                        {
                            dttTemp.Rows.Add(dtt.Rows[0].ItemArray);
                            dttTemp.AcceptChanges();

                            dtt.Rows.Remove(dtt.Rows[0]);
                            dtt.AcceptChanges();
                        }
                    }


                    dsSch.Tables.Add(dttTemp.Copy());
                    dsSch.Tables[dtCount - 1].TableName = dtCount.ToString();
                    dsSch.AcceptChanges();
                }
                #endregion
            }
            else
            {
                dsSch.Tables.Add(dtt.Copy());
                dsSch.AcceptChanges();
            }

            #region get data CNMI
            DataTable dttSession = new DataTable();
            DataTable dttSessionCNMI = new DataTable();
            ProcessGetRISClinicsession proc = new ProcessGetRISClinicsession();
            proc.Invoke();
            dttSession = proc.Result.Tables[0];

            proc = new ProcessGetRISClinicsession();
            proc.InvokeCNMI();
            dttSessionCNMI = proc.Result.Tables[0];

            DataTable desExamCNMI = baseMange.get_Ris_ExamAllCNMI();
            DataTable desExam = baseMange.get_Ris_ExamAll();
            #endregion

            #region his_registration.
            int regID = 0;
            ProcessAddHISRegistration pAddHIS = new ProcessAddHISRegistration(false);
            pAddHIS.HIS_REGISTRATION.ADDR1 = dtPatient.Rows[0]["ADDR1"].ToString();
            pAddHIS.HIS_REGISTRATION.ADDR2 = dtPatient.Rows[0]["ADDR2"].ToString();
            pAddHIS.HIS_REGISTRATION.ADDR3 = dtPatient.Rows[0]["ADDR3"].ToString();
            pAddHIS.HIS_REGISTRATION.ADDR4 = dtPatient.Rows[0]["ADDR4"].ToString();
            pAddHIS.HIS_REGISTRATION.EM_CONTACT_PERSON = dtPatient.Rows[0]["EM_CONTACT_PERSON"].ToString();
            pAddHIS.HIS_REGISTRATION.EMAIL = dtPatient.Rows[0]["EMAIL"].ToString();
            pAddHIS.HIS_REGISTRATION.NATIONALITY = dtPatient.Rows[0]["NATIONALITY"].ToString();
            pAddHIS.HIS_REGISTRATION.CREATED_BY = 1;
            pAddHIS.HIS_REGISTRATION.DOB = Convert.ToDateTime(dtPatient.Rows[0]["DOB"].ToString());
            pAddHIS.HIS_REGISTRATION.FNAME = dtPatient.Rows[0]["FNAME"].ToString();
            pAddHIS.HIS_REGISTRATION.FNAME_ENG = dtPatient.Rows[0]["FNAME_ENG"].ToString();
            pAddHIS.HIS_REGISTRATION.GENDER = char.Parse(dtPatient.Rows[0]["GENDER"].ToString());
            pAddHIS.HIS_REGISTRATION.HN = dsSch.Tables[0].Rows[0]["HN"].ToString();
            pAddHIS.HIS_REGISTRATION.LNAME = dtPatient.Rows[0]["LNAME"].ToString();
            pAddHIS.HIS_REGISTRATION.LNAME_ENG = dtPatient.Rows[0]["LNAME_ENG"].ToString();
            pAddHIS.HIS_REGISTRATION.ORG_ID = env.OrgID;
            pAddHIS.HIS_REGISTRATION.PHONE1 = dtPatient.Rows[0]["PHONE1"].ToString();
            pAddHIS.HIS_REGISTRATION.PHONE2 = dtPatient.Rows[0]["PHONE2"].ToString();
            pAddHIS.HIS_REGISTRATION.PHONE3 = dtPatient.Rows[0]["PHONE3"].ToString();
            pAddHIS.HIS_REGISTRATION.SSN = dtPatient.Rows[0]["SSN"].ToString();
            pAddHIS.HIS_REGISTRATION.TITLE = dtPatient.Rows[0]["TITLE"].ToString();
            pAddHIS.HIS_REGISTRATION.TITLE_ENG = dtPatient.Rows[0]["TITLE_ENG"].ToString();
            pAddHIS.HIS_REGISTRATION.INSURANCE_TYPE = dtPatient.Rows[0]["INSURANCE_TYPE"].ToString();
            pAddHIS.HIS_REGISTRATION.IS_FOREIGNER = dtPatient.Rows[0]["IS_FOREIGNER"].ToString();
            pAddHIS.HIS_REGISTRATION.PATIENT_ID_DETAIL = dtPatient.Rows[0]["PATIENT_ID_DETAIL"].ToString();
            pAddHIS.HIS_REGISTRATION.PATIENT_ID_LABEL = dtPatient.Rows[0]["PATIENT_ID_LABEL"].ToString();
            pAddHIS.HIS_REGISTRATION.IS_JOHNDOE = 'Y';
            pAddHIS.InvokeCNMI();
            regID = pAddHIS.HIS_REGISTRATION.REG_ID;
            #endregion

            for (int z = 0; z < dsSch.Tables.Count; z++)
            {
                if (dsSch.Tables[z].Rows.Count > 0)
                {
                    #region Check Parameter
                    //schedule_id = string.IsNullOrEmpty(dsSch.Tables[z].Rows[0]["SCHEDULE_ID"].ToString()) ? 0 : Convert.ToInt32(dsSch.Tables[z].Rows[0]["SCHEDULE_ID"].ToString());
                    int avg_time = 5;
                    if (string.IsNullOrEmpty(dsSch.Tables[z].Rows[0]["AVG_INV_TIME"].ToString()))
                    {
                        RISBaseClass risbase = new RISBaseClass();
                        DataRow[] drModality = risbase.get_Ris_Modality().Select("MODALITY_ID=" + dsSch.Tables[z].Rows[0]["MODALITY_ID"].ToString());
                        avg_time = Convert.ToInt32(drModality[0]["AVG_INV_TIME"]);
                    }
                    else
                    {
                        avg_time = Convert.ToInt32(dsSch.Tables[z].Rows[0]["AVG_INV_TIME"]);
                    }
                    string strBP_ID = string.IsNullOrEmpty(dsSch.Tables[z].Rows[0]["BPVIEW_ID"].ToString()) ? "5" : dsSch.Tables[z].Rows[0]["BPVIEW_ID"].ToString();
                    #endregion

                    if (schedule_id == 0)
                    {
                        #region get data CNMI
                        DataRow[] drSession = dttSession.Select("SESSION_ID = '" + dsSch.Tables[z].Rows[0]["SESSION_ID"] + "'");
                        string[] strSession = drSession[0]["SESSION_NAME"].ToString().Split(' ');

                        String fillter = "";
                        if (strSession[0].ToString().ToLower() == "cnmi")
                            fillter = "SESSION_NAME = '" + strSession[1] + " " + strSession[2] + "'";

                        DataRow[] drSessionCNMI = dttSessionCNMI.Select(fillter);
                        #endregion

                        #region Insert Schedule
                        ProcessAddRISSchedule sch = new ProcessAddRISSchedule();
                        sch.RIS_SCHEDULE.SCHEDULE_ID = 0;
                        sch.RIS_SCHEDULE.HN = dsSch.Tables[z].Rows[0]["HN"].ToString();
                        sch.RIS_SCHEDULE.REG_ID = regID;
                        sch.RIS_SCHEDULE.SCHEDULE_DT = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["EXAM_DT"]);
                        sch.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["MODALITY_ID"]);
                        sch.RIS_SCHEDULE.SCHEDULE_DATA = get_ScheduleData(dsSch.Tables[z], dtTemp);
                        sch.RIS_SCHEDULE.SESSION_ID = drSessionCNMI.Length > 0 ? Convert.ToInt32(drSessionCNMI[0]["SESSION_ID"].ToString()) : Convert.ToInt32(dsSch.Tables[z].Rows[0]["SESSION_ID"]);   //
                        sch.RIS_SCHEDULE.START_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["START_DATETIME"]);
                        sch.RIS_SCHEDULE.END_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["END_DATETIME"]);
                        //sch.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"]);
                        //sch.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(dtTemp.Rows[0]["REF_DOC_ID"]);
                        sch.RIS_SCHEDULE.REF_UNIT = 0;   //
                        sch.RIS_SCHEDULE.REF_DOC = 0;    //
                        //sch.RIS_SCHEDULE.REF_UNIT = 1;   //
                        //sch.RIS_SCHEDULE.REF_DOC = 1;    //
                        sch.RIS_SCHEDULE.REF_DOC_INSTRUCTION = dsSch.Tables[z].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                        sch.RIS_SCHEDULE.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
                        sch.RIS_SCHEDULE.PAT_STATUS = Convert.ToInt32(dtTemp.Rows[0]["PAT_STATUS"]);

                        sch.RIS_SCHEDULE.SCHEDULE_STATUS = Convert.ToChar(dsSch.Tables[z].Rows[0]["STATUS"].ToString());//dsSch.Tables[z].Rows[0]["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'W' : 'S';
                        sch.RIS_SCHEDULE.IS_BLOCKED = 'N';//drChk["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'Y' : 'N';
                        sch.RIS_SCHEDULE.COMMENTS = dsSch.Tables[z].Rows[0]["COMMENTS"].ToString();
                        sch.RIS_SCHEDULE.ORG_ID = env.OrgID;
                        sch.RIS_SCHEDULE.CREATED_BY = 1;    //
                        sch.RIS_SCHEDULE.INSURANCE_TYPE_ID = Convert.ToInt32(dtTemp.Rows[0]["INSURANCE_TYPE_ID"]);
                        //sch.RIS_SCHEDULE.ENC_TYPE = dtTemp.Rows[0]["ENC_TYPE"].ToString();
                        //sch.RIS_SCHEDULE.ENC_CLINIC = dtTemp.Rows[0]["ENC_CLINIC"].ToString();
                        sch.RIS_SCHEDULE.ENC_TYPE = ""; //
                        sch.RIS_SCHEDULE.ENC_CLINIC = "";   //
                        sch.RIS_SCHEDULE.ENC_ID = 0;    //
                        sch.RIS_SCHEDULE.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
                        sch.RIS_SCHEDULE.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
                        sch.InvokeCNMI();
                        schedule_id = sch.RIS_SCHEDULE.SCHEDULE_ID;
                        foreach (DataRow drChk in dsSch.Tables[z].Rows)
                        {
                            DataRow[] drSelExam = desExam.Select("EXAM_ID=" + Convert.ToInt32(drChk["EXAM_ID"].ToString()) + "");
                            DataRow[] drSelExamCnmi = desExamCNMI.Select("EXAM_UID='" + drSelExam[0]["EXAM_UID"].ToString() + "'");

                            ProcessAddRISScheduleDtl schdtl = new ProcessAddRISScheduleDtl();
                            schdtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                            schdtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drSelExamCnmi[0]["EXAM_ID"]);  //
                            schdtl.RIS_SCHEDULEDTL.QTY = string.IsNullOrEmpty(drChk["QTY"].ToString()) ? 1 : Convert.ToInt32(drChk["QTY"]);
                            schdtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(drChk["RATE"]);
                            schdtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(drChk["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drChk["ASSIGNED_TO"].ToString());
                            schdtl.RIS_SCHEDULEDTL.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                            schdtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = avg_time;
                            schdtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                            schdtl.RIS_SCHEDULEDTL.CREATED_BY = 1;  //
                            schdtl.RIS_SCHEDULEDTL.PAT_DEST_ID = 1; //
                            schdtl.RIS_SCHEDULEDTL.SCHEDULE_PRIORITY = string.IsNullOrEmpty(drChk["PRIORITY"].ToString().Trim()) ? "R" : drChk["PRIORITY"].ToString().Trim();
                            schdtl.InvokeCNMI();
                        }
                        #endregion

                        #region Keep logs
                        set_scheduleLogsCNMI(schedule_id, env.UserID, 'C', "Create OnlineRama");
                        #endregion
                    }
                    //else
                    //{
                    //    #region Update Schedule
                    //    ProcessUpdateRISSchedule upd = new ProcessUpdateRISSchedule();
                    //    upd.RIS_SCHEDULE.SCHEDULE_ID = schedule_id;
                    //    upd.RIS_SCHEDULE.HN = dsSch.Tables[z].Rows[0]["HN"].ToString();
                    //    upd.RIS_SCHEDULE.REG_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["REG_ID"]);
                    //    upd.RIS_SCHEDULE.SCHEDULE_DT = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["EXAM_DT"]);
                    //    upd.RIS_SCHEDULE.MODALITY_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["MODALITY_ID"]);
                    //    upd.RIS_SCHEDULE.SCHEDULE_DATA = get_ScheduleData(dsSch.Tables[z], dtTemp);
                    //    upd.RIS_SCHEDULE.SESSION_ID = Convert.ToInt32(dsSch.Tables[z].Rows[0]["SESSION_ID"]);
                    //    upd.RIS_SCHEDULE.START_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["START_DATETIME"]);
                    //    upd.RIS_SCHEDULE.END_DATETIME = Convert.ToDateTime(dsSch.Tables[z].Rows[0]["END_DATETIME"]);
                    //    upd.RIS_SCHEDULE.REF_UNIT = Convert.ToInt32(dtTemp.Rows[0]["REF_UNIT_ID"]);
                    //    upd.RIS_SCHEDULE.REF_DOC = Convert.ToInt32(dtTemp.Rows[0]["REF_DOC_ID"]);
                    //    upd.RIS_SCHEDULE.REF_DOC_INSTRUCTION = dsSch.Tables[z].Rows[0]["REF_DOC_INSTRUCTION"].ToString();
                    //    upd.RIS_SCHEDULE.CLINICAL_INSTRUCTION = dtTemp.Rows[0]["txtEditor"].ToString();
                    //    upd.RIS_SCHEDULE.PAT_STATUS = Convert.ToInt32(dtTemp.Rows[0]["PAT_STATUS"]);
                    //    upd.RIS_SCHEDULE.SCHEDULE_STATUS = dsSch.Tables[z].Rows[0]["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'W' : 'S';
                    //    upd.RIS_SCHEDULE.IS_BLOCKED = 'N';//drChk["strEXAM_DT"].ToString().IndexOf("Waiting") >= 0 ? 'Y' : 'N';
                    //    upd.RIS_SCHEDULE.COMMENTS = dsSch.Tables[z].Rows[0]["COMMENTS"].ToString();
                    //    upd.RIS_SCHEDULE.ORG_ID = env.OrgID;
                    //    upd.RIS_SCHEDULE.CREATED_BY = env.UserID;
                    //    upd.RIS_SCHEDULE.INSURANCE_TYPE_ID = Convert.ToInt32(dtTemp.Rows[0]["INSURANCE_TYPE_ID"]);
                    //    upd.RIS_SCHEDULE.ENC_TYPE = dtTemp.Rows[0]["ENC_TYPE"].ToString();
                    //    upd.RIS_SCHEDULE.ENC_CLINIC = dtTemp.Rows[0]["ENC_CLINIC"].ToString();
                    //    upd.RIS_SCHEDULE.IS_ALERT_CLINICAL_INSTRUCTION = dtTemp.Rows[0]["IS_ALERT_CLINICAL_INSTRUCTION"].ToString();
                    //    upd.RIS_SCHEDULE.CLINICAL_INSTRUCTION_TAG = dtTemp.Rows[0]["CLINICAL_INSTRUCTION_TAG"].ToString();
                    //    upd.Invoke();
                        //foreach (DataRow drChk in dsSch.Tables[z].Rows)
                        //{
                        //    if (string.IsNullOrEmpty(drChk["SCHEDULE_ID"].ToString()))
                        //    {
                        //        ProcessAddRISScheduleDtl schdtl = new ProcessAddRISScheduleDtl();
                        //        schdtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                        //        schdtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drChk["EXAM_ID"]);
                        //        schdtl.RIS_SCHEDULEDTL.QTY = string.IsNullOrEmpty(drChk["QTY"].ToString()) ? 1 : Convert.ToInt32(drChk["QTY"]);
                        //        schdtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(drChk["RATE"]);
                        //        schdtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(drChk["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drChk["ASSIGNED_TO"].ToString());
                        //        schdtl.RIS_SCHEDULEDTL.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                        //        schdtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = avg_time;
                        //        schdtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                        //        schdtl.RIS_SCHEDULEDTL.CREATED_BY = env.UserID;
                        //        schdtl.RIS_SCHEDULEDTL.PAT_DEST_ID = Convert.ToInt32(drChk["PAT_DEST_ID"]);
                        //        schdtl.Invoke();
                        //    }
                        //    else
                        //    {
                        //        ProcessUpdateRISScheduledtl upddtl = new ProcessUpdateRISScheduledtl();
                        //        upddtl.RIS_SCHEDULEDTL.SCHEDULE_ID = schedule_id;
                        //        upddtl.RIS_SCHEDULEDTL.EXAM_ID = Convert.ToInt32(drChk["EXAM_ID"]);
                        //        upddtl.RIS_SCHEDULEDTL.QTY = string.IsNullOrEmpty(drChk["QTY"].ToString()) ? 1 : Convert.ToInt32(drChk["QTY"]);
                        //        upddtl.RIS_SCHEDULEDTL.RATE = Convert.ToDecimal(drChk["RATE"]);
                        //        upddtl.RIS_SCHEDULEDTL.RAD_ID = string.IsNullOrEmpty(drChk["ASSIGNED_TO"].ToString()) ? 0 : Convert.ToInt32(drChk["ASSIGNED_TO"].ToString());
                        //        upddtl.RIS_SCHEDULEDTL.BPVIEW_ID = Convert.ToInt32(strBP_ID);
                        //        upddtl.RIS_SCHEDULEDTL.AVG_REQ_MIN = avg_time;
                        //        upddtl.RIS_SCHEDULEDTL.ORG_ID = env.OrgID;
                        //        upddtl.RIS_SCHEDULEDTL.CREATED_BY = env.UserID;
                        //        upddtl.RIS_SCHEDULEDTL.PAT_DEST_ID = 1;
                        //        upddtl.Invoke();
                        //    }
                        //}
                    //    #endregion

                    //    #region Keep logs
                    //    set_scheduleLogsCNMI(schedule_id, env.UserID, 'C', "Create OnlineRama");
                    //    #endregion
                    //}
                    list.Add(schedule_id);
                }
            }
            return list;
        }
        
        public bool set_ONLSchedule_Delete(int schedule_id,string reason,int last_modified_by,string hn)
        {
            ProcessDeleteRISSchedule del = new ProcessDeleteRISSchedule();
            del.RIS_SCHEDULE.SCHEDULE_ID = schedule_id;
            del.RIS_SCHEDULE.REASON = reason;
            del.RIS_SCHEDULE.LAST_MODIFIED_BY = last_modified_by;
            del.RIS_SCHEDULE.HN = hn;
            del.Invoke();
            return true;
        }
        private string get_ScheduleData(DataTable dtsch, DataTable dtTemp)
        {
            RISBaseClass risbase = new RISBaseClass();
            DataTable dtExam = risbase.get_Ris_Exam();
            string schedule_data = "";
            schedule_data += "HN : " + dtsch.Rows[0]["HN"].ToString();
            schedule_data += " " + dtTemp.Rows[0]["FULLNAME_PAT"].ToString();
            foreach (DataRow dr in dtsch.Rows)
            {
                DataRow[] rowExam = dtExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                if (rowExam.Length > 0)
                    schedule_data += " " + rowExam[0]["EXAM_NAME"].ToString() +";";
            }
            foreach (DataRow drr in dtsch.Rows)
                schedule_data += " (" + drr["COMMENTS"].ToString()+");";

            return schedule_data;
        }
        private string get_ScheduleDataCNMI(DataTable dtsch, DataTable dtTemp)
        {
            RISBaseClass risbase = new RISBaseClass();
            DataTable dtExam = risbase.get_Ris_Exam();
            string schedule_data = "";
            schedule_data += "HN : " + dtsch.Rows[0]["HN"].ToString();
            schedule_data += " " + dtTemp.Rows[0]["FULLNAME_PAT"].ToString();
            foreach (DataRow dr in dtsch.Rows)
            {
                DataRow[] rowExam = dtExam.Select("EXAM_ID=" + dr["EXAM_ID"].ToString());
                if (rowExam.Length > 0)
                    schedule_data += " " + rowExam[0]["EXAM_NAME"].ToString() + ";";
            }
            schedule_data += "(Online)";
            foreach (DataRow drr in dtsch.Rows)
                schedule_data += " (" + drr["COMMENTS"].ToString() + ");";

            return schedule_data;
        }
        private int get_CIID_ClinicalIndication(string strFullPath)
        {
            ProcessGetRISClinicalIndication indication = new ProcessGetRISClinicalIndication();
            string[] splFullPath = strFullPath.Split('/');
            int ciid = 0;
            if (splFullPath.Length > 1)
            {
                int i = splFullPath.Length - 1;
                ciid = indication.get_CI_ID(splFullPath[i], splFullPath[i - 1], "Multi"); ;
            }
            else
                ciid = indication.get_CI_ID(splFullPath[0], "", "Single");

            return ciid;
        }
        private int get_CITypeID_ClinicalIndicationType(string strFullPath)
        {
            string[] splFullPath = strFullPath.Split('/');
            int ciid = 0;
            ProcessGetRISClinicalIndicationType indication = new ProcessGetRISClinicalIndicationType();
            if (splFullPath.Length > 1)
            {
                int i = splFullPath.Length - 1;
                ciid = indication.get_CI_TYPE_ID(splFullPath[i], splFullPath[i - 1], "Multi");
            }
            else
                ciid = indication.get_CI_TYPE_ID(splFullPath[0], "", "Single");
            return ciid;
        }

        public bool set_RIS_ORDERCLINICALINDICATION(List<string> listFullpath, int schedule_id, bool is_delete,GBLEnvVariable env)
        {
            if (is_delete)
            {
                ProcessDeleteRISOrderClinicalIndication del = new ProcessDeleteRISOrderClinicalIndication();
                del.RIS_ORDERCLINICALINDICATION.ORDER_ID = 0;
                del.RIS_ORDERCLINICALINDICATION.SCHEDULE_ID = schedule_id;
                del.Invoke();
            }
            else
            {
                foreach (string strFullPath in listFullpath)
                {
                    int ciid = get_CIID_ClinicalIndication(strFullPath);

                    ProcessAddRISOrderClinicalindication addOrdIndication = new ProcessAddRISOrderClinicalindication();
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.SCHEDULE_ID = schedule_id;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.IS_REQONLINE = "Y";
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CI_ID = ciid;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.ORG_ID = env.OrgID;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CREATED_BY = env.UserID;
                    addOrdIndication.Invoke();
                }
            }
            return true;
        }
        public bool set_RIS_ORDERCLINICALINDICATIONTYPE(List<string> listFullpath, int schedule_id, bool is_delete,GBLEnvVariable env)
        {

            if (is_delete)
            {
                ProcessDeleteRISOrderClinicalIndicationType del = new ProcessDeleteRISOrderClinicalIndicationType();
                del.RIS_ORDERCLINICALINDICATIONTYPE.ORDER_ID = 0;
                del.RIS_ORDERCLINICALINDICATIONTYPE.SCHEDULE_ID = schedule_id;
                del.Invoke();
            }
            else
            {
                foreach (string strFullPath in listFullpath)
                {
                    int ciid = get_CITypeID_ClinicalIndicationType(strFullPath);
                    ProcessAddRISOrderClinicalindicationType addOrdIndication = new ProcessAddRISOrderClinicalindicationType();
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.SCHEDULE_ID = schedule_id;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.IS_REQONLINE = "Y";
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CI_ID = ciid;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.ORG_ID = env.OrgID;
                    addOrdIndication.RIS_ORDERCLINICALINDICATION.CREATED_BY = env.UserID;
                    addOrdIndication.Invoke();
                }
            }
            return true;
        }
        
        public bool set_RIS_ORDERICD(DataTable dt, int schedule_id, bool is_update,GBLEnvVariable env)
        {
            foreach (DataRow dr in dt.Rows)
            {
                ProcessAddRISOrderICD addICD = new ProcessAddRISOrderICD();
                addICD.RIS_ORDERICD.SCHEDULE_ID = schedule_id;
                addICD.RIS_ORDERICD.ICD_ID = Convert.ToInt32(dr["ICD_ID"]);
                addICD.RIS_ORDERICD.ORG_ID = env.OrgID;
                addICD.RIS_ORDERICD.CREATED_BY = env.UserID;
                addICD.RIS_ORDERICD.IS_REQONLINE = "Y";
                addICD.Invoke();
            }
            return true;
        }

        public bool set_RiskManagement(int schedule_id, DataTable dataRisk)
        {
            ProcessDeleteRisRiskIncidents processDeleteRiskIncident = new ProcessDeleteRisRiskIncidents();
            processDeleteRiskIncident.RIS_RISKINCIDENTS.SCHEDULE_ID = schedule_id;
            processDeleteRiskIncident.DeleteScheduleID();

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
                processAddRiskIncident.RIS_RISKINCIDENTS.SCHEDULE_ID = schedule_id;
                processAddRiskIncident.RIS_RISKINCIDENTS.INCIDENT_CHOOSED = dr["INCIDENT_CHOOSED"].ToString(); ;
                processAddRiskIncident.Invoke();
            }
            return true;
        }

        #region Keep logs
        public void set_scheduleLogs(int schedule_id,int logs_modified_by,char logs_status, string logs_desc)
        {
            #region insert schedule logs
            ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
            schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = schedule_id;
            schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = logs_modified_by;
            schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = logs_status;
            schLogs.RIS_SCHEDULELOGS.LOGS_DESC = logs_desc;
            schLogs.Invoke();
            #endregion
        }
        public void set_scheduleLogsCNMI(int schedule_id, int logs_modified_by, char logs_status, string logs_desc)
        {
            #region insert schedule logs
            ProcessAddRISScheduleLogs schLogs = new ProcessAddRISScheduleLogs();
            schLogs.RIS_SCHEDULELOGS.SCHEDULE_ID = schedule_id;
            schLogs.RIS_SCHEDULELOGS.LOGS_MODIFIED_BY = 1;
            schLogs.RIS_SCHEDULELOGS.LOGS_STATUS = logs_status;
            schLogs.RIS_SCHEDULELOGS.LOGS_DESC = logs_desc;
            schLogs.InvokeCNMI();
            #endregion
        }
        #endregion
    }
}
