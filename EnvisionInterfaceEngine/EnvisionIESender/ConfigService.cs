using System;
using System.Configuration;

namespace EnvisionIESender
{
    public class ConfigService
    {
        public static int InvestigationServiceTypeId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.InvestigationServiceTypeId"]); }
        }
    }
}
