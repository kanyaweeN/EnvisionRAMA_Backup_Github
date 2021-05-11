using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Envision.BusinessLogic.AIResult;
using Envision.Entity.AIResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Envision5API3rdPartyServices.Controllers.AIResult
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIResultController : ControllerBase
    {
        [HttpPost]
        [Route("TestAIDetail")]
        public AIResponse TestAIDetail(DetectData detectData, string paraString)
        {
            if (string.IsNullOrEmpty(detectData.hn))
            {
                return new AIResponse()
                {
                    code = 500,
                    message = "HN is Empty."
                };
            }
            if (string.IsNullOrEmpty(detectData.accession_no))
            {
                return new AIResponse()
                {
                    code = 500,
                    message = "Accession is Empty."
                };
            }

            try
            {

                AIResultComponent aIResult = new AIResultComponent();
                aIResult.Item.Hn = detectData.hn;
                aIResult.Item.AccessionNo = detectData.accession_no;
                aIResult.Item.DetectValues = detectData.detectos_value;
                aIResult.Item.Remark = paraString;
                RisAIDetail aIDetail = aIResult.GetByAccession();

                if (aIDetail != null)
                {
                    aIResult.Update();
                }
                else
                {
                    aIResult.Add();
                }
                return new AIResponse()
                {
                    code = 200,
                    message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new AIResponse()
                {
                    code = 200,
                    message = "Error : " + ex.Message
                };
            }
        }
        [HttpPost]
        [Route("SetAIDetail")]
        public AIResponse SetAIDetail([FromBody] dynamic para)
        {
            var detectData = JsonConvert.DeserializeObject<DetectData>(para.ToString());
            return this.TestAIDetail(detectData, para.ToString());
        }
    }
}
