using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class SRTemplatePartInsert : DataAccessBase
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }

        public SRTemplatePartInsert()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEPART_Insert;
        }
        public void InsertData()
        {
            this.ParameterList = this.BuildParameters();
            DataTable dtt = this.ExecuteDataTable();
            if (dtt.Rows.Count > 0)
            {
                this.SR_TEMPLATEPART.PART_ID = Convert.ToInt32(dtt.Rows[0][0].ToString());
            }
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameters = { 
                                           Parameter("@PART_NAME", this.SR_TEMPLATEPART.PART_NAME),
                                           Parameter("@TEMPLATE_ID", this.SR_TEMPLATEPART.TEMPLATE_ID),
                                           Parameter("@SL", this.SR_TEMPLATEPART.SL),
                                           Parameter("@ORG_ID", this.SR_TEMPLATEPART.ORG_ID),
                                           Parameter("@CREATED_BY", this.SR_TEMPLATEPART.CREATED_BY),
                                       };
            return parameters;
        }
    }
}
