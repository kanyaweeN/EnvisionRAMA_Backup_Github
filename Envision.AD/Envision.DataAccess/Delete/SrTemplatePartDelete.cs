using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Delete
{
    public class SrTemplatePartDelete : DataAccessBase
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }
        public SrTemplatePartDelete()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEPART_Delete;
        }
        public void DeleteData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@PART_ID", SR_TEMPLATEPART.PART_ID),
                                            Parameter("@ORG_ID", SR_TEMPLATEPART.ORG_ID),
                                       };
            return parameters;
        }
    }
}
