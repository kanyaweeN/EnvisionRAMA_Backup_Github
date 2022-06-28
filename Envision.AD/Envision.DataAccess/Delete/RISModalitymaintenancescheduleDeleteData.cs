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


namespace Envision.DataAccess.Delete
{
	public class RISModalitymaintenancescheduleDeleteData : DataAccessBase 
	{
        private RIS_MODALITYMAINTENANCESCHEDULE _rismodalitymaintenanceschedule;
		public  RISModalitymaintenancescheduleDeleteData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCESCHEDULE_Delete;
		}
        public RIS_MODALITYMAINTENANCESCHEDULE RIS_MODALITYMAINTENANCESCHEDULE
		{
			get{return _rismodalitymaintenanceschedule;}
			set{_rismodalitymaintenanceschedule=value;}
		}
		public bool Delete()
		{
            //param= new RISModalitymaintenancescheduleDeleteDataParameters(RISModalitymaintenanceschedule);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
            //return true;
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
		}
        public DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={ 			
                Parameter("@MTN_SCH_ID",RIS_MODALITYMAINTENANCESCHEDULE.MTN_SCH_ID)
			};
            return parameters;
        }
	}
}

