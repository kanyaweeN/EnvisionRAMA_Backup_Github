//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    17/04/2551
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;

namespace RIS.DataAccess.Select
{
	public class RISAuthlevelSelectData : DataAccessBase 
	{
		private RISAuthlevel	_risauthlevel;
		private RISAuthlevelInsertDataParameters	_risauthlevelinsertdataparameters;
		public  RISAuthlevelSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_AUTHLEVEL_Select.ToString();
		}
		public  RISAuthlevel	RISAuthlevel
		{
			get{return _risauthlevel;}
			set{_risauthlevel=value;}
		}
		public DataSet GetData()
		{
			//_risauthlevelinsertdataparameters = new RISAuthlevelInsertDataParameters(RISAuthlevel);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);//,_risauthlevelinsertdataparameters.Parameters);
			return ds;
		}
	}
	public class RISAuthlevelInsertDataParameters 
	{
		private RISAuthlevel _risauthlevel;
		private SqlParameter[] _parameters;
		public RISAuthlevelInsertDataParameters(RISAuthlevel risauthlevel)
		{
			RISAuthlevel=risauthlevel;
			Build();
		}
		public  RISAuthlevel	RISAuthlevel
		{
			get{return _risauthlevel;}
			set{_risauthlevel=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={new SqlParameter("@AUTH_LEVEL_ID",RISAuthlevel.AUTH_LEVEL_ID),new SqlParameter("@AUTH_LEVEL_UID",RISAuthlevel.AUTH_LEVEL_UID),new SqlParameter("@AUTH_LEVEL_DESC",RISAuthlevel.AUTH_LEVEL_DESC),new SqlParameter("@AUTH_LEVEL_SL",RISAuthlevel.AUTH_LEVEL_SL),new SqlParameter("@AUTH_LEVEL_TEXT",RISAuthlevel.AUTH_LEVEL_TEXT)
			,new SqlParameter("@ORG_ID",RISAuthlevel.ORG_ID),new SqlParameter("@CREATED_BY",RISAuthlevel.CREATED_BY),new SqlParameter("@CREATED_ON",RISAuthlevel.CREATED_ON),new SqlParameter("@LAST_MODIFIED_BY",RISAuthlevel.LAST_MODIFIED_BY),new SqlParameter("@LAST_MODIFIED_ON",RISAuthlevel.LAST_MODIFIED_ON)};
			Parameters = parameters;
		}
	}
}

