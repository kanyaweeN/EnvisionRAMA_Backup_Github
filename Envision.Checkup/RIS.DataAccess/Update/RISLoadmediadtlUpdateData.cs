//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    19/02/2009 11:21:27
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
	public class RISLoadmediadtlUpdateData : DataAccessBase 
	{
		private RISLoadmediadtl	_risloadmediadtl;
		private RISLoadmediadtlUpdateDataParameters param;
		public  RISLoadmediadtlUpdateData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_LOADMEDIADTL_Update.ToString();
		}
		public  RISLoadmediadtl	RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public bool Update()
		{
			param= new RISLoadmediadtlUpdateDataParameters(RISLoadmediadtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
			return true;
		}
	}
	public class RISLoadmediadtlUpdateDataParameters 
	{
		private RISLoadmediadtl _risloadmediadtl;
		private SqlParameter[] _parameters;
		public RISLoadmediadtlUpdateDataParameters(RISLoadmediadtl risloadmediadtl)
		{
			RISLoadmediadtl=risloadmediadtl;
			Build();
		}
		public  RISLoadmediadtl	RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{

			SqlParameter[] parameters ={			
new SqlParameter("@LOAD_ID",RISLoadmediadtl.LOAD_ID)
,new SqlParameter("@EXAM_ID",RISLoadmediadtl.EXAM_ID)
,new SqlParameter("@ACCESSION_NO",RISLoadmediadtl.ACCESSION_NO)
//,new SqlParameter("@EXAM_DT",RISLoadmediadtl.EXAM_DT)
,new SqlParameter("@HL7_TEXT",RISLoadmediadtl.HL7_TEXT)
,new SqlParameter("@HL7_SENT",RISLoadmediadtl.HL7_SENT)
//,new SqlParameter("@CREATED_BY",RISLoadmediadtl.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISLoadmediadtl.CREATED_ON)
,new SqlParameter("@LAST_MODIFIED_BY",RISLoadmediadtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISLoadmediadtl.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

