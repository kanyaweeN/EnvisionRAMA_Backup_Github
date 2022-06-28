using Envision.Common;
using Envision.DataAccess;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISIntegrationConfig : IBusinessLogic
	{
		public RIS_INTEGRATIONCONFIG RIS_INTEGRATIONCONFIG { get; set; }

		public ProcessUpdateRISIntegrationConfig() { RIS_INTEGRATIONCONFIG = new RIS_INTEGRATIONCONFIG(); }

		public void Invoke()
		{
			RISIntegrationConfigUpdateData prc = new RISIntegrationConfigUpdateData();
			prc.RIS_INTEGRATIONCONFIG = RIS_INTEGRATIONCONFIG;
			prc.Update();
		}
	}
}
