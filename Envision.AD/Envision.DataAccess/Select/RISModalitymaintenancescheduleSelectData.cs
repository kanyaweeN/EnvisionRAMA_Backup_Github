//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/01/2553 11:26:58
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class RISModalitymaintenancescheduleSelectData : DataAccessBase 
	{
        private RIS_MODALITYMAINTENANCESCHEDULE _rismodalitymaintenanceschedule;
        int mode = 0;
        public RISModalitymaintenancescheduleSelectData(int mode)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Select_Worklist;
            this.mode = mode;
        }
        public RIS_MODALITYMAINTENANCESCHEDULE RIS_MODALITYMAINTENANCESCHEDULE
		{
			get{return _rismodalitymaintenanceschedule;}
			set{_rismodalitymaintenanceschedule=value;}
		}
		public DataSet GetData()
		{
            if (mode==1)
            {    
                //param_report = new RISModalitymaintenancescheduleSelectDataParameters_ReportSelect(RISModalitymaintenanceschedule);
                //StoredProcedureName = StoredProcedure.Name.Prc_RIS_Rpt_ModalityMaintenanceSchedule.ToString();
                //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                //DataSet ds = dbhelper.Run(base.ConnectionString, param_report.Parameters);
                //return ds;
                DataSet ds = new DataSet();
                StoredProcedureName = StoredProcedure.Prc_RIS_Rpt_ModalityMaintenanceSchedule;
                ParameterList = buildParameter_ReportSelect();
                ds = ExecuteDataSet();
                return ds;
            }
            else if (mode == 2)
            {
                //param_schedule = new RISModalitymaintenancescheduleSelectDataParameters_Schedule(RISModalitymaintenanceschedule);
                //StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Select_Schedule.ToString();
                //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                //DataSet ds = dbhelper.Run(base.ConnectionString, param_schedule.Parameters);
                //return ds;
                DataSet ds = new DataSet();
                StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Select_Schedule;
                ParameterList = buildParameter_ScheduleSelect();
                ds = ExecuteDataSet();
                return ds;
            }
            else //when mode = 0
            {
                //param = new RISModalitymaintenancescheduleSelectDataParameters(RISModalitymaintenanceschedule);
                //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
                //DataSet ds = dbhelper.Run(base.ConnectionString, param.Parameters);
                //return ds;
                DataSet ds = new DataSet();
                StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Select_Worklist;
                ParameterList = buildParameter_WorklistSelect();
                ds = ExecuteDataSet();
                return ds;
            }
		}
        private DbParameter[] buildParameter_ReportSelect()
        {
            DbParameter[] parameters ={			
                Parameter("@FromDate",RIS_MODALITYMAINTENANCESCHEDULE.START_TIME)
                ,Parameter("@ToDate",RIS_MODALITYMAINTENANCESCHEDULE.END_TIME)
                ,Parameter("@MODALITY_ID",RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID)
                ,Parameter("@RESPONSIBLE_PERSON",RIS_MODALITYMAINTENANCESCHEDULE.RESPONSIBLE_PERSON)
                ,Parameter("@MTN_TYPE_WHERECLAUSE",RIS_MODALITYMAINTENANCESCHEDULE.MTN_TYPE_WHERECLAUSE)
                ,Parameter("@MODE",RIS_MODALITYMAINTENANCESCHEDULE.MODE)
			};
            return parameters;
        }
        private DbParameter[] buildParameter_ScheduleSelect()
        {
            DbParameter[] parameters ={			
                new SqlParameter("@MTN_SCH_ID",RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID)
                ,new SqlParameter("@Start_Date",RIS_MODALITYMAINTENANCESCHEDULE.START_TIME)
                ,new SqlParameter("@End_Date",RIS_MODALITYMAINTENANCESCHEDULE.END_TIME)
                ,new SqlParameter("@MODE",RIS_MODALITYMAINTENANCESCHEDULE.MODE)
                ,new SqlParameter("@MODALITY_ID_WHERECLAUSE",RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID_WHERECLAUSE)
			};
            return parameters;
        }
        private DbParameter[] buildParameter_WorklistSelect()
        {
            DbParameter[] parameters ={			
                Parameter("@Start_Date",RIS_MODALITYMAINTENANCESCHEDULE.START_TIME)
                ,Parameter("@End_Date",RIS_MODALITYMAINTENANCESCHEDULE.END_TIME)
			};
            return parameters;
        }
	}
}

