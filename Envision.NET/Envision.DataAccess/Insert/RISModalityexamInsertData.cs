//---------------------------------------------------------------------------------------------
//         Use program generate this file from database.
//---------------------------------------------------------------------------------------------
//         Author     :    fadel cheteng
//         Email      :    fadelc99@hotmail.com 
//         Generate   :    03/04/2008
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISModalityexamInsertData : DataAccessBase 
	{
        public RIS_MODALITYEXAM RIS_MODALITYEXAM { get; set; }
		public  RISModalityexamInsertData()
		{
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
			StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void AddOnline()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_MODALITYEXAM_ONL_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter createOn = Parameter();
            createOn.ParameterName = "@CREATED_ON";
            if (RIS_MODALITYEXAM.CREATED_ON == null)
                createOn.Value = DBNull.Value;
            else
                createOn.Value = RIS_MODALITYEXAM.CREATED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_MODALITYEXAM.CREATED_ON;

            DbParameter modifyOn = Parameter();
            modifyOn.ParameterName = "@LAST_MODIFIED_ON";
            if (RIS_MODALITYEXAM.LAST_MODIFIED_ON == null)
                modifyOn.Value = DBNull.Value;
            else
                modifyOn.Value = RIS_MODALITYEXAM.LAST_MODIFIED_ON == DateTime.MinValue ? (object)DBNull.Value : RIS_MODALITYEXAM.LAST_MODIFIED_ON;
            
            DbParameter[] parameters ={
                Parameter("@MODALITY_ID",RIS_MODALITYEXAM.MODALITY_ID),
                Parameter("@EXAM_ID",RIS_MODALITYEXAM.EXAM_ID),
                Parameter("@TECH_BYPASS",RIS_MODALITYEXAM.TECH_BYPASS),
                Parameter("@QA_BYPASS",RIS_MODALITYEXAM.QA_BYPASS),
                Parameter("@IS_ACTIVE",RIS_MODALITYEXAM.IS_ACTIVE),
                Parameter("@IS_DEFAULT_MODALITY",RIS_MODALITYEXAM.IS_DEFAULT_MODALITY),
                Parameter("@IS_UPDATED",RIS_MODALITYEXAM.IS_UPDATED),
                Parameter("@IS_DELETED",RIS_MODALITYEXAM.IS_DELETED),
                Parameter("@ORG_ID",RIS_MODALITYEXAM.ORG_ID),
                Parameter("@CREATED_BY",RIS_MODALITYEXAM.CREATED_BY),
                createOn,
                Parameter("@LAST_MODIFIED_BY",RIS_MODALITYEXAM.LAST_MODIFIED_BY),
                modifyOn
			};
            return parameters;
        }
	}
}

