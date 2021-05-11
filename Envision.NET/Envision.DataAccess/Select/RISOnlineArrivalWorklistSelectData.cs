using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
    public class RISOnlineArrivalWorklistSelectData : DataAccessBase 
    {
        private OnlineArrivalWorklist _onlinearrivalworklist;
        public RISOnlineArrivalWorklistSelectData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_OnlineArrivalWorlist;
		}
        public OnlineArrivalWorklist OnlineArrivalWorklist
		{
            get { return _onlinearrivalworklist; }
            set { _onlinearrivalworklist = value; }
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
            DbParameter[] parameters ={			
                   Parameter("@SELECTCASE",OnlineArrivalWorklist.SELECTCASE),
                   Parameter("@HN",OnlineArrivalWorklist.HN),
                   Parameter("@ORDER_ID",OnlineArrivalWorklist.ORDER_ID),
                   Parameter("@ACCESSION_NO",OnlineArrivalWorklist.ACCESSION_NO),
                   Parameter("@EXAM_ID",OnlineArrivalWorklist.EXAM_ID)
			};
            return parameters;
        }
	}
}
