//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:15
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
	public class GBLRadexperienceSelectData : DataAccessBase 
	{
		private GBLRadexperience	_gblradexperience;
		private GBLRadexperienceSelectDataParameters param;
		public  GBLRadexperienceSelectData()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_RADEXPERIENCE_Select.ToString();
		}
		public  GBLRadexperience	GBLRadexperience
		{
			get{return _gblradexperience;}
			set{_gblradexperience=value;}
		}
		public DataSet GetData()
		{
			param = new GBLRadexperienceSelectDataParameters(GBLRadexperience);
			DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
			DataSet ds = dbhelper.Run(base.ConnectionString,param.Parameters);
			return ds;
		}
	}
	public class GBLRadexperienceSelectDataParameters 
	{
		private GBLRadexperience _gblradexperience;
		private SqlParameter[] _parameters;
		public GBLRadexperienceSelectDataParameters(GBLRadexperience gblradexperience)
		{
			GBLRadexperience=gblradexperience;
			Build();
		}
		public  GBLRadexperience	GBLRadexperience
		{
			get{return _gblradexperience;}
			set{_gblradexperience=value;}
		}
		public  SqlParameter[] Parameters
		{
			get{return _parameters;}
			set{_parameters=value;}
		}
		public void Build()
		{
			SqlParameter[] parameters ={			
new SqlParameter("@RADIOLOGIST_ID",GBLRadexperience.RADIOLOGIST_ID)
//,new SqlParameter("@AUTO_REFRESH_WL_SEC",GBLRadexperience.AUTO_REFRESH_WL_SEC)
//,new SqlParameter("@DASHBOARD_DEF_SEARCH",GBLRadexperience.DASHBOARD_DEF_SEARCH)
//,new SqlParameter("@LOAD_FINALIZED_EXAMS",GBLRadexperience.LOAD_FINALIZED_EXAMS)
//,new SqlParameter("@ALL_EXAM_VISIBLE",GBLRadexperience.ALL_EXAM_VISIBLE)
			
//,new SqlParameter("@LOAD_ALL_EXAM",GBLRadexperience.LOAD_ALL_EXAM)
//,new SqlParameter("@AUTO_START_ORDER_IMG",GBLRadexperience.AUTO_START_ORDER_IMG)
//,new SqlParameter("@AUTO_START_PACS_IMG",GBLRadexperience.AUTO_START_PACS_IMG)
//,new SqlParameter("@DEF_DATE_RANGE",GBLRadexperience.DEF_DATE_RANGE)
//,new SqlParameter("@REMEMBER_GRID_ORDER",GBLRadexperience.REMEMBER_GRID_ORDER)
			
//,new SqlParameter("@GRID_DBL_CLICK_TO",GBLRadexperience.GRID_DBL_CLICK_TO)
//,new SqlParameter("@FINISH_WRITING_REFER_TO",GBLRadexperience.FINISH_WRITING_REFER_TO)
//,new SqlParameter("@ALLOW_OTHERSTO_FINALIZE",GBLRadexperience.ALLOW_OTHERSTO_FINALIZE)
//,new SqlParameter("@FONT_FACE",GBLRadexperience.FONT_FACE)
//,new SqlParameter("@FONT_SIZE",GBLRadexperience.FONT_SIZE)
			
//,new SqlParameter("@SIGNATURE_TEXT",GBLRadexperience.SIGNATURE_TEXT)
//,new SqlParameter("@SIGNATURE_SCAN",GBLRadexperience.SIGNATURE_SCAN)
//,new SqlParameter("@USED_SIGNATURE",GBLRadexperience.USED_SIGNATURE)
//,new SqlParameter("@WHEN_GROUP_SIGN_USE",GBLRadexperience.WHEN_GROUP_SIGN_USE)
//,new SqlParameter("@ORG_ID",GBLRadexperience.ORG_ID)
			
//,new SqlParameter("@CREATED_BY",GBLRadexperience.CREATED_BY)
//,new SqlParameter("@CREATED_ON",GBLRadexperience.CREATED_ON)
//,new SqlParameter("@LAST_MODIFIED_BY",GBLRadexperience.LAST_MODIFIED_BY)
//,new SqlParameter("@LAST_MODIFIED_ON",GBLRadexperience.LAST_MODIFIED_ON)
			};
			_parameters=parameters;
		}
	}
}

