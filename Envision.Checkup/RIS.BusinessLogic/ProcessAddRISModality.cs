using System;
using System.Collections.Generic;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Insert;
using System.Data;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISModality : IBusinessLogic
	{
		private RISModality _rismodality;
        private DataSet _ds;
        public ProcessAddRISModality() { _rismodality = new RISModality(); }
		public RISModality RISModality		{
			get{return _rismodality;}
			set{_rismodality=value;}
		}
		public void Invoke()
		{
			RISModalityInsertData _proc=new RISModalityInsertData();
			_proc.RISModality=this.RISModality;
			_ds = _proc.Add();
		}
        public DataSet DataResult
        {
            get { return _ds; }
            set { _ds = value; }
        }
	}
}

