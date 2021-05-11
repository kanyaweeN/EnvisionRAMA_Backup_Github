/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data;
using System.Data.SqlClient;
using RIS.Common.Common;


namespace RIS.DataAccess.Select
{
    public class HistorySelectData : DataAccessBase
    {
        private ResultEntryWorkList _worklist;
        private HistorySelectDataParameters _worklistselectdataparameters;

        public HistorySelectData()
        {
            StoredProcedureName = StoredProcedure.Name.Prc_ResultEntryHistory.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            _worklistselectdataparameters = new HistorySelectDataParameters(ResultEntryWorkList);
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            ds = dbhelper.Run(base.ConnectionString, _worklistselectdataparameters.Parameters);
            return ds;

        }

        public ResultEntryWorkList ResultEntryWorkList
        {
            get { return _worklist; }
            set { _worklist = value; }
        }
    }

    public class HistorySelectDataParameters
    {
        private ResultEntryWorkList _worklist;
        private SqlParameter[] _parameters;

        public HistorySelectDataParameters(ResultEntryWorkList worklist)
        {
            ResultEntryWorkList = worklist;
            Build();
        }

        private void Build()
        {


            SqlParameter[] parameters =
		    {
                
				new SqlParameter( "@SP_Types"	, ResultEntryWorkList.SpType ),
                new SqlParameter( "@FROM_DT"        , ResultEntryWorkList.FromDate ),
                new SqlParameter( "@TO_DATE"        , ResultEntryWorkList.ToDate),
				new SqlParameter( "@ORG_ID"        , ResultEntryWorkList.OrgID),
                new SqlParameter( "@HN"        , ResultEntryWorkList.PatientID)
				
		    };

            Parameters = parameters;
        }

        public ResultEntryWorkList ResultEntryWorkList
        {
            get { return _worklist; }
            set { _worklist = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
