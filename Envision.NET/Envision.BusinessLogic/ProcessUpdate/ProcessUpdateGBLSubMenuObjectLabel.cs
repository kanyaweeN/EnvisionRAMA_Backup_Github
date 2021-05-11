using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLSubMenuObjectLabel : IBusinessLogic
    {
        public GBL_SUBMENUOBJECTLABEL GBL_SUBMENUOBJECTLABEL { get; set; }
        private List<GBL_SUBMENUOBJECTLABEL> _objectsitem { get; set; }

        public ProcessUpdateGBLSubMenuObjectLabel()
        {
            GBL_SUBMENUOBJECTLABEL = new GBL_SUBMENUOBJECTLABEL();
            _objectsitem = new List<GBL_SUBMENUOBJECTLABEL>();
        }

        public void Invoke()
        {
            foreach (GBL_SUBMENUOBJECTLABEL item in _objectsitem)
            {
                GBLSubMenuObjectLabelUpdateData menudata = new GBLSubMenuObjectLabelUpdateData();
                menudata.GBL_SUBMENUOBJECTLABEL = item;
                menudata.Add();
            }

        }
    }
}
