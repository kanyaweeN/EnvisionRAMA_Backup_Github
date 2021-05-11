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
	public class ProcessGetGBLMymenu : IBusinessLogic
	{
        public GBL_MYMENU GBL_MYMENU { get; set; }
		private DataSet result;
		public ProcessGetGBLMymenu()
		{
            GBL_MYMENU = new GBL_MYMENU();
            result = new DataSet();
		}
		
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			GBLMymenuSelectData _proc=new GBLMymenuSelectData();
            _proc.GBL_MYMENU = GBL_MYMENU;
			result=_proc.GetData();
		}
	}
}

