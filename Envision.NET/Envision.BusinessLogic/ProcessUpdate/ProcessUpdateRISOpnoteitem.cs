using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISOpnoteitem : IBusinessLogic
	{
        public RIS_OPNOTEITEM RIS_OPNOTEITEM { get; set; }

		public ProcessUpdateRISOpnoteitem()
		{
            RIS_OPNOTEITEM = new RIS_OPNOTEITEM();
		}
		public void Invoke()
		{
			RISOpnoteitemUpdateData _proc=new RISOpnoteitemUpdateData();
            _proc.RIS_OPNOTEITEM = this.RIS_OPNOTEITEM;
			_proc.Update();
		}
	}
}

