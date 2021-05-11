using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;


namespace Envision.DataAccess.Insert
{
	public class RISTechworksInsertData : DataAccessBase 
	{
        public RIS_TECHWORK RIS_TECHWORK { get; set; }
        private int action;

		public RISTechworksInsertData()
		{
            RIS_TECHWORK = new RIS_TECHWORK();
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHWORKS_Insert;
            action = 0;
		}
        public RISTechworksInsertData(bool InsertStart)
        {
            if (InsertStart)
            {
                StoredProcedureName = StoredProcedure.Prc_RIS_TECHWORKS_InsertByStartOnly;
                action = 1;
            }

        }

	
		public void Add()
		{
            if (action == 0)
                ParameterList = buildParameter();
            else if (action == 1)
                ParameterList = buildParameterStart();
            try
            {
                ExecuteNonQuery();
            }
            catch(Exception ex) { }
		}
        private DbParameter[] buildParameter() {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_ON", RIS_TECHWORK.ACCESSION_ON)
                ,Parameter("@TAKE", RIS_TECHWORK.TAKE)
                ,Parameter("@START_TIME", RIS_TECHWORK.START_TIME)
                ,Parameter("@END_TIME", RIS_TECHWORK.END_TIME)
                ,Parameter("@EXPOSURE_TECHNIQUE", RIS_TECHWORK.EXPOSURE_TECHNIQUE)
                ,Parameter("@PROTOCOL", RIS_TECHWORK.PROTOCOL)
                ,Parameter("@KV", RIS_TECHWORK.KV)
                ,Parameter("@mA", RIS_TECHWORK.mA)
                ,Parameter("@SEC", RIS_TECHWORK.SEC)
                ,Parameter("@STATUS", RIS_TECHWORK.STATUS)
                ,Parameter("@COMMENTS", RIS_TECHWORK.COMMENTS)
                ,Parameter("@NO_OF_IMAGES", RIS_TECHWORK.NO_OF_IMAGES)
                ,Parameter("@ORG_ID", RIS_TECHWORK.ORG_ID)
                ,Parameter("@CREATED_BY", RIS_TECHWORK.CREATED_BY)
                ,Parameter("@PERFORMANCED_BY", RIS_TECHWORK.PERFORMANCED_BY)
            };
            return parameters;
        }
        private DbParameter[] buildParameterStart() {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_ON",RIS_TECHWORK.ACCESSION_ON)
                ,Parameter("@START_TIME",RIS_TECHWORK.START_TIME)
                ,Parameter("@END_TIME",RIS_TECHWORK.END_TIME)
                ,Parameter("@ORG_ID",RIS_TECHWORK.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_TECHWORK.CREATED_BY)
                //,Parameter("@STATUS",RIS_TECHWORK.STATUS)
            };
            return parameters;
        }
	}
}

