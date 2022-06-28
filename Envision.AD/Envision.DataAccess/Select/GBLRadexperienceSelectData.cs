using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using Envision.Common;
namespace Envision.DataAccess.Select
{
	public class GBLRadexperienceSelectData : DataAccessBase 
	{
        public GBL_RADEXPERIENCE GBL_RADEXPERIENCE { get; set; }

		public  GBLRadexperienceSelectData()
		{
            GBL_RADEXPERIENCE = new GBL_RADEXPERIENCE();
            StoredProcedureName = StoredProcedure.Prc_GBL_RADEXPERIENCE_Select;
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
                                                 Parameter( "@RADIOLOGIST_ID"	,GBL_RADEXPERIENCE.RADIOLOGIST_ID )
                                       };
            return parameters;
        }
	}
}

