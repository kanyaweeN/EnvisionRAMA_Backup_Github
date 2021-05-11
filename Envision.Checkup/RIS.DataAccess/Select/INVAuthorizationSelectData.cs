//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    14/01/2552 02:19:18
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class INVAuthorizationSelectData : DataAccessBase 
	{
		private INVAuthorization	_invauthorization;
		private INVAuthorizationInsertDataParameters	_invauthorizationinsertdataparameters;
		public  INVAuthorizationSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_INV_AUTHORIZATION_Select.ToString();
		}
		public  INVAuthorization	INVAuthorization
		{
			get{return _invauthorization;}
			set{_invauthorization=value;}
		}
		public DataSet GetData()
		{
			_invauthorizationinsertdataparameters = new INVAuthorizationInsertDataParameters(INVAuthorization);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_invauthorizationinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class INVAuthorizationInsertDataParameters 
	{
		private INVAuthorization _invauthorization;
		private SqlParameter[] _parameters;
		public INVAuthorizationInsertDataParameters(INVAuthorization invauthorization)
		{
			INVAuthorization=invauthorization;
			Build();
		}
		public  INVAuthorization	INVAuthorization
		{
			get{return _invauthorization;}
			set{_invauthorization=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@AUTH_ID",INVAuthorization.AUTH_ID)
//,new SqlParameter("@AUTH_DT",INVAuthorization.AUTH_DT)
new SqlParameter("@PR_ID",INVAuthorization.PR_ID)
//,new SqlParameter("@ITEM_ID",INVAuthorization.ITEM_ID)
//,new SqlParameter("@EMP_ID",INVAuthorization.EMP_ID)
			
//,new SqlParameter("@QTY",INVAuthorization.QTY)
//,new SqlParameter("@ORG_ID",INVAuthorization.ORG_ID)
//,new SqlParameter("@CREATED_BY",INVAuthorization.CREATED_BY)
//,new SqlParameter("@CREATED_ON",INVAuthorization.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",INVAuthorization.LAST_MODIFIED_BY)
			
//,new SqlParameter("@LAST_MODIFIED_ON",INVAuthorization.LAST_MODIFIED_ON)
			};
		}
	}
}

