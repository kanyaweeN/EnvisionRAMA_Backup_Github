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

namespace RIS.DataAccess.Delete
{
	public class INVAuthorizationDeleteData : DataAccessBase 
	{
		private INVAuthorization	_invauthorization;
		private INVAuthorizationInsertDataParameters	_invauthorizationinsertdataparameters;
		public  INVAuthorizationDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_AUTHORIZATION_Delete.ToString();
		}
		public  INVAuthorization	INVAuthorization
		{
			get{return _invauthorization;}
			set{_invauthorization=value;}
		}
		public void Delete()
		{
			_invauthorizationinsertdataparameters = new INVAuthorizationInsertDataParameters(INVAuthorization);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invauthorizationinsertdataparameters.Parameters);
		}
        public void Delete(SqlTransaction tran)
        {
            _invauthorizationinsertdataparameters = new INVAuthorizationInsertDataParameters(INVAuthorization);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            dbhelper.Run(tran, _invauthorizationinsertdataparameters.Parameters);
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
new SqlParameter("@AUTH_ID",INVAuthorization.AUTH_ID)
			};
			Parameters = parameters;
		}
	}
}

