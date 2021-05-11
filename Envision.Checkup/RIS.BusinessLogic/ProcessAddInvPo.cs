using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVPo : IBusinessLogic
	{
		private INVPo _invpo;
        private SqlTransaction tran = null;
		public ProcessAddINVPo()
		{
			_invpo = new  INVPo();
		}
        public ProcessAddINVPo(SqlTransaction transaction)
        {
            _invpo = new INVPo();
            tran = transaction;
        }
		public INVPo INVPo		{
			get{return _invpo;}
			set{_invpo=value;}
		}
		public void Invoke()
		{
			INVPoInsertData _proc=new INVPoInsertData();
			_proc.INVPo=this.INVPo;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
            this.INVPo.PO_ID = _proc.GetID();
		}
	}
}

