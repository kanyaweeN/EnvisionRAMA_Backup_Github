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
	public class ProcessAddFINPaymentdtl : IBusinessLogic
	{
        public FIN_PAYMENTDTL FIN_PAYMENTDTL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddFINPaymentdtl()
		{
            FIN_PAYMENTDTL = new FIN_PAYMENTDTL();
            Transaction = null;
		}
		public void Invoke()
		{
			FINPaymentdtlInsertData _proc=new FINPaymentdtlInsertData();
            _proc.FIN_PAYMENTDTL = this.FIN_PAYMENTDTL;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

