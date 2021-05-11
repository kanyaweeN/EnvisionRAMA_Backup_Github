using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISModalityexam : IBusinessLogic
	{
        public RIS_MODALITYEXAM RIS_MODALITYEXAM { get; set; }

		public ProcessUpdateRISModalityexam(){
            RIS_MODALITYEXAM = new RIS_MODALITYEXAM();
        }
		public void Invoke()
		{
			RISModalityexamUpdateData _proc=new RISModalityexamUpdateData();
            _proc.RIS_MODALITYEXAM = this.RIS_MODALITYEXAM;
			_proc.Update();
		}
        public void InvokeOnline()
        {
            RISModalityexamUpdateData _proc = new RISModalityexamUpdateData();
            _proc.RIS_MODALITYEXAM = this.RIS_MODALITYEXAM;
            _proc.UpdateOnline();
        }
	}
}

