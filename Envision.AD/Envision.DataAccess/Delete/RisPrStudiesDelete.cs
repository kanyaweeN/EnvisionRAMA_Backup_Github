using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class RisPrStudiesDelete : DataAccessBase
    {
        public RIS_PRSTUDIES RIS_PRSTUDIES { get; set; }

        public RisPrStudiesDelete()
        {
            RIS_PRSTUDIES = new RIS_PRSTUDIES();
        }

        public void Delete()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_PRSTUDIES_Delete;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter( "@PR_GROUP_ID"	    , RIS_PRSTUDIES.PR_GROUP_ID ) ,
                Parameter( "@PR_ALGORITHM_ID"	, RIS_PRSTUDIES.PR_ALGORITHM_ID ) ,
            };
            return parameters;
        }
    }
}