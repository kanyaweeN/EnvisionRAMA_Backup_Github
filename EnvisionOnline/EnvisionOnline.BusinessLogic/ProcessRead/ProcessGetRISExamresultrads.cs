using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using EnvisionOnline.Common;
using EnvisionOnline.BusinessLogic;
using EnvisionOnline.DataAccess.Select;
namespace EnvisionOnline.BusinessLogic.ProcessRead
{
    public class ProcessGetRISExamresultrads
    {
        public RIS_EXAMRESULTRADS RIS_EXAMRESULTRADS{get;set;}
		public DataSet Result {get;set;}

        public ProcessGetRISExamresultrads()
		{
            RIS_EXAMRESULTRADS = new RIS_EXAMRESULTRADS();
		}
		public void Invoke()
		{
            RISExamresultradsSelectData _proc = new RISExamresultradsSelectData();
            _proc.RIS_EXAMRESULTRADS = this.RIS_EXAMRESULTRADS;
            Result = _proc.GetData();
		}
    }
}
