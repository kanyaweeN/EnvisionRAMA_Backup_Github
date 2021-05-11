using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteINVPodtl : IBusinessLogic
	{
		private INVPodtl _invpodtl;
        SqlTransaction tran = null;
		public ProcessDeleteINVPodtl()
		{
			_invpodtl = new  INVPodtl();
		}
        public ProcessDeleteINVPodtl(SqlTransaction Transaction)
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
			INVPodtlDeleteData _proc=new INVPodtlDeleteData();
			_proc.INVPodtl=this.INVPodtl;
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

