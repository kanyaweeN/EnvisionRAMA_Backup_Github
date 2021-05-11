using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISExamresultseverity : IBusinessLogic
	{
		private RISExamresultseverity _risexamresultseverity;
		public ProcessAddRISExamresultseverity()
		{
			_risexamresultseverity = new  RISExamresultseverity();
		}
		public RISExamresultseverity RISExamresultseverity		{
			get{return _risexamresultseverity;}
			set{_risexamresultseverity=value;}
		}
		public void Invoke()
		{
			RISExamresultseverityInsertData _proc=new RISExamresultseverityInsertData();
			_proc.RISExamresultseverity=this.RISExamresultseverity;
			_proc.Add();
		}
	}
}

