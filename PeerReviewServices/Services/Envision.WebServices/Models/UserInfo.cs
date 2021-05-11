using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Envision.WebServices.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public string Token { get; set; }
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public MenuInfo[] UserMenu { get; set; }
        public string Themes { get; set; }
        public string MenuLayout { get; set; }
        public string ProfileLayout { get; set; }
        public string ImagePath { get; set; }
        public bool IsLayoutCompact { get; set; }
        public bool IsDaskMenu { get; set; }
    }
}