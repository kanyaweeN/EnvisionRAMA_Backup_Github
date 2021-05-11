using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISModalityexam : IBusinessLogic
	{
		private RISModalityexam _rismodalityexam;
		public ProcessUpdateRISModalityexam(){
            _rismodalityexam = new RISModalityexam();
        }
		public RISModalityexam RISModalityexam		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public void Invoke()
		{
			RISModalityexamUpdateData _proc=new RISModalityexamUpdateData();
			_proc.RISModalityexam=this.RISModalityexam;
			_proc.Update();
		}
	}
}

