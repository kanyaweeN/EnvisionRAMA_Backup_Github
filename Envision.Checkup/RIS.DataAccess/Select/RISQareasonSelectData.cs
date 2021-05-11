//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    20/05/2009 04:53:29
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
	public class RISQareasonSelectData : DataAccessBase 
	{
		private RISQareason	_risqareason;
		private RISQareasonSelectDataParameters param;
		public  RISQareasonSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_QAREASON_Select.ToString();
		}
		public  RISQareason	RISQareason
		{
			get{return _risqareason;}
			set{_risqareason=value;}
		}
		public DataSet GetData()
		{
			param = new RISQareasonSelectDataParameters(RISQareason);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class RISQareasonSelectDataParameters 
	{
		private RISQareason _risqareason;
		private SqlParameter[] _parameters;
		public RISQareasonSelectDataParameters(RISQareason risqareason)
		{
			RISQareason=risqareason;
			Build();
		}
		public  RISQareason	RISQareason
		{
			get{return _risqareason;}
			set{_risqareason=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@REASON_ID",RISQareason.REASON_ID)
//,new SqlParameter("@REASON_UID",RISQareason.REASON_UID)
//,new SqlParameter("@REASON_TEXT",RISQareason.REASON_TEXT)
//,new SqlParameter("@REASON_ACTION",RISQareason.REASON_ACTION)
//,new SqlParameter("@ORG_ID",RISQareason.ORG_ID)
			
//,new SqlParameter("@CREATED_BY",RISQareason.CREATED_BY)
//,new SqlParameter("@CREATED_ON",RISQareason.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",RISQareason.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",RISQareason.LAST_MODIFIED_ON)
			};
			_parameters=parameters;
		}
	}
}

