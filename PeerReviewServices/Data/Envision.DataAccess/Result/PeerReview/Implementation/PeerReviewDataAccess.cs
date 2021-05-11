using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.DataAccess.Result.PeerReview;
using Envision.Entity.Result.PeerReview;
using System.Data.SqlClient;
using Envision.Database;

namespace Envision.DataAccess.Result.PeerReview
{
    public class PeerReviewDataAccess  : IPeerReviewDataAccess
    {
        public PeerReviewDataAccess()
        {

        }
        public List<PEER_REVIEW_WORKLIST_MODEL> SelectPeerReviewWorklist(Envision.Entity.Result.PeerReview.RIS_PRASSIGNMENT assignmentModel)
        {
            using (var context = new EnvisionDataModel())
            {
                //var clientIdParameter = new SqlParameter("@MY_ID", assignmentModel.EMP_ID);
                SqlParameter[] parameters =
                {
                    new SqlParameter("@MY_ID", assignmentModel.EMP_ID)             

                };
                var result = context.Database.SqlQuery<PEER_REVIEW_WORKLIST_MODEL>("PRC_PEERREVIEW_WORKLIST @MY_ID", parameters).ToList();
                return result;
            }

            
        }

        public List<PEER_REVIEW_SCORE_MODEL> SelectPeerReviewScore(Envision.Entity.Result.PeerReview.RIS_PRASSIGNMENT assignmentModel)
        {
            using (var context = new EnvisionDataModel())
            {
                //var clientIdParameter = new SqlParameter("@MY_ID", assignmentModel.EMP_ID);
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ASSIGNMENT_ID", assignmentModel.ASSIGNMENT_ID)

                };
                var result = context.Database.SqlQuery<PEER_REVIEW_SCORE_MODEL>("PRC_PEERREVIEW_SCORE @ASSIGNMENT_ID", parameters).ToList();
                return result;
            }


        }

        public object InsertPeerReviewReport(Envision.Entity.Result.PeerReview.PEER_REVIEW_MODEL peerModel)
        {
            using (var context = new EnvisionDataModel())
            {
                //var clientIdParameter = new SqlParameter("@MY_ID", assignmentModel.EMP_ID);
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", peerModel.ACTION_TYPE),
                    new SqlParameter("@ASSIGNMENT_ID", peerModel.ASSIGNMENT_ID),
                    new SqlParameter("@REPORT_TEXT_HTML", peerModel.REPORT_TEXT_HTML),
                    new SqlParameter("@REPORT_STATUS", peerModel.REPORT_STATUS),
                    new SqlParameter("@REVIEW_SCORE", "1"),
                    new SqlParameter("@COMMENT", ""),
                    new SqlParameter("@CREATED_BY", peerModel.CREATED_BY)



                };
                var result = context.Database.ExecuteSqlCommand("exec PRC_PEERREVIEW_INSERT @ACTION_TYPE, @ASSIGNMENT_ID, @REPORT_TEXT_HTML, @REPORT_STATUS, @REVIEW_SCORE, @COMMENT, @CREATED_BY", parameters);
                return result;
            }


        }

        public object InsertPeerReviewScore(Envision.Entity.Result.PeerReview.PEER_REVIEW_MODEL peerModel)
        {
            using (var context = new EnvisionDataModel())
            {
                //var clientIdParameter = new SqlParameter("@MY_ID", assignmentModel.EMP_ID);
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", peerModel.ACTION_TYPE),
                    new SqlParameter("@ASSIGNMENT_ID", peerModel.ASSIGNMENT_ID),
                    new SqlParameter("@REPORT_TEXT_HTML", peerModel.REPORT_TEXT_HTML),
                    new SqlParameter("@REPORT_STATUS", peerModel.REPORT_STATUS),
                    new SqlParameter("@REVIEW_SCORE", peerModel.REVIEW_SCORE),
                    new SqlParameter("@COMMENT", peerModel.COMMENT),
                    new SqlParameter("@CREATED_BY", peerModel.CREATED_BY)



                };
                var result = context.Database.ExecuteSqlCommand("exec PRC_PEERREVIEW_INSERT @ACTION_TYPE, @ASSIGNMENT_ID, @REPORT_TEXT_HTML, @REPORT_STATUS, @REVIEW_SCORE, @COMMENT, @CREATED_BY", parameters);
                return result;
            }

        }

        public List<PEER_GBLENV_MODEL> SelectPeerGblEnv(int orgId)
        {
            PEER_GBLENV_MODEL model ;
            List<PEER_GBLENV_MODEL> itemList = null;
            using (var context = new EnvisionDataModel())
            {
                var itemSearch = (from data in context.GBL_ENV
                                  where data.ORG_ID == orgId
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<PEER_GBLENV_MODEL>();
                    foreach (var obj in itemSearch)
                    {
                        model = new PEER_GBLENV_MODEL();
                        model.ORG_ID = obj.ORG_ID;
                        model.ORG_NAME = obj.ORG_NAME;
                        model.PACS_URL1 = obj.PACS_URL1;
                        itemList.Add(model);
                    }                        
                }
            }
            return itemList;
         }

        
    }
}
