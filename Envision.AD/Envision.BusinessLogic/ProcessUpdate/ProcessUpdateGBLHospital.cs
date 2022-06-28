using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateGBLHospital : IBusinessLogic
	{
        public GBL_HOSPITAL GBL_HOSPITAL { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateGBLHospital()
		{
            GBL_HOSPITAL = new GBL_HOSPITAL();
            Transaction = null;
		}
		public void Invoke()
		{
			GBLHospitalUpdateData _proc=new GBLHospitalUpdateData();
            _proc.GBL_HOSPITAL = this.GBL_HOSPITAL;
            _proc.Update();
		}
	}
}

