using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLMessageUpdateData : DataAccessBase
    {
        public GBL_MESSAGE Columns { get; set; }

        public GBLMessageUpdateData()
        {

        }

        public void Update()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGE_Update;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_ID",Columns.MSG_ID),
                Parameter("@MSG_SUBJECT",Columns.MSG_SUBJECT), 
                Parameter("@MSG_BODY",Columns.MSG_BODY ),
                Parameter("@MSG_STATUS",Columns.MSG_STATUS),
                Parameter("@MSG_PRIORITY",Columns.MSG_PRIORITY),
                Parameter("@IS_FORCED",Columns.IS_FORCED),
                Parameter("@LAST_MODIFIED_BY",Columns.LAST_MODIFIED_BY)
            };

            ExecuteNonQuery();
        }
        public void UpdateStar()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGE_Update_Star;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_ID",Columns.MSG_ID),
                Parameter("@IS_STARRED",Columns.IS_STARRED),
                Parameter("@LAST_MODIFIED_BY",Columns.LAST_MODIFIED_BY)
            };

            ExecuteNonQuery();
        }
        public void UpdateTrash()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGE_Update_Trash;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_ID",Columns.MSG_ID),
                Parameter("@IS_DELETED",Columns.IS_DELETED),
                Parameter("@LAST_MODIFIED_BY",Columns.LAST_MODIFIED_BY)
            };

            ExecuteNonQuery();
        }
    }
}
