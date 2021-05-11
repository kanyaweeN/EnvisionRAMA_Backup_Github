using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISOpnoteitem : IBusinessLogic
	{
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }
		public ProcessAddRISOpnoteitem()
		{
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
		}
		
		public void Invoke()
		{
            RIS_OPNOTEITEMInsertData _proc = new RIS_OPNOTEITEMInsertData();
            _proc.RIS_OPNOTEITEM = RIS_OPNOTEITEM;
            _proc.Add();
		}
	}
}

