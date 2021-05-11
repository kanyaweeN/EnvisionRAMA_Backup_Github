using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.BusinessLogic.ProcessRead;
using System.Data;
using Envision.BusinessLogic.ProcessDelete;
using Envision.Common;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;

namespace Envision.BusinessLogic
{
    public class AcademicManagement
    {
        //private static AcademicModule _academicModule; // academic module

        #region
        private static AC_ASSIGNMENT ac_ASSIGNMENT;
        private static AC_EVALUATION ac_EVALUATION;
        private static ProcessAddACAssignment acAssignmentInsert;
        private static ProcessAddACEvaluation acEvaluationInsert;
        private static ProcessUpdateACEvaluation ACEvaluationUpdate;
        public static AC_ASSIGNMENT AC_ASSIGNMENT
        {
            get { return ac_ASSIGNMENT; }
            set { ac_ASSIGNMENT = value; }
        }
        public static AC_EVALUATION AC_EVALUATION
        {
            get { return ac_EVALUATION; }
            set { ac_EVALUATION = value; }
        }

        public static void AddAssignment()
        {
            acAssignmentInsert = new ProcessAddACAssignment();
            acAssignmentInsert.AC_ASSIGNMENT = ac_ASSIGNMENT;
            acAssignmentInsert.Invoke();
        }
        public static void AddEvaluation()
        {
            acEvaluationInsert = new ProcessAddACEvaluation();
            acEvaluationInsert.AC_EVALUATION = ac_EVALUATION;
            acEvaluationInsert.Invoke();
        }
        public static void UpdateEvaluation()
        {
            ACEvaluationUpdate = new ProcessUpdateACEvaluation();
            ACEvaluationUpdate.AC_EVALUATION = ac_EVALUATION;
            ACEvaluationUpdate.Invoke();
        }
        public static DataSet SelectEnrollForAssignment(int empID)
        {
            ProcessGetACEnrollment endroll = new ProcessGetACEnrollment();
            endroll.SelectEnrollmentForAssignment(empID);
            return endroll.ResultSet.Copy();
        }
        public static DataTable SelectAssignmentFromAccession(string acc)
        {
            ProcessGetACAssignment assign = new ProcessGetACAssignment();
            return assign.SelectByAccessionNo(acc);
        }
        public static DataSet SelectAssignmentFromAccession(string acc, int empID)
        {
            ProcessGetACAssignment assign = new ProcessGetACAssignment();
            assign.SelectByAccessionNo(acc, empID);
            return assign.ResultSet.Copy();
        }
        public static DataSet SelectAssignmentFromAccessionRAD(string acc, int empID)
        {
            ProcessGetACAssignment assign = new ProcessGetACAssignment();
            assign.SelectByAccessionNoRAD(acc, empID);
            return assign.ResultSet.Copy();
        }
        public static bool canAcamedic(int emp_id, int org_id)
        {
            ProcessGetACAssignment assign = new ProcessGetACAssignment();
            assign.canAcademic(emp_id, org_id);
            DataSet ds = assign.ResultSet;
            bool canAcademic = false;
            if (!Miracle.Util.Utilities.IsHaveData(ds))
            {
                canAcademic = false;
            }
            else
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row["IS_FELLOW"].ToString() == "Y" || row["IS_RESIDENT"].ToString() == "Y")
                    canAcademic = true;
                else
                    canAcademic = false;
            }

