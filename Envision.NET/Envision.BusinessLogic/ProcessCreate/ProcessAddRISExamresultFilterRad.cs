using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Insert;

namespace Envision.BusinessLogic.ProcessCreate
{
    public class ProcessAddRISExamresultFilterRad: IBusinessLogic
	{
        public RIS_EXAMRESULT_FILTERRAD RIS_EXAMRESULT_FILTERRAD { get; set; }
        public ProcessAddRISExamresultFilterRad()
		{
            RIS_EXAMRESULT_FILTERRAD = new RIS_EXAMRESULT_FILTERRAD();
		}
		public void Invoke()
		{
            RISExamresultFilterRadInsertData _proc = new RISExamresultFilterRadInsertData();
            _proc.RIS_EXAMRESULT_FILTERRAD = this.RIS_EXAMRESULT_FILTERRAD;
			_proc.Add();
		}
	}
}
