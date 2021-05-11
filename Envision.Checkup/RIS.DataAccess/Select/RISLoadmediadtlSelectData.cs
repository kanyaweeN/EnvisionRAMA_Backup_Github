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

namespace RIS.DataAccess.Select
{
	public class RISLoadmediadtlSelectData : DataAccessBase 
	{
		private RISLoadmediadtl	_risloadmediadtl;
		private RISLoadmediadtlSelectDataParameters param;
		public  RISLoadmediadtlSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_LOADMEDIADTL_Select.ToString();
		}
		public  RISLoadmediadtl	RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public DataSet GetData()
		{
			param = new RISLoadmediadtlSelectDataParameters(RISLoadmediadtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISLoadmediadtlSelectDataParameters 
	{
		private RISLoadmediadtl _risloadmediadtl;
		private SqlParameter[] _parameters;
		public RISLoadmediadtlSelectDataParameters(RISLoadmediadtl risloadmediadtl)
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
,new SqlParameter("@selectcase",RISLoadmediadtl.SELECTCASE)
//,new SqlParameter("@ACCESSION_NO",RISLoadmediadtl.ACCESSION_NO)
//,new SqlParameter("@EXAM_DT",RISLoadmediadtl.EXAM_DT)
//,new SqlParameter("@HL7_TEXT",RISLoadmediadtl.HL7_TEXT)
			
//,new SqlParameter("@HL7_SENT",RISLoadmediadtl.HL7_SENT)
//,new SqlParameter("@CREATED_BY",RISLoadmediadtl.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISLoadmediadtl.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISLoadmediadtl.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISLoadmediadtl.LAST_MODIFIED_ON)
			};
			_parameters=parameters;
		}
	}
}

