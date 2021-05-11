using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISUnlockedCase: IBusinessLogic
	{
        public RIS_UNLOCKEDCASE RIS_UNLOCKEDCASE { get; set; }

        public ProcessUpdateRISUnlockedCase()
		{
            RIS_UNLOCKEDCASE = new RIS_UNLOCKEDCASE();
		}
		public void Invoke()
		{
            RISUnlockedUpdateData _proc = new RISUnlockedUpdateData();
            _proc.RIS_UNLOCKEDCASE = this.RIS_UNLOCKEDCASE;
                _proc.Update();
		}
	}
}

