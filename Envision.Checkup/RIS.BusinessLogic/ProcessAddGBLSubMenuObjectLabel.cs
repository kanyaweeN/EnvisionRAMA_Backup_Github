using System;
using System.Collections.Generic;
using System.Text;

using RIS.Common;
using RIS.DataAccess.Insert;

namespace RIS.BusinessLogic
{
    public class ProcessAddGBLSubMenuObjectLabel : IBusinessLogic
    {
        private GBLSubMenuObjectLabel _gblsubmenuobjectlabel;
        private List<GBLSubMenuObjectLabel> _objectsitem = new List<GBLSubMenuObjectLabel>();

        public ProcessAddGBLSubMenuObjectLabel()
        {

        }

        public void Invoke()
        {
            foreach (GBLSubMenuObjectLabel item in _objectsitem)
            {
                GBLSubMenuObjectLabelInsertData menudata = new GBLSubMenuObjectLabelInsertData();
                menudata.GBLSubMenuObjectLabel = item;
                menudata.Add();
            }

        }

        public GBLSubMenuObjectLabel GBLSubMenuObjectLabel
        {
            get { return _gblsubmenuobjectlabel; }
            set { _gblsubmenuobjectlabel = value; }
        }

        public List<GBLSubMenuObjectLabel> ObjectsItem
        {
            get { return _objectsitem; }
            set { _objectsitem = value; }
        }

    }
}
