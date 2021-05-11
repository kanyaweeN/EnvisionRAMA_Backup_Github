using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class MGGetDemographic : DataAccessBase
    {
        public MGGetDemographic()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_GetDemographic;
        }

        public DataSet GetData(string AccessionNo)
        {
            DataSet ds = null;
            ParameterList = this.BuildParameters(AccessionNo);
            ds = this.ExecuteDataSet();
            return ds;
        }

        private DbParameter[] BuildParameters(string AccessionNo)
        {
            DbParameter[] parameters = { 
                                            Parameter("@ACCESSION_NO", AccessionNo)
                                       };
            return parameters;
        }
    }
}
