using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISOrderDtlDeleteData : DataAccessBase
    {
        public RIS_ORDERDTL RIS_ORDERDTL { get; set; }

        public RISOrderDtlDeleteData()
        {
            RIS_ORDERDTL = new RIS_ORDERDTL();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERDTL_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@ORDER_ID",RIS_ORDERDTL.ORDER_ID),
            Parameter("@EXAM_ID",RIS_ORDERDTL.EXAM_ID),
                                     };
            return parameters;
        }
    }
}