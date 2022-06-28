//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    03/04/2009 05:03:16
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class GBLRadexperienceUpdateData : DataAccessBase 
	{
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; }

		public  GBLRadexperienceUpdateData()
		{
            GBL_RADEXPERIENCE = new GBL_RADEXPERIENCE();
			StoredProcedureName = StoredProcedure.Prc_GBL_RADEXPERIENCE_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        public void UpdateGridWorklist(int RadID, string XMLGridWL)
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_RADEXPERIENCE_Update_GridWL;
            DbParameter[] parameters ={
				Parameter("@RADIOLOGIST_ID", RadID),
                Parameter("@WORKLIST_GRID_ORDER", XMLGridWL)
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        public void UpdateGridHistory(int RadID, string XMLGridHistory)
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_RADEXPERIENCE_Update_GridHistory;
            DbParameter[] parameters =
		    {
				Parameter("@RADIOLOGIST_ID", RadID),
                Parameter("@HISTORY_GRID_ORDER", XMLGridHistory)
		    };

            ParameterList = parameters;
            ExecuteNonQuery();
        }
		public bool Update(DbTransaction tran) 
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@RADIOLOGIST_ID",GBL_RADEXPERIENCE.RADIOLOGIST_ID)
,Parameter("@AUTO_REFRESH_WL_SEC",GBL_RADEXPERIENCE.AUTO_REFRESH_WL_SEC)
,Parameter("@DASHBOARD_DEF_SEARCH",GBL_RADEXPERIENCE.DASHBOARD_DEF_SEARCH)
,Parameter("@LOAD_FINALIZED_EXAMS",GBL_RADEXPERIENCE.LOAD_FINALIZED_EXAMS)
,Parameter("@ALL_EXAM_VISIBLE",GBL_RADEXPERIENCE.ALL_EXAM_VISIBLE)
,Parameter("@LOAD_ALL_EXAM",GBL_RADEXPERIENCE.LOAD_ALL_EXAM)
,Parameter("@AUTO_START_ORDER_IMG",GBL_RADEXPERIENCE.AUTO_START_ORDER_IMG)
,Parameter("@AUTO_START_PACS_IMG",GBL_RADEXPERIENCE.AUTO_START_PACS_IMG)
,Parameter("@DEF_DATE_RANGE",GBL_RADEXPERIENCE.DEF_DATE_RANGE)
,Parameter("@REMEMBER_GRID_ORDER",GBL_RADEXPERIENCE.REMEMBER_GRID_ORDER)
,Parameter("@GRID_DBL_CLICK_TO",GBL_RADEXPERIENCE.GRID_DBL_CLICK_TO)
,Parameter("@FINISH_WRITING_REFER_TO",GBL_RADEXPERIENCE.FINISH_WRITING_REFER_TO)
,Parameter("@ALLOW_OTHERSTO_FINALIZE",GBL_RADEXPERIENCE.ALLOW_OTHERSTO_FINALIZE)
,Parameter("@FONT_FACE",GBL_RADEXPERIENCE.FONT_FACE)
,Parameter("@FONT_SIZE",GBL_RADEXPERIENCE.FONT_SIZE)
,Parameter("@SIGNATURE_TEXT",GBL_RADEXPERIENCE.SIGNATURE_TEXT)
,Parameter("@SIGNATURE_SCAN",GBL_RADEXPERIENCE.Picture_Forsave)
,Parameter("@USED_SIGNATURE",GBL_RADEXPERIENCE.USED_SIGNATURE)
,Parameter("@WHEN_GROUP_SIGN_USE",GBL_RADEXPERIENCE.WHEN_GROUP_SIGN_USE)
,Parameter("@ORG_ID",GBL_RADEXPERIENCE.ORG_ID)
,Parameter("@LAST_MODIFIED_BY",GBL_RADEXPERIENCE.LAST_MODIFIED_BY)
,Parameter("@SIGNATURE_RTF",GBL_RADEXPERIENCE.SIGNATURE_RTF)
,Parameter("@SIGNATURE_HTML",GBL_RADEXPERIENCE.SIGNATURE_HTML)
,Parameter("@MINIMIZE_CHARACTER",GBL_RADEXPERIENCE.MINIMIZE_CHARACTER)
,Parameter("@USED_MENUBAR",GBL_RADEXPERIENCE.USED_MENUBAR)
,Parameter("@USED_120DPI",GBL_RADEXPERIENCE.USED_120DPI)
,Parameter("@RECONFIRM_PASS_ON_SAVE",GBL_RADEXPERIENCE.RECONFIRM_PASS_ON_SAVE)
,Parameter("@IS_ADDENDUM",GBL_RADEXPERIENCE.IS_ADDENDUM)
,Parameter("@ZOOM_SETTING",GBL_RADEXPERIENCE.ZOOM_SETTING)
,Parameter("@AUTO_EXAMNAME",GBL_RADEXPERIENCE.AUTO_EXAMNAME) 
,Parameter("@AUTO_CLINICALINDICATION",GBL_RADEXPERIENCE.AUTO_CLINICALINDICATION)
,Parameter("@OPEN_PACS_WHEN_MERGE",GBL_RADEXPERIENCE.OPEN_PACS_WHEN_MERGE) 
                                      };
            return parameters;
        }
	}
}

