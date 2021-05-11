using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISExamtransferlog : IBusinessLogic
	{
		private RISExamtransferlog _risexamtransferlog;
		public ProcessDeleteRISExamtransferlog()
		{
			_risexamtransferlog = new  RISExamtransferlog();
		}
		public RISExamtransferlog RISExamtransferlog		{
			get{return _risexamtransferlog;}
			set{_risexamtransferlog=value;}
		}
		public void Invoke()
		{
			RISExamtransferlogDeleteData _proc=new RISExamtransferlogDeleteData();
			_proc.RISExamtransferlog=this.RISExamtransferlog;
			_proc.Delete();
		}
	}
}

