using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class GBLMessageRecipientUpdateData : DataAccessBase
    {
        public GBL_MESSAGERECIPIENT Columns { get; set; }

        public GBLMessageRecipientUpdateData()
        {

        }

        public void Update()
        {
            StoredProcedureName = StoredProcedure.GBLAlert_Update;
            ExecuteNonQuery();
        }
        public void UpdateTime() {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGERECIPIENT_Update_Read;
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void UpdateStar()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGERECIPIENT_Update_Star;
            ParameterList = buildParameterStart();
            ExecuteNonQuery();
        }
        public void UpdateTrash()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGERECIPIENT_Update_Trash;
            ParameterList = buildParameterTrash();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@MSG_ID",Columns.MSG_ID),
                 Parameter("@MSG_TO",Columns.CC_TO),
                Parameter("@SP_TYPE",Columns.SP_TYPE)
                };
            return parameters;
        }
        private DbParameter[] buildParameterStart()
        {
            DbParameter[] parameters ={
                Parameter("@MSG_ID",Columns.MSG_ID),
                Parameter("@IS_STARRED",Columns.IS_STARRED),
                Parameter("@LAST_MODIFIED_BY",Columns.LAST_MODIFIED_BY)
                };
            return parameters;
        }
        private DbParameter[] buildParameterTrash()
        {
            DbParameter[] parameters ={
                Parameter("@SP_TYPE",Columns.SP_TYPE),
                Parameter("@MSG_ID",Columns.MSG_ID),
                Parameter("@IS_TRASHED",Columns.IS_TRASHED),
                Parameter("@LAST_MODIFIED_BY",Columns.LAST_MODIFIED_BY)
                };
            return parameters;
        }
    }
}
