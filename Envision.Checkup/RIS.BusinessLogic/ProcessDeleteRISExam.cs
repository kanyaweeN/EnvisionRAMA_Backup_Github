using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISExam : IBusinessLogic
	{
		private RISExam _risexam;
		public ProcessDeleteRISExam(){
            _risexam = new RISExam();
        }
		public RISExam RISExam		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public void Invoke()
		{
			RISExamDeleteData _proc=new RISExamDeleteData();
			_proc.RISExam=this.RISExam;
			_proc.Delete();
		}
	}
}

