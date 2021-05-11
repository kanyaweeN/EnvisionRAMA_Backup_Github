using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace EnvisionIEGet3rdPartyData.Common.Global
{
    public class ConfigManager
    {
        public static PriorityConfig GetPriority { get { return (PriorityConfig)ConfigurationManager.GetSection("PriorityConfig"); } }
        public static char GetPriorityStatus(string priorityUid)
        {
            IEnumerable<PriorityElement> query = GetPriority.Element.Cast<PriorityElement>().ToList().Where(party => party.PriorityUid == priorityUid);

            return (query.Count() > 0) ? query.ElementAt<PriorityElement>(0).PriorityStatus : 'R';
        }
    }
}