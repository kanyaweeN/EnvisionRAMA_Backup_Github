using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class GBLMymenuSelectData : DataAccessBase 
	{
        public GBL_MYMENU GBL_MYMENU { get; set; }

		public  GBLMymenuSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_GBL_Favourite_Select;
            GBL_MYMENU = new GBL_MYMENU();
		}
		
		public DataSet GetData()
		{
            DataSet ds = new DataSet();
            ParameterList = buildParameter();
            ds = ExecuteDataSet();
            return ds;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                                 Parameter( "@EMP_ID"	, GBL_MYMENU.EMP_ID )
                                       };
            return parameters;
        }
	}
}

