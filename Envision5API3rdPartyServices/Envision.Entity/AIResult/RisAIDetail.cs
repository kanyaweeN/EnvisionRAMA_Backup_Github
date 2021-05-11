using System;
using System.Collections.Generic;
using System.Text;

namespace Envision.Entity.AIResult
{
    public class RisAIDetail
    {
        public int AiId { get; set; }
        public string Hn { get; set; }
        public string AccessionNo { get; set; }
        public decimal DetectValues { get; set; }
        public string Remark { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
