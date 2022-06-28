using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class HistorySelectData : DataAccessBase
    {
        public ResultEntryWorkList ResultEntryWorkList { get; set; }

        public HistorySelectData()
        {
            StoredProcedureName = StoredProcedure.Prc_ResultEntryHistory;
            ResultEntryWorkList = new ResultEntryWorkList();
        }

        public DataSet Get()
        {
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;

        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                    Parameter( "@SP_TYPE"	    , ResultEntryWorkList.SpType ),
                                                    Parameter( "@FROM_DT"       , ResultEntryWorkList.FromDate ),
                                                    Parameter( "@TO_DATE"       , ResultEntryWorkList.ToDate),
				                                    Parameter( "@ORG_ID"        , ResultEntryWorkList.OrgID),
                                                    Parameter( "@HN"            , ResultEntryWorkList.PatientID)
                                       };
            return parameters;
        }
    }
}
