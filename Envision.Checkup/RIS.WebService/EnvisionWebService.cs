using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace RIS.WebService
{
    [WebServiceBindingAttribute(Name = "ServiceSoap", Namespace = "http://www.miracleadvance.com/")]
    public class EnvisionWebService : SoapHttpClientProtocol
    {
        private string url = "{0}EnvisionWebService/Service.asmx";

        public EnvisionWebService(string host)
        {
            Url = string.Format(url, host);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/SavePicture",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool SavePicture(string fileName, byte[] fileIn)
        {
            return (bool)(((object[])Invoke("SavePicture", new object[] { fileName, fileIn }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/GetClientPort",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public int GetClientPort()
        {
            return (int)(((object[])Invoke("GetClientPort", new object[] { }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/KillClientSession",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void KillClientSession(string hostName)
        {
            Invoke("KillClientSession", new object[] { hostName });
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/ThaiToEng",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string ThaiToEng(string textThai)
        {
            return ((object[])Invoke("ThaiToEng", new object[] { textThai }))[0].ToString();
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/ThaiToEngSalutation",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public string ThaiToEngSalutation(string textThai)
        {
            return ((object[])Invoke("ThaiToEngSalutation", new object[] { textThai }))[0].ToString();
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/SaveClientLog",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool SaveClientLog(string caption, string message)
        {
            try
            {
                return (bool)(((object[])Invoke("SaveClientLog", new object[] { caption, message }))[0]);
            }
            catch{ return false; }
        }
    }
}
