using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateINVPodtl : IBusinessLogic
	{
		private INVPodtl _invpodtl;
        private SqlTransaction tran = null;
		public ProcessUpdateINVPodtl()
		{
			_invpodtl = new INVPodtl();
		}
        public ProcessUpdateINVPodtl(SqlTransaction Transaction)
		{
            _invpodtl = new INVPodtl();
            tran = Transaction;
		}
		public INVPodtl INVPodtl		{
			get{return _invpodtl;}
			set{_invpodtl=value;}
		}
		public void Invoke()
		{
			INVPodtlUpdateData _proc=new INVPodtlUpdateData();
			_proc.INVPodtl=this.INVPodtl;
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

