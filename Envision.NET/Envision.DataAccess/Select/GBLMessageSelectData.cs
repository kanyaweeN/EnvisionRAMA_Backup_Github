using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Select
{
    public class GBLMessageSelectData : DataAccessBase
    {
        public GBL_MESSAGE Columns { get; set; }

        public GBLMessageSelectData()
        {

        }

        public DataSet GetDataByMsgID()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGE_SelectByMsgID;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_ID",Columns.MSG_ID)
            };

            return ExecuteDataSet();
        }
        public DataSet GetDataByStatus()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGE_SelectByStatus;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_FROM",Columns.MSG_FROM),
                Parameter("@MSG_STATUS",Columns.MSG_STATUS)
            };

            return ExecuteDataSet();
        }

        public DataSet GetDataTrash()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGE_Select_Trash;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_FROM",Columns.MSG_FROM)
            };

            return ExecuteDataSet();
        }
    }
}
