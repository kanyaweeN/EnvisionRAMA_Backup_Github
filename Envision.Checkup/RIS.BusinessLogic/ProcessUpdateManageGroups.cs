using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateManageGroups : IBusinessLogic
    {
        ManageGroups _mng;
        public ProcessUpdateManageGroups()
        { 
        }

        public void Invoke()
        {
            ManageGroupsUpdateData mng = new ManageGroupsUpdateData();
            mng.ManageGroups = ManageGroups;
            mng.Set();
        }

        public ManageGroups ManageGroups
        {
            get { return _mng; }
            set { _mng = value; }
        }
    }
}
