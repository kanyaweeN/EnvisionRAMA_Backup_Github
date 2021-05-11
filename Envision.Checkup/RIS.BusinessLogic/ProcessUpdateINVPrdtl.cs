using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateINVPrdtl : IBusinessLogic
	{
		private INVPrdtl _invprdtl;
        private SqlTransaction tran = null;
		public ProcessUpdateINVPrdtl()
		{
			_invprdtl = new INVPrdtl();
		}
        public ProcessUpdateINVPrdtl(SqlTransaction Transaction)
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
			INVPrdtlUpdateData _proc=new INVPrdtlUpdateData();
			_proc.INVPrdtl=this.INVPrdtl;
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

