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
    public class RISStudyLibraryTagsInsertData : DataAccessBase 
	{
        public RIS_STUDYLIBRARY RIS_STUDYLIBRARY { get; set; }
        public RISStudyLibraryTagsInsertData()
		{
            RIS_STUDYLIBRARY = new RIS_STUDYLIBRARY();
            StoredProcedureName = StoredProcedure.Prc_RIS_STUDYLIBRARYTAGS_Insert;
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
                Parameter("@TAGS",RIS_STUDYLIBRARY.TAGS),
                Parameter("@ORG_ID",new GBLEnvVariable().OrgID),
                Parameter("@CREATED_BY", new GBLEnvVariable().UserID),
			};
            return parameters;
        }
	}
}

