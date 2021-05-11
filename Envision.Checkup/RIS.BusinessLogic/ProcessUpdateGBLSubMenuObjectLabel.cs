using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateGBLSubMenuObjectLabel : IBusinessLogic
    {
        private GBLSubMenuObjectLabel _gblsubmenuobjectlabel;
        private List<GBLSubMenuObjectLabel> _objectsitem = new List<GBLSubMenuObjectLabel>();

        public ProcessUpdateGBLSubMenuObjectLabel()
        {

        }

        public void Invoke()
        {
            foreach (GBLSubMenuObjectLabel item in _objectsitem)
            {
                GBLSubMenuObjectLabelUpdateData menudata = new GBLSubMenuObjectLabelUpdateData();
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
