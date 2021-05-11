using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteINVAuthorization : IBusinessLogic
	{
		private INVAuthorization _invauthorization;
        SqlTransaction tran = null;
		public ProcessDeleteINVAuthorization()
		{
			_invauthorization = new  INVAuthorization();
		}
        public ProcessDeleteINVAuthorization(SqlTransaction Transaction)
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
			INVAuthorizationDeleteData _proc=new INVAuthorizationDeleteData();
			_proc.INVAuthorization=this.INVAuthorization;
            if (tran == null)
            {
                _proc.Delete();
            }
            else
            {
                _proc.Delete(tran);
            }
		}
	}
}

