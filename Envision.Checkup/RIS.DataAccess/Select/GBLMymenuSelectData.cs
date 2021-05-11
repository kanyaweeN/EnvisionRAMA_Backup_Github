//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    06/08/2552 04:53:43
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
	public class GBLMymenuSelectData : DataAccessBase 
	{
		private GBLMymenu	_gblmymenu;
		private GBLMymenuSelectDataParameters param;
		public  GBLMymenuSelectData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_GBL_Favourite_Select.ToString();
		}
		public  GBLMymenu	GBLMymenu
		{
			get{return _gblmymenu;}
			set{_gblmymenu=value;}
		}
		public DataSet GetData()
		{
			param = new GBLMymenuSelectDataParameters(GBLMymenu);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class GBLMymenuSelectDataParameters 
	{
		private GBLMymenu _gblmymenu;
		private SqlParameter[] _parameters;
		public GBLMymenuSelectDataParameters(GBLMymenu gblmymenu)
		{
			GBLMymenu=gblmymenu;
			Build();
		}
		public  GBLMymenu	GBLMymenu
		{
			get{return _gblmymenu;}
			set{_gblmymenu=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
//new SqlParameter("@MYMENU_ID",GBLMymenu.MYMENU_ID)
//,new SqlParameter("@MYMENU_UID",GBLMymenu.MYMENU_UID)
new SqlParameter("@EMP_ID",GBLMymenu.EMP_ID)
//,new SqlParameter("@SL_NO",GBLMymenu.SL_NO)
//,new SqlParameter("@SUBMENU_ID",GBLMymenu.SUBMENU_ID)
			
//,new SqlParameter("@ORG_ID",GBLMymenu.ORG_ID)
//,new SqlParameter("@IS_ACTIVE",GBLMymenu.IS_ACTIVE)
//,new SqlParameter("@CREATED_BY",GBLMymenu.CREATED_BY)
//,new SqlParameter("@CREATED_ON",GBLMymenu.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",GBLMymenu.LAST_MODIFIED_BY)
			
//,new SqlParameter("@LAST_MODIFIED_ON",GBLMymenu.LAST_MODIFIED_ON)
			};
			_parameters=parameters;
		}
	}
}

