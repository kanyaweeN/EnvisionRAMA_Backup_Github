using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISExamhospital : IBusinessLogic
	{
		private RISExamhospital _risexamhospital;
		public ProcessDeleteRISExamhospital()
		{
			_risexamhospital = new  RISExamhospital();
		}
		public RISExamhospital RISExamhospital		{
			get{return _risexamhospital;}
			set{_risexamhospital=value;}
		}
		public void Invoke()
		{
			RISExamhospitalDeleteData _proc=new RISExamhospitalDeleteData();
			_proc.RISExamhospital=this.RISExamhospital;
			_proc.Delete();
		}
	}
}

