using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.DataAccess.Update;

namespace Envision.BusinessLogic.ProcessUpdate
{
    public class ProcessUpdateRISExamresultKeyimage : IBusinessLogic
    {
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}

        public DbTransaction Transaction { get; set; }

        public ProcessUpdateRISExamresultKeyimage()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
            Transaction = null;
		}
		public void Invoke()
		{

            RISExamresultKeyimageUpdateData _proc = new RISExamresultKeyimageUpdateData();
            _proc.RIS_EXAMRESULTKEYIMAGES = this.RIS_EXAMRESULTKEYIMAGES;
			_proc.Update();
		}
    }
}
