using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISExamresultseverity : IBusinessLogic
	{
		private DataSet result;
		private RISExamresultseverity _risexamresultseverity;
        private int UnitID = 0;
		public ProcessGetRISExamresultseverity()
		{
			_risexamresultseverity = new  RISExamresultseverity();
		}
        public RISExamresultseverity RISExamresultseverity
        {
            get { return _risexamresultseverity; }
            set { _risexamresultseverity = value; }
        }
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
        public void Invoke()
        {
            RISExamresultseveritySelectData _proc = new RISExamresultseveritySelectData();
            _proc.RISExamresultseverity = _risexamresultseverity;
            result = _proc.GetData();
        }
	}
}

