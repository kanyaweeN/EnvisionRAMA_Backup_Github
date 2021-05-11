using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity.Result.PeerReview
{
    public partial class PEER_REVIEW_MODEL
    {
        public PEER_REVIEW_MODEL()
        {
        }
        public int ACTION_TYPE { get; set; }
        public int ASSIGNMENT_ID { get; set; }
        public string REPORT_TEXT_HTML { get; set; }
        public string REPORT_STATUS { get; set; }
        public string REVIEW_SCORE { get; set; }
        public string COMMENT { get; set; }
        public int @CREATED_BY { get; set; }
    
    }
}
