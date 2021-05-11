using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity.Result.PeerReview
{
   public partial class PEER_REVIEW_WORKLIST_MODEL
    {
        public PEER_REVIEW_WORKLIST_MODEL()
        {
        }
            public int ASSIGNMENT_ID { get; set; }
            public string HN { get; set; }
            public string PATIENT_NAME { get; set; }
            public string ACCESSION_NO { get; set; }
            public string EXAM_NAME { get; set; }
            public DateTime ORDER_DT { get; set; }
            public string TYPE_NAME_ALIAS { get; set; }
            public string REVIEW_SCORE { get; set; }
            public string STATUS { get; set; }
            public string IS_COMMENTED { get; set; }
            public string COMMENT { get; set; }
            public Nullable<System.DateTime> REVIEW_DT { get; set; }



    }
}
