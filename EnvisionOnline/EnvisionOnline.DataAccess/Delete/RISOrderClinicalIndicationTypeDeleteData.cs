using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISOrderClinicalIndicationTypeDeleteData: DataAccessBase
    {

        public RIS_ORDERCLINICALINDICATIONTYPE RIS_ORDERCLINICALINDICATIONTYPE { get; set; }

        public RISOrderClinicalIndicationTypeDeleteData()
        {
            RIS_ORDERCLINICALINDICATIONTYPE = new RIS_ORDERCLINICALINDICATIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERCLINICALINDICATIONTYPE_Delete2;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@ORDER_ID",RIS_ORDERCLINICALINDICATIONTYPE.ORDER_ID),
                                        Parameter("@SCHEDULE_ID",RIS_ORDERCLINICALINDICATIONTYPE.SCHEDULE_ID),
                                     };
            return parameters;
        }
    }
}

