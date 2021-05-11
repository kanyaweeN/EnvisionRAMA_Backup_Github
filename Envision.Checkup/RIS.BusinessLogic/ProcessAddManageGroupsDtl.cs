using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddManageGroupsDtl : IBusinessLogic
    {
        ManageGroups _mng;
        public ProcessAddManageGroupsDtl()
        { 
        }

        public void Invoke()
        {
            ManageGroupsInsertDataDtl mngdtl = new ManageGroupsInsertDataDtl();
            mngdtl.ManageGroups = this.ManageGroups;
            mngdtl.Set();
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }
}
