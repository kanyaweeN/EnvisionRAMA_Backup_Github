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
	public class ProcessAddFINPayment : IBusinessLogic
	{
        public FIN_PAYMENT FIN_PAYMENT { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessAddFINPayment()
		{
            FIN_PAYMENT = new FIN_PAYMENT();
            Transaction = null;
		}
		public void Invoke()
		{
			FINPaymentInsertData _proc=new FINPaymentInsertData();
            _proc.FIN_PAYMENT = this.FIN_PAYMENT;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

