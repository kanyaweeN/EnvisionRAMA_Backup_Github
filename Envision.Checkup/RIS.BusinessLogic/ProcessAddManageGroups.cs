using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddManageGroups : IBusinessLogic
    {
        ManageGroups _mng;
        public ProcessAddManageGroups()
        { 
        }

        public void Invoke()
        {
            ManageGroupsInsertData mng = new ManageGroupsInsertData();
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
