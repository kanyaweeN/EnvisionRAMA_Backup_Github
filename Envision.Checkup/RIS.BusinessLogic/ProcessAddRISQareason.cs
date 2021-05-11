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
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISQareason : IBusinessLogic
	{
		private RISQareason _risqareason;
		private bool useTran;
		public ProcessAddRISQareason()
		{
			_risqareason = new  RISQareason();
			useTran=false;
		}
		public RISQareason RISQareason
		{
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
			RISQareasonInsertData _proc=new RISQareasonInsertData();
			_proc.RISQareason=this.RISQareason;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

