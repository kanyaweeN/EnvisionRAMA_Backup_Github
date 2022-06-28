//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    08/02/2009 02:32:43
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddFINInvoicedtl : IBusinessLogic
	{
        public FIN_INVOICEDTL FIN_INVOICEDTL { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddFINInvoicedtl()
		{
            FIN_INVOICEDTL = new FIN_INVOICEDTL();
            Transaction = null;
		}
		public void Invoke()
		{
			FINInvoicedtlInsertData _proc=new FINInvoicedtlInsertData();
            _proc.FIN_INVOICEDTL = this.FIN_INVOICEDTL;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

