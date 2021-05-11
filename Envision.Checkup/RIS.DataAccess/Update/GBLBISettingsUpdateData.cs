using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using RIS.DataAccess;
using System.Data.SqlClient;
using RIS.Common.Common;

namespace Envision.DataAccess.Update
{
	public class GBLBISettingsUpdateData : DataAccessBase 
	{
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }

        public GBLBISettingsUpdateData()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
			StoredProcedureName = StoredProcedure.Name.Prc_GBL_BISETTINGS_Update.ToString();
		}
		public void Update()
		{
            SqlParameter[] ParameterList = buildParameter();
            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            object id = dbhelper.RunScalar(base.ConnectionString, ParameterList);
		}

        //@BISETTINGS_ID int
        //,@EMP_ID int
        //,@BI_NAME nvarchar(150)
        //,@BI_DESC nvarchar(300)
        //,@BI_TAG nvarchar(300)
        //,@IS_GLOBAL nvarchar(1)
        //,@LAST_MODIFIED_BY int

        private SqlParameter[] buildParameter()
        {
            SqlParameter[] parameters ={
                    new SqlParameter("@BISETTINGS_ID",GBL_BISETTINGS.BISETTINGS_ID)
                    ,new SqlParameter("@EMP_ID",GBL_BISETTINGS.EMP_ID)
                    ,new SqlParameter("@BI_NAME",GBL_BISETTINGS.BI_NAME)
                    ,new SqlParameter("@BI_DESC",GBL_BISETTINGS.BI_DESC)
                    ,new SqlParameter("@BI_TAG",GBL_BISETTINGS.BI_TAG)
                    ,new SqlParameter("@IS_GLOBAL",GBL_BISETTINGS.IS_GLOBAL)
                    ,new SqlParameter("@LAST_MODIFIED_BY",new GBLEnvVariable().UserID)
                                      };
            return parameters;
        }
	}
}

