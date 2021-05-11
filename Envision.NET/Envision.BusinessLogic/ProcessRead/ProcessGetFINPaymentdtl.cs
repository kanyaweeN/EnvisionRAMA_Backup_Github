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
	public class ProcessGetFINPaymentdtl : IBusinessLogic
	{
		private DataSet result;
        public FIN_PAYMENTDTL FIN_PAYMENTDTL { get; set; }
		public ProcessGetFINPaymentdtl()
		{
            FIN_PAYMENTDTL = new FIN_PAYMENTDTL();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINPaymentdtlSelectData _proc=new FINPaymentdtlSelectData();
            _proc.FIN_PAYMENTDTL = this.FIN_PAYMENTDTL;
			result=_proc.GetData();
		}
	}
}

