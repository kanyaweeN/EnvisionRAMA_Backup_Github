using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class RISScheduleSelectData : DataAccessBase 
	{
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        private int action = 0;

		public  RISScheduleSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectByHN;
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE.SCHEDULE_ID = 0;
		}
        public RISScheduleSelectData(int ScheduleID) {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectByID;
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE.SCHEDULE_ID = ScheduleID;
            action = 2;
        }
        public RISScheduleSelectData(string HN)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectByHIS;
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE.HN = HN;
            action = 1;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            if (action == 1)
                ParameterList = buildParameter_ScheduleByHN(RIS_SCHEDULE.HN);
            else if (action == 2)
                ParameterList = buildParameter_ScheduleByID();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                 Parameter("@REG_ID",RIS_SCHEDULE.REG_ID)
                ,Parameter("@HN",RIS_SCHEDULE.HN)
                ,Parameter("@APPOINT_DT",RIS_SCHEDULE.START_DATETIME)
			};
            return parameters;
        }
        private DbParameter[] buildParameter_ScheduleByHN(string HN)
        {
            DbParameter[] parameters ={			
                    Parameter("@HN",HN)
			};
            return parameters;
        }
        private DbParameter[] buildParameter_ScheduleByID()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID", RIS_SCHEDULE.SCHEDULE_ID)
			};
            return parameters;
        }
        //public DataSet GetScheduleData()
        //{
        //    StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Select;
        //    //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectByCheck;
        //    //ParameterList = buildParameterSelect();
        //    DataSet ds = new DataSet();
        //    ds = ExecuteDataSet();
        //    return ds;
        //}
        public DataSet GetScheduleData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Select;
            ParameterList = buildParameterSelect();
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataTable CheckFreeSlot()
        {
            DataTable dtt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_CheckFreeSlot;
            ParameterList = buildParameter_CheckSlot();
            dtt = ExecuteDataTable();
            return dtt;
        }
        private DbParameter[] buildParameter_CheckSlot()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
			};
            return parameters;
        }

        public DataSet CheckTime()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectTime;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_CheckTime();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet CheckFreeTime() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_CheckFree;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_CheckFree();
            ds = ExecuteDataSet();
            return ds;
        
        }
        
        private DbParameter[] buildParameter_CheckTime()
        {
            DbParameter[] parameters ={			
                 Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@IS_BLOCK",RIS_SCHEDULE.IS_BLOCKED)
			};
            return parameters;
        }
        public DataSet CheckConflictTime(string hn, int exam_id, DateTime datetime_start)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_CheckConflictTime;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_CheckConflictTime(hn,exam_id,datetime_start);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_CheckConflictTime(string hn,int exam_id,DateTime datetime_start)
        {
            DbParameter[] parameters ={			
                    Parameter("@HN", hn) ,
                    Parameter("@EXAM_ID", exam_id) ,
                    Parameter("@DATETIME_START", datetime_start),
			};
            return parameters;
        }
        public int CaseCount() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Count;
            int count = 0;
            try
            {
                DataSet ds = new DataSet();
                ParameterList = buildParameter_CaseCount(true);
                ds = ExecuteDataSet();
                count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            catch { 

            }
            return count;
        }
        private DbParameter[] buildParameter_CaseCount(bool CaseCount)
        {
            if (CaseCount)
            {
                DbParameter[] parameters1 ={			
                 Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                //,Parameter("@APPOINT_DT",RIS_SCHEDULE.APPOINT_DT)
			     };
                return parameters1; 
            }
            else
            {
                DbParameter[] parameters2 ={			
                 Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID)
                ,Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                //,Parameter("@START_DATETIME",RIS_SCHEDULE.APPOINT_DT)
                //,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
                //,Parameter("@IS_BLOCK",RIS_SCHEDULE.IS_BLOCK)
			     };
                return parameters2; 
            }
        }
        public DataSet GetScheduleLog() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULELOGS_Select2;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_ScheduleLog();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_ScheduleLog()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID", RIS_SCHEDULE.SCHEDULE_ID)
			};
            return parameters;
        }
        public DataSet GetHNAppointment()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectHNApp;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_HNAppointment();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_HNAppointment()
        {
            DbParameter[] parameters ={			
                    Parameter("@HN", RIS_SCHEDULE.HN) ,
                    Parameter("@SCHEDULE_DT", RIS_SCHEDULE.SCHEDULE_DT) 
			};
            return parameters;
        }
        public DataSet GetModality()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectModality;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_Modality();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_Modality()
        {
            DbParameter[] parameters ={			
                    Parameter("@EMP_ID", new GBLEnvVariable().UserID)
			};
            return parameters;
        }
        public DataSet GetSessionCount()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SessionTime;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_SessionCount();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_SessionCount()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@START_TIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_TIME",RIS_SCHEDULE.END_DATETIME)
            };
            return parameters;
        }
        public DataSet GetSessionShow()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SessionShow;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_SessionShow();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_SessionShow()
        {
            DbParameter[] parameters ={			
                Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                ,Parameter("@START_TIME",RIS_SCHEDULE.START_DATETIME)
                ,Parameter("@END_TIME",RIS_SCHEDULE.END_DATETIME)
                ,Parameter("@SESSION_ID",RIS_SCHEDULE.SESSION_ID)
            };
            return parameters;
        }
        public DataSet GetByHN()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectHN;
            //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectHN2; //test
            DataSet ds = new DataSet();
            ParameterList = buildParameter_ByHN();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_ByHN()
        {
            DbParameter[] parameters ={			
                    Parameter("@TYPE",RIS_SCHEDULE.TYPE),
                    Parameter("@HN", RIS_SCHEDULE.HN)
			};
            return parameters;
        }
        public DataSet GetByMultiPrint() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectMultiPrint;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_ByMultiPrint();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_ByMultiPrint()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID", RIS_SCHEDULE.SCHEDULE_ID)
                    //, Parameter("@HN", RIS_SCHEDULE.HN)
			};
            return parameters;
        }
        private DbParameter[] buildParameter_CheckFree()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID", RIS_SCHEDULE.SCHEDULE_ID) ,
                    Parameter("@HN", RIS_SCHEDULE.HN) ,
                    Parameter("@MODALITY_ID", RIS_SCHEDULE.MODALITY_ID) ,
                    Parameter("@START_DATETIME", RIS_SCHEDULE.START_DATETIME),
                    Parameter("@END_DATETIME", RIS_SCHEDULE.END_DATETIME) 
			};
            return parameters;
        }
        private DbParameter[] buildParameterSelect()
        {
            DbParameter[] parameters ={	
                     //Parameter("@MODALITY_ID", RIS_SCHEDULE.MODALITY_ID),
                    //Parameter("@HN", RIS_SCHEDULE.HN),
                    //Parameter("@START_DATETIME", RIS_SCHEDULE.START_DATETIME),
                    //Parameter("@END_DATETIME", RIS_SCHEDULE.END_DATETIME)
                    Parameter("@TYPE", RIS_SCHEDULE.TYPE)
			};
            return parameters;
        }


        public DataTable GetBusyStatus()
        {
            //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Busy;
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Busy2;
            ParameterList = buildParameter_ScheduleByID();
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataTable GetWaitingList()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_WaitingList;
            //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_WaitingList2;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }

        public DataTable GetPendingOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_PendingOnline;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataTable GetAppointOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_AppointmentOnline;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataTable GetShowOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_ShowOnline2;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataTable GetOnlineStatCase()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_OnlineStatCase;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataTable UpdateNotifyAdmin(int SCHEDULE_ID, string NOTIFY_ADMIN_WL)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_UpdateNotifyAdmin;
            ParameterList = new DbParameter[] 
            { 
                    Parameter("@SCHEDULE_ID", SCHEDULE_ID)
                    ,Parameter("@NOTIFY_ADMIN_WL",NOTIFY_ADMIN_WL)
            };
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }

        private DbParameter[] buildParameterCurrentAppointment()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID),
                    Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID)
                    ,Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME)
                    ,Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
			};
            return parameters;
        }
        public DataSet GetCurrentAppointment()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_AppointmentCount;
            DataSet ds = new DataSet();
            ParameterList = buildParameterCurrentAppointment();
            ds = ExecuteDataSet();
            return ds;
        }

        public DataSet GetAppointmentDuration(string hn, DateTime date_selected)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectCaseDuration;
            ParameterList = buildParameter_AppointmentDuration(hn,date_selected);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_AppointmentDuration(string hn, DateTime date_selected)
        {
            DbParameter[] parameters ={			
                    Parameter("@HN", hn) ,
                    Parameter("@APP_DATE", date_selected) 
			};
            return parameters;
        }
        

        public DataTable GetScheduleDataTest() {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectTest;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataTable GetScheduleBlock()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectBlock;
            ParameterList = buildParameterScheduleBlock();
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }

        public DataSet getDataWorklist(DateTime start_datetime, DateTime end_datetime)
        {
            DataSet ds = new DataSet();
            //StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectWorklist;
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectWorklist3;
            ParameterList = buildParameterWorklist(start_datetime, end_datetime);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterWorklist(DateTime start_datetime, DateTime end_datetime)
        {
            DbParameter pmdateBegin = Parameter();
            pmdateBegin.ParameterName = "@dateBegin";
            if (start_datetime == null)
                pmdateBegin.Value = DBNull.Value;
            else
                pmdateBegin.Value = start_datetime == DateTime.MinValue ? (object)DBNull.Value : new DateTime(start_datetime.Year, start_datetime.Month, start_datetime.Day,0,0,0);

            DbParameter pmdateEnd = Parameter();
            pmdateEnd.ParameterName = "@dateEnd";
            if (end_datetime == null)
                pmdateEnd.Value = DBNull.Value;
            else
                pmdateEnd.Value = end_datetime == DateTime.MinValue ? (object)DBNull.Value : new DateTime(end_datetime.Year, end_datetime.Month, end_datetime.Day, 23, 59, 59);

            DbParameter[] parameters ={		
                 pmdateBegin
                ,pmdateEnd
                ,Parameter("@ORG_ID",new GBLEnvVariable().OrgID)
			};
            return parameters;
        }

        public DataTable getXrayreqData(int xrayreq_id)
        {
            DataTable dt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectByXrayreqID;
            ParameterList = buildParameterXrayreqData(xrayreq_id);
            dt = ExecuteDataTable();
            return dt;
        }
        private DbParameter[] buildParameterXrayreqData(int xrayreq_id)
        {
            DbParameter[] parameters ={		
                Parameter("@ORDER_ID",xrayreq_id)
			};
            return parameters;
        }
        public DataTable getXrayreqData(int xrayreq_id, int modality_id)
        {
            DataTable dt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectByXrayreqAndModality;
            ParameterList = buildParameterXrayreqData(xrayreq_id, modality_id);
            dt = ExecuteDataTable();
            return dt;
        }
        private DbParameter[] buildParameterXrayreqData(int xrayreq_id, int modality_id)
        {
            DbParameter[] parameters ={		
                Parameter("@ORDER_ID",xrayreq_id),
                Parameter("@MODALITY_ID",modality_id)
			};
            return parameters;
        }

        public DataTable getAppointmentMerge(int schedule_id,int modality_id,DateTime appoint_dt,int reg_id)
        {
            DataTable dt = new DataTable();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectMergeCase;
            ParameterList = new DbParameter[] { 
            Parameter("@SCHEDULE_ID",schedule_id),    
            Parameter("@REG_ID",reg_id),
                Parameter("@MODALITY_ID",modality_id),
                Parameter("@APPOINT_DT",appoint_dt)
            };
            dt = ExecuteDataTable();
            return dt;
        }
        public DataSet getAppointmentMerge(int schedule_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectMergeCaseDtl;
            ParameterList = new DbParameter[] { 
                Parameter("@SCHEDULE_ID",schedule_id)
            };
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet checkExamConflictMerge(int schedule_id, int exam_id)
        {
            DataSet ds = new DataSet();
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectMergeConflict;
            ParameterList = new DbParameter[] { 
                Parameter("@SCHEDULE_ID",schedule_id),
                Parameter("@EXAM_ID",exam_id)
            };
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterScheduleBlock()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID",RIS_SCHEDULE.SCHEDULE_ID),
                    Parameter("@MODALITY_ID",RIS_SCHEDULE.MODALITY_ID),
                    Parameter("@START_DATETIME",RIS_SCHEDULE.START_DATETIME),
                    Parameter("@END_DATETIME",RIS_SCHEDULE.END_DATETIME)
			};
            return parameters;
        }
	}
}

