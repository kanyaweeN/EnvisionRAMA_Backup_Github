using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
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