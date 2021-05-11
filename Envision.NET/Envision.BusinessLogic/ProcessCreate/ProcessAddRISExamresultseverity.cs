using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISExamresultseverity : IBusinessLogic
	{
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }
		public ProcessAddRISExamresultseverity()
		{
            RIS_EXAMRESULTSEVERITY = new RIS_EXAMRESULTSEVERITY();
		}
		public void Invoke()
		{
			RISExamresultseverityInsertData _proc=new RISExamresultseverityInsertData();
            _proc.RIS_EXAMRESULTSEVERITY = this.RIS_EXAMRESULTSEVERITY;
			_proc.Add();
		}
	}
}

