using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLGrantRoleByRole : IBusinessLogic
    {
        private GBLGrantRole _gblgrantrole;
        public ProcessAddGBLGrantRoleByRole() { }
        public void Invoke()
        {
            GBLGrantRoleInsertDataRole update = new GBLGrantRoleInsertDataRole();
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
