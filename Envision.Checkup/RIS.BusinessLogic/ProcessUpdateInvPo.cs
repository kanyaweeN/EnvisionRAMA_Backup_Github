using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateINVPo : IBusinessLogic
	{
		private INVPo _invpo;
        private SqlTransaction tran = null;
		public ProcessUpdateINVPo()
		{
			_invpo = new INVPo();
		}
        public ProcessUpdateINVPo(SqlTransaction Transaction)
        {
            _invpo = new INVPo();
            tran = Transaction;
        }
		public INVPo INVPo		{
			get{return _invpo;}
			set{_invpo=value;}
		}
        
		public void Invoke()
		{
			INVPoUpdateData _proc=new INVPoUpdateData();
			_proc.INVPo=this.INVPo;
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

