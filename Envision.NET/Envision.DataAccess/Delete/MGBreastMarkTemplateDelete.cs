using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.Common.Linq;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Delete
{
    public class MGBreastMarkTemplateDelete : DataAccessBase
    {
        public MG_BREASTMARKTEMPLATE MG_BREASTMARKTEMPLATE { get; set; }

        public MGBreastMarkTemplateDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_MG_BREASTMARKTEMPLATE_Delete;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = {
                                           Parameter("@TPL_ID", MG_BREASTMARKTEMPLATE.TPL_ID)
                                       };
            return parameters;
        }
    }
}
