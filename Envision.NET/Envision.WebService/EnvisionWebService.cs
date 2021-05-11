using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;

namespace Envision.WebService
{
    [WebServiceBindingAttribute(Name = "ServiceSoap", Namespace = "http://www.miracleadvance.com/")]
    public class EnvisionWebService : SoapHttpClientProtocol
    {
        private string url = "{0}EnvisionWebService/Service.asmx";

        public EnvisionWebService(string host)
        {
            Url = string.Format(url, host);
            //Url = "http://localhost:23146/Service.asmx";
        }
        public EnvisionWebService(string host, bool is_old)
        {
            Url = string.Format("{0}EnvisionWebServiceNew/Service.asmx", host);
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

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/SaveFile",
                    RequestNamespace = "http://www.miracleadvance.com/",
                    ResponseNamespace = "http://www.miracleadvance.com/",
                    Use = SoapBindingUse.Literal,
                    ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool SaveFile(string fileName, byte[] fileIn)
        {
            return (bool)(((object[])Invoke("SaveFile", new object[] { fileName, fileIn }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/MoveFile",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool MoveFile(string sourceFileName, string destFileName)
        {
            return (bool)(((object[])Invoke("MoveFile", new object[] { sourceFileName, destFileName }))[0]);
        }

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/DeleteFile",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool DeleteFile(string fileName)
        {
            return (bool)(((object[])Invoke("DeleteFile", new object[] { fileName }))[0]);
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

        [SoapDocumentMethodAttribute("http://www.miracleadvance.com/SentClientSession",
            RequestNamespace = "http://www.miracleadvance.com/",
            ResponseNamespace = "http://www.miracleadvance.com/",
            Use = SoapBindingUse.Literal,
            ParameterStyle = SoapParameterStyle.Wrapped)]
        public void SentClientSession(string hostName, string msg)
        {
            Invoke("SentClientSession", new object[] { hostName, msg });
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
            catch { return false; }
        }
    }
}
