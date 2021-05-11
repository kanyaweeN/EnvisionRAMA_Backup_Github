//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    22/01/2553 11:25:39
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
	public class RISModalitymaintenancetypeUpdateData : DataAccessBase 
	{
        private RIS_MODALITYMAINTENANCETYPE _rismodalitymaintenancetype;
		public  RISModalitymaintenancetypeUpdateData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCETYPE_Update;
		}
        public RIS_MODALITYMAINTENANCETYPE RIS_MODALITYMAINTENANCETYPE
		{
			get{return _rismodalitymaintenancetype;}
			set{_rismodalitymaintenancetype=value;}
		}
		public bool Update()
		{
            //param= new RISModalitymaintenancetypeUpdateDataParameters(RISModalitymaintenancetype);
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
                Parameter("@MTN_TYPE_ID",RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_ID)
                ,Parameter("@MTN_TYPE_UID",RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_UID)
                ,Parameter("@MTN_TYPE_DESC",RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_DESC)
                ,Parameter("@ORG_ID",RIS_MODALITYMAINTENANCETYPE.ORG_ID)
                //,new SqlParameter("@CREATED_BY",RISModalitymaintenancetype.CREATED_BY)
                //,new SqlParameter("@CREATED_ON",RISModalitymaintenancetype.CREATED_ON)
                ,Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                //,new SqlParameter("@LAST_MODIFIED_ON",RIS_MODALITYMAINTENANCETYPE.LAST_MODIFIED_ON)
            };
            return parameters;
        }
        //public bool Update(bool flag,bool autocommit) 
        //{
        //    if (flag)
        //    {
        //        DataAccess.DataAccessBase.BeginTransaction();
        //        SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
        //        param= new RISModalitymaintenancetypeUpdateDataParameters(RISModalitymaintenancetype);
        //        DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
        //        dbhelper.Run(tran,param.Parameters);
        //        if(autocommit) DataAccess.DataAccessBase.Commit();
        //    }
        //    else Update();
        //    return true;
        //}
	}
}

