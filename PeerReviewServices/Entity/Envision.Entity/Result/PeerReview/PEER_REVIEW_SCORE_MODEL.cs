using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Entity.Result.PeerReview
{
    public partial class PEER_REVIEW_SCORE_MODEL
    {
        public PEER_REVIEW_SCORE_MODEL()
        {
        }
        public string ACCESSION_NO { get; set; }
        public string RESULT_TEXT_HTML { get; set; }
        public string RESULT_TEXT_RTF { get; set; }
        public int ASSIGNMENT_ID { get; set; }
        public string REVIEW_SCORE { get; set; }
        public string COMMENT { get; set; }
        public string REPORT_TEXT_HTML { get; set; }
        public string REPORT_STATUS { get; set; }       

    }
}
