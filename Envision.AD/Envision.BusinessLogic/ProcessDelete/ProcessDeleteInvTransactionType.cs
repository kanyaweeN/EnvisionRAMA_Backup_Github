using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteInvTransactionType : IBusinessLogic
    {
        public INV_TRANSACTIONTYPE INV_TRANSACTIONTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

        public ProcessDeleteInvTransactionType()
        {
            INV_TRANSACTIONTYPE = new INV_TRANSACTIONTYPE();
            Transaction = null;
        }

        public void Invoke()
        {
            INV_TRANSACTIONTYPEDeleteData delete = new INV_TRANSACTIONTYPEDeleteData();
            delete.INV_TRANSACTIONTYPE = INV_TRANSACTIONTYPE;
            delete.Delete();
        }
    }
}
