using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Envision.Entity.Result.PeerReview;
using System.Data.SqlClient;
using Envision.Database;

namespace Envision.DataAccess.Result.PeerReview
{
    public class PeerManageStudyDataAccess : IPeerManageStudyDataAccess
    {
        public PeerManageStudyDataAccess()
        {
        }
        public object AutoPeerStudyAssignment(Envision.Entity.Result.PeerReview.RIS_PRASSIGNMENT assignModel)
        {
            using (var context = new EnvisionDataModel())
            {
                //var clientIdParameter = new SqlParameter("@MY_ID", assignmentModel.EMP_ID);
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", assignModel.ACTION_TYPE),
                    new SqlParameter("@FROM_DT", assignModel.CREATED_ON),
                    new SqlParameter("@TO_DT", assignModel.LAST_MODIFIED_ON),
                    new SqlParameter("@CREATED_BY", assignModel.CREATED_BY)
                };
                var result = context.Database.ExecuteSqlCommand("exec PRC_PEERAUTOMATIC_ASSIGNMENT @ACTION_TYPE, @FROM_DT, @TO_DT, @CREATED_BY", parameters);
                return result;
            }
            
        }

        public List<Envision.Entity.Result.PeerReview.RIS_PRSUBSPECIALTY> SelectPeerSubSpecialty(int actionType)
        {
            using (var context = new EnvisionDataModel())
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", actionType),
                    new SqlParameter("@SUB_SPECIALTY_ID", 1),
                    new SqlParameter("@EMP_ID", 1)

                };

