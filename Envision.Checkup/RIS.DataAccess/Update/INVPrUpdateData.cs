//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    23/12/2551 12:15:50
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class INVPrUpdateData : DataAccessBase 
	{
		private INVPr	_invpr;
		private INVPrInsertDataParameters	_invprinsertdataparameters;
		public  INVPrUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PR_Update.ToString();
		}
		public  INVPr	INVPr
		{
			get{return _invpr;}
			set{_invpr=value;}
		}
		public void Update()
		{
			_invprinsertdataparameters = new INVPrInsertDataParameters(INVPr);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			dbhelper.Run(base.ConnectionString,_invprinsertdataparameters.Parameters);
		}
        public void Update(SqlTransaction tran)
        {
            _invprinsertdataparameters = new INVPrInsertDataParameters(INVPr);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _invprinsertdataparameters.Parameters);
        }
	}
	public class INVPrInsertDataParameters 
	{
		private INVPr _invpr;
		private SqlParameter[] _parameters;
		public INVPrInsertDataParameters(INVPr invpr)
		{
			INVPr=invpr;
			Build();
		}
		public  INVPr	INVPr
		{
			get{return _invpr;}
			set{_invpr=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
new SqlParameter("@PR_ID",INVPr.PR_ID)
,new SqlParameter("@PR_UID",INVPr.PR_UID)
//,new SqlParameter("@GENERATE_MODE",INVPr.GENERATE_MODE)
//,new SqlParameter("@GENERATED_BY",INVPr.GENERATED_BY)
//,new SqlParameter("@GENERATED_ON",INVPr.GENERATED_ON)
//,new SqlParameter("@PR_STATUS",INVPr.PR_STATUS)
//,new SqlParameter("@ORG_ID",INVPr.ORG_ID)
//,new SqlParameter("@CREATED_BY",INVPr.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVPr.CREATED_ON)
,new SqlParameter("@LAST_MODIFIED_BY",INVPr.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",INVPr.LAST_MODIFIED_ON)
			};
            Parameters = parameters;
		}
	}
}

