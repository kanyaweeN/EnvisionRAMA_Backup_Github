using System;
using System.Configuration;

namespace EnvisionInterfaceEngine.Common.Global
{
    public class Config
    {
        public static string LogPath { get { return ConfigurationManager.AppSettings["LogPath"]; } }
        public static int TimeInterval { get { return Convert.ToInt32(ConfigurationManager.AppSettings["TimeInterval"]) * 1000; } }
        public static string ConnectionString { get { return ConfigurationManager.AppSettings["ConnectionString"]; } }
        public static string DomainWebService { get { return ConfigurationManager.AppSettings["DomainWebService"]; } }

        public static string AccessionNoNLS { get { return ConfigurationManager.AppSettings["AccessionNoNLS"]; } }
        public static string AccessionNoFormat { get { return ConfigurationManager.AppSettings["AccessionNoFormat"]; } }

        public static string HL7ADTQueuePath { get { return ConfigurationManager.AppSettings["HL7ADTQueuePath"]; } }
        public static string HL7ORMQueuePath { get { return ConfigurationManager.AppSettings["HL7ORMQueuePath"]; } }
        public static string HL7ORMBidirectionalQueuePath { get { return ConfigurationManager.AppSettings["HL7ORMBidirectionalQueuePath"]; } }
        public static string ADTByHNQueuePath { get { return ConfigurationManager.AppSettings["ADTByHNQueuePath"]; } }
        public static string ADTReconcileQueuePath { get { return ConfigurationManager.AppSettings["ADTReconcileQueuePath"]; } }
        public static string ORMByAccessionNoQueuePath { get { return ConfigurationManager.AppSettings["ORMByAccessionNoQueuePath"]; } }
        public static string ORMByOrderIdQueuePath { get { return ConfigurationManager.AppSettings["ORMByOrderIdQueuePath"]; } }
        public static string ORMBidirectionalByAccessionNoQueuePath { get { return ConfigurationManager.AppSettings["ORMBidirectionalByAccessionNoQueuePath"]; } }
        public static string ORMMergeByAccessionNoQueuePath { get { return ConfigurationManager.AppSettings["ORMMergeByAccessionNoQueuePath"]; } }
        public static string ORUByAccessionNoQueuePath { get { return ConfigurationManager.AppSettings["ORUByAccessionNoQueuePath"]; } }
    }
}