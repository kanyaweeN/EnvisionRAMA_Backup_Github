using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLSubMenuObjectLabel : IBusinessLogic
    {
        public GBL_SUBMENUOBJECTLABEL GBL_SUBMENUOBJECTLABEL { get; set; }
        public List<GBL_SUBMENUOBJECTLABEL> _objectsitem { get; set; }
        public ProcessAddGBLSubMenuObjectLabel()
        {
            GBL_SUBMENUOBJECTLABEL = new GBL_SUBMENUOBJECTLABEL();
            _objectsitem = new List<GBL_SUBMENUOBJECTLABEL>();
        }

        public void Invoke()
        {
            foreach (GBL_SUBMENUOBJECTLABEL item in _objectsitem)
            {
                GBLSubMenuObjectLabelInsertData menudata = new GBLSubMenuObjectLabelInsertData();
                menudata.GBL_SUBMENUOBJECTLABEL = item;
                menudata.Add();
            }

        }


    }
}
