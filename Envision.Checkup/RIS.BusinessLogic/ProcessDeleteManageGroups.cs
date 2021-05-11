using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteManageGroups : IBusinessLogic
    {
        ManageGroups _mng;
        public ProcessDeleteManageGroups()
        { 
        }

        public void Invoke()
        {
            ManageGroupsDeleteData mng = new ManageGroupsDeleteData();
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
