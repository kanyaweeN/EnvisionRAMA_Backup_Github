using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class SrTemplateDelete : DataAccessBase
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public SrTemplateDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Delete;
        }

        public void DeleteData()
        {
            this.ParameterList = this.BuildParameter();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter("@TEMPLATE_ID", SR_TEMPLATE.TEMPLATE_ID),
                                            Parameter("@ORG_ID", SR_TEMPLATE.ORG_ID)
                                       };
            return parameters;
        }
    }
}
