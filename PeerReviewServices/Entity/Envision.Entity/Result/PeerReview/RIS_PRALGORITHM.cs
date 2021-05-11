
using System;
using System.Collections.Generic;

namespace Envision.Entity.Result.PeerReview
{
    public partial class RIS_PRALGORITHM
    {
   
        public int PR_ALGORITHM_ID { get; set; }

        public string ALGORITHM_TEXT { get; set; }

        public string LOGIC { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
        public string PERIOD { get; set; }

        public int? PERCENTAGE_PER_SUBSPECIALTY { get; set; }

        public int? MAX_PER_SUBSPECIALTY { get; set; }

        public int? PERCENTAGE_PER_RAD { get; set; }

        public int? MAX_CASE_PER_MONTH { get; set; }

        public int? MAX_ASSIGNMENT_PER_RAD { get; set; }
    }
}
