using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.DataAccess.Result.PeerReview;
using Envision.Entity.Result.PeerReview;

namespace Envision.Business.Result.PeerReview
{
    public class PeerManageStudyBusiness : IPeerManageStudyBusiness
    {
        IPeerManageStudyDataAccess _dataAccess;
        public PeerManageStudyBusiness()
        {
            _dataAccess = new PeerManageStudyDataAccess();
        }

        public object AutoPeerStudyAssignment(Envision.Entity.Result.PeerReview.RIS_PRASSIGNMENT assignModel)
        {
            return _dataAccess.AutoPeerStudyAssignment(assignModel);
        }

        public List<RIS_PRSUBSPECIALTY> SelectPeerSubSpecialty(int actionType)
        {
            return _dataAccess.SelectPeerSubSpecialty(actionType);
        }

        public List<PEER_RADIOLOGIST_MODEL> SelectPeerRadiologist(int actionType, int subspecialtyId)
        {
            return _dataAccess.SelectPeerRadiologist(actionType, subspecialtyId);
        }

        public List<PEER_REVIEW_WORKLIST_MODEL> SelectPeerRadAssignments(int actionType, int empId, int subId)
        {
            return _dataAccess.SelectPeerRadAssignments(actionType, empId, subId);
        }

        public List<PEER_RADIOLOGIST_MODEL> SelectPeerRadAssignmentsCount(int actionType)
        {
            return _dataAccess.SelectPeerRadAssignmentsCount(actionType);
        }

        public List<PEER_REVIEW_ASSIGNMENT_MODEL> SelectAssgnmentDate(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel)
        {
            return _dataAccess.SelectAssgnmentDate(assignmentModel);
        }

        public List<PEER_REVIEW_HISTORY_MODEL> SelectReviewHistory(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel)
        {
            return _dataAccess.SelectReviewHistory(assignmentModel);
        }

        public List<PEER_REVIEW_WORKLIST_MODEL> SelectReviewHistoryDtl(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel)
        {
            return _dataAccess.SelectReviewHistoryDtl(assignmentModel);
        }

        public List<PEER_ALGORITHM_MODEL> SelectPeerAlgorithm()
        {
            return _dataAccess.SelectPeerAlgorithm();
        }

        public object SaveChangesAlgorithm(PEER_ALGORITHM_MODEL algorithmModel)
        {
            return _dataAccess.SaveChangesAlgorithm(algorithmModel);
        }
    }
}
