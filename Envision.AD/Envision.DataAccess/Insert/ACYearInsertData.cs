using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ACYearInsertData : DataAccessBase 
    {
          public AC_YEAR AC_YEAR { get; set; }
        int _id = 0;
        public ACYearInsertData()
		{
            AC_YEAR = new AC_YEAR();
			StoredProcedureName = StoredProcedure.Prc_AC_YEAR_Insert;
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
            DbParameter _YEAR_ID = Parameter("@YEAR_ID", AC_YEAR.YEAR_ID);
            _YEAR_ID.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
_YEAR_ID
,Parameter("@YEAR_UID",AC_YEAR.YEAR_UID)
,Parameter("@START_DATE",AC_YEAR.START_DATE)
,Parameter("@END_DATE",AC_YEAR.END_DATE)
,Parameter("@ORG_ID",AC_YEAR.ORG_ID)
,Parameter("@CREATED_BY",AC_YEAR.CREATED_BY)
//,Parameter("@CREATED_ON",AC_YEAR.CREATED_ON)
,Parameter("@LAST_MODIFIED_BY",AC_YEAR.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",AC_YEAR.LAST_MODIFIED_ON)
            };
            return parameters;
        }
    }
}
