using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class RISPaticdUpdateData : DataAccessBase 
	{
        public RIS_PATICD RIS_PATICD { get; set; }

		public  RISPaticdUpdateData()
		{
            RIS_PATICD = new RIS_PATICD();
            StoredProcedureName = StoredProcedure.Prc_RIS_PATICD_Update;
		}
        public void Update()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Update(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@PAT_ICD_ID",RIS_PATICD.PAT_ICD_ID)
                ,Parameter("@ICD_ID",RIS_PATICD.ICD_ID)
                ,Parameter("@HN",RIS_PATICD.HN)
                ,Parameter("@ORDER_NO",RIS_PATICD.ORDER_NO)
                ,Parameter("@ACCESSION_NO",RIS_PATICD.ACCESSION_NO)
                ,Parameter("@ORDER_RESULT_FLAG",RIS_PATICD.ORDER_RESULT_FLAG)
                ,Parameter("@ORG_ID",RIS_PATICD.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",RIS_PATICD.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}

