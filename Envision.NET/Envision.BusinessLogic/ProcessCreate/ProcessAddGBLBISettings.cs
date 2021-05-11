using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddGBLBISettings : IBusinessLogic
	{
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }
        public ProcessAddGBLBISettings()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
		}
		public void Invoke()
		{
            GBLBISettingsInsertData _proc = new GBLBISettingsInsertData();
            _proc.GBL_BISETTINGS = this.GBL_BISETTINGS;
			_proc.Add();
		}
	}
}

