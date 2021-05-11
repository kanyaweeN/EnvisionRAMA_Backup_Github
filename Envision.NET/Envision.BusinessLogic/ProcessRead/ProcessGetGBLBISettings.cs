using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;
using Envision.Common;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetGBLBISettings
    {
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }

        public ProcessGetGBLBISettings()
        {
            GBL_BISETTINGS = new GBL_BISETTINGS();
        }

        public DataTable GetData()
        {
            GBLBISettingsSelectData select = new GBLBISettingsSelectData();
            select.GBL_BISETTINGS = this.GBL_BISETTINGS;
            return select.Get().Tables[0];
        }
    }
}
