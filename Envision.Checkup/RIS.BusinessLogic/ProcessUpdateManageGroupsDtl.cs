using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateManageGroupsDtl : IBusinessLogic
    {
        ManageGroups _mng;
        public ProcessUpdateManageGroupsDtl()
        { 
        }

        public void Invoke()
        {
            ManageGroupsUpdateDataDtl mngdtl = new ManageGroupsUpdateDataDtl();
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
