/*
 * Project	: RIS
 *
 * Author   : Surajit Kumar Sarkar
 * eMail    : java2guide@gmail.com
 *
 * Comments	:	
 *	
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class OrderImagesInsertData : DataAccessBase
    {
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }
        public OrderImagesInsertData()
        {
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            StoredProcedureName = StoredProcedure.Prc_OrderImages_Insert;
        }

        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter OrderID = Parameter();
            OrderID.ParameterName = "@ORDER_ID";
            if (RIS_ORDERIMAGE.ORDER_ID == null)
                OrderID.Value = DBNull.Value;
            else
                OrderID.Value = RIS_ORDERIMAGE.ORDER_ID == 0 ? (object)DBNull.Value : RIS_ORDERIMAGE.ORDER_ID;

            DbParameter[] parameters ={			
				Parameter( "@HN"	        , RIS_ORDERIMAGE.PATIENT_ID ) ,
				OrderID ,
				Parameter( "@SL_NO"	        , RIS_ORDERIMAGE.SL_NO ) ,
				Parameter( "@IMAGE_NAME"    , RIS_ORDERIMAGE.IMAGE_NAME ) ,
				Parameter( "@ORG_ID"		, RIS_ORDERIMAGE.ORG_ID ) ,
				Parameter( "@CREATED_BY"	, RIS_ORDERIMAGE.CREATED_BY ),
                Parameter("@SCHEDULE_ID"    ,RIS_ORDERIMAGE.SCHEDULE_ID)
			            };
            return parameters;
        }
    }
}
