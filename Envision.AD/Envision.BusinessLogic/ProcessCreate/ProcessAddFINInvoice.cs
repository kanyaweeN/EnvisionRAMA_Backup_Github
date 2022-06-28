//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:41
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddFINInvoice : IBusinessLogic
	{
        public FIN_INVOICE FIN_INVOICE { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddFINInvoice()
		{
            FIN_INVOICE = new FIN_INVOICE();
            Transaction = null;
		}
		public void Invoke()
		{
			FINInvoiceInsertData _proc=new FINInvoiceInsertData();
            _proc.FIN_INVOICE = this.FIN_INVOICE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

