using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteGBLSubMenuObjectLabel : IBusinessLogic
    {
        private GBLSubMenuObjectLabel _gblsubmenuobjectlabel;

        private List<GBLSubMenuObjectLabel> _delObjects = new List<GBLSubMenuObjectLabel>();

        public ProcessDeleteGBLSubMenuObjectLabel()
        {

        }

        public void Invoke()
        {
            foreach (GBLSubMenuObjectLabel item in _delObjects)
            {
                GBLSubMenuObjectLabelDeleteData menudata = new GBLSubMenuObjectLabelDeleteData();
                //menudata.ObjectId = item;
                menudata.GBLSubMenuObjectLabel = item;
                menudata.Delete();
            }
            
        }

        public GBLSubMenuObjectLabel GBLSubMenuObjectLabel
        {
            get { return _gblsubmenuobjectlabel; }
            set { _gblsubmenuobjectlabel = value; }
        }

        public List<GBLSubMenuObjectLabel> DeleteItem
        {
            get { return _delObjects; }
            set { _delObjects = value; }
        }
    }
}
