using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class SR_QUESTIONSDTLDeleteData : DataAccessBase
    {
        public SR_QUESTIONSDTL SR_QUESTIONSDTL { get; set; }

        public SR_QUESTIONSDTLDeleteData() {
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTL_Delete;
            SR_QUESTIONSDTL = new SR_QUESTIONSDTL();
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@Q_ID_DTL",SR_QUESTIONSDTL.Q_ID_DTL)
                                     };
            return parameters;
        }
    }
}
