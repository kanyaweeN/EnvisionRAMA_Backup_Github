using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;

namespace Envision.DataAccess.Update
{
    public class SrTemplatePartUpdate : DataAccessBase
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }

        public SrTemplatePartUpdate()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEPART_Update;
        }

        public void UpdateData()
        {
            this.ParameterList = this.BuildParameters();
            this.ExecuteNonQuery();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                            Parameter("@PART_ID", SR_TEMPLATEPART.PART_ID),
                                            Parameter("@PART_NAME", SR_TEMPLATEPART.PART_NAME),
                                            Parameter("@SL", SR_TEMPLATEPART.SL),
                                            Parameter("@ORG_ID", SR_TEMPLATEPART.ORG_ID),
                                            Parameter("@LAST_MODIFIED_BY", SR_TEMPLATEPART.LAST_MODIFIED_BY),
                                       };
            return parameters;
        }
    }
}
