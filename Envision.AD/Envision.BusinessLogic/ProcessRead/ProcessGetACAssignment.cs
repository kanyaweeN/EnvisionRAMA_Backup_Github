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
    public class ProcessGetACAssignment : IBusinessLogic
    {
         private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _uid = "";

        public ProcessGetACAssignment()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            ACAssignmentSelectData _select = new ACAssignmentSelectData();
            ResultSet = _select.SelectAll();
        }
        public void Invoke(int _ByID)
        {
            ACAssignmentSelectData _select = new ACAssignmentSelectData();
            ResultSet = _select.SelectByID(_ByID);
        }
        public DataTable SelectByAccessionNo(string _acc)
        {
            ACAssignmentSelectData _select = new ACAssignmentSelectData();
            return _select.SelectByAccessionNo(_acc);
        }
        public void SelectByAccessionNo(string _acc, int _empid)
        {
            ACAssignmentSelectData _select = new ACAssignmentSelectData();
            ResultSet = _select.SelectByAccessionNo(_acc, _empid);
        }
        public void SelectByAccessionNoRAD(string _acc, int _empid)
        {
            ACAssignmentSelectData _select = new ACAssignmentSelectData();
            ResultSet = _select.SelectByAccessionNoRAD(_acc, _empid);
        }
        public void canAcademic(int _empid, int _org_id)
        {
            ACAssignmentSelectData _select = new ACAssignmentSelectData();
            ResultSet = _select.canAcademic(_empid, _org_id);
        }
    }
}
