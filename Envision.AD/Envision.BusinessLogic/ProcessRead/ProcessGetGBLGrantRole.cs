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
