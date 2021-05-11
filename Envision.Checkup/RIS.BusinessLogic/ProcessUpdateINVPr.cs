using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateINVPr : IBusinessLogic
	{
		private INVPr _invpr;
        private SqlTransaction tran = null;
		public ProcessUpdateINVPr()
		{
			_invpr = new INVPr();
		}
        public ProcessUpdateINVPr(SqlTransaction Transaction)
        {
            _invpr = new INVPr();
            tran = Transaction;
        }
		public INVPr INVPr		{
			get{return _invpr;}
			set{_invpr=value;}
		}
		public void Invoke()
		{
			INVPrUpdateData _proc=new INVPrUpdateData();
			_proc.INVPr=this.INVPr;
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

