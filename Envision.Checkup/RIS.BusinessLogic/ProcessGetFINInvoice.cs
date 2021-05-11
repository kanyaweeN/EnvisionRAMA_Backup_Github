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
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetFINInvoice : IBusinessLogic
	{
		private DataSet result;
		private FINInvoice _fininvoice;
		public ProcessGetFINInvoice()
		{
			_fininvoice = new  FINInvoice();
		}
		public FINInvoice FINInvoice
		{
			get{return _fininvoice;}
			set{_fininvoice=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINInvoiceSelectData _proc=new FINInvoiceSelectData();
			_proc.FINInvoice=this.FINInvoice;
			result=_proc.GetData();
		}
	}
}

