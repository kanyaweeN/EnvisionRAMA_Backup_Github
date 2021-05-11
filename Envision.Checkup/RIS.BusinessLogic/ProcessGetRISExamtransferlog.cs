using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISExamtransferlog : IBusinessLogic
	{
		private DataSet result;
		private RISExamtransferlog _risexamtransferlog;
		public ProcessGetRISExamtransferlog(int UserID)
		{
			_risexamtransferlog = new  RISExamtransferlog();
            _risexamtransferlog.CREATED_BY = UserID;
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamtransferlogSelectData _proc=new RISExamtransferlogSelectData();
            _proc.RISExamtransferlog = _risexamtransferlog;
			result=_proc.GetData();
		}
	}
}

