//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;
using RIS.Common.Common;

namespace RIS.DataAccess.Insert
{
	public class RISExaminstructionsInsertData : DataAccessBase 
	{
		private RISExaminstructions	_risexaminstructions;
		private RISExaminstructionsInsertDataParameters	_risexaminstructionsinsertdataparameters;
		public  RISExaminstructionsInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMINSTRUCTIONS_Insert.ToString();
		}
		public  RISExaminstructions	RISExaminstructions
		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public void Add()
		{
			_risexaminstructionsinsertdataparameters = new RISExaminstructionsInsertDataParameters(RISExaminstructions);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_risexaminstructionsinsertdataparameters.Parameters);
		}
	}
	public class RISExaminstructionsInsertDataParameters 
	{
		private RISExaminstructions _risexaminstructions;
		private SqlParameter[] _parameters;
		public RISExaminstructionsInsertDataParameters(RISExaminstructions risexaminstructions)
		{
			RISExaminstructions=risexaminstructions;
			Build();
		}
		public  RISExaminstructions	RISExaminstructions
		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter[] parameters ={
                new SqlParameter("@EXAM_TYPE_ID",RISExaminstructions.EXAM_TYPE_ID),
                new SqlParameter("@EXAM_ID",RISExaminstructions.EXAM_ID),
                new SqlParameter("@INS_UID",RISExaminstructions.EXAM_ID),
                new SqlParameter("@INS_TEXT",RISExaminstructions.INS_TEXT),
                new SqlParameter("@INHERIT_GROUP",DBNull.Value),
                new SqlParameter("@IS_UPDATED",DBNull.Value),
                new SqlParameter("@IS_DELETED",DBNull.Value),
                new SqlParameter("@ORG_ID",new GBLEnvVariable().OrgID),
                new SqlParameter("@CREATED_BY",new GBLEnvVariable().UserID),
                new SqlParameter("@CREATED_ON",DateTime.Now),
                new SqlParameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID),
                new SqlParameter("@LAST_MODIFIED_ON",DateTime.Now)};

			Parameters = parameters;
		}
	}
}
