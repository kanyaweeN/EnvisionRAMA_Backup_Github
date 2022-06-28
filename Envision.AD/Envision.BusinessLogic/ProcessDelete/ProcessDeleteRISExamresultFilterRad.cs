using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Envision.Common;
using Envision.DataAccess.Delete;

namespace Envision.BusinessLogic.ProcessDelete
{
    public class ProcessDeleteRISExamresultFilterRad: IBusinessLogic
    {
        public RIS_EXAMRESULT_FILTERRAD RIS_EXAMRESULT_FILTERRAD { get; set; }

        public ProcessDeleteRISExamresultFilterRad()
		{
            RIS_EXAMRESULT_FILTERRAD = new RIS_EXAMRESULT_FILTERRAD();
		}
        
		public void Invoke()
		{
            RISExamresultFilterRadDeleteData _proc = new RISExamresultFilterRadDeleteData();
            _proc.RIS_EXAMRESULT_FILTERRAD = RIS_EXAMRESULT_FILTERRAD;
			 _proc.Delete();
		}
    }
}

