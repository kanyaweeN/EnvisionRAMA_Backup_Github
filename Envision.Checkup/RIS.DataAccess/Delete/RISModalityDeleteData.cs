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
	public class RISModalityDeleteData : DataAccessBase 
	{
		private RISModality	_rismodality;
		private RISModalityInsertDataParameters	_rismodalityinsertdataparameters;
		public  RISModalityDeleteData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITY_Delete.ToString();
		}
		public  RISModality	RISModality
		{
			get{return _rismodality;}
			set{_rismodality=value;}
		}
		public void Delete()
		{
			_rismodalityinsertdataparameters = new RISModalityInsertDataParameters(RISModality);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rismodalityinsertdataparameters.Parameters);
		}
	}
	public class RISModalityInsertDataParameters 
	{
		private RISModality _rismodality;
		private SqlParameter[] _parameters;
		public RISModalityInsertDataParameters(RISModality rismodality)
		{
			RISModality=rismodality;
			Build();
		}
		public  RISModality	RISModality
		{
			get{return _rismodality;}
			set{_rismodality=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={ 
                new SqlParameter("@MODALITY_ID",RISModality.MODALITY_ID)};
			Parameters = parameters;
		}
	}
}

