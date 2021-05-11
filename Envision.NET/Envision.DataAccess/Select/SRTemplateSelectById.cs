using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class SRTemplateSelectById : DataAccessBase
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }
        public SRTemplateSelectById()
        {
            this.StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_SelectById;
        }

        public DataSet SelectData()
        {
            this.ParameterList = this.BuildParameters();
            DataSet ds = this.ExecuteDataSet();
            ds.Tables[0].TableName = "TEMPLATE";
            ds.Tables[1].TableName = "TEMPLATE_PART";
            ds.Tables[2].TableName = "QUESTIONS";
            ds.Tables[3].TableName = "QUESTIONDTL";
            ds.Tables[4].TableName = "QUESTIONDTLCHILD";
            return ds.Copy();
        }

        private System.Data.Common.DbParameter[] BuildParameters()
        {
            DbParameter[] parameter = { 
                                            Parameter("@TEMPLATE_ID", SR_TEMPLATE.TEMPLATE_ID),
                                            Parameter("@ORG_ID", SR_TEMPLATE.ORG_ID)
                                      };

            return parameter;
        }
    }
}
