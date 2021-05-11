using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISExamhospital : IBusinessLogic
	{
		private RISExamhospital _risexamhospital;
		public ProcessUpdateRISExamhospital()
		{
			_risexamhospital = new RISExamhospital();
		}
		public RISExamhospital RISExamhospital		{
			get{return _risexamhospital;}
			set{_risexamhospital=value;}
		}
		public void Invoke()
		{
			RISExamhospitalUpdateData _proc=new RISExamhospitalUpdateData();
			_proc.RISExamhospital=this.RISExamhospital;
			_proc.Update();
		}
	}
}

