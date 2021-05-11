using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISBPViewMapping: IBusinessLogic
	{
        public RIS_BPVIEWMAPPING RIS_BPVIEWMAPPING { get; set; }

        public ProcessDeleteRISBPViewMapping()
        {
            RIS_BPVIEWMAPPING = new RIS_BPVIEWMAPPING();
        }
		
		public void Invoke()
		{
            RISBPViewMappingDeleteData _proc = new RISBPViewMappingDeleteData();
            _proc.RIS_BPVIEWMAPPING = this.RIS_BPVIEWMAPPING;
			_proc.Delete();
		}
	}
}