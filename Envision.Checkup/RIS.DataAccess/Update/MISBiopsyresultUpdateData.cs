//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:24
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Update
{
	public class MISBiopsyresultUpdateData : DataAccessBase 
	{
		private MISBiopsyresult	_misbiopsyresult;
		private MISBiopsyresultUpdateDataParameters param;
		public  MISBiopsyresultUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_BIOPSYRESULT_Update.ToString();
		}
		public  MISBiopsyresult	MISBiopsyresult
		{
			get{return _misbiopsyresult;}
			set{_misbiopsyresult=value;}
		}
		public bool Update()
		{
			param= new MISBiopsyresultUpdateDataParameters(MISBiopsyresult);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
		public bool Update(bool flag,bool autocommit) 
		{
			if (flag)
			{
				DataAccess.DataAccessBase.BeginTransaction();
				SqlTransaction tran = DataAccess.DataAccessBase.Transaction;
				param= new MISBiopsyresultUpdateDataParameters(MISBiopsyresult);
				DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
				dbhelper.Run(tran,param.Parameters);
				if(autocommit) DataAccess.DataAccessBase.Commit();
			}
			else Update();
			return true;
		}
	}
	public class MISBiopsyresultUpdateDataParameters 
	{
		private MISBiopsyresult _misbiopsyresult;
		private SqlParameter[] _parameters;
		public MISBiopsyresultUpdateDataParameters(MISBiopsyresult misbiopsyresult)
		{
			MISBiopsyresult=misbiopsyresult;
			Build();
		}
		public  MISBiopsyresult	MISBiopsyresult
		{
			get{return _misbiopsyresult;}
			set{_misbiopsyresult=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
            SqlParameter LocNoR = new SqlParameter();
            LocNoR.ParameterName = "@LOC_NO_R";
            if (MISBiopsyresult.LOC_NO_R == "N")
                LocNoR.Value = DBNull.Value;
            else
                LocNoR.Value = MISBiopsyresult.LOC_NO_R;

            SqlParameter LocNoL = new SqlParameter();
            LocNoL.ParameterName = "@LOC_NO_L";
            if (MISBiopsyresult.LOC_NO_L == "N")
                LocNoL.Value = DBNull.Value;
            else
                LocNoL.Value = MISBiopsyresult.LOC_NO_L;

            SqlParameter Depth_R = new SqlParameter();
            Depth_R.ParameterName = "@DEPTH_TYPE_R";
            if (MISBiopsyresult.DEPTH_TYPE_R == "N")
                Depth_R.Value = DBNull.Value;
            else
                Depth_R.Value = MISBiopsyresult.DEPTH_TYPE_R;

            SqlParameter Depth_L = new SqlParameter();
            Depth_L.ParameterName = "@DEPTH_TYPE_L";
            if (MISBiopsyresult.DEPTH_TYPE_L == "N")
                Depth_L.Value = DBNull.Value;
            else
                Depth_L.Value = MISBiopsyresult.DEPTH_TYPE_L;
			SqlParameter[] parameters ={	
new SqlParameter("@BIOPSY_RESULT_ID",MISBiopsyresult.BIOPSY_RESULT_ID)		
,new SqlParameter("@ACCESSION_NO",MISBiopsyresult.ACCESSION_NO)
,new SqlParameter("@RESULT_DT",MISBiopsyresult.RESULT_DT)
,new SqlParameter("@RADIOLOGIST_ID",MISBiopsyresult.RADIOLOGIST_ID)
,LocNoR
                ,LocNoL
,new SqlParameter("@TISSUE_TYPE",MISBiopsyresult.TISSUE_TYPE)
,Depth_R
                ,Depth_L
,new SqlParameter("@WIDTH",MISBiopsyresult.WIDTH)
,new SqlParameter("@LENGTH",MISBiopsyresult.LENGTH)
,new SqlParameter("@DEPTH",MISBiopsyresult.DEPTH)
,new SqlParameter("@PROCEDURE_TYPE",MISBiopsyresult.PROCEDURE_TYPE)
,new SqlParameter("@NO_OF_CORE",MISBiopsyresult.NO_OF_CORE)
,new SqlParameter("@CALCIUM_PCS",MISBiopsyresult.CALCIUM_PCS)
,new SqlParameter("@IS_SATISFACTORY",MISBiopsyresult.IS_SATISFACTORY)
,new SqlParameter("@IS_SURGERY",MISBiopsyresult.IS_SURGERY)
,new SqlParameter("@COMMENTS",MISBiopsyresult.COMMENTS)
,new SqlParameter("@IS_PALPABLE",MISBiopsyresult.IS_PALPABLE)
,new SqlParameter("@LESION_TYPE_ID",MISBiopsyresult.LESION_TYPE_ID)
,new SqlParameter("@ASESSMENT_TYPE_ID",MISBiopsyresult.ASESSMENT_TYPE_ID)
,new SqlParameter("@TECHNIQUE_TYPE_ID",MISBiopsyresult.TECHNIQUE_TYPE_ID)
,new SqlParameter("@LAB_DATA",MISBiopsyresult.LAB_DATA)
,new SqlParameter("@ORG_ID",MISBiopsyresult.ORG_ID)
//,new SqlParameter("@CREATED_BY",MISBiopsyresult.CREATED_BY)
//,new SqlParameter("@CREATED_ON",MISBiopsyresult.CREATED_ON)
,new SqlParameter("@LAST_MODIFIED_BY",MISBiopsyresult.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",MISBiopsyresult.LAST_MODIFIED_ON)
,new SqlParameter("@STATUS",MISBiopsyresult.STATUS)
//,new SqlParameter("@ASSINGED_TO",MISBiopsyresult.ASSINGED_TO)
			};
			_parameters = parameters;
		}
	}
}

