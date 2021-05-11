using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLSubMenu : IBusinessLogic
    {
        public GBL_SUBMENU GBL_SUBMENU { get; set; }

        public ProcessUpdateGBLSubMenu()
        {
            GBL_SUBMENU = new GBL_SUBMENU();
        }

        public void Invoke()
        {
            GBLSubMenuUpdateData menudata = new GBLSubMenuUpdateData();
            menudata.GBL_SUBMENU = this.GBL_SUBMENU;
            menudata.Add();

        }
    }
}
