using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class ACYearUpdateData : DataAccessBase 
    {
        public AC_YEAR AC_YEAR { get; set; }

        public ACYearUpdateData()
		{
            AC_YEAR = new AC_YEAR();
			StoredProcedureName = StoredProcedure.Prc_AC_YEAR_Update;
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
Parameter("@YEAR_ID",AC_YEAR.YEAR_ID)
,Parameter("@YEAR_UID",AC_YEAR.YEAR_UID)
,Parameter("@START_DATE",AC_YEAR.START_DATE)
,Parameter("@END_DATE",AC_YEAR.END_DATE)
,Parameter("@ORG_ID",AC_YEAR.ORG_ID)
,Parameter("@LAST_MODIFIED_BY",AC_YEAR.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
    }
}
