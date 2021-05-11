using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateRISNursesData : IBusinessLogic
    {
        private RISNursesData _risnursesdata;
		private bool useTran;
        public ProcessUpdateRISNursesData()
		{
            _risnursesdata = new RISNursesData();
			useTran=false;
		}
        public RISNursesData RISNursesData
        {
            get { return _risnursesdata; }
            set { _risnursesdata = value; }
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{

            RISNurseDataUpdateData _proc = new RISNurseDataUpdateData();
            _proc.RISNursesData = this.RISNursesData;
			_proc.Update();
		}
    }
}
