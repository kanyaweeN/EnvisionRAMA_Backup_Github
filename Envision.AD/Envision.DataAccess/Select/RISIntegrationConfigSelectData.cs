using System;
using System.Data;
using System.Data.Common;
using Envision.Common;

namespace Envision.DataAccess.Select
{
	public class RISIntegrationConfigSelectData : DataAccessBase
	{
		public RIS_INTEGRATIONCONFIG RIS_INTEGRATIONCONFIG { get; set; }

		public RISIntegrationConfigSelectData() { }

		public DataSet GetData()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_INTEGRATIONCONFIG_Select;

			return ExecuteDataSet();
		}
		public bool GetCheckUnique()
		{
			StoredProcedureName = StoredProcedure.Prc_RIS_INTEGRATIONCONFIG_SelectCheckUnique;

			ParameterList = new DbParameter[]
			{
				Parameter("@FLAG", 0),
				Parameter("@WORK_STATION_ID", RIS_INTEGRATIONCONFIG.WORK_STATION_ID),
				Parameter("@WORK_STATION_UID", RIS_INTEGRATIONCONFIG.WORK_STATION_UID)
			};

			ParameterList[0].Direction = ParameterDirection.Output;

			ExecuteNonQuery();

			return Convert.ToBoolean(ParameterList[0].Value);
		}
	}
}
