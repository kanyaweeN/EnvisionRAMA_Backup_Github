using System.Data;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
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
