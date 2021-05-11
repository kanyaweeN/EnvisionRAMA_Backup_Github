using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity
{
    public class RisAuthLevel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Desc { get; set; }
        public string Text { get; set; }
        public byte? SL { get; set; }
        public int? OrgId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
