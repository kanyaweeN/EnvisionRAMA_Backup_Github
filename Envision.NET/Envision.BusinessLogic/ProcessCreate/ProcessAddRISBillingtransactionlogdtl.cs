//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    23/03/2553 05:48:15
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
	public class ProcessAddRISBillingtransactionlogdtl : IBusinessLogic
	{
        private RISBillingtransactionlogdtl _risbillingtransactionlogdtl;
		private bool useTran;
		public ProcessAddRISBillingtransactionlogdtl()
		{
			_risbillingtransactionlogdtl = new  RISBillingtransactionlogdtl();
			useTran=false;
		}
		public RISBillingtransactionlogdtl RISBillingtransactionlogdtl
		{
			get{return _risbillingtransactionlogdtl;}
			set{_risbillingtransactionlogdtl=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISBillingtransactionlogdtlInsertData _proc=new RISBillingtransactionlogdtlInsertData();
			_proc.RISBillingtransactionlogdtl=this.RISBillingtransactionlogdtl;
			_proc.Add();
		}
	}
}

