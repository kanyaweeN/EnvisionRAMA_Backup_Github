using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISPatstatus : IBusinessLogic
	{
		private RISPatstatus _rispatstatus;
		public ProcessUpdateRISPatstatus()
		{
			_rispatstatus = new RISPatstatus();
		}
		public RISPatstatus RISPatstatus		{
			get{return _rispatstatus;}
			set{_rispatstatus=value;}
		}
		public void Invoke()
		{
            RISPatstatusUpdateData _proc = new RISPatstatusUpdateData();
            _proc.RISPatstatus = this.RISPatstatus;
            _proc.Update();
		}
	}
}

