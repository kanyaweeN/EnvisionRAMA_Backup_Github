using System.Data;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
	public class ProcessGetRISIntegrationConfig : IBusinessLogic
	{
		public RIS_INTEGRATIONCONFIG RIS_INTEGRATIONCONFIG { get; set; }
		public DataSet Result { get; set; }

		public ProcessGetRISIntegrationConfig() { RIS_INTEGRATIONCONFIG = new RIS_INTEGRATIONCONFIG(); }

		public void Invoke()
		{
			RISIntegrationConfigSelectData prc = new RISIntegrationConfigSelectData();
			prc.RIS_INTEGRATIONCONFIG = RIS_INTEGRATIONCONFIG;

			Result = prc.GetData();
		}
		public bool InvokeCheckUnique()
		{
			RISIntegrationConfigSelectData prc = new RISIntegrationConfigSelectData();
			prc.RIS_INTEGRATIONCONFIG = RIS_INTEGRATIONCONFIG;

			return prc.GetCheckUnique();
		}
	}
}