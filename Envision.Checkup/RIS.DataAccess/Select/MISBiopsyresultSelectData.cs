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

namespace RIS.DataAccess.Select
{
	public class MISBiopsyresultSelectData : DataAccessBase 
	{
		private MISBiopsyresult	_misbiopsyresult;
		private MISBiopsyresultSelectDataParameters param;
		public  MISBiopsyresultSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_MIS_BIOPSYRESULT_Select.ToString();
		}
		public  MISBiopsyresult	MISBiopsyresult
		{
			get{return _misbiopsyresult;}
			set{_misbiopsyresult=value;}
		}
		public DataSet GetData()
		{
			param = new MISBiopsyresultSelectDataParameters(MISBiopsyresult);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class MISBiopsyresultSelectDataParameters 
	{
		private MISBiopsyresult _misbiopsyresult;
		private SqlParameter[] _parameters;
		public MISBiopsyresultSelectDataParameters(MISBiopsyresult misbiopsyresult)
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
			SqlParameter[] parameters ={			
new SqlParameter("@ACCESSION_NO",MISBiopsyresult.ACCESSION_NO)
//,new SqlParameter("@RESULT_DT",MISBiopsyresult.RESULT_DT)
//,new SqlParameter("@RADIOLOGIST_ID",MISBiopsyresult.RADIOLOGIST_ID)
//,new SqlParameter("@LOC_NO_R",MISBiopsyresult.LOC_NO_R)
//                ,new SqlParameter("@LOC_NO_L",MISBiopsyresult.LOC_NO_L)
//,new SqlParameter("@TISSUE_TYPE",MISBiopsyresult.TISSUE_TYPE)
			
//,new SqlParameter("@DEPTH_TYPE_R",MISBiopsyresult.DEPTH_TYPE_R)
//                ,new SqlParameter("@DEPTH_TYPE_L",MISBiopsyresult.DEPTH_TYPE_L)
//,new SqlParameter("@WIDTH",MISBiopsyresult.WIDTH)
//,new SqlParameter("@LENGTH",MISBiopsyresult.LENGTH)
//,new SqlParameter("@DEPTH",MISBiopsyresult.DEPTH)
//,new SqlParameter("@PROCEDURE_TYPE",MISBiopsyresult.PROCEDURE_TYPE)
			
//,new SqlParameter("@NO_OF_CORE",MISBiopsyresult.NO_OF_CORE)
//,new SqlParameter("@CALCIUM_PCS",MISBiopsyresult.CALCIUM_PCS)
//,new SqlParameter("@IS_SATISFACTORY",MISBiopsyresult.IS_SATISFACTORY)
//,new SqlParameter("@IS_SURGERY",MISBiopsyresult.IS_SURGERY)
//,new SqlParameter("@COMMENTS",MISBiopsyresult.COMMENTS)
			
//,new SqlParameter("@IS_PALPABLE",MISBiopsyresult.IS_PALPABLE)
//,new SqlParameter("@LESION_TYPE_ID",MISBiopsyresult.LESION_TYPE_ID)
//,new SqlParameter("@ASESSMENT_TYPE_ID",MISBiopsyresult.ASESSMENT_TYPE_ID)
//,new SqlParameter("@TECHNIQUE_TYPE_ID",MISBiopsyresult.TECHNIQUE_TYPE_ID)
//,new SqlParameter("@LAB_DATA",MISBiopsyresult.LAB_DATA)
			
//,new SqlParameter("@ORG_ID",MISBiopsyresult.ORG_ID)
//,new SqlParameter("@CREATED_BY",MISBiopsyresult.CREATED_BY)
//,new SqlParameter("@CREATED_ON",MISBiopsyresult.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",MISBiopsyresult.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",MISBiopsyresult.LAST_MODIFIED_ON)
			};
			_parameters=parameters;
		}
	}
}

