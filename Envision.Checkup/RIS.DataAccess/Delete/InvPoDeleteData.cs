//---------------------------------------------------------------------------------------------
//         Use MamuGenscript generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    
//         Email      :    
//         Generate   :    16/01/2552 12:10:28
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class INVPoDeleteData : DataAccessBase 
	{
		private INVPo	_invpo;
		private INVPoInsertDataParameters	_invpoinsertdataparameters;
		public  INVPoDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_INV_PO_Delete.ToString();
		}
		public  INVPo	INVPo
		{
			get{return _invpo;}
			set{_invpo=value;}
		}
		public void Delete()
		{
			_invpoinsertdataparameters = new INVPoInsertDataParameters(INVPo);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_invpoinsertdataparameters.Parameters);
		}
	}
	public class INVPoInsertDataParameters 
	{
		private INVPo _invpo;
		private SqlParameter[] _parameters;
		public INVPoInsertDataParameters(INVPo invpo)
		{
			INVPo=invpo;
			Build();
		}
		public  INVPo	INVPo
		{
			get{return _invpo;}
			set{_invpo=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 			
new SqlParameter("@PO_ID",INVPo.PO_ID)
			};
			Parameters = parameters;
		}
	}
}

