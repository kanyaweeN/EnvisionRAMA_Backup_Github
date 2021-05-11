using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISExaminstructions : IBusinessLogic
	{
		private RISExaminstructions _risexaminstructions;
		public ProcessAddRISExaminstructions(){}
		public RISExaminstructions RISExaminstructions		{
			get{return _risexaminstructions;}
			set{_risexaminstructions=value;}
		}
		public void Invoke()
		{
			RISExaminstructionsInsertData _proc=new RISExaminstructionsInsertData();
			_proc.RISExaminstructions=this.RISExaminstructions;
			_proc.Add();
		}
	}
}

