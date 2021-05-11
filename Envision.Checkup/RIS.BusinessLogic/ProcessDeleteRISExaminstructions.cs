using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISExaminstructions : IBusinessLogic
	{
		private RISExaminstructions _risexaminstructions;
		public ProcessDeleteRISExaminstructions(){}
		public RISExaminstructions RISExaminstructions		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public void Invoke()
		{
			RISExaminstructionsDeleteData _proc=new RISExaminstructionsDeleteData();
			_proc.RISExaminstructions=this.RISExaminstructions;
			_proc.Delete();
		}
	}
}

