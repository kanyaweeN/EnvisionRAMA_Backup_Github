using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISSF02InsertData : DataAccessBase
    {
        public RISSF02Data RISSF02Data { get; set; } 

        public RISSF02InsertData()
        {
            RISSF02Data = new RISSF02Data();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF02_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter( "@ICD_UID"	    , RISSF02Data.ICD_UID ) ,
				                        Parameter( "@ICD_DESC"      , RISSF02Data.ICD_DESC ) ,
				                        Parameter( "@ICD_VERSION"	, RISSF02Data.ICD_VERSION ) ,
				                        Parameter( "@IS_UPDATE"	    , RISSF02Data.IS_UPDATE ) ,
				                        Parameter( "@IS_DELETED"	, RISSF02Data.IS_DELETED ), 
				                        Parameter( "@OrgID"	        , RISSF02Data.ORG_ID ) ,
				                        Parameter( "@CreatedBy"		, RISSF02Data.CREATED_BY )
                                      };
            return parameters;
        }
    }
}
