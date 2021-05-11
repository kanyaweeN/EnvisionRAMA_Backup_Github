using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Insert
{
    public class RisPrAlgorithmInsert : DataAccessBase
    {
        public RIS_PRALGORITHM RIS_PRALGORITHM { get; set; }

        public RisPrAlgorithmInsert()
        {
            RIS_PRALGORITHM = new RIS_PRALGORITHM();
        }

        public int Add()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRALGORITHM_Insert;
            ParameterList = buildParameter();
            return Convert.ToInt32(ExecuteScalar().ToString());
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@ALGORITHM_TEXT"	, RIS_PRALGORITHM.ALGORITHM_TEXT ) ,
                Parameter( "@LOGIC"	            , RIS_PRALGORITHM.LOGIC ) ,
                Parameter( "@ORG_ID"	        , RIS_PRALGORITHM.ORG_ID ) ,
                Parameter( "@CREATED_BY"	    , RIS_PRALGORITHM.CREATED_BY ) ,
            };
            return parameters;
        }
    }
}
