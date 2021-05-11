using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.Common.Linq;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Select
{
    public class MGBreastMarkTemplateSelect : DataAccessBase
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }

        public MGBreastMarkTemplateSelect()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARKTEMPLATE_Select;
        }

        public DataSet GetData()
        {
            this.ParameterList = this.BuildParameters();
            return this.ExecuteDataSet();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                          Parameter("@EMP_ID", MG_BREASTMARKTEMPLATE.EMP_ID),
                                          Parameter("@ORG_ID", MG_BREASTMARKTEMPLATE.ORG_ID)
                                       };
            return parameters;
        }
    }
}
