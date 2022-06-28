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

namespace Envision.DataAccess.Insert
{
	public class RISModalitymaintenancescheduleInsertData : DataAccessBase 
	{
        private RIS_MODALITYMAINTENANCESCHEDULE _rismodalitymaintenanceschedule;
		public  RISModalitymaintenancescheduleInsertData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Insert;
		}
        public RIS_MODALITYMAINTENANCESCHEDULE RIS_MODALITYMAINTENANCESCHEDULE
		{
			get{return _rismodalitymaintenanceschedule;}
			set{_rismodalitymaintenanceschedule=value;}
		}
		public bool Add()
		{
            //param= new RISModalitymaintenancescheduleInsertDataParameters(RISModalitymaintenanceschedule);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
            //return true;
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={			
                            new SqlParameter("@MODALITY_ID",RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID)
                            ,new SqlParameter("@MTN_TYPE_ID",RIS_MODALITYMAINTENANCESCHEDULE.MTN_TYPE_ID)
                            ,new SqlParameter("@MTN_DT",RIS_MODALITYMAINTENANCESCHEDULE.MTN_DT)
                            ,new SqlParameter("@START_TIME",RIS_MODALITYMAINTENANCESCHEDULE.START_TIME)
                            ,new SqlParameter("@END_TIME",RIS_MODALITYMAINTENANCESCHEDULE.END_TIME)
                            ,new SqlParameter("@MTN_COST",RIS_MODALITYMAINTENANCESCHEDULE.MTN_COST)
                            ,new SqlParameter("@DISALLOW_EXAM",RIS_MODALITYMAINTENANCESCHEDULE.DISALLOW_EXAM)
                            ,new SqlParameter("@RESPONSIBLE_PERSON",RIS_MODALITYMAINTENANCESCHEDULE.RESPONSIBLE_PERSON)
                            ,new SqlParameter("@MTN_SCH_STATUS",RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_STATUS)
                            ,new SqlParameter("@COMMENTS",RIS_MODALITYMAINTENANCESCHEDULE.COMMENTS)
                            ,new SqlParameter("@ORG_ID",new GBLEnvVariable().OrgID)
                            ,new SqlParameter("@CREATED_BY",new GBLEnvVariable().UserID)
                            //,new SqlParameter("@RECURRENCEINFO",RIS_MODALITYMAINTENANCESCHEDULE.RECURRENCEINFO)
                            //,new SqlParameter("@REMINDERINFO",RIS_MODALITYMAINTENANCESCHEDULE.REMINDERINFO)
                            ,new SqlParameter("@SCHEDULE_ID",RIS_MODALITYMAINTENANCESCHEDULE.SCHEDULE_ID)
			            };
            return parameters;
        }
	}
}

