using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISExamtransferlog : IBusinessLogic
	{
		private RISExamtransferlog _risexamtransferlog;
		public ProcessAddRISExamtransferlog()
		{
			_risexamtransferlog = new  RISExamtransferlog();
		}
		public RISExamtransferlog RISExamtransferlog		{
			get{return _risexamtransferlog;}
			set{_risexamtransferlog=value;}
		}
		public void Invoke()
		{
			RISExamtransferlogInsertData _proc=new RISExamtransferlogInsertData();
			_proc.RISExamtransferlog=this.RISExamtransferlog;
			_proc.Add();
		}
	}
}

