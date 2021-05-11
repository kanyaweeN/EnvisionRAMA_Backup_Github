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
	public class ProcessGetFINPayment : IBusinessLogic
	{
		private DataSet result;
		private FINPayment _finpayment;
		public ProcessGetFINPayment()
		{
			_finpayment = new  FINPayment();
		}
		public FINPayment FINPayment
		{
			get{return _finpayment;}
			set{_finpayment=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINPaymentSelectData _proc=new FINPaymentSelectData();
			_proc.FINPayment=this.FINPayment;
			result=_proc.GetData();
		}
	}
}

