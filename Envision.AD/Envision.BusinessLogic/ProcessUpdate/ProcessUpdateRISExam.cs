using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;
namespace Envision.BusinessLogic.ProcessUpdate
{
	public class ProcessUpdateRISExam : IBusinessLogic
	{
        public RIS_EXAM RIS_EXAM { get; set; }

		public ProcessUpdateRISExam(){
            RIS_EXAM = new RIS_EXAM();
        }
		public void Invoke()
		{
			RISExamUpdateData _proc=new RISExamUpdateData();
            _proc.RIS_EXAM = this.RIS_EXAM;
			_proc.Update();
		}
        public void UpdateBarcode(int EXAM_ID, string BARCODE)
        {
            RISExamUpdateData _proc = new RISExamUpdateData();
            _proc.RIS_EXAM = this.RIS_EXAM;
            _proc.UpdateBarcode(EXAM_ID, BARCODE);
        }
	}
}

