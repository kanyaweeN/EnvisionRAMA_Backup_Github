using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISSF09UpdateData : DataAccessBase
    {
        public RISSF09Data RISSF09Data { get; set; }

        public RISSF09UpdateData()
        {
            RISSF09Data = new RISSF09Data();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF09_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@EXAM_TYPE_ID"	, RISSF09Data.EXAM_TYPE_ID ) ,
				Parameter( "@EXAM_TYPE_UID"	, RISSF09Data.EXAM_TYPE_UID  ) ,
				Parameter( "@EXAM_TYPE_TEXT"        , RISSF09Data.EXAM_TYPE_TEXT  ) ,
				Parameter( "@IsActive"	, RISSF09Data.IS_ACTIVE ) ,
				Parameter( "@OrgID"	    , RISSF09Data.ORG_ID ) ,
				Parameter( "@LAST_MODIFIED_BY"		, RISSF09Data.LASTMODIFIED_BY ) ,
                                      };
            return parameters;
        }
    }
}
