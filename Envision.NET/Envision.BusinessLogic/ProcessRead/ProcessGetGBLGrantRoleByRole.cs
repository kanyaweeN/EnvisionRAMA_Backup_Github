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
    public class ProcessGetGBLGrantRoleByRole : IBusinessLogic
    {
        private DataSet _dataresult;
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public ProcessGetGBLGrantRoleByRole() { }
        public void Invoke()
        {
            GBLGrantRoleSelectDataByRole select = new GBLGrantRoleSelectDataByRole();
            select.GBL_GRANTROLE = this.GBL_GRANTROLE;
            DataResult = select.Get();
        }
        public DataSet DataResult
        {
            get{ return _dataresult; }
            set{ _dataresult = value; }
        }
    }
}
