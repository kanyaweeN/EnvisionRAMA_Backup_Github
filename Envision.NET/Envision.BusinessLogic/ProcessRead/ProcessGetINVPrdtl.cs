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
	public class ProcessGetINVPrdtl : IBusinessLogic
	{
        public INV_PRDTL INV_PRDTL { get; set; }
		private DataSet result;

		public ProcessGetINVPrdtl()
		{
            INV_PRDTL = new INV_PRDTL();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVPrdtlSelectData _proc=new INVPrdtlSelectData();
            _proc.INV_PRDTL = this.INV_PRDTL;
			result=_proc.GetData();
		}
	}
}

