using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISSF09InsertData : DataAccessBase
    {
        public RISSF09Data RISSF09Data { get; set; }

        public RISSF09InsertData()
        {
            RISSF09Data = new RISSF09Data();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF09_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter( "@EXAM_TYPE_UID"	        , RISSF09Data.EXAM_TYPE_UID ) ,
				                        Parameter( "@EXAM_TYPE_TEXT"        , RISSF09Data.EXAM_TYPE_TEXT ) ,
				                        Parameter( "@IsActive"	    , RISSF09Data.IS_ACTIVE ) ,
				                        Parameter( "@OrgID"	                , RISSF09Data.ORG_ID ) ,
				                        Parameter( "@CreatedBy"		        , RISSF09Data.CREATED_BY ) 
                                      };
            return parameters;
        }
    }
}
