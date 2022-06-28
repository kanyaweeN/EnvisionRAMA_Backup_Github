using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class ResultEntyWorkListSelectData : DataAccessBase
    {
        public ResultEntryWorkList ResultEntryWorkList{get;set;}

        public ResultEntyWorkListSelectData()
        {
            ResultEntryWorkList=new ResultEntryWorkList();
            StoredProcedureName = StoredProcedure.Prc_ResultEntryWorklist;
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
                                                    Parameter( "@SP_Types"	            , ResultEntryWorkList.SpType ),
                                                    Parameter( "@ASSIGNED_TO"		    , ResultEntryWorkList.AssignedTo ) ,
				                                    Parameter( "@FROM_DT"               , ResultEntryWorkList.FromDate ),
                                                    Parameter( "@TO_DATE"               , ResultEntryWorkList.ToDate),
				                                    Parameter( "@ORG_ID"                , ResultEntryWorkList.OrgID),
                                                    Parameter( "@HN"                    , ResultEntryWorkList.PatientID)
                                       };
            return parameters;
        }
     
    }
}
