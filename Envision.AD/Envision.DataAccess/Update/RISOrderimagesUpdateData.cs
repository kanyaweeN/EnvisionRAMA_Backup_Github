using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISOrderimagesUpdateData : DataAccessBase 
	{
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }

		public  RISOrderimagesUpdateData()
		{
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_UpdateStatus;
		}
        public RISOrderimagesUpdateData(RIS_ORDERIMAGE risorderimage)
        {
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            RIS_ORDERIMAGE = risorderimage;
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_Update;
        }
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public void UpdateOrder()
        {
            ParameterList = buildParameterUpdateOrder();
            ExecuteNonQuery();
        }
        public void UpdateOrderIdByScheduleId(DbTransaction tran)
        {
            Transaction = tran;
            UpdateOrderIdByScheduleId();
        }
        public void UpdateOrderIdByScheduleId()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_UpdateOrderIdByScheduleId;
            DbParameter[] parameters ={
               Parameter("@ORDER_ID",RIS_ORDERIMAGE.ORDER_ID)
                ,Parameter("@SCHEDULE_ID",RIS_ORDERIMAGE.SCHEDULE_ID)
                                      };
            ParameterList = parameters;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@ORDER_IMAGE_ID",RIS_ORDERIMAGE.ORDER_IMAGE_ID)
                ,Parameter("@IS_DELETED",RIS_ORDERIMAGE.IS_DELETED)
                ,Parameter("@LAST_MODIFIED_BY",RIS_ORDERIMAGE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        private DbParameter[] buildParameterUpdateOrder()
        {
            DbParameter[] parameters ={
               Parameter("@ORDER_IMAGE_ID",RIS_ORDERIMAGE.ORDER_IMAGE_ID)
                ,Parameter("@ORDER_ID",RIS_ORDERIMAGE.ORDER_ID)
                ,Parameter("@LAST_MODIFIED_BY",RIS_ORDERIMAGE.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
        public void UpdateIsDeleted()
        {
            StoredProcedureName = StoredProcedure.Prc_RIS_ORDERIMAGES_UpdateIsDeleted;

            ParameterList = new DbParameter[]
            {
                Parameter("@ORDER_IMAGE_ID", RIS_ORDERIMAGE.ORDER_IMAGE_ID),
                Parameter("@IS_DELETED", RIS_ORDERIMAGE.IS_DELETED),
                Parameter("@LAST_MODIFIED_BY", RIS_ORDERIMAGE.LAST_MODIFIED_BY)
            };

            ExecuteNonQuery();
        }
	}
}

