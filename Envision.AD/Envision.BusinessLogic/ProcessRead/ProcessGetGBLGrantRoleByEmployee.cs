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
    public class ProcessGetGBLGrantRoleByEmployee : IBusinessLogic
    {

        private DataSet _dataresult;
        public GBL_GRANTROLE GBL_GRANTROLE { get; set; }
        public ProcessGetGBLGrantRoleByEmployee() { GBL_GRANTROLE = new GBL_GRANTROLE(); }
        public void Invoke()
        {
            GBLGrantRoleSelectDataByEmployee select = new GBLGrantRoleSelectDataByEmployee();
            select.GBL_GRANTROLE = this.GBL_GRANTROLE;
            DataResult = select.Get();
        }
        public DataSet GetAD()
        {
            GBLGrantRoleSelectDataByEmployee select = new GBLGrantRoleSelectDataByEmployee();
            select.GBL_GRANTROLE = this.GBL_GRANTROLE;
            return select.GetAD();
        }
        public DataSet DataResult
        {
            get{ return _dataresult; }
            set{ _dataresult = value; }
        }
    }
}
