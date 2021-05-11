using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISReleasemediaNew : IBusinessLogic
    {
        private DataSet result;
		private RISReleasemedia _risreleasemedia;
        public ProcessGetRISReleasemediaNew()
		{
			_risreleasemedia = new  RISReleasemedia();
		}
		public RISReleasemedia RISReleasemedia
		{
			get{return _risreleasemedia;}
			set{_risreleasemedia=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISReleasemediaSelectDataNew _proc = new RISReleasemediaSelectDataNew();
			_proc.RISReleasemedia=this.RISReleasemedia;
			result=_proc.GetData();
		}
    }
}
