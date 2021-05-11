using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISUnlocked: IBusinessLogic
	{
		private DataSet result;

        public ProcessGetRISUnlocked()
		{
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISUnlockedSelectData _proc = new RISUnlockedSelectData();
			result=_proc.GetData();
		}
	}
}