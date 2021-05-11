//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    27/03/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Delete
{
	public class RISOrderDeleteData : DataAccessBase 
	{
		private RISOrder	_risorder;
		private RISOrderInsertDataParameters	_risorderinsertdataparameters;
		public  RISOrderDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_ORDER_Delete.ToString();
		}
		public  RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public void Delete()
		{
			_risorderinsertdataparameters = new RISOrderInsertDataParameters(RISOrder);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risorderinsertdataparameters.Parameters);
		}
	}
	public class RISOrderInsertDataParameters 
	{
		private RISOrder _risorder;
		private SqlParameter[] _parameters;
		public RISOrderInsertDataParameters(RISOrder risorder)
		{
			RISOrder=risorder;
			Build();
		}
		public  RISOrder	RISOrder
		{
			get{return _risorder;}
			set{_risorder=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ new SqlParameter("@ORDER_ID",RISOrder.ORDER_ID)};
			Parameters = parameters;
		}
	}
}

