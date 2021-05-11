using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class RisClinicSession
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string AliasName { get; set; }
        public int? TypeId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public byte? SL { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsOnline { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public RisClinicType ClinicType { get; set; }
    }
}
