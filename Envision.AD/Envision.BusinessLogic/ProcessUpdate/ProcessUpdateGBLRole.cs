using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLRole : IBusinessLogic
    {
        public GBLRole GBLRole { get; set; }
        public List<GBLRole> _objectsitem { get; set; }

        public ProcessUpdateGBLRole()
        {
            GBLRole = new GBLRole();
            _objectsitem = new List<GBLRole>();
        }

        public void Invoke()
        {
            foreach (GBLRole item in _objectsitem)
            {
                GBLRoleUpdateData menudata = new GBLRoleUpdateData();
                menudata.GBLRole = item;
                menudata.Add();
            }

        }
    }
}
