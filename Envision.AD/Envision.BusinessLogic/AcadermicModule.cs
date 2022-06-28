using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

using System.Linq;
using System.Data.Linq;


using Envision.Common;
using Envision.Common.Linq;

using Envision.BusinessLogic.ProcessRead;
using Envision.BusinessLogic.ProcessDelete;
using Envision.BusinessLogic.ProcessCreate;
using Envision.BusinessLogic.ProcessUpdate;

using Envision.WebService.PACSService;

namespace Envision.BusinessLogic
{
    public class AcademicModule
    {
        private AC_ASSIGNMENT _AC_ASSIGNMENT;
        private AC_EVALUATION _AC_EVALUATION;
        private ProcessAddACAssignment _ACAssignmentInsert;
        private ProcessAddACEvaluation _ACEvaluationInsert;
        private ProcessUpdateACEvaluation _ACEvaluationUpdate;
        public AC_ASSIGNMENT AC_ASSIGNMENT
        {
            get { return _AC_ASSIGNMENT; }
            set { _AC_ASSIGNMENT = value; }
        }
        public AC_EVALUATION AC_EVALUATION
        {
            get { return _AC_EVALUATION; }
            set { _AC_EVALUATION = value; }
        }
        public AcademicModule()
        {
            AC_ASSIGNMENT = new AC_ASSIGNMENT();
            AC_EVALUATION = new AC_EVALUATION();
        }
        public void AddAssignment()
        {
            _ACAssignmentInsert = new ProcessAddACAssignment();
            _ACAssignmentInsert.AC_ASSIGNMENT = _AC_ASSIGNMENT;
            _ACAssignmentInsert.Invoke();
        }
        public void AddEvaluation()
        {
            _ACEvaluationInsert = new ProcessAddACEvaluation();
            _ACEvaluationInsert.AC_EVALUATION = _AC_EVALUATION;
            _ACEvaluationInsert.Invoke();
        }
        public void UpdateEvaluation()
        {
            _ACEvaluationUpdate = new ProcessUpdateACEvaluation();
            _ACEvaluationUpdate.AC_EVALUATION = _AC_EVALUATION;
            _ACEvaluationUpdate.Invoke();
        }
        public DataSet SelectEnrollForAssignment(int _empID)
        {
            ProcessGetACEnrollment _endroll = new ProcessGetACEnrollment();
            _endroll.SelectEnrollmentForAssignment(_empID);
            return _endroll.ResultSet.Copy();
        }
        public DataTable SelectAssignmentFromAccession(string _acc) {
            ProcessGetACAssignment _assign = new ProcessGetACAssignment();
            return _assign.SelectByAccessionNo(_acc);
        }
        public DataSet SelectAssignmentFromAccession(string _acc, int _empID)
        {
            ProcessGetACAssignment _assign = new ProcessGetACAssignment();
            _assign.SelectByAccessionNo(_acc, _empID);
            return _assign.ResultSet.Copy();
        }
        public DataSet SelectAssignmentFromAccessionRAD(string _acc, int _empID)
        {
            ProcessGetACAssignment _assign = new ProcessGetACAssignment();
            _assign.SelectByAccessionNoRAD(_acc, _empID);
            return _assign.ResultSet.Copy();
        }
        public bool canAcamedic(int emp_id, int org_id)
        {
            ProcessGetACAssignment _assign = new ProcessGetACAssignment();
            _assign.canAcademic(emp_id, org_id);
            DataSet ds = _assign.ResultSet;
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

        public DataTable GetWorkList(int EmpId)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            return proc.GetWorkList(EmpId);
        }
        public DataTable GetWorkList(int EmpId, DateTime dtStart, DateTime dtEnd)
        {
            ProcessGetACEvaluation proc = new ProcessGetACEvaluation();
            return proc.GetWorkList(EmpId, dtStart, dtEnd);
        }
    }
}
