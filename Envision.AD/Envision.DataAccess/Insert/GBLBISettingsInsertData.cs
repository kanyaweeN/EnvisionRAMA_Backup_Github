using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;

namespace Envision.DataAccess.Insert
{
	public class GBLBISettingsInsertData : DataAccessBase 
	{
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }
        public GBLBISettingsInsertData()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
            StoredProcedureName = StoredProcedure.Prc_GBL_BISETTINGS_Insert;
		}
		public void Add()
		{
            ParameterList = buildParameter();
            ExecuteNonQuery();
		}

        //@EMP_ID int
        //,@BI_NAME nvarchar(150)
        //,@BI_DESC nvarchar(300)
        //,@BI_TAG nvarchar(300)
        //,@IS_GLOBAL nvarchar(1)
        //,@ORG_ID int
        //,@CREATED_BY int

        private DbParameter[] buildParameter() {
            DbParameter[] parameters ={
                Parameter("@EMP_ID",GBL_BISETTINGS.EMP_ID)
                ,Parameter("@BI_NAME",GBL_BISETTINGS.BI_NAME)
                ,Parameter("@BI_DESC",GBL_BISETTINGS.BI_DESC)
                ,Parameter("@BI_TAG",GBL_BISETTINGS.BI_TAG)
                ,Parameter("@IS_GLOBAL",GBL_BISETTINGS.IS_GLOBAL)
                ,Parameter("@BI_FIELD_ORDER",GBL_BISETTINGS.BI_FIELD_ORDER)
                ,Parameter("@ORG_ID",new GBLEnvVariable().OrgID)
                ,Parameter("@CREATED_BY",new GBLEnvVariable().UserID)
            };
            return parameters;
        }
	}
}

