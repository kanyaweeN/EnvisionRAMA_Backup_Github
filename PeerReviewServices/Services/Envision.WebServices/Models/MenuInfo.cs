using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.WebServices.Models
{
    public class SubMenuInfo {
        public string label { get; set; }
        public string icon { get; set; }
        public string[] routerLink { get; set; }
    }
    public class MenuInfo
    {
        public string label { get; set; }
        public string icon { get; set; }
        public string[] routerLink { get; set; }

        public SubMenuInfo[] items;
    }
}