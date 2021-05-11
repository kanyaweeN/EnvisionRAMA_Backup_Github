using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.Entity.Result.PeerReview;

namespace Envision.Business.Result.PeerReview
{ 
    public interface IPeerManageStudyBusiness
    {
        object AutoPeerStudyAssignment(RIS_PRASSIGNMENT assignModel);
        List<RIS_PRSUBSPECIALTY> SelectPeerSubSpecialty(int actionType);
        List<PEER_RADIOLOGIST_MODEL> SelectPeerRadiologist(int actionType, int subspecialtyId);
        List<PEER_REVIEW_WORKLIST_MODEL> SelectPeerRadAssignments(int actionType, int empId, int subId);
        List<PEER_RADIOLOGIST_MODEL> SelectPeerRadAssignmentsCount(int actionType);
        List<PEER_REVIEW_ASSIGNMENT_MODEL> SelectAssgnmentDate(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel);
        List<PEER_REVIEW_HISTORY_MODEL> SelectReviewHistory(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel);
        List<PEER_REVIEW_WORKLIST_MODEL> SelectReviewHistoryDtl(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel);
        List<PEER_ALGORITHM_MODEL> SelectPeerAlgorithm();
        object SaveChangesAlgorithm(PEER_ALGORITHM_MODEL algorithmModel);
    }
}
