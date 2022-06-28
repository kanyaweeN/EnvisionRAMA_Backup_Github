using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using Envision.Common;
using Envision.BusinessLogic;
using Envision.DataAccess.Select;

namespace Envision.BusinessLogic.ProcessRead
{
    public class ProcessGetRISExamresultKeyimage : IBusinessLogic
    {
        public RIS_EXAMRESULTKEYIMAGES RIS_EXAMRESULTKEYIMAGES {get;set;}
		private DataSet result;

        public ProcessGetRISExamresultKeyimage()
		{
            RIS_EXAMRESULTKEYIMAGES = new RIS_EXAMRESULTKEYIMAGES();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISExamresultKeyimageSelectData _proc = new RISExamresultKeyimageSelectData();
            _proc.RIS_EXAMRESULTKEYIMAGES = this.RIS_EXAMRESULTKEYIMAGES;
			result=_proc.GetData();
		}
    }
}
