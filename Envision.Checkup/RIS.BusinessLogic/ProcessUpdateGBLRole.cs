using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLRole : IBusinessLogic
    {
        private GBLRole _gblrole;
        private List<GBLRole> _objectsitem = new List<GBLRole>();

        public ProcessUpdateGBLRole()
        {

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

        public GBLRole GBLRole
        {
            get { return _gblrole; }
            set { _gblrole = value; }
        }

        public List<GBLRole> ObjectsItem
        {
            get { return _objectsitem; }
            set { _objectsitem = value; }
        }
    }
}
