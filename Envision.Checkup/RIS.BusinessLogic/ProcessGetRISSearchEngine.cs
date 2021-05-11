using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;

namespace RIS.BusinessLogic
{
    public class ProcessGetRISSearchEngine
    {
        private DataSet result;
        private RIS.Common.RISSearchEngine _se;

        public ProcessGetRISSearchEngine()
        {
            _se = new RIS.Common.RISSearchEngine();
        }

        public RIS.Common.RISSearchEngine RISSearchEngine
        {
            get { return _se; }
            set { _se = value; }
        }

        public DataSet Result
        {
            get { return result; }
            set { result = value; }
        }
 
		public void Invoke()
		{
            RISSearchEngineSelectData _proc = new RISSearchEngineSelectData();
            _proc.RISSearchEngine = this.RISSearchEngine;
			result=_proc.GetData();
		}
    }
}
