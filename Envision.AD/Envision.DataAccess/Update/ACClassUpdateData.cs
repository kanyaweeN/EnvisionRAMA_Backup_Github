using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
    public class ACClassUpdateData : DataAccessBase
    {
        public AC_CLASS AC_CLASS { get; set; }

        public ACClassUpdateData()
        {
            AC_CLASS = new AC_CLASS();
            StoredProcedureName = StoredProcedure.Prc_AC_CLASS_Update;
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
Parameter("@CLASS_ID",AC_CLASS.CLASS_ID)
,Parameter("@CLASS_ALIAS",AC_CLASS.CLASS_ALIAS)
,Parameter("@CLASS_LABEL",AC_CLASS.CLASS_LABEL)
,Parameter("@ORG_ID",AC_CLASS.ORG_ID)
,Parameter("@LAST_MODIFIED_BY",AC_CLASS.LAST_MODIFIED_BY)
                                      };
            return parameters;
        }
    }
}
