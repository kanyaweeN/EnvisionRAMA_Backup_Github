using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.Entity.Result.PeerReview;

namespace Envision.DataAccess.Result.PeerReview
{
    public interface IPeerReviewDataAccess
    {
        List<PEER_REVIEW_WORKLIST_MODEL> SelectPeerReviewWorklist(RIS_PRASSIGNMENT assignmentModel);
        List<PEER_REVIEW_SCORE_MODEL> SelectPeerReviewScore(RIS_PRASSIGNMENT assignmentModel);
        object InsertPeerReviewReport(PEER_REVIEW_MODEL peerModel);
        object InsertPeerReviewScore(PEER_REVIEW_MODEL peerModel);
        List<PEER_GBLENV_MODEL> SelectPeerGblEnv(int orgId);
    }
}
