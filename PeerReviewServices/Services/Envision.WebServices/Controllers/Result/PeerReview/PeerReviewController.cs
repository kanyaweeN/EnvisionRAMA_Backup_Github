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
    [RoutePrefix("peerreview")]
    public class PeerReviewController : ApiController
    {
        IPeerReviewBusiness reviewBusiness;

        public PeerReviewController()
        {
            reviewBusiness = new PeerReviewBusiness();

        }
        [Route("{myid:int}")]
        public List<PEER_REVIEW_WORKLIST_MODEL> GetPeerReviewWorklist(int myid)
        {
            RIS_PRASSIGNMENT myWL = new RIS_PRASSIGNMENT();
            myWL.EMP_ID = myid;
            return reviewBusiness.SelectPeerReviewWorklist(myWL);

        }

        [Route("score/{assignid:int}")]
        public List<PEER_REVIEW_SCORE_MODEL> GetPeerReviewScore(int assignid)
        {
            RIS_PRASSIGNMENT myWL = new RIS_PRASSIGNMENT();
            myWL.ASSIGNMENT_ID = assignid;
            List<PEER_REVIEW_SCORE_MODEL> pScore = reviewBusiness.SelectPeerReviewScore(myWL);
            foreach (PEER_REVIEW_SCORE_MODEL pEER_REVIEW_SCORE in pScore)
            {
                Operational.Translator.TransRtf tran = new Operational.Translator.TransRtf(pEER_REVIEW_SCORE.RESULT_TEXT_RTF);
                pEER_REVIEW_SCORE.RESULT_TEXT_HTML = tran.Translator()
                    .Replace("<img	src=\"none\" />", string.Empty)
                    .Replace(@"\X000d\", "<br>");
            }
            return pScore;
        }

        [HttpPost]
        [Route("report")]
        public object InsertPeerReviewReport([FromBody] dynamic para)
        {
            int actionType = Convert.ToInt32(para.ACTION_TYPE.Value);
            int assignId = Convert.ToInt32(para.ASSIGNMENT_ID.Value);
            int createdBy = Convert.ToInt32(para.CREATED_BY.Value);
            string status = para.REPORT_STATUS.Value;
            string report = para.REPORT_TEXT_HTML.Value;

            PEER_REVIEW_MODEL prModel = new PEER_REVIEW_MODEL();
            prModel.ACTION_TYPE = actionType;
            prModel.ASSIGNMENT_ID = assignId;
            prModel.CREATED_BY = createdBy;
            prModel.REPORT_STATUS = status;
            prModel.REPORT_TEXT_HTML = report;

            reviewBusiness.InsertPeerReviewReport(prModel);

            return 1;
        }

        [HttpPost]
        [Route("score")]
        public object InsertPeerReviewScore([FromBody] dynamic para)
        {
            int actionType = Convert.ToInt32(para.ACTION_TYPE.Value);
            int assignId = Convert.ToInt32(para.ASSIGNMENT_ID.Value);
            int createdBy = Convert.ToInt32(para.CREATED_BY.Value);
            string score = para.REVIEW_SCORE.Value;
            string comment = para.COMMENT.Value;

            PEER_REVIEW_MODEL prModel = new PEER_REVIEW_MODEL();
            prModel.ACTION_TYPE = actionType;
            prModel.ASSIGNMENT_ID = assignId;
            prModel.CREATED_BY = createdBy;
            prModel.REPORT_STATUS = "";
            prModel.REPORT_TEXT_HTML = "";
            prModel.REVIEW_SCORE = score;
            if (comment == null)
                prModel.COMMENT = "";
            else
                prModel.COMMENT = comment;

            reviewBusiness.InsertPeerReviewScore(prModel);

            return 1;
        }

        [Route("gblenv/{orgid:int}")]
        public List<PEER_GBLENV_MODEL> GetPeerGblEnv(int orgid)
        {           
            return reviewBusiness.SelectPeerGblEnv(orgid);
        }
    }
}
