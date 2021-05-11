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

namespace RIS.DataAccess.Update
{
	public class RISModalityexamUpdateData : DataAccessBase 
	{
		private RISModalityexam	_rismodalityexam;
		private RISModalityexamInsertDataParameters	_rismodalityexaminsertdataparameters;
		public  RISModalityexamUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_MODALITYEXAM_Update.ToString();
		}
		public  RISModalityexam	RISModalityexam
		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public void Update()
		{
			_rismodalityexaminsertdataparameters = new RISModalityexamInsertDataParameters(RISModalityexam);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,_rismodalityexaminsertdataparameters.Parameters);
		}
	}
	public class RISModalityexamInsertDataParameters 
	{
		private RISModalityexam _rismodalityexam;
		private SqlParameter[] _parameters;
		public RISModalityexamInsertDataParameters(RISModalityexam rismodalityexam)
		{
			RISModalityexam=rismodalityexam;
			Build();
		}
		public  RISModalityexam	RISModalityexam
		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@LAST_MODIFIED_ON";
            if (RISModalityexam.LAST_MODIFIED_ON == DateTime.MinValue)
                param.Value = DBNull.Value;
            else
                param.Value = RISModalityexam.LAST_MODIFIED_ON;

            SqlParameter paramOn = new SqlParameter();
            paramOn.ParameterName = "@CREATED_ON";
            if (RISModalityexam.CREATED_ON == DateTime.MinValue)
                paramOn.Value = DBNull.Value;
            else
                paramOn.Value = RISModalityexam.CREATED_ON;
			SqlParameter[] parameters ={
                new SqlParameter("@MODALITY_EXAM_ID",RISModalityexam.MODALITY_EXAM_ID),
                new SqlParameter("@MODALITY_ID",RISModalityexam.MODALITY_ID),
                new SqlParameter("@EXAM_ID",RISModalityexam.EXAM_ID),
                new SqlParameter("@TECH_BYPASS",RISModalityexam.TECH_BYPASS),
                new SqlParameter("@QA_BYPASS",RISModalityexam.QA_BYPASS),
                new SqlParameter("@IS_ACTIVE",RISModalityexam.IS_ACTIVE),
                new SqlParameter("@IS_DEFAULT_MODALITY",RISModalityexam.IS_DEFAULT_MODALITY),
                new SqlParameter("@IS_UPDATED",RISModalityexam.IS_UPDATED),
                new SqlParameter("@IS_DELETED",RISModalityexam.IS_DELETED),
                new SqlParameter("@ORG_ID",RISModalityexam.ORG_ID),
                new SqlParameter("@CREATED_BY",RISModalityexam.CREATED_BY),
                paramOn,
                new SqlParameter("@LAST_MODIFIED_BY",RISModalityexam.LAST_MODIFIED_BY),
                param
                };
			Parameters = parameters;
		}
	}
}

