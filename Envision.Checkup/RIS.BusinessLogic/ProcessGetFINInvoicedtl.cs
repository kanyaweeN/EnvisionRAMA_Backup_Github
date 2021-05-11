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
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetFINInvoicedtl : IBusinessLogic
	{
		private DataSet result;
		private FINInvoicedtl _fininvoicedtl;
		public ProcessGetFINInvoicedtl()
		{
			_fininvoicedtl = new  FINInvoicedtl();
		}
		public FINInvoicedtl FINInvoicedtl
		{
			get{return _fininvoicedtl;}
			set{_fininvoicedtl=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINInvoicedtlSelectData _proc=new FINInvoicedtlSelectData();
			_proc.FINInvoicedtl=this.FINInvoicedtl;
			result=_proc.GetData();
		}
	}
}

