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
	public class ProcessGetINVRequisitiondtl : IBusinessLogic
	{
        public INV_REQUISITIONDTL INV_REQUISITIONDTL { get; set; }
		private DataSet result;

		public ProcessGetINVRequisitiondtl()
		{
            INV_REQUISITIONDTL = new INV_REQUISITIONDTL();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			INVRequisitiondtlSelectData _proc=new INVRequisitiondtlSelectData();
            _proc.INV_REQUISITIONDTL = this.INV_REQUISITIONDTL;
			result=_proc.GetData();
		}
	}
}

