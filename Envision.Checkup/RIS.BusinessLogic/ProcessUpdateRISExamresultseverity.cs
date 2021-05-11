using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISExamresultseverity : IBusinessLogic
	{
		private RISExamresultseverity _risexamresultseverity;
		public ProcessUpdateRISExamresultseverity()
		{
			_risexamresultseverity = new RISExamresultseverity();
		}
		public RISExamresultseverity RISExamresultseverity		{
			get{return _risexamresultseverity;}
			set{_risexamresultseverity=value;}
		}
		public void Invoke()
		{
			RISExamresultseverityUpdateData _proc=new RISExamresultseverityUpdateData();
			_proc.RISExamresultseverity=this.RISExamresultseverity;
			_proc.Update();
		}
	}
}

