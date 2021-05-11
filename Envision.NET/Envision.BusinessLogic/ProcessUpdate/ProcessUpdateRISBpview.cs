using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISBpview : IBusinessLogic
	{
        public RIS_BPVIEW RIS_BPVIEW { get; set; }

		public ProcessUpdateRISBpview()
		{
            RIS_BPVIEW = new RIS_BPVIEW();
		}
		public void Invoke()
		{
			RISBpviewUpdateData _proc=new RISBpviewUpdateData();
            _proc.RIS_BPVIEW = this.RIS_BPVIEW;
			_proc.Update();
		}
	}
}

