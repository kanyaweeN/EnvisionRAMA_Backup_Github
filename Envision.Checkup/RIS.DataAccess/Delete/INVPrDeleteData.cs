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

namespace RIS.DataAccess.Delete
{
	public class INVPrDeleteData : DataAccessBase 
	{
		private INVPr	_invpr;
		private INVPrInsertDataParameters	_invprinsertdataparameters;
		public  INVPrDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PR_Delete.ToString();
		}
		public  INVPr	INVPr
		{
			get{return _invpr;}
			set{_invpr=value;}
		}
		public void Delete()
		{
			_invprinsertdataparameters = new INVPrInsertDataParameters(INVPr);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invprinsertdataparameters.Parameters);
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
			};
			Parameters = parameters;
		}
	}
}

