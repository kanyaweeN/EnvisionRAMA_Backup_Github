using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace EnvisionInterfaceEngine.WebService
{
    [WebServiceBindingAttribute(Name = "ServiceSoap", Namespace = "http://www.miracleadvance.com/")]
    public class EnvisionIEPreSyncParams : SoapHttpClientProtocol
    {
        private string url = "{0}EnvisionIEPreSyncParams/Service.asmx";

        public EnvisionIEPreSyncParams(string host)
        {
            Url = string.Format(url, host);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ADTByHNQueue",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool Set_ADTByHNQueue(int logId, string hn, int orgId)
        {
            return (bool)(((object[])Invoke("Set_ADTByHNQueue", new object[] { logId, hn, orgId }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ADTReconcileQueue",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool Set_ADTReconcileQueue(int logId, string oldHn, string newHn, int orgId)
        {
            return (bool)(((object[])Invoke("Set_ADTReconcileQueue", new object[] { logId, oldHn, newHn, orgId }))[0]);
        }

		[SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ORMByAccessionNoQueue",
			RequestNamespace = "http://www.miracleadvance.com/",
			ResponseNamespace = "http://www.miracleadvance.com/",
			Use = SoapBindingUse.Literal,
			ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool Set_ORMByAccessionNoQueue(int logId, string accessionNo, int orgId)
		{
			return (bool)(((object[])Invoke("Set_ORMByAccessionNoQueue", new object[] { logId, accessionNo, orgId }))[0]);
		}

		[SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ORMByOrderIdQueue",
			RequestNamespace = "http://www.miracleadvance.com/",
			ResponseNamespace = "http://www.miracleadvance.com/",
			Use = SoapBindingUse.Literal,
			ParameterStyle = SoapParameterStyle.Wrapped)]
		public bool Set_ORMByOrderIdQueue(int logId, int orderId)
		{
			return (bool)(((object[])Invoke("Set_ORMByOrderIdQueue", new object[] { logId, orderId }))[0]);
		}

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ORMBidirectionalByAccessionNoQueue",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool Set_ORMBidirectionalByAccessionNoQueue(int logId, string accessionNo, int orgId)
        {
            return (bool)(((object[])Invoke("Set_ORMBidirectionalByAccessionNoQueue", new object[] { logId, accessionNo, orgId }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ORMMergeByAccessionNoQueue",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool Set_ORMMergeByAccessionNoQueue(int logId, string accessionNo, int orgId)
        {
            return (bool)(((object[])Invoke("Set_ORMMergeByAccessionNoQueue", new object[] { logId, accessionNo, orgId }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ORUByAccessionNoQueue",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool Set_ORUByAccessionNoQueue(int logId, string accessionNo, int orgId)
        {
            return (bool)(((object[])Invoke("Set_ORUByAccessionNoQueue", new object[] { logId, accessionNo, orgId }))[0]);
        }
    }
}
