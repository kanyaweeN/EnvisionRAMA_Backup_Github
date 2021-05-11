//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:41
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
	public class ProcessAddFINInvoice : IBusinessLogic
	{
		private FINInvoice _fininvoice;
		private bool useTran;
		public ProcessAddFINInvoice()
		{
			_fininvoice = new  FINInvoice();
			useTran=false;
		}
		public FINInvoice FINInvoice
		{
			get{return _fininvoice;}
			set{_fininvoice=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			FINInvoiceInsertData _proc=new FINInvoiceInsertData();
			_proc.FINInvoice=this.FINInvoice;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

