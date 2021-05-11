using System;
using System.Data;
using System.Data.Common;
using RIS.Common;
using System.Data.SqlClient;

namespace RIS.DataAccess.Insert
{
	public class RISIntegrationConfigSelectData : DataAccessBase
	{
		public RIS_INTEGRATIONCONFIG RIS_INTEGRATIONCONFIG { get; set; }

		public RISIntegrationConfigSelectData() { }

		public DataSet GetData()
		{
            StoredProcedureName = StoredProcedure.Name.Prc_RIS_INTEGRATIONCONFIG_Select.ToString();

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString);
			return ds;
		}
		public bool GetCheckUnique()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_INTEGRATIONCONFIG_SelectCheckUnique.ToString();

            SqlParameter[] param = 
			{
				new SqlParameter("@FLAG", 0),
				new SqlParameter("@WORK_STATION_ID", RIS_INTEGRATIONCONFIG.WORK_STATION_ID),
				new SqlParameter("@WORK_STATION_UID", RIS_INTEGRATIONCONFIG.WORK_STATION_UID)
			};

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString,param);

            param[0].Direction = ParameterDirection.Output;
            return true;
		}
	}
}
