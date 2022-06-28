using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLSubMenuObjects : IBusinessLogic
    {
        public GBL_SUBMENUOBJECT GBL_SUBMENUOBJECT { get; set; }
        public List<GBL_SUBMENUOBJECT> _objectsitem { get; set; }

        public ProcessAddGBLSubMenuObjects()
        {
            GBL_SUBMENUOBJECT = new GBL_SUBMENUOBJECT();
            _objectsitem = new List<GBL_SUBMENUOBJECT>();
        }

        public void Invoke()
        {
            foreach (GBL_SUBMENUOBJECT item in _objectsitem)
            {
                GBLSubMenuObjectsInsertData menudata = new GBLSubMenuObjectsInsertData();
                menudata.GBL_SUBMENUOBJECT = item;
                menudata.Add();
            }

        }

    }
}
