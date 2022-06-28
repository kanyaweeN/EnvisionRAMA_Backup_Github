using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class RISNurseDataDtlUpdateData : DataAccessBase
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }

        public RISNurseDataDtlUpdateData()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
			StoredProcedureName = StoredProcedure.Prc_RIS_NURSESDATADTL_Update;
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
                Parameter("@NURSE_DATA_UK_ID",RIS_NURSESDATADTL.NURSE_DATA_UK_ID)
                ,Parameter("@DETAIL_DATA_ID",RIS_NURSESDATADTL.DETAIL_DATA_ID)
                ,Parameter("@DETAIL_TIME",RIS_NURSESDATADTL.DETAIL_TIME)
                ,Parameter("@HR_MIN",RIS_NURSESDATADTL.HR_MIN)
                ,Parameter("@RR_MIN",RIS_NURSESDATADTL.RR_MIN)
                ,Parameter("@BP_MMHG",RIS_NURSESDATADTL.BP_MMHG)
                ,Parameter("@O2_SAT",RIS_NURSESDATADTL.O2_SAT)
                ,Parameter("@CONCSIOUS",RIS_NURSESDATADTL.CONCSIOUS)
                ,Parameter("@PROGRESS_NOTE",RIS_NURSESDATADTL.PROGRESS_NOTE)
                ,Parameter("@ORG_ID",RIS_NURSESDATADTL.ORG_ID)
                ,Parameter("@LAST_MODIFIED_BY",RIS_NURSESDATADTL.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
	}
}
