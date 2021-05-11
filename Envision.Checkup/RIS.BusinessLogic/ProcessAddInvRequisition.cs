using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
using System.Data.SqlClient;
namespace RIS.BusinessLogic
{
	public class ProcessAddINVRequisition : IBusinessLogic
	{
		private INVRequisition _invrequisition;
        private SqlTransaction tran = null;
		public ProcessAddINVRequisition()
		{
			_invrequisition = new  INVRequisition();
		}
        public ProcessAddINVRequisition(SqlTransaction transaction)
        {
            _invrequisition = new INVRequisition();
            tran = transaction;
        }
		public INVRequisition INVRequisition		{
			get{return _invrequisition;}
			set{_invrequisition=value;}
		}
		public void Invoke()
		{
            INVRequisitionInsertData _proc = new INVRequisitionInsertData();
            _proc.INVRequisition = this.INVRequisition;
            if (tran == null)
            {
                _proc.Add();
            }
            else
            {
                _proc.Add(tran);
            }
            this.INVRequisition.REQUISITION_ID = _proc.GetID();
		}
	}
}

