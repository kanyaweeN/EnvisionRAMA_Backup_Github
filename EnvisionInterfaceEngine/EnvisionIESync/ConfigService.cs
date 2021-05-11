using System;
using System.Configuration;

namespace EnvisionIESync
{
    public class ConfigService
    {
        public static bool BypassProcessHL7ADT
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.BypassProcessHL7ADT"]); }
        }
        public static bool BypassProcessHL7ORM
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.BypassProcessHL7ORM"]); }
        }
        public static bool AllowHL7ORMBidirectionalNewOrder
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.AllowHL7ORMBidirectionalNewOrder"]); }
        }
        public static bool AllowUpdateReferenceUnit
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.AllowUpdateReferenceUnit"]); }
        }
        public static bool AllowUpdateReferringDoctor
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.AllowUpdateReferringDoctor"]); }
        }
        public static bool AllowUpdateExam
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.AllowUpdateExam"]); }
        }
        public static bool AllowAutoMappingModalityExam
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.AllowAutoMappingModalityExam"]); }
        }
        public static int DefaultOrgId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultOrgId"]); }
        }
        public static int DefaultLastModifiedBy
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultLastModifiedBy"]); }
        }
        public static int DefaultExamTypeId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultExamTypeId"]); }
        }
        public static string DefaultModalityTypeNameAlias
        {
            get { return ConfigurationManager.AppSettings["ConfigService.DefaultModalityTypeNameAlias"]; }
        }
		public static int DefaultBPId
		{
			get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultBPId"]); }
		}
		public static int DefaultBPViewId
		{
			get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultBPViewId"]); }
		}
        public static int DefaultServiceTypeId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultServiceTypeId"]); }
        }
        public static int DefaultUnitId
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.DefaultUnitId"]); }
		}
		public static bool AutoModifyModalityId
		{
			get { return Convert.ToBoolean(ConfigurationManager.AppSettings["ConfigService.AutoModifyModalityId"]); }
		}
		public static int UnknownModalityId
		{
			get { return Convert.ToInt32(ConfigurationManager.AppSettings["ConfigService.UnknownModalityId"]); }
		}
    }
}