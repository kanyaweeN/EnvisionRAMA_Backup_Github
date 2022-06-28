using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
	public class ProcessGetINVRequisition : IBusinessLogic
	{
        public INV_REQUISITION INV_REQUISITION { get; set; }
		private DataSet result;

		public ProcessGetINVRequisition()
		{
            INV_REQUISITION = new INV_REQUISITION();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVRequisitionSelectData _proc=new INVRequisitionSelectData();
            _proc.INV_REQUISITION = this.INV_REQUISITION;
			result=_proc.GetData();
		}
        public void Invoke222()
        {
            InvItemSelectData _proc = new InvItemSelectData();
            result = _proc.Query();
        }
        public DataSet SelectAll()
        {
           INVRequisitionSelectData _proc=new INVRequisitionSelectData();
           return _proc.SelectAll();
        }
        public DataSet GetREQMaster(int REQUISITION_ID, int UNIT_ID)
        {
            INVRequisitionSelectData _proc = new INVRequisitionSelectData();
            _proc.INV_REQUISITION = INV_REQUISITION;
            return _proc.GetREQMaster(REQUISITION_ID, UNIT_ID);
        }
        public DataSet GetREQDetail(int REQUISITION_ID, int UNIT_ID)
        {
            INVRequisitionSelectData _proc = new INVRequisitionSelectData();
            _proc.INV_REQUISITION = INV_REQUISITION;
            return _proc.GetREQDetail(REQUISITION_ID, UNIT_ID);
        }
        public DataSet SelectForTranfer()
        {
            INVRequisitionSelectData _proc = new INVRequisitionSelectData();
            return _proc.SelectForTranfer();
        }
	}
}

