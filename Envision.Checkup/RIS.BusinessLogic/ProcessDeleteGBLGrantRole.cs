using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLGrantRole : IBusinessLogic
    {
        private GBLGrantRole _gblgrantrole;
        public void Invoke()
        {
            GBLGrantRoleDeleteData delete = new GBLGrantRoleDeleteData();
            delete.GBLGrantRole = GBLGrantRole;
            delete.Get();
        }
        public GBLGrantRole GBLGrantRole
        {
            get { return _gblgrantrole; }
            set { _gblgrantrole = value; }
        }
    }
}
