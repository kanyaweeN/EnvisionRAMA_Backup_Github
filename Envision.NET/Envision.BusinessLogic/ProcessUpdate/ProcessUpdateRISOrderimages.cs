using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISOrderimages : IBusinessLogic
	{
        public DbTransaction Transaction { get; set; }
        public RIS_ORDERIMAGE RIS_ORDERIMAGE { get; set; }

		public ProcessUpdateRISOrderimages()
		{
            RIS_ORDERIMAGE = new RIS_ORDERIMAGE();
		}
		public void Invoke()
		{
			RISOrderimagesUpdateData _proc=new RISOrderimagesUpdateData();
            _proc.RIS_ORDERIMAGE = this.RIS_ORDERIMAGE;
			_proc.Update();
		}
        public void UpdateOrder()
        {
            RISOrderimagesUpdateData _proc = new RISOrderimagesUpdateData(RIS_ORDERIMAGE);
            _proc.RIS_ORDERIMAGE = this.RIS_ORDERIMAGE;
            _proc.UpdateOrder();
        }
        public void UpdateOrderIdByScheduleId()
        {
            RISOrderimagesUpdateData _proc = new RISOrderimagesUpdateData();
            _proc.RIS_ORDERIMAGE = this.RIS_ORDERIMAGE;
            if (this.Transaction == null)
                _proc.UpdateOrderIdByScheduleId();
            else
                _proc.UpdateOrderIdByScheduleId(Transaction);
            
        }
        public void InvokeIsDeleted()
        {
            RISOrderimagesUpdateData prc = new RISOrderimagesUpdateData();
            prc.RIS_ORDERIMAGE = RIS_ORDERIMAGE;
            prc.UpdateIsDeleted();
        }
	}
}

