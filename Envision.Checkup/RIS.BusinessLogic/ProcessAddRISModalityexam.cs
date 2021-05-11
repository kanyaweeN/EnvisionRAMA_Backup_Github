using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISModalityexam : IBusinessLogic
	{
		private RISModalityexam _rismodalityexam;
		public ProcessAddRISModalityexam(){
            _rismodalityexam = new RISModalityexam();
        }
		public RISModalityexam RISModalityexam		{
			get{return _rismodalityexam;}
			set{_rismodalityexam=value;}
		}
		public void Invoke()
		{
			RISModalityexamInsertData _proc=new RISModalityexamInsertData();
			_proc.RISModalityexam=this.RISModalityexam;
			_proc.Add();
		}
	}
}

