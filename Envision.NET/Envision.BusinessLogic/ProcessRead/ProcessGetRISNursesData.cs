using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;
namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISNursesData : IBusinessLogic
    {
        public RIS_NURSESDATA RIS_NURSESDATA { get; set; }
        private DataSet result;

        public ProcessGetRISNursesData()
		{
            RIS_NURSESDATA = new RIS_NURSESDATA();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISNursesDataSelectData _proc = new RISNursesDataSelectData();
            _proc.RIS_NURSESDATA = this.RIS_NURSESDATA;
			result=_proc.GetData();
		}
    }
}
