using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class GBLMessageRecipientInsertData : DataAccessBase 
	{
        public GBL_MESSAGERECIPIENT Columns { get; set; }

        public GBLMessageRecipientInsertData()
		{

		}

        public void Add()
        {
        }

        public void AddSend()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGERECIPIENT_Insert_Send;

            ParameterList = new DbParameter[]
            {
                Parameter("@MSG_ID",Columns.MSG_ID),
                Parameter("@CC_TO",Columns.CC_TO),
                Parameter("@RECIPIENT_TYPE",Columns.RECIPIENT_TYPE),
                Parameter("@CREATED_BY",Columns.CREATED_BY)
            };

            ExecuteNonQuery();
        }
	}
}

