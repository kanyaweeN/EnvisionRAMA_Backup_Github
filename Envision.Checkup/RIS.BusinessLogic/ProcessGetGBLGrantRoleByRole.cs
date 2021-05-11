using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
using System.Data;

namespace RIS.BusinessLogic
{
    public class ProcessGetGBLGrantRoleByRole : IBusinessLogic
    {
        private DataSet _dataresult;
        private GBLGrantRole _gblgrantrole;
        public ProcessGetGBLGrantRoleByRole() { }
        public void Invoke()
        {
            GBLGrantRoleSelectDataByRole select = new GBLGrantRoleSelectDataByRole();
            select.GBLGrantRole = this.GBLGrantRole;
            DataResult = select.Get();
        }
        public DataSet DataResult
        {
            get{ return _dataresult; }
            set{ _dataresult = value; }
        }
        public GBLGrantRole GBLGrantRole
        {
            get { return _gblgrantrole; }
            set { _gblgrantrole = value; }
        }
    }
}
