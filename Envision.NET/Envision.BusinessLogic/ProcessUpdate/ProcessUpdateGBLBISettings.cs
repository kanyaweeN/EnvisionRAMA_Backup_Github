using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateGBLBISettings : IBusinessLogic
	{
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }

        public ProcessUpdateGBLBISettings()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
		}
		public void Invoke()
		{
            GBLBISettingsUpdateData _proc = new GBLBISettingsUpdateData();
            _proc.GBL_BISETTINGS = this.GBL_BISETTINGS;
			_proc.Update();
		}
	}
}

