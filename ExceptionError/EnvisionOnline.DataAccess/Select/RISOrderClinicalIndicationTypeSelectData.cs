using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISOrderClinicalIndicationTypeSelectData: DataAccessBase
    {
        public RIS_ORDERCLINICALINDICATIONTYPE RIS_ORDERCLINICALINDICATIONTYPE { get; set; }
        public RISOrderClinicalIndicationTypeSelectData()
        {
            RIS_ORDERCLINICALINDICATIONTYPE = new RIS_ORDERCLINICALINDICATIONTYPE();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERCLINICALINDICATIONTYPE_ONL_Select;
        }
        public DataSet GetData()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                          Parameter("@ORDER_ID",RIS_ORDERCLINICALINDICATIONTYPE.ORDER_ID),
                                          Parameter("@SCHEDULE_ID",RIS_ORDERCLINICALINDICATIONTYPE.SCHEDULE_ID),
                                       };
            return parameters;
        }
    }
}

