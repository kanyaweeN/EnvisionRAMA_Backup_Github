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
using System.Data.SqlClient;

using RIS.Common;

namespace RIS.DataAccess.Insert
{
    public class OrderImagesInsertData : DataAccessBase
    {
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }

        private OrderImagesInsertDataParameters _orderimagesinsertdataparameters;

        public OrderImagesInsertData()
        {
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            StoredProcedureName = StoredProcedure.Name.Prc_OrderImages_Insert.ToString();
        }

        public void Add()
        {
            _orderimagesinsertdataparameters = new OrderImagesInsertDataParameters();
            _orderimagesinsertdataparameters.RIS_ORDERIMAGE = RIS_ORDERIMAGE;
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, _orderimagesinsertdataparameters.Parameters);

        }
    }

    public class OrderImagesInsertDataParameters
    {
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }
        private SqlParameter[] _parameters;

        public OrderImagesInsertDataParameters()
        {
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
            Build();
        }

        private void Build()
        {
            SqlParameter OrderID = new SqlParameter();
            OrderID.ParameterName = "@ORDER_ID";
            if (RIS_ORDERIMAGE.ORDER_ID == 0)
                OrderID.Value = DBNull.Value;
            else
                OrderID.Value = RIS_ORDERIMAGE.ORDER_ID;
            SqlParameter[] parameters =
		    {
				new SqlParameter( "@HN"	, RIS_ORDERIMAGE.HN ) ,
				OrderID ,
				new SqlParameter( "@SL_NO"	, RIS_ORDERIMAGE.SL_NO ) ,
				new SqlParameter( "@IMAGE_NAME"	    , RIS_ORDERIMAGE.IMAGE_NAME ) ,
				new SqlParameter( "@ORG_ID"		, RIS_ORDERIMAGE.ORG_ID ) ,
				new SqlParameter( "@CREATED_BY"	    , RIS_ORDERIMAGE.CREATED_BY ),
                new SqlParameter("@SCHEDULE_ID" ,RIS_ORDERIMAGE.SCHEDULE_ID)
               
                
			};

            Parameters = parameters;
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
    }
}
