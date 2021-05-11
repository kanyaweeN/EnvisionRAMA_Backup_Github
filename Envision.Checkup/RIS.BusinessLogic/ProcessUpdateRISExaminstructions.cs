using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISExaminstructions : IBusinessLogic
	{
		private RISExaminstructions _risexaminstructions;
		public ProcessUpdateRISExaminstructions(){}
		public RISExaminstructions RISExaminstructions		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public void Invoke()
		{
			RISExaminstructionsUpdateData _proc=new RISExaminstructionsUpdateData();
			_proc.RISExaminstructions=this.RISExaminstructions;
			_proc.Update();
		}
	}
}

