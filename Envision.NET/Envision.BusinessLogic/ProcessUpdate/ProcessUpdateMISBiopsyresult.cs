using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateMISBiopsyresult : IBusinessLogic
	{
        public MIS_BIOPSYRESULT MIS_BIOPSYRESULT { get; set; }
        public DbTransaction Transaction { get; set; }

		public ProcessUpdateMISBiopsyresult()
		{
            MIS_BIOPSYRESULT = new MIS_BIOPSYRESULT();
            Transaction = null;
		}
		public void Invoke()
		{
			MISBiopsyresultUpdateData _proc=new MISBiopsyresultUpdateData();
            _proc.MIS_BIOPSYRESULT = this.MIS_BIOPSYRESULT;
		    _proc.Update();
		}
	}
}

