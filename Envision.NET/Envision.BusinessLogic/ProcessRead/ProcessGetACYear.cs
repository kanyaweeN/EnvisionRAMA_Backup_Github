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
    public class ProcessGetACYear : IBusinessLogic
    {
        private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _uid = "";

        public ProcessGetACYear()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            ACYearSelectData _select = new ACYearSelectData();
            ResultSet = _select.SelectAll();
        }
        public void Invoke(int _ByID)
        {
            ACYearSelectData _select = new ACYearSelectData();
            ResultSet = _select.SelectByID(_ByID);
        }
        public void SelectByDatenow()
        {
            ACYearSelectData _select = new ACYearSelectData();
            ResultSet = _select.SelectByDatenow();
        }
    }
}
