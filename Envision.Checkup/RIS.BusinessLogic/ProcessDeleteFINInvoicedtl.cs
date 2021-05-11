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
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteFINInvoicedtl : IBusinessLogic
	{
		private FINInvoicedtl _fininvoicedtl;
		private bool useTran;
		public ProcessDeleteFINInvoicedtl()
		{
			_fininvoicedtl = new  FINInvoicedtl();
			useTran=false;
		}
		public FINInvoicedtl FINInvoicedtl		{
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
			FINInvoicedtlDeleteData _proc=new FINInvoicedtlDeleteData();
			_proc.FINInvoicedtl=this.FINInvoicedtl;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

