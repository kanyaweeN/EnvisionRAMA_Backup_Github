using System;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISOrderimagesInsertData : DataAccessBase
    {
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }

        public RISOrderimagesInsertData() { RIS_ORDERIMAGE = new RIS_ORDERIMAGE(); }

        public void Add()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_Insert;

            ParameterList = new DbParameter[]
            {
                Parameter("@ORDER_IMAGE_ID", RIS_ORDERIMAGE.ORDER_IMAGE_ID),
                Parameter("@HN", RIS_ORDERIMAGE.HN),
                Parameter("@SCHEDULE_ID", RIS_ORDERIMAGE.SCHEDULE_ID == 0 ? null : (object)RIS_ORDERIMAGE.SCHEDULE_ID),
                Parameter("@ORDER_ID", RIS_ORDERIMAGE.ORDER_ID == 0 ? null : (object)RIS_ORDERIMAGE.ORDER_ID),
                Parameter("@IMAGE_NAME", RIS_ORDERIMAGE.IMAGE_NAME),
                Parameter("@IS_DELETED", RIS_ORDERIMAGE.IS_DELETED),
                Parameter("@ORG_ID", RIS_ORDERIMAGE.ORG_ID),
                Parameter("@LAST_MODIFIED_BY", RIS_ORDERIMAGE.LAST_MODIFIED_BY)
            };

            ParameterList[0].Direction = ParameterDirection.Output;

            ExecuteNonQuery();

            RIS_ORDERIMAGE.ORDER_IMAGE_ID = Convert.ToInt32(ParameterList[0].Value);
        }
    }
}