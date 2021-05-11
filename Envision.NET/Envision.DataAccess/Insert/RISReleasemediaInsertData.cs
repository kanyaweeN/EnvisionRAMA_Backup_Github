using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISReleasemediaInsertData : DataAccessBase
    {
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
        int _id = 0;

        public RISReleasemediaInsertData()
        {
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
            StoredProcedureName = StoredProcedure.Prc_RIS_RELEASEMEDIA_Insert;
        }
       
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            _id = (int)ParameterList[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
        private DbParameter[] buildParameter() {
            DbParameter Release_Date = Parameter();
            Release_Date.ParameterName = "@RELEASE_DATE";
            if (RIS_RELEASEMEDIA.RELEASE_DATE == DateTime.MinValue)
            {
                Release_Date.Value = DateTime.Now;
            }
            else
            {
                Release_Date.Value = RIS_RELEASEMEDIA.RELEASE_DATE;
            }

            DbParameter Request_By = Parameter();
            Request_By.ParameterName = "@REQUEST_BY";
            if (RIS_RELEASEMEDIA.REQUEST_BY == '0')
            {
                Request_By.Value = "N";
            }
            else
            {
                Request_By.Value = RIS_RELEASEMEDIA.REQUEST_BY;
            }
            DbParameter MediaType = Parameter();
            MediaType.ParameterName = "@MEDIA_TYPE";
            MediaType.Value = "0";
            if (RIS_RELEASEMEDIA.MEDIA_TYPE == '0')
            {
                MediaType.Value = "0";
            }
            else
            {
                MediaType.Value = RIS_RELEASEMEDIA.MEDIA_TYPE;
            }

            DbParameter Reason = Parameter();
            Reason.ParameterName = "@REASON";
            Reason.Value = "N";
            if (RIS_RELEASEMEDIA.REASON == '0')
            {
                Reason.Value = "N";
            }
            else
            {
                Reason.Value = RIS_RELEASEMEDIA.REASON;
            }


            DbParameter param1 = Parameter("@RELEASE_ID", RIS_RELEASEMEDIA.RELEASE_ID);
            param1.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
                param1
                ,Parameter("@ORDER_ID",RIS_RELEASEMEDIA.ORDER_ID)
                ,Parameter("@EXAM_ID",RIS_RELEASEMEDIA.EXAM_ID)
			    ,Parameter("@HN",RIS_RELEASEMEDIA.HN)
                ,Release_Date
                ,Request_By
                ,Parameter("@REQUEST_BY_ID",RIS_RELEASEMEDIA.REQUEST_BY_ID)
                ,MediaType
                ,Parameter("@RECEIVED_BY",RIS_RELEASEMEDIA.RECEIVED_BY)
                ,Reason
                ,Parameter("@COMMENT",RIS_RELEASEMEDIA.COMMENT)
                ,Parameter("@UNIT_ID",RIS_RELEASEMEDIA.UNIT_ID)
                ,Parameter("@CREATED_BY",RIS_RELEASEMEDIA.CREATED_BY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_RELEASEMEDIA.LAST_MODIFIED_BY)
                ,Parameter("@QTY",RIS_RELEASEMEDIA.QTY)
			};
            return parameters;
        }
    }
}

