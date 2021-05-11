using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISScheduleSelectData : DataAccessBase
    {
        public RIS_SCHEDULE RIS_SCHEDULE { get; set; }
        private int action = 0;

        public RISScheduleSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectByHN;
            RIS_SCHEDULE = new RIS_SCHEDULE();
            RIS_SCHEDULE.SCHEDULE_ID = 0;
        }
        public RISScheduleSelectData(int ScheduleID)
        {
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
        public DataSet GetScheduleConflictExam(int exam_id, int reg_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectConflictExam;
            ParameterList = buildParameter_ScheduleConflictExam(exam_id, reg_id);
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        public DataSet getScheduleAppCountDisplay(int modalityId, DateTime appDate, string sessionUid)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Online_SelectCheckDisplay;
            DbParameter[] parameters ={			
                    Parameter("@MODALITY_ID", modalityId)
                    ,Parameter("@APP_DATE", appDate)
                    ,Parameter("@SESSION_UID", sessionUid)
			};
            ParameterList = parameters;
            DataSet ds = new DataSet();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_ScheduleConflictExam(int exam_id, int reg_id)
        {
            DbParameter[] parameters ={			
                    Parameter("@EXAM_ID", exam_id)
                    ,Parameter("@REG_ID", reg_id)
			};
            return parameters;
        }
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
        public DataSet CheckFreeTime()
        {
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
        public DataSet CheckConflictTime()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_CheckConflict;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_CheckConflictTime();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_CheckConflictTime()
        {
            DbParameter[] parameters ={			
                    Parameter("@SCHEDULE_ID", RIS_SCHEDULE.SCHEDULE_ID) ,
                    Parameter("@HN", RIS_SCHEDULE.HN) ,
                    Parameter("@START_DATETIME", RIS_SCHEDULE.START_DATETIME),
                    Parameter("@END_DATETIME", RIS_SCHEDULE.END_DATETIME) 
			};
            return parameters;
        }
        public int CaseCount()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Count;
            int count = 0;
            try
            {
                DataSet ds = new DataSet();
                ParameterList = buildParameter_CaseCount(true);
                ds = ExecuteDataSet();
                count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            }
            catch
            {

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
        public DataSet GetScheduleLog()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULELOG_Select;
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
        public DataSet GetModality(int emp_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectModality;
            DataSet ds = new DataSet();
            ParameterList = buildParameter_Modality(emp_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter_Modality(int emp_id)
        {
            DbParameter[] parameters ={			
                    Parameter("@EMP_ID", emp_id)
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
        public DataSet GetByHN()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectHN;
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
        public DataSet GetByMultiPrint()
        {
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

        public DataSet checkBlockcase()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_CHECKBLOCK_Select;
            DataSet ds = new DataSet();
            ParameterList = buildParameterSelectBlockcase();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameterSelectBlockcase()
        {
            DbParameter[] parameters ={	
                    Parameter("@DATE_START", RIS_SCHEDULE.SCHEDULE_DT)
                     ,Parameter("@MODALITY_ID", RIS_SCHEDULE.MODALITY_ID)
			};
            return parameters;
        }
        public DataTable GetScheduleApp()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Online_Select;
            ParameterList = buildParameterSelectScheduleApp();
            return ExecuteDataSet().Tables[0];
        }
        private DbParameter[] buildParameterSelectScheduleApp()
        {
            DbParameter[] parameters ={	
                    Parameter("@DATE_START", RIS_SCHEDULE.START_DATETIME)
                     ,Parameter("@DATE_END", RIS_SCHEDULE.END_DATETIME)
                     ,Parameter("@MODALITY_ID", RIS_SCHEDULE.MODALITY_ID)
			};
            return parameters;
        }

        public DataTable GetBusyStatus()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_Busy;
            ParameterList = buildParameter_ScheduleByID();
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
        public DataTable GetWaitingList()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_WaitingList;
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

        public DataTable GetScheduleDataTest()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_SCHEDULE_SelectTest;
            DataTable ds = new DataTable();
            ds = ExecuteDataTable();
            return ds;
        }
    }
}
