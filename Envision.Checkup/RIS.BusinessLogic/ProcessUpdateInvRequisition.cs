using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateINVRequisition : IBusinessLogic
	{
		private INVRequisition _invrequisition;
        private SqlTransaction tran = null;
		public ProcessUpdateINVRequisition()
		{
			_invrequisition = new INVRequisition();
		}
        public ProcessUpdateINVRequisition(SqlTransaction Transaction)
        {
            _invrequisition = new INVRequisition();
            tran = Transaction;
        }
		public INVRequisition INVRequisition		{
			get{return _invrequisition;}
			set{_invrequisition=value;}
		}
		public void Invoke()
		{
			INVRequisitionUpdateData _proc=new INVRequisitionUpdateData();
			_proc.INVRequisition=this.INVRequisition;
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

