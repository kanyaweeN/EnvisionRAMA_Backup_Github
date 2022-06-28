using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExamresulttimeInsertData : DataAccessBase 
    {
         public RIS_EXAMRESULTTIME RIS_EXAMRESULTTIME { get; set; }
        int _id = 0;
        public RISExamresulttimeInsertData()
		{
            RIS_EXAMRESULTTIME = new RIS_EXAMRESULTTIME();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTTIME_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            //_id = (int)ParameterList[0].Value;
		}
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
           // _id = (int)ParameterList[0].Value;
        }
        public int GetID()
        {
            return _id;
        }
        private DbParameter[] buildParameter()
        {

            DbParameter[] parameters ={
Parameter("@ACCESSION_NO",RIS_EXAMRESULTTIME.ACCESSION_NO)
,Parameter("@RAD_ID",RIS_EXAMRESULTTIME.RAD_ID)
,Parameter("@START_STATUS",RIS_EXAMRESULTTIME.START_STATUS)
            };
            return parameters;
        }
    }
}
