using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVPodtl : IBusinessLogic
	{
		private INVPodtl _invpodtl;
        private SqlTransaction tran = null;
		public ProcessAddINVPodtl()
		{
			_invpodtl = new  INVPodtl();
		}
        public ProcessAddINVPodtl(SqlTransaction Transaction)
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
			INVPodtlInsertData _proc=new INVPodtlInsertData();
			_proc.INVPodtl=this.INVPodtl;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
		}
	}
}

