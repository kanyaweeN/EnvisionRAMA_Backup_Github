using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteRISNursesData : IBusinessLogic
    {
        private RISNursesData _risnursesdata;
		private bool useTran;
        public ProcessDeleteRISNursesData()
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
            RISNursesDeleteData _proc = new RISNursesDeleteData();
            _proc.RISNursesData = this.RISNursesData;
			 _proc.Delete();
		}
    }
}
