using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetFINPayment : IBusinessLogic
	{
		private DataSet result;
        public FIN_PAYMENT FIN_PAYMENT { get; set; }
		public ProcessGetFINPayment()
		{
            FIN_PAYMENT = new FIN_PAYMENT();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINPaymentSelectData _proc=new FINPaymentSelectData();
            _proc.FIN_PAYMENT = this.FIN_PAYMENT;
			result=_proc.GetData();
		}
	}
}

