using System.Data;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace Envision.WebService
{
    [WebServiceBindingAttribute(Name = "ServiceSoap", Namespace = "http://www.miracleadvance.com/")]
    public class EnvisionIEGet3rdPartyData : SoapHttpClientProtocol
    {
        private string url = "{0}EnvisionIEGet3rdPartyData/Service.asmx";

        public EnvisionIEGet3rdPartyData(string host)
        {
            Url = string.Format(url, host);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Welcome",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string Welcome(string how)
        {
            return ((object[])Invoke("Welcome", new object[] { how }))[0].ToString();
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Get_Billing",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Get_Billing(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Get_Billing", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_Billing",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Set_Billing(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Set_Billing", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_PreBilling",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Set_PreBilling(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Set_PreBilling", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Get_Demographic",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Get_Demographic(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Get_Demographic", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Get_Demographic_Short",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Get_Demographic_Short(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Get_Demographic_Short", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_Demographic",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Set_Demographic(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Set_Demographic", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Get_Result_Legacy",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Get_Result_Legacy(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Get_Result_Legacy", new object[] { data }))[0]);
        }

		[SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_Result",
			RequestNamespace = "http://www.miracleadvance.com/",
			ResponseNamespace = "http://www.miracleadvance.com/",
			Use = SoapBindingUse.Literal,
			ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet Set_Result(DataSet data)
		{
			return (DataSet)(((object[])Invoke("Set_Result", new object[] { data }))[0]);
		}

		[SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_ResultHasImage",
			RequestNamespace = "http://www.miracleadvance.com/",
			ResponseNamespace = "http://www.miracleadvance.com/",
			Use = SoapBindingUse.Literal,
			ParameterStyle = SoapParameterStyle.Wrapped)]
		public DataSet Set_ResultHasImage(DataSet data)
		{
			return (DataSet)(((object[])Invoke("Set_ResultHasImage", new object[] { data }))[0]);
		}

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Get_Schedule",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Get_Schedule(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Get_Schedule", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Get_Schedule_Legacy",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Get_Schedule_Legacy(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Get_Schedule_Legacy", new object[] { data }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/Set_Schedule",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet Set_Schedule(DataSet data)
        {
            return (DataSet)(((object[])Invoke("Set_Schedule", new object[] { data }))[0]);
        }
    }
}
