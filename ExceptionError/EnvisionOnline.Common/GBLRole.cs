using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Reflection;

namespace EnvisionOnline.Common
{
    public class GBLRole
    {
        public int SubMenuID{get;set;}

        public string SubMenuUID { get; set; }

        public string SubMenuNameUser { get; set; }

        public int RoleID { get; set; }

        public int RoleDTLId { get; set; }

        public string RoleUID { get; set; }

        public string RoleDTLUID { get; set; }

        public string RoleName { get; set; }

        public string RoleDesc { get; set; }

        public string IsActive { get; set; }
        public string IsUpdated { get; set; }

        public string IsDeleted { get; set; }

        public string CanView { get; set; }

        public string CanModify { get; set; }

        public string CanCreate { get; set; }

        public string CanRemove { get; set; }

        public int OrgID { get; set; }
        public int CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public string ModifiedOn { get; set; }
    }
}
