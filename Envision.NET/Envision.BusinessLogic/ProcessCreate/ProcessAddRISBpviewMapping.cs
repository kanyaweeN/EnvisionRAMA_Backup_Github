using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISBpviewMapping : IBusinessLogic
	{
        public RIS_BPVIEWMAPPING RIS_BPVIEWMAPPING { get; set; }
        public ProcessAddRISBpviewMapping()
		{
            RIS_BPVIEWMAPPING = new RIS_BPVIEWMAPPING();
		}
		public void Invoke()
		{
            RISBpviewMappingInsertData _proc = new RISBpviewMappingInsertData();
            _proc.RIS_BPVIEWMAPPING = this.RIS_BPVIEWMAPPING;
			_proc.Add();
		}
	}
}

