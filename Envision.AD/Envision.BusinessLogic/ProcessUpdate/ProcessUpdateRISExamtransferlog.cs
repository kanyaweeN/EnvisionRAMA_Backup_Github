using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISExamtransferlog : IBusinessLogic
	{
        public RIS_EXAMTRANSFERLOG RIS_EXAMTRANSFERLOG { get; set; }

		public ProcessUpdateRISExamtransferlog()
		{
            RIS_EXAMTRANSFERLOG = new RIS_EXAMTRANSFERLOG();
		}
		public void Invoke()
		{
			RISExamtransferlogUpdateData _proc=new RISExamtransferlogUpdateData();
            _proc.RIS_EXAMTRANSFERLOG = this.RIS_EXAMTRANSFERLOG;
			_proc.Update();
		}
	}
}

