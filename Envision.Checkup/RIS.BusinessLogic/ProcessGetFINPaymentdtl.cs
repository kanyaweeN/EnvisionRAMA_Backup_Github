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
	public class ProcessGetFINPaymentdtl : IBusinessLogic
	{
		private DataSet result;
		private FINPaymentdtl _finpaymentdtl;
		public ProcessGetFINPaymentdtl()
		{
			_finpaymentdtl = new  FINPaymentdtl();
		}
		public FINPaymentdtl FINPaymentdtl
		{
			get{return _finpaymentdtl;}
			set{_finpaymentdtl=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINPaymentdtlSelectData _proc=new FINPaymentdtlSelectData();
			_proc.FINPaymentdtl=this.FINPaymentdtl;
			result=_proc.GetData();
		}
	}
}

