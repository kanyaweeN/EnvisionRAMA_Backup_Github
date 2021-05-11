//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    20/05/2009 04:53:30
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISQareason : IBusinessLogic
	{
		private RISQareason _risqareason;
		private bool useTran;
		public ProcessDeleteRISQareason()
		{
			_risqareason = new  RISQareason();
			useTran=false;
		}
		public RISQareason RISQareason		{
			get{return _risqareason;}
			set{_risqareason=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISQareasonDeleteData _proc=new RISQareasonDeleteData();
			_proc.RISQareason=this.RISQareason;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

