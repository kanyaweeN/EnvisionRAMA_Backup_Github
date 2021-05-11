using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISOrderClinicalIndicationSelectData: DataAccessBase
    {
        public RIS_ORDERCLINICALINDICATION RIS_ORDERCLINICALINDICATION { get; set; }
        public RISOrderClinicalIndicationSelectData()
        {
            RIS_ORDERCLINICALINDICATION = new RIS_ORDERCLINICALINDICATION();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERCLINICALINDICATION_ONL_Select;
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
                                          Parameter("@ORDER_ID",RIS_ORDERCLINICALINDICATION.ORDER_ID),
                                          Parameter("@SCHEDULE_ID",RIS_ORDERCLINICALINDICATION.SCHEDULE_ID),
                                       };
            return parameters;
        }
        
    }
}
