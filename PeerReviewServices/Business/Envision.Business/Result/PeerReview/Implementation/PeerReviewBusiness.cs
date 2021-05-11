using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.Business.Result.PeerReview;
using Envision.DataAccess.Result.PeerReview;
using Envision.Entity.Result.PeerReview;

namespace Envision.Business.Result.PeerReview
{
    public class PeerReviewBusiness : IPeerReviewBusiness
    {
        IPeerReviewDataAccess _dataAccess;
        public PeerReviewBusiness()
        {
            _dataAccess = new PeerReviewDataAccess();
        }

        public List<PEER_REVIEW_WORKLIST_MODEL> SelectPeerReviewWorklist(RIS_PRASSIGNMENT assignmentModel)
        {
            return _dataAccess.SelectPeerReviewWorklist(assignmentModel);
        }

        public List<PEER_REVIEW_SCORE_MODEL> SelectPeerReviewScore(RIS_PRASSIGNMENT assignmentModel)
        {
            return _dataAccess.SelectPeerReviewScore(assignmentModel);
        }

        public object InsertPeerReviewReport(Envision.Entity.Result.PeerReview.PEER_REVIEW_MODEL peerModel)
        {
            return _dataAccess.InsertPeerReviewReport(peerModel);
        }
        public object InsertPeerReviewScore(Envision.Entity.Result.PeerReview.PEER_REVIEW_MODEL peerModel)
        {
            return _dataAccess.InsertPeerReviewScore(peerModel);
        }

        public List<PEER_GBLENV_MODEL> SelectPeerGblEnv(int orgId)
        {
            return _dataAccess.SelectPeerGblEnv(orgId);
        }
    }
}