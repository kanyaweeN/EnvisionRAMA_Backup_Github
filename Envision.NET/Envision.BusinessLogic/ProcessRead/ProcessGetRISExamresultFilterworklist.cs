using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using System.Data;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISExamresultFilterworklist: IBusinessLogic
	{
		private DataSet result;
        public RIS_EXAMRESULT_FILTERWORKLIST RIS_EXAMRESULT_FILTERWORKLIST { get; set; }
        public ProcessGetRISExamresultFilterworklist()
		{
            RIS_EXAMRESULT_FILTERWORKLIST = new RIS_EXAMRESULT_FILTERWORKLIST();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISExamresultFilterworklistSelectData _proc = new RISExamresultFilterworklistSelectData();
            _proc.RIS_EXAMRESULT_FILTERWORKLIST = this.RIS_EXAMRESULT_FILTERWORKLIST;
			result=_proc.Get();
		}
        public void getDataByRadid()
        {
            RISExamresultFilterworklistSelectData _proc = new RISExamresultFilterworklistSelectData();
            _proc.RIS_EXAMRESULT_FILTERWORKLIST = this.RIS_EXAMRESULT_FILTERWORKLIST;
            result = _proc.GetDataByRadId();
        }

	}
}

