using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISBpview : IBusinessLogic
	{
        public RIS_BPVIEW RIS_BPVIEW { get; set; }
		public ProcessAddRISBpview()
		{
            RIS_BPVIEW = new RIS_BPVIEW();
		}
		public void Invoke()
		{
			RISBpviewInsertData _proc=new RISBpviewInsertData();
            _proc.RIS_BPVIEW = this.RIS_BPVIEW;
			_proc.Add();
		}
	}
}

