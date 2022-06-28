using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISModalityexam : IBusinessLogic
	{
        public RIS_MODALITYEXAM RIS_MODALITYEXAM { get; set; }

		public ProcessAddRISModalityexam(){
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
        }
		public void Invoke()
		{
			RISModalityexamInsertData _proc=new RISModalityexamInsertData();
            _proc.RIS_MODALITYEXAM = this.RIS_MODALITYEXAM;
			_proc.Add();
		}
        public void InvokeOnline()
        {
            RISModalityexamInsertData _proc = new RISModalityexamInsertData();
            _proc.RIS_MODALITYEXAM = this.RIS_MODALITYEXAM;
            _proc.AddOnline();
        }
	}
}

