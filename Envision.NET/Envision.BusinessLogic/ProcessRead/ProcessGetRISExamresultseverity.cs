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
	public class ProcessGetRISExamresultseverity : IBusinessLogic
	{
        public RIS_EXAMRESULTSEVERITY RIS_EXAMRESULTSEVERITY { get; set; }
		private DataSet result;
        private int UnitID = 0;
		public ProcessGetRISExamresultseverity()
		{
            RIS_EXAMRESULTSEVERITY = new RIS_EXAMRESULTSEVERITY();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
        public void Invoke()
        {
            RISExamresultseveritySelectData _proc = new RISExamresultseveritySelectData();
            _proc.RIS_EXAMRESULTSEVERITY = RIS_EXAMRESULTSEVERITY;
            result = _proc.GetData();
        }
        public void GetSeverityLOG(string Accession_no)
        {
            RISExamresultseveritySelectData _proc = new RISExamresultseveritySelectData();
            result = _proc.GetSeverityLOG(Accession_no);
        }
	}
}

