using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISReleasemediaNew : IBusinessLogic
    {
        private DataSet result;
        public RIS_RELEASEMEDIA RIS_RELEASEMEDIA { get; set; }
        public ProcessGetRISReleasemediaNew()
		{
            RIS_RELEASEMEDIA = new RIS_RELEASEMEDIA();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISReleasemediaSelectDataNew _proc = new RISReleasemediaSelectDataNew();
			_proc.RIS_RELEASEMEDIA=this.RIS_RELEASEMEDIA;
			result=_proc.GetData();
		}
        public void Invoke_History()
        {
            RISReleasemediaSelectDataNew _proc = new RISReleasemediaSelectDataNew();
            _proc.RIS_RELEASEMEDIA = this.RIS_RELEASEMEDIA;
            result = _proc.GetData_History();
        }
    }
}
