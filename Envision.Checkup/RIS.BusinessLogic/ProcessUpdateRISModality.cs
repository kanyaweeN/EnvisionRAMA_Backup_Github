using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISModality : IBusinessLogic
	{
		private RISModality _rismodality;
		public ProcessUpdateRISModality(){
            _rismodality = new RISModality();
        }
		public RISModality RISModality		{
			get{return _rismodality;}
			set{_rismodality=value;}
		}
		public void Invoke()
		{
			RISModalityUpdateData _proc=new RISModalityUpdateData();
			_proc.RISModality=this.RISModality;
			_proc.Update();
		}
	}
}

