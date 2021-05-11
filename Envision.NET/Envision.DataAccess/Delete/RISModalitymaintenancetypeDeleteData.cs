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

namespace Envision.DataAccess.Delete
{
	public class RISModalitymaintenancetypeDeleteData : DataAccessBase 
	{
        private RIS_MODALITYMAINTENANCETYPE _rismodalitymaintenancetype;
		public  RISModalitymaintenancetypeDeleteData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYMAINTENANCETYPE_Delete;
		}
        public RIS_MODALITYMAINTENANCETYPE RIS_MODALITYMAINTENANCETYPE
		{
			get{return _rismodalitymaintenancetype;}
			set{_rismodalitymaintenancetype=value;}
		}
		public bool Delete()
		{
            //param= new RISModalitymaintenancetypeDeleteDataParameters(RISModalitymaintenancetype);
            //DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
            //return true;
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
		}
        public bool Delete(DbTransaction tran) 
		{
            //if (flag)
            //{
            //    DataAccess.DataAccessBase.BeginTransaction();
            //    SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
            //    param= new RISModalitymaintenancetypeDeleteDataParameters(RISModalitymaintenancetype);
            //    DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            //    dbhelper.Run(tran,param.Parameters);
            //    if(autocommit) DataAccess.DataAccessBase.Commit();
            //}
            //else Delete();
            //return true;
            if (tran != null)
            {
                ParameterList = buildParameter();
                Transaction = tran;
                ExecuteNonQuery();
            }
            else Delete();
            return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                            Parameter("@MTN_TYPE_ID",RIS_MODALITYMAINTENANCETYPE.MTN_TYPE_ID)
                                       };
            return parameters;
        }
	}
}

