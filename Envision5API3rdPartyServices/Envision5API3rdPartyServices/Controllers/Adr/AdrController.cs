using System;
using System.Collections.Generic;
using Envision.BusinessLogic.Adr;
using Envision.Entity.Adr;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Envision5API3rdPartyServices.Controllers.Adr
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdrController : ControllerBase
    {
        [HttpPost]
        [Route("GetAdr")]
        public AdrResponse GetAdr(string paraString, string mode, string mrn, string code)
        {
            try
            {
                AdrComponent adrResult = new AdrComponent();
                List<AdrData> _result = adrResult.SearchAdrByMode(mode, mrn, code);

                return new AdrResponse()
                {
                    code = 200,
                    message = "Success",
                    resultJson = _result
                };
            }
            catch (Exception ex)
            {
                return new AdrResponse()
                {
                    code = 200,
                    message = "Error : " + ex.Message
                };
            }
        }

        [HttpPost]
        [Route("searchAdrByMrn")]
        public AdrResponse searchAdrByMrn([FromBody] dynamic para)
        {
            var requestValue = JsonConvert.DeserializeObject<object>(para.ToString());
            if (string.IsNullOrEmpty(requestValue.Mrn.Value.ToString()))
            {
                return new AdrResponse()
                {
                    code = 500,
                    message = "Mrn is Empty",
                    resultJson = null,
                };
            }

            return this.GetAdr(para.ToString(), "Mrn", requestValue.Mrn.Value.ToString(), "");
        }
        [HttpPost]
        [Route("searchAdrByMrnAndCode")]
        public AdrResponse searchAdrByMrnAndCode([FromBody] dynamic para)
        {
            var requestValue = JsonConvert.DeserializeObject<object>(para.ToString());
            if (string.IsNullOrEmpty(requestValue.Mrn.Value.ToString()))
            {
                return new AdrResponse()
                {
                    code = 500,
                    message = "Mrn is Empty",
                    resultJson = null,
                };
            }
            if (string.IsNullOrEmpty(requestValue.Code.Value.ToString()))
            {
                return new AdrResponse()
                {
                    code = 500,
                    message = "Code is Empty",
                    resultJson = null,
                };
            }

            return this.GetAdr(para.ToString(),"MrnAndCode", requestValue.Mrn.Value.ToString(), requestValue.Code.Value.ToString());
        }
    }
}