using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RISStudyLibraryConferenceInsertData: DataAccessBase 
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
        public RISStudyLibraryConferenceInsertData()
		{
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYCONFERENCE_Insert;
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
                Parameter("@CONFERENCE_ID",RIS_STUDYLIBRARY.CONFERENCE_ID),
                Parameter("@CONFERENCE_DATE",RIS_STUDYLIBRARY.CONFERENCE_DATE),
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID),
                Parameter("@CREATED_BY", new GBLEnvVariable().UserID),
			};
            return parameters;
        }
	}
}


