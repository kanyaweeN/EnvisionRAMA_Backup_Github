using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Delete
{
    public class ACYearDeleteData : DataAccessBase 
    {
        public AC_YEAR AC_YEAR { get; set; }

         public ACYearDeleteData()
		{
            AC_YEAR = new AC_YEAR();
            StoredProcedureName = StoredProcedure.Prc_AC_YEAR_Delete;
		}
		
		public void Delete()
		{
            try
            {
                ParameterList = buildParameter();
                ExecuteNonQuery();
            }
            catch { }
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                                         Parameter("@YEAR_ID",AC_YEAR.YEAR_ID),
                                     };
            return parameters;
        }
    }
}
