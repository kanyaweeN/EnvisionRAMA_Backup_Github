using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISRejectcapturelogInsertData : DataAccessBase 
    {
        public RIS_REJECTCAPTURELOG RIS_REJECTCAPTURELOG { get; set; }
        public RISRejectcapturelogInsertData()
		{
            RIS_REJECTCAPTURELOG = new RIS_REJECTCAPTURELOG();
            StoredProcedureName = StoredProcedure.Prc_RIS_REJECTCAPTURELOG_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter REASON_ID = Parameter();
            REASON_ID.ParameterName = "@REASON_ID";
            if (RIS_REJECTCAPTURELOG.REASON_ID == 0)
                REASON_ID.Value = DBNull.Value;
            else
                REASON_ID.Value = RIS_REJECTCAPTURELOG.REASON_ID;

            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_REJECTCAPTURELOG.ACCESSION_NO)
                ,Parameter("@REASON_ID",RIS_REJECTCAPTURELOG.REASON_ID)
                ,Parameter("@COMMENTS",RIS_REJECTCAPTURELOG.COMMENTS)
                ,Parameter("@PHONE_CALL_BACK",RIS_REJECTCAPTURELOG.PHONE_CALL_BACK)
                ,Parameter("@SL_NO",RIS_REJECTCAPTURELOG.SL_NO)
                ,Parameter("@CREATED_BY",RIS_REJECTCAPTURELOG.CREATED_BY)
            };
            return parameters;
        }
    }
}
