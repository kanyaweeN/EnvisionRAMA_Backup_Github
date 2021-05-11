using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISExamtransferlog : IBusinessLogic
	{
		private RISExamtransferlog _risexamtransferlog;
		public ProcessUpdateRISExamtransferlog()
		{
			_risexamtransferlog = new RISExamtransferlog();
		}
		public RISExamtransferlog RISExamtransferlog		{
			get{return _risexamtransferlog;}
			set{_risexamtransferlog=value;}
		}
		public void Invoke()
		{
			RISExamtransferlogUpdateData _proc=new RISExamtransferlogUpdateData();
			_proc.RISExamtransferlog=this.RISExamtransferlog;
			_proc.Update();
		}
	}
}

