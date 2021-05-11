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
            StoredProcedureName = StoredProcedure.Prc_RIS_BPVIEWMAPPING_Select;
        }

        public DataSet GetData(string exam_uid)
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter(exam_uid);
            ds = ExecuteDataSet();
            return ds;
        }
        private DbParameter[] buildParameter(string exam_uid)
        {
            DbParameter[] parameters = { 
                                          Parameter("@EXAM_UID",exam_uid),
                                       };
            return parameters;
        }
    }
}
