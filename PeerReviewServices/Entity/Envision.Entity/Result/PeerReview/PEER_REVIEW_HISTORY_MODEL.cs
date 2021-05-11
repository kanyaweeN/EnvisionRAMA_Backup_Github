using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity.Result.PeerReview
{
    public partial class PEER_REVIEW_HISTORY_MODEL
    {
        public PEER_REVIEW_HISTORY_MODEL()
        {
        }
        public int SUB_SPECIALTY_ID { get; set; }
        public string SUB_SPECIALTY_NAME { get; set; }
        public int EMP_ID { get; set; }
        public string RAD_NAME { get; set; }
        public int TOTAL { get; set; }
        public int REVIEWED { get; set; }
        public int PENDING { get; set; }

    }
}
