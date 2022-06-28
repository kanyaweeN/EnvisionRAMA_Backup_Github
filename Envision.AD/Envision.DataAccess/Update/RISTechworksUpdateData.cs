using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISTechworksUpdateData : DataAccessBase 
	{
        public RIS_TECHWORK RIS_TECHWORK { get; set; }

		public  RISTechworksUpdateData()
		{
            RIS_TECHWORK = new RIS_TECHWORK();
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHWORKS_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_ON",RIS_TECHWORK.ACCESSION_ON)
                ,Parameter("@TAKE",RIS_TECHWORK.TAKE)
                ,Parameter("@START_TIME",RIS_TECHWORK.START_TIME)
                ,Parameter("@END_TIME",RIS_TECHWORK.END_TIME)
                ,Parameter("@EXPOSURE_TECHNIQUE",RIS_TECHWORK.EXPOSURE_TECHNIQUE)
                ,Parameter("@PROTOCOL",RIS_TECHWORK.PROTOCOL)
                ,Parameter("@KV",RIS_TECHWORK.KV)
                ,Parameter("@mA",RIS_TECHWORK.mA)
                ,Parameter("@SEC",RIS_TECHWORK.SEC)
                ,Parameter("@STATUS",RIS_TECHWORK.STATUS)
                ,Parameter("@COMMENTS",RIS_TECHWORK.COMMENTS)
                ,Parameter("@NO_OF_IMAGES",RIS_TECHWORK.NO_OF_IMAGES)
                ,Parameter("@ORG_ID",RIS_TECHWORK.ORG_ID)
                ,Parameter("@PERFORMANCED_BY",RIS_TECHWORK.PERFORMANCED_BY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_TECHWORK.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

