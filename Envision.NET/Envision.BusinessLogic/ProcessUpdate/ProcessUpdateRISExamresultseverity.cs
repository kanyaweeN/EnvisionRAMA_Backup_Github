using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISExamresultseverity : IBusinessLogic
	{
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }

		public ProcessUpdateRISExamresultseverity()
		{
            RIS_EXAMRESULTSEVERITY = new RIS_EXAMRESULTSEVERITY();
		}
		public void Invoke()
		{
			RISExamresultseverityUpdateData _proc=new RISExamresultseverityUpdateData();
            _proc.RIS_EXAMRESULTSEVERITY = this.RIS_EXAMRESULTSEVERITY;
			_proc.Update();
		}
	}
}

