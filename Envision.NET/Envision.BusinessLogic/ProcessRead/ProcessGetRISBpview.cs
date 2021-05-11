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
	public class ProcessGetRISBpview : IBusinessLogic
	{
        public RIS_BPVIEW RIS_BPVIEW { get; set; }
		private DataSet result;

		public ProcessGetRISBpview()
		{
            RIS_BPVIEW = new RIS_BPVIEW();
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISBpviewSelectData _proc=new RISBpviewSelectData();
			result=_proc.GetData();
		}
        public DataTable GetBodyPart()
        {
            RISBpviewSelectData _proc = new RISBpviewSelectData();
            return _proc.GetBodyPart();
        }
	}
}

