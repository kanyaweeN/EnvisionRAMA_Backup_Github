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
	public class ProcessGetGBLEnvlog : IBusinessLogic
	{
		private DataSet result;
        public GBL_ENVLOG GBL_ENVLOG { get; set; }
		public ProcessGetGBLEnvlog()
		{
			GBL_ENVLOG = new  GBL_ENVLOG();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			GBLEnvlogSelectData _proc=new GBLEnvlogSelectData();
            _proc.GBL_ENVLOG = this.GBL_ENVLOG;
			result=_proc.GetData();
		}
	}
}

