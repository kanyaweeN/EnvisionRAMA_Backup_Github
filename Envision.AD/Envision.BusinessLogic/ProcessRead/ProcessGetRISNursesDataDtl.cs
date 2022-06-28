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
    public class ProcessGetRISNursesDataDtl : IBusinessLogic
    {
        public RIS_NURSESDATADTL RIS_NURSESDATADTL { get; set; }
        private DataSet result;

        public ProcessGetRISNursesDataDtl()
		{
            RIS_NURSESDATADTL = new RIS_NURSESDATADTL();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISNursesDataDtlSelectData _proc = new RISNursesDataDtlSelectData();
            _proc.RIS_NURSESDATADTL = this.RIS_NURSESDATADTL;
			result=_proc.GetData();
		}
    }
}
