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
    public class ProcessGetACGrade : IBusinessLogic
    {
         private DataSet _resultset;
        public DataSet ResultSet
        {
            get { return _resultset; }
            set { _resultset = value; }
        }
        private string _uid = "";

        public ProcessGetACGrade()
        {
            _resultset = new DataSet();
        }
        public void Invoke()
        {
            ACGradeSelectData _select = new ACGradeSelectData();
            ResultSet = _select.SelectAll();
        }
        public void Invoke(int _ByID)
        {
            ACGradeSelectData _select = new ACGradeSelectData();
            ResultSet = _select.SelectByID(_ByID);
        }
    }
}
