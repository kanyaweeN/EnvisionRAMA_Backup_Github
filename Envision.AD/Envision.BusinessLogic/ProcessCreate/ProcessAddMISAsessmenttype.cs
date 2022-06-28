//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    11/06/2552 05:41:23
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddMISAsessmenttype : IBusinessLogic
	{
        public MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE { get; set; }
        public DbTransaction Transaction { get; set; }
		public ProcessAddMISAsessmenttype()
		{
            MIS_ASESSMENTTYPE = new MIS_ASESSMENTTYPE();
            Transaction = null;
		}
		public void Invoke()
		{
			MISAsessmenttypeInsertData _proc=new MISAsessmenttypeInsertData();
            _proc.MIS_ASESSMENTTYPE = this.MIS_ASESSMENTTYPE;
            if (Transaction == null)
                _proc.Add();
            else
                _proc.Add(Transaction);
		}
	}
}

