using System.Data.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using RIS.Common;


namespace RIS.DataAccess.Update
{
	public class RISIntegrationConfigUpdateData : DataAccessBase
	{
		public RIS_INTEGRATIONCONFIG RIS_INTEGRATIONCONFIG { get; set; }

		public RISIntegrationConfigUpdateData() { }

		public void Update()
		{
			StoredProcedureName = StoredProcedure.Name.Prc_RIS_INTEGRATIONCONFIG_Update.ToString();
            SqlParameter[] param = 
			{
				new SqlParameter("@WORK_STATION_ID", RIS_INTEGRATIONCONFIG.WORK_STATION_ID),
				new SqlParameter("@WORK_STATION_UID", RIS_INTEGRATIONCONFIG.WORK_STATION_UID),
				new SqlParameter("@SERVER_ID", RIS_INTEGRATIONCONFIG.SERVER_ID),
				new SqlParameter("@USE_SOCKET", RIS_INTEGRATIONCONFIG.USE_SOCKET),
				new SqlParameter("@RECEIVER_IP", RIS_INTEGRATIONCONFIG.RECEIVER_IP),
				new SqlParameter("@RECEIVER_PORT", RIS_INTEGRATIONCONFIG.RECEIVER_PORT == 0 ? DBNull.Value : (object)RIS_INTEGRATIONCONFIG.RECEIVER_PORT),
				new SqlParameter("@SENDER_IP", RIS_INTEGRATIONCONFIG.SENDER_IP),
				new SqlParameter("@WEB_SERVICE_URL", RIS_INTEGRATIONCONFIG.WEB_SERVICE_URL),
				new SqlParameter("@SEND_ADT", RIS_INTEGRATIONCONFIG.SEND_ADT),
				new SqlParameter("@SEND_ADT_RECONCILE", RIS_INTEGRATIONCONFIG.SEND_ADT_RECONCILE),
				new SqlParameter("@SEND_ORM", RIS_INTEGRATIONCONFIG.SEND_ORM),
				new SqlParameter("@SEND_ORM_BIDIRECTIONAL", RIS_INTEGRATIONCONFIG.SEND_ORM_BIDIRECTIONAL),
				new SqlParameter("@SEND_ORM_MERGE", RIS_INTEGRATIONCONFIG.SEND_ORM_MERGE),
				new SqlParameter("@SEND_ORU", RIS_INTEGRATIONCONFIG.SEND_ORU),
				new SqlParameter("@SEND_ORU_WHEN_OWNER", RIS_INTEGRATIONCONFIG.SEND_ORU_WHEN_OWNER),
				new SqlParameter("@SEND_PRELIM", RIS_INTEGRATIONCONFIG.SEND_PRELIM),
				new SqlParameter("@RESULT_TYPE", RIS_INTEGRATIONCONFIG.RESULT_TYPE),
				new SqlParameter("@IS_ACTIVE", RIS_INTEGRATIONCONFIG.IS_ACTIVE)
			};

            DataBaseHelper dbhelper = new DataBaseHelper(StoredProcedureName);
            DataSet ds = dbhelper.Run(base.ConnectionString, param);
		}
	}
}
