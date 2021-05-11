using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteINVPrdtl : IBusinessLogic
	{
		private INVPrdtl _invprdtl;
        SqlTransaction tran = null;
		public ProcessDeleteINVPrdtl()
		{
			_invprdtl = new  INVPrdtl();
		}
        public ProcessDeleteINVPrdtl(SqlTransaction Transaction)
        {
            _invprdtl = new INVPrdtl();
            tran = Transaction;
        }
		public INVPrdtl INVPrdtl		{
			get{return _invprdtl;}
			set{_invprdtl=value;}
		}
		public void Invoke()
		{
			INVPrdtlDeleteData _proc=new INVPrdtlDeleteData();
			_proc.INVPrdtl=this.INVPrdtl;
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

