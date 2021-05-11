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
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
	public class RISModalitymaintenancescheduleUpdateData : DataAccessBase 
	{
        private RIS_MODALITYMAINTENANCESCHEDULE _rismodalitymaintenanceschedule;
		public  RISModalitymaintenancescheduleUpdateData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Update;
		}
        public RIS_MODALITYMAINTENANCESCHEDULE RIS_MODALITYMAINTENANCESCHEDULE
		{
			get{return _rismodalitymaintenanceschedule;}
			set{_rismodalitymaintenanceschedule=value;}
		}
		public bool Update()
		{
            //param= new RISModalitymaintenancescheduleUpdateDataParameters(RISModalitymaintenanceschedule);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
            //return true;
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Update;
            ParameterList = buildParameter_Update();
            ExecuteNonQuery();
            return true;
		}
        public bool UpdateChangeStatus()
		{
            //param_changestatus= new RISModalitymaintenancescheduleUpdateDataParameters_UpdateStatus(RISModalitymaintenanceschedule);
            //StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYMAINTENANCESCHEDULE_ChangeStatus.ToString();
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString, param_changestatus.Parameters);
            //return true;
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_ChangeStatus;
            ParameterList = buildParameter_UpdateChangeStatus();
            ExecuteNonQuery();
            return true;
		}

        private DbParameter[] buildParameter_Update()
        {
            DbParameter[] parameters ={
                Parameter("@MTN_SCH_ID",RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID)
                ,Parameter("@MODALITY_ID",RIS_MODALITYMAINTENANCESCHEDULE.MODALITY_ID)
                ,Parameter("@MTN_TYPE_ID",RIS_MODALITYMAINTENANCESCHEDULE.MTN_TYPE_ID)
                //,new SqlParameter("@MTN_DT",RISModalitymaintenanceschedule.MTN_DT)
                ,Parameter("@START_TIME",RIS_MODALITYMAINTENANCESCHEDULE.START_TIME)
                ,Parameter("@END_TIME",RIS_MODALITYMAINTENANCESCHEDULE.END_TIME)
                ,Parameter("@MTN_COST",RIS_MODALITYMAINTENANCESCHEDULE.MTN_COST)
                ,Parameter("@DISALLOW_EXAM",RIS_MODALITYMAINTENANCESCHEDULE.DISALLOW_EXAM)
                ,Parameter("@RESPONSIBLE_PERSON",RIS_MODALITYMAINTENANCESCHEDULE.RESPONSIBLE_PERSON)
                //,new SqlParameter("@MTN_SCH_STATUS",RISModalitymaintenanceschedule.MTN_SCH_STATUS)
                ,Parameter("@COMMENTS",RIS_MODALITYMAINTENANCESCHEDULE.COMMENTS)
                ,Parameter("@ORG_ID",new GBLEnvVariable().OrgID)
                //,new SqlParameter("@CREATED_BY",RISModalitymaintenanceschedule.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISModalitymaintenanceschedule.CREATED_ON)
                ,Parameter("@LAST_MODIFIED_BY",RIS_MODALITYMAINTENANCESCHEDULE.LAST_MODIFIED_BY)
                //,new SqlParameter("@LAST_MODIFIED_ON",RISModalitymaintenanceschedule.LAST_MODIFIED_ON)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameter_UpdateChangeStatus()
        {
            DbParameter[] parameters ={
                Parameter("@MTN_SCH_ID",RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID)
                ,Parameter("@MTN_SCH_STATUS",RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_STATUS)
                ,Parameter("@COMMENTS",RIS_MODALITYMAINTENANCESCHEDULE.COMMENTS)
                ,Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                                      };
            return parameters;
        }
	}
}

