using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteManageGroupsDtl : IBusinessLogic
    {
        ManageGroups _mng;
        public ProcessDeleteManageGroupsDtl()
        {
        }

        public void Invoke()
        {
            ManageGroupsDeleteDataDtl mng = new ManageGroupsDeleteDataDtl();
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
