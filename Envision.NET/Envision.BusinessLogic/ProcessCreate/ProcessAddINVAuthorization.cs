using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddINVAuthorization : IBusinessLogic
	{
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddINVAuthorization()
		{
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
            Transaction = null;
		}
        public ProcessAddINVAuthorization(DbTransaction tran)
        {
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVAuthorizationInsertData _proc=new INVAuthorizationInsertData();
            _proc.INV_AUTHORIZATION = this.INV_AUTHORIZATION;
            if (Transaction == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(Transaction);
            }
		}
	}
}

