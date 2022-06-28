using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class MGDominantDelete : DataAccessBase
    {
        public MG_DOMINANT MG_DOMINANT { get; set; }

        public MGDominantDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_DOMINANT_Delete;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("ACCESSION_NO", MG_DOMINANT.ACCESSION_NO),
                                           Parameter("ORG_ID", MG_DOMINANT.ORG_ID)
                                       };

            return parameters;
        }
    }
}
