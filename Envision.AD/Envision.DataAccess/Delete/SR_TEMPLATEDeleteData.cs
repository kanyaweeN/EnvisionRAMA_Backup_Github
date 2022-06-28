using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class SR_TEMPLATEDeleteData : DataAccessBase
    {
        public SR_TEMPLATE SR_TEMPLATE { get; set; }

        public SR_TEMPLATEDeleteData() {
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATE_Delete;
        }


        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                            Parameter("@TEMPLATE_ID", SR_TEMPLATE.TEMPLATE_ID),
                                            Parameter("@ORG_ID", SR_TEMPLATE.ORG_ID)
                                       };
            return parameters;
        }
    }
}
