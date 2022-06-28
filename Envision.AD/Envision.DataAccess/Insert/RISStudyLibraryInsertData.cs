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
	public class RISStudyLibraryInsertData : DataAccessBase 
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }       
        public RISStudyLibraryInsertData()
		{
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
			StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARY_Insert;
		}
		public DataSet Add()
		{
            ParameterList = buildParameter();
            DataSet ds = ExecuteDataSet();
            return ds;
		}

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@RADIOLOGIST_ID",RIS_STUDYLIBRARY.RADIOLOGIST_ID),
                Parameter("@ACCESSION_NO",RIS_STUDYLIBRARY.ACCESSION_NO),
                Parameter("@IS_FAVOURITE",RIS_STUDYLIBRARY.IS_FAVOURITE),
                Parameter("@IS_TEACHING",RIS_STUDYLIBRARY.IS_TEACHING),
                Parameter("@IS_RESEARCH",RIS_STUDYLIBRARY.IS_RESEARCH),
                Parameter("@IS_OTHERS",RIS_STUDYLIBRARY.IS_OTHERS),
                Parameter("@TAGS",RIS_STUDYLIBRARY.TAGS),
                Parameter("@DIFFICULTY_LEVEL",RIS_STUDYLIBRARY.DIFFICULTY_LEVEL),
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID),
                Parameter("@CREATED_BY", new GBLEnvVariable().UserID),
                Parameter("@SUMMARY_ACR",RIS_STUDYLIBRARY.SUMMARY_ACR),
                Parameter("@SUMMARY_BODYPART",RIS_STUDYLIBRARY.SUMMARY_BODYPART),
                Parameter("@SUMMARY_CPT",RIS_STUDYLIBRARY.SUMMARY_CPT),
                Parameter("@SUMMARY_ICD",RIS_STUDYLIBRARY.SUMMARY_ICD),
                Parameter("@SUMMARY_SHARED_WITH",RIS_STUDYLIBRARY.SUMMARY_SHARED_WITH),
                Parameter("@SHARE_TYPE",RIS_STUDYLIBRARY.SHARE_TYPE),
			};
            return parameters;
        }
	}
}

