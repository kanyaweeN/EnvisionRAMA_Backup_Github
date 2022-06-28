using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISExamhospital : IBusinessLogic
	{
		private DataSet result;
		private RISExamhospital _risexamhospital;
		public ProcessGetRISExamhospital()
		{
			_risexamhospital = new  RISExamhospital();
            _risexamhospital.EXAM_ID = 0;
		}
        public ProcessGetRISExamhospital(int EXAM_ID)
        {
            _risexamhospital = new RISExamhospital();
            _risexamhospital.EXAM_ID = EXAM_ID;
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISExamhospitalSelectData _proc=new RISExamhospitalSelectData();
            _proc.RISExamhospital = _risexamhospital;
			result=_proc.GetData();
		}
	}
}

