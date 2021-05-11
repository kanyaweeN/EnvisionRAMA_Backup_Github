using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLSubMenuObjects : IBusinessLogic
    {
        private GBLSubMenuObjects _gblsubmenuobjects;

        private List<string> _delObjects = new List<string>();

        public ProcessDeleteGBLSubMenuObjects()
        {

        }

        public void Invoke()
        {
            foreach (string item in _delObjects)
            {
                GBLSubMenuObjectsDeleteData menudata = new GBLSubMenuObjectsDeleteData();
                menudata.ObjectId = item;
                //menudata.GBLSubMenuObjects = item;
                menudata.Delete();
            }
            
        }

        public GBLSubMenuObjects GBLSubMenuObjects
        {
            get { return _gblsubmenuobjects; }
            set { _gblsubmenuobjects = value; }
        }

        public List<string> DeleteItem
        {
            get { return _delObjects; }
            set { _delObjects = value; }
        }
    }
}
