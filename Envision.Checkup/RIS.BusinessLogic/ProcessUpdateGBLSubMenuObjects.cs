using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLSubMenuObjects : IBusinessLogic
    {
        private GBLSubMenuObjects _gblsubmenuobjects;
        private List<GBLSubMenuObjects> _objectsitem = new List<GBLSubMenuObjects>();

        public ProcessUpdateGBLSubMenuObjects()
        {

        }

        public void Invoke()
        {
            foreach (GBLSubMenuObjects item in _objectsitem)
            {
                GBLSubMenuObjectsUpdateData menudata = new GBLSubMenuObjectsUpdateData();
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