                var result = context.Database.SqlQuery<Envision.Entity.Result.PeerReview.RIS_PRSUBSPECIALTY>("PRC_PEERREVIEW_ASSIGN_HISTORY @ACTION_TYPE, @SUB_SPECIALTY_ID,@EMP_ID", parameters).ToList();
                return result;
            }
            
        }

        public List<PEER_RADIOLOGIST_MODEL> SelectPeerRadiologist(int actionType, int subspecialtyId)
        {
            using (var context = new EnvisionDataModel())
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", actionType),
                    new SqlParameter("@SUB_SPECIALTY_ID", subspecialtyId),
                    new SqlParameter("@EMP_ID", 1)

                };

                var result = context.Database.SqlQuery<Envision.Entity.Result.PeerReview.PEER_RADIOLOGIST_MODEL>("PRC_PEERREVIEW_ASSIGN_HISTORY @ACTION_TYPE, @SUB_SPECIALTY_ID,@EMP_ID", parameters).ToList();
                return result;
            }
            
        }

        public List<PEER_REVIEW_WORKLIST_MODEL> SelectPeerRadAssignments(int actionType, int empId, int subId)
        {
            using (var context = new EnvisionDataModel())
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", actionType),
                    new SqlParameter("@SUB_SPECIALTY_ID", subId),
                    new SqlParameter("@EMP_ID", empId)

                };

                var result = context.Database.SqlQuery<Envision.Entity.Result.PeerReview.PEER_REVIEW_WORKLIST_MODEL>("PRC_PEERREVIEW_ASSIGN_HISTORY @ACTION_TYPE, @SUB_SPECIALTY_ID,@EMP_ID", parameters).ToList();
                return result;
            }            
        }

        public List<PEER_RADIOLOGIST_MODEL> SelectPeerRadAssignmentsCount(int actionType)
        {
            using (var context = new EnvisionDataModel())
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", actionType),
                    new SqlParameter("@SUB_SPECIALTY_ID", 1),
                    new SqlParameter("@EMP_ID", 1)

                };

                var result = context.Database.SqlQuery<Envision.Entity.Result.PeerReview.PEER_RADIOLOGIST_MODEL>("PRC_PEERREVIEW_ASSIGN_HISTORY @ACTION_TYPE, @SUB_SPECIALTY_ID,@EMP_ID", parameters).ToList();
                return result;
            }

        }

        public List<PEER_REVIEW_ASSIGNMENT_MODEL> SelectAssgnmentDate(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel)
        {
            using (var context = new EnvisionDataModel())
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", assignmentModel.ACTION_TYPE),
                    new SqlParameter("@FROM_DATE", assignmentModel.FROM_DATE),
                    new SqlParameter("@TO_DATE", assignmentModel.TO_DATE),
                    new SqlParameter("@SUBSPECIALTY_ID", assignmentModel.SUBSPECIALTY_ID),
                    new SqlParameter("@EMP_ID", assignmentModel.EMP_ID)

                };

                var result = context.Database.SqlQuery<Envision.Entity.Result.PeerReview.PEER_REVIEW_ASSIGNMENT_MODEL>("PRC_PEERREVIEW_HISTORY @ACTION_TYPE, @FROM_DATE, @TO_DATE, @SUBSPECIALTY_ID, @EMP_ID", parameters).ToList();
                return result;
            }

        }

        public List<PEER_REVIEW_HISTORY_MODEL> SelectReviewHistory(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel)
        {
            using (var context = new EnvisionDataModel())
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", assignmentModel.ACTION_TYPE),
                    new SqlParameter("@FROM_DATE", Convert.ToDateTime(assignmentModel.FROM_DATE)),
                    new SqlParameter("@TO_DATE", Convert.ToDateTime(assignmentModel.TO_DATE)),
                    new SqlParameter("@SUBSPECIALTY_ID", assignmentModel.SUBSPECIALTY_ID),
                    new SqlParameter("@EMP_ID", assignmentModel.EMP_ID)

                };

                var result = context.Database.SqlQuery<Envision.Entity.Result.PeerReview.PEER_REVIEW_HISTORY_MODEL>("PRC_PEERREVIEW_HISTORY @ACTION_TYPE, @FROM_DATE, @TO_DATE, @SUBSPECIALTY_ID, @EMP_ID", parameters).ToList();
                return result;
            }

        }

        public List<PEER_REVIEW_WORKLIST_MODEL> SelectReviewHistoryDtl(PEER_REVIEW_ASSIGNMENT_MODEL assignmentModel)
        {
            using (var context = new EnvisionDataModel())
            {
                SqlParameter[] parameters =
                {
                    new SqlParameter("@ACTION_TYPE", assignmentModel.ACTION_TYPE),
                    new SqlParameter("@FROM_DATE", Convert.ToDateTime(assignmentModel.FROM_DATE)),
                    new SqlParameter("@TO_DATE", Convert.ToDateTime(assignmentModel.TO_DATE)),
                    new SqlParameter("@SUBSPECIALTY_ID", assignmentModel.SUBSPECIALTY_ID),
                    new SqlParameter("@EMP_ID", assignmentModel.EMP_ID)

                };

                var result = context.Database.SqlQuery<Envision.Entity.Result.PeerReview.PEER_REVIEW_WORKLIST_MODEL>("PRC_PEERREVIEW_HISTORY @ACTION_TYPE, @FROM_DATE, @TO_DATE, @SUBSPECIALTY_ID, @EMP_ID", parameters).ToList();
                return result;
            }

        }

        public List<PEER_ALGORITHM_MODEL> SelectPeerAlgorithm()
        {
            PEER_ALGORITHM_MODEL model;
            List<PEER_ALGORITHM_MODEL> itemList = null;
            using (var context = new EnvisionDataModel())
            {
                var itemSearch = (from data in context.RIS_PRALGORITHM
                                  select data).ToList();
                if (itemSearch != null)
                {
                    itemList = new List<PEER_ALGORITHM_MODEL>();
                    foreach (var obj in itemSearch)
                    {
                        model = new PEER_ALGORITHM_MODEL();
                        model.PR_ALGORITHM_ID = obj.PR_ALGORITHM_ID;
                        model.PERCENTAGE_PER_RAD = Convert.ToInt32(obj.PERCENTAGE_PER_RAD);
                        model.MAX_ASSIGNMENT_PER_RAD = Convert.ToInt32(obj.MAX_ASSIGNMENT_PER_RAD);
                        itemList.Add(model);
                    }
                }
            }
            return itemList;
        }

        public object SaveChangesAlgorithm(PEER_ALGORITHM_MODEL algorithmModel)
        {
            bool flag = false;
            using (var context = new EnvisionDataModel())
            {
                var obj = context.RIS_PRALGORITHM.Find(algorithmModel.PR_ALGORITHM_ID);
                if (obj != null)
                {
                    obj.PERCENTAGE_PER_RAD = algorithmModel.PERCENTAGE_PER_RAD;
                    obj.MAX_ASSIGNMENT_PER_RAD = algorithmModel.MAX_ASSIGNMENT_PER_RAD;
                    flag = context.SaveChanges() > 0;
                }
            }
            return flag;
        }
    }

}
