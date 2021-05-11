using System;
using System.Collections.Generic;

namespace Envision.Entity.Result.PeerReview
{
    public partial class RIS_PRASSIGNMENT
    {
        public RIS_PRASSIGNMENT()
        {
            
        }
        public int ACTION_TYPE { get; set; }

        public int ASSIGNMENT_ID { get; set; }
        
        public string ACCESSION_NO { get; set; }

        public int? EMP_ID { get; set; }

        public int? ORG_ID { get; set; }

        public int? CREATED_BY { get; set; }

        public DateTime? CREATED_ON { get; set; }

        public int? LAST_MODIFIED_BY { get; set; }

        public DateTime? LAST_MODIFIED_ON { get; set; }
        public string STATUS { get; set; }
       
    }
}
