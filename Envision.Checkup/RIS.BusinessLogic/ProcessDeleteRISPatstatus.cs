using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteRISPatstatus : IBusinessLogic
    {
        private RISPatstatus _rispatstatus;
		private bool useTran;
        public ProcessDeleteRISPatstatus()
		{
            _rispatstatus = new RISPatstatus();
			useTran=false;
		}
        public RISPatstatus RISPatstatus
        {
            get { return _rispatstatus; }
            set { _rispatstatus = value; }
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
            RISPatStatusDeleteData _proc = new RISPatStatusDeleteData();
            _proc.RISPatstatus = this.RISPatstatus;
			 _proc.Delete();
		}
    }
}
