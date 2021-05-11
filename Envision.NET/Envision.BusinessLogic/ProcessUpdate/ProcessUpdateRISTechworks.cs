using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISTechworks : IBusinessLogic
	{
        public RIS_TECHWORK RIS_TECHWORK { get; set; } 

		public ProcessUpdateRISTechworks()
		{
            RIS_TECHWORK = new RIS_TECHWORK();
		}
		public void Invoke()
		{
			RISTechworksUpdateData _proc=new RISTechworksUpdateData();
            _proc.RIS_TECHWORK = RIS_TECHWORK;
			_proc.Update();
		}
	}
}

