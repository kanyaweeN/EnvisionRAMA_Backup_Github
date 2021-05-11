using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISModalityexam : IBusinessLogic
	{
		private RISModalityexam _rismodalityexam;
		public ProcessDeleteRISModalityexam(){
            _rismodalityexam = new RISModalityexam();
        }
		public RISModalityexam RISModalityexam		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public void Invoke()
		{
			RISModalityexamDeleteData _proc=new RISModalityexamDeleteData();
			_proc.RISModalityexam=this.RISModalityexam;
			_proc.Delete();
		}
	}
}

