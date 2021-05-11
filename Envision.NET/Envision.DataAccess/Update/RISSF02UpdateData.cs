using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISSF02UpdateData : DataAccessBase
    {
        public RISSF02Data RISSF02Data { get; set; }

        public RISSF02UpdateData()
        {
            RISSF02Data = new RISSF02Data();
            StoredProcedureName = StoredProcedure.PRC_RIS_SF02_Update;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
				Parameter( "@ICD_ID"	, RISSF02Data.ICD_ID) ,
				Parameter( "@ICD_UID"	, RISSF02Data.ICD_UID ) ,
				Parameter( "@ICD_DESC"        , RISSF02Data.ICD_DESC ) ,
				Parameter( "@ICD_VERSION"	, RISSF02Data.ICD_VERSION  ) ,
				Parameter( "@ORG_ID"	    , RISSF02Data.ORG_ID ) ,
				Parameter( "@IS_DELETED"		, RISSF02Data.IS_DELETED ) ,
				Parameter( "@IS_UPDATE"		, RISSF02Data.IS_UPDATE ) ,
				Parameter( "@LASTMODIFIED_BY"		, RISSF02Data.LASTMODIFIED_BY ) ,
                                      };
            return parameters;
        }
    }
}
