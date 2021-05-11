using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVPrdtl : IBusinessLogic
	{
		private INVPrdtl _invprdtl;
        private SqlTransaction tran = null;
		public ProcessAddINVPrdtl()
		{
			_invprdtl = new  INVPrdtl();
		}
        public ProcessAddINVPrdtl(SqlTransaction Transaction)
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
			INVPrdtlInsertData _proc=new INVPrdtlInsertData();
			_proc.INVPrdtl=this.INVPrdtl;
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

