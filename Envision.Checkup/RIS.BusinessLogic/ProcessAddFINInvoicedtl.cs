//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:43
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
	public class ProcessAddFINInvoicedtl : IBusinessLogic
	{
		private FINInvoicedtl _fininvoicedtl;
		private bool useTran;
		public ProcessAddFINInvoicedtl()
		{
			_fininvoicedtl = new  FINInvoicedtl();
			useTran=false;
		}
		public FINInvoicedtl FINInvoicedtl
		{
			get{return _fininvoicedtl;}
			set{_fininvoicedtl=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			FINInvoicedtlInsertData _proc=new FINInvoicedtlInsertData();
			_proc.FINInvoicedtl=this.FINInvoicedtl;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

