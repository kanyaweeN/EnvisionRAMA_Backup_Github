using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
namespace Envision.DataAccess.Delete
{
    public class GBLBISettingsDeleteData : DataAccessBase
    {
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }
        public GBLBISettingsDeleteData()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
            StoredProcedureName = StoredProcedure.Prc_GBL_BISETTINGS_Delete;
		}
       
		public bool Delete()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
			return true;
		}
        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters = { 
                                           Parameter("@BISETTINGS_ID",GBL_BISETTINGS.BISETTINGS_ID) ,
                                       };
            return parameters;
        }
	}
}
