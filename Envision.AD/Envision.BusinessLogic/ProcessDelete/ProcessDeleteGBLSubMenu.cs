using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLSubMenu : IBusinessLogic
    {
        public GBL_SUBMENU GBL_SUBMENU { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteGBLSubMenu()
        {
            Transaction = null;
            GBL_SUBMENU = new GBL_SUBMENU();
        }

        public void Invoke()
        {
            GBL_SUBMENUDeleteData menudata = new GBL_SUBMENUDeleteData();
            menudata.GBL_SUBMENU = GBL_SUBMENU;
            menudata.Delete();
        }
    }
}
