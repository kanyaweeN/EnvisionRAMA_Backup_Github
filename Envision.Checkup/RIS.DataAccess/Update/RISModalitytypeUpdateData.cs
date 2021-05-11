//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//         Modifier   :    Sitti Borisuit
//         Modified   :    03/04/2008
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
	public class RISModalitytypeUpdateData : DataAccessBase 
	{
		private RISModalitytype	_rismodalitytype;
		private RISModalitytypeInsertDataParameters	_rismodalitytypeinsertdataparameters;
		public  RISModalitytypeUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYTYPE_Update.ToString();
		}
		public  RISModalitytype	RISModalitytype
		{
			get{return _rismodalitytype;}
			set{_rismodalitytype=value;}
		}
		public void Update()
		{
			_rismodalitytypeinsertdataparameters = new RISModalitytypeInsertDataParameters(RISModalitytype);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rismodalitytypeinsertdataparameters.Parameters);
		}
	}
	public class RISModalitytypeInsertDataParameters 
	{
		private RISModalitytype _rismodalitytype;
		private SqlParameter[] _parameters;
		public RISModalitytypeInsertDataParameters(RISModalitytype rismodalitytype)
		{
			RISModalitytype=rismodalitytype;
			Build();
		}
		public  RISModalitytype	RISModalitytype
		{
			get{return _rismodalitytype;}
			set{_rismodalitytype=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
        {
            SqlParameter[] parameters ={
                new SqlParameter("@TYPE_ID",RISModalitytype.TYPE_ID),
                new SqlParameter("@TYPE_UID",RISModalitytype.TYPE_UID),
                new SqlParameter("@TYPE_NAME",RISModalitytype.TYPE_NAME),
                new SqlParameter("@TYPE_NAME_ALIAS",RISModalitytype.TYPE_NAME_ALIAS),
                new SqlParameter("@DESCR",RISModalitytype.DESCR),
                new SqlParameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID),
                new SqlParameter("@ORG_ID",new GBLEnvVariable().OrgID)};
            Parameters = parameters;
        }
	}
}

