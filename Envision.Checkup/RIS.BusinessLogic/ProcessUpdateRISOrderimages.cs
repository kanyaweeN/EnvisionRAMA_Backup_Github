using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISOrderimages : IBusinessLogic
	{
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
            RISOrderimagesUpdateData _proc = new RISOrderimagesUpdateData();
            _proc.RIS_ORDERIMAGE = this.RIS_ORDERIMAGE;
            _proc.UpdateOrder();
        }
	}
}

