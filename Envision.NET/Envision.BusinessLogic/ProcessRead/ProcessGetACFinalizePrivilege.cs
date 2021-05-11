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
    public class ProcessGetACFinalizePrivilege : IBusinessLogic
    {
         private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }

        public ProcessGetACFinalizePrivilege()
        {
            _resultset = new DataSet();
        }
        public void SelectJobTitle()
        {
            ACFinalizePrivilegeSelectData _select = new ACFinalizePrivilegeSelectData();
            ResultSet = _select.SelectJobTitle();
        }
        public void SelectExamTypeWithIsActive(int EMP_ID)
        {
            ACFinalizePrivilegeSelectData _select = new ACFinalizePrivilegeSelectData();
            ResultSet = _select.SelectExamTypeWithIsActive(EMP_ID);
        }

        #region IBusinessLogic Members

        public void Invoke()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
