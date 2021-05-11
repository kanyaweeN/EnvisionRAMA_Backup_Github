using System;
using System.Collections.Generic;

namespace Envision.Entity.Result.PeerReview
{
    public partial class RIS_PRRADMAPPING
    {
       
        public int RADMAPPING_ID { get; set; }

        public int? EMP_ID { get; set; }

        public int? SUB_SPECIALTY_ID { get; set; }

        public int? MAX_CASE_PER_MONTH { get; set; }

        public string ALLOW_PEER_REVIEW { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }

        public virtual RIS_PRSUBSPECIALTY RIS_PRSUBSPECIALTY { get; set; }
    }
}
