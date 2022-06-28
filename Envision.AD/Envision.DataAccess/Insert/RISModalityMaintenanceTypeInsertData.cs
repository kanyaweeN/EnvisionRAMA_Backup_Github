//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    02/06/2552 08:25:41
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISModalityMaintenanceTypeInsertData : DataAccessBase 
	{
        public RIS_MODALITYMAINTENANCETYPE RIS_MODALITYMAINTENANCETYPE { get; set; }
        public RISModalityMaintenanceTypeInsertData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCETYPE_Insert;
		}
        public bool Add()
        {
            //StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCETYPE_Insert;
            //ParameterList = buildParameter();
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString, ParameterList);
            //return true;
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCETYPE_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@MTN_TYPE_UID",RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_UID)
                ,Parameter("@MTN_TYPE_DESC",RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_DESC)
                ,Parameter("@ORG_ID",RIS_MODALITYMAINTENANCETYPE.ORG_ID)
                ,Parameter("@CREATED_BY",new GBLEnvVariable().UserID)
                //,Parameter("@CREATED_ON",RIS_MODALITYMAINTENANCETYPE.CREATED_ON)
            };
            return parameters;
        }
	}
}

