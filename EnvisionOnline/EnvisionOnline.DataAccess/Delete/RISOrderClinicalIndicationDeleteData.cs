using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Delete
{
    public class RISOrderClinicalIndicationDeleteData: DataAccessBase
    {

        public RIS_ORDERCLINICALINDICATION RIS_ORDERCLINICALINDICATION { get; set; }

        public RISOrderClinicalIndicationDeleteData()
        {
            RIS_ORDERCLINICALINDICATION = new RIS_ORDERCLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERCLINICALINDICATION_Delete;
        }

        public void Delete()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                        Parameter("@ORDER_ID",RIS_ORDERCLINICALINDICATION.ORDER_ID),
                                        Parameter("@SCHEDULE_ID",RIS_ORDERCLINICALINDICATION.SCHEDULE_ID),
                                     };
            return parameters;
        }
    }
}
