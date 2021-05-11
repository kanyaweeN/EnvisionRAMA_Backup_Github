using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity.Result.PeerReview
{
    public partial class PEER_REVIEW_ASSIGNMENT_MODEL
    {
        public PEER_REVIEW_ASSIGNMENT_MODEL()
        {
        }
        public int ACTION_TYPE { get; set; }
        public string FROM_DATE { get; set; }
        public string TO_DATE { get; set; }
        public int SUBSPECIALTY_ID { get; set; }
        public int EMP_ID { get; set; }
        public int TOTAL_STUDY { get; set; }
        public string ASSIGNMENT_DATE { get; set; }    

    }
}
