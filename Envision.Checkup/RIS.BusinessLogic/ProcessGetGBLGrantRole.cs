using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
using System.Data;

namespace RIS.BusinessLogic
{
    public class ProcessGetGBLGrantRole : IBusinessLogic
    {
        private DataSet _dataresult;
        public ProcessGetGBLGrantRole() { }
        public void Invoke()
        {
            GBLGrantRoleSelectData select = new GBLGrantRoleSelectData();
            DataResult = select.Get();
        }
        public DataSet DataResult
        {
            get{ return _dataresult; }
            set{ _dataresult = value; }
        }
    }
}
