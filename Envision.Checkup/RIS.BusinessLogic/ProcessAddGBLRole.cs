using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLRole : IBusinessLogic
    {
        private GBLRole _gblrole;
        private List<GBLRole> _objectsitem = new List<GBLRole>();

        public ProcessAddGBLRole()
        {

        }

        public void Invoke()
        {
            foreach (GBLRole item in _objectsitem)
            {
                GBLRoleInsertData menudata = new GBLRoleInsertData();
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
