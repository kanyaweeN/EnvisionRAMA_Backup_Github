using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISTechconsumptionInsertData : DataAccessBase 
	{
        public RIS_TECHCONSUMPTION RIS_TECHCONSUMPTION { get; set; }

        public RISTechconsumptionInsertData()
		{
            RIS_TECHCONSUMPTION = new RIS_TECHCONSUMPTION();
            StoredProcedureName = StoredProcedure.Prc_RIS_TECHCONSUMPTION_Insert;
		}
		
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter() {
            DbParameter pORG_ID = Parameter();
            pORG_ID.ParameterName = "@ORG_ID";
            if (RIS_TECHCONSUMPTION.ORG_ID == null)
                pORG_ID.Value = DBNull.Value;
            else
                pORG_ID.Value = RIS_TECHCONSUMPTION.ORG_ID==0 ? (object)DBNull.Value : RIS_TECHCONSUMPTION.ORG_ID;

            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_TECHCONSUMPTION.ACCESSION_NO)
                ,Parameter("@TAKE",RIS_TECHCONSUMPTION.TAKE)
                ,Parameter("@EXAM_ID",RIS_TECHCONSUMPTION.EXAM_ID)
                ,Parameter("@QTY",RIS_TECHCONSUMPTION.QTY)
                ,Parameter("@RATE",RIS_TECHCONSUMPTION.RATE)
                ,Parameter("@ORG_ID",pORG_ID.Value)
                ,Parameter("@CREATED_BY",RIS_TECHCONSUMPTION.CREATED_BY)
            };
            return parameters;
        }
	}
}

