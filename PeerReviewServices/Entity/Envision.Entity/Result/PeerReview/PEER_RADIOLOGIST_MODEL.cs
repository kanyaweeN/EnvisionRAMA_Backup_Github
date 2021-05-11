using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity.Result.PeerReview
{
    public partial class PEER_RADIOLOGIST_MODEL
    {
        public PEER_RADIOLOGIST_MODEL()
        {
        }
        public int EMP_ID { get; set; }
        public string RAD_NAME { get; set; }
        public string GENDER { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string EMAIL { get; set; }
        public int STUDY_COUNT { get; set; }

    }
}
