using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Update
{
	public class GBLBISettingsUpdateData : DataAccessBase 
	{
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }

        public GBLBISettingsUpdateData()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
			StoredProcedureName = StoredProcedure.Prc_GBL_BISETTINGS_Update;
		}
		public void Update()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}

        //@BISETTINGS_ID int
        //,@EMP_ID int
        //,@BI_NAME nvarchar(150)
        //,@BI_DESC nvarchar(300)
        //,@BI_TAG nvarchar(300)
        //,@IS_GLOBAL nvarchar(1)
        //,@LAST_MODIFIED_BY int

        private DbParameter[] buildParameter()
        {
            DbParameter[] parameters ={
                    Parameter("@BISETTINGS_ID",GBL_BISETTINGS.BISETTINGS_ID)
                    ,Parameter("@EMP_ID",GBL_BISETTINGS.EMP_ID)
                    ,Parameter("@BI_NAME",GBL_BISETTINGS.BI_NAME)
                    ,Parameter("@BI_DESC",GBL_BISETTINGS.BI_DESC)
                    ,Parameter("@BI_TAG",GBL_BISETTINGS.BI_TAG)
                    ,Parameter("@IS_GLOBAL",GBL_BISETTINGS.IS_GLOBAL)
                    ,Parameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                                      };
            return parameters;
        }
	}
}

