using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLSubMenuObjects : IBusinessLogic
    {
        public GBL_SUBMENUOBJECT GBL_SUBMENUOBJECT { get; set; }
        private List<GBL_SUBMENUOBJECT> _objectsitem { get; set; }

        public ProcessUpdateGBLSubMenuObjects()
        {
            GBL_SUBMENUOBJECT = new GBL_SUBMENUOBJECT();
            _objectsitem = new List<GBL_SUBMENUOBJECT>();
        }

        public void Invoke()
        {
            foreach (GBL_SUBMENUOBJECT item in _objectsitem)
            {
                GBLSubMenuObjectsUpdateData menudata = new GBLSubMenuObjectsUpdateData();
                menudata.GBL_SUBMENUOBJECT = item;
                menudata.Add();
            }

        }
    }
}
