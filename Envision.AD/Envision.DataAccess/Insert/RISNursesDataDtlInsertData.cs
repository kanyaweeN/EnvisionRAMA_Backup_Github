using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class RISNursesDataDtlInsertData : DataAccessBase
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }
        public RISNursesDataDtlInsertData()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
			StoredProcedureName = StoredProcedure.Prc_RIS_NURSESDATADTL_Insert;
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
            DbParameter DetailTime = Parameter();
            DetailTime.ParameterName = "@DETAIL_TIME";

            if (RIS_NURSESDATADTL.DETAIL_TIME == null)
                DetailTime.Value = DBNull.Value;
            else
                DetailTime.Value = RIS_NURSESDATADTL.DETAIL_TIME == DateTime.MinValue ? (object)DBNull.Value : RIS_NURSESDATADTL.DETAIL_TIME;
            
            DbParameter[] parameters ={
			    Parameter("@NURSE_DATA_UK_ID",RIS_NURSESDATADTL.NURSE_DATA_UK_ID)
                ,DetailTime
                ,Parameter("@HR_MIN",RIS_NURSESDATADTL.HR_MIN)
                ,Parameter("@RR_MIN",RIS_NURSESDATADTL.RR_MIN)
                ,Parameter("@BP_MMHG",RIS_NURSESDATADTL.BP_MMHG)
                ,Parameter("@O2_SAT",RIS_NURSESDATADTL.O2_SAT)
                ,Parameter("@CONCSIOUS",RIS_NURSESDATADTL.CONCSIOUS)
                ,Parameter("@PROGRESS_NOTE",RIS_NURSESDATADTL.PROGRESS_NOTE)
                ,Parameter("@ORG_ID",RIS_NURSESDATADTL.ORG_ID)
                ,Parameter("@CREATED_BY",RIS_NURSESDATADTL.CREATED_BY)
                ,Parameter("@LAST_MODIFIED_BY",RIS_NURSESDATADTL.LAST_MODIFIED_BY)
			};
            return parameters;

        }
	}
}
