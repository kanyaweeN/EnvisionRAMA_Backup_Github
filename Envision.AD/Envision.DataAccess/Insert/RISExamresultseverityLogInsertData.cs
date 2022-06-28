using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data.Common;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class RISExamresultseverityLogInsertData: DataAccessBase 
	{
        public RIS_EXAMRESULTSEVERITY_LOG RIS_EXAMRESULTSEVERITY_LOG { get; set; }
        public RISExamresultseverityLogInsertData()
		{
            RIS_EXAMRESULTSEVERITY_LOG = new RIS_EXAMRESULTSEVERITY_LOG();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTSEVERITYLOG_Insert2;
		}
        public int Add()
        {
            ParameterList = buildParameter();
            DataTable dt = ExecuteDataTable();
            int result = 0;
            if (dt.Rows.Count > 0)
                result = Convert.ToInt32(dt.Rows[0][0]);
            return result;
        }
        private DbParameter[] buildParameter()
        {

            DbParameter pVERBAL_DATETIME = Parameter();
            pVERBAL_DATETIME.ParameterName = "@VERBAL_DATETIME";
            if (RIS_EXAMRESULTSEVERITY_LOG.VERBAL_DATETIME == null)
                pVERBAL_DATETIME.Value = DBNull.Value;
            else
                pVERBAL_DATETIME.Value = RIS_EXAMRESULTSEVERITY_LOG.VERBAL_DATETIME == DateTime.MinValue ? (object)DBNull.Value : RIS_EXAMRESULTSEVERITY_LOG.VERBAL_DATETIME;


            DbParameter[] parameters ={
                    Parameter("@ACCESSION_NO",RIS_EXAMRESULTSEVERITY_LOG.ACCESSION_NO),
                    Parameter("@SEVERITY_ID",RIS_EXAMRESULTSEVERITY_LOG.SEVERITY_ID),
                    pVERBAL_DATETIME,
                    Parameter("@VERBAL_TIME",RIS_EXAMRESULTSEVERITY_LOG.VERBAL_TIME),
                    Parameter("@VERBAL_WITH",RIS_EXAMRESULTSEVERITY_LOG.VERBAL_WITH),
                    Parameter("@VERBAL_WITH_NAME",RIS_EXAMRESULTSEVERITY_LOG.VERBAL_WITH_NAME),
                    Parameter("@ORG_ID",RIS_EXAMRESULTSEVERITY_LOG.ORG_ID),
                    Parameter("@CREATED_BY",RIS_EXAMRESULTSEVERITY_LOG.CREATED_BY),
            };
            return parameters;
        }
	}
}

