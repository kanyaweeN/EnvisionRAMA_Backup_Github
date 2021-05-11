using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateMISAsessmenttype : IBusinessLogic
	{
        public MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateMISAsessmenttype()
		{
            MIS_ASESSMENTTYPE = new MIS_ASESSMENTTYPE();
            Transaction = null;
		}
		public void Invoke()
		{
			MISAsessmenttypeUpdateData _proc=new MISAsessmenttypeUpdateData();
            _proc.MIS_ASESSMENTTYPE = this.MIS_ASESSMENTTYPE;
            if (Transaction == null)
                _proc.Update();
            else
                _proc.Update(Transaction);
		}
	}
}

