using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISExamresultradsInsertData : DataAccessBase
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS { get; set; }
        public RISExamresultradsInsertData()
        {
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTRADS_Insert;
        }
        public void Add()
        {
            ParameterList = buildParameter();
            ExecuteNonQuery();
        }
        public void Add(DbTransaction tran)
        {
            ParameterList = buildParameter();
            Transaction = tran;
            ExecuteNonQuery();
        }
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                Parameter("@ACCESSION_NO",RIS_EXAMRESULTRADS.ACCESSION_NO)
                ,Parameter("@RAD_ID",RIS_EXAMRESULTRADS.RAD_ID)
                ,Parameter("@CAN_PRELIM",RIS_EXAMRESULTRADS.CAN_PRELIM)
                ,Parameter("@CAN_FINALIZE",RIS_EXAMRESULTRADS.CAN_FINALIZE)
                ,Parameter("@SL_NO",RIS_EXAMRESULTRADS.SL_NO)
                ,Parameter("@CREATED_BY",RIS_EXAMRESULTRADS.CREATED_BY)
			};
            return parameters;

        }
    }
}
