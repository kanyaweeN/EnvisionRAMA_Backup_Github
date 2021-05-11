using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Delete;
namespace Envision.BusinessLogic.ProcessDelete
{
	public class ProcessDeleteMISAsessmenttype : IBusinessLogic
	{
        public MIS_ASESSMENTTYPE MIS_ASESSMENTTYPE { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessDeleteMISAsessmenttype()
		{
            MIS_ASESSMENTTYPE = new MIS_ASESSMENTTYPE();
            Transaction = null;
		}
		
		public void Invoke()
		{
            MIS_ASESSMENTTYPEDeleteData _proc = new MIS_ASESSMENTTYPEDeleteData();
            _proc.MIS_ASESSMENTTYPE = MIS_ASESSMENTTYPE;
            if (Transaction == null)
                _proc.Delete();
            else
                _proc.Delete(Transaction);
		}
	}
}

