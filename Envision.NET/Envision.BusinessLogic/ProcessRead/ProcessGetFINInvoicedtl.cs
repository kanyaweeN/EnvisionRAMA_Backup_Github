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
	public class ProcessGetFINInvoicedtl : IBusinessLogic
	{
		private DataSet result;
        public FIN_INVOICEDTL FIN_INVOICEDTL { get; set; }
		public ProcessGetFINInvoicedtl()
		{
            FIN_INVOICEDTL = new FIN_INVOICEDTL();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINInvoicedtlSelectData _proc=new FINInvoicedtlSelectData();
            _proc.FIN_INVOICEDTL = this.FIN_INVOICEDTL;
			result=_proc.GetData();
		}
	}
}

