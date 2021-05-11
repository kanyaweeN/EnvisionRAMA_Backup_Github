using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;

namespace RIS.BusinessLogic
{
    public class ProcessDeleteRISNursesDtlData : IBusinessLogic
    {
         private RISNursesDataDtl _risnursesdatadtl;
		private bool useTran;
        public ProcessDeleteRISNursesDtlData()
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
            RISNursesDtlDeleteData _proc = new RISNursesDtlDeleteData();
            _proc.RISNursesDataDtl = this.RISNursesDataDtl;
			 _proc.Delete();
		}
    }
}
