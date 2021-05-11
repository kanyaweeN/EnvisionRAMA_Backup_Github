using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLSubMenuObjectLabel : IBusinessLogic
    {
        public GBL_SUBMENUOBJECTLABEL GBL_SUBMENUOBJECTLABEL { get; set; }
        public List<GBL_SUBMENUOBJECTLABEL> DeleteItem { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteGBLSubMenuObjectLabel()
        {
            GBL_SUBMENUOBJECTLABEL = new GBL_SUBMENUOBJECTLABEL();
            DeleteItem = new List<GBL_SUBMENUOBJECTLABEL>();
            Transaction = null;
        }

        public void Invoke()
        {
            foreach (GBL_SUBMENUOBJECTLABEL item in DeleteItem)
            {
                GBL_SUBMENUOBJECTLABELDeleteData menudata = new GBL_SUBMENUOBJECTLABELDeleteData();
                menudata.GBL_SUBMENUOBJECTLABEL = item;
                menudata.Delete();
            }
        }
    }
}
