using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Envision.DataAccess.Select
{
    public class RISUnlockedSelectData : DataAccessBase 
	{

        public RISUnlockedSelectData()
		{
            StoredProcedureName = StoredProcedure.Prc_RIS_UNLOCKED_Select;
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
                                       };
            return parameters;
        }
	}
}