using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class ACClassDeleteData : DataAccessBase 
    {
        public AC_CLASS AC_CLASS { get; set; }

          public ACClassDeleteData()
		{
            AC_CLASS = new AC_CLASS();
            StoredProcedureName = StoredProcedure.Prc_AC_CLASS_Delete;
		}
		
		public void Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@CLASS_ID",AC_CLASS.CLASS_ID),
                                     };
            return parameters;
        }
    }
}
