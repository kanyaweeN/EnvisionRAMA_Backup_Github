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
    public class ProcessGetACClass : IBusinessLogic
    {
        private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _uid = "";

        public ProcessGetACClass()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            ACClassSelectData _select = new ACClassSelectData();
            ResultSet = _select.SelectAll();
        }
        public void Invoke(int _ByID)
        {
            ACClassSelectData _select = new ACClassSelectData();
            ResultSet = _select.SelectByID(_ByID);
        }
    }
}
