using System.Data;
using System.Data.Common;
using Envision.Common;
using System;

namespace Envision.DataAccess.Select
{
    public class RISCommentSystemAlertSelect : DataAccessBase
    {
        public RIS_COMMENTSYSTEMALERT RIS_COMMENTSYSTEMALERT { get; set; }

        public int GetAlertMessageCount()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_Count;

            ParameterList = new DbParameter[]
            {
                Parameter("@EMP_ID",RIS_COMMENTSYSTEMALERT.READER_ID)
            };
            DataTable dt = ExecuteDataTable();
            int returnValue = dt == null ? 0 : Convert.ToInt32(dt.Rows[0][0]);
            return returnValue;
        }
        public DataSet GetAlertMessage()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_COMMENTSYSTEMALERT_Check;

            ParameterList = new DbParameter[]
            {
                Parameter("@EMP_ID",RIS_COMMENTSYSTEMALERT.READER_ID)
            };

            return ExecuteDataSet();
        }
    }
}
