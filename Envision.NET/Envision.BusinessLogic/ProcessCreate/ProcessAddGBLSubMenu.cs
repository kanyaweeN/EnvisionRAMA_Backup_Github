using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddGBLSubMenu : IBusinessLogic
    {
        public GBL_SUBMENU GBL_SUBMENU { get; set; }

        public ProcessAddGBLSubMenu()
        {
            GBL_SUBMENU = new GBL_SUBMENU();
        }

        public void Invoke()
        {
            GBLSubMenuInsertData menudata = new GBLSubMenuInsertData();
            menudata.GBL_SUBMENU = this.GBL_SUBMENU;
            menudata.Add();

        }
    }
}
