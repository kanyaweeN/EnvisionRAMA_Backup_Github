using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISExaminstructions : IBusinessLogic
	{
        public RIS_EXAMINSTRUCTION RIS_EXAMINSTRUCTION { get; set; }
		public ProcessAddRISExaminstructions()
        {
            RIS_EXAMINSTRUCTION = new RIS_EXAMINSTRUCTION();
        }
		public void Invoke()
		{
			RISExaminstructionsInsertData _proc=new RISExaminstructionsInsertData();
            _proc.RIS_EXAMINSTRUCTION = this.RIS_EXAMINSTRUCTION;
			_proc.Add();
		}
	}
}

