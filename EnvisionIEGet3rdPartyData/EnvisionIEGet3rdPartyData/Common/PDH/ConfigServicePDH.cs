using System;
using System.Configuration;
using EnvisionIEGet3rdPartyData.Common.Global;

namespace EnvisionIEGet3rdPartyData.Common.PDH
{
    public class ConfigServicePDH
    {
		public static int SweepDelayMinTimes { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigServicePDH.SweepDelayMinTimes"]); } }
    }
}