using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.WebServices
{
    public class AppHelper
    {
        private const string TOKEN_KEY = "_APP_TOKEN_APP_";
        private const string USER_ID = "_APP_USER_ID_KEY_APP_";
        private const string ORG_ID = "_APP_ORG_ID_KEY_APP_";
        private const string IP_KEY = "_APP_IPADDRESS_KEY_APP_";

        public static string Token
        {
            get
            {
                return HttpContext.Current.Session[TOKEN_KEY] == null ? null : HttpContext.Current.Session[TOKEN_KEY].ToString();
            }
            set
            {
                HttpContext.Current.Session.Add(TOKEN_KEY, value);
            }
        }

        public static int? UserId
        {
            get
            {
                int? Id = null;
                if (HttpContext.Current.Session[USER_ID] != null)
                {
                    string key = HttpContext.Current.Session[USER_ID].ToString();
                    if (!string.IsNullOrEmpty(key)) Id = Convert.ToInt32(key);
                }

                return Id;
            }
            set
            {
                HttpContext.Current.Session.Add(USER_ID, value);
            }
        }

        public static int? OrgId
        {
            get
            {
                int? Id = null;
                if (HttpContext.Current.Session[ORG_ID] != null)
                {
                    string key = HttpContext.Current.Session[ORG_ID].ToString();
                    if (!string.IsNullOrEmpty(key)) Id = Convert.ToInt32(key);
                }

                return Id;
            }
            set
            {
                HttpContext.Current.Session.Add(ORG_ID, value);
            }
        }

        public static string ClientIP
        {
            get
            {
                return HttpContext.Current.Session[IP_KEY] == null ? null : HttpContext.Current.Session[IP_KEY].ToString();
            }
            set
            {
                HttpContext.Current.Session.Add(IP_KEY, value);
            }
        }
    }
}
