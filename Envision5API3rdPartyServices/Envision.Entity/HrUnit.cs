using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class HrUnit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
        public string PhoneNo { get; set; }
        public string Desc { get; set; }
        public string UnitAlias { get; set; }
        public string UnitType { get; set; }
        public string UnitIns { get; set; }
        public bool? IsExternal { get; set; }
        public string Loc { get; set; }
        public bool? IsDeleted { get; set; }
        public string LocAlias { get; set; }
        public string UnitParentName { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public ICollection<RisExam> ExamList { get; set; }
    }
}
