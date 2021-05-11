using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnvisionOnline.Common;
using System.Data;
using System.Data.Common;

namespace EnvisionOnline.DataAccess.Select
{
    public class ResultEntryHNSelectData: DataAccessBase
    {
        public ResultEntryWorkList ResultEntryWorkList { get; set; }
        public ResultEntryHNSelectData()
        {
            ResultEntryWorkList = new ResultEntryWorkList();
            StoredProcedureName = StoredProcedure.Prc_ResultEntryHistory;
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
                                          	Parameter( "@SP_TYPE"	, ResultEntryWorkList.SpType ),
                                            Parameter( "@FROM_DT"        , ResultEntryWorkList.FromDate ),
                                            Parameter( "@TO_DATE"        , ResultEntryWorkList.ToDate),
				                            Parameter( "@ORG_ID"        , ResultEntryWorkList.OrgID),
                                            Parameter( "@HN"        , ResultEntryWorkList.PatientID)
                                       };
            return parameters;
        }
    }
}
