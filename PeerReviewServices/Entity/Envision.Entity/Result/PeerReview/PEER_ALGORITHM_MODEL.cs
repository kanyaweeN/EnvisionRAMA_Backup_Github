using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity.Result.PeerReview
{
    public partial class PEER_ALGORITHM_MODEL
    {
        public PEER_ALGORITHM_MODEL()
        {
        }
        public int PR_ALGORITHM_ID { get; set; }
        public int PERCENTAGE_PER_RAD { get; set; }
        public int MAX_ASSIGNMENT_PER_RAD { get; set; }

    }
}
