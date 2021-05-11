using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class RISPaticdInsertData : DataAccessBase 
	{
        public RIS_PATICD RIS_PATICD { get; set; }

        public RISPaticdInsertData()
		{
            RIS_PATICD = new RIS_PATICD();
            StoredProcedureName = StoredProcedure.Prc_RIS_PATICD_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        public int Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
            return (int)ParameterList[0].Value;
        }
        private DbParameter[] buildParameter() {
            DbParameter pPAT_ICD_ID = Parameter();
            pPAT_ICD_ID.ParameterName = "@PAT_ICD_ID";
            pPAT_ICD_ID.Value = 0;
            pPAT_ICD_ID.Direction = ParameterDirection.Output;

            DbParameter pACCESSION_NO = Parameter();
            pACCESSION_NO.ParameterName = "@ACCESSION_NO";
            if (string.IsNullOrEmpty(RIS_PATICD.ACCESSION_NO))// == string.Empty || RIS_PATICD.ACCESSION_NO == null)
                pACCESSION_NO.Value = DBNull.Value;
            else
                pACCESSION_NO.Value = RIS_PATICD.ACCESSION_NO;

            DbParameter[] parameters ={
                pPAT_ICD_ID
                ,Parameter("@ICD_ID",RIS_PATICD.ICD_ID)
                ,Parameter("@HN",RIS_PATICD.HN)
                ,Parameter("@ORDER_NO",RIS_PATICD.ORDER_NO)
                ,pACCESSION_NO
                ,Parameter("@ORDER_RESULT_FLAG",RIS_PATICD.ORDER_RESULT_FLAG)
                ,Parameter("@ORG_ID",RIS_PATICD.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_PATICD.CREATED_BY)
                
            };
            return parameters;
        }
	}
}

