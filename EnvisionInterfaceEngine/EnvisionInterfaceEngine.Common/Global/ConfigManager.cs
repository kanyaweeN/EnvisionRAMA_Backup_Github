using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace EnvisionInterfaceEngine.Common.Global
{
    public class ConfigManager
    {
        public static TypeCodeAccessionNoConfig GetTypeCodeAccessionNo { get { return (TypeCodeAccessionNoConfig)ConfigurationManager.GetSection("TypeCodeAccessionNoConfig"); } }
        public static string GetTypeCode(string modalityUid, string modalityTypeUid)
		{
			TypeCodeAccessionNoConfig config = GetTypeCodeAccessionNo;

			if (config == null)
				return null;

			IEnumerable<TypeCodeAccessionNoElement> query = config.Element.Cast<TypeCodeAccessionNoElement>().ToList().Where(party => party.ModalityUid == modalityUid);

            if (query.Count() > 0)
                return query.ElementAt<TypeCodeAccessionNoElement>(0).TypeCode;

            query = GetTypeCodeAccessionNo.Element.Cast<TypeCodeAccessionNoElement>().ToList().Where(party => party.ModalityTypeUid == modalityTypeUid);

            if (query.Count() > 0)
                return query.ElementAt<TypeCodeAccessionNoElement>(0).TypeCode;

            return null;
        }

        public static FacilityConfig GetFacility { get { return (FacilityConfig)ConfigurationManager.GetSection("FacilityConfig"); } }
        public static string GetFacilityName(string unitUid)
        {
			FacilityConfig config = GetFacility;

			if (config == null)
				return null;

			IEnumerable<FacilityElement> query = config.Element.Cast<FacilityElement>().ToList().Where(party => party.UnitUid == unitUid);
			
            return (query.Count() > 0) ? query.ElementAt<FacilityElement>(0).FacilityName : null;
        }

        public static BidirectionalNewOrderConfig GetBidirectionalNewOrder { get { return (BidirectionalNewOrderConfig)ConfigurationManager.GetSection("BidirectionalNewOrderConfig"); } }
        public static BidirectionalNewOrderElement GetBidirectionalNewOrderElement(int aeTitleId)
		{
			BidirectionalNewOrderConfig config = GetBidirectionalNewOrder;

			if (config == null)
				return null;

			IEnumerable<BidirectionalNewOrderElement> query = config.Element.Cast<BidirectionalNewOrderElement>().ToList().Where(party => party.AETitleId == aeTitleId);

            return (query.Count() > 0) ? query.ElementAt<BidirectionalNewOrderElement>(0) : null;
        }
    }
}