            return canAcademic;
        }

        public static DataTable GetWorkList(int EmpId)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            return proc.GetWorkList(EmpId);
        }
        public static DataTable GetWorkList(int EmpId, DateTime dtStart, DateTime dtEnd)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            return proc.GetWorkList(EmpId, dtStart, dtEnd);
        }
        #endregion

        static AcademicManagement()
        {
            AC_ASSIGNMENT = new AC_ASSIGNMENT();
            AC_EVALUATION = new AC_EVALUATION();
        }
        /// <summary>
        /// This method use to genarate academic management
        /// </summary>
        /// <param name="gradeLabel">Grade label</param>
        /// <param name="langLabel">Language of Report label</param>
        /// <param name="accessionNo">Accession No</param>
        /// <param name="peerBy_fname">Peer Review By (Fname)</param>
        /// <param name="peerBy_LastName">Peer Review By (Lname)</param>
        /// <param name="OrgId">Org ID</param>
        /// <returns>Genarated Message</returns>
        public static string GenarateInternalMessage(string gradeLabel
            , string langLabel
            , string accessionNo
            , bool isLikely
            , string gradeComment
            , string langComment
            , string peerBy_fname
            , string peerBy_LastName
            , int OrgId)
        {
            // Get Case Info
            ProcessGetRISOrderCaseInfo _processGetRISOrderCaseInfo = new ProcessGetRISOrderCaseInfo();
            _processGetRISOrderCaseInfo.ACCESSION_NO = accessionNo;
            _processGetRISOrderCaseInfo.ORG_ID = OrgId;
            _processGetRISOrderCaseInfo.Invoke();
            DataSet dsResult = _processGetRISOrderCaseInfo.Result;
            if (dsResult != null)
            {
                if (dsResult.Tables.Count > 0)
                {
                    if (dsResult.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder strBuilder = new StringBuilder();
                        strBuilder.Append("Feedback Findings of\r\n");
                        strBuilder.Append("\tHN: " + dsResult.Tables[0].Rows[0]["HN"].ToString() + "\r\n");
                        strBuilder.Append("\tPatient Name: " + dsResult.Tables[0].Rows[0]["PATIENT_NAME"].ToString() + "\r\n");
                        strBuilder.Append("\tStudy: " + dsResult.Tables[0].Rows[0]["STUDY"].ToString() + "\r\n");
                        strBuilder.Append("\tAccession No: " + dsResult.Tables[0].Rows[0]["ACCESSION_NO"].ToString() + "\r\n");
                        strBuilder.Append("\tOrder Date Time: " + Convert.ToDateTime(dsResult.Tables[0].Rows[0]["ORDER_DATETIME"]).ToString("dd/MM/yyyy hh:mm") + "\r\n");
                        strBuilder.Append("\tFeedback Date Time: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm") + "\r\n");
                        strBuilder.Append("\tFeedback By: " + peerBy_fname + " " + peerBy_LastName + "\r\n\r\n");
                        strBuilder.Append("Opinion of Clinical Report: " + gradeLabel + "\r\n");
                        
                        if(isLikely)
                            strBuilder.Append("\tThe Radiologist disagreed and thought this is Likely to be clinically significant: \r\n");
                        else
                            strBuilder.Append("\tThe Radiologist disagreed and thought this is Unlikely to be clinically significant: \r\n");

                        if (gradeComment.Trim().Length > 0)
                            strBuilder.Append("\tComment: " + gradeComment + "\r\n");

                        strBuilder.Append("Language of Report: " + langLabel + "\r\n");
                        
                        if(langComment.Trim().Length > 0)
                            strBuilder.Append("\tComment: " + langComment + "\r\n");
                        
                        Envision.Common.GBLEnvVariable gblenv = new Envision.Common.GBLEnvVariable();
                        strBuilder.Append(Environment.NewLine);
                        strBuilder.Append("\tSynapse url : " + gblenv.PacsUrl + accessionNo + "\r\n");

                        return strBuilder.ToString();
                    }
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// This method use to get rad emp id
        /// </summary>
        /// <param name="accessionNo">Accession No</param>
        /// <param name="orgId">Org Id</param>
        /// <returns>emp Id list</returns>
        public static int[] GetRadEmpIdGroup(string accessionNo, int orgId)
        {
            List<int> empIds = new List<int>();
            try
            {
                ProcessGetRISExamresultrads processGetRISExamResultrads = new ProcessGetRISExamresultrads();
                processGetRISExamResultrads.RIS_EXAMRESULTRADS.ACCESSION_NO = accessionNo;
                processGetRISExamResultrads.RIS_EXAMRESULTRADS.ORG_ID = orgId;
                processGetRISExamResultrads.Invoke();
                if (processGetRISExamResultrads.Result != null)
                {
                    if (processGetRISExamResultrads.Result.Tables.Count > 0)
                    {
                        foreach (DataRow eachRow in processGetRISExamResultrads.Result.Tables[0].Rows)
                            empIds.Add(Convert.ToInt32(eachRow["RAD_ID"]));
                        return empIds.ToArray();
                    }
                }
                return new int[] { };
            }
            catch { return new int[] { }; }
            finally { empIds = null; }
        }
        /// <summary>
        /// This method use to add assignment 
        /// </summary>
        /// <param name="empId">emp id</param>
        /// <param name="assignedTo">assigned to</param>
        /// <param name="accessionNo">accession no</param>
        /// <param name="orgId">org id</param>
        /// <param name="createdBy">created by</param>
        public static int AddAssignment(int empId, int assignedTo, string accessionNo, int orgId, int createdBy)
        {
            //Check enrollment
            DataSet empEnrollDataSet = SelectEnrollForAssignment(empId);
            if (empEnrollDataSet != null)
            {
                if (empEnrollDataSet.Tables.Count > 0)
                {
                    if (empEnrollDataSet.Tables[0].Rows.Count > 0)
                    {
                        AC_ASSIGNMENT.ENROLL_ID = Convert.ToInt32(empEnrollDataSet.Tables[0].Rows[0]["ENROLL_ID"].ToString());
                        AC_ASSIGNMENT.ASSIGNED_BY = assignedTo;
                        AC_ASSIGNMENT.ASSIGNMENT_TYPE = "A";
                        AC_ASSIGNMENT.ACCESSION_NO = accessionNo;
                        AC_ASSIGNMENT.ORG_ID = orgId;
                        AC_ASSIGNMENT.CREATED_BY = createdBy;
                        AC_ASSIGNMENT.LAST_MODIFIED_BY = createdBy;
                        AddAssignment();
                        return AC_ASSIGNMENT.ASSIGNEMENT_ID;
                    }
                }
            }
            return 0;
        }
        /// <summary>
        /// This method use to delete assignment
        /// </summary>
        /// <param name="empId">emp Id</param>
        /// <param name="accessionNo">accession no</param>
        /// <param name="orgId">org id</param>
        public static int RemoveAssignment(int empId, string accessionNo, int orgId)
        {
             DataSet empEnrollDataSet = SelectEnrollForAssignment(empId);
             if (empEnrollDataSet != null)
             {
                 if (empEnrollDataSet.Tables.Count > 0)
                 {
                     if (empEnrollDataSet.Tables[0].Rows.Count > 0)
                     {
                         try
                         {
                             ProcessDeleteACAssignment processDeleteACAssignment = new ProcessDeleteACAssignment();
                             processDeleteACAssignment.AC_ASSIGNMENT.ASSIGNED_BY = Convert.ToInt32(empEnrollDataSet.Tables[0].Rows[0]["ENROLL_ID"]);
                             processDeleteACAssignment.AC_ASSIGNMENT.ACCESSION_NO = accessionNo;
                             processDeleteACAssignment.AC_ASSIGNMENT.ORG_ID = orgId;
                             processDeleteACAssignment.Invoke();
                             return processDeleteACAssignment.AC_ASSIGNMENT.ASSIGNEMENT_ID;
                         }
                         catch { return 0; }
                         //finally { }
                     }
                 }
             }
             return 0;
        }
        public static int AddAssignment(int empId, int assignedTo, string accessionNo, int orgId, int createdBy, string status, string report_text, int severityId)
        {
            //Check enrollment
            DataSet empEnrollDataSet = SelectEnrollForAssignment(empId);
            if (empEnrollDataSet != null)
            {
                if (empEnrollDataSet.Tables.Count > 0)
                {
                    if (empEnrollDataSet.Tables[0].Rows.Count > 0)
                    {
                        AC_ASSIGNMENT.ENROLL_ID = Convert.ToInt32(empEnrollDataSet.Tables[0].Rows[0]["ENROLL_ID"].ToString());
                        AC_ASSIGNMENT.ASSIGNED_BY = assignedTo;
                        AC_ASSIGNMENT.ASSIGNMENT_TYPE = "A";
                        AC_ASSIGNMENT.ACCESSION_NO = accessionNo;
                        AC_ASSIGNMENT.ORG_ID = orgId;
                        AC_ASSIGNMENT.CREATED_BY = createdBy;
                        AC_ASSIGNMENT.LAST_MODIFIED_BY = createdBy;
                        AC_ASSIGNMENT.REPORT_TYPE = status;
                        AC_ASSIGNMENT.REPORT_TEXT = report_text;
                        AC_ASSIGNMENT.ASSIGNEMENT_ID = 0;
                        AC_ASSIGNMENT.SEVERITY_ID = severityId;
                        AddAssignment();
                        return AC_ASSIGNMENT.ASSIGNEMENT_ID;
                    }
                }
            }
            return 0;
        }
        public static DataSet GetUserEnrollment(int EmpId)
        {
            return SelectEnrollForAssignment(EmpId);
        }

        public static DataTable GetAcademicWorkList(int EmpID)
        {

            return GetWorkList(EmpID);
        }
        public static DataTable GetAcademicWorkList(int EmpID, DateTime dtStart, DateTime dtEnd)
        {

            return GetWorkList(EmpID, dtStart, dtEnd);
        }

        public static DataTable GetAcademicWorkListNew(int EmpID)
        {
            return GetWorkListNew(EmpID);
        }
        public static DataTable GetAcademicWorkListNew(int EmpID, DateTime dtStart, DateTime dtEnd)
        {

            return GetWorkListNew(EmpID, dtStart, dtEnd);
        }
        public static DataTable GetWorkListNew(int EmpId)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            return proc.GetWorkListNew(EmpId);
        }
        public static DataTable GetWorkListNew(int EmpId, DateTime dtStart, DateTime dtEnd)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            return proc.GetWorkListNew(EmpId, dtStart, dtEnd);
        }
        public static DataTable GetBindData(string AccessionNo)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            return proc.GetBindData(AccessionNo);            
        }
        public static DataSet SelectEvaluationByID(int assignmentId)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            proc.Invoke(assignmentId);
            return proc.ResultSet;
        }
    }
}
