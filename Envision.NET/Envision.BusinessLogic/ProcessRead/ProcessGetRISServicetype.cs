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
	public class ProcessGetRISServicetype : IBusinessLogic
	{
        public RIS_SERVICETYPE RIS_SERVICETYPE { get; set; }
		private DataSet result;

        int action;
        public ProcessGetRISServicetype()
        {
            action = 0;
        }
        public ProcessGetRISServicetype(bool selectAll)
        {
            if (selectAll)
                action = 1;
            else
                action = 0;
        }

		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISServicetypeSelectData _proc=new RISServicetypeSelectData();
            if (action == 1)
                _proc = new RISServicetypeSelectData(true);
			result=_proc.GetData();
		}
	}
}

