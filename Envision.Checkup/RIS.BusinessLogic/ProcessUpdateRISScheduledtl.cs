using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateRISScheduledtl : IBusinessLogic
    {
        private RISScheduledtl _risscheduledtl;
		private bool useTran;
        public ProcessUpdateRISScheduledtl()
		{
            _risscheduledtl = new RISScheduledtl();
			useTran=false;
		}
        public RISScheduledtl RISScheduledtl
        {
            get { return _risscheduledtl; }
            set { _risscheduledtl = value; }
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
            RISScheduleDtlUpdateData _proc = new RISScheduleDtlUpdateData();
            _proc.RISScheduledtl = this.RISScheduledtl;
			/*useTran= useTran ?_proc.Update(useTran,true):*/_proc.Update();
		}
    }
}
