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

namespace RIS.DataAccess.Delete
{
	public class RISExaminstructionsDeleteData : DataAccessBase 
	{
		private RISExaminstructions	_risexaminstructions;
		private RISExaminstructionsInsertDataParameters	_risexaminstructionsinsertdataparameters;
		public  RISExaminstructionsDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_EXAMINSTRUCTIONS_Delete.ToString();
		}
        public RISExaminstructions RISExaminstructions
		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public void Delete()
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
        public RISExaminstructions RISExaminstructions
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
                new SqlParameter("@EXAM_ID",RISExaminstructions.INS_ID),
                new SqlParameter("@EXAM_UID",RISExaminstructions.EXAM_ID)};
			Parameters = parameters;
		}
	}
}

