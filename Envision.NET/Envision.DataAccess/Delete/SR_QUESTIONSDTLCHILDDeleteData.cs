using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class SR_QUESTIONSDTLCHILDDeleteData : DataAccessBase
    {
        public SR_QUESTIONSDTLCHILD SR_QUESTIONSDTLCHILD { get; set; }

        public SR_QUESTIONSDTLCHILDDeleteData() {
            SR_QUESTIONSDTLCHILD = new SR_QUESTIONSDTLCHILD();
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTLCHILD_Delete;
        }
        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@Q_ID",SR_QUESTIONSDTLCHILD.Q_ID)
                                     };
            return parameters;
        }

        public void DeleteByPartID(int PartId) {
            DbParameter[] parameters ={Parameter("@PART_ID",PartId)};
            ParameterList = parameters;
            StoredProcedureName = StoredProcedure.Prc_SR_QUESTIONSDTLCHILD_DeleteByPartId;
            ExecuteNonQuery();
        }

    }
}
