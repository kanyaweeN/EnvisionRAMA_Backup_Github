using System.Web.Services;
using EnvisionInterfaceEngine.Common.Global;
using EnvisionInterfaceEngine.Operational.MSMQ;

namespace EnvisionIEPreSyncParams
{
	[WebService(Namespace = "http://www.miracleadvance.com/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.None)]
	public class Service : WebService
	{
		[WebMethod]
		public string Welcome(string how)
		{
			return "Welcome " + how;
		}

		[WebMethod]
		public bool Set_ADTByHNQueue(int logId, string hn, int orgId)
		{
			string message = string.Format("{0}^{1}", hn, orgId);

			return MSMQManager.Send(Config.ADTByHNQueuePath, logId.ToString(), message);
		}

		[WebMethod]
		public bool Set_ADTReconcileQueue(int logId, string oldHn, string newHn, int orgId)
		{
			string message = string.Format("{0}^{1}^{2}", oldHn, newHn, orgId);

			return MSMQManager.Send(Config.ADTReconcileQueuePath, logId.ToString(), message);
		}

		[WebMethod]
		public bool Set_ORMByAccessionNoQueue(int logId, string accessionNo, int orgId)
		{
			string message = string.Format("{0}^{1}", accessionNo, orgId);

			return MSMQManager.Send(Config.ORMByAccessionNoQueuePath, logId.ToString(), message);
		}

		[WebMethod]
		public bool Set_ORMByOrderIdQueue(int logId, int orderId)
		{
			string message = string.Format("{0}", orderId);

			return MSMQManager.Send(Config.ORMByOrderIdQueuePath, logId.ToString(), message);
		}

		[WebMethod]
		public bool Set_ORMBidirectionalByAccessionNoQueue(int logId, string accessionNo, int orgId)
		{
			string message = string.Format("{0}^{1}", accessionNo, orgId);

			return MSMQManager.Send(Config.ORMBidirectionalByAccessionNoQueuePath, logId.ToString(), message);
		}

		[WebMethod]
		public bool Set_ORMMergeByAccessionNoQueue(int logId, string accessionNo, int orgId)
		{
			string message = string.Format("{0}^{1}", accessionNo, orgId);

			return MSMQManager.Send(Config.ORMMergeByAccessionNoQueuePath, logId.ToString(), message);
		}

		[WebMethod]
		public bool Set_ORUByAccessionNoQueue(int logId, string accessionNo, int orgId)
		{
			string message = string.Format("{0}^{1}", accessionNo, orgId);

			return MSMQManager.Send(Config.ORUByAccessionNoQueuePath, logId.ToString(), message);
		}
	}
}