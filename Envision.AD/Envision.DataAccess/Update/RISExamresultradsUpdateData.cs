using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISExamresultradsUpdateData : DataAccessBase
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS{get;set;}
        public RISExamresultradsUpdateData()
        {
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
            StoredProcedureName = StoredProcedure.Prc_RIS_EXAMRESULTRADS_Update;
        }
		public bool Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
            return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
Parameter("@ACCESSION_NO",RIS_EXAMRESULTRADS.ACCESSION_NO)
,Parameter("@RAD_ID",RIS_EXAMRESULTRADS.RAD_ID)
,Parameter("@SL_NO",RIS_EXAMRESULTRADS.SL_NO)
,Parameter("@CAN_PRELIM",RIS_EXAMRESULTRADS.CAN_PRELIM)
,Parameter("@CAN_FINALIZE",RIS_EXAMRESULTRADS.CAN_FINALIZE)
,Parameter("@LAST_MODIFIED_BY",RIS_EXAMRESULTRADS.LAST_MODIFIED_BY)

                                      };
            return parameters;
        }
    }
}
