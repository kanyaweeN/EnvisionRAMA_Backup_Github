using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class MGDominantInsert : DataAccessBase
    {
        public MG_DOMINANT MG_DOMINANT { get; set; }

        public MGDominantInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_DOMINANT_Insert;
        }

        public void InsertData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("ACCESSION_NO", MG_DOMINANT.ACCESSION_NO),
                                           //Parameter("BREAST_MARKDTL_ID", MG_MASSDOMINANTCYST.BREAST_MARKDTL_ID),
                                           Parameter("MASS_NO", MG_DOMINANT.MASS_NO),
                                           Parameter("DIAMETER", MG_DOMINANT.DIAMETER),
                                           Parameter("CLOCK_LOCATION", MG_DOMINANT.CLOCK_LOCATION),
                                           Parameter("SIDE", MG_DOMINANT.SIDE),
                                           Parameter("IS_DOMINANT_CYST", MG_DOMINANT.IS_DOMINANT_CYST),
                                           Parameter("ORG_ID", MG_DOMINANT.ORG_ID),
                                           Parameter("CREATED_BY", MG_DOMINANT.CREATED_BY)
                                       };
            return parameters;
        }
    }
}
