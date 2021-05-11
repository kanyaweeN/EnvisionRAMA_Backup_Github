using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISServicetype : IBusinessLogic
	{
		private DataSet result;
        private RISServicetype _risservicetype;
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

