using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;

namespace RIS.BusinessLogic
{
    public class ProcessUpdateRISNursesDataDtl : IBusinessLogic
    {
        private RISNursesDataDtl _risnursesdatadtl;
		private bool useTran;
        public ProcessUpdateRISNursesDataDtl()
		{
            _risnursesdatadtl = new RISNursesDataDtl();
			useTran=false;
		}
        public RISNursesDataDtl RISNursesDataDtl
        {
            get { return _risnursesdatadtl; }
            set { _risnursesdatadtl = value; }
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{

            RISNurseDataDtlUpdateData _proc = new RISNurseDataDtlUpdateData();
            _proc.RISNursesDataDtl = this.RISNursesDataDtl;
			_proc.Update();
		}
    }
}
