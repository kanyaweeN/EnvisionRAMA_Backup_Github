using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class SR_TEMPLATEPARTDeleteData : DataAccessBase
    {
        public SR_TEMPLATEPART SR_TEMPLATEPART { get; set; }

        public SR_TEMPLATEPARTDeleteData() {
            SR_TEMPLATEPART = new SR_TEMPLATEPART();
            StoredProcedureName = StoredProcedure.Prc_SR_TEMPLATEPART_Delete;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@PART_ID",SR_TEMPLATEPART.PART_ID)
                                     };
            return parameters;
        }
    }
}
