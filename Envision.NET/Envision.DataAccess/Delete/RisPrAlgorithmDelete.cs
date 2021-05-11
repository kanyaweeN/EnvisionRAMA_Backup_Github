using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RisPrAlgorithmDelete : DataAccessBase
    {
        public RIS_PRALGORITHM RIS_PRALGORITHM { get; set; }

        public RisPrAlgorithmDelete()
        {
            RIS_PRALGORITHM = new RIS_PRALGORITHM();
        }

        public void Delete()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRALGORITHM_Delete;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }


        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@ALGORITHM_ID"	, RIS_PRALGORITHM.ALGORITHM_ID ) ,
            };
            return parameters;
        }
    }
}
