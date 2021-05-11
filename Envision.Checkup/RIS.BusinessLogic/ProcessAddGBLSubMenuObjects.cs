using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLSubMenuObjects : IBusinessLogic
    {
        private GBLSubMenuObjects _gblsubmenuobjects;
        private List<GBLSubMenuObjects> _objectsitem = new List<GBLSubMenuObjects>();

        public ProcessAddGBLSubMenuObjects()
        {

        }

        public void Invoke()
        {
            foreach (GBLSubMenuObjects item in _objectsitem)
            {
                GBLSubMenuObjectsInsertData menudata = new GBLSubMenuObjectsInsertData();
                menudata.GBLSubMenuObjects = item;
                menudata.Add();
            }

        }

        public GBLSubMenuObjects GBLSubMenuObjects
        {
            get { return _gblsubmenuobjects; }
            set { _gblsubmenuobjects = value; }
        }

        public List<GBLSubMenuObjects> ObjectsItem
        {
            get { return _objectsitem; }
            set { _objectsitem = value; }
        }

    }
}
