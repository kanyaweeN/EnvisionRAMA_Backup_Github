using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISNursesDataDtl : IBusinessLogic
    {
        private DataSet result;
		private RISNursesDataDtl _risnursesdatadtl;
        public ProcessGetRISNursesDataDtl()
		{
            _risnursesdatadtl = new RISNursesDataDtl();
		}
        public RISNursesDataDtl RISNursesDataDtl
		{
            get { return _risnursesdatadtl; }
            set { _risnursesdatadtl = value; }
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISNursesDataDtlSelectData _proc = new RISNursesDataDtlSelectData();
			_proc.RISNursesDataDtl=this.RISNursesDataDtl;
			result=_proc.GetData();
		}
    }
}
