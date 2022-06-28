using Envision.Operational.Configs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Envision5API3rdPartyServices.Middleware
{
    public class AppSettingMiddleware
    {
        private readonly RequestDelegate _next;
        public AppSettingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IOptions<EnvisionConfig> config, IOptions<ThirdPartyConfig> config3rd)
        {
            EnvisionConfig _config = config.Value;
            ThirdPartyConfig _config3rd = config3rd.Value;
            await _next.Invoke(context);
        }
    }
}
