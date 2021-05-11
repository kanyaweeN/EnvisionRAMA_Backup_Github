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

namespace RIS.DataAccess.Insert
{
	public class RISModalityInsertData : DataAccessBase 
	{
		private RISModality	_rismodality;
		private RISModalityInsertDataParameters	_rismodalityinsertdataparameters;
		public  RISModalityInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITY_Insert.ToString();
		}
		public  RISModality	RISModality
		{
			get{return _rismodality;}
			set{_rismodality=value;}
		}
		public DataSet Add()
		{
			_rismodalityinsertdataparameters = new RISModalityInsertDataParameters(RISModality);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,_rismodalityinsertdataparameters.Parameters);
            return ds;
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
                new SqlParameter("@MODALITY_UID",RISModality.MODALITY_UID),
                new SqlParameter("@MODALITY_NAME",RISModality.MODALITY_NAME),
                new SqlParameter("@MODALITY_TYPE",RISModality.MODALITY_TYPE),
                new SqlParameter("@ROOM_ID",RISModality.ROOM_ID),
                new SqlParameter("@UNIT_ID",RISModality.UNIT_ID),
                new SqlParameter("@START_TIME",RISModality.START_TIME),
                new SqlParameter("@END_TIME",RISModality.END_TIME),
                new SqlParameter("@AVG_INV_TIME",RISModality.AVG_INV_TIME),
                new SqlParameter("@IS_ACTIVE",RISModality.IS_ACTIVE),
                new SqlParameter("@ORG_ID",RISModality.ORG_ID),
                new SqlParameter("@CREATED_BY",RISModality.CREATED_BY),
            };
			Parameters = parameters;
		}
	}
}

