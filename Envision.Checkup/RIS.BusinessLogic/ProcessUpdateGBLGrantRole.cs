using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLGrantRole :IBusinessLogic
    {
        private GBLGrantRole _gblgrantrole;
        public ProcessUpdateGBLGrantRole() { }
        public void Invoke()
        {
            GBLGrantRoleUpdateData update = new GBLGrantRoleUpdateData();
            update.GBLGrantRole = GBLGrantRole;
            update.Get();
        }
        public GBLGrantRole GBLGrantRole
        {
            get { return _gblgrantrole; }
            set { _gblgrantrole = value; }
        }
    }
}
