using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISExam : IBusinessLogic
	{
		private DataSet result;
        private RISExam _risexam;
        private int action;

		public ProcessGetRISExam()
		{
			_risexam = new  RISExam();
            action = 0;
		}
        public ProcessGetRISExam(bool selectAll)
        {
            _risexam = new RISExam();
            action = 1;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamSelectData _proc=new RISExamSelectData();
            if (action == 1)
                _proc = new RISExamSelectData(true);
			result=_proc.GetData();
		}
        public DataSet Consumable() {
            RISExamSelectData _proc = new RISExamSelectData();
            return _proc.GetConsumable();
        }
	}
}

