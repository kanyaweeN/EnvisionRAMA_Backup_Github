using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISNursesDataInsertData : DataAccessBase
    {
        public RIS_NURSESDATA RIS_NURSESDATA { get; set; }
        int _id = 0;
		public  RISNursesDataInsertData()
		{
            RIS_NURSESDATA = new RIS_NURSESDATA();
			StoredProcedureName = StoredProcedure.Prc_RIS_NURSESDATA_Insert;
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
        private DbParameter[] buildParameter()
        {
            DbParameter param1 = Parameter("@NURSE_DATA_UK_ID", RIS_NURSESDATA.NURSE_DATA_UK_ID);
            param1.Direction = ParameterDirection.Output;
            DbParameter[] parameters ={			
			    param1
                ,Parameter("@NURSE_ID",RIS_NURSESDATA.NURSE_ID)
                ,Parameter("@ACCESSION_NO",RIS_NURSESDATA.ACCESSION_NO)
                ,Parameter("@ANESTHESIA_TECHNIQUE",RIS_NURSESDATA.ANESTHESIA_TECHNIQUE)
                ,Parameter("@PAST_ILL_DM",RIS_NURSESDATA.PAST_ILL_DM)
                ,Parameter("@PAST_ILL_HT",RIS_NURSESDATA.PAST_ILL_HT)
                ,Parameter("@PAST_ILL_HD",RIS_NURSESDATA.PAST_ILL_HD)
                ,Parameter("@PAST_ILL_ASTHMA",RIS_NURSESDATA.PAST_ILL_ASTHMA)
                ,Parameter("@PAST_ILL_OTHERS",RIS_NURSESDATA.PAST_ILL_OTHERS)
                ,Parameter("@PROCEDURE",RIS_NURSESDATA.PROCEDURE)
                ,Parameter("@DIAGNOSIS",RIS_NURSESDATA.DIAGNOSIS)
                ,Parameter("@OTHER_DESCRIPTION",RIS_NURSESDATA.OTHER_DESCRIPTION)
                ,Parameter("@ASSISTANT_ID",RIS_NURSESDATA.ASSISTANT_ID)
                ,Parameter("@OPERATOR_ID",RIS_NURSESDATA.OPERATOR_ID)
                ,Parameter("@ORG_ID",RIS_NURSESDATA.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_NURSESDATA.CREATED_BY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_NURSESDATA.LAST_MODIFIED_BY)
			            };
            return parameters;
        }
	}
}
