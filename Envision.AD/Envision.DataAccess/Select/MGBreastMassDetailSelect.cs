using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class MGBreastMassDetailSelect : DataAccessBase
    {
        public MG_BREASTMASSDETAILS MG_BREASTMASSDETAILS { get; set; }

        public MGBreastMassDetailSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMASSDETAILS_SELECT;
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
                                            Parameter("@ACCESSION_NO", MG_BREASTMASSDETAILS.ACCESSION_NO),
                                            Parameter("@ORG_ID", MG_BREASTMASSDETAILS.ORG_ID)
                                       };
            return parameters;
        }
    }
}
