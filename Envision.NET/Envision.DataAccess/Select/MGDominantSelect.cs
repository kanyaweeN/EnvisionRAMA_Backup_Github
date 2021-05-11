using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class MGDominantSelect : DataAccessBase
    {
        public MG_DOMINANT MG_DOMINANT { get; set; }

        public MGDominantSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_DOMINANT_Select;
        }

        public DataSet GetData()
        {
            DataSet ds = null;
            this.ParameterList = this.BuildParameters();
            ds = this.ExecuteDataSet();
            return ds;
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
