using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateINVAuthorization : IBusinessLogic
	{
        public INV_AUTHORIZATION INV_AUTHORIZATION { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateINVAuthorization()
		{
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
            Transaction = null;
		}
        public ProcessUpdateINVAuthorization(DbTransaction tran)
        {
            INV_AUTHORIZATION = new INV_AUTHORIZATION();
            Transaction = tran;
        }
		public void Invoke()
		{
			INVAuthorizationUpdateData _proc=new INVAuthorizationUpdateData();
            _proc.INV_AUTHORIZATION = this.INV_AUTHORIZATION;
            if (Transaction == null)
            {
                _proc.Update();
            }
            else
            {
                _proc.Update(Transaction);
            }
		}
	}
}

