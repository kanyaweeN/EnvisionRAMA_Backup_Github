using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISTechworks : IBusinessLogic
	{
        public RIS_TECHWORK RIS_TECHWORK { get; set; }
        private int action;
		public ProcessAddRISTechworks()
		{
            RIS_TECHWORK = new RIS_TECHWORK();
            action = 0;
		}
        public ProcessAddRISTechworks(RIS_TECHWORK ristechworks)
        {
            RIS_TECHWORK = ristechworks;
            action = 1;
        }
		public void Invoke()
		{
            RISTechworksInsertData _proc = null;
            if (action == 0)
                _proc = new RISTechworksInsertData();
            else
                _proc = new RISTechworksInsertData(true);
            _proc.RIS_TECHWORK = this.RIS_TECHWORK;
			_proc.Add();
		}
	}
}

