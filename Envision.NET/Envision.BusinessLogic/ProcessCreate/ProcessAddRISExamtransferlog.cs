using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISExamtransferlog : IBusinessLogic
	{
        public RIS_EXAMTRANSFERLOG RIS_EXAMTRANSFERLOG { get; set; }
		public ProcessAddRISExamtransferlog()
		{
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
		}
		public void Invoke()
		{
			RISExamtransferlogInsertData _proc=new RISExamtransferlogInsertData();
            _proc.RIS_EXAMTRANSFERLOG = this.RIS_EXAMTRANSFERLOG;
			_proc.Add();
		}
	}
}

