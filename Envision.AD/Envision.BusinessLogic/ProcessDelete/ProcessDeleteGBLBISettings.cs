using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteGBLBISettings : IBusinessLogic
    {
        public GBL_BISETTINGS GBL_BISETTINGS { get; set; }

        public ProcessDeleteGBLBISettings()
		{
            GBL_BISETTINGS = new GBL_BISETTINGS();
		}
        
		public void Invoke()
		{
            GBLBISettingsDeleteData _proc = new GBLBISettingsDeleteData();
            _proc.GBL_BISETTINGS = GBL_BISETTINGS;
			 _proc.Delete();
		}
    }
}
