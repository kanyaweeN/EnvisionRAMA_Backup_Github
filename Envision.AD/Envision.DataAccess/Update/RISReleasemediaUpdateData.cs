using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISReleasemediaUpdateData : DataAccessBase 
	{
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }

		public  RISReleasemediaUpdateData()
        {
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
			StoredProcedureName = StoredProcedure.Prc_RIS_RELEASEMEDIA_Update;
		}
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter Release_Date = Parameter();
            Release_Date.ParameterName = "@RELEASE_DATE";
            if (RIS_RELEASEMEDIA.RELEASE_DATE == null)
                Release_Date.Value = DBNull.Value;
            else
                Release_Date.Value = RIS_RELEASEMEDIA.RELEASE_DATE == DateTime.MinValue ? (object)DBNull.Value : RIS_RELEASEMEDIA.RELEASE_DATE;

            DbParameter Request_By = Parameter();
            Request_By.ParameterName = "@REQUEST_BY";
            if (RIS_RELEASEMEDIA.REQUEST_BY == null)
                Request_By.Value = "N";
            else
                Request_By.Value = RIS_RELEASEMEDIA.REQUEST_BY.ToString() == "0" ? "N": RIS_RELEASEMEDIA.REQUEST_BY.ToString();


            DbParameter MediaType = Parameter();
            MediaType.ParameterName = "@MEDIA_TYPE";
            if (RIS_RELEASEMEDIA.MEDIA_TYPE == null)
                MediaType.Value = "N";
            else
                MediaType.Value = RIS_RELEASEMEDIA.MEDIA_TYPE.ToString() == "0" ? "0" : RIS_RELEASEMEDIA.MEDIA_TYPE.ToString();

            DbParameter Reason = Parameter();
            Reason.ParameterName = "@REASON";
            if (RIS_RELEASEMEDIA.REASON == null)
                Reason.Value = "N";
            else
                Reason.Value = RIS_RELEASEMEDIA.REASON.ToString() == "0" ? "N" : RIS_RELEASEMEDIA.REASON.ToString();

            DbParameter[] parameters ={
Parameter("@RELEASE_ID",RIS_RELEASEMEDIA.RELEASE_ID)
,Parameter("@HN",RIS_RELEASEMEDIA.HN)
,Release_Date
,Request_By
,Parameter("@REQUEST_BY_ID",RIS_RELEASEMEDIA.REQUEST_BY_ID)
,MediaType
,Parameter("@RECEIVED_BY",RIS_RELEASEMEDIA.RECEIVED_BY)
,Reason
,Parameter("@COMMENT",RIS_RELEASEMEDIA.COMMENT)
,Parameter("@UNIT_ID",RIS_RELEASEMEDIA.UNIT_ID)
,Parameter("@LAST_MODIFIED_BY",RIS_RELEASEMEDIA.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

