using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class RisClinicType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public string AliasName { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsActive { get; set; }
        public decimal? RateIncrease { get; set; }
        public int? SL { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }

        public ICollection<RisClinicSession> ClinicSessionList { get; set; }
    }
}
