using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLMessageRecipientSelectData : DataAccessBase
    {
        public GBL_MESSAGERECIPIENT Columns { get; set; }

        public GBLMessageRecipientSelectData()
        {

        }

        public DataSet GetData()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGERECIPIENT_Select;

            ParameterList = new DbParameter[]
            {
                Parameter("@CC_TO",Columns.CC_TO)
            };

            return ExecuteDataSet();
        }
        public DataSet GetDataByMsgID()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGERECIPIENT_SelectByMsgID;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_ID",Columns.MSG_ID),
                Parameter("@CC_TO",Columns.CC_TO)
            };

            return ExecuteDataSet();
        }
        public DataTable GetMessage()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGERECIPIENT_Check;

            ParameterList = new DbParameter[]
            {
                Parameter("@SP_TYPE",Columns.SP_TYPE),
                Parameter("@MSG_TO",Columns.CC_TO)
            };

            return ExecuteDataTable();
        }
    }
}
