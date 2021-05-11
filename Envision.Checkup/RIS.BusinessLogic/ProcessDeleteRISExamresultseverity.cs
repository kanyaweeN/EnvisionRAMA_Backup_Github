using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISExamresultseverity : IBusinessLogic
	{
		private RISExamresultseverity _risexamresultseverity;
		public ProcessDeleteRISExamresultseverity()
		{
			_risexamresultseverity = new  RISExamresultseverity();
		}
		public RISExamresultseverity RISExamresultseverity		{
			get{return _risexamresultseverity;}
			set{_risexamresultseverity=value;}
		}
		public void Invoke()
		{
			RISExamresultseverityDeleteData _proc=new RISExamresultseverityDeleteData();
			_proc.RISExamresultseverity=this.RISExamresultseverity;
			_proc.Delete();
		}
	}
}

