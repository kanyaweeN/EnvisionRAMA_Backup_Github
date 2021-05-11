using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISExam : IBusinessLogic
	{
		private RISExam _risexam;
		public ProcessAddRISExam(){
            _risexam = new RISExam();
        }
		public RISExam RISExam		{
			get{return _risexam;}
			set{_risexam=value;}
		}
		public void Invoke()
		{
			RISExamInsertData _proc=new RISExamInsertData();
			_proc.RISExam=this.RISExam;
			_proc.Add();
		}
	}
}

