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
	public class ProcessGetINVPodtl : IBusinessLogic
	{
        public INV_PODTL INV_PODTL { get; set; }
		private DataSet result;

		public ProcessGetINVPodtl()
		{
            INV_PODTL = new INV_PODTL();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPodtlSelectData _proc=new INVPodtlSelectData();
            _proc.INV_PODTL = this.INV_PODTL;
			result=_proc.GetData();
		}
	}
}

