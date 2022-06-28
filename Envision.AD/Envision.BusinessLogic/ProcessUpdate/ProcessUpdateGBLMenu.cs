using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateGBLMenu : IBusinessLogic
    {
        public GBL_MENU GBL_MENU { get; set; }

        public ProcessUpdateGBLMenu()
        {
            GBL_MENU = new GBL_MENU();
        }

        public void Invoke()
        {
            GBLMenuUpdateData menudata = new GBLMenuUpdateData();
            menudata.GBL_MENU = this.GBL_MENU;
            menudata.Add();

        }
    }
}
