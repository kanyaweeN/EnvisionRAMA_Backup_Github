using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteINVAuthorization : IBusinessLogic
	{
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteINVAuthorization()
		{
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
            Transaction = null;
		}
        public ProcessDeleteINVAuthorization(DbTransaction transaction)
        {
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
            Transaction = transaction;
        }
		
		public void Invoke()
		{
            INV_AUTHORIZATIONDeleteData _proc = new INV_AUTHORIZATIONDeleteData();
            _proc.INV_AUTHORIZATION = INV_AUTHORIZATION;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

