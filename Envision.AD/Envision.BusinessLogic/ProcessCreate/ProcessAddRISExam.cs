using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Insert;
using System.Collections.Generic;
using System;
namespace Envision.BusinessLogic.ProcessCreate
{
	public class ProcessAddRISExam : IBusinessLogic
	{
        public RIS_EXAM RIS_EXAM { get; set; }
		public ProcessAddRISExam(){
            RIS_EXAM = new RIS_EXAM();
        }
		public void Invoke()
		{
			RISExamInsertData _proc=new RISExamInsertData();
            _proc.RIS_EXAM = this.RIS_EXAM;
			_proc.Add();
		}
        public void AddFromHIS() {
            RISExamInsertData _proc = new RISExamInsertData();
            _proc.RIS_EXAM = RIS_EXAM;
            _proc.AddByHIS();
        }
	}
}

