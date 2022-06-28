using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetACEvaluation : IBusinessLogic
    {
        private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _uid = "";

        public ProcessGetACEvaluation()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            ACEvaluationSelectData _select = new ACEvaluationSelectData();
            ResultSet = _select.SelectAll();
        }
        public void Invoke(int _ByID)
        {
            ACEvaluationSelectData _select = new ACEvaluationSelectData();
            ResultSet = _select.SelectByID(_ByID);
        }

        public DataTable GetWorkList(int EmpId)
        {
            ACEvaluationSelectData select = new ACEvaluationSelectData();
            return select.GetWorkList(EmpId);
        }
        public DataTable GetWorkList(int EmpId, DateTime dtStart, DateTime dtEnd)
        {
            ACEvaluationSelectData select = new ACEvaluationSelectData();
            return select.GetWorkList(EmpId, dtStart, dtEnd);
        }

        public DataTable GetWorkListNew(int EmpId)
        {
            ACEvaluationSelectData select = new ACEvaluationSelectData();
            return select.GetWorkListNew(EmpId);
        }
        public DataTable GetWorkListNew(int EmpId, DateTime dtStart, DateTime dtEnd)
        {
            ACEvaluationSelectData select = new ACEvaluationSelectData();
            return select.GetWorkListNew(EmpId, dtStart, dtEnd);
        }

        public DataTable GetBindData(string AccessionNo)
        {
            ACEvaluationSelectData select = new ACEvaluationSelectData();
            return select.GetBindData(AccessionNo);
        }
    }
}
