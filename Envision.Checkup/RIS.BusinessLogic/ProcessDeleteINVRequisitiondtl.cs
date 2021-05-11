using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteINVRequisitiondtl : IBusinessLogic
	{
		private INVRequisitiondtl _invrequisitiondtl;
        SqlTransaction tran = null;
		public ProcessDeleteINVRequisitiondtl()
		{
			_invrequisitiondtl = new  INVRequisitiondtl();
		}
        public ProcessDeleteINVRequisitiondtl(SqlTransaction Transaction)
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
			INVRequisitiondtlDeleteData _proc=new INVRequisitiondtlDeleteData();
			_proc.INVRequisitiondtl=this.INVRequisitiondtl;
			_proc.Delete();
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

