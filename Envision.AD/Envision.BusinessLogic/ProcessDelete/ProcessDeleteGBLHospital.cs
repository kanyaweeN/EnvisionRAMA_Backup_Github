using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteGBLHospital : IBusinessLogic
	{
        public GBL_HOSPITAL GBL_HOSPITAL { get; set; } 
        public DbTransaction Transaction { get; set; }
        private GBL_HOSPITALDeleteData _proc;

		public ProcessDeleteGBLHospital()
		{
            GBL_HOSPITAL = new GBL_HOSPITAL();
            Transaction = null;
		}

		public void Invoke()
		{
            _proc = new GBL_HOSPITALDeleteData();
            _proc.GBL_HOSPITAL = GBL_HOSPITAL;
            _proc.Delete();
		}
        public bool DeleteMapping(int HOSID) {
            _proc = new GBL_HOSPITALDeleteData();
            _proc.GBL_HOSPITAL = GBL_HOSPITAL;
            return _proc.DeleteMapping(HOSID);
        }
	}
}

