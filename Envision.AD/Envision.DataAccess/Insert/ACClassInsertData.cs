using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
    public class ACClassInsertData : DataAccessBase 
    {
        public AC_CLASS AC_CLASS { get; set; }
        int _id = 0;
        public ACClassInsertData()
		{
            AC_CLASS = new AC_CLASS();
			StoredProcedureName = StoredProcedure.Prc_AC_CLASS_Insert;
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
            DbParameter _CLASS_ID = Parameter("@CLASS_ID", AC_CLASS.CLASS_ID);
            _CLASS_ID.Direction = ParameterDirection.Output;

            DbParameter[] parameters ={
_CLASS_ID
,Parameter("@CLASS_ALIAS",AC_CLASS.CLASS_ALIAS)
,Parameter("@CLASS_LABEL",AC_CLASS.CLASS_LABEL)
,Parameter("@ORG_ID",AC_CLASS.ORG_ID)
,Parameter("@CREATED_BY",AC_CLASS.CREATED_BY)
//,Parameter("@CREATED_ON",AC_CLASS.CREATED_ON)
,Parameter("@LAST_MODIFIED_BY",AC_CLASS.LAST_MODIFIED_BY)
//,Parameter("@LAST_MODIFIED_ON",AC_CLASS.LAST_MODIFIED_ON)
            };
            return parameters;
        }
    }
}
