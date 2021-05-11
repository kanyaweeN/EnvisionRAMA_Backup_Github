using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVRequisitiondtl : IBusinessLogic
	{
		private INVRequisitiondtl _invrequisitiondtl;
        private SqlTransaction tran = null;
		public ProcessAddINVRequisitiondtl()
		{
			_invrequisitiondtl = new  INVRequisitiondtl();
		}
        public ProcessAddINVRequisitiondtl(SqlTransaction Transaction)
        {
            _invrequisitiondtl = new INVRequisitiondtl();
            tran = Transaction;
        }
		public INVRequisitiondtl INVRequisitiondtl		{
			get{return _invrequisitiondtl;}
			set{_invrequisitiondtl=value;}
		}
		public void Invoke()
		{
			INVRequisitiondtlInsertData _proc=new INVRequisitiondtlInsertData();
			_proc.INVRequisitiondtl=this.INVRequisitiondtl;
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

