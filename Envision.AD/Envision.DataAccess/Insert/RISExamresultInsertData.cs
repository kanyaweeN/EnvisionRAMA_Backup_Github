//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    09/04/2552 11:07:09
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISExamresultInsertData : DataAccessBase 
	{
        public RIS_EXAMRESULT RIS_EXAMRESULT { get; set; }
		public  RISExamresultInsertData()
		{
            RIS_EXAMRESULT = new RIS_EXAMRESULT();
		}
		public bool Add()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_Reporting;
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        public bool UpdateServerity()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_UpdateServerity;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_EXAMRESULT.ACCESSION_NO)
                ,Parameter("@SEVERITY_ID",RIS_EXAMRESULT.SEVERITY_ID)
            };
            ExecuteNonQuery();
            return true;
        }
        public bool UpdateServerityLog(string accession_no, int severitylog_id)
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_UpdateServerityLog;

            DbParameter SeverityLog = Parameter();
            SeverityLog.ParameterName = "@SEVERITYLOG_ID";
            if (severitylog_id == null)
                SeverityLog.Value = DBNull.Value;
            else
                SeverityLog.Value = severitylog_id == 0 ? (object)DBNull.Value : severitylog_id;

            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",accession_no)
                ,SeverityLog
            };
            ExecuteNonQuery();
            return true;
        }
        public bool UpdateHtml()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULT_UpdateHtml;
            ParameterList = new DbParameter[]
            {
                Parameter("@ACCESSION_NO",RIS_EXAMRESULT.ACCESSION_NO)
                ,Parameter("@RESULT_TEXT_HTML",RIS_EXAMRESULT.RESULT_TEXT_HTML)
            };
            ExecuteNonQuery();
            return true;
        }
        private DbParameter[] buildParameter()
        {
            DbParameter Severity = Parameter();
            Severity.ParameterName = "@SEVERITY_ID";
            if (RIS_EXAMRESULT.SEVERITY_ID == null)
                Severity.Value = DBNull.Value;
            else
                Severity.Value = RIS_EXAMRESULT.SEVERITY_ID == 0 ? (object)DBNull.Value : RIS_EXAMRESULT.SEVERITY_ID;

            DbParameter reason = Parameter();
            reason.ParameterName = "@REASON";
            if (RIS_EXAMRESULT.REASON == null)
                reason.Value = DBNull.Value;
            else
                reason.Value = RIS_EXAMRESULT.REASON == 0 ? (object)DBNull.Value : RIS_EXAMRESULT.REASON;

            DbParameter[] parameters ={			
                Parameter("@ACCESSION_NO",RIS_EXAMRESULT.ACCESSION_NO)
                ,Parameter("@ORDER_ID",RIS_EXAMRESULT.ORDER_ID)
                ,Parameter("@EXAM_ID",RIS_EXAMRESULT.EXAM_ID)
                ,Parameter("@RESULT_TEXT_HTML",RIS_EXAMRESULT.RESULT_TEXT_HTML)
                ,Parameter("@RESULT_TEXT_PLAIN",RIS_EXAMRESULT.RESULT_TEXT_PLAIN)
                ,Parameter("@RESULT_TEXT_RTF",RIS_EXAMRESULT.RESULT_TEXT_RTF)
                ,Parameter("@RESULT_STATUS",RIS_EXAMRESULT.RESULT_STATUS)
                ,Parameter("@HL7_TEXT",RIS_EXAMRESULT.HL7_TEXT)
                ,Parameter("@HL7_SEND",RIS_EXAMRESULT.HL7_SEND)
                ,Parameter("@ICD_ID",RIS_EXAMRESULT.ICD_ID)
                ,Parameter("@RELEASED_BY",RIS_EXAMRESULT.RELEASED_BY)
                ,Parameter("@FINALIZED_BY",RIS_EXAMRESULT.FINALIZED_BY)
                ,Parameter("@ORG_ID",RIS_EXAMRESULT.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_EXAMRESULT.CREATED_BY)
                ,Parameter("@ASSIGNED_TO",RIS_EXAMRESULT.ASSIGNED_TO)
                ,Severity
                ,reason
			            };
            return parameters;
        }
	}
}

