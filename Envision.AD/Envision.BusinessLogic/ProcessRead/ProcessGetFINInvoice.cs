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
	public class ProcessGetFINInvoice : IBusinessLogic
	{
		private DataSet result;
        public FIN_INVOICE FIN_INVOICE;
		public ProcessGetFINInvoice()
		{
            FIN_INVOICE = new FIN_INVOICE();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			FINInvoiceSelectData _proc=new FINInvoiceSelectData();
            _proc.FIN_INVOICE = this.FIN_INVOICE;
			result=_proc.GetData();
		}
	}
}

