using System;
using System.Configuration;
using EnvisionIEGet3rdPartyData.Common.Global;

namespace EnvisionIEGet3rdPartyData.Common.HOSxP
{
    public class ConfigServiceHOSxP
    {
        public static bool UseLegacyVersion { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigServiceHOSxP.UseLegacyVersion"]); } }
		public static int HNLength { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigServiceHOSxP.HNLength"]); } }
		public static bool HNKeepPrefix { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigServiceHOSxP.HNKeepPrefix"]); } }
        public static int SweepDelayMinTimes { get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigServiceHOSxP.SweepDelayMinTimes"]); } }
        public static bool SweepOrderVerifyPatientXn { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigServiceHOSxP.SweepOrderVerifyPatientXn"]); } }
        public static bool SweepOrderVerifyConfirm { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigServiceHOSxP.SweepOrderVerifyConfirm"]); } }
        public static bool ExamWithPosition { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigServiceHOSxP.ExamWithPosition"]); } }
        public static bool RecordOperator { get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigServiceHOSxP.RecordOperator"]); } }
        
        public static char GetPriorityStatus(string priorityUid) { return ConfigManager.GetPriorityStatus(priorityUid); }
    }
}