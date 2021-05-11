using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using EnvisionOnline.Common.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class RISBpviewMappingSelectData : DataAccessBase
    {

        public RISBpviewMappingSelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEWMAPPING_SelectNew;
        }

        public DataSet GetData(int exam_id)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(exam_id);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(int exam_id)
        {
            DbParameter[] parameters = { 
                                          Parameter("@EXAM_ID",exam_id),
                                       };
            return parameters;
        }
    }
}
