using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class MGBreastUSMassDetailSelect : DataAccessBase
    {
        public MG_BREASTUSMASSDETAILS MG_BREASTUSMASSDETAILS { get; set; }

        public MGBreastUSMassDetailSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTUSMASSDETAILS_SELECT;
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
                                            Parameter("@ACCESSION_NO", MG_BREASTUSMASSDETAILS.ACCESSION_NO),
                                            Parameter("@ORG_ID", MG_BREASTUSMASSDETAILS.ORG_ID)
                                       };
            return parameters;
        }
    }
}
