using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISQaworks : IBusinessLogic
	{
        public RIS_QAWORK RIS_QAWORK { get; set; }
		public ProcessAddRISQaworks()
		{
            RIS_QAWORK = new RIS_QAWORK();
		}
		public void Invoke()
		{
			RISQaworksInsertData _proc=new RISQaworksInsertData();
            _proc.RIS_QAWORK = this.RIS_QAWORK;
			_proc.Add();
		}
	}
}

