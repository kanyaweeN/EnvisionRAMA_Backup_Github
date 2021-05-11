using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISNursesData : IBusinessLogic
    {
        private DataSet result;
		private RISNursesData _risnursesdata;
        public ProcessGetRISNursesData()
		{
            _risnursesdata = new RISNursesData();
		}
        public RISNursesData RISNursesData
		{
            get { return _risnursesdata; }
            set { _risnursesdata = value; }
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISNursesDataSelectData _proc = new RISNursesDataSelectData();
			_proc.RISNursesData=this.RISNursesData;
			result=_proc.GetData();
		}
    }
}
