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
	public class RISExaminstructionsUpdateData : DataAccessBase 
	{
		private RISExaminstructions	_risexaminstructions;
		private RISExaminstructionsInsertDataParameters	_risexaminstructionsinsertdataparameters;
		public  RISExaminstructionsUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMINSTRUCTIONS_Update.ToString();
		}
		public  RISExaminstructions	RISExaminstructions
		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public void Update()
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
                new SqlParameter("@SP_TYPE",RISExaminstructions.SP_TYPE),
                new SqlParameter("@INS_ID",RISExaminstructions.INS_ID),
                new SqlParameter("@UNIT_ID",RISExaminstructions.UNIT_ID),
                new SqlParameter("@UNIT_INS",RISExaminstructions.UNIT_INS),
                new SqlParameter("@EXAM_TYPE_ID",RISExaminstructions.EXAM_TYPE_ID),
                new SqlParameter("@EXAM_TYPE_INS",RISExaminstructions.EXAM_TYPE_INS),
                new SqlParameter("@EXAM_TYPE_INS_KID",RISExaminstructions.EXAM_TYPE_INS_KID),
                new SqlParameter("@INS_TEXT",RISExaminstructions.INS_TEXT),
                new SqlParameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)};

            Parameters = parameters;
		}
	}
}

