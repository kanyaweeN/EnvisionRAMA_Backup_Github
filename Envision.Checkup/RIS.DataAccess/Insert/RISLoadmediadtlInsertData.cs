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

namespace RIS.DataAccess.Insert
{
	public class RISLoadmediadtlInsertData : DataAccessBase 
	{
		private RISLoadmediadtl	_risloadmediadtl;
		private RISLoadmediadtlInsertDataParameters	param;
		public  RISLoadmediadtlInsertData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_LOADMEDIADTL_Insert.ToString();
		}
		public  RISLoadmediadtl	RISLoadmediadtl
		{
			get{return _risloadmediadtl;}
			set{_risloadmediadtl=value;}
		}
		public void Add()
		{
			param= new RISLoadmediadtlInsertDataParameters(RISLoadmediadtl);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			object id = dbhelper.RunScalar(base.ConnectionString,param.Parameters);
		}
        public void Add(SqlTransaction tran)
        {
            param = new RISLoadmediadtlInsertDataParameters(RISLoadmediadtl);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(tran, param.Parameters);
        }
	}
	public class RISLoadmediadtlInsertDataParameters 
	{
		private RISLoadmediadtl _risloadmediadtl;
		private SqlParameter[] _parameters;
		public RISLoadmediadtlInsertDataParameters(RISLoadmediadtl risloadmediadtl)
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
            //SqlParameter LoadDT = new SqlParameter();
            //LoadDT.ParameterName = "@LOAD_DT";
            //if (RISLoadmedia.LOAD_DT == DateTime.MinValue)
            //{
            //    LoadDT.Value = DateTime.Now;
            //}
            //else
            //{
            //    LoadDT.Value = RISLoadmedia.LOAD_DT;
            //}
			SqlParameter[] parameters ={			
            new SqlParameter("@LOAD_ID",RISLoadmediadtl.LOAD_ID)
            ,new SqlParameter("@EXAM_ID",RISLoadmediadtl.EXAM_ID)
            ,new SqlParameter("@ACCESSION_NO",RISLoadmediadtl.ACCESSION_NO)
            //,new SqlParameter("@EXAM_DT",RISLoadmediadtl.EXAM_DT)
            ,new SqlParameter("@HL7_TEXT",RISLoadmediadtl.HL7_TEXT)
            ,new SqlParameter("@HL7_SENT",RISLoadmediadtl.HL7_SENT)
            ,new SqlParameter("@CREATED_BY",RISLoadmediadtl.CREATED_BY)
            //,new SqlParameter("@CREATED_ON",RISLoadmediadtl.CREATED_ON)
            ,new SqlParameter("@LAST_MODIFIED_BY",RISLoadmediadtl.LAST_MODIFIED_BY)
            //,new SqlParameter("@LAST_MODIFIED_ON",RISLoadmediadtl.LAST_MODIFIED_ON)
			};
			_parameters = parameters;
		}
	}
}

