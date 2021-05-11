//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    04/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Update
{
	public class RISServicetypeUpdateData : DataAccessBase 
	{
		private RISServicetype	_risservicetype;
		private RISServicetypeInsertDataParameters	_risservicetypeinsertdataparameters;
		public  RISServicetypeUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_SERVICETYPE_Update.ToString();
		}
		public  RISServicetype	RISServicetype
		{
			get{return _risservicetype;}
			set{_risservicetype=value;}
		}
		public void Update()
		{
			_risservicetypeinsertdataparameters = new RISServicetypeInsertDataParameters(RISServicetype);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risservicetypeinsertdataparameters.Parameters);
		}
	}
	public class RISServicetypeInsertDataParameters 
	{
		private RISServicetype _risservicetype;
		private SqlParameter[] _parameters;
		public RISServicetypeInsertDataParameters(RISServicetype risservicetype)
		{
			RISServicetype=risservicetype;
			Build();
		}
		public  RISServicetype	RISServicetype
		{
			get{return _risservicetype;}
			set{_risservicetype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={
                new SqlParameter("@SERVICE_TYPE_ID",RISServicetype.SERVICE_TYPE_ID),
                new SqlParameter("@SERVICE_TYPE_UID",RISServicetype.SERVICE_TYPE_UID),
                new SqlParameter("@IS_UPDATED",RISServicetype.IS_UPDATED),
                new SqlParameter("@IS_DELETED",RISServicetype.IS_DELETED),
                new SqlParameter("@ORG_ID",new GBLEnvVariable().OrgID),
                new SqlParameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID),
                new SqlParameter("@IS_ACTIVE",RISServicetype.IS_ACTIVE),
                new SqlParameter("@SERVICE_TYPE_TEXT",RISServicetype.SERVICE_TYPE_TEXT)};
			Parameters = parameters;
		}
	}
}

