using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateINVAuthorization : IBusinessLogic
	{
		private INVAuthorization _invauthorization;
        private SqlTransaction tran = null;
		public ProcessUpdateINVAuthorization()
		{
			_invauthorization = new INVAuthorization();
		}
        public ProcessUpdateINVAuthorization(SqlTransaction Transaction)
        {
            _invauthorization = new INVAuthorization();
            tran = Transaction;
        }
		public INVAuthorization INVAuthorization		{
			get{return _invauthorization;}
			set{_invauthorization=value;}
		}
		public void Invoke()
		{
			INVAuthorizationUpdateData _proc=new INVAuthorizationUpdateData();
			_proc.INVAuthorization=this.INVAuthorization;
            if (tran == null)
            {
                _proc.Update();
            }
            else
            {
                _proc.Update(tran);
            }
		}
	}
}

