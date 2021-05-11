using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Envision.Entity.Result.PeerReview;
using Envision.Business.Result.PeerReview;

namespace Envision.WebServices.Controllers.Result.PeerReview
{
    [RoutePrefix("peerstudy")]
    public class PeerStudyManageController : ApiController
    {
        IPeerManageStudyBusiness reviewBusiness;

        public PeerStudyManageController()
        {
            reviewBusiness = new PeerManageStudyBusiness();

        }
        
        [HttpPost]
        [Route("autoassign")]
        public object InsertPeerReviewReport([FromBody] dynamic para)
        {
            int actionType = Convert.ToInt32(para.ACTION_TYPE.Value);
            string fromDT = para.FROM_DT.Value;
            string toDT = para.TO_DATE.Value;
            int createdBy = Convert.ToInt32(para.CREATED_BY.Value);

            RIS_PRASSIGNMENT prModel = new RIS_PRASSIGNMENT();
            prModel.ACTION_TYPE = actionType;
            prModel.CREATED_ON = Convert.ToDateTime(fromDT);
            prModel.LAST_MODIFIED_ON = Convert.ToDateTime(toDT);
            prModel.CREATED_BY = createdBy;



            reviewBusiness.AutoPeerStudyAssignment(prModel);

            return 1;
        }

        [Route("{actiontype:int}")]
        public List<RIS_PRSUBSPECIALTY> GetAllSubSepecialty(int actiontype)
        {
            RIS_PRSUBSPECIALTY subSpecialty = new RIS_PRSUBSPECIALTY();
            return reviewBusiness.SelectPeerSubSpecialty(actiontype);

        }

        [Route("radiologist/{actiontype:int}/{subid:int}")]
        public List<PEER_RADIOLOGIST_MODEL> GetAllRadiologist(int actiontype, int subid)
        {
            return reviewBusiness.SelectPeerRadiologist(actiontype, subid);

        }

        [Route("radassignment/{actiontype:int}/{empid:int}/{subid:int}")]
        public List<PEER_REVIEW_WORKLIST_MODEL> GetAllRadAssignments(int actiontype, int empid, int subid)
        {
            return reviewBusiness.SelectPeerRadAssignments(actiontype, empid, subid);

        }

        [Route("studycount/{actiontype:int}")]
        public List<PEER_RADIOLOGIST_MODEL> GetAllRadAssignmentsCount(int actiontype)
        {
            return reviewBusiness.SelectPeerRadAssignmentsCount(actiontype);

        }

        [Route("assignmentdate/{actiontype:int}")]
        public List<PEER_REVIEW_ASSIGNMENT_MODEL> GetAllAssignmentsDate(int actiontype)
        {
            PEER_REVIEW_ASSIGNMENT_MODEL _model = new PEER_REVIEW_ASSIGNMENT_MODEL();
            _model.ACTION_TYPE = actiontype;
            _model.FROM_DATE = String.Empty;
            _model.TO_DATE = String.Empty;
            _model.SUBSPECIALTY_ID = 0;
            _model.EMP_ID = 0;
            return reviewBusiness.SelectAssgnmentDate(_model);

        }

        [HttpPost]
        [Route("reviewhistory")]
        public List<PEER_REVIEW_HISTORY_MODEL> GetReviewHistory([FromBody] dynamic para)
        {
            int actionType = Convert.ToInt32(para.ACTION_TYPE.Value);
            string fromDT = para.FROM_DATE.Value;
            string toDT = para.TO_DATE.Value;

            PEER_REVIEW_ASSIGNMENT_MODEL _model = new PEER_REVIEW_ASSIGNMENT_MODEL();
            _model.ACTION_TYPE = actionType;
            _model.FROM_DATE = fromDT;
            _model.TO_DATE = toDT;
            _model.SUBSPECIALTY_ID = 0;
            _model.EMP_ID = 0;

            return reviewBusiness.SelectReviewHistory(_model);
        }

        [HttpPost]
        [Route("reviewhistorydtl")]
        public List<PEER_REVIEW_WORKLIST_MODEL> GetReviewHistoryDtl([FromBody] dynamic para)
        {
            int actionType = Convert.ToInt32(para.ACTION_TYPE.Value);
            string fromDT = para.FROM_DATE.Value;
            string toDT = para.TO_DATE.Value;
            int subID = Convert.ToInt32(para.SUB_ID.Value);
            int empID = Convert.ToInt32(para.EMP_ID.Value);

            PEER_REVIEW_ASSIGNMENT_MODEL _model = new PEER_REVIEW_ASSIGNMENT_MODEL();
            _model.ACTION_TYPE = actionType;
            _model.FROM_DATE = fromDT;
            _model.TO_DATE = toDT;
            _model.SUBSPECIALTY_ID = subID;
            _model.EMP_ID = empID;

            return reviewBusiness.SelectReviewHistoryDtl(_model);
        }

        [Route("peeralgorithm")]
        public List<PEER_ALGORITHM_MODEL> GetPeerAlgorithm()
        {
            return reviewBusiness.SelectPeerAlgorithm();
        }

        [HttpPost]
        [Route("changesalgorithm")]
        public object PostPeerAlgorithm([FromBody] dynamic para)
        {
            int algorithmID = Convert.ToInt32(para.ALGORITHM_ID.Value);
            int valPer = Convert.ToInt32(para.VAL_PER.Value);
            int valMax = Convert.ToInt32(para.VAL_MAX.Value);

            PEER_ALGORITHM_MODEL _model = new PEER_ALGORITHM_MODEL();
            _model.PR_ALGORITHM_ID = algorithmID;
            _model.PERCENTAGE_PER_RAD = valPer;
            _model.MAX_ASSIGNMENT_PER_RAD = valMax;

            return reviewBusiness.SaveChangesAlgorithm(_model);
        }

    }
}
