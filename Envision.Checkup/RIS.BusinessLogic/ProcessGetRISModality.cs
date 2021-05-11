using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISModality : IBusinessLogic
	{
        RISModality _rismodality;
		private DataSet result;
        private int action;

		public ProcessGetRISModality()
		{
			_rismodality = new  RISModality();
            action = 0;
		}
        public ProcessGetRISModality(bool selectAll) {
            _rismodality = new RISModality();
            action = selectAll ? 1 : 0;
        }

		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
            RISModalitySelectData _proc;
            if (action == 0)
                _proc = new RISModalitySelectData();
            else
                _proc = new RISModalitySelectData(true);
			result=_proc.GetData();
		}
	}
}

