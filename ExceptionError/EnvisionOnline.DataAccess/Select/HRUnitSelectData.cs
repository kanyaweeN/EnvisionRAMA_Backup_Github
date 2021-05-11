using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class HRUnitSelectData : DataAccessBase
    {
        public HR_UNIT HR_UNIT { get; set; }
        public HRUnitSelectData()
        {
            HR_UNIT = new HR_UNIT();
            StoredProcedureName = StoredProcedure.Prc_HR_UNIT_Select;
        }
        public HRUnitSelectData(bool is_online)
        {
            HR_UNIT = new HR_UNIT();
            StoredProcedureName = StoredProcedure.Prc_ONLHR_UNIT_Select;
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
                                          //Parameter("@ORG_ID",HR_UNIT.ORG_ID),
                                       };
            return parameters;
        }
    }
}
