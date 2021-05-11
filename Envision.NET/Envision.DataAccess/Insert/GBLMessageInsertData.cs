using System.Data.Common;

using Envision.Common;
using System;
using System.Data;

namespace Envision.DataAccess.Insert
{
    public class GBLMessageInsertData : DataAccessBase
    {
        public GBL_MESSAGE Columns { get; set; }

        public GBLMessageInsertData()
        {

        }

        public int Add()
        {
            StoredProcedureName = StoredProcedure.Prc_GBL_MESSAGE_Insert;

            DbParameter _return = Parameter("@i", 0);
            _return.Direction = ParameterDirection.Output;
            _return.DbType = DbType.Int32;

            ParameterList = new DbParameter[]
            {
                _return,
                Parameter("@MSG_FROM",Columns.MSG_FROM),
                Parameter("@MSG_SUBJECT",Columns.MSG_SUBJECT),
                Parameter("@MSG_BODY",Columns.MSG_BODY),
                Parameter("@MSG_STATUS",Columns.MSG_STATUS),
                Parameter("@MSG_PRIORITY",Columns.MSG_PRIORITY),
                Parameter("@IS_FOECED",Columns.IS_FORCED),
                Parameter("@CREATED_BY",Columns.CREATED_BY)
            };

            ExecuteNonQuery();

            return Convert.ToInt32(_return.Value);
        }
    }
}