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
    public class ProcessGetRISExamresulttime : IBusinessLogic
    {
        private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _execExamType;
        public string execExamType
        {
            get { return _execExamType; }
            set { _execExamType = value; }
        }
        private string _uid = "";

        public ProcessGetRISExamresulttime()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            //RISExamresulttimeSelectDta _select = new RISExamresulttimeSelectDta();
            //ResultSet = _select.SelectAll();
        }
        public void Invoke(int _ByID)
        {
            RISExamresulttimeSelectDta _select = new RISExamresulttimeSelectDta();
            _select.execExamType = _execExamType;
            ResultSet = _select.SelectAll(_ByID);
        }
        public void SelectByAccessionNo(string _acc)
        {
            RISExamresulttimeSelectDta _select = new RISExamresulttimeSelectDta();
            _select.execExamType = _execExamType;
            ResultSet = _select.SelectByAccessionNo(_acc);
        }
        public void SelectByAccessionNoRad(string _acc, int _id)
        {
            RISExamresulttimeSelectDta _select = new RISExamresulttimeSelectDta();
            _select.execExamType = _execExamType;
            ResultSet = _select.SelectByAccessionNoRad(_acc, _id);
        }
        public void SelectByDate(int _id, DateTime _from, DateTime _to)
        {
            RISExamresulttimeSelectDta _select = new RISExamresulttimeSelectDta();
            _select.execExamType = _execExamType;
            ResultSet = _select.SelectByDate(_id, _from, _to);
        }
        public void SelectExecSummary(string _ExecSummary)
        {
            RISExamresulttimeSelectDta _select = new RISExamresulttimeSelectDta();
            ResultSet = _select.SelectExecSummary(_ExecSummary);
        }
    }
}
