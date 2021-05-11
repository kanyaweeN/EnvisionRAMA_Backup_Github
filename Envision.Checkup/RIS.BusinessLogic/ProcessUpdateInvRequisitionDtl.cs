using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using System.Data.SqlClient;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateINVRequisitiondtl : IBusinessLogic
	{
		private INVRequisitiondtl _invrequisitiondtl;
        private SqlTransaction tran = null;
		public ProcessUpdateINVRequisitiondtl()
		{
			_invrequisitiondtl = new INVRequisitiondtl();
		}
        public ProcessUpdateINVRequisitiondtl(SqlTransaction Transaction)
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
			INVRequisitiondtlUpdateData _proc=new INVRequisitiondtlUpdateData();
			_proc.INVRequisitiondtl=this.INVRequisitiondtl;
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

