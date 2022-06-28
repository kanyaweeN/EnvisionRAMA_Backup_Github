using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class RisPrStudiesUpdate : DataAccessBase
    {
        public RIS_PRSTUDIES RIS_PRSTUDIES { get; set; }

        public RisPrStudiesUpdate()
        {
            RIS_PRSTUDIES = new RIS_PRSTUDIES();
        }

        public void Update()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRSTUDIES_Update;
            ParameterList = buildParameterForUpdate();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameterForUpdate()
        {
            DbParameter[] parameters ={
                Parameter( "@STUDY_ID"	                    , RIS_PRSTUDIES.STUDY_ID ) ,
                Parameter( "@RAD_OPINION"	                , RIS_PRSTUDIES.RAD_OPINION ) ,
                Parameter( "@IS_CLINICALLY_SIGNIFICANT"	    , RIS_PRSTUDIES.IS_CLINICALLY_SIGNIFICANT ) ,
                Parameter( "@RAD_COMMENTS"	                , RIS_PRSTUDIES.RAD_COMMENTS ) ,
                Parameter( "@PR_STATUS"	                    , RIS_PRSTUDIES.PR_STATUS ) ,
                Parameter( "@REPORT_LANG_ID"	            , RIS_PRSTUDIES.REPORT_LANG_ID ) ,
                Parameter( "@REPORT_LANG_COMMENTS"	        , RIS_PRSTUDIES.REPORT_LANG_COMMENTS ) ,
                Parameter( "@ORG_ID"	                    , RIS_PRSTUDIES.ORG_ID ) ,
                Parameter( "@LAST_MODIFIED_BY"	            , RIS_PRSTUDIES.LAST_MODIFIED_BY ) ,
            };
            return parameters;
        }
    }
}
