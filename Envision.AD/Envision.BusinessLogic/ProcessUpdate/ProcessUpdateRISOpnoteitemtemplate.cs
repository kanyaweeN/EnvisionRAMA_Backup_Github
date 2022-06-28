using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISOpnoteitemtemplate : IBusinessLogic
	{
        public RIS_OPNOTEITEMTEMPLATE RIS_OPNOTEITEMTEMPLATE { get; set; }

		public ProcessUpdateRISOpnoteitemtemplate()
		{
            RIS_OPNOTEITEMTEMPLATE = new RIS_OPNOTEITEMTEMPLATE();
		}
		public void Invoke()
		{
			RISOpnoteitemtemplateUpdateData _proc=new RISOpnoteitemtemplateUpdateData();
            _proc.RIS_OPNOTEITEMTEMPLATE = this.RIS_OPNOTEITEMTEMPLATE;
			_proc.Update();
		}
	}
}

