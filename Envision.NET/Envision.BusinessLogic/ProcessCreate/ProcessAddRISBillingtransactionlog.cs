//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    23/03/2553 05:16:49
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic
{
	public class ProcessAddRISBillingtransactionlog : IBusinessLogic
	{
		private RISBillingtransactionlog _risbillingtransactionlog;
		private bool useTran;
		public ProcessAddRISBillingtransactionlog()
		{
			_risbillingtransactionlog = new  RISBillingtransactionlog();
			useTran=false;
		}
		public RISBillingtransactionlog RISBillingtransactionlog
		{
			get{return _risbillingtransactionlog;}
			set{_risbillingtransactionlog=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISBillingtransactionlogInsertData _proc=new RISBillingtransactionlogInsertData();
			_proc.RISBillingtransactionlog=this.RISBillingtransactionlog;
			_proc.Add();
		}
	}
}

