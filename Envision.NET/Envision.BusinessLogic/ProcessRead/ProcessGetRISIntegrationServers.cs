using System.Data;
using Envision.Common;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetRISIntegrationServers : IBusinessLogic
	{
		public RIS_INTEGRATIONSERVERS RIS_INTEGRATIONSERVERS { get; set; }
		public DataSet Result { get; set; }

		public ProcessGetRISIntegrationServers() { RIS_INTEGRATIONSERVERS = new RIS_INTEGRATIONSERVERS(); }

		public void Invoke()
		{
			RISIntegrationServersSelectData prc = new RISIntegrationServersSelectData();
			prc.RIS_INTEGRATIONSERVERS = RIS_INTEGRATIONSERVERS;

			Result = prc.GetData();
		}
	}
}
