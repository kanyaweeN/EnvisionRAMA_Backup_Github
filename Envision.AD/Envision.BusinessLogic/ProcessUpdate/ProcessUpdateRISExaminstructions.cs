using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISExaminstructions : IBusinessLogic
	{
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }
        public ProcessUpdateRISExaminstructions() { RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION(); }
		public void Invoke()
		{
			RISExaminstructionsUpdateData _proc=new RISExaminstructionsUpdateData();
            _proc.RIS_EXAMINSTRUCTION = this.RIS_EXAMINSTRUCTION;
			_proc.Update();
		}
	}
}

