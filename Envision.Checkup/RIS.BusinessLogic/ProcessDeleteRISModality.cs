using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISModality : IBusinessLogic
	{
		private RISModality _rismodality;
		public ProcessDeleteRISModality(){}
		public RISModality RISModality		{
			get{return _rismodality;}
			set{_rismodality=value;}
		}
		public void Invoke()
		{
			RISModalityDeleteData _proc=new RISModalityDeleteData();
			_proc.RISModality=this.RISModality;
			_proc.Delete();
		}
	}
}

