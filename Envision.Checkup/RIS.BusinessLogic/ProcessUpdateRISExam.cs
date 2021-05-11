using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISExam : IBusinessLogic
	{
		private RISExam _risexam;
		public ProcessUpdateRISExam(){
            _risexam = new RISExam();
        }
		public RISExam RISExam		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public void Invoke()
		{
			RISExamUpdateData _proc=new RISExamUpdateData();
			_proc.RISExam=this.RISExam;
			_proc.Update();
		}
	}
}

