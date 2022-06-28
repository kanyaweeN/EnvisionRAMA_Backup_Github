using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLSubMenuObjects : IBusinessLogic
    {
        public GBL_SUBMENUOBJECT GBL_SUBMENUOBJECT { get; set; }
        public List<string> DeleteItem = new List<string>();

        public ProcessDeleteGBLSubMenuObjects()
        {
            DeleteItem = new List<string>();
            GBL_SUBMENUOBJECT = new GBL_SUBMENUOBJECT();
        }

        public void Invoke()
        {
            foreach (string item in DeleteItem)
            {
                GBL_SUBMENUOBJECTDeleteData menudata = new GBL_SUBMENUOBJECTDeleteData();
                menudata.ObjectId = item;
                menudata.Delete();
            }
            
        }

    }
}
