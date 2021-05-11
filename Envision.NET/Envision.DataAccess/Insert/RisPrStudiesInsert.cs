using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RisPrStudiesInsert : DataAccessBase
    {
        public RIS_PRSTUDIES RIS_PRSTUDIES { get; set; }

        public RisPrStudiesInsert()
        {
            RIS_PRSTUDIES = new RIS_PRSTUDIES();
        }

        public void Add()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRSTUDIES_Insert;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@ACCESSION_NO"	    , RIS_PRSTUDIES.ACCESSION_NO ) ,
                Parameter( "@ITERATION"	        , RIS_PRSTUDIES.ITERATION ) ,
                Parameter( "@PR_GROUP_ID"	    , RIS_PRSTUDIES.PR_GROUP_ID ) ,
                Parameter( "@PR_ALGORITHM_ID"	, RIS_PRSTUDIES.PR_ALGORITHM_ID ) ,
                Parameter( "@RAD_ID"	        , RIS_PRSTUDIES.RAD_ID ) ,
                Parameter( "@PR_STATUS"	        , RIS_PRSTUDIES.PR_STATUS ) ,
                Parameter( "@ORG_ID"	        , RIS_PRSTUDIES.ORG_ID ) ,
                Parameter( "@CREATED_BY"	    , RIS_PRSTUDIES.CREATED_BY ) ,
            };
            return parameters;
        }
    }
}